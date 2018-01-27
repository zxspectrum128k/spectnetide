﻿using Antlr4.Runtime;

namespace Spect.Net.TestParser.SyntaxTree.TestSet
{
    /// <summary>
    /// Represents an abstract test option clause
    /// </summary>
    public abstract class TestOptionNode: NodeBase
    {
        /// <summary>
        /// Creates a clause with the span defined by the passed context
        /// </summary>
        /// <param name="context">Parser rule context</param>
        protected TestOptionNode(ParserRuleContext context) : base(context)
        {
            OptionKeywordSpan = context.CreateSpan(0);
        }

        public TextSpan OptionKeywordSpan { get; }
    }
}