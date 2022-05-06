using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Qsu.Parsing;
using Qsu.Lexing;
using Qsu.AST;

namespace QsuTest
{
    [TestClass]
    public partial class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string input = "let a = 1;";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseRoot();
            CheckParserError(parser);

            Assert.AreEqual(root.Statements.Count, 1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string input = @"
let a = e;
let x = b;
let x = c;
let x = d;
return a;
";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseRoot();
            CheckParserError(parser);

            Assert.AreEqual(root.Statements.Count, 5);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string input = "let q = x;";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseRoot();
            CheckParserError(parser);

            Assert.AreEqual(root.ToJSON(), "{ \"root\":[{\"ASTName\":\"let\",\"Param\":{\"Name\":{\"ASTName\":\"Ident\",\"Param\":{\"Value\":\"q\"}},\"Value\":{\"ASTName\":\"Ident\",\"Param\":{\"Value\":\"x\"}}}}] }");
            //{ "root":[{"Name":"let","Param":{"Name":"q","Value":"1"}}] }
        }
        [TestMethod]
        public void TestMethod4()
        {
            string input = @"
let a = 2;
";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseRoot();
            CheckParserError(parser);
            root.ToJSON();

        }
        [TestMethod]
        public void TestMethod5()
        {
            string input = @"
let a = -2;
return !5;
";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseRoot();
            CheckParserError(parser);
            root.ToJSON();
        }
        [TestMethod]
        public void TestMethod6()
        {
            string input = @"
let a = 2 - 1;
return 5 + 2;
";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseRoot();
            CheckParserError(parser);
            root.ToJSON();
        }
        [TestMethod]
        public void TestMethod7()
        {
            string input = @"
let a = 2 - 1 * 2;
return 5 + 2;
";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseRoot();
            CheckParserError(parser);
            root.ToJSON();
        }
        [TestMethod]
        public void TestMethod8()
        {
            string input = @"
let a = true;
return false;
";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseRoot();
            CheckParserError(parser);
            root.ToJSON();
        }
        [TestMethod]
        public void TestMethod9()
        {
            string input = @"
let a = 1 + (2*2);
return !(false == false);
";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseRoot();
            CheckParserError(parser);
            root.ToJSON();
        }
        [TestMethod]
        public void TestMethod10()
        {
            string input = @"

";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseRoot();
            CheckParserError(parser);
            root.ToJSON();
        }
    }
}
