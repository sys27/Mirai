namespace Mirai.Emitting.Metadata.CodedIndexes
{
    public sealed class Indexes
    {
        public static CodedIndexType<TypeDefOrRefTag> TypeDefOrRef =
            new CodedIndexType<TypeDefOrRefTag>(2, new[]
            {
                TableType.TypeDef, TableType.TypeRef, TableType.TypeSpec
            });

        public static CodedIndexType<HasConstantTag> HasConstant =
            new CodedIndexType<HasConstantTag>(2, new[]
            {
                TableType.Field, TableType.Param, TableType.Property
            });

        public static CodedIndexType<HasCustomAttributeTag> HasCustomAttribute =
            new CodedIndexType<HasCustomAttributeTag>(5, new[]
            {
                TableType.Method,
                TableType.Field,
                TableType.TypeRef,
                TableType.TypeDef,
                TableType.Param,
                TableType.InterfaceImpl,
                TableType.MemberRef,
                TableType.Module,
                TableType.Property,
                TableType.Event,
                TableType.StandAloneSig,
                TableType.ModuleRef,
                TableType.TypeSpec,
                TableType.Assembly,
                TableType.AssemblyRef,
                TableType.File,
                TableType.ExportedType,
                TableType.ManifestResource,
                TableType.GenericParam,
                TableType.GenericParamConstraint,
                TableType.MethodSpec,
            });

        public static CodedIndexType<HasFieldMarshallTag> HasFieldMarshall =
            new CodedIndexType<HasFieldMarshallTag>(1, new[]
            {
                TableType.Field, TableType.Param
            });

        public static CodedIndexType<HasDeclSecurityTag> HasDeclSecurity =
            new CodedIndexType<HasDeclSecurityTag>(2, new[]
            {
                TableType.TypeDef, TableType.Method, TableType.Assembly
            });

        public static CodedIndexType<MemberRefParentTag> MemberRefParent =
            new CodedIndexType<MemberRefParentTag>(3, new[]
            {
                TableType.TypeDef,
                TableType.TypeRef,
                TableType.ModuleRef,
                TableType.Method,
                TableType.TypeSpec,
            });

        public static CodedIndexType<HasSemanticsTag> HasSemantics =
            new CodedIndexType<HasSemanticsTag>(1, new[]
            {
                TableType.Event, TableType.Property,
            });

        public static CodedIndexType<MethodDefOrRefTag> MethodDefOrRef =
            new CodedIndexType<MethodDefOrRefTag>(1, new[]
            {
                TableType.Method, TableType.MemberRef,
            });

        public static CodedIndexType<MemberForwardedTag> MemberForwarded =
            new CodedIndexType<MemberForwardedTag>(1, new[]
            {
                TableType.Field, TableType.Method,
            });

        public static CodedIndexType<ImplementationTag> Implementation =
            new CodedIndexType<ImplementationTag>(2, new[]
            {
                TableType.File,
                TableType.AssemblyRef,
                TableType.ExportedType,
            });

        public static CodedIndexType<CustomAttributeTypeTag> CustomAttributeType =
            new CodedIndexType<CustomAttributeTypeTag>(3, new[]
            {
                TableType.Method, TableType.MemberRef,
            });

        public static CodedIndexType<ResolutionScopeTag> ResolutionScope =
            new CodedIndexType<ResolutionScopeTag>(2, new[]
            {
                TableType.Module,
                TableType.ModuleRef,
                TableType.AssemblyRef,
                TableType.TypeRef,
            });

        public static CodedIndexType<TypeOrMethodDefTag> TypeOrMethodDef =
            new CodedIndexType<TypeOrMethodDefTag>(1, new[]
            {
                TableType.TypeDef, TableType.Method,
            });
    }
}