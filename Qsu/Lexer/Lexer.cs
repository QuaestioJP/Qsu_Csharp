using System;
using System.Collections.Generic;

namespace Qsu.Lexing
{
    public class Lexer
    {
        public string Input { get; private set; }
        public char CurrentChar { get; private set; }
        public char NextChar { get; private set; }
        public int Position { get; private set; } = 0;

        public Lexer(string input)
        {
            Input = input;
            ReadChar();
        }

        public Token NextToken()
        {
            //空白とかを読み飛ばす
            SkipWhiteSpace();

            Token token = null;
            switch (CurrentChar)
            {
                case '=':
                    if (NextChar == '=')
                    {
                        token = new Token(TokenType.EQ, "==");
                        ReadChar();
                    }
                    else
                    {
                        token = new Token(TokenType.ASSIGN, CurrentChar.ToString());
                    }
                    break;
                case '+':
                    token = new Token(TokenType.PLUS, CurrentChar.ToString());
                    break;
                case '-':
                    token = new Token(TokenType.MINUS, CurrentChar.ToString());
                    break;
                case '*':
                    token = new Token(TokenType.ASTERISK, CurrentChar.ToString());
                    break;
                case '/':
                    token = new Token(TokenType.SLASH, CurrentChar.ToString());
                    break;
                case '!':
                    if (NextChar == '=')
                    {
                        token = new Token(TokenType.NOT_EQ, "!=");
                        ReadChar();
                    }
                    else
                    {
                        token = new Token(TokenType.BANG, CurrentChar.ToString());
                    }
                    break;
                case '>':
                    token = new Token(TokenType.GT, CurrentChar.ToString());
                    break;
                case '<':
                    token = new Token(TokenType.LT, CurrentChar.ToString());
                    break;
                case ',':
                    token = new Token(TokenType.COMMA, CurrentChar.ToString());
                    break;
                case ';':
                    token = new Token(TokenType.SEMICOLON, CurrentChar.ToString());
                    break;
                case '(':
                    token = new Token(TokenType.LPAREN, CurrentChar.ToString());
                    break;
                case ')':
                    token = new Token(TokenType.RPAREN, CurrentChar.ToString());
                    break;
                case '{':
                    token = new Token(TokenType.LBRACE, CurrentChar.ToString());
                    break;
                case '}':
                    token = new Token(TokenType.RBRACE, CurrentChar.ToString());
                    break;
                case (char)0:
                    token = new Token(TokenType.EOF, "");
                    break;
                default://識別子候補たち

                    if (IsLetter(CurrentChar)) //予約語
                    {
                        string identifier = ReadIdentifier();
                        TokenType type = Token.LookupIdentifier(identifier);
                        token = new Token(type, identifier);
                    }
                    else if (IsDigit(CurrentChar)) //数字リテラル
                    {
                        string number = ReadNumber();
                        token = new Token(TokenType.INT, number);
                    }
                    else
                    {
                        token = new Token(TokenType.ILLEGAL, CurrentChar.ToString());
                    }

                    break;
            }

            ReadChar();
            return token;
        }

        private void SkipWhiteSpace()
        {
            while (CurrentChar == ' ' || CurrentChar == '\t' || CurrentChar == '\r' || CurrentChar == '\n')
            {
                ReadChar();
            }
        }

        private string ReadNumber()
        {
            string number = CurrentChar.ToString();

            while (IsDigit(NextChar))
            {
                number += NextChar;

                ReadChar();
            }

            return number;
        }
        private bool IsDigit(char c)
        {
            return '0' <= c && c <= '9';
        }

        private string ReadIdentifier()
        {
            string identifier = CurrentChar.ToString();

            while (IsLetter(NextChar))
            {
                identifier += NextChar;
                ReadChar();
            }

            return identifier;
        }

        private bool IsLetter(char c)
        {
            return ('a' <= c && c <= 'z') || ('A' <= c && c <= 'Z') || c == '_';
        }

        private void ReadChar()
        {
            //CurrentCharをセット
            if (Position >= Input.Length)
            {
                CurrentChar = (char)0;
            }
            else
            {
                CurrentChar = Input[Position];
            }

            //NextCharをセット
            if (Position + 1 >= Input.Length)
            {
                NextChar = (char)0;
            }
            else
            {
                NextChar = Input[Position + 1];
            }

            //Positionを一つ進める
            Position++;
        }
    }

    public enum TokenType
    {
        // 不正なトークン, 終端
        ILLEGAL,
        EOF,
        //識別子
        IDENT,
        //リテラル
        INT,
        //演算子
        ASSIGN,
        PLUS,
        MINUS,
        ASTERISK,
        SLASH,
        BANG,
        LT,
        GT,
        EQ,
        NOT_EQ,
        //デリミタ
        COMMA,
        SEMICOLON,
        // 括弧(){}
        LPAREN,
        RPAREN,
        LBRACE,
        RBRACE,
        // キーワード
        LET,
        IF,
        ELSE,
        RETURN,
        TRUE,
        FALSE,
        WHILE
    }
    public class Token
    {
        public TokenType Type;
        public string Literal;

        public static Dictionary<string, TokenType> Keywords = new Dictionary<string, TokenType>()
        {
            {"let" , TokenType.LET},
            {"if",TokenType.IF },
            {"else", TokenType.ELSE },
            {"return" , TokenType.RETURN},
            {"true",TokenType.TRUE },
            {"false" ,TokenType.FALSE},
            {"while" ,TokenType.WHILE},
        };

        public Token(TokenType type,string literal)
        {
            Type = type;
            Literal = literal;
        }

        public static TokenType LookupIdentifier(string identifier)
        {
            if (Token.Keywords.ContainsKey(identifier))
            {
                return Keywords[identifier];
            }

            return TokenType.IDENT;
        }
    }
}
