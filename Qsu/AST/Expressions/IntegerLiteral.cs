using System;
using System.Collections.Generic;
using System.Text;
using Qsu.AST;
using Qsu.AST.ToJSON;
using Qsu.Lexing;


namespace Qsu.AST.Expressions
{
    public class IntegerLiteral : IExpression
    {
        public Token Token;
        public int Value;

        public string ToJSON()
        {
            return JsonUtil.ToJSON("Integer", new (string, string)[]
            {
                ("Value",$"\"{Value}\"")
            });
        }
        public string ToCsharp()
        {
            var builder = new StringBuilder();

            builder.Append(Value);

            return builder.ToString();
        }
    }
}
