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
                case TokenType.IF:
                    return ParseIfStatement();
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

        public BlockStatement ParseBlockStatement()
        {
            var block = new BlockStatement()
            {
                Token = CurrentToken,
                Statements = new List<IStatement>()
            };

            //"{"をぶっ飛ばす
            ReadToken();

            while (this.CurrentToken.Type != TokenType.RBRACE
                && this.CurrentToken.Type != TokenType.EOF)
            {
                // ブロックの中身を解析する
                var statement = this.ParseStatement();
                if (statement != null)
                {
                    block.Statements.Add(statement);
                }
                this.ReadToken();
            }

            return block;
        }

        public IfStatement ParseIfStatement()
        {
            var expression = new IfStatement()
            {
                Token = this.CurrentToken // IF
            };

            // if の後は括弧 ( でなければならない
            if (!this.ExpectPeek(TokenType.LPAREN)) return null;

            // 括弧 ( を読み飛ばす
            this.ReadToken();

            // ifの条件式を解析する
            expression.Condition = this.ParseExpression(Precedence.LOWEST);

            // 閉じ括弧 ) 中括弧が続く 
            if (!this.ExpectPeek(TokenType.RPAREN)) return null;
            if (!this.ExpectPeek(TokenType.LBRACE)) return null;

            // この時点で { が現在のトークン
            // ブロック文の解析関数を呼ぶ
            expression.Consequence = this.ParseBlockStatement();

            // else句があれば解析する
            if (this.NextToken.Type == TokenType.ELSE)
            {
                // else に読み進める
                this.ReadToken();
                // else の後に { が続かなければならない
                if (!this.ExpectPeek(TokenType.LBRACE)) return null;

                // この時点で { が現在のトークン
                // ブロック文の解析関数を呼ぶ
                expression.Alternative = this.ParseBlockStatement();
            }

            return expression;
        }
    }
}
