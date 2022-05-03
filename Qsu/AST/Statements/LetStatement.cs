using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;
using Qsu.AST.Expressions;

namespace Qsu.AST.Statements
{
    public class LetStatement : IStatement
    {
        public Token Token;
        public Identifier Name;
        public IExpression Value;

        public string TokenLiteral() => Token.Literal;

        public string ToCode()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Token?.Literal ?? "");
            builder.Append(" ");
            builder.Append(Name?.ToCode() ?? "");
            builder.Append(" = ");
            builder.Append(Value?.ToCode() ?? "");
            builder.Append(";");

            return builder.ToString();
        }
    }
}
