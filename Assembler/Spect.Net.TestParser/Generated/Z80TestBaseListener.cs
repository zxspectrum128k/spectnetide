//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.4
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\dotne\source\repos\spectnetide\Assembler\AntlrZ80TestParserGenerator\AntlrZ80TestParserGenerator\Z80Test.g4 by ANTLR 4.6.4

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Spect.Net.TestParser.Generated {

using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IZ80TestListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.4")]
[System.CLSCompliant(false)]
public partial class Z80TestBaseListener : IZ80TestListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.compileUnit"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCompileUnit([NotNull] Z80TestParser.CompileUnitContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.compileUnit"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCompileUnit([NotNull] Z80TestParser.CompileUnitContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.testSet"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTestSet([NotNull] Z80TestParser.TestSetContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.testSet"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTestSet([NotNull] Z80TestParser.TestSetContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.testSetBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTestSetBody([NotNull] Z80TestParser.TestSetBodyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.testSetBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTestSetBody([NotNull] Z80TestParser.TestSetBodyContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.machineContext"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMachineContext([NotNull] Z80TestParser.MachineContextContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.machineContext"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMachineContext([NotNull] Z80TestParser.MachineContextContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.sourceContext"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSourceContext([NotNull] Z80TestParser.SourceContextContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.sourceContext"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSourceContext([NotNull] Z80TestParser.SourceContextContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.testOptions"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTestOptions([NotNull] Z80TestParser.TestOptionsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.testOptions"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTestOptions([NotNull] Z80TestParser.TestOptionsContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.testOption"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTestOption([NotNull] Z80TestParser.TestOptionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.testOption"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTestOption([NotNull] Z80TestParser.TestOptionContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.dataBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDataBlock([NotNull] Z80TestParser.DataBlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.dataBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDataBlock([NotNull] Z80TestParser.DataBlockContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.dataBlockBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDataBlockBody([NotNull] Z80TestParser.DataBlockBodyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.dataBlockBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDataBlockBody([NotNull] Z80TestParser.DataBlockBodyContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.valueDef"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterValueDef([NotNull] Z80TestParser.ValueDefContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.valueDef"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitValueDef([NotNull] Z80TestParser.ValueDefContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.memPattern"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMemPattern([NotNull] Z80TestParser.MemPatternContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.memPattern"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMemPattern([NotNull] Z80TestParser.MemPatternContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.byteSet"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterByteSet([NotNull] Z80TestParser.ByteSetContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.byteSet"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitByteSet([NotNull] Z80TestParser.ByteSetContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.wordSet"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterWordSet([NotNull] Z80TestParser.WordSetContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.wordSet"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitWordSet([NotNull] Z80TestParser.WordSetContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.text"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterText([NotNull] Z80TestParser.TextContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.text"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitText([NotNull] Z80TestParser.TextContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.portMock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPortMock([NotNull] Z80TestParser.PortMockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.portMock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPortMock([NotNull] Z80TestParser.PortMockContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.portPulse"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPortPulse([NotNull] Z80TestParser.PortPulseContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.portPulse"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPortPulse([NotNull] Z80TestParser.PortPulseContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.initSettings"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInitSettings([NotNull] Z80TestParser.InitSettingsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.initSettings"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInitSettings([NotNull] Z80TestParser.InitSettingsContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.setupCode"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSetupCode([NotNull] Z80TestParser.SetupCodeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.setupCode"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSetupCode([NotNull] Z80TestParser.SetupCodeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.cleanupCode"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCleanupCode([NotNull] Z80TestParser.CleanupCodeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.cleanupCode"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCleanupCode([NotNull] Z80TestParser.CleanupCodeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.invokeCode"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInvokeCode([NotNull] Z80TestParser.InvokeCodeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.invokeCode"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInvokeCode([NotNull] Z80TestParser.InvokeCodeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.testBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTestBlock([NotNull] Z80TestParser.TestBlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.testBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTestBlock([NotNull] Z80TestParser.TestBlockContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.testParams"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTestParams([NotNull] Z80TestParser.TestParamsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.testParams"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTestParams([NotNull] Z80TestParser.TestParamsContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.testCases"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTestCases([NotNull] Z80TestParser.TestCasesContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.testCases"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTestCases([NotNull] Z80TestParser.TestCasesContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.arrange"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArrange([NotNull] Z80TestParser.ArrangeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.arrange"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArrange([NotNull] Z80TestParser.ArrangeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignment([NotNull] Z80TestParser.AssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignment([NotNull] Z80TestParser.AssignmentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.regAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRegAssignment([NotNull] Z80TestParser.RegAssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.regAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRegAssignment([NotNull] Z80TestParser.RegAssignmentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.flagStatus"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFlagStatus([NotNull] Z80TestParser.FlagStatusContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.flagStatus"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFlagStatus([NotNull] Z80TestParser.FlagStatusContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.memAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMemAssignment([NotNull] Z80TestParser.MemAssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.memAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMemAssignment([NotNull] Z80TestParser.MemAssignmentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.act"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAct([NotNull] Z80TestParser.ActContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.act"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAct([NotNull] Z80TestParser.ActContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.assert"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssert([NotNull] Z80TestParser.AssertContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.assert"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssert([NotNull] Z80TestParser.AssertContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.reg8"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReg8([NotNull] Z80TestParser.Reg8Context context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.reg8"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReg8([NotNull] Z80TestParser.Reg8Context context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.reg8Idx"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReg8Idx([NotNull] Z80TestParser.Reg8IdxContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.reg8Idx"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReg8Idx([NotNull] Z80TestParser.Reg8IdxContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.reg8Spec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReg8Spec([NotNull] Z80TestParser.Reg8SpecContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.reg8Spec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReg8Spec([NotNull] Z80TestParser.Reg8SpecContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.reg16"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReg16([NotNull] Z80TestParser.Reg16Context context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.reg16"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReg16([NotNull] Z80TestParser.Reg16Context context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.reg16Idx"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReg16Idx([NotNull] Z80TestParser.Reg16IdxContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.reg16Idx"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReg16Idx([NotNull] Z80TestParser.Reg16IdxContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.reg16Spec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReg16Spec([NotNull] Z80TestParser.Reg16SpecContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.reg16Spec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReg16Spec([NotNull] Z80TestParser.Reg16SpecContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.flag"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFlag([NotNull] Z80TestParser.FlagContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.flag"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFlag([NotNull] Z80TestParser.FlagContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpr([NotNull] Z80TestParser.ExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpr([NotNull] Z80TestParser.ExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.orExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOrExpr([NotNull] Z80TestParser.OrExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.orExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOrExpr([NotNull] Z80TestParser.OrExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.xorExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterXorExpr([NotNull] Z80TestParser.XorExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.xorExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitXorExpr([NotNull] Z80TestParser.XorExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.andExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAndExpr([NotNull] Z80TestParser.AndExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.andExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAndExpr([NotNull] Z80TestParser.AndExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.equExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEquExpr([NotNull] Z80TestParser.EquExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.equExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEquExpr([NotNull] Z80TestParser.EquExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.relExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRelExpr([NotNull] Z80TestParser.RelExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.relExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRelExpr([NotNull] Z80TestParser.RelExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.shiftExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterShiftExpr([NotNull] Z80TestParser.ShiftExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.shiftExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitShiftExpr([NotNull] Z80TestParser.ShiftExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.addExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAddExpr([NotNull] Z80TestParser.AddExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.addExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAddExpr([NotNull] Z80TestParser.AddExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.multExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultExpr([NotNull] Z80TestParser.MultExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.multExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultExpr([NotNull] Z80TestParser.MultExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.unaryExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterUnaryExpr([NotNull] Z80TestParser.UnaryExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.unaryExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitUnaryExpr([NotNull] Z80TestParser.UnaryExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.literalExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLiteralExpr([NotNull] Z80TestParser.LiteralExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.literalExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLiteralExpr([NotNull] Z80TestParser.LiteralExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.symbolExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSymbolExpr([NotNull] Z80TestParser.SymbolExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.symbolExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSymbolExpr([NotNull] Z80TestParser.SymbolExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.registerSpec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRegisterSpec([NotNull] Z80TestParser.RegisterSpecContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.registerSpec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRegisterSpec([NotNull] Z80TestParser.RegisterSpecContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.addrSpec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAddrSpec([NotNull] Z80TestParser.AddrSpecContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.addrSpec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAddrSpec([NotNull] Z80TestParser.AddrSpecContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="Z80TestParser.reachSpec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReachSpec([NotNull] Z80TestParser.ReachSpecContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="Z80TestParser.reachSpec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReachSpec([NotNull] Z80TestParser.ReachSpecContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace Spect.Net.TestParser.Generated
