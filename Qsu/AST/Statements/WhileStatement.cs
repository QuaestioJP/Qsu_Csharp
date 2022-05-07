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
    }
}
