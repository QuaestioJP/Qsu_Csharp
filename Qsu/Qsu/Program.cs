using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qsu.Lexing;

namespace Qsu
{
    public class Repl
    {
        const string PROMPT = ">> ";

        static void Main(string[] args)
        {
            Repl repl = new Repl();
            repl.Start();
        }

        public void Start()
        {
            while (true)
            {
                Console.Write(PROMPT);

                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) return;

                Lexer lexer = new Lexer(input);
                for (var token = lexer.NextToken();token.Type != TokenType.EOF; token = lexer.NextToken())
                {
                    Console.WriteLine($"{{ Type: {token.Type.ToString()}, Literal: {token.Literal} }}");
                }
            }
        }
    }
}