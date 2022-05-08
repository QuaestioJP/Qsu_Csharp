using System;
using System.Collections.Generic;
using System.Text;
using Qsu.AST;
using Qsu.AST.ToJSON;
using Qsu.Lexing;

namespace Qsu.AST.Expressions
{
    public class PrefixExpression : IExpression
    {
        public Token Token;
        public string Operator;
        public IExpression Right;

        public string ToJSON()
        {
            return JsonUtil.ToJSON("Prefix", new (string, string)[]
            {
                ("Operator",$"\"{Operator}\""),
                ("Right",Right.ToJSON())
            });
        }

        public string ToCsharp()
        {
            var builder = new StringBuilder();

            builder.Append(Operator);

            builder.Append(Right.ToCsharp());

            return builder.ToString();
        }

        public string ToPython()
        {
            var builder = new StringBuilder();

            builder.Append(Operator);

            builder.Append(Right.ToPython());

            return builder.ToString();
        }
        public string ToJavaScript()
        {
            var builder = new StringBuilder();

            builder.Append(Operator);
            builder.Append(Right.ToJavaScript());

            return builder.ToString();
        }
    }
}
