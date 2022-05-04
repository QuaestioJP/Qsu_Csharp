using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;

namespace Qsu.AST.Expressions
{
    public class BlockExpression : IExpression
    {
        public Token Token;
        public List<IStatement> Statements;

        public string ToCode()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var statement in Statements)
            {
                builder.Append(statement.ToCode());
            }
            return builder.ToString();
        }

        public string TokenLiteral() => Token.Literal;
    }
}
