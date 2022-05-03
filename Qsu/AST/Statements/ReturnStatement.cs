using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;

namespace Qsu.AST.Statements
{
    public class ReturnStatement : IStatement
    {
        public Token Token;
        public IExpression ReturnValue;

        public string TokenLiteral() => Token.Literal;
    }
}
