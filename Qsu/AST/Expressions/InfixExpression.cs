using System;
using System.Collections.Generic;
using System.Text;
using Qsu.AST;
using Qsu.AST.ToJSON;
using Qsu.Lexing;

namespace Qsu.AST.Expressions
{
    public class InfixExpression : IExpression
    {
        public Token Token;

        public IExpression Left;
        public string Operator;
        public IExpression Right;

        public string ToJSON()
        {
            return JsonUtil.ToJSON("Infix", new (string, string)[]
            {
                ("Operator",$"\"{Operator}\""),
                ("Left",Left.ToJSON()),
                ("Right",Right.ToJSON())
            });
        }
    }
}
