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
    }
}
