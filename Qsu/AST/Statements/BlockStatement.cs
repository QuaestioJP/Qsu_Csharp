using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Qsu.Lexing;
using Qsu.AST.Expressions;
using Qsu.AST.ToJSON;

namespace Qsu.AST.Statements
{
    public class BlockStatement : IStatement
    {
        public Token Token;
        public List<IStatement> Statements;

        public string ToJSON()
        {
            var param = new List<string>();

            foreach (var item in Statements)
            {
                param.Add(item.ToJSON());
            }

            return JsonUtil.ToJSON("Block", new (string, string)[]
            {
                ("statements",$"[{string.Join(",",param)}]")
            });
        }

        public string ToCsharp()
        {
            var builder = new StringBuilder();

            builder.Append("{");

            foreach (var item in Statements)
            {
                builder.Append(item.ToCsharp());
            }

            builder.Append("}");

            return builder.ToString();
        }
    }
}
