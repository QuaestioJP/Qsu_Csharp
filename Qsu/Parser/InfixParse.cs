using System;
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
        public Dictionary<TokenType, Precedence> Precedences = new Dictionary<TokenType, Precedence>()
        {
                { TokenType.EQ, Precedence.EQUALS },
                { TokenType.NOT_EQ, Precedence.EQUALS },
                { TokenType.LT, Precedence.LESSGREATER },
                { TokenType.GT, Precedence.LESSGREATER },
                { TokenType.PLUS, Precedence.SUM },
                { TokenType.MINUS, Precedence.SUM },
                { TokenType.SLASH, Precedence.PRODUCT },
                { TokenType.ASTERISK, Precedence.PRODUCT },
        };

        public Precedence CurrentPrecedence
        {
            get
            {
                if (Precedences.TryGetValue(CurrentToken.Type, out var p))
                {
                    return p;
                }
                return Precedence.LOWEST;
            }
        }
        public Precedence NextPrecedence
        {
            get
            {
                if (Precedences.TryGetValue(NextToken.Type, out var p))
                {
                    return p;
                }
                return Precedence.LOWEST;
            }
        }


        private void RegisterInfixParseFns()
        {
            InfixParseFns = new Dictionary<TokenType, InfixParseFn>();
            InfixParseFns.Add(TokenType.PLUS, ParseInfixExpression);
            InfixParseFns.Add(TokenType.MINUS, ParseInfixExpression);
            InfixParseFns.Add(TokenType.SLASH, ParseInfixExpression);
            InfixParseFns.Add(TokenType.ASTERISK, ParseInfixExpression);
            InfixParseFns.Add(TokenType.EQ, ParseInfixExpression);
            InfixParseFns.Add(TokenType.NOT_EQ, ParseInfixExpression);
            InfixParseFns.Add(TokenType.LT, ParseInfixExpression);
            InfixParseFns.Add(TokenType.GT, ParseInfixExpression);
        }

        public IExpression ParseInfixExpression(IExpression left)
        {
            var expression = new InfixExpression()
            {
                Token = this.CurrentToken,
                Operator = this.CurrentToken.Literal,
                Left = left,
            };

            var precedence = this.CurrentPrecedence;
            this.ReadToken();
            expression.Right = this.ParseExpression(precedence);

            return expression;
        }
    }
}
