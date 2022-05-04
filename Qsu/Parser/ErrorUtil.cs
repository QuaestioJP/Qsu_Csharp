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
        public List<string> Errors = new List<string>();

        /// <summary>
        /// 来なくてはならないトークンタイプが来なかった場合のエラー
        /// </summary>
        /// <param name="expected">来なくてはならないトークンタイプ</param>
        /// <param name="actual">実際のトークンタイプ</param>
        private void AddNextTokenError(TokenType expected , TokenType actual)
        {
            Errors.Add($"{actual.ToString()}ではなく、{expected.ToString()}が来なければいけません。");
        }
    }
}
