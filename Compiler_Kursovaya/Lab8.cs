using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler_Kursovaya
{
    public enum Lab8_TokenType
    {
        Digit,
        Dot,
        Plus,
        Minus,
        Ten,
        EOF,
        Unknown
    }
    public class Lab8_Token
    {
        public Lab8_TokenType Type { get; }
        public string Value { get; }

        public Lab8_Token(Lab8_TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }

    public class Lab8_Lexer
    {
        private readonly string _input;
        private int _pos = 0;
        private readonly List<Lab8_Token> _tokens = new List<Lab8_Token>();

        public Lab8_Lexer(string input)
        {
            _input = input;
            Tokenize();
        }

        private void Tokenize()
        {
            while (_pos < _input.Length)
            {
                // Пропуск пробелов и табов
                while (_pos < _input.Length && char.IsWhiteSpace(_input[_pos]))
                    _pos++;

                if (_pos >= _input.Length)
                    break;

                char c = _input[_pos];

                if (char.IsDigit(c))
                {
                    string number = "";
                    while (_pos < _input.Length && char.IsDigit(_input[_pos]))
                        number += _input[_pos++];

                    if (number == "10")
                        _tokens.Add(new Lab8_Token(Lab8_TokenType.Ten, number));
                    else
                        foreach (char digit in number)
                            _tokens.Add(new Lab8_Token(Lab8_TokenType.Digit, digit.ToString()));
                }
                else if (c == '.')
                {
                    _tokens.Add(new Lab8_Token(Lab8_TokenType.Dot, "."));
                    _pos++;
                }
                else if (c == '+')
                {
                    _tokens.Add(new Lab8_Token(Lab8_TokenType.Plus, "+"));
                    _pos++;
                }
                else if (c == '-')
                {
                    _tokens.Add(new Lab8_Token(Lab8_TokenType.Minus, "-"));
                    _pos++;
                }
                else
                {
                    _tokens.Add(new Lab8_Token(Lab8_TokenType.Unknown, c.ToString()));
                    _pos++;
                }
            }

            _tokens.Add(new Lab8_Token(Lab8_TokenType.EOF, ""));
        }

        public List<Lab8_Token> GetTokens() => _tokens;
    }

    public class Lab8_Parser
    {
        private List<Lab8_Token> _tokens;
        private int _pos;
        private List<string> _trace;

        public Lab8_Parser(List<Lab8_Token> tokens)
        {
            _tokens = tokens;
            _pos = 0;
            _trace = new List<string>();
        }

        public List<string> GetParseTrace()
        {
            _trace.Clear();
            if (ParseUnsignedNumber())
                return _trace;
            List<string> error = new List<string>() { "Ошибка синтаксического анализа" };
            return error;
        }

        private Lab8_Token Current => _pos < _tokens.Count ? _tokens[_pos] : new Lab8_Token(Lab8_TokenType.EOF, "EOF");

        private bool Match(Lab8_TokenType type, string value = null)
        {
            if (Current.Type == type && (value == null || Current.Value == value))
            {
                _trace.Add(Current.Value);
                _pos++;
                return true;
            }
            return false;
        }

        private bool MatchDigit()
        {
            if (Current.Type == Lab8_TokenType.Digit)
            {
                _trace.Add(Current.Value);
                _pos++;
                return true;
            }
            return false;
        }

        private bool Try(Func<bool> func)
        {
            int save = _pos;
            int traceCount = _trace.Count;
            bool result = func();
            if (!result)
            {
                _pos = save;
                _trace.RemoveRange(traceCount, _trace.Count - traceCount);
            }
            return result;
        }

        public bool ParseUnsignedNumber()
        {
            _trace.Add("unsigned_number");
            return Try(() => ParseDecimalNumber() && ParseExponentialPart()) ||
                   Try(ParseExponentialPart) ||
                   Try(ParseDecimalNumber);
        }

        private bool ParseDecimalNumber()
        {
            _trace.Add("decimal_number");
            return Try(() => ParseUnsignedInteger() && ParseDecimalFraction()) ||
                   Try(ParseDecimalFraction) ||
                   Try(ParseUnsignedInteger);
        }

        private bool ParseUnsignedInteger()
        {
            _trace.Add("unsigned_integer");
            if (!MatchDigit()) return false;
            while (MatchDigit()) { }
            return true;
        }

        private bool ParseDecimalFraction()
        {
            _trace.Add("decimal_fraction");
            if (!Match(Lab8_TokenType.Dot, ".")) return false;
            return ParseUnsignedInteger();
        }

        private bool ParseExponentialPart()
        {
            _trace.Add("exponential_part");
            if (!Match(Lab8_TokenType.Ten, "10")) return false;
            return ParseInteger();
        }

        private bool ParseInteger()
        {
            _trace.Add("integer");
            if (Match(Lab8_TokenType.Plus, "+") || Match(Lab8_TokenType.Minus, "-"))
                return ParseUnsignedInteger();
            return ParseUnsignedInteger();
        }
    }
}
