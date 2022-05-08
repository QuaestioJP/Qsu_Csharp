using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Qsu.Lexing;
using Qsu.AST.Expressions;
using Qsu.AST.ToJSON;

namespace Qsu.AST.Statements
{
    public class IfStatement : IStatement
    {
        public Token Token;
        public IExpression Condition;
        public BlockStatement Consequence;
        public BlockStatement Alternative;


        public string ToJSON()
        {
            if (Alternative == null)
            {
                //ifのみの場合
                return JsonUtil.ToJSON("if", new (string, string)[]
                {
                    ("Consequence",Consequence.ToJSON()),
                });
            }
            else
            {
                //if-elseの場合
                return JsonUtil.ToJSON("if-else", new (string, string)[]
                {
                    ("Consequence",Consequence.ToJSON()),
                    ("Alternative",Alternative.ToJSON()),
                });
            }
        }
        public string ToCsharp()
        {
            var builder = new StringBuilder();

            builder.Append("if");
            builder.Append("(");
            builder.Append(Condition.ToCsharp());
            builder.Append(")");
            builder.Append("{");
            builder.Append(Consequence.ToCsharp());
            builder.Append("}");
            if (Alternative != null)
            {
                builder.Append("else");
                builder.Append("{");
                builder.Append(Alternative.ToCsharp());
                builder.Append("}");
            }

            return builder.ToString();
        }
    }
}
