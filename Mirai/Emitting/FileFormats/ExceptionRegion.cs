namespace Mirai.Emitting.FileFormats
{
    public class ExceptionRegion
    {
        public ExceptionRegionFlags Kind { get; }
        public uint DataSize { get; }
        public ExceptionClaus[] Clauses { get; }
    }
}