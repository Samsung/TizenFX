using Microsoft.Windows.Design.Metadata;
using System.ComponentModel;

namespace Tizen.NUI
{
    internal class RegisterMetadata : IProvideAttributeTable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AttributeTable AttributeTable => new AttributeTableBuilder().CreateTable();
    }
}
