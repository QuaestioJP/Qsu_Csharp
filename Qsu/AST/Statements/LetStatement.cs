using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;
using Qsu.AST.Expressions;
using Qsu.AST.ToJSON;

namespace Qsu.AST.Statements
{
    public class LetStatement : IStatement
    {
        public Token Token;
        /// <summary>
        /// 変数名
        /// </summary>
        public Identifier Name;
        /// <summary>
        /// 値
        /// </summary>
        public IExpression Value;

        public string ToJSON()
        {
            return JsonUtil.ToJSON("let", new (string,string)[] {
                ("Name" , Name.ToJSON()), 
                ("Value", Value.ToJSON())
                //$"\"a\""
                //Value.ToJSON
            });
        }

        public string ToCsharp()
        {
            var builder = new StringBuilder();

            builder.Append("var ");

            builder.Append(Name.ToCsharp());

            builder.Append(" = ");

            builder.Append(Value.ToCsharp());

            builder.Append(";");

            return builder.ToString();
        }

        public string ToPython()
        {
            var builder = new StringBuilder();

            builder.Append(Name.ToPython());
            builder.Append("=");
            builder.Append(Value.ToPython());

            return builder.ToString();
        }
        public string ToJavaScript()
        {
            var builder = new StringBuilder();

            builder.Append($"let {Name.ToJavaScript()}={Value.ToJavaScript()};");

            return builder.ToString();
        }

        public string ToJava()
        {
            var builder = new StringBuilder();

            builder.Append("var ");

            builder.Append(Name.ToJava());

            builder.Append(" = ");

            builder.Append(Value.ToJava());

            builder.Append(";");

            return builder.ToString();
        }

        public string ToClang()
        {
            var builder = new StringBuilder();

            //仮にintをつけておく (型の判別方法が分かったら直す)
            //本当は値の型によってcharとかfloatとかしたい
            //lexerに他の型が追加されたら直すとします

            builder.Append("int ");

            builder.Append(Name.ToClang());

            builder.Append(" = ");

            builder.Append(Value.ToClang());

            builder.Append(";");

            return builder.ToString();
        }
    }
}
