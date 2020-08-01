using Mirai.Emitting.Metadata;

namespace Mirai.Emitting.FileFormats
{
    public readonly struct Tables
    {
        public Tables(
            MetadataTable<Module> moduleTable,
            MetadataTable<TypeRef> typeRefTable,
            MetadataTable<TypeDef> typeDefTable,
            MetadataTable<FieldPtr> fieldPtrTable,
            MetadataTable<Field> fieldTable,
            MetadataTable<MethodPtr> methodPtrTable,
            MetadataTable<MethodDef> methodTable,
            MetadataTable<ParamPtr> paramPtrTable,
            MetadataTable<Param> paramTable,
            MetadataTable<InterfaceImpl> interfaceImplTable,
            MetadataTable<MemberRef> memberRefTable,
            MetadataTable<Constant> constantTable,
            MetadataTable<CustomAttribute> customAttributeTable,
            MetadataTable<FieldMarshal> fieldMarshalTable,
            MetadataTable<DeclSecurity> declSecurityTable,
            MetadataTable<ClassLayout> classLayoutTable,
            MetadataTable<FieldLayout> fieldLayoutTable,
            MetadataTable<StandAloneSig> standAloneSigTable,
            MetadataTable<EventMap> eventMapTable,
            MetadataTable<EventPtr> eventPtrTable,
            MetadataTable<Event> eventTable,
            MetadataTable<PropertyMap> propertyMapTable,
            MetadataTable<PropertyPtr> propertyPtrTable,
            MetadataTable<Property> propertyTable,
            MetadataTable<MethodSemantics> methodSemanticsTable,
            MetadataTable<MethodImpl> methodImplTable,
            MetadataTable<ModuleRef> moduleRefTable,
            MetadataTable<TypeSpec> typeSpecTable,
            MetadataTable<ImplMap> implMapTable,
            MetadataTable<FieldRVA> fieldRvaTable,
            MetadataTable<ENCLog> encLogTable,
            MetadataTable<ENCMap> encMapTable,
            MetadataTable<Assembly> assemblyTable,
            MetadataTable<AssemblyProcessor> assemblyProcessorTable,
            MetadataTable<AssemblyOS> assemblyOsTable,
            MetadataTable<AssemblyRef> assemblyRefTable,
            MetadataTable<AssemblyRefProcessor> assemblyRefProcessorTable,
            MetadataTable<AssemblyRefOS> assemblyRefOsTable,
            MetadataTable<File> fileTable,
            MetadataTable<ExportedType> exportedTypeTable,
            MetadataTable<ManifestResource> manifestResourceTable,
            MetadataTable<NestedClass> nestedClassTable,
            MetadataTable<GenericParam> genericParamTable,
            MetadataTable<MethodSpec> methodSpecTable,
            MetadataTable<GenericParamConstraint> genericParamConstraintTable,
            MetadataTable<Document> documentTable,
            MetadataTable<MethodDebugInformation> methodDebugInformationTable,
            MetadataTable<LocalScope> localScopeTable,
            MetadataTable<LocalVariable> localVariableTable,
            MetadataTable<LocalConstant> localConstantTable,
            MetadataTable<ImportScope> importScopeTable,
            MetadataTable<StateMachineMethod> stateMachineMethodTable,
            MetadataTable<CustomDebugInformation> customDebugInformationTable)
        {
            ModuleTable = moduleTable;
            TypeRefTable = typeRefTable;
            TypeDefTable = typeDefTable;
            FieldPtrTable = fieldPtrTable;
            FieldTable = fieldTable;
            MethodPtrTable = methodPtrTable;
            MethodTable = methodTable;
            ParamPtrTable = paramPtrTable;
            ParamTable = paramTable;
            InterfaceImplTable = interfaceImplTable;
            MemberRefTable = memberRefTable;
            ConstantTable = constantTable;
            CustomAttributeTable = customAttributeTable;
            FieldMarshalTable = fieldMarshalTable;
            DeclSecurityTable = declSecurityTable;
            ClassLayoutTable = classLayoutTable;
            FieldLayoutTable = fieldLayoutTable;
            StandAloneSigTable = standAloneSigTable;
            EventMapTable = eventMapTable;
            EventPtrTable = eventPtrTable;
            EventTable = eventTable;
            PropertyMapTable = propertyMapTable;
            PropertyPtrTable = propertyPtrTable;
            PropertyTable = propertyTable;
            MethodSemanticsTable = methodSemanticsTable;
            MethodImplTable = methodImplTable;
            ModuleRefTable = moduleRefTable;
            TypeSpecTable = typeSpecTable;
            ImplMapTable = implMapTable;
            FieldRVATable = fieldRvaTable;
            ENCLogTable = encLogTable;
            ENCMapTable = encMapTable;
            AssemblyTable = assemblyTable;
            AssemblyProcessorTable = assemblyProcessorTable;
            AssemblyOSTable = assemblyOsTable;
            AssemblyRefTable = assemblyRefTable;
            AssemblyRefProcessorTable = assemblyRefProcessorTable;
            AssemblyRefOSTable = assemblyRefOsTable;
            FileTable = fileTable;
            ExportedTypeTable = exportedTypeTable;
            ManifestResourceTable = manifestResourceTable;
            NestedClassTable = nestedClassTable;
            GenericParamTable = genericParamTable;
            MethodSpecTable = methodSpecTable;
            GenericParamConstraintTable = genericParamConstraintTable;
            DocumentTable = documentTable;
            MethodDebugInformationTable = methodDebugInformationTable;
            LocalScopeTable = localScopeTable;
            LocalVariableTable = localVariableTable;
            LocalConstantTable = localConstantTable;
            ImportScopeTable = importScopeTable;
            StateMachineMethodTable = stateMachineMethodTable;
            CustomDebugInformationTable = customDebugInformationTable;
        }

        public MetadataTable<Module> ModuleTable { get; }
        public MetadataTable<TypeRef> TypeRefTable { get; }
        public MetadataTable<TypeDef> TypeDefTable { get; }
        public MetadataTable<FieldPtr> FieldPtrTable { get; }
        public MetadataTable<Field> FieldTable { get; }
        public MetadataTable<MethodPtr> MethodPtrTable { get; }
        public MetadataTable<MethodDef> MethodTable { get; }
        public MetadataTable<ParamPtr> ParamPtrTable { get; }
        public MetadataTable<Param> ParamTable { get; }
        public MetadataTable<InterfaceImpl> InterfaceImplTable { get; }
        public MetadataTable<MemberRef> MemberRefTable { get; }
        public MetadataTable<Constant> ConstantTable { get; }
        public MetadataTable<CustomAttribute> CustomAttributeTable { get; }
        public MetadataTable<FieldMarshal> FieldMarshalTable { get; }
        public MetadataTable<DeclSecurity> DeclSecurityTable { get; }
        public MetadataTable<ClassLayout> ClassLayoutTable { get; }
        public MetadataTable<FieldLayout> FieldLayoutTable { get; }
        public MetadataTable<StandAloneSig> StandAloneSigTable { get; }
        public MetadataTable<EventMap> EventMapTable { get; }
        public MetadataTable<EventPtr> EventPtrTable { get; }
        public MetadataTable<Event> EventTable { get; }
        public MetadataTable<PropertyMap> PropertyMapTable { get; }
        public MetadataTable<PropertyPtr> PropertyPtrTable { get; }
        public MetadataTable<Property> PropertyTable { get; }
        public MetadataTable<MethodSemantics> MethodSemanticsTable { get; }
        public MetadataTable<MethodImpl> MethodImplTable { get; }
        public MetadataTable<ModuleRef> ModuleRefTable { get; }
        public MetadataTable<TypeSpec> TypeSpecTable { get; }
        public MetadataTable<ImplMap> ImplMapTable { get; }
        public MetadataTable<FieldRVA> FieldRVATable { get; }
        public MetadataTable<ENCLog> ENCLogTable { get; }
        public MetadataTable<ENCMap> ENCMapTable { get; }
        public MetadataTable<Assembly> AssemblyTable { get; }
        public MetadataTable<AssemblyProcessor> AssemblyProcessorTable { get; }
        public MetadataTable<AssemblyOS> AssemblyOSTable { get; }
        public MetadataTable<AssemblyRef> AssemblyRefTable { get; }
        public MetadataTable<AssemblyRefProcessor> AssemblyRefProcessorTable { get; }
        public MetadataTable<AssemblyRefOS> AssemblyRefOSTable { get; }
        public MetadataTable<File> FileTable { get; }
        public MetadataTable<ExportedType> ExportedTypeTable { get; }
        public MetadataTable<ManifestResource> ManifestResourceTable { get; }
        public MetadataTable<NestedClass> NestedClassTable { get; }
        public MetadataTable<GenericParam> GenericParamTable { get; }
        public MetadataTable<MethodSpec> MethodSpecTable { get; }
        public MetadataTable<GenericParamConstraint> GenericParamConstraintTable { get; }
        public MetadataTable<Document> DocumentTable { get; }
        public MetadataTable<MethodDebugInformation> MethodDebugInformationTable { get; }
        public MetadataTable<LocalScope> LocalScopeTable { get; }
        public MetadataTable<LocalVariable> LocalVariableTable { get; }
        public MetadataTable<LocalConstant> LocalConstantTable { get; }
        public MetadataTable<ImportScope> ImportScopeTable { get; }
        public MetadataTable<StateMachineMethod> StateMachineMethodTable { get; }
        public MetadataTable<CustomDebugInformation> CustomDebugInformationTable { get; }
    }
}