using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Qsu.Parsing;
using Qsu.Lexing;
using Qsu.AST;

namespace QsuTest
{
    public partial class UnitTest1
    {
        private void CheckParserError(Parser parser)
        {
            if (parser.Errors.Count == 0) return;

            foreach (var item in parser.Errors)
            {
                Assert.Fail(item);
            }
        }
    }
}
