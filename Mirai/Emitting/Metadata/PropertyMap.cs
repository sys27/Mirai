using System.Collections.Generic;

namespace Mirai.Emitting.Metadata
{
    // 0x15
    public class PropertyMap : Table
    {
        public PropertyMap(uint recordIndex, uint parent, uint propertyList)
            : base(recordIndex)
        {
            Parent = parent;
            PropertyList = propertyList;
        }

        public override TableType TableType => TableType.PropertyMap;

        /// <summary>
        /// An index into the TypeDef table.
        /// </summary>
        public uint Parent { get; }

        /// <summary>
        /// An index into the Property table.
        /// </summary>
        public uint PropertyList { get; }
    }
}