﻿using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;

namespace Qsu.AST.Expressions
{
    /// <summary>
    /// 識別子
    /// </summary>
    public class Identifier : IExpression
    {
        public Token Token;
        /// <summary>
        /// 変数名
        /// </summary>
        public string Value;

        public Identifier(Token token, string value)
        {
            Token = token;
            Value = value;
        }
    }
}