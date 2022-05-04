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
        public LetStatement ParseLetStatement()
        {
            LetStatement statement = new LetStatement();

            statement.Token = CurrentToken;


            //識別子
            if (!ExpectPeek(TokenType.IDENT))
            {
                return null;
            }

            statement.Name = new Identifier(CurrentToken, CurrentToken.Literal);

            //イコール
            if (!ExpectPeek(TokenType.ASSIGN)) return null;

            //式
            // TODO : 後で実装しておく
            while (CurrentToken.Type != TokenType.SEMICOLON)
            {
                //読み飛ばす
                ReadToken();
            }

            //セミコロン

            return statement;
        }

        public ReturnStatement ParseReturnStatement()
        {
            ReturnStatement statement = new ReturnStatement();
            statement.Token = CurrentToken;

            //式
            // TODO : 後で実装しておく
            while (CurrentToken.Type != TokenType.SEMICOLON)
            {
                //読み飛ばす
                ReadToken();
            }

            //セミコロン

            return statement;

        }
    }
}
