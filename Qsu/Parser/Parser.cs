using System.Collections.Generic;
using System;
using Qsu.Lexing;
using Qsu.AST;
using Qsu.AST.Expressions;
using Qsu.AST.Statements;

namespace Qsu.Parsing
{
    using PrefixParseFn = Func<IExpression>;
    using InfixParseFn = Func<IExpression, IExpression>;

    public class Parser
    {
        public Token CurrentToken;
        public Token NextToken;
        public Lexer Lexer { get; }
        public List<string> Errors = new List<string>();

        public Dictionary<TokenType, PrefixParseFn> PrefixParseFns;
        public Dictionary<TokenType, InfixParseFn> InfixParseFns;


        public Parser(Lexer lexer)
        {
            Lexer = lexer;

            //トークンを二つセット
            CurrentToken = Lexer.NextToken();
            NextToken = Lexer.NextToken();

            //トークンの種類と解析関数を関連付ける
            RegisterPrefixParseFns();
        }

        private void RegisterPrefixParseFns()
        {
            PrefixParseFns = new Dictionary<TokenType, PrefixParseFn>();
            PrefixParseFns.Add(TokenType.IDENT, ParseIdentifier);
            PrefixParseFns.Add(TokenType.INT, ParseIntegerLiteral);
            PrefixParseFns.Add(TokenType.BANG, ParsePrefixExpression);
            PrefixParseFns.Add(TokenType.MINUS, ParsePrefixExpression);
        }

        public IExpression ParsePrefixExpression()
        {
            PrefixExpression expression = new PrefixExpression()
            {
                Token = CurrentToken,
                Operator = CurrentToken.Literal
            };

            ReadToken();

            expression.Right = ParseExpression(Precedence.PREFIX);
            return expression;
        }

        public IExpression ParseIntegerLiteral()
        {
            //リテラルを整数値に変換
            if (int.TryParse(CurrentToken.Literal, out int result))
            {
                return new IntegerLiteral()
                {
                    Token = CurrentToken,
                    Value = result,
                };
            }

            //型変換失敗時
            var message = $"{this.CurrentToken.Literal} を integer に変換できません。";
            Errors.Add(message);
            return null;
        }

        public IExpression ParseIdentifier()
        {
            return new Identifier(CurrentToken, CurrentToken.Literal);
        }

        private void ReadToken()
        {
            CurrentToken = NextToken;
            NextToken = Lexer.NextToken();
        }

        public Root ParseRoot()
        {
            return null;
        }

        public Root ParseProgram()
        {
            Root root = new Root();
            root.Statements = new List<IStatement>();

            while (CurrentToken.Type != TokenType.EOF)
            {
                IStatement statement = ParseStatement();
                if (statement != null)
                {
                    root.Statements.Add(statement);
                }
                ReadToken();
            }

            return root;
        }

        public IStatement ParseStatement()
        {
            switch (CurrentToken.Type)
            {
                case TokenType.LET:
                    return ParseLetStatement();
                case TokenType.RETURN:
                    return ParseReturnStatement();
                default:
                    return ParseExpressionStatement();
            }
        }

        public ReturnStatement ParseReturnStatement()
        {
            var statement = new ReturnStatement();
            statement.Token = CurrentToken;
            ReadToken();

            // TODO: 後で実装いたします。
            while (CurrentToken.Type != TokenType.SEMICOLON)
            {
                ReadToken();
            }

            return statement;
        }

        public LetStatement ParseLetStatement()
        {
            LetStatement statement = new LetStatement();
            statement.Token = CurrentToken;

            if (!ExpectPeek(TokenType.IDENT)) return null;

            //識別子
            statement.Name = new Identifier(CurrentToken, CurrentToken.Literal);

            //等号
            if (!ExpectPeek(TokenType.ASSIGN)) return null;

            // TODO: 後で実装いたします。
            //式
            while (CurrentToken.Type != TokenType.SEMICOLON)
            {
                ReadToken();
            }

            return statement;

        }

        private bool ExpectPeek(TokenType type)
        {
            if (NextToken.Type == type)
            {
                ReadToken();
                return true;
            }

            AddNextTokenError(type, NextToken.Type);
            return false;
        }

        private void AddNextTokenError(TokenType expected,TokenType actual)
        {
            Errors.Add($"{actual.ToString()} ではなく {expected.ToString()} が来なければなりません。");
        }

        public IExpression ParseExpression(Precedence precedence)
        {
            PrefixParseFns.TryGetValue(CurrentToken.Type, out var prefix);
            if (prefix == null) 
            {
                AddPrefixParseFnError(CurrentToken.Type);
                return null;
            }

            IExpression leftExpression = prefix();
            return leftExpression;
        }

        private void AddPrefixParseFnError(TokenType tokenType)
        {
            var message = $"{tokenType.ToString()} に関連付けられた Prefix Parse Function が存在しません。";
            Errors.Add(message);
        }

        public ExpressionStatement ParseExpressionStatement()
        {
            ExpressionStatement statement = new ExpressionStatement();
            statement.Token = CurrentToken;

            statement.Expression = ParseExpression(Precedence.LOWEST);

            //セミコロンをぶっ飛ばす
            if (NextToken.Type == TokenType.SEMICOLON) ReadToken();

            return statement;
        }

        public enum Precedence
        {
            LOWEST = 1,
            EQUALS,         // ==
            LESSGREATER,    // >, <
            SUM,            // +
            PRODUCT,        // *
            PREFIX,         // -x, !x
            CALL            // myFunction(x)
        }
    }
}
