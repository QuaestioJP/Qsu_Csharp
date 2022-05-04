using System;
using System.Collections.Generic;
using System.Text;

namespace Qsu.AST.ToJSON
{
    public static class JsonUtil
    {
        public static string StatementToJSON(string StateName, (string , string)[] p)
        {
            var builder = new StringBuilder();

            builder.Append("{");
            
            builder.Append($"\"Name\":\"{StateName}\"");
            
            builder.Append(",");

            builder.Append("\"Param\":");
            builder.Append("{");
            for (int i = 0; i < p.Length; i++)
            {

                builder.Append($"\"{p[i].Item1}\":{p[i].Item2}");
                if (p.Length - 1 != i)
                {
                    builder.Append(",");
                }
            }
            builder.Append("}");
            
            builder.Append("}");

            return builder.ToString();
        }
    }
}
