﻿using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;
using Qsu.AST.ToJSON;

namespace Qsu.AST.Expressions
{
    public class BooleanLiteral : IExpression
    {
        public Token Token;
        public bool Value;

        public string ToJSON()
        {
            return JsonUtil.ToJSON("Boolean", new (string, string)[]
            {
                ("Value",$"\"{Value.ToString()}\"")
            });
        }
    }
}
