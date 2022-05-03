using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;

namespace Qsu.AST.Expressions
{
    public class Identifier : IExpression
    {
        public Token Token;
        public string Value;

        public Identifier(Token token,string value)
        {
            Token = token;
            Value = value;
        }

        public string TokenLiteral() => Token.Literal;
    }
}
