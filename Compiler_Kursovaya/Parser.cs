using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Compiler_Kursovaya
{
    class Parser
    {
        private List<(int, string, string, int, int)> tokens;
        private int position;
        private DataGridView grid;
        private List<ErrorInfo> errors;
        private State parserState;

        //код, тип, содержание, начало, конец 
        public Parser(List<(int, string, string, int, int)> tokens, DataGridView grid)
        {
            this.tokens = tokens;
            this.position = 0;
            this.grid = grid;
            this.errors = new List<ErrorInfo>();
            this.parserState = State.START;
        }

        public void Run()   
        {
            while (position < tokens.Count())
            {
                var token = tokens[position];
                switch (parserState)
                {
                    case State.START:
                        if (token.Item1 == 1)
                        {
                            parserState = State.ID;
                        }
                        else if (token.Item1 == 9)
                        {
                            if (char.IsDigit(token.Item3[0]))
                            {
                                AddError("Ключевое слово не может начинаться с цифры!", token);
                            }
                            for (int i = 0; i < token.Item3.Length; i++)
                            {
                                if (((token.Item3[i] >= 'а') && (token.Item3[i] <= 'я')) || ((token.Item3[i] >= 'А') && (token.Item3[i] <= 'Я')) || (!char.IsLetterOrDigit(token.Item3[i])))
                                {
                                    int errPosStart = token.Item4 + i;
                                    int errPosEnd = errPosStart;
                                    while ((((token.Item3[i] >= 'а') && (token.Item3[i] <= 'я')) || ((token.Item3[i] >= 'А') && (token.Item3[i] <= 'Я')) || (!char.IsLetterOrDigit(token.Item3[i]))) && (i < token.Item3.Length - 1))
                                    {
                                        i++;
                                        errPosEnd++;
                                    }
                                    AddError("Ключевое слово не может содержать неопознанные символы и символы кириллицы! ", token);
                                }
                            }
                            parserState = State.ID;
                        }
                        else if (position >= tokens.Count())
                        {
                            AddError("Ожидалось ключевое слово 'Const', но лексемы не найдено.");
                        }
                        else if (position < tokens.Count())
                        {
                            int count = 0;
                            bool fullExit = false;
                            bool tempExit = false;
                            int errPosStart = token.Item4;
                            int tempPos = position;
                            var tempToken = tokens[tempPos];
                            while (tempToken.Item1 != 2 && tempPos <= tokens.Count())
                            {
                                if (tempToken.Item1 == 8)
                                {
                                    if (count == 0)
                                    {
                                        fullExit = true;
                                        AddError("Ожидалось ключевое слово 'Const'.", tempToken);
                                        parserState = State.END;
                                        break;
                                    }
                                    fullExit = true;
                                    AddError("Ожидалось ключевое слово 'Const'.", tempToken);
                                    parserState = State.ID;
                                    break;
                                }
                                count++;
                                tempPos++;
                                if (tempPos < tokens.Count())
                                {
                                    tempToken = tokens[tempPos];
                                }
                                else
                                {
                                    fullExit = true;
                                    AddError("Ожидалось ключевое слово 'Const'.", tempToken);
                                    parserState = State.ID;
                                    break;
                                }
                            }
                            if (tempExit)
                            {
                                break;
                            }
                            if (fullExit)
                            {
                                continue;
                            }
                            position = tempPos;
                            position++;
                            parserState = State.ID;
                            AddError("Ожидалось ключевое слово 'Const'.", tempToken);
                            continue;
                        }
                        else
                        {
                            AddError("Ожидалось ключевое слово 'Const'.", token);
                            parserState = State.ID;
                        }
                        if (position - tokens.Count == -1)
                        {
                            continue;
                        }
                        break;

                    case State.ID:
                        if (token.Item1 == 2)
                        {
                            parserState = State.COLON;
                        }
                        else if (token.Item1 == 9)
                        {
                            if (char.IsDigit(token.Item3[0]))
                            {
                                AddError("Идентификатор не может начинаться с цифры!", token);
                            }
                            for (int i = 0; i < token.Item3.Length; i++)
                            {
                                if (((token.Item3[i] >= 'а') && (token.Item3[i] <= 'я')) || ((token.Item3[i] >= 'А') && (token.Item3[i] <= 'Я')) || (!char.IsLetterOrDigit(token.Item3[i])))
                                {
                                    int errPosStart = token.Item4 + i;
                                    int errPosEnd = errPosStart;
                                    while ((((token.Item3[i] >= 'а') && (token.Item3[i] <= 'я')) || ((token.Item3[i] >= 'А') && (token.Item3[i] <= 'Я')) || (!char.IsLetterOrDigit(token.Item3[i]))) && (i < token.Item3.Length - 1))
                                    {
                                        i++;
                                        errPosEnd++;
                                    }
                                    AddError("Идентификатор не может содержать неопознанные символы и символы кириллицы!", token);
                                }
                            }
                            parserState = State.COLON;
                        }
                        else if (position >= tokens.Count())
                        {
                            AddError("Ожидался идентификатор, но лексемы не найдено.");
                        }
                        else if (position < tokens.Count())
                        {
                            int count = 0;
                            bool fullExit = false;
                            bool tempExit = false;
                            int errPosStart = token.Item4;
                            int tempPos = position;
                            var tempToken = tokens[tempPos];
                            while (tempToken.Item1 != 5 && tempPos <= tokens.Count())
                            {
                                if (tempToken.Item1 == 8)
                                {
                                    if (count == 0)
                                    {
                                        fullExit = true;
                                        AddError("Ожидался идентификатор.", tempToken);
                                        parserState = State.END;
                                        break;
                                    }
                                    fullExit = true;
                                    AddError("Ожидался идентификатор.", tempToken);
                                    parserState = State.COLON;
                                    break;
                                }
                                count++;
                                tempPos++;
                                if (tempPos < tokens.Count())
                                {
                                    tempToken = tokens[tempPos];
                                }
                                else
                                {
                                    fullExit = true;
                                    AddError("Ожидался идентификатор.", tempToken);
                                    parserState = State.COLON;
                                    break;
                                }
                            }
                            if (tempExit)
                            {
                                break;
                            }
                            if (fullExit)
                            {
                                continue;
                            }
                            position = tempPos;
                            parserState = State.COLON;
                            AddError("Ожидался идентификатор.", tempToken);
                            continue;
                        }
                        else
                        {
                            AddError("Ожидался идентификатор.", token);
                            parserState = State.COLON;
                        }
                        if (position - tokens.Count == -1)
                        {
                            continue;
                        }
                        break;

                    case State.COLON:
                        if (token.Item1 == 5)
                        {
                            parserState = State.TYPE;
                        }
                        else if (position >= tokens.Count())
                        {
                            AddError("Ожидался символ ':', но лексемы не найдено.");
                        }
                        else if (position < tokens.Count())
                        {
                            int count = 0;
                            bool fullExit = false;
                            bool tempExit = false;
                            int errPosStart = token.Item4;
                            int tempPos = position;
                            var tempToken = tokens[tempPos];
                            while (tempToken.Item1 != 3 && tempPos <= tokens.Count())
                            {
                                if (tempToken.Item1 == 8)
                                {
                                    if (count == 0)
                                    {
                                        fullExit = true;
                                        AddError("Ожидался символ ':'.", tempToken);
                                        parserState = State.END;
                                        break;
                                    }
                                    fullExit = true;
                                    AddError("Ожидался символ ':'.", tempToken);
                                    parserState = State.TYPE;
                                    break;
                                }
                                count++;
                                tempPos++;
                                if (tempPos < tokens.Count())
                                {
                                    tempToken = tokens[tempPos];
                                }
                                else
                                {
                                    fullExit = true;
                                    AddError("Ожидался символ ':'.", tempToken);
                                    parserState = State.TYPE;
                                    break;
                                }
                            }
                            if (tempExit)
                            {
                                break;
                            }
                            if (fullExit)
                            {
                                continue;
                            }
                            position = tempPos;
                            parserState = State.TYPE;
                            AddError("Ожидался символ ':'.", tempToken);
                            continue;
                        }
                        else
                        {
                            AddError("Ожидался символ ':'.", token);
                            parserState = State.TYPE;
                        }
                        break;

                    case State.TYPE:
                        if (token.Item1 == 3)
                        {
                            parserState = State.EQUAL;
                        }
                        else if (token.Item1 == 9)
                        {
                            if (char.IsDigit(token.Item3[0]))
                            {
                                AddError("Ключевое слово не может начинаться с цифры!", token);
                            }
                            for (int i = 0; i < token.Item3.Length; i++)
                            {
                                if (((token.Item3[i] >= 'а') && (token.Item3[i] <= 'я')) || ((token.Item3[i] >= 'А') && (token.Item3[i] <= 'Я')) || (!char.IsLetterOrDigit(token.Item3[i])))
                                {
                                    int errPosStart = token.Item4 + i;
                                    int errPosEnd = errPosStart;
                                    while ((((token.Item3[i] >= 'а') && (token.Item3[i] <= 'я')) || ((token.Item3[i] >= 'А') && (token.Item3[i] <= 'Я')) || (!char.IsLetterOrDigit(token.Item3[i]))) && (i < token.Item3.Length-1))
                                    {
                                        i++;
                                        errPosEnd++;
                                    }
                                    AddError("Ключевое слово не может содержать неопознанные символы и символы кириллицы! ", token);
                                }
                            }
                            parserState = State.EQUAL;
                        }
                        else if (position >= tokens.Count())
                        {
                            AddError("Ожидалось ключевое слово 'string', но лексемы не найдено.");
                        }
                        else if (position < tokens.Count())
                        {
                            int count = 0;
                            bool fullExit = false;
                            bool tempExit = false;
                            int errPosStart = token.Item4;
                            int tempPos = position;
                            var tempToken = tokens[tempPos];
                            while (tempToken.Item1 != 6 && tempPos <= tokens.Count())
                            {
                                if (tempToken.Item1 == 8)
                                {
                                    if (count == 0)
                                    {
                                        fullExit = true;
                                        AddError("Ожидалось ключевое слово 'string'.", tempToken);
                                        parserState = State.END;
                                        break;
                                    }
                                    fullExit = true;
                                    AddError("Ожидалось ключевое слово 'string'.", tempToken);
                                    parserState = State.EQUAL;
                                    break;
                                }
                                count++;
                                tempPos++;
                                if (tempPos < tokens.Count())
                                {
                                    tempToken = tokens[tempPos];
                                }
                                else
                                {
                                    fullExit = true;
                                    AddError("Ожидалось ключевое слово 'string'.", tempToken);
                                    parserState = State.EQUAL;
                                    break;
                                }
                            }
                            if (tempExit)
                            {
                                break;
                            }
                            if (fullExit)
                            {
                                continue;
                            }
                            position = tempPos;
                            parserState = State.EQUAL;
                            AddError("Ожидалось ключевое слово 'string'.", tempToken);
                            continue;
                        }
                        else
                        {
                            AddError("Ожидалось ключевое слово 'string'.", token);
                            parserState = State.EQUAL;
                        }
                        if (position-tokens.Count == -1)
                        {
                            continue;
                        }
                        break;

                    case State.EQUAL:
                        if (token.Item1 == 6)
                        {
                            parserState = State.STRING;
                        }
                        else if (position >= tokens.Count())
                        {
                            AddError("Ожидался символ '=', но лексемы не найдено.");
                        }
                        else if (position < tokens.Count())
                        {
                            int count = 0;
                            bool fullExit = false;
                            bool tempExit = false;
                            int errPosStart = token.Item4;
                            int tempPos = position;
                            var tempToken = tokens[tempPos];
                            while (tempToken.Item1 != 7 && tempPos <= tokens.Count())
                            {
                                if (tempToken.Item1 == 8)
                                {
                                    if (count == 0)
                                    {
                                        fullExit = true;
                                        AddError("Ожидался символ '='.", tempToken);
                                        parserState = State.END;
                                        break;
                                    }
                                    fullExit = true;
                                    AddError("Ожидался символ '='.", tempToken);
                                    parserState = State.STRING;
                                    break;
                                }
                                count++;
                                tempPos++;
                                if (tempPos < tokens.Count())
                                {
                                    tempToken = tokens[tempPos];
                                }
                                else if (tokens.Count - position == 1)
                                {
                                    fullExit = true;
                                    AddError("Ожидался символ '='.", tempToken);
                                    parserState = State.STRING;
                                    break;
                                }
                                else
                                {
                                    tempExit = true;
                                    AddError("Ожидался символ '='.", tempToken);
                                    parserState = State.STRING;
                                    break;
                                }
                            }
                            if (tempExit)
                            {
                                break;
                            }
                            if (fullExit)
                            {
                                continue;
                            }
                            position = tempPos;
                            parserState = State.STRING;
                            AddError("Ожидался символ '='.", tempToken);
                            continue;
                        }
                        else
                        {
                            AddError("Ожидался символ '='.", token);
                            parserState = State.STRING;
                        }
                        break;

                    case State.STRING:
                        if (token.Item1 == 7)
                        {
                            if (position-tokens.Count() == -1)
                            {
                                parserState = State.END;
                                continue;
                            }
                            parserState = State.END;
                        }
                        else if (token.Item1 == 9)
                        {
                            if (token.Item3[0] != '\'')
                            {
                                AddError("Строка должна начинаться с символа '\''.", token);
                            }
                            else if (token.Item3[token.Item3.Length-1] != '\'')
                            {
                                AddError("Строка должна заканчиваться символом '\''.", token);
                            }
                            else
                            {
                                for (int i = 0; i < token.Item3.Length; i++)
                                {
                                    if (!char.IsLetterOrDigit(token.Item3[i]) && token.Item3[i] != '\'')
                                    {
                                        AddError($"Неопознанный символ в строке: {token.Item3[i]}!", token);
                                    }
                                }
                            }
                            if (position - tokens.Count() == -1)
                            {
                                parserState = State.END;
                                continue;
                            }
                            else
                            {
                                parserState = State.END;
                                position++;
                                continue;
                            }
                        }
                        else if (position >= tokens.Count())
                        {
                            AddError("Ожидалась строка, но лексемы не найдено.");
                        }
                        else if (position < tokens.Count())
                        {
                            int count = 0;
                            bool fullExit = false;
                            bool tempExit = false;
                            int errPosStart = token.Item4;
                            int tempPos = position;
                            var tempToken = tokens[tempPos];
                            while (tempPos <= tokens.Count())
                            {
                                if (tempToken.Item1 == 8)
                                {
                                    if (count == 0)
                                    {
                                        fullExit = true;
                                        AddError("Ожидалась строка.", tempToken);
                                        parserState = State.END;
                                        break;
                                    }
                                    fullExit = true;
                                    AddError("Ожидалась строка.", tempToken);
                                    parserState = State.END;
                                    break;
                                }
                                if (tempToken.Item1 == 7)
                                {
                                    position = tempPos;
                                    fullExit = true;
                                    break;
                                }
                                count++;
                                tempPos++;
                                if (tempPos < tokens.Count())
                                {
                                    tempToken = tokens[tempPos];
                                }
                                else
                                {
                                    tempExit = true;
                                    AddError("Ожидалась строка.", tempToken);
                                    parserState = State.END;
                                    break;
                                }
                            }
                            if (tempExit)
                            {
                                break;
                            }
                            if (fullExit)
                            {
                                position++;
                                continue;
                            }
                            position = tempPos;
                            parserState = State.END;
                            AddError("Ожидалась строка.", tempToken);
                            continue;
                        }
                        else
                        {
                            AddError("Ожидалась строка.", token);
                            parserState = State.END;
                        }
                        break;

                    case State.END:
                        if (token.Item1 == 8 && position >= tokens.Count())
                        {
                            return;
                        }
                        else if (token.Item1 == 8 && position < tokens.Count())
                        {
                            parserState = State.START;
                        }
                        else if (position <= tokens.Count())
                        {
                            bool fullExit = false;
                            bool tempExit = false;
                            int errPosStart = token.Item4;
                            int tempPos = position;
                            var tempToken = tokens[tempPos];
                            while (tempPos < tokens.Count())
                            {
                                if (tempToken.Item1 == 8)
                                {
                                    fullExit = true;
                                    AddError("Ожидался символ ';'.", tempToken);
                                    parserState = State.START;
                                    break;
                                }
                                tempPos++;
                                if (tempPos == tokens.Count())
                                {
                                    AddError("Ожидался символ ';'.", tempToken);
                                    tempExit = true;
                                    break;
                                }
                                tempToken = tokens[tempPos];
                            }
                            if (tempExit)
                            {
                                break;
                            }
                            if (fullExit)
                            {
                                continue;
                            }
                            position = tempPos;
                            parserState = State.START;
                            AddError("Ожидался символ ';'.", tempToken);
                            continue;
                        }
                        else
                        {
                            AddError("Ожидался символ ';'.", token);
                        }
                        break;
                }
                position++;
            }
            DisplayErrors();
        }

        private void AddError(string message, (int, string, string, int, int)? token)
        {
            errors.Add(new ErrorInfo
            {
                Name = "Ошибка синтаксиса",
                Value = message,
                Location = token == null ? "В конце строки" : $"С {token.Value.Item4} по {token.Value.Item5} символ"
            });
        }
        private void AddError(string message)
        {
            errors.Add(new ErrorInfo
            {
                Name = "Ошибка синтаксиса",
                Value = message,
                Location = "Конец введённой строки"
            });
        }

        private void DisplayErrors()
        {
            foreach (var error in errors)
            {
                grid.Rows.Add(error.Name, error.Value, error.Location);
            }
        }

        private enum State
        {
            START,
            ID,
            COLON,
            TYPE,
            EQUAL,
            STRING,
            END
        }
    }

    public class ErrorInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Location { get; set; }
    }
}
