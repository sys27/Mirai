namespace Mirai.Emitting.Metadata
{
    /// <summary>
    /// The metadata table types.
    /// </summary>
    public enum TableType : byte
    {
        /// <summary>
        /// Module table (0x00).
        /// </summary>
        Module,

        /// <summary>
        /// TypeRef table (0x01).
        /// </summary>
        TypeRef,

        /// <summary>
        /// TypeDef table (0x02).
        /// </summary>
        TypeDef,

        /// <summary>
        /// FieldPtr table (0x03).
        /// </summary>
        FieldPtr,

        /// <summary>
        /// Field table (0x04).
        /// </summary>
        Field,

        /// <summary>
        /// MethodPtr table (0x05).
        /// </summary>
        MethodPtr,

        /// <summary>
        /// Method table (0x06).
        /// </summary>
        Method,

        /// <summary>
        /// ParamPtr table (0x07).
        /// </summary>
        ParamPtr,

        /// <summary>
        /// Param table (0x08).
        /// </summary>
        Param,

        /// <summary>
        /// InterfaceImpl table (0x09).
        /// </summary>
        InterfaceImpl,

        /// <summary>
        /// MemberRef table (0x0A).
        /// </summary>
        MemberRef,

        /// <summary>
        /// Constant table (0x0B).
        /// </summary>
        Constant,

        /// <summary>
        /// CustomAttribute table (0x0C).
        /// </summary>
        CustomAttribute,

        /// <summary>
        /// FieldMarshal table (0x0D).
        /// </summary>
        FieldMarshal,

        /// <summary>
        /// DeclSecurity table (0x0E).
        /// </summary>
        DeclSecurity,

        /// <summary>
        /// ClassLayout table (0x0F).
        /// </summary>
        ClassLayout,

        /// <summary>
        /// FieldLayout table (0x10).
        /// </summary>
        FieldLayout,

        /// <summary>
        /// StandAloneSig table (0x11).
        /// </summary>
        StandAloneSig,

        /// <summary>
        /// EventMap table (0x12).
        /// </summary>
        EventMap,

        /// <summary>
        /// EventPtr table (0x13).
        /// </summary>
        EventPtr,

        /// <summary>
        /// Event table (0x14).
        /// </summary>
        Event,

        /// <summary>
        /// PropertyMap table (0x15).
        /// </summary>
        PropertyMap,

        /// <summary>
        /// PropertyPtr table (0x16).
        /// </summary>
        PropertyPtr,

        /// <summary>
        /// Property table (0x17).
        /// </summary>
        Property,

        /// <summary>
        /// MethodSemantics table (0x18).
        /// </summary>
        MethodSemantics,

        /// <summary>
        /// MethodImpl table (0x19).
        /// </summary>
        MethodImpl,

        /// <summary>
        /// ModuleRef table (0x1A).
        /// </summary>
        ModuleRef,

        /// <summary>
        /// TypeSpec table (0x1B).
        /// </summary>
        TypeSpec,

        /// <summary>
        /// ImplMap table (0x1C).
        /// </summary>
        ImplMap,

        /// <summary>
        /// FieldRVA table (0x1D).
        /// </summary>
        FieldRVA,

        /// <summary>
        /// ENCLog table (0x1E).
        /// </summary>
        ENCLog,

        /// <summary>
        /// ENCMap table (0x1F).
        /// </summary>
        ENCMap,

        /// <summary>
        /// Assembly table (0x20).
        /// </summary>
        Assembly,

        /// <summary>
        /// AssemblyProcessor table (0x21).
        /// </summary>
        AssemblyProcessor,

        /// <summary>
        /// AssemblyOS table (0x22).
        /// </summary>
        AssemblyOS,

        /// <summary>
        /// AssemblyRef table (0x23).
        /// </summary>
        AssemblyRef,

        /// <summary>
        /// AssemblyRefProcessor table (0x24).
        /// </summary>
        AssemblyRefProcessor,

        /// <summary>
        /// AssemblyRefOS table (0x25).
        /// </summary>
        AssemblyRefOS,

        /// <summary>
        /// File table (0x26).
        /// </summary>
        File,

        /// <summary>
        /// ExportedType table (0x27).
        /// </summary>
        ExportedType,

        /// <summary>
        /// ManifestResource table (0x28).
        /// </summary>
        ManifestResource,

        /// <summary>
        /// NestedClass table (0x29).
        /// </summary>
        NestedClass,

        /// <summary>
        /// GenericParam table (0x2A).
        /// </summary>
        GenericParam,

        /// <summary>
        /// MethodSpec table (0x2B).
        /// </summary>
        MethodSpec,

        /// <summary>
        /// GenericParamConstraint table (0x2C).
        /// </summary>
        GenericParamConstraint,

        /// <summary>
        /// (Portable PDB) Document table (0x30).
        /// </summary>
        Document = 0x30,

        /// <summary>
        /// (Portable PDB) MethodDebugInformation table (0x31).
        /// </summary>
        MethodDebugInformation,

        /// <summary>
        /// (Portable PDB) LocalScope table (0x32).
        /// </summary>
        LocalScope,

        /// <summary>
        /// (Portable PDB) LocalVariable table (0x33).
        /// </summary>
        LocalVariable,

        /// <summary>
        /// (Portable PDB) LocalConstant table (0x34).
        /// </summary>
        LocalConstant,

        /// <summary>
        /// (Portable PDB) ImportScope table (0x35).
        /// </summary>
        ImportScope,

        /// <summary>
        /// (Portable PDB) StateMachineMethod table (0x36).
        /// </summary>
        StateMachineMethod,

        /// <summary>
        /// (Portable PDB) CustomDebugInformation table (0x37).
        /// </summary>
        CustomDebugInformation,
    }
}