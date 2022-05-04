using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;

namespace Qsu.AST.Expressions
{
    public class IfExpression : IExpression
    {
        public Token Token;
        public IExpression Condition;
        public IExpression Consequence;
        public IExpression Alternative;

        public string ToCode()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("if");
            builder.Append(Condition.ToCode());
            builder.Append(" ");
            builder.Append(Consequence.ToCode());

            //elseがあるなら
            if (Alternative != null)
            {
                builder.Append("else ");
                builder.Append(Alternative.ToCode());
            }

            return builder.ToString();
        }

        public string TokenLiteral() => Token.Literal;
    }
}
