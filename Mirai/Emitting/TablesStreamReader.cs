using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Mirai.Emitting.FileFormats;
using Mirai.Emitting.Metadata;
using Mirai.Emitting.Metadata.CodedIndexes;
using File = Mirai.Emitting.Metadata.File;
using FileAttributes = Mirai.Emitting.Metadata.FileAttributes;

namespace Mirai.Emitting
{
    public struct TablesStreamReader
    {
        private const int TablesCount = sizeof(ulong) * 8;

        private readonly BinaryReader reader;
        private readonly MetadataRoot metadataRoot;
        private readonly StreamHeader streamHeader;
        private readonly StringsStreamReader stringsReader;
        private readonly GuidStreamReader guidReader;
        private readonly BlobStreamReader blobReader;

        private bool isBigString;
        private bool isBigGuid;
        private bool isBigBlob;

        public TablesStreamReader(
            BinaryReader reader,
            MetadataRoot metadataRoot,
            StringsStreamReader stringsReader,
            GuidStreamReader guidReader,
            BlobStreamReader blobReader)
        {
            this.reader = reader;
            this.metadataRoot = metadataRoot;
            this.streamHeader = metadataRoot.StreamHeaders.First(x => x.Name == StreamHeader.TablesName);
            this.stringsReader = stringsReader;
            this.guidReader = guidReader;
            this.blobReader = blobReader;

            this.isBigString = false;
            this.isBigGuid = false;
            this.isBigBlob = false;
        }

        public TablesHeap GetTablesStream()
        {
            var metadataRootOffset = metadataRoot.FileOffset;
            var offset = metadataRootOffset.Offset + streamHeader.Offset;
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);

            var heap = GetTablesHeap();

            return heap;
        }

        private TablesHeap GetTablesHeap()
        {
            var reserved1 = reader.ReadUInt32();
            Debug.Assert(reserved1 == 0, "Should be 0.");

            var majorVersion = reader.ReadByte();
            var minorVersion = reader.ReadByte();
            var heapSizes = (HeapSizeFlags) reader.ReadByte();

            this.isBigString = heapSizes.HasFlag(HeapSizeFlags.BigString);
            this.isBigGuid = heapSizes.HasFlag(HeapSizeFlags.BigGuid);
            this.isBigBlob = heapSizes.HasFlag(HeapSizeFlags.BigBlob);

            var reserved2 = reader.ReadByte();
            // Debug.Assert(reserved2 == 1, "Should be 1.");

            var valid = reader.ReadUInt64();
            var sorted = reader.ReadUInt64();

            var rows = GetTableRows(valid);
            var tables = GetTables(rows);

            return new TablesHeap(
                streamHeader,
                majorVersion,
                minorVersion,
                heapSizes,
                valid,
                sorted,
                rows,
                tables);
        }

        private TableSizes GetTableRows(ulong valid)
        {
            var rows = new uint[TablesCount];

            for (var i = 0; i < TablesCount; valid >>= 1, i++)
                if ((valid & 1) == 1)
                    rows[i] = reader.ReadUInt32();

            return new TableSizes(rows.ToImmutableArray());
        }

        private Tables GetTables(TableSizes rows)
        {
            var moduleTable = GetModule(rows);
            var typeRefTable = GetTypeRef(rows);
            var typeDefTable = GetTypeDef(rows);
            var fieldPtrTable = GetFieldPtr(rows);
            var fieldTable = GetField(rows);
            var methodPtrTable = GetMethodPtr(rows);
            var methodTable = GetMethod(rows);
            var paramPtrTable = GetParamPtr(rows);
            var paramTable = GetParam(rows);
            var interfaceImplTable = GetInterfaceImpl(rows);
            var memberRefTable = GetMemberRef(rows);
            var constantTable = GetConstant(rows);
            var customAttributeTable = GetCustomAttribute(rows);
            var fieldMarshalTable = GetFieldMarshal(rows);
            var declSecurityTable = GetDeclSecurity(rows);
            var classLayoutTable = GetClassLayout(rows);
            var fieldLayoutTable = GetFieldLayout(rows);
            var standAloneSigTable = GetStandAloneSig(rows);
            var eventMapTable = GetEventMap(rows);
            var eventPtrTable = GetEventPtr(rows);
            var eventTable = GetEvent(rows);
            var propertyMapTable = GetPropertyMap(rows);
            var propertyPtrTable = GetPropertyPtr(rows);
            var propertyTable = GetProperty(rows);
            var methodSemanticsTable = GetMethodSemantics(rows);
            var methodImplTable = GetMethodImpl(rows);
            var moduleRefTable = GetModuleRef(rows);
            var typeSpecTable = GetTypeSpec(rows);
            var implMapTable = GetImplMap(rows);
            var fieldRvaTable = GetFieldRVA(rows);
            var encLogTable = GetENCLog(rows);
            var encMapTable = GetENCMap(rows);
            var assemblyTable = GetAssembly(rows);
            var assemblyProcessorTable = GetAssemblyProcessor(rows);
            var assemblyOsTable = GetAssemblyOS(rows);
            var assemblyRefTable = GetAssemblyRef(rows);
            var assemblyRefProcessorTable = GetAssemblyRefProcessor(rows);
            var assemblyRefOsTable = GetAssemblyRefOS(rows);
            var fileTable = GetFile(rows);
            var exportedTypeTable = GetExportedType(rows);
            var manifestResourceTable = GetManifestResource(rows);
            var nestedClassTable = GetNestedClass(rows);
            var genericParamTable = GetGenericParam(rows);
            var methodSpecTable = GetMethodSpec(rows);
            var genericParamConstraintTable = GetGenericParamConstraint(rows);
            var documentTable = GetDocument(rows);
            var methodDebugInformationTable = GetMethodDebugInformation(rows);
            var localScopeTable = GetLocalScope(rows);
            var localVariableTable = GetLocalVariable(rows);
            var localConstantTable = GetLocalConstant(rows);
            var importScopeTable = GetImportScope(rows);
            var stateMachineMethodTable = GetStateMachineMethod(rows);
            var customDebugInformationTable = GetCustomDebugInformation(rows);

            return new Tables(
                moduleTable,
                typeRefTable,
                typeDefTable,
                fieldPtrTable,
                fieldTable,
                methodPtrTable,
                methodTable,
                paramPtrTable,
                paramTable,
                interfaceImplTable,
                memberRefTable,
                constantTable,
                customAttributeTable,
                fieldMarshalTable,
                declSecurityTable,
                classLayoutTable,
                fieldLayoutTable,
                standAloneSigTable,
                eventMapTable,
                eventPtrTable,
                eventTable,
                propertyMapTable,
                propertyPtrTable,
                propertyTable,
                methodSemanticsTable,
                methodImplTable,
                moduleRefTable,
                typeSpecTable,
                implMapTable,
                fieldRvaTable,
                encLogTable,
                encMapTable,
                assemblyTable,
                assemblyProcessorTable,
                assemblyOsTable,
                assemblyRefTable,
                assemblyRefProcessorTable,
                assemblyRefOsTable,
                fileTable,
                exportedTypeTable,
                manifestResourceTable,
                nestedClassTable,
                genericParamTable,
                methodSpecTable,
                genericParamConstraintTable,
                documentTable,
                methodDebugInformationTable,
                localScopeTable,
                localVariableTable,
                localConstantTable,
                importScopeTable,
                stateMachineMethodTable,
                customDebugInformationTable);
        }

        private MetadataTable<Module> GetModule(TableSizes tableSizes)
        {
            var moduleSize = tableSizes[TableType.Module];
            var modules = new Module[moduleSize];

            for (var recordIndex = 0U; recordIndex < moduleSize; recordIndex++)
            {
                var generation = reader.ReadUInt16();
                Debug.Assert(generation == 0, "Should be 0.");

                var nameIndex = ReadStringIndex();
                var mvidIndex = ReadGuidIndex();

                var encId = ReadGuidIndex();
                Debug.Assert(encId == 0, "Should be 0.");

                var encBaseId = ReadGuidIndex();
                Debug.Assert(encBaseId == 0, "Should be 0.");

                var name = stringsReader.ReadString(nameIndex);
                var mvid = guidReader.ReadGuid(mvidIndex);

                modules[recordIndex] = new Module(
                    recordIndex + 1,
                    generation,
                    new MetadataString(nameIndex, name), // TODO:
                    new MetadataGuid(mvidIndex, mvid),
                    encId,
                    encBaseId);
            }

            return new MetadataTable<Module>(modules);
        }

        private MetadataTable<TypeRef> GetTypeRef(TableSizes tableSizes)
        {
            var typeRefSize = tableSizes[TableType.TypeRef];
            var resolutionScopeSize = tableSizes.ForCodedIndex(Indexes.ResolutionScope);

            var typeRefs = new TypeRef[typeRefSize];

            for (var recordIndex = 0U; recordIndex < typeRefSize; recordIndex++)
            {
                var resolutionScope = Indexes.ResolutionScope.Create(ReadIndex(resolutionScopeSize));
                var typeNameIndex = ReadStringIndex();
                var typeNamespaceIndex = ReadStringIndex();

                var typeName = stringsReader.ReadString(typeNameIndex);
                // TODO: nullable
                var typeNamespace = stringsReader.ReadString(typeNamespaceIndex);

                typeRefs[recordIndex] = new TypeRef(
                    recordIndex + 1,
                    resolutionScope,
                    new MetadataString(typeNameIndex, typeName),
                    new MetadataString(typeNamespaceIndex, typeNamespace));
            }

            return new MetadataTable<TypeRef>(typeRefs);
        }

        private MetadataTable<TypeDef> GetTypeDef(TableSizes tableSizes)
        {
            var typeDefSize = tableSizes[TableType.TypeDef];
            var extendsSize = tableSizes.ForCodedIndex(Indexes.TypeDefOrRef);
            var fieldListSize = tableSizes.GetIndexSize(TableType.Field);
            var methodListSize = tableSizes.GetIndexSize(TableType.Method);

            var typeDefs = new TypeDef[typeDefSize];

            for (var recordIndex = 0U; recordIndex < typeDefSize; recordIndex++)
            {
                var flags = ReadEnum4<TypeAttributes>();
                if (flags.HasFlag(TypeAttributes.HasSecurity))
                {
                    // TODO:
                }

                var typeNameIndex = ReadStringIndex();
                if (typeNameIndex == 0)
                    throw new Exception();

                var typeNamespaceIndex = ReadStringIndex();
                var extends = Indexes.TypeDefOrRef.Create(ReadIndex(extendsSize));
                var fieldList = ReadIndex(fieldListSize);
                var methodList = ReadIndex(methodListSize);

                var typeName = stringsReader.ReadString(typeNameIndex);
                // TODO: nullable
                var typeNamespace = stringsReader.ReadString(typeNamespaceIndex);

                typeDefs[recordIndex] = new TypeDef(
                    recordIndex + 1,
                    flags,
                    new MetadataString(typeNameIndex, typeName),
                    new MetadataString(typeNamespaceIndex, typeNamespace),
                    extends,
                    fieldList,
                    methodList);
            }

            return new MetadataTable<TypeDef>(typeDefs);
        }

        private MetadataTable<FieldPtr> GetFieldPtr(TableSizes tableSizes)
        {
            var fieldPtrSize = tableSizes[TableType.FieldPtr];
            var indexSize = tableSizes.GetIndexSize(TableType.Field);

            var fieldPtrs = new FieldPtr[fieldPtrSize];

            for (var recordIndex = 0U; recordIndex < fieldPtrSize; recordIndex++)
            {
                var field = ReadIndex(indexSize);

                fieldPtrs[recordIndex] = new FieldPtr(
                    recordIndex + 1,
                    field);
            }

            return new MetadataTable<FieldPtr>(fieldPtrs);
        }

        private MetadataTable<Field> GetField(TableSizes tableSizes)
        {
            var fieldSize = tableSizes[TableType.Field];

            var fields = new Field[fieldSize];

            for (var recordIndex = 0U; recordIndex < fieldSize; recordIndex++)
            {
                var flags = ReadEnum2<FieldAttributes>();

                var access = flags & FieldAttributes.FieldAccessMask;
                // TODO: validate access

                if (flags.HasFlag(FieldAttributes.Literal | FieldAttributes.InitOnly))
                    throw new Exception();

                if (flags.HasFlag(FieldAttributes.Literal) && !flags.HasFlag(FieldAttributes.Static))
                    throw new Exception();

                if (flags.HasFlag(FieldAttributes.RTSpecialName) &&
                    !flags.HasFlag(FieldAttributes.SpecialName))
                    throw new Exception();

                var nameIndex = ReadStringIndex();
                if (nameIndex == 0)
                    throw new Exception();

                var signatureIndex = ReadBlobIndex();
                if (signatureIndex == 0)
                    throw new Exception();

                var name = stringsReader.ReadString(nameIndex);
                var signatureArray = blobReader.ReadBlob(signatureIndex);
                var signature = new SignatureReader(signatureArray)
                    .ReadSignature();

                fields[recordIndex] = new Field(
                    recordIndex + 1,
                    flags,
                    new MetadataString(nameIndex, name),
                    new MetadataSignature(signatureIndex, signature));
            }

            return new MetadataTable<Field>(fields);
        }

        private MetadataTable<MethodPtr> GetMethodPtr(TableSizes tableSizes)
        {
            var methodPtrSize = tableSizes[TableType.MethodPtr];
            var indexSize = tableSizes.GetIndexSize(TableType.Method);

            var methodPtrs = new MethodPtr[methodPtrSize];

            for (var recordIndex = 0U; recordIndex < methodPtrSize; recordIndex++)
            {
                var method = ReadIndex(indexSize);

                methodPtrs[recordIndex] = new MethodPtr(
                    recordIndex + 1,
                    method);
            }

            return new MetadataTable<MethodPtr>(methodPtrs);
        }

        private MetadataTable<MethodDef> GetMethod(TableSizes tableSizes)
        {
            var methodSize = tableSizes[TableType.Method];
            var paramSize = tableSizes.GetIndexSize(TableType.Param);

            var methods = new MethodDef[methodSize];

            for (var recordIndex = 0U; recordIndex < methodSize; recordIndex++)
            {
                var rva = reader.ReadUInt32();
                var implFlags = ReadEnum2<MethodImplAttributes>();
                var flags = ReadEnum2<MethodAttributes>();
                var nameIndex = ReadStringIndex();
                var signatureIndex = ReadBlobIndex();
                var paramList = ReadIndex(paramSize);

                var name = stringsReader.ReadString(nameIndex);
                var signatureArray = blobReader.ReadBlob(signatureIndex);
                var signature = new SignatureReader(signatureArray)
                    .ReadSignature();

                methods[recordIndex] = new MethodDef(
                    recordIndex + 1,
                    rva,
                    implFlags,
                    flags,
                    new MetadataString(nameIndex, name),
                    new MetadataSignature(signatureIndex, signature),
                    paramList);
            }

            return new MetadataTable<MethodDef>(methods);
        }

        private MetadataTable<ParamPtr> GetParamPtr(TableSizes tableSizes)
        {
            var paramPtrSize = tableSizes[TableType.ParamPtr];
            var indexSize = tableSizes.GetIndexSize(TableType.Param);

            var paramPtrs = new ParamPtr[paramPtrSize];

            for (var recordIndex = 0U; recordIndex < paramPtrSize; recordIndex++)
            {
                var method = ReadIndex(indexSize);

                paramPtrs[recordIndex] = new ParamPtr(
                    recordIndex + 1,
                    method);
            }

            return new MetadataTable<ParamPtr>(paramPtrs);
        }

        private MetadataTable<Param> GetParam(TableSizes tableSizes)
        {
            var paramSize = tableSizes[TableType.Param];

            var @params = new Param[paramSize];

            for (var recordIndex = 0U; recordIndex < paramSize; recordIndex++)
            {
                var flags = ReadEnum2<ParamAttributes>();
                var sequence = reader.ReadUInt16();
                var nameIndex = ReadStringIndex();

                var name = stringsReader.ReadString(nameIndex);

                @params[recordIndex] = new Param(
                    recordIndex + 1,
                    flags,
                    sequence,
                    new MetadataString(nameIndex, name));
            }

            return new MetadataTable<Param>(@params);
        }

        private MetadataTable<InterfaceImpl> GetInterfaceImpl(TableSizes tableSizes)
        {
            var interfaceImplSize = tableSizes[TableType.InterfaceImpl];
            var typeDefSize = tableSizes.GetIndexSize(TableType.TypeDef);
            var interfaceSize = tableSizes.ForCodedIndex(Indexes.TypeDefOrRef);

            var impls = new InterfaceImpl[interfaceImplSize];

            for (var recordIndex = 0U; recordIndex < interfaceImplSize; recordIndex++)
            {
                var @class = ReadIndex(typeDefSize);
                var @interface = Indexes.TypeDefOrRef.Create(ReadIndex(interfaceSize));

                impls[recordIndex] = new InterfaceImpl(
                    recordIndex + 1,
                    @class,
                    @interface);
            }

            return new MetadataTable<InterfaceImpl>(impls);
        }

        private MetadataTable<MemberRef> GetMemberRef(TableSizes tableSizes)
        {
            var memberRefSize = tableSizes[TableType.MemberRef];
            var classSize = tableSizes.ForCodedIndex(Indexes.MemberRefParent);

            var memberRefs = new MemberRef[memberRefSize];

            for (var recordIndex = 0U; recordIndex < memberRefSize; recordIndex++)
            {
                var @class = Indexes.MemberRefParent.Create(ReadIndex(classSize));
                var nameIndex = ReadStringIndex();
                var signatureIndex = ReadBlobIndex();

                var name = stringsReader.ReadString(nameIndex);
                var signatureArray = blobReader.ReadBlob(signatureIndex);
                var signature = new SignatureReader(signatureArray)
                    .ReadSignature();

                memberRefs[recordIndex] = new MemberRef(
                    recordIndex + 1,
                    @class,
                    new MetadataString(nameIndex, name),
                    new MetadataSignature(signatureIndex, signature));
            }

            return new MetadataTable<MemberRef>(memberRefs);
        }

        private MetadataTable<Constant> GetConstant(TableSizes tableSizes)
        {
            var constantSize = tableSizes[TableType.Constant];
            var valueSize = tableSizes.ForCodedIndex(Indexes.HasConstant);

            var constants = new Constant[constantSize];

            for (var recordIndex = 0U; recordIndex < constantSize; recordIndex++)
            {
                var type = ReadEnum1<ElementType>();

                // padding
                reader.ReadByte();

                var parent = Indexes.HasConstant.Create(ReadIndex(valueSize));
                var valueIndex = ReadBlobIndex();

                var value = blobReader.ReadBlob(valueIndex);

                constants[recordIndex] = new Constant(
                    recordIndex + 1,
                    type,
                    parent,
                    new MetadataBlob(valueIndex, value));
            }

            return new MetadataTable<Constant>(constants);
        }

        private MetadataTable<CustomAttribute> GetCustomAttribute(TableSizes tableSizes)
        {
            var customAttributeSize = tableSizes[TableType.CustomAttribute];
            var parentSize = tableSizes.ForCodedIndex(Indexes.HasCustomAttribute);
            var typeSize = tableSizes.ForCodedIndex(Indexes.CustomAttributeType);

            var customAttributes = new CustomAttribute[customAttributeSize];

            for (var recordIndex = 0U; recordIndex < customAttributeSize; recordIndex++)
            {
                var parent = Indexes.HasCustomAttribute.Create(ReadIndex(parentSize));
                var type = Indexes.CustomAttributeType.Create(ReadIndex(typeSize));
                var valueIndex = ReadBlobIndex();

                var value = blobReader.ReadBlob(valueIndex);

                customAttributes[recordIndex] = new CustomAttribute(
                    recordIndex + 1,
                    parent,
                    type,
                    new MetadataBlob(valueIndex, value));
            }

            return new MetadataTable<CustomAttribute>(customAttributes);
        }

        private MetadataTable<FieldMarshal> GetFieldMarshal(TableSizes tableSizes)
        {
            var fieldMarshalSize = tableSizes[TableType.FieldMarshal];
            var parentSize = tableSizes.ForCodedIndex(Indexes.HasFieldMarshall);

            var fieldMarshals = new FieldMarshal[fieldMarshalSize];

            for (var recordIndex = 0U; recordIndex < fieldMarshalSize; recordIndex++)
            {
                var parent = Indexes.HasFieldMarshall.Create(ReadIndex(parentSize));
                var nativeTypeIndex = ReadBlobIndex();

                var nativeType = blobReader.ReadBlob(nativeTypeIndex);

                fieldMarshals[recordIndex] = new FieldMarshal(
                    recordIndex + 1,
                    parent,
                    new MetadataBlob(nativeTypeIndex, nativeType));
            }

            return new MetadataTable<FieldMarshal>(fieldMarshals);
        }

        private MetadataTable<DeclSecurity> GetDeclSecurity(TableSizes tableSizes)
        {
            var declSecuritySize = tableSizes[TableType.DeclSecurity];
            var parentSize = tableSizes.ForCodedIndex(Indexes.HasDeclSecurity);

            var declSecurities = new DeclSecurity[declSecuritySize];

            for (var recordIndex = 0U; recordIndex < declSecuritySize; recordIndex++)
            {
                var action = reader.ReadUInt16();
                var parent = Indexes.HasDeclSecurity.Create(ReadIndex(parentSize));
                var permissionSetIndex = ReadBlobIndex();

                var permissionSet = blobReader.ReadBlob(permissionSetIndex);

                declSecurities[recordIndex] = new DeclSecurity(
                    recordIndex + 1,
                    action,
                    parent,
                    new MetadataBlob(permissionSetIndex, permissionSet));
            }

            return new MetadataTable<DeclSecurity>(declSecurities);
        }

        private MetadataTable<ClassLayout> GetClassLayout(TableSizes tableSizes)
        {
            var classLayoutSize = tableSizes[TableType.ClassLayout];
            var parentSize = tableSizes.GetIndexSize(TableType.TypeDef);

            var classLayouts = new ClassLayout[classLayoutSize];

            for (var recordIndex = 0U; recordIndex < classLayoutSize; recordIndex++)
            {
                var packingSize = reader.ReadUInt16();
                var classSize = reader.ReadUInt32();
                var parent = ReadIndex(parentSize);

                classLayouts[recordIndex] = new ClassLayout(
                    recordIndex + 1,
                    packingSize,
                    classSize,
                    parent);
            }

            return new MetadataTable<ClassLayout>(classLayouts);
        }

        private MetadataTable<FieldLayout> GetFieldLayout(TableSizes tableSizes)
        {
            var fieldLayoutSize = tableSizes[TableType.FieldLayout];
            var fieldSize = tableSizes.GetIndexSize(TableType.Field);

            var fieldLayouts = new FieldLayout[fieldLayoutSize];

            for (var recordIndex = 0U; recordIndex < fieldLayoutSize; recordIndex++)
            {
                var offset = reader.ReadUInt32();
                var field = ReadIndex(fieldSize);

                fieldLayouts[recordIndex] = new FieldLayout(
                    recordIndex + 1,
                    offset,
                    field);
            }

            return new MetadataTable<FieldLayout>(fieldLayouts);
        }

        private MetadataTable<StandAloneSig> GetStandAloneSig(TableSizes tableSizes)
        {
            var standAlongSigSize = tableSizes[TableType.StandAloneSig];

            var standAloneSigs = new StandAloneSig[standAlongSigSize];

            for (var recordIndex = 0U; recordIndex < standAlongSigSize; recordIndex++)
            {
                var signatureIndex = ReadBlobIndex();
                var signatureArray = blobReader.ReadBlob(signatureIndex);
                var signature = new SignatureReader(signatureArray)
                    .ReadSignature();

                standAloneSigs[recordIndex] = new StandAloneSig(
                    recordIndex + 1,
                    new MetadataSignature(signatureIndex, signature));
            }

            return new MetadataTable<StandAloneSig>(standAloneSigs);
        }

        private MetadataTable<EventMap> GetEventMap(TableSizes tableSizes)
        {
            var eventMapSize = tableSizes[TableType.EventMap];
            var parentSize = tableSizes.GetIndexSize(TableType.TypeDef);
            var eventListSize = tableSizes.GetIndexSize(TableType.Event);

            var eventMaps = new EventMap[eventMapSize];

            for (var recordIndex = 0U; recordIndex < eventMapSize; recordIndex++)
            {
                var parent = ReadIndex(parentSize);
                var eventList = ReadIndex(eventListSize);

                eventMaps[recordIndex] = new EventMap(
                    recordIndex + 1,
                    parent,
                    eventList);
            }

            return new MetadataTable<EventMap>(eventMaps);
        }

        private MetadataTable<EventPtr> GetEventPtr(TableSizes tableSizes)
        {
            var eventPtrSize = tableSizes[TableType.EventPtr];
            var eventSize = tableSizes.GetIndexSize(TableType.Event);

            var eventPtrs = new EventPtr[eventPtrSize];

            for (var recordIndex = 0U; recordIndex < eventPtrSize; recordIndex++)
            {
                var @event = ReadIndex(eventSize);

                eventPtrs[recordIndex] = new EventPtr(
                    recordIndex + 1,
                    @event);
            }

            return new MetadataTable<EventPtr>(eventPtrs);
        }

        private MetadataTable<Event> GetEvent(TableSizes tableSizes)
        {
            var eventSize = tableSizes[TableType.Event];
            var eventTypeSize = tableSizes.ForCodedIndex(Indexes.TypeDefOrRef);

            var events = new Event[eventSize];

            for (var recordIndex = 0U; recordIndex < eventSize; recordIndex++)
            {
                var eventFlags = ReadEnum2<EventAttributes>();
                var nameIndex = ReadStringIndex();
                var eventType = Indexes.TypeDefOrRef.Create(ReadIndex(eventTypeSize));

                var name = stringsReader.ReadString(nameIndex);

                events[recordIndex] = new Event(
                    recordIndex + 1,
                    eventFlags,
                    new MetadataString(nameIndex, name),
                    eventType);
            }

            return new MetadataTable<Event>(events);
        }

        private MetadataTable<PropertyMap> GetPropertyMap(TableSizes tableSizes)
        {
            var propertyMapSize = tableSizes[TableType.PropertyMap];
            var parentSize = tableSizes.GetIndexSize(TableType.TypeDef);
            var propertyListSize = tableSizes.GetIndexSize(TableType.Property);

            var propertyMaps = new PropertyMap[propertyMapSize];

            for (var recordIndex = 0U; recordIndex < propertyMapSize; recordIndex++)
            {
                var parent = ReadIndex(parentSize);
                var propertyList = ReadIndex(propertyListSize);

                propertyMaps[recordIndex] = new PropertyMap(
                    recordIndex + 1,
                    parent,
                    propertyList);
            }

            return new MetadataTable<PropertyMap>(propertyMaps);
        }

        private MetadataTable<PropertyPtr> GetPropertyPtr(TableSizes tableSizes)
        {
            var propertyPtrSize = tableSizes[TableType.PropertyPtr];
            var propertySize = tableSizes.GetIndexSize(TableType.Property);

            var propertyPtrs = new PropertyPtr[propertyPtrSize];

            for (var recordIndex = 0U; recordIndex < propertyPtrSize; recordIndex++)
            {
                var property = ReadIndex(propertySize);

                propertyPtrs[recordIndex] = new PropertyPtr(
                    recordIndex + 1,
                    property);
            }

            return new MetadataTable<PropertyPtr>(propertyPtrs);
        }

        private MetadataTable<Property> GetProperty(TableSizes tableSizes)
        {
            var propertySize = tableSizes[TableType.Property];

            var properties = new Property[propertySize];

            for (var recordIndex = 0U; recordIndex < propertySize; recordIndex++)
            {
                var flags = ReadEnum2<PropertyAttributes>();
                var nameIndex = ReadStringIndex();
                var typeIndex = ReadBlobIndex();

                var name = stringsReader.ReadString(nameIndex);
                var type = blobReader.ReadBlob(typeIndex);

                properties[recordIndex] = new Property(
                    recordIndex + 1,
                    flags,
                    new MetadataString(nameIndex, name),
                    new MetadataBlob(typeIndex, type));
            }

            return new MetadataTable<Property>(properties);
        }

        private MetadataTable<MethodSemantics> GetMethodSemantics(TableSizes tableSizes)
        {
            var methodSemanticsSize = tableSizes[TableType.MethodSemantics];
            var methodSize = tableSizes.GetIndexSize(TableType.Method);
            var associationSize = tableSizes.ForCodedIndex(Indexes.HasSemantics);

            var methodSemanticses = new MethodSemantics[methodSemanticsSize];

            for (var recordIndex = 0U; recordIndex < methodSemanticsSize; recordIndex++)
            {
                var semantics = ReadEnum2<MethodSemanticsAttributes>();
                var method = ReadIndex(methodSize);
                var association = Indexes.HasSemantics.Create(ReadIndex(associationSize));

                methodSemanticses[recordIndex] = new MethodSemantics(
                    recordIndex + 1,
                    semantics,
                    method,
                    association);
            }

            return new MetadataTable<MethodSemantics>(methodSemanticses);
        }

        private MetadataTable<MethodImpl> GetMethodImpl(TableSizes tableSizes)
        {
            var methodImplSize = tableSizes[TableType.MethodImpl];
            var typeDefSize = tableSizes.GetIndexSize(TableType.TypeDef);
            var methodSize = tableSizes.ForCodedIndex(Indexes.MethodDefOrRef);

            var methodImpls = new MethodImpl[methodImplSize];

            for (var recordIndex = 0U; recordIndex < methodImplSize; recordIndex++)
            {
                var @class = ReadIndex(typeDefSize);
                var methodBody = Indexes.MethodDefOrRef.Create(ReadIndex(methodSize));
                var methodDeclaration = Indexes.MethodDefOrRef.Create(ReadIndex(methodSize));

                methodImpls[recordIndex] = new MethodImpl(
                    recordIndex + 1,
                    @class,
                    methodBody,
                    methodDeclaration);
            }

            return new MetadataTable<MethodImpl>(methodImpls);
        }

        private MetadataTable<ModuleRef> GetModuleRef(TableSizes tableSizes)
        {
            var moduleRefSize = tableSizes[TableType.ModuleRef];

            var moduleRefs = new ModuleRef[moduleRefSize];

            for (var recordIndex = 0U; recordIndex < moduleRefSize; recordIndex++)
            {
                var nameIndex = ReadStringIndex();
                var name = stringsReader.ReadString(nameIndex);

                moduleRefs[recordIndex] = new ModuleRef(
                    recordIndex + 1,
                    new MetadataString(nameIndex, name));
            }

            return new MetadataTable<ModuleRef>(moduleRefs);
        }

        private MetadataTable<TypeSpec> GetTypeSpec(TableSizes tableSizes)
        {
            var typeSpecSize = tableSizes[TableType.TypeSpec];

            var moduleRefs = new TypeSpec[typeSpecSize];

            for (var recordIndex = 0U; recordIndex < typeSpecSize; recordIndex++)
            {
                var signatureIndex = ReadBlobIndex();
                var signatureArray = blobReader.ReadBlob(signatureIndex);
                var signature = new SignatureReader(signatureArray)
                    .ReadType();

                moduleRefs[recordIndex] = new TypeSpec(
                    recordIndex + 1,
                    new MetadataTypeSpec(signatureIndex, signature));
            }

            return new MetadataTable<TypeSpec>(moduleRefs);
        }

        private MetadataTable<ImplMap> GetImplMap(TableSizes tableSizes)
        {
            var implMapSize = tableSizes[TableType.ImplMap];
            var memberSize = tableSizes.ForCodedIndex(Indexes.MemberForwarded);
            var moduleRefSize = tableSizes.GetIndexSize(TableType.ModuleRef);

            var implMaps = new ImplMap[implMapSize];

            for (var recordIndex = 0U; recordIndex < implMapSize; recordIndex++)
            {
                var mappingFlags = ReadEnum2<PInvokeAttributes>();
                var memberForwarded = Indexes.MemberForwarded.Create(ReadIndex(memberSize));
                var importNameIndex = ReadStringIndex();
                var importScope = ReadIndex(moduleRefSize);

                var importName = stringsReader.ReadString(importNameIndex);

                implMaps[recordIndex] = new ImplMap(
                    recordIndex + 1,
                    mappingFlags,
                    memberForwarded,
                    new MetadataString(importNameIndex, importName),
                    importScope);
            }

            return new MetadataTable<ImplMap>(implMaps);
        }

        private MetadataTable<FieldRVA> GetFieldRVA(TableSizes tableSizes)
        {
            var fieldRvaSize = tableSizes[TableType.FieldRVA];
            var fieldSize = tableSizes.GetIndexSize(TableType.Field);

            var fieldRvas = new FieldRVA[fieldRvaSize];

            for (var recordIndex = 0U; recordIndex < fieldRvaSize; recordIndex++)
            {
                uint rva = reader.ReadUInt32();
                uint field = ReadIndex(fieldSize);

                fieldRvas[recordIndex] = new FieldRVA(
                    recordIndex + 1,
                    rva,
                    field);
            }

            return new MetadataTable<FieldRVA>(fieldRvas);
        }

        private MetadataTable<ENCLog> GetENCLog(TableSizes tableSizes)
        {
            var encLogSize = tableSizes[TableType.ENCLog];

            var encLogs = new ENCLog[encLogSize];

            for (var recordIndex = 0U; recordIndex < encLogSize; recordIndex++)
            {
                var token = reader.ReadUInt32();
                var funcCode = reader.ReadUInt32();

                encLogs[recordIndex] = new ENCLog(
                    recordIndex + 1,
                    token,
                    funcCode);
            }

            return new MetadataTable<ENCLog>(encLogs);
        }

        private MetadataTable<ENCMap> GetENCMap(TableSizes tableSizes)
        {
            var encMapSize = tableSizes[TableType.ENCMap];

            var encMaps = new ENCMap[encMapSize];

            for (var recordIndex = 0U; recordIndex < encMapSize; recordIndex++)
            {
                var token = reader.ReadUInt32();

                encMaps[recordIndex] = new ENCMap(
                    recordIndex + 1,
                    token);
            }

            return new MetadataTable<ENCMap>(encMaps);
        }

        private MetadataTable<Assembly> GetAssembly(TableSizes tableSizes)
        {
            var assemblySize = tableSizes[TableType.Assembly];

            var assemblies = new Assembly[assemblySize];

            for (var recordIndex = 0U; recordIndex < assemblySize; recordIndex++)
            {
                var hashAlgId = ReadEnum4<AssemblyHashAlgorithm>();
                var version = new AssemblyVersion(
                    reader.ReadUInt16(),
                    reader.ReadUInt16(),
                    reader.ReadUInt16(),
                    reader.ReadUInt16());
                var flags = ReadEnum4<AssemblyFlags>();
                var publicKeyIndex = ReadBlobIndex();
                var nameIndex = ReadStringIndex();
                var cultureIndex = ReadStringIndex();

                var publicKey = blobReader.ReadBlob(publicKeyIndex);
                var name = stringsReader.ReadString(nameIndex);
                var culture = stringsReader.ReadString(cultureIndex);

                assemblies[recordIndex] = new Assembly(
                    recordIndex + 1,
                    hashAlgId,
                    version,
                    flags,
                    new MetadataBlob(publicKeyIndex, publicKey),
                    new MetadataString(nameIndex, name),
                    new MetadataString(cultureIndex, culture));
            }

            return new MetadataTable<Assembly>(assemblies);
        }

        private MetadataTable<AssemblyProcessor> GetAssemblyProcessor(TableSizes tableSizes)
        {
            var assemblyProcessorSize = tableSizes[TableType.AssemblyProcessor];

            var assemblyProcessors = new AssemblyProcessor[assemblyProcessorSize];

            for (var recordIndex = 0U; recordIndex < assemblyProcessorSize; recordIndex++)
            {
                var processor = reader.ReadUInt32();

                assemblyProcessors[recordIndex] = new AssemblyProcessor(
                    recordIndex + 1,
                    processor);
            }

            return new MetadataTable<AssemblyProcessor>(assemblyProcessors);
        }

        private MetadataTable<AssemblyOS> GetAssemblyOS(TableSizes tableSizes)
        {
            var assemblyOSSize = tableSizes[TableType.AssemblyOS];

            var assemblyOSes = new AssemblyOS[assemblyOSSize];

            for (var recordIndex = 0U; recordIndex < assemblyOSSize; recordIndex++)
            {
                var osPlatformId = reader.ReadUInt32();
                var osMajorVersion = reader.ReadUInt32();
                var osMinorVersion = reader.ReadUInt32();

                assemblyOSes[recordIndex] = new AssemblyOS(
                    recordIndex + 1,
                    osPlatformId,
                    osMajorVersion,
                    osMinorVersion);
            }

            return new MetadataTable<AssemblyOS>(assemblyOSes);
        }

        private MetadataTable<AssemblyRef> GetAssemblyRef(TableSizes tableSizes)
        {
            var assemblyRefSize = tableSizes[TableType.AssemblyRef];

            var assemblyRefs = new AssemblyRef[assemblyRefSize];

            for (var recordIndex = 0U; recordIndex < assemblyRefSize; recordIndex++)
            {
                var version = new AssemblyVersion(
                    reader.ReadUInt16(),
                    reader.ReadUInt16(),
                    reader.ReadUInt16(),
                    reader.ReadUInt16());
                var flags = ReadEnum4<AssemblyFlags>();
                var publicKeyOrTokenIndex = ReadBlobIndex();
                var nameIndex = ReadStringIndex();
                var cultureIndex = ReadStringIndex();
                var hashValueIndex = ReadBlobIndex();

                var publicKeyOrToken = blobReader.ReadBlob(publicKeyOrTokenIndex);
                var name = stringsReader.ReadString(nameIndex);
                var culture = stringsReader.ReadString(cultureIndex);
                var hashValue = blobReader.ReadBlob(hashValueIndex);

                assemblyRefs[recordIndex] = new AssemblyRef(
                    recordIndex + 1,
                    version,
                    flags,
                    new MetadataBlob(publicKeyOrTokenIndex, publicKeyOrToken),
                    new MetadataString(nameIndex, name),
                    new MetadataString(cultureIndex, culture),
                    new MetadataBlob(hashValueIndex, hashValue));
            }

            return new MetadataTable<AssemblyRef>(assemblyRefs);
        }

        private MetadataTable<AssemblyRefProcessor> GetAssemblyRefProcessor(TableSizes tableSizes)
        {
            var assemblyRefProcessorSize = tableSizes[TableType.AssemblyOS];
            var assemblyRefSize = tableSizes.GetIndexSize(TableType.AssemblyRef);

            var assemblyRefProcessors = new AssemblyRefProcessor[assemblyRefProcessorSize];

            for (var recordIndex = 0U; recordIndex < assemblyRefProcessorSize; recordIndex++)
            {
                var processor = reader.ReadUInt32();
                var assemblyRef = ReadIndex(assemblyRefSize);

                assemblyRefProcessors[recordIndex] = new AssemblyRefProcessor(
                    recordIndex + 1,
                    processor,
                    assemblyRef);
            }

            return new MetadataTable<AssemblyRefProcessor>(assemblyRefProcessors);
        }

        private MetadataTable<AssemblyRefOS> GetAssemblyRefOS(TableSizes tableSizes)
        {
            var assemblyRefOSSize = tableSizes[TableType.AssemblyRefOS];
            var assemblyRefSize = tableSizes.GetIndexSize(TableType.AssemblyRef);

            var assemblyRefOSes = new AssemblyRefOS[assemblyRefOSSize];

            for (var recordIndex = 0U; recordIndex < assemblyRefOSSize; recordIndex++)
            {
                var osPlatformId = reader.ReadUInt32();
                var osMajorVersion = reader.ReadUInt32();
                var osMinorVersion = reader.ReadUInt32();
                var assemblyRef = ReadIndex(assemblyRefSize);

                assemblyRefOSes[recordIndex] = new AssemblyRefOS(
                    recordIndex + 1,
                    osPlatformId,
                    osMajorVersion,
                    osMinorVersion,
                    assemblyRef);
            }

            return new MetadataTable<AssemblyRefOS>(assemblyRefOSes);
        }

        private MetadataTable<File> GetFile(TableSizes tableSizes)
        {
            var fileSize = tableSizes[TableType.File];

            var files = new File[fileSize];

            for (var recordIndex = 0U; recordIndex < fileSize; recordIndex++)
            {
                var flags = ReadEnum4<FileAttributes>();
                var nameIndex = ReadStringIndex();
                var hashValueIndex = ReadBlobIndex();

                var name = stringsReader.ReadString(nameIndex);
                var hashValue = blobReader.ReadBlob(hashValueIndex);

                files[recordIndex] = new File(
                    recordIndex + 1,
                    flags,
                    new MetadataString(nameIndex, name),
                    new MetadataBlob(hashValueIndex, hashValue));
            }

            return new MetadataTable<File>(files);
        }

        private MetadataTable<ExportedType> GetExportedType(TableSizes tableSizes)
        {
            var exportedTypeSize = tableSizes[TableType.ExportedType];
            var implementationSize = tableSizes.ForCodedIndex(Indexes.Implementation);

            var exportedTypes = new ExportedType[exportedTypeSize];

            for (var recordIndex = 0U; recordIndex < exportedTypeSize; recordIndex++)
            {
                var flags = ReadEnum4<TypeAttributes>();
                var typeDefId = reader.ReadUInt32();
                var typeNameIndex = ReadStringIndex();
                var typeNamespaceIndex = ReadStringIndex();
                var implementation = Indexes.Implementation.Create(ReadIndex(implementationSize));

                var typeName = stringsReader.ReadString(typeNameIndex);
                var typeNamespace = stringsReader.ReadString(typeNamespaceIndex);

                exportedTypes[recordIndex] = new ExportedType(
                    recordIndex + 1,
                    flags,
                    typeDefId,
                    new MetadataString(typeNameIndex, typeName),
                    new MetadataString(typeNamespaceIndex, typeNamespace),
                    implementation);
            }

            return new MetadataTable<ExportedType>(exportedTypes);
        }

        private MetadataTable<ManifestResource> GetManifestResource(TableSizes tableSizes)
        {
            var manifestResourceSize = tableSizes[TableType.ManifestResource];
            var implementationSize = tableSizes.ForCodedIndex(Indexes.Implementation);

            var exportedTypes = new ManifestResource[manifestResourceSize];

            for (var recordIndex = 0U; recordIndex < manifestResourceSize; recordIndex++)
            {
                var offset = reader.ReadUInt32();
                var flags = ReadEnum4<ManifestResourceAttributes>();
                var nameIndex = ReadStringIndex();
                var implementation = Indexes.Implementation.Create(ReadIndex(implementationSize));

                var name = stringsReader.ReadString(nameIndex);

                exportedTypes[recordIndex] = new ManifestResource(
                    recordIndex + 1,
                    offset,
                    flags,
                    new MetadataString(nameIndex, name),
                    implementation);
            }

            return new MetadataTable<ManifestResource>(exportedTypes);
        }

        private MetadataTable<NestedClass> GetNestedClass(TableSizes tableSizes)
        {
            var nestedClassSize = tableSizes[TableType.NestedClass];
            var typeDefSize = tableSizes.GetIndexSize(TableType.TypeDef);

            var nestedClasses = new NestedClass[nestedClassSize];

            for (var recordIndex = 0U; recordIndex < nestedClassSize; recordIndex++)
            {
                var nestedClass = ReadIndex(typeDefSize);
                var enclosingClass = ReadIndex(typeDefSize);

                nestedClasses[recordIndex] = new NestedClass(
                    recordIndex + 1,
                    nestedClass,
                    enclosingClass);
            }

            return new MetadataTable<NestedClass>(nestedClasses);
        }

        private MetadataTable<GenericParam> GetGenericParam(TableSizes tableSizes)
        {
            var genericParamSize = tableSizes[TableType.GenericParam];
            var ownerSize = tableSizes.ForCodedIndex(Indexes.TypeOrMethodDef);

            var genericParams = new GenericParam[genericParamSize];

            for (var recordIndex = 0U; recordIndex < genericParamSize; recordIndex++)
            {
                var number = reader.ReadUInt16();
                var flags = ReadEnum2<GenericParamAttributes>();
                var owner = Indexes.TypeOrMethodDef.Create(ReadIndex(ownerSize));
                var nameIndex = ReadStringIndex();

                var name = stringsReader.ReadString(nameIndex);

                genericParams[recordIndex] = new GenericParam(
                    recordIndex + 1,
                    number,
                    flags,
                    owner,
                    new MetadataString(nameIndex, name));
            }

            return new MetadataTable<GenericParam>(genericParams);
        }

        private MetadataTable<MethodSpec> GetMethodSpec(TableSizes tableSizes)
        {
            var methodSpecSize = tableSizes[TableType.MethodSpec];
            var methodSize = tableSizes.ForCodedIndex(Indexes.MethodDefOrRef);

            var methodSpecs = new MethodSpec[methodSpecSize];

            for (var recordIndex = 0U; recordIndex < methodSpecSize; recordIndex++)
            {
                var method = Indexes.MethodDefOrRef.Create(ReadIndex(methodSize));
                var instantiationIndex = ReadBlobIndex();

                var instantiation = blobReader.ReadBlob(instantiationIndex);

                methodSpecs[recordIndex] = new MethodSpec(
                    recordIndex + 1,
                    method,
                    new MetadataBlob(instantiationIndex, instantiation));
            }

            return new MetadataTable<MethodSpec>(methodSpecs);
        }

        private MetadataTable<GenericParamConstraint> GetGenericParamConstraint(TableSizes tableSizes)
        {
            var genericParamConstraintSize = tableSizes[TableType.GenericParamConstraint];
            var genericParamSize = tableSizes.GetIndexSize(TableType.GenericParam);
            var constraintSize = tableSizes.ForCodedIndex(Indexes.TypeDefOrRef);

            var genericParamConstraints = new GenericParamConstraint[genericParamConstraintSize];

            for (var recordIndex = 0U; recordIndex < genericParamConstraintSize; recordIndex++)
            {
                var owner = ReadIndex(genericParamSize);
                var constraint = Indexes.TypeDefOrRef.Create(ReadIndex(constraintSize));

                genericParamConstraints[recordIndex] = new GenericParamConstraint(
                    recordIndex + 1,
                    owner,
                    constraint);
            }

            return new MetadataTable<GenericParamConstraint>(genericParamConstraints);
        }

        private MetadataTable<Document> GetDocument(TableSizes tableSizes)
        {
            var documentSize = tableSizes[TableType.Document];

            var documents = new Document[documentSize];

            for (var recordIndex = 0U; recordIndex < documentSize; recordIndex++)
            {
                var nameIndex = ReadStringIndex();
                var hashAlgorithmIndex = ReadGuidIndex();
                var hashIndex = ReadBlobIndex();
                var languageIndex = ReadGuidIndex();

                var name = stringsReader.ReadString(nameIndex);
                var hashAlgorithm = guidReader.ReadGuid(hashAlgorithmIndex);
                var hash = blobReader.ReadBlob(hashIndex);
                var language = blobReader.ReadBlob(languageIndex);

                documents[recordIndex] = new Document(
                    recordIndex + 1,
                    new MetadataString(nameIndex, name),
                    new MetadataGuid(hashAlgorithmIndex, hashAlgorithm),
                    new MetadataBlob(hashIndex, hash),
                    new MetadataBlob(languageIndex, language));
            }

            return new MetadataTable<Document>(documents);
        }

        private MetadataTable<MethodDebugInformation> GetMethodDebugInformation(TableSizes tableSizes)
        {
            var methodDebugInformationSize = tableSizes[TableType.MethodDebugInformation];
            var documentSize = tableSizes.GetIndexSize(TableType.Document);

            var methodDebugInformations = new MethodDebugInformation[methodDebugInformationSize];

            for (var recordIndex = 0U; recordIndex < methodDebugInformationSize; recordIndex++)
            {
                var document = ReadIndex(documentSize);
                var sequencePointsIndex = ReadBlobIndex();

                var sequencePoints = blobReader.ReadBlob(sequencePointsIndex);

                methodDebugInformations[recordIndex] = new MethodDebugInformation(
                    recordIndex + 1,
                    document,
                    new MetadataBlob(sequencePointsIndex, sequencePoints));
            }

            return new MetadataTable<MethodDebugInformation>(methodDebugInformations);
        }

        private MetadataTable<LocalScope> GetLocalScope(TableSizes tableSizes)
        {
            var localScopeSize = tableSizes[TableType.LocalScope];
            var methodSize = tableSizes.GetIndexSize(TableType.Method);
            var importScopeSize = tableSizes.GetIndexSize(TableType.ImportScope);
            var localVariableSize = tableSizes.GetIndexSize(TableType.LocalVariable);
            var localConstantSize = tableSizes.GetIndexSize(TableType.LocalConstant);

            var localScopes = new LocalScope[localScopeSize];

            for (var recordIndex = 0U; recordIndex < localScopeSize; recordIndex++)
            {
                var method = ReadIndex(methodSize);
                var importScope = ReadIndex(importScopeSize);
                var variableList = ReadIndex(localVariableSize);
                var constantList = ReadIndex(localConstantSize);
                var startOffset = reader.ReadUInt32();
                var length = reader.ReadUInt32();

                localScopes[recordIndex] = new LocalScope(
                    recordIndex + 1,
                    method,
                    importScope,
                    variableList,
                    constantList,
                    startOffset,
                    length);
            }

            return new MetadataTable<LocalScope>(localScopes);
        }

        private MetadataTable<LocalVariable> GetLocalVariable(TableSizes tableSizes)
        {
            var localVariableSize = tableSizes[TableType.LocalVariable];

            var localVariables = new LocalVariable[localVariableSize];

            for (var recordIndex = 0U; recordIndex < localVariableSize; recordIndex++)
            {
                var attributes = reader.ReadUInt16();
                var index = reader.ReadUInt16();
                var nameIndex = ReadStringIndex();

                var name = stringsReader.ReadString(nameIndex);

                localVariables[recordIndex] = new LocalVariable(
                    recordIndex + 1,
                    attributes,
                    index,
                    new MetadataString(nameIndex, name));
            }

            return new MetadataTable<LocalVariable>(localVariables);
        }

        private MetadataTable<LocalConstant> GetLocalConstant(TableSizes tableSizes)
        {
            var localConstantSize = tableSizes[TableType.LocalConstant];

            var localConstants = new LocalConstant[localConstantSize];

            for (var recordIndex = 0U; recordIndex < localConstantSize; recordIndex++)
            {
                var nameIndex = ReadStringIndex();
                var signatureIndex = ReadBlobIndex();

                var name = stringsReader.ReadString(nameIndex);
                var signatureArray = blobReader.ReadBlob(signatureIndex);
                var signature = new SignatureReader(signatureArray)
                    .ReadSignature();

                localConstants[recordIndex] = new LocalConstant(
                    recordIndex + 1,
                    new MetadataString(nameIndex, name),
                    new MetadataSignature(signatureIndex, signature));
            }

            return new MetadataTable<LocalConstant>(localConstants);
        }

        private MetadataTable<ImportScope> GetImportScope(TableSizes tableSizes)
        {
            var importScopeSize = tableSizes[TableType.ImportScope];
            var parentSize = tableSizes.GetIndexSize(TableType.ImportScope);

            var importScopes = new ImportScope[importScopeSize];

            for (var recordIndex = 0U; recordIndex < importScopeSize; recordIndex++)
            {
                var parent = ReadIndex(parentSize);
                var importsIndex = ReadBlobIndex();

                var imports = blobReader.ReadBlob(importsIndex);

                importScopes[recordIndex] = new ImportScope(
                    recordIndex + 1,
                    parent,
                    new MetadataBlob(importsIndex, imports));
            }

            return new MetadataTable<ImportScope>(importScopes);
        }

        private MetadataTable<StateMachineMethod> GetStateMachineMethod(TableSizes tableSizes)
        {
            var stateMachineMethodSize = tableSizes[TableType.StateMachineMethod];
            var methodSize = tableSizes.GetIndexSize(TableType.Method);

            var stateMachineMethods = new StateMachineMethod[stateMachineMethodSize];

            for (var recordIndex = 0U; recordIndex < stateMachineMethodSize; recordIndex++)
            {
                var moveNextMethod = ReadIndex(methodSize);
                var kickoffMethod = ReadIndex(methodSize);

                stateMachineMethods[recordIndex] = new StateMachineMethod(
                    recordIndex + 1,
                    moveNextMethod,
                    kickoffMethod);
            }

            return new MetadataTable<StateMachineMethod>(stateMachineMethods);
        }

        private MetadataTable<CustomDebugInformation> GetCustomDebugInformation(TableSizes tableSizes)
        {
            var customDebugInformationSize = tableSizes[TableType.CustomDebugInformation];
            var parentSize = tableSizes.GetIndexSize(TableType.CustomDebugInformation);

            var customDebugInformations = new CustomDebugInformation[customDebugInformationSize];

            for (var recordIndex = 0U; recordIndex < customDebugInformationSize; recordIndex++)
            {
                var parent = ReadIndex(parentSize);
                var kindIndex = ReadGuidIndex();
                var valueIndex = ReadStringIndex();

                var kind = guidReader.ReadGuid(kindIndex);
                var value = stringsReader.ReadString(valueIndex);

                customDebugInformations[recordIndex] = new CustomDebugInformation(
                    recordIndex + 1,
                    parent,
                    new MetadataGuid(kindIndex, kind),
                    new MetadataString(valueIndex, value));
            }

            return new MetadataTable<CustomDebugInformation>(customDebugInformations);
        }

        private TEnum ReadEnum1<TEnum>() where TEnum : Enum
        {
            var value = reader.ReadByte();

            return Unsafe.As<byte, TEnum>(ref value);
        }

        private TEnum ReadEnum2<TEnum>() where TEnum : Enum
        {
            var value = reader.ReadUInt16();

            return Unsafe.As<ushort, TEnum>(ref value);
        }

        private TEnum ReadEnum4<TEnum>() where TEnum : Enum
        {
            var value = reader.ReadUInt32();

            return Unsafe.As<uint, TEnum>(ref value);
        }

        private uint ReadStringIndex()
        {
            return this.isBigString ? reader.ReadUInt32() : reader.ReadUInt16();
        }

        private uint ReadGuidIndex()
        {
            return this.isBigGuid ? reader.ReadUInt32() : reader.ReadUInt16();
        }

        private uint ReadBlobIndex()
        {
            return this.isBigBlob ? reader.ReadUInt32() : reader.ReadUInt16();
        }

        private uint ReadIndex(int indexSize)
        {
            Debug.Assert(indexSize == 2 || indexSize == 4);

            return indexSize == 4 ? reader.ReadUInt32() : reader.ReadUInt16();
        }
    }
}