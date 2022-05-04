using System;
using System.Collections.Generic;
using System.Text;
using Qsu.Lexing;
using Qsu.AST.Expressions;

namespace Qsu.AST.Statements
{
    public class LetStatement : IStatement
    {
        public Token Token;
        /// <summary>
        /// 変数名
        /// </summary>
        public Identifier Name;
        /// <summary>
        /// 値
        /// </summary>
        public IExpression Value;
    }
}
