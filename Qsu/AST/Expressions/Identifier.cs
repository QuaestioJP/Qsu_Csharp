using System;
using System.Collections.Generic;
using System.Text;
using Qsu.AST.ToJSON;
using Qsu.Lexing;

namespace Qsu.AST.Expressions
{
    /// <summary>
    /// 識別子
    /// </summary>
    public class Identifier : IExpression
    {
        public Token Token;
        /// <summary>
        /// 変数名
        /// </summary>
        public string Value;

        public Identifier(Token token, string value)
        {
            Token = token;
            Value = value;
        }

        public string ToJSON()
        {
            return JsonUtil.ToJSON("Ident", new (string, string)[]
            {
                ("Value",$"\"{Value}\"")
            });
        }

        public string ToCsharp()
        {
            var builder = new StringBuilder();

            builder.Append("Qsu_" + Value);

            return builder.ToString();
        }

        public string ToPython()
        {
            var builder = new StringBuilder();

            builder.Append("Qsu_" + Value);
            
            return builder.ToString();
        }
        public string ToJavaScript()
        {
            var builder = new StringBuilder();

            builder.Append("Qsu_" + Value);

            return builder.ToString();
        }
        public string ToJava()
        {
            var builder = new StringBuilder();

            builder.Append("Qsu_" + Value);

            return builder.ToString();
        }
        public string ToClang()
        {
            var builder = new StringBuilder();

            builder.Append("Qsu_" + Value);

            return builder.ToString();
        }
    }
}
