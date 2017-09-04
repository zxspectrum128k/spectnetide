﻿using AntlrZ80Asm.SyntaxTree;

namespace AntlrZ80Asm.Assembler
{
    /// <summary>
    /// This class represents an error when invalid argument is used
    /// </summary>
    public class InvalidLabelError : SemanticErrorBase
    {
        public InvalidLabelError(SourceLineBase line, string message) : 
            base(line.SourceLine, line.Position, "", message)
        {
        }
    }
}