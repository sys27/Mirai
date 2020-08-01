namespace Mirai.Emitting.Metadata
{
    public abstract class Table
    {
        protected Table(uint recordIndex)
        {
            MetadataToken = new MetadataToken(TableType, recordIndex);
        }

        public abstract TableType TableType { get; }
        public MetadataToken MetadataToken { get; }
    }
}