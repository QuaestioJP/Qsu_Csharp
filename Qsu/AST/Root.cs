using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qsu.AST
{
    public class Root : INode
    {
        public List<IStatement> Statements;

        public string TokenLiteral()
        {
            return Statements.FirstOrDefault()?.TokenLiteral() ?? "";
        }
        public string ToCode()
        {
            var builder = new StringBuilder();
            foreach (var ast in Statements)
            {
                builder.AppendLine(ast.ToCode());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
