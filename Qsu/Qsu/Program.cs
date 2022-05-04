using System;
using Qsu.AST;
using Qsu.Lexing;
using Qsu.Parsing;

namespace Qsu
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.Write(">> ");
                string input = Console.ReadLine();

                Lexer lexer = new Lexer(input);
                Parser parser = new Parser(lexer);

                Console.WriteLine(parser.ParseRoot().ToJSON());
            }
        }
    }
}
