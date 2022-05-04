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
        public Identifier Value;


        public string ToJSON()
        {

            return JsonUtil.StatementToJSON("return",new (string, string)[] { 
                ("Value",Value.ToJSON())
                //$"\"a\""
                //Value.ToJSON
            });
        }
    }
}
