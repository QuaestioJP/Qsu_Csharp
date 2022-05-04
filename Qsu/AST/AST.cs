using System.Text;
using System;
using System.Collections.Generic;
using Qsu.AST;
using Qsu.AST.Expressions;
using Qsu.AST.Statements;

namespace Qsu.AST
{
    public class Root : INode
    {
        public List<IStatement> Statements;

        public string ToJSON()
        {
            var builder = new StringBuilder();

            builder.Append("{ \"root\":[");

            for (int i = 0; i < Statements.Count; i++)
            {
                builder.Append(Statements[i].ToJSON());

                if (i != Statements.Count - 1)
                {
                    builder.Append(",");
                }
            }
            builder.Append("] }");

            return builder.ToString();
        }
    }
}
