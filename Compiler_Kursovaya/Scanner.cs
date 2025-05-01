using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_Kursovaya
{
    public class Scanner
    {
        private string input;
        private int position;

        public Scanner(string input)
        {
            this.input = input;
            this.position = 0;
        }

        public (int, string, string, int, int) GetNextToken()
        {
            if (position >= input.Length)
                return ((int)TokenType.End, "EOF", "Ошибка", position, position);

            int startPos = position;

            char curr = input[position];
            while (position < input.Length && char.IsWhiteSpace(input[position]))
            {
                position++;
            }

            if (position >= input.Length)
            {
                return ((int)TokenType.End, "EOF", "Ошибка", startPos + 1, position);
            }

            startPos = position;
            char current = input[position];

            if (MatchWord("Const", out int endPos))
            {
                if (endPos + 1 < input.Length && (char.IsLetterOrDigit(input[endPos + 1])))
                {
                    position = startPos;
                }
                else
                {
                    return ((int)TokenType.KeywordConst, "Ключевое слово", "Const", startPos + 1, endPos + 1);
                }
            }

            if (MatchWord("string", out endPos))
            {
                if (endPos + 1 < input.Length && (char.IsLetterOrDigit(input[endPos + 1])))
                {
                    position = startPos;
                }
                else
                {
                    return ((int)TokenType.KeywordString, "Ключевое слово", "string", startPos + 1, endPos + 1);
                }
            }

            if ((current >= 'a' && current <= 'z') ||
                (current >= 'A' && current <= 'Z') ||
                (current >= 'а' && current <= 'я') ||
                (current >= 'А' && current <= 'Я')
            )
            {
                bool hasErrors = false;
                StringBuilder identifier = new StringBuilder();
                while (position < input.Length &&
                    (
                        (((input[position] >= 'a' && input[position] <= 'z') ||
                        (input[position] >= 'A' && input[position] <= 'Z') ||
                        (input[position] >= 'а' && input[position] <= 'я') ||
                        (input[position] >= 'А' && input[position] <= 'Я') ||
                        (input[position] >= '0' && input[position] <= '9')) ||
                        (!char.IsLetterOrDigit(input[position]))) &&
                        (input[position] != ':' && input[position] != '=' && !char.IsWhiteSpace(input[position]) && input[position] != '\'')
                    )
                )
                {
                    if ((input[position] >= 'а' && input[position] <= 'я') ||
                        (input[position] >= 'А' && input[position] <= 'Я') ||
                        (!char.IsLetterOrDigit(input[position]))) 
                    {
                        hasErrors = true;
                    }
                    identifier.Append(input[position]);
                    position++;
                }
                if (!hasErrors)
                {
                    return ((int)TokenType.Identifier, "Идентификатор", identifier.ToString(), startPos + 1, position);
                }
                else
                {
                    return ((int)TokenType.Error, "Ошибка", identifier.ToString(), startPos + 1, position);
                }
            }


            if (current == ':')
            {
                position++;
                return ((int)TokenType.Symbol, "Символ", current.ToString(), startPos + 1, position);
            }

            if (current == '=')
            {
                position++;
                return ((int)TokenType.AssignmentOperator, "Оператор присваивания", current.ToString(), startPos + 1, position);
            }

            if (current == '\'')
            {
                bool hasErrors = false;
                position++;
                StringBuilder strLiteral = new StringBuilder();
                strLiteral.Append("'");
                while (position < input.Length && input[position] != '\n')
                {
                    if (input[position] == '\'')
                    {
                        strLiteral.Append("'");
                        position++;
                        if (!hasErrors)
                        {
                            return ((int)TokenType.StringLiteral, "Строка", strLiteral.ToString(), startPos + 1, position);
                        }
                        else
                        {
                            return ((int)TokenType.Error, "Ошибка", strLiteral.ToString(), startPos + 1, position);
                        }
                    }
                    if (!char.IsLetterOrDigit(input[position]))
                    {
                        hasErrors = true;
                    }
                    strLiteral.Append(input[position]);
                    position++;
                }
                if (position < input.Length && input[position] == '\'')
                {
                    strLiteral.Append("'");
                    position++;
                }
                return ((int)TokenType.Error, "Ошибка", strLiteral.ToString(), startPos + 1, position);
            }

            if (current == ';')
            {
                position++;
                return ((int)TokenType.EndStatement, "Конец оператора", ";", startPos + 1, position);
            }

            if (!
                    (
                        (current >= 'a' && current <= 'z') ||
                        (current >= 'A' && current <= 'Z') ||
                        current == ':' ||
                        current == ';' ||
                        current == '\'' ||
                        current == '='
                    )
                )
            {
                StringBuilder errorLiteral = new StringBuilder();
                while (position < input.Length &&
                    (!
                        (
                            input[position] == ':' ||
                            input[position] == ';' ||
                            input[position] == '\'' ||
                            input[position] == '=' ||
                            char.IsWhiteSpace(input[position])
                        )
                    )
                )
                {
                    errorLiteral.Append(input[position]);
                    position++;
                }
                return ((int)TokenType.Error, "Недопустимый символ", errorLiteral.ToString(), startPos + 1, position);
            }
            position++;
            return ((int)TokenType.End, "EOF", "Ошибка", position, position);
        }

        private bool MatchWord(string word, out int endPos)
        {
            if (input.Substring(position).StartsWith(word))
            {
                endPos = position + word.Length - 1;
                position += word.Length;
                return true;
            }
            endPos = position;
            return false;
        }
    }
}
