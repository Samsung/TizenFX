using System;

namespace Tizen.NUI.Binding
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class RenderWithAttribute : Attribute
    {
        public RenderWithAttribute(System.Type type)
        {
            Type = type;
        }

        public System.Type Type { get; }
    }
}