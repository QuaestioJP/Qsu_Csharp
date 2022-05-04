using System;
using Qsu.Lexing;

namespace Qsu.Parsing
{
    public class Parser
    {
        public Token CurrentToken;
        public Token NextToken;
        public Lexer Lexer;
        
        public Parser(Lexer lexer)
        {
            Lexer = lexer;

            CurrentToken = Lexer.NextToken();
            NextToken = Lexer.NextToken();
        }

        public void ReadToken()
        {
            CurrentToken = NextToken;
            NextToken = Lexer.NextToken();
        }
    }
}
