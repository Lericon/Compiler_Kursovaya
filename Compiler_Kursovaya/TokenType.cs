using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_Kursovaya
{
    public enum TokenType
    {
        KeywordConst = 1,
        Identifier = 2,
        KeywordString = 3,
        Separator = 4,
        Symbol = 5,
        AssignmentOperator = 6,
        StringLiteral = 7,
        EndStatement = 8,
        Error = 9,
        End = -1
    }
}
