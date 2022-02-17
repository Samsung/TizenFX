using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tizen.NUI.StyleSheets;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Binding
{
    internal sealed class MergedStyle : IStyle
    {
        ////If the base type is one of these, stop registering dynamic resources further
        ////The last one (typeof(Element)) is a safety guard as we might be creating VisualElement directly in internal code
        static readonly IList<Type> stopAtTypes = new List<Type> { typeof(View), typeof(Element) };

        IList<BindableProperty> classStyleProperties;

        readonly List<BindableProperty> implicitStyles = new List<BindableProperty>();

        IList<XamlStyle> classStyles;

        IStyle implicitStyle;

        IStyle style;

        IList<string> styleClass;

        public MergedStyle(Type targetType, BindableObject target)
        {
            Target = target;
            TargetType = targetType;
            RegisterImplicitStyles();
            Apply(Target);
        }

        public IStyle Style
        {
            get { return style; }
            set
            {
                if (style == value)
                    return;
                if (value != null && !value.TargetType.IsAssignableFrom(TargetType))
                    NUILog.Error($"Style TargetType {value.TargetType.FullName} is not compatible with element target type {TargetType}");
                SetStyle(ImplicitStyle, ClassStyles, value);
            }
        }

        public IList<string> StyleClass
        {
            get { return styleClass; }
            set
            {
                if (styleClass == value)
                    return;

                if (styleClass != null && classStyleProperties != null)
                    foreach (var classStyleProperty in classStyleProperties)
                        Target.RemoveDynamicResource(classStyleProperty);

                styleClass = value;

                if (styleClass != null)
                {
                    classStyleProperties = new List<BindableProperty>();
                    foreach (var styleClass in styleClass)
                    {
                        var classStyleProperty = BindableProperty.Create("ClassStyle", typeof(IList<XamlStyle>), typeof(View), default(IList<XamlStyle>),
                            propertyChanged: (bindable, oldvalue, newvalue) => ((View)bindable).MergedStyle.OnClassStyleChanged());
                        classStyleProperties.Add(classStyleProperty);
                        Target.OnSetDynamicResource(classStyleProperty, Tizen.NUI.Binding.XamlStyle.StyleClassPrefix + styleClass);
                    }
                }
            }
        }

        public BindableObject Target { get; }

        IList<XamlStyle> ClassStyles
        {
            get { return classStyles; }
            set { SetStyle(ImplicitStyle, value, Style); }
        }

        IStyle ImplicitStyle
        {
            get { return implicitStyle; }
            set { SetStyle(value, ClassStyles, Style); }
        }

        public void Apply(BindableObject bindable)
        {
            ImplicitStyle?.Apply(bindable);
            if (ClassStyles != null)
                foreach (var classStyle in ClassStyles)
                    ((IStyle)classStyle)?.Apply(bindable);
            Style?.Apply(bindable);
        }

        public Type TargetType { get; }

        public void UnApply(BindableObject bindable)
        {
            Style?.UnApply(bindable);
            if (ClassStyles != null)
                foreach (var classStyle in ClassStyles)
                    ((IStyle)classStyle)?.UnApply(bindable);
            ImplicitStyle?.UnApply(bindable);
        }

        void OnClassStyleChanged()
        {
            ClassStyles = classStyleProperties.Select(p => (Target.GetValue(p) as IList<XamlStyle>)?.FirstOrDefault(s => s.CanBeAppliedTo(TargetType))).ToList();
        }

        void OnImplicitStyleChanged()
        {
            var first = true;
            foreach (BindableProperty implicitStyleProperty in implicitStyles)
            {
                var implicitStyle = (XamlStyle)Target.GetValue(implicitStyleProperty);
                if (implicitStyle != null)
                {
                    if (first || implicitStyle.ApplyToDerivedTypes)
                    {
                        ImplicitStyle = implicitStyle;
                        return;
                    }
                }
                first = false;
            }
        }

        void RegisterImplicitStyles()
        {
            Type type = TargetType;
            while (true)
            {
                if (type != null)
                {
                    BindableProperty implicitStyleProperty = BindableProperty.Create(nameof(ImplicitStyle), typeof(XamlStyle), typeof(View), default(XamlStyle),
                            propertyChanged: (bindable, oldvalue, newvalue) => OnImplicitStyleChanged());
                    implicitStyles.Add(implicitStyleProperty);
                    Target.SetDynamicResource(implicitStyleProperty, type.FullName);
                    type = type.GetTypeInfo().BaseType;
                }

                if (type == null || stopAtTypes.Contains(type))
                    return;
            }
        }

        void SetStyle(IStyle implicitStyle, IList<XamlStyle> classStyles, IStyle style)
        {
            bool shouldReApplyStyle = implicitStyle != ImplicitStyle || classStyles != ClassStyles || Style != style;
            bool shouldReApplyClassStyle = implicitStyle != ImplicitStyle || classStyles != ClassStyles;
            bool shouldReApplyImplicitStyle = implicitStyle != ImplicitStyle && (Style as XamlStyle == null || ((XamlStyle)Style).CanCascade);

            if (shouldReApplyStyle)
                Style?.UnApply(Target);
            if (shouldReApplyClassStyle && ClassStyles != null)
                foreach (var classStyle in ClassStyles)
                    ((IStyle)classStyle)?.UnApply(Target);
            if (shouldReApplyImplicitStyle)
                ImplicitStyle?.UnApply(Target);

            this.implicitStyle = implicitStyle;
            this.classStyles = classStyles;
            this.style = style;

            if (shouldReApplyImplicitStyle)
                ImplicitStyle?.Apply(Target);
            if (shouldReApplyClassStyle && ClassStyles != null)
                foreach (var classStyle in ClassStyles)
                    ((IStyle)classStyle)?.Apply(Target);
            if (shouldReApplyStyle)
                Style?.Apply(Target);
        }
    }
}