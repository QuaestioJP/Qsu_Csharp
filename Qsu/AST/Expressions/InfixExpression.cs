using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;

namespace Qsu.AST.Expressions
{
    public class InfixExpression : IExpression
    {
        public Token Token;
        public IExpression Left;
        public string Operator;
        public IExpression Right;

        public string ToCode()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            builder.Append(Left.ToCode());
            builder.Append(" ");
            builder.Append(Operator);
            builder.Append(" ");
            builder.Append(Right.ToCode());
            builder.Append(")");

            return builder.ToString();
        }

        public string TokenLiteral() => Token.Literal;
    }
}
