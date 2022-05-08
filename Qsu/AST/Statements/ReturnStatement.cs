using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;
using Qsu.AST.Expressions;
using Qsu.AST.ToJSON;

namespace Qsu.AST.Statements
{
    public class ReturnStatement : IStatement
    {
        public Token Token;
        /// <summary>
        /// 値
        /// </summary>
        public IExpression Value;


        public string ToJSON()
        {

            return JsonUtil.ToJSON("return",new (string, string)[] { 
                ("Value",Value.ToJSON())
                //$"\"a\""
                //Value.ToJSON
            });
        }

        public string ToCsharp()
        {
            var builder = new StringBuilder();

            builder.Append("return ");

            builder.Append(Value.ToCsharp());

            builder.Append(";");

            return builder.ToString();
        }
        public string ToPython()
        {
            var builder = new StringBuilder();

            builder.Append("return ");
            builder.Append(Value.ToPython());

            return builder.ToString();
        }
    }
}
