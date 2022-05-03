using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;

namespace Qsu.AST.Expressions
{
    public class PrefixExpression : IExpression
    {
        public Token Token;
        public string Operator;
        public IExpression Right;

        public string ToCode() => $"({this.Operator}{this.Right.ToCode()})";
        public string TokenLiteral() => Token.Literal;
    }
}
