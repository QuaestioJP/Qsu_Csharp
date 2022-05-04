using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qsu.Lexing;
using Qsu.Parsing;

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
                Parser parser = new Parser(lexer);
                var root = parser.ParseProgram();

                if (string.IsNullOrEmpty(input)) return;

                Lexer lexer2 = new Lexer(input);
                for (var token = lexer2.NextToken(); token.Type != TokenType.EOF; token = lexer2.NextToken())
                {
                    Console.WriteLine($"{{ Type: {token.Type.ToString()}, Literal: {token.Literal} }}");
                }

                if (parser.Errors.Count > 0)
                {
                    foreach (var error in parser.Errors)
                    {
                        Console.WriteLine($"\t{error}");
                    }
                    continue;
                }

                Console.WriteLine(root.ToCode());
            }
        }
    }
}