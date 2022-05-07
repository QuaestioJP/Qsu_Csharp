using System;
using Qsu.AST;
using Qsu.Lexing;
using Qsu.Parsing;
using Qsu.Evaluating;

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
                Root root = parser.ParseRoot();

                foreach (var item in parser.Errors)
                {
                    Console.WriteLine(item);
                }

                var evaluator = new Evaluator();
                var evaluated = evaluator.Eval(root);

                if (evaluated != null)
                {
                    Console.WriteLine(evaluated.Inspect());
                }

                Console.WriteLine(root.ToJSON());
            }
        }
    }
}
