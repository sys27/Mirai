using System.Collections.Generic;
using System.Collections.Immutable;
using Mirai.Emitting.Metadata;

namespace Mirai.Emitting.FileFormats
{
    public class MetadataTable<TTable> where TTable : Table
    {
        private readonly ImmutableArray<TTable> tableRows;

        public MetadataTable(IEnumerable<TTable> tableRows)
        {
            this.tableRows = tableRows.ToImmutableArray();
        }

        public TTable this[int recordIndex]
            => tableRows[recordIndex - 1];
    }
}