using System.Text;
using System.Collections.Generic;
using Qsu.AST;
using Qsu.AST.Expressions;
using Qsu.AST.Statements;

namespace Qsu.AST
{
    public class Root : INode
    {
        public List<IStatement> Statements;

        public string ToJSON()
        {
            var builder = new StringBuilder();

            builder.Append("{ \"root\":[");

            for (int i = 0; i < Statements.Count; i++)
            {
                builder.Append(Statements[i].ToJSON());

                if (i != Statements.Count - 1)
                {
                    builder.Append(",");
                }
            }
            builder.Append("] }");

            return builder.ToString();
        }

        public string ToCsharp()
        {
            var builder = new StringBuilder();
            builder.Append("using System;");
            builder.Append("namespace QsuProject");
            builder.Append("{");

            builder.Append("public class Program");
            builder.Append("{");

            builder.Append("public void Main(string[] args)");
            builder.Append("{");

            foreach (var item in Statements)
            {
                builder.Append(item.ToCsharp());
            }

            builder.Append("}");
            builder.Append("public void QsuUtility_ExpressionStatement(object expression){}");

            builder.Append("}");

            builder.Append("}");
            return builder.ToString();
        }

        public string ToPython()
        {
            var builder = new StringBuilder();

            builder.Append("def QsuUtility_ExpressionStatement(expression):\n    pass\n");

            foreach (var item in Statements)
            {
                builder.Append(item.ToPython());
            }

            return builder.ToString();
        }

        public string ToJavaScript()
        {
            var builder = new StringBuilder();

            builder.Append("function QsuUtility_ExpressionStatement(expression){;}");

            foreach (var item in Statements)
            {
                builder.Append(item.ToJavaScript());
            }

            return builder.ToString();
        }

        public string ToJava()
        {
            var builder = new StringBuilder();

            builder.Append("public class Program");
            builder.Append("{");

            builder.Append("public static void main(String[] args)");
            builder.Append("{");

            foreach (var item in Statements)
            {
                builder.Append(item.ToJava());
            }

            builder.Append("}");
            builder.Append("public void QsuUtility_ExpressionStatement(Object expression){}");

            builder.Append("}");

            return builder.ToString();
        }

        public string ToClang()
        {
            var builder = new StringBuilder();

            builder.Append("#include<stdio.h>");

            builder.Append("void main(int argc, char *argv[])");
            builder.Append("{");

            foreach (var item in Statements)
            {
                builder.Append(item.ToClang());
            }

            builder.Append("}");

            //これの用途と型の判別方法が分かったら変更する
            builder.Append("void QsuUtility_ExpressionStatement(int expression){}");

            return builder.ToString();
        }
    }
}
