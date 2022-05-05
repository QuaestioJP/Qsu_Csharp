using System;
using System.Collections.Generic;
using Qsu.Lexing;
using Qsu.AST.Statements;
using Qsu.AST.Expressions;
using Qsu.AST;


namespace Qsu.Parsing
{
    public partial class Parser
    {
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
                    Errors.Add("未定義の構文が使用されました。");
                    return null;
            }
        }

        public LetStatement ParseLetStatement()
        {
            LetStatement statement = new LetStatement();

            statement.Token = CurrentToken;


            //識別子
            if (!ExpectPeek(TokenType.IDENT)) return null;

            statement.Name = new Identifier(CurrentToken, CurrentToken.Literal);

            //イコール
            if (!ExpectPeek(TokenType.ASSIGN)) return null;

            ReadToken();

            //式
            statement.Value = ParseExpression(Precedence.LOWEST);

            //セミコロン
            if (NextToken.Type != TokenType.SEMICOLON) return null;

            ReadToken();

            return statement;
        }

        public ReturnStatement ParseReturnStatement()
        {
            ReturnStatement statement = new ReturnStatement();
            statement.Token = CurrentToken;

            ReadToken();

            //式
            statement.Value = ParseExpression(Precedence.LOWEST);

            //セミコロン
            if (NextToken.Type != TokenType.SEMICOLON) return null;

            ReadToken();

            return statement;

        }
    }
}
