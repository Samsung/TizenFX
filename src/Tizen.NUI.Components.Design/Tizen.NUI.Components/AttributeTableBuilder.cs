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
            //Tizen.NUI.Components
            Type typeFromHandle = typeof(Control);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Button);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(CheckBox);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            //typeFromHandle = typeof(DropDown);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ScrollBar);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Loading);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Notification);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Pagination);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Popup);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Progress);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(RadioButton);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ScrollableBase);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Scrollbar);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ScrollbarBase);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(SelectButton);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Slider);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Switch);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Tab);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(Toast);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(FlexibleView);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(RecyclerView);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));


            //Tizen.NUI.Components Style
            typeFromHandle = typeof(ButtonStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ControlStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            //typeFromHandle = typeof(DropDownStyle);
            //AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            //typeFromHandle = typeof(DropDownItemStyle);
            //AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ScrollBarStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(LoadingStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(PaginationStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(PopupStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ProgressStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ScrollbarStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(SliderStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(SwitchStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(TabStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
            typeFromHandle = typeof(ToastStyle);
            AddTypeAttributes(typeFromHandle, new EditorBrowsableAttribute(EditorBrowsableState.Always));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AttributeTableBuilder() : base()
        {
            Assembly assembly = typeof(Control).Assembly;
            assembly = typeof(Control).Assembly;
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
