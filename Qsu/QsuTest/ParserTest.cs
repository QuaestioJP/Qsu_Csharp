﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Qsu.Lexing;
using Qsu.Parsing;
using Qsu.AST.Statements;
using Qsu.AST;

namespace QsuTest
{
    [TestClass]
    public class ParsetTest
    {
        [TestMethod]
        public void TestLetStatement1()
        {
            var input = 
@"
return 5;
return 10;
return = 993322;";

            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var root = parser.ParseProgram();
            _CheckParserErrors(parser);

            Assert.AreEqual(
                root.Statements.Count, 3,
                "Root.Statementsの数が間違っています。"
            );

            foreach (var statement in root.Statements)
            {
                var returnStatement = statement as ReturnStatement;
                if (returnStatement == null)
                {
                    Assert.Fail("statement が ReturnStatement ではありません。");
                }

                Assert.AreEqual(
                    returnStatement.TokenLiteral(), "return",
                    $"return のリテラルが間違っています。"
                );
            }
        }
        private void _TestLetStatement(IStatement statement, string name)
        {
            Assert.AreEqual(
                statement.TokenLiteral(), "let",
                "TokenLiteral が let ではありません。"
            );

            var letStatement = statement as LetStatement;
            if (letStatement == null)
            {
                Assert.Fail("statement が LetStatement ではありません。");
            }

            Assert.AreEqual(
                letStatement.Name.Value, name,
                $"識別子が間違っています。"
            );

            Assert.AreEqual(
                letStatement.Name.TokenLiteral(), name,
                $"識別子のリテラルが間違っています。"
            );

        }

        private void _CheckParserErrors(Parser parser)
        {
            if (parser.Errors.Count == 0) return;
            var message = "\n" + string.Join("\n", parser.Errors);
            Assert.Fail(message);
        }
    }
}
