using System;
using System.Collections.Generic;
using System.Text;

namespace Qsu.AST
{
    /// <summary>
    /// 全てのノードが実装しているインターフェース
    /// </summary>
    public interface INode
    {
        public string ToJSON();

        public string ToCsharp();
    }

    /// <summary>
    /// 全ての文が実装しているインターフェース
    /// </summary>
    public interface IStatement : INode
    {

    }

    /// <summary>
    /// 全ての式が実装しているインターフェース
    /// </summary>
    public interface IExpression : INode
    {

    }
}
