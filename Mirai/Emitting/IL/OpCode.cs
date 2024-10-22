namespace Mirai.Emitting.IL
{
    public sealed class OpCode
    {
        public OpCode(
            string name,
            ushort code,
            OperandType operandType,
            ControlFlow controlFlow,
            StackBehaviourPop stackBehaviourPop,
            StackBehaviourPush stackBehaviourPush)
        {
            Name = name;
            Code = code;
            OperandType = operandType;
            ControlFlow = controlFlow;
            StackBehaviourPop = stackBehaviourPop;
            StackBehaviourPush = stackBehaviourPush;
        }

        public string Name { get; }
        public ushort Code { get; }
        public OperandType OperandType { get; }
        public ControlFlow ControlFlow { get; }
        public StackBehaviourPop StackBehaviourPop { get; }
        public StackBehaviourPush StackBehaviourPush { get; }

        public static OpCode nop = new OpCode("nop", 0xFF00, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode @break = new OpCode("break", 0xFF01, OperandType.InlineNone, ControlFlow.Break, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode ldarg_0 = new OpCode("ldarg.0", 0xFF02, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldarg_1 = new OpCode("ldarg.1", 0xFF03, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldarg_2 = new OpCode("ldarg.2", 0xFF04, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldarg_3 = new OpCode("ldarg.3", 0xFF05, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldloc_0 = new OpCode("ldloc.0", 0xFF06, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldloc_1 = new OpCode("ldloc.1", 0xFF07, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldloc_2 = new OpCode("ldloc.2", 0xFF08, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldloc_3 = new OpCode("ldloc.3", 0xFF09, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode stloc_0 = new OpCode("stloc.0", 0xFF0A, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push0);
        public static OpCode stloc_1 = new OpCode("stloc.1", 0xFF0B, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push0);
        public static OpCode stloc_2 = new OpCode("stloc.2", 0xFF0C, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push0);
        public static OpCode stloc_3 = new OpCode("stloc.3", 0xFF0D, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push0);
        public static OpCode ldarg_s = new OpCode("ldarg.s", 0xFF0E, OperandType.ShortInlineVar, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldarga_s = new OpCode("ldarga.s", 0xFF0F, OperandType.ShortInlineVar, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode starg_s = new OpCode("starg.s", 0xFF10, OperandType.ShortInlineVar, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push0);
        public static OpCode ldloc_s = new OpCode("ldloc.s", 0xFF11, OperandType.ShortInlineVar, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldloca_s = new OpCode("ldloca.s", 0xFF12, OperandType.ShortInlineVar, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode stloc_s = new OpCode("stloc.s", 0xFF13, OperandType.ShortInlineVar, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push0);
        public static OpCode ldnull = new OpCode("ldnull", 0xFF14, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushRef);
        public static OpCode ldc_i4_m1 = new OpCode("ldc.i4.m1", 0xFF15, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i4_0 = new OpCode("ldc.i4.0", 0xFF16, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i4_1 = new OpCode("ldc.i4.1", 0xFF17, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i4_2 = new OpCode("ldc.i4.2", 0xFF18, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i4_3 = new OpCode("ldc.i4.3", 0xFF19, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i4_4 = new OpCode("ldc.i4.4", 0xFF1A, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i4_5 = new OpCode("ldc.i4.5", 0xFF1B, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i4_6 = new OpCode("ldc.i4.6", 0xFF1C, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i4_7 = new OpCode("ldc.i4.7", 0xFF1D, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i4_8 = new OpCode("ldc.i4.8", 0xFF1E, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i4_s = new OpCode("ldc.i4.s", 0xFF1F, OperandType.ShortInlineI, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i4 = new OpCode("ldc.i4", 0xFF20, OperandType.InlineI, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldc_i8 = new OpCode("ldc.i8", 0xFF21, OperandType.InlineI8, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI8);
        public static OpCode ldc_r4 = new OpCode("ldc.r4", 0xFF22, OperandType.ShortInlineR, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushR4);
        public static OpCode ldc_r8 = new OpCode("ldc.r8", 0xFF23, OperandType.InlineR, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushR8);
        public static OpCode unused = new OpCode("unused", 0xFF24, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode dup = new OpCode("dup", 0xFF25, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push1_Push1);
        public static OpCode pop = new OpCode("pop", 0xFF26, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push0);
        public static OpCode jmp = new OpCode("jmp", 0xFF27, OperandType.InlineMethod, ControlFlow.Call, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode call = new OpCode("call", 0xFF28, OperandType.InlineMethod, ControlFlow.Call, StackBehaviourPop.VarPop, StackBehaviourPush.VarPush);
        public static OpCode calli = new OpCode("calli", 0xFF29, OperandType.InlineSig, ControlFlow.Call, StackBehaviourPop.VarPop, StackBehaviourPush.VarPush);
        public static OpCode ret = new OpCode("ret", 0xFF2A, OperandType.InlineNone, ControlFlow.Return, StackBehaviourPop.VarPop, StackBehaviourPush.Push0);
        public static OpCode br_s = new OpCode("br.s", 0xFF2B, OperandType.ShortInlineBrTarget, ControlFlow.Branch, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode brfalse_s = new OpCode("brfalse.s", 0xFF2C, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.PopI, StackBehaviourPush.Push0);
        public static OpCode brtrue_s = new OpCode("brtrue.s", 0xFF2D, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.PopI, StackBehaviourPush.Push0);
        public static OpCode beq_s = new OpCode("beq.s", 0xFF2E, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode bge_s = new OpCode("bge.s", 0xFF2F, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode bgt_s = new OpCode("bgt.s", 0xFF30, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode ble_s = new OpCode("ble.s", 0xFF31, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode blt_s = new OpCode("blt.s", 0xFF32, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode bne_un_s = new OpCode("bne.un.s", 0xFF33, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode bge_un_s = new OpCode("bge.un.s", 0xFF34, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode bgt_un_s = new OpCode("bgt.un.s", 0xFF35, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode ble_un_s = new OpCode("ble.un.s", 0xFF36, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode blt_un_s = new OpCode("blt.un.s", 0xFF37, OperandType.ShortInlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode br = new OpCode("br", 0xFF38, OperandType.InlineBrTarget, ControlFlow.Branch, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode brfalse = new OpCode("brfalse", 0xFF39, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.PopI, StackBehaviourPush.Push0);
        public static OpCode brtrue = new OpCode("brtrue", 0xFF3A, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.PopI, StackBehaviourPush.Push0);
        public static OpCode beq = new OpCode("beq", 0xFF3B, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode bge = new OpCode("bge", 0xFF3C, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode bgt = new OpCode("bgt", 0xFF3D, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode ble = new OpCode("ble", 0xFF3E, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode blt = new OpCode("blt", 0xFF3F, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode bne_un = new OpCode("bne.un", 0xFF40, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode bge_un = new OpCode("bge.un", 0xFF41, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode bgt_un = new OpCode("bgt.un", 0xFF42, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode ble_un = new OpCode("ble.un", 0xFF43, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode blt_un = new OpCode("blt.un", 0xFF44, OperandType.InlineBrTarget, ControlFlow.ConditionalBranch, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push0);
        public static OpCode @switch = new OpCode("switch", 0xFF45, OperandType.InlineSwitch, ControlFlow.ConditionalBranch, StackBehaviourPop.PopI, StackBehaviourPush.Push0);
        public static OpCode ldind_i1 = new OpCode("ldind.i1", 0xFF46, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushI);
        public static OpCode ldind_u1 = new OpCode("ldind.u1", 0xFF47, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushI);
        public static OpCode ldind_i2 = new OpCode("ldind.i2", 0xFF48, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushI);
        public static OpCode ldind_u2 = new OpCode("ldind.u2", 0xFF49, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushI);
        public static OpCode ldind_i4 = new OpCode("ldind.i4", 0xFF4A, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushI);
        public static OpCode ldind_u4 = new OpCode("ldind.u4", 0xFF4B, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushI);
        public static OpCode ldind_i8 = new OpCode("ldind.i8", 0xFF4C, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushI8);
        public static OpCode ldind_i = new OpCode("ldind.i", 0xFF4D, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushI);
        public static OpCode ldind_r4 = new OpCode("ldind.r4", 0xFF4E, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushR4);
        public static OpCode ldind_r8 = new OpCode("ldind.r8", 0xFF4F, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushR8);
        public static OpCode ldind_ref = new OpCode("ldind.ref", 0xFF50, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushRef);
        public static OpCode stind_ref = new OpCode("stind.ref", 0xFF51, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode stind_i1 = new OpCode("stind.i1", 0xFF52, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode stind_i2 = new OpCode("stind.i2", 0xFF53, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode stind_i4 = new OpCode("stind.i4", 0xFF54, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode stind_i8 = new OpCode("stind.i8", 0xFF55, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI_PopI8, StackBehaviourPush.Push0);
        public static OpCode stind_r4 = new OpCode("stind.r4", 0xFF56, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI_PopR4, StackBehaviourPush.Push0);
        public static OpCode stind_r8 = new OpCode("stind.r8", 0xFF57, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI_PopR8, StackBehaviourPush.Push0);
        public static OpCode add = new OpCode("add", 0xFF58, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode sub = new OpCode("sub", 0xFF59, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode mul = new OpCode("mul", 0xFF5A, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode div = new OpCode("div", 0xFF5B, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode div_un = new OpCode("div.un", 0xFF5C, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode rem = new OpCode("rem", 0xFF5D, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode rem_un = new OpCode("rem.un", 0xFF5E, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode and = new OpCode("and", 0xFF5F, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode or = new OpCode("or", 0xFF60, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode xor = new OpCode("xor", 0xFF61, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode shl = new OpCode("shl", 0xFF62, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode shr = new OpCode("shr", 0xFF63, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode shr_un = new OpCode("shr.un", 0xFF64, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode neg = new OpCode("neg", 0xFF65, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push1);
        public static OpCode not = new OpCode("not", 0xFF66, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push1);
        public static OpCode conv_i1 = new OpCode("conv.i1", 0xFF67, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_i2 = new OpCode("conv.i2", 0xFF68, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_i4 = new OpCode("conv.i4", 0xFF69, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_i8 = new OpCode("conv.i8", 0xFF6A, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI8);
        public static OpCode conv_r4 = new OpCode("conv.r4", 0xFF6B, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushR4);
        public static OpCode conv_r8 = new OpCode("conv.r8", 0xFF6C, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushR8);
        public static OpCode conv_u4 = new OpCode("conv.u4", 0xFF6D, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_u8 = new OpCode("conv.u8", 0xFF6E, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI8);
        public static OpCode callvirt = new OpCode("callvirt", 0xFF6F, OperandType.InlineMethod, ControlFlow.Call, StackBehaviourPop.VarPop, StackBehaviourPush.VarPush);
        public static OpCode cpobj = new OpCode("cpobj", 0xFF70, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode ldobj = new OpCode("ldobj", 0xFF71, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.Push1);
        public static OpCode ldstr = new OpCode("ldstr", 0xFF72, OperandType.InlineString, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushRef);
        public static OpCode newobj = new OpCode("newobj", 0xFF73, OperandType.InlineMethod, ControlFlow.Call, StackBehaviourPop.VarPop, StackBehaviourPush.PushRef);
        public static OpCode castclass = new OpCode("castclass", 0xFF74, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopRef, StackBehaviourPush.PushRef);
        public static OpCode isinst = new OpCode("isinst", 0xFF75, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopRef, StackBehaviourPush.PushI);
        public static OpCode conv_r_un = new OpCode("conv.r.un", 0xFF76, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushR8);
        public static OpCode unbox = new OpCode("unbox", 0xFF79, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopRef, StackBehaviourPush.PushI);
        public static OpCode @throw = new OpCode("throw", 0xFF7A, OperandType.InlineNone, ControlFlow.Throw, StackBehaviourPop.PopRef, StackBehaviourPush.Push0);
        public static OpCode ldfld = new OpCode("ldfld", 0xFF7B, OperandType.InlineField, ControlFlow.Next, StackBehaviourPop.PopRef, StackBehaviourPush.Push1);
        public static OpCode ldflda = new OpCode("ldflda", 0xFF7C, OperandType.InlineField, ControlFlow.Next, StackBehaviourPop.PopRef, StackBehaviourPush.PushI);
        public static OpCode stfld = new OpCode("stfld", 0xFF7D, OperandType.InlineField, ControlFlow.Next, StackBehaviourPop.PopRef_Pop1, StackBehaviourPush.Push0);
        public static OpCode ldsfld = new OpCode("ldsfld", 0xFF7E, OperandType.InlineField, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldsflda = new OpCode("ldsflda", 0xFF7F, OperandType.InlineField, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode stsfld = new OpCode("stsfld", 0xFF80, OperandType.InlineField, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push0);
        public static OpCode stobj = new OpCode("stobj", 0xFF81, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopI_Pop1, StackBehaviourPush.Push0);
        public static OpCode conv_ovf_i1_un = new OpCode("conv.ovf.i1.un", 0xFF82, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_i2_un = new OpCode("conv.ovf.i2.un", 0xFF83, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_i4_un = new OpCode("conv.ovf.i4.un", 0xFF84, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_i8_un = new OpCode("conv.ovf.i8.un", 0xFF85, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI8);
        public static OpCode conv_ovf_u1_un = new OpCode("conv.ovf.u1.un", 0xFF86, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_u2_un = new OpCode("conv.ovf.u2.un", 0xFF87, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_u4_un = new OpCode("conv.ovf.u4.un", 0xFF88, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_u8_un = new OpCode("conv.ovf.u8.un", 0xFF89, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI8);
        public static OpCode conv_ovf_i_un = new OpCode("conv.ovf.i.un", 0xFF8A, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_u_un = new OpCode("conv.ovf.u.un", 0xFF8B, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode box = new OpCode("box", 0xFF8C, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushRef);
        public static OpCode newarr = new OpCode("newarr", 0xFF8D, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushRef);
        public static OpCode ldlen = new OpCode("ldlen", 0xFF8E, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef, StackBehaviourPush.PushI);
        public static OpCode ldelema = new OpCode("ldelema", 0xFF8F, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushI);
        public static OpCode ldelem_i1 = new OpCode("ldelem.i1", 0xFF90, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushI);
        public static OpCode ldelem_u1 = new OpCode("ldelem.u1", 0xFF91, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushI);
        public static OpCode ldelem_i2 = new OpCode("ldelem.i2", 0xFF92, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushI);
        public static OpCode ldelem_u2 = new OpCode("ldelem.u2", 0xFF93, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushI);
        public static OpCode ldelem_i4 = new OpCode("ldelem.i4", 0xFF94, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushI);
        public static OpCode ldelem_u4 = new OpCode("ldelem.u4", 0xFF95, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushI);
        public static OpCode ldelem_i8 = new OpCode("ldelem.i8", 0xFF96, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushI8);
        public static OpCode ldelem_i = new OpCode("ldelem.i", 0xFF97, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushI);
        public static OpCode ldelem_r4 = new OpCode("ldelem.r4", 0xFF98, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushR4);
        public static OpCode ldelem_r8 = new OpCode("ldelem.r8", 0xFF99, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushR8);
        public static OpCode ldelem_ref = new OpCode("ldelem.ref", 0xFF9A, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.PushRef);
        public static OpCode stelem_i = new OpCode("stelem.i", 0xFF9B, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode stelem_i1 = new OpCode("stelem.i1", 0xFF9C, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode stelem_i2 = new OpCode("stelem.i2", 0xFF9D, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode stelem_i4 = new OpCode("stelem.i4", 0xFF9E, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode stelem_i8 = new OpCode("stelem.i8", 0xFF9F, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI_PopI8, StackBehaviourPush.Push0);
        public static OpCode stelem_r4 = new OpCode("stelem.r4", 0xFFA0, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI_PopR4, StackBehaviourPush.Push0);
        public static OpCode stelem_r8 = new OpCode("stelem.r8", 0xFFA1, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI_PopR8, StackBehaviourPush.Push0);
        public static OpCode stelem_ref = new OpCode("stelem.ref", 0xFFA2, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopRef_PopI_PopRef, StackBehaviourPush.Push0);
        public static OpCode ldelem = new OpCode("ldelem", 0xFFA3, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopRef_PopI, StackBehaviourPush.Push1);
        public static OpCode stelem = new OpCode("stelem", 0xFFA4, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopRef_PopI_Pop1, StackBehaviourPush.Push0);
        public static OpCode unbox_any = new OpCode("unbox.any", 0xFFA5, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopRef, StackBehaviourPush.Push1);
        public static OpCode conv_ovf_i1 = new OpCode("conv.ovf.i1", 0xFFB3, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_u1 = new OpCode("conv.ovf.u1", 0xFFB4, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_i2 = new OpCode("conv.ovf.i2", 0xFFB5, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_u2 = new OpCode("conv.ovf.u2", 0xFFB6, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_i4 = new OpCode("conv.ovf.i4", 0xFFB7, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_u4 = new OpCode("conv.ovf.u4", 0xFFB8, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_i8 = new OpCode("conv.ovf.i8", 0xFFB9, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI8);
        public static OpCode conv_ovf_u8 = new OpCode("conv.ovf.u8", 0xFFBA, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI8);
        public static OpCode refanyval = new OpCode("refanyval", 0xFFC2, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode ckfinite = new OpCode("ckfinite", 0xFFC3, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushR8);
        public static OpCode mkrefany = new OpCode("mkrefany", 0xFFC6, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.Push1);
        public static OpCode ldtoken = new OpCode("ldtoken", 0xFFD0, OperandType.InlineTok, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode conv_u2 = new OpCode("conv.u2", 0xFFD1, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_u1 = new OpCode("conv.u1", 0xFFD2, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_i = new OpCode("conv.i", 0xFFD3, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_i = new OpCode("conv.ovf.i", 0xFFD4, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode conv_ovf_u = new OpCode("conv.ovf.u", 0xFFD5, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode add_ovf = new OpCode("add.ovf", 0xFFD6, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode add_ovf_un = new OpCode("add.ovf.un", 0xFFD7, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode mul_ovf = new OpCode("mul.ovf", 0xFFD8, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode mul_ovf_un = new OpCode("mul.ovf.un", 0xFFD9, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode sub_ovf = new OpCode("sub.ovf", 0xFFDA, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode sub_ovf_un = new OpCode("sub.ovf.un", 0xFFDB, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.Push1);
        public static OpCode endfinally = new OpCode("endfinally", 0xFFDC, OperandType.InlineNone, ControlFlow.Return, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode leave = new OpCode("leave", 0xFFDD, OperandType.InlineBrTarget, ControlFlow.Branch, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode leave_s = new OpCode("leave.s", 0xFFDE, OperandType.ShortInlineBrTarget, ControlFlow.Branch, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode stind_i = new OpCode("stind.i", 0xFFDF, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode conv_u = new OpCode("conv.u", 0xFFE0, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode prefix7 = new OpCode("prefix7", 0xFFF8, OperandType.InlineNone, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode prefix6 = new OpCode("prefix6", 0xFFF9, OperandType.InlineNone, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode prefix5 = new OpCode("prefix5", 0xFFFA, OperandType.InlineNone, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode prefix4 = new OpCode("prefix4", 0xFFFB, OperandType.InlineNone, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode prefix3 = new OpCode("prefix3", 0xFFFC, OperandType.InlineNone, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode prefix2 = new OpCode("prefix2", 0xFFFD, OperandType.InlineNone, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode prefix1 = new OpCode("prefix1", 0xFFFE, OperandType.InlineNone, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode prefixref = new OpCode("prefixref", 0xFFFF, OperandType.InlineNone, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode arglist = new OpCode("arglist", 0xFE00, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ceq = new OpCode("ceq", 0xFE01, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.PushI);
        public static OpCode cgt = new OpCode("cgt", 0xFE02, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.PushI);
        public static OpCode cgt_un = new OpCode("cgt.un", 0xFE03, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.PushI);
        public static OpCode clt = new OpCode("clt", 0xFE04, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.PushI);
        public static OpCode clt_un = new OpCode("clt.un", 0xFE05, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1_Pop1, StackBehaviourPush.PushI);
        public static OpCode ldftn = new OpCode("ldftn", 0xFE06, OperandType.InlineMethod, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode ldvirtftn = new OpCode("ldvirtftn", 0xFE07, OperandType.InlineMethod, ControlFlow.Next, StackBehaviourPop.PopRef, StackBehaviourPush.PushI);
        public static OpCode ldarg = new OpCode("ldarg", 0xFE09, OperandType.InlineVar, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldarga = new OpCode("ldarga", 0xFE0A, OperandType.InlineVar, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode starg = new OpCode("starg", 0xFE0B, OperandType.InlineVar, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push0);
        public static OpCode ldloc = new OpCode("ldloc", 0xFE0C, OperandType.InlineVar, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.Push1);
        public static OpCode ldloca = new OpCode("ldloca", 0xFE0D, OperandType.InlineVar, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode stloc = new OpCode("stloc", 0xFE0E, OperandType.InlineVar, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.Push0);
        public static OpCode localloc = new OpCode("localloc", 0xFE0F, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.PushI);
        public static OpCode endfilter = new OpCode("endfilter", 0xFE11, OperandType.InlineNone, ControlFlow.Return, StackBehaviourPop.PopI, StackBehaviourPush.Push0);
        public static OpCode unaligned_ = new OpCode("unaligned.", 0xFE12, OperandType.ShortInlineI, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode volatile_ = new OpCode("volatile.", 0xFE13, OperandType.InlineNone, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode tail_ = new OpCode("tail.", 0xFE14, OperandType.InlineNone, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode initobj = new OpCode("initobj", 0xFE15, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.PopI, StackBehaviourPush.Push0);
        public static OpCode constrained_ = new OpCode("constrained.", 0xFE16, OperandType.InlineType, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode cpblk = new OpCode("cpblk", 0xFE17, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI_PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode initblk = new OpCode("initblk", 0xFE18, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.PopI_PopI_PopI, StackBehaviourPush.Push0);
        public static OpCode rethrow = new OpCode("rethrow", 0xFE1A, OperandType.InlineNone, ControlFlow.Throw, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
        public static OpCode @sizeof = new OpCode("sizeof", 0xFE1C, OperandType.InlineType, ControlFlow.Next, StackBehaviourPop.Pop0, StackBehaviourPush.PushI);
        public static OpCode refanytype = new OpCode("refanytype", 0xFE1D, OperandType.InlineNone, ControlFlow.Next, StackBehaviourPop.Pop1, StackBehaviourPush.PushI);
        public static OpCode readonly_ = new OpCode("readonly.", 0xFE1E, OperandType.InlineNone, ControlFlow.Meta, StackBehaviourPop.Pop0, StackBehaviourPush.Push0);
    }
}