using System;
using System.Collections.Generic;
using Qsu.Lexing;
using Qsu.AST.Expressions;
using Qsu.AST;

namespace Qsu.Parsing
{
    public partial class Parser
    {
        public Token CurrentToken;
        public Token NextToken;
        public Lexer Lexer;

        
        public Parser(Lexer lexer)
        {
            Lexer = lexer;

            CurrentToken = Lexer.NextToken();
            NextToken = Lexer.NextToken();
        }

        /// <summary>
        /// トークンを次のトークンに進めます
        /// </summary>
        public void ReadToken()
        {
            CurrentToken = NextToken;
            NextToken = Lexer.NextToken();
        }

        /// <summary>
        /// プログラム全体をパースします
        /// </summary>
        /// <returns></returns>
        public Root ParseRoot()
        {
            Root root = new Root();
            root.Statements = new List<IStatement>();

            //最後の行まで繰り返す
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

        /// <summary>
        /// 文を構文解析します
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 次のトークンが期待するものであれば、そのトークンを読み飛ばす
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool ExpectPeek(TokenType type)
        {
            if (this.NextToken.Type == type)
            {
                this.ReadToken();
                return true;
            }

            AddNextTokenError(type, NextToken.Type);
            return false;
        }
    }
}
