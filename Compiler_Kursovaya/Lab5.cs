using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Compiler_Kursovaya
{
    class Lab5
    {
        private string input;
        private int position;
        public List<string> errors = new List<string>();
        private List<Quadruple> quadruples = new List<Quadruple>();
        private int tempVarCounter = 1;

        public struct Quadruple
        {
            public string Op { get; set; }
            public string Arg1 { get; set; }
            public string Arg2 { get; set; }
            public string Result { get; set; }
        }

        public Lab5(string input)
        {
            this.input = input.Replace(" ", "");
            this.position = 0;
        }

        public void Parse()
        {
            try
            {
                quadruples.Clear();
                tempVarCounter = 1;

                if (input.Contains("="))
                {
                    int equalPos = input.IndexOf('=');
                    string leftPart = input.Substring(0, equalPos);
                    string rightPart = input.Substring(equalPos + 1);

                    this.input = rightPart;
                    this.position = 0;
                    E();

                    var lastQuad = quadruples[quadruples.Count - 1];
                    quadruples.Add(new Quadruple
                    {
                        Op = "=",
                        Arg1 = lastQuad.Result,
                        Arg2 = "",
                        Result = leftPart
                    });
                }
                else
                {
                    E();
                }

                if (position != input.Length)
                {
                    errors.Add($"Ошибка: неожиданный символ '{input[position]}' в позиции {position}");
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
        }

        private string E()
        {
            var left = T();
            return A(left);
        }

        private string A(string left)
        {
            if (position < input.Length && (input[position] == '+' || input[position] == '-'))
            {
                char op = input[position];
                position++;
                var right = T();

                string result = $"t{tempVarCounter++}";
                quadruples.Add(new Quadruple
                {
                    Op = op.ToString(),
                    Arg1 = left,
                    Arg2 = right,
                    Result = result
                });

                return A(result);
            }
            return left;
        }

        private string T()
        {
            var left = F();
            return B(left);
        }

        private string B(string left)
        {
            if (position < input.Length && (input[position] == '*' || input[position] == '/'))
            {
                char op = input[position];
                position++;
                var right = F();

                string result = $"t{tempVarCounter++}";
                quadruples.Add(new Quadruple
                {
                    Op = op.ToString(),
                    Arg1 = left,
                    Arg2 = right,
                    Result = result
                });

                return B(result);
            }
            return left;
        }

        private string F()
        {
            if (position < input.Length && input[position] == '-')
            {
                position++;
                var operand = O();

                string result = $"t{tempVarCounter++}";
                quadruples.Add(new Quadruple
                {
                    Op = "minus",
                    Arg1 = operand,
                    Arg2 = "",
                    Result = result
                });

                return result;
            }
            return O();
        }

        private string O()
        {
            if (position < input.Length && char.IsLetter(input[position]))
            {
                return Id();
            }
            else if (position < input.Length && input[position] == '(')
            {
                position++;
                var expr = E();
                if (position >= input.Length || input[position] != ')')
                {
                    throw new Exception($"Ошибка: ожидается закрывающая скобка в позиции {position}");
                }
                position++;
                return expr;
            }
            throw new Exception($"Ошибка: ожидается идентификатор или скобка в позиции {position}");
        }

        private string Id()
        {
            string id = "";
            while (position < input.Length && char.IsLetter(input[position]))
            {
                id += input[position];
                position++;
            }
            return id;
        }

        public void DisplayQuadruplesInDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            foreach (var quad in quadruples)
            {
                dataGridView.Rows.Add(quad.Op, quad.Arg1, quad.Arg2, quad.Result);
            }
        }

        public void PrintErrors(DataGridView dgv)
        {
            if (errors.Count == 0)
            {
                dgv.Rows.Add("Ошибок не обнаружено. Синтаксический анализ завершен успешно.");
            }
            else
            {
                foreach (var error in errors)
                {
                    dgv.Rows.Add(error);
                }
            }
        }
    }
}