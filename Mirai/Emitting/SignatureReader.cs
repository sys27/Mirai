using System;
using Mirai.Emitting.Metadata;
using Mirai.Emitting.Metadata.CodedIndexes;
using Mirai.Emitting.Metadata.Signatures;
using Param = Mirai.Emitting.Metadata.Signatures.Param;
using Type = Mirai.Emitting.Metadata.Signatures.Type;
using ValueType = Mirai.Emitting.Metadata.Signatures.ValueType;

namespace Mirai.Emitting
{
    public ref struct SignatureReader
    {
        private ReadOnlySpan<byte> bytes;

        public SignatureReader(ReadOnlySpan<byte> bytes)
        {
            this.bytes = bytes;
        }

        public Signature ReadSignature()
        {
            var callingConvention = ReadCallingConvention();

            Signature signature;
            switch (callingConvention & CallingConvention.Mask)
            {
                case CallingConvention.Default:
                case CallingConvention.C:
                case CallingConvention.StdCall:
                case CallingConvention.ThisCall:
                case CallingConvention.FastCall:
                case CallingConvention.VarArg:
                    signature = ReadMethod(callingConvention);
                    break;
                case CallingConvention.Field:
                    signature = ReadField();
                    break;
                case CallingConvention.LocalSig:
                    signature = ReadLocalVar();
                    break;
                case CallingConvention.Property:
                    signature = ReadProperty(callingConvention);
                    break;
                // case CallingConvention.Unmanaged:
                // case CallingConvention.GenericInst:
                // case CallingConvention.NativeVarArg:
                //     signature = null;
                //     break;
                default:
                    throw new Exception();
            }

            if (bytes.Length != 0)
                throw new Exception();

            return signature;
        }

        private Signature ReadMethod(CallingConvention callingConvention)
        {
            // TODO: MethodDefSig / MethodRefSig / StandAloneSig

            var genParamCount = new CompressedUInt(0);
            if (callingConvention.HasFlag(CallingConvention.Generic))
                genParamCount = CompressedUInt.FromCompressed(ref bytes);

            var paramCount = CompressedUInt.FromCompressed(ref bytes);
            var retType = ReadRetType();
            var @params = ReadParams(paramCount);

            return new MethodDefSig(
                callingConvention,
                genParamCount,
                paramCount,
                retType,
                @params);
        }

        private Signature ReadField()
        {
            var customMod = ReadCustomMod();
            var type = ReadType();

            return new FieldSig(customMod, type);
        }

        private CustomMod? ReadCustomMod()
        {
            var cmod = (ElementType) bytes[0];
            if (cmod == ElementType.CModOpt || cmod == ElementType.Reqd)
            {
                bytes = bytes[1..];

                var defOrRef = ReadTypeDefOrRefEncoded();

                return new CustomMod(cmod, defOrRef);
            }

            return null;
        }

        private Signature ReadLocalVar()
        {
            var count = CompressedUInt.FromCompressed(ref bytes);
            var items = new LocalVarSigItem[count];
            for (var i = 0; i < items.Length; i++)
            {
                var customMod = ReadCustomMod();
                var type = ReadType();

                items[i] = new LocalVarSigItem(customMod, type);
            }

            return new LocalVarSig(count, items);
        }

        private Signature ReadProperty(CallingConvention callingConvention)
        {
            var paramCount = ReadCompressedUInt();
            var customMod = ReadCustomMod();
            var type = ReadType();
            var param = ReadParams(paramCount);

            return new PropertySig(
                callingConvention,
                paramCount,
                customMod,
                type,
                param);
        }

        private TypeDefOrRefEncoded ReadTypeDefOrRefEncoded()
        {
            var compressed = CompressedUInt.FromCompressed(ref bytes);
            var codedIndex = Indexes.TypeDefOrRef.Create(compressed);

            return new TypeDefOrRefEncoded(codedIndex);
        }

        private RetType ReadRetType()
        {
            var customMod = ReadCustomMod();
            var type = ReadType();

            return new RetType(customMod, type);
        }

        public Type ReadType()
        {
            var elementType = ReadElementType();

            return elementType switch
            {
                ElementType.ValueType => ReadValueType(),
                ElementType.Class => ReadClassType(),
                ElementType.Ptr => ReadPtrType(),
                ElementType.FnPtr => ReadFnPtrType(),
                ElementType.Array => ReadArrayType(),
                ElementType.SzArray => ReadSzArrayType(),
                ElementType.GenericInst => ReadGenericType(),
                ElementType.Var => ReadVarType(),
                ElementType.MVar => ReadMVarType(),
                ElementType.TypedByRef => throw new Exception(),
                ElementType.ByRef => ReadByRef(),
                ElementType.Pinned => ReadPinnedType(),
                _ => new Type(elementType),
            };
        }

        private ValueType ReadValueType()
        {
            var defOrRef = ReadTypeDefOrRefEncoded();

            return new ValueType(defOrRef);
        }

        private ClassType ReadClassType()
        {
            var defOrRef = ReadTypeDefOrRefEncoded();

            return new ClassType(defOrRef);
        }

        private PtrType ReadPtrType()
        {
            var customMod = ReadCustomMod();
            var type = ReadType();

            return new PtrType(customMod, type);
        }

        private FnPtrType ReadFnPtrType()
        {
            throw new NotImplementedException();
        }

        private ArrayType ReadArrayType()
        {
            var type = ReadType();
            var arrayShape = ReadArrayShape();

            return new ArrayType(type, arrayShape);
        }

        private ArrayShape ReadArrayShape()
        {
            var rank = CompressedUInt.FromCompressed(ref bytes);

            var numSize = CompressedUInt.FromCompressed(ref bytes);
            var size = new CompressedUInt[numSize];
            for (var i = 0; i < size.Length; i++)
                size[i] = CompressedUInt.FromCompressed(ref bytes);

            var numLoBounds = CompressedUInt.FromCompressed(ref bytes);
            var loBound = new CompressedUInt[numLoBounds];
            for (var i = 0; i < loBound.Length; i++)
                loBound[i] = CompressedUInt.FromCompressed(ref bytes);

            return new ArrayShape(
                rank,
                numSize,
                size,
                numLoBounds,
                loBound);
        }

        private SzArrayType ReadSzArrayType()
        {
            var customMod = ReadCustomMod();
            var type = ReadType();

            return new SzArrayType(customMod, type);
        }

        private GenericType ReadGenericType()
        {
            var elementType = ReadElementType();
            if (elementType != ElementType.Class && elementType != ElementType.ValueType)
                throw new Exception();

            var defOrRef = ReadTypeDefOrRefEncoded();
            var genArgCount = CompressedUInt.FromCompressed(ref bytes);
            var types = new Type[genArgCount];
            for (var i = 0; i < types.Length; i++)
                types[i] = ReadType();

            return new GenericType(
                elementType,
                defOrRef,
                genArgCount,
                types);
        }

        private VarType ReadVarType()
        {
            var number = CompressedUInt.FromCompressed(ref bytes);

            return new VarType(number);
        }

        private MVarType ReadMVarType()
        {
            var number = CompressedUInt.FromCompressed(ref bytes);

            return new MVarType(number);
        }

        private ByRefType ReadByRef()
        {
            var type = ReadType();

            return new ByRefType(type);
        }

        private PinnedType ReadPinnedType()
        {
            var type = ReadType();

            return new PinnedType(type);
        }

        private CompressedUInt ReadCompressedUInt()
        {
            return CompressedUInt.FromCompressed(ref bytes);
        }

        private Param[] ReadParams(uint count)
        {
            var @params = new Param[count];

            for (var i = 0; i < @params.Length; i++)
                @params[i] = ReadParam();

            return @params;
        }

        private Param ReadParam()
        {
            var customMod = ReadCustomMod();
            var type = ReadType();

            return new Param(customMod, type);
        }

        private CallingConvention ReadCallingConvention()
        {
            var callingConvention = (CallingConvention) bytes[0];
            bytes = bytes[1..];

            return callingConvention;
        }

        private ElementType ReadElementType()
        {
            var elementType = (ElementType) bytes[0];
            bytes = bytes[1..];

            return elementType;
        }
    }
}