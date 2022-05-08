using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Qsu.Lexing;
using Qsu.AST.Expressions;
using Qsu.AST.ToJSON;

namespace Qsu.AST.Statements
{
    public class WhileStatement : IStatement
    {
        public Token Token;
        public IExpression Condition;
        public BlockStatement Block;


        public string ToJSON()
        {
            return JsonUtil.ToJSON("While", new (string, string)[]
            {
                ("Condition",Condition.ToJSON()),
                ("Block",Block.ToJSON())
            });
        }

        public string ToCsharp()
        {
            var builder = new StringBuilder();

            builder.Append("while");
            builder.Append("(");
            builder.Append(Condition.ToCsharp());
            builder.Append(")"); 
            builder.Append("{");
            builder.Append(Block.ToCsharp());
            builder.Append("}");

            return builder.ToString();
        }
        public string ToPython()
        {
            var builder = new StringBuilder();

            builder.Append("while ");
            builder.Append(Condition.ToPython() + ":\n");
            builder.Append(Block.ToPython());

            return builder.ToString();
        }
    }
}
