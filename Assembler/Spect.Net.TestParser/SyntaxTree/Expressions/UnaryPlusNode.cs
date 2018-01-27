﻿using Antlr4.Runtime;

namespace Spect.Net.TestParser.SyntaxTree.Expressions
{
    /// <summary>
    /// This class represents an UNARY + operation
    /// </summary>
    public sealed class UnaryPlusNode: UnaryExpressionNode
    {
        /// <summary>
        /// Retrieves the value of the expression
        /// </summary>
        /// <param name="evalContext">Evaluation context</param>
        /// <returns>Evaluated expression value</returns>
        public override ExpressionValue Evaluate(IEvaluationContext evalContext)
        {
            // --- Check operand error
            var operandValue = Operand.Evaluate(evalContext);
            if (operandValue.Type == ExpressionValueType.Error)
            {
                EvaluationError = Operand.EvaluationError;
                return ExpressionValue.Error;
            }

            // --- Carry out operation
            if (operandValue.Type != ExpressionValueType.ByteArray)
            {
                return operandValue;
            }

            EvaluationError = "Unary plus operator cannot be applied on a byte array";
            return ExpressionValue.Error;
        }

        public UnaryPlusNode(ParserRuleContext context) : base(context)
        {
        }
    }
}