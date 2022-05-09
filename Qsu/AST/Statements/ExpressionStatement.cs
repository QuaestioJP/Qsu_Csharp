using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Qsu.Lexing;
using Qsu.AST.Expressions;
using Qsu.AST.ToJSON;

namespace Qsu.AST.Statements
{
    public class ExpressionStatement : IStatement
    {
        public Token Token;
        public IExpression Expression;

        public string ToCsharp()
        {
            return $"QsuUtility_ExpressionStatement({Expression.ToCsharp()});";
        }

        public string ToJavaScript()
        {
            return $"QsuUtility_ExpressionStatement({Expression.ToJavaScript()});";
        }

        public string ToJSON()
        {
            return JsonUtil.ToJSON("expressionStatement", new (string, string)[]
            {
                ("Expression",Expression.ToJSON())
            });
        }

        public string ToPython()
        {
            return $"QsuUtility_ExpressionStatement({Expression.ToPython()})";
        }
    }
}