using System;
using System.Collections.Generic;
using Qsu.AST;
using Qsu.AST.Statements;
using Qsu.AST.Expressions;
using Qsu.Objects;

namespace Qsu.Evaluating
{
    public class Evaluator
    {
        public BooleanObject True = new BooleanObject(true);
        public BooleanObject False = new BooleanObject(false);
        public NullObject Null = new NullObject();

        public IObject Eval(INode node)
        {
            switch (node)
            {
                case Root root:
                    return EvalRootStatement(root.Statements);
                case IntegerLiteral integerLiteral:
                    return new IntegerObject(integerLiteral.Value);
                case BooleanLiteral booleanLiteral:
                    return booleanLiteral.Value ? True : False;
                case PrefixExpression prefixExpression:
                    var right = Eval(prefixExpression.Right);
                    return EvalPrefixExpression(prefixExpression.Operator, right);
                case BlockStatement blockStatement:
                    return EvalBlockStatement(blockStatement);
                case IfStatement ifStatement:
                    return EvalIfStatement(ifStatement);
                case ReturnStatement returnStatement:
                    var value = Eval(returnStatement.Value);
                    return new ReturnValue(value);
            }

            Console.WriteLine(node.GetType());

            return null;
        }

        public IObject EvalRootStatement(List<IStatement> statements)
        {
            IObject result = null;

            foreach (var statement in statements)
            {
                result = Eval(statement);

                if (result is ReturnValue returnValue)
                {
                    return returnValue.Value;
                }
            }

            return result;
        }

        public IObject EvalBlockStatement(BlockStatement blockStatement)
        {
            IObject result = null;
            foreach (var statement in blockStatement.Statements)
            {
                result = Eval(statement);

                if (result.Type() == ObjectType.RETURN_VALUE) return result;
            }

            return result;
        }

        public IObject EvalPrefixExpression(string op, IObject right)
        {
            switch (op)
            {
                case "!":
                    return EvalBangOperator(right);
                case "-":
                    return EvalMinusPrefixOperatorExpression(right);
            }

            return Null;
        }

        public IObject EvalBangOperator(IObject right)
        {
            if (right == True) return False;
            if (right == False) return True;

            return False;
        }

        public IObject EvalMinusPrefixOperatorExpression(IObject right)
        {
            if (right.Type() != ObjectType.INTEGER) return Null;

            var value = (right as IntegerObject).Value;
            return new IntegerObject(-value);
        }

        public IObject EvalInfixExpression(string op, IObject left , IObject right)
        {
            if (left is IntegerObject leftIntegerObject && right is IntegerObject rightIntegerObject)
            {
                return EvalIntegerInfixExpression(op, leftIntegerObject, rightIntegerObject);
            }

            switch (op)
            {
                case "==":
                    return ToBooleanObject(left == right);
                case "!=":
                    return ToBooleanObject(left != right);
            }

            return Null;
        }

        public IObject EvalIntegerInfixExpression(string op,IntegerObject left, IntegerObject right)
        {
            var leftValue = left.Value;
            var rightValue = right.Value;

            switch (op)
            {
                case "+":
                    return new IntegerObject(leftValue + rightValue);
                case "-":
                    return new IntegerObject(leftValue - rightValue);
                case "*":
                    return new IntegerObject(leftValue * rightValue);
                case "/":
                    return new IntegerObject(leftValue / rightValue);
                case "<":
                    return ToBooleanObject(leftValue < rightValue);
                case ">":
                    return ToBooleanObject(leftValue > rightValue);
                case "==":
                    return ToBooleanObject(leftValue == rightValue);
                case "!=":
                    return ToBooleanObject(leftValue != rightValue);
            }

            return Null;
        }

        public BooleanObject ToBooleanObject(bool value) => value ? True : False;

        public IObject EvalIfStatement(IfStatement ifStatement)
        {
            var condition = Eval(ifStatement.Condition);

            if (IsTruthly(condition))
            {
                return EvalBlockStatement(ifStatement.Consequence);
            }
            else if(ifStatement.Alternative != null)
            {
                return EvalBlockStatement(ifStatement.Alternative);
            }

            return Null;
        }

        public bool IsTruthly(IObject obj)
        {
            if (obj == True) return true;
            if (obj == False) return false;

            return false;
        }
    }
}
