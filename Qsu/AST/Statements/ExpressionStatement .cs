using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;

namespace Qsu.AST.Statements
{
    public class ExpressionStatement : IStatement
    {
        public Token Token;
        public IExpression Expression;

        public string ToCode() => Expression?.ToCode() ?? "";

        public string TokenLiteral() => Token.Literal;
    }
}
