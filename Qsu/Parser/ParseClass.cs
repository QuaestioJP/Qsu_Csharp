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
        public List<TokenType> ClassTokenType;

        private void RegisterClassTokenType()
        {
            ClassTokenType = new List<TokenType>();
            ClassTokenType.Add(TokenType.IDENT);
        }

        private bool CheckClassTokenType(TokenType tt)
        {
            foreach (var item in ClassTokenType)
            {
                if (item == tt)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
