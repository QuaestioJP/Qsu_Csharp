using System.Collections.Generic;
using System;
using Qsu.Lexing;
using Qsu.AST;
using Qsu.AST.Expressions;
using Qsu.AST.Statements;

namespace Qsu.Parsing
{
    public class Parser
    {
        public Token CurrentToken;
        public Token NextToken;
        public Lexer Lexer { get; }
        public List<string> Errors = new List<string>();

        public Parser(Lexer lexer)
        {
            Lexer = lexer;

            //トークンを二つセット
            CurrentToken = Lexer.NextToken();
            NextToken = Lexer.NextToken();
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
                    return null;
            }
        }

        public ReturnStatement ParseReturnStatement()
        {
            var statement = new ReturnStatement();
            statement.Token = CurrentToken;
            ReadToken();

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
    }
}
