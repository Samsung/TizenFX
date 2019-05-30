using System;

namespace Tizen.NUI.XamlBinding
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class RenderWithAttribute : Attribute
    {
        public RenderWithAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; }
    }
}