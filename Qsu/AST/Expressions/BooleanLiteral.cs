using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;

namespace Qsu.AST.Expressions
{
    public class BooleanLiteral : IExpression
    {
        public Token Token;
        public bool Value;

        public string ToCode() => Token.Literal;
        public string TokenLiteral() => Token.Literal;
    }
}
