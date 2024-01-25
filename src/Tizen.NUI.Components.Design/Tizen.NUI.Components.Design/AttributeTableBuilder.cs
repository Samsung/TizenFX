using System;
using System.ComponentModel;
using Microsoft.Windows.Design;

namespace Tizen.NUI.Components.Design
{
    internal class AttributeTableBuilder : Microsoft.Windows.Design.Metadata.AttributeTableBuilder
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AttributeTableBuilder()
        {
            AddCustomAttributes(typeof(Button).Assembly,
                new XmlnsSupportsValidationAttribute("http://tizen.org/Tizen.NUI/2018/XAML", false));
        }
    }

    internal class AnythingConverter : global::System.ComponentModel.TypeConverter
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsValid(ITypeDescriptorContext context, object value)
        {
            return true;
        }
    }
}