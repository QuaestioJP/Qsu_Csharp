using System;
using System.IO;
using System.Text;
using Qsu.AST;
using Qsu.Lexing;
using Qsu.Parsing;

namespace Qsu
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                StreamReader sr = new StreamReader(args[0], Encoding.UTF8);
                string str = sr.ReadToEnd();
                sr.Close();

                Lexer lexer = new Lexer(str);
                Parser parser = new Parser(lexer);
                Root root = parser.ParseRoot();
                Console.WriteLine(root.ToJSON());
            }
            else
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

                    Console.WriteLine("JSON:    " + root.ToJSON());
                    Console.WriteLine("Csharp:    " + root.ToCsharp());
                }
            }
        }
    }
}