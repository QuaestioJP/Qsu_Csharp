using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Qsu.Parsing;
using Qsu.Lexing;
using Qsu.AST;

namespace QsuTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string input = "let a = 1;";
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseRoot();

            Assert.AreEqual(root.Statements.Count, 1);
        }
    }
}
