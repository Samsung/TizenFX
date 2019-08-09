﻿using System;
using System.ComponentModel;
using System.Reflection;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI
{
    internal class AttributeTableBuilder : Microsoft.Windows.Design.Metadata.AttributeTableBuilder
    {
        private void AddAttributesForTypes()
        {
            Type typeFromHandle = typeof(ContentPage);
            typeFromHandle = typeof(PushButton);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ContentPage);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            AddTypeAttributes(typeFromHandle, new global::System.Windows.Markup.ContentPropertyAttribute("Content"));
            typeFromHandle = typeof(TextEditor);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(FlexContainer);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ImageView);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(TextLabel);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(TextField);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ProgressBar);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ScrollView);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ScrollBar);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Slider);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(TableView);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(View);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            AddTypeAttributes(typeFromHandle, new global::System.Windows.Markup.ContentPropertyAttribute("Children"));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AttributeTableBuilder() : base()
        {
            Assembly assembly = typeof(View).Assembly;
            AddAssemblyAttributes(assembly, new global::System.Windows.Markup.XmlnsDefinitionAttribute("http://tizen.org/Tizen.NUI/2018/XAML", "Tizen.NUI"));
            AddAssemblyAttributes(assembly, new global::System.Windows.Markup.XmlnsDefinitionAttribute("http://tizen.org/Tizen.NUI/2018/XAML", "Tizen.NUI.BaseComponents"));
            AddAssemblyAttributes(assembly, new global::System.Windows.Markup.XmlnsDefinitionAttribute("http://tizen.org/Tizen.NUI/2018/XAML", "Tizen.NUI.UIComponents"));
            AddAssemblyAttributes(assembly, new global::System.Windows.Markup.XmlnsDefinitionAttribute("http://tizen.org/Tizen.NUI/2018/XAML", "Tizen.NUI.Xaml"));
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
