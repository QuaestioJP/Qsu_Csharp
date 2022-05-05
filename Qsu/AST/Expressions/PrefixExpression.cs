﻿using System;
using System.Collections.Generic;
using System.Text;
using Qsu.AST;
using Qsu.AST.ToJSON;
using Qsu.Lexing;

namespace Qsu.AST.Expressions
{
    public class PrefixExpression : IExpression
    {
        public Token Token;
        public string Operator;
        public IExpression Right;

        public string ToJSON()
        {
            return JsonUtil.ToJSON("Prefix", new (string, string)[]
            {
                ("Operator",$"\"{Operator}\""),
                ("Right",Right.ToJSON())
            });
        }
    }
}