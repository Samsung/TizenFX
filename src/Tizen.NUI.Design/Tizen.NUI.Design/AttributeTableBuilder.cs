using System;
using System.ComponentModel;
using Microsoft.Windows.Design;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace Tizen.NUI.Design
{
    internal class AttributeTableBuilder : Microsoft.Windows.Design.Metadata.AttributeTableBuilder
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AttributeTableBuilder()
        {
            // Turn off validation of values, which doesn't work for OnPlatform/OnIdiom
            AddCustomAttributes(typeof(View).Assembly,
                new XmlnsSupportsValidationAttribute("http://tizen.org/Tizen.NUI/2018/XAML", false));

            // Style isn't a view, make it visible
            //AddCallback(typeof(Style), builder => builder.AddCustomAttributes(
               //new EditorBrowsableAttribute(EditorBrowsableState.Always),
               //new global::System.Windows.Markup.ContentPropertyAttribute("Setters"),
               // Since the class doesn't have a public parameterless ctor, we need to provide a converter
               //new global::System.ComponentModel.TypeConverterAttribute(typeof(StringConverter))));

            // The Setter.Value can actually come from an <OnPlatform />, so enable it as Content.
            AddCallback(typeof(Setter), builder => builder.AddCustomAttributes(
              new EditorBrowsableAttribute(EditorBrowsableState.Always),
              new global::System.Windows.Markup.ContentPropertyAttribute("Value")));

            // Special case for FontSize which isn't an enum.
            //var fontElements = typeof(View).Assembly.ExportedTypes.Where(t => typeof(IFontElement).IsAssignableFrom(t));
            //foreach (var fontElement in fontElements)
            //{
            //    AddCallback(fontElement, builder => builder.AddCustomAttributes(
            //       "FontSize",
            //       new global::System.ComponentModel.TypeConverterAttribute(typeof(NonExclusiveEnumConverter<NamedSize>))));
            //}
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