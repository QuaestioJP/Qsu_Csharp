﻿using System;
using System.Collections.Generic;
using Qsu.Lexing;
using Qsu.AST.Statements;
using Qsu.AST.Expressions;
using Qsu.AST;
using System.Linq;


namespace Qsu.Parsing
{
    using PrefixParseFn = Func<IExpression>;                //前置
    using InfixParseFn = Func<IExpression, IExpression>;    //中置

    public partial class Parser
    {
        public Dictionary<TokenType, PrefixParseFn> PrefixParseFns;
        public Dictionary<TokenType, InfixParseFn> InfixParseFns;

        /// <summary>
        /// PrefixParseFnsの初期化
        /// </summary>
        private void RegisterPrefixParseFns()
        {
            PrefixParseFns = new Dictionary<TokenType, PrefixParseFn>();
            PrefixParseFns.Add(TokenType.IDENT, ParseIdentifier);
        }

        /// <summary>
        /// 式を構文解析します
        /// </summary>
        /// <returns></returns>
        public IExpression ParseExpression(Precedence precedence)
        {
            PrefixParseFns.TryGetValue(CurrentToken.Type, out var prefix);
            if (prefix == null) return null;

            var leftExpression = prefix();
            return leftExpression;
        }

        public IExpression ParseIdentifier()
        {
            return new Identifier(CurrentToken, CurrentToken.Literal);
        }
    }

    public enum Precedence
    {
        LOWEST = 1,
        EQUALS,
        LESSGREATER,
        SUM,
        PRODUCT,
        PREFIX,
        CALL,
    }
}