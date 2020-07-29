using System;
using System.ComponentModel;
using System.Reflection;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Components
{
    internal class AttributeTableBuilder : Microsoft.Windows.Design.Metadata.AttributeTableBuilder
    {
        private void AddAttributesForTypes()
        {
            Type typeFromHandle = typeof(Control);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AttributeTableBuilder() : base()
        {
            Assembly assembly = typeof(Control).Assembly;
            AddAssemblyAttributes(assembly, new global::System.Windows.Markup.XmlnsDefinitionAttribute("http://tizen.org/Tizen.NUI/2018/XAML", "Tizen.NUI.Components"));
            AddAttributesForTypes();
        }

        private void AddTypeAttributes(Type type, params Attribute[] attribs)
        {
            this.AddCallback(type, builder => builder.AddCustomAttributes(attribs));
        }

        private void AddMemberAttributes(Type type, string memberName, params Attribute[] attribs)
        {
            this.AddCallback(type, builder => builder.AddCustomAttributes(attribs));
        }

        private void AddAssemblyAttributes(Assembly assembly, params Attribute[] attribs)
        {
            this.AddCustomAttributes(assembly, attribs);
        }
    }
}
