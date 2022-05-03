using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Qsu.AST;
using Qsu.AST.Expressions;
using Qsu.AST.Statements;
using Qsu.Lexing;


namespace QsuTest
{
    [TestClass]
    public class AstTest
    {
        [TestMethod]
        public void TestNodeToCode1()
        {
            var code = "let x = abc;";

            var root = new Root();
            root.Statements = new List<IStatement>();

            root.Statements.Add(
                new LetStatement()
                {
                    Token = new Token(TokenType.LET, "let"),
                    Name = new Identifier(
                        new Token(TokenType.IDENT, "x"),
                        "x"
                    ),
                    Value = new Identifier(
                        new Token(TokenType.IDENT, "abc"),
                        "abc"
                    ),
                }
            );

            Console.WriteLine(root.ToCode());

            Assert.AreEqual(code, root.ToCode(), "Root.ToCode() の結果が間違っています。");
        }
    }
}
