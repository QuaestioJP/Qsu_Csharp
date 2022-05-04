using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;
using Qsu.AST.Expressions;

namespace Qsu.AST.Statements
{
    public class ReturnStatement : IStatement
    {
        public Token Token;
        /// <summary>
        /// 値
        /// </summary>
        public Identifier Value;
    }
}
