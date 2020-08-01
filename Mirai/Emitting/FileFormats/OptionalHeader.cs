namespace Mirai.Emitting.FileFormats
{
    public class OptionalHeader
    {
        public OptionalHeader(
            StandardFields standardFields,
            WindowsSpecificFields windowsSpecificFields,
            DirectoryEntries directoryEntries)
        {
            StandardFields = standardFields;
            WindowsSpecificFields = windowsSpecificFields;
            DirectoryEntries = directoryEntries;
        }

        public StandardFields StandardFields { get; }
        public WindowsSpecificFields WindowsSpecificFields { get; }
        public DirectoryEntries DirectoryEntries { get; }
    }
}