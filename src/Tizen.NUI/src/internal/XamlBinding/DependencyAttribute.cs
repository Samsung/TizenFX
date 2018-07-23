using System;

namespace Tizen.NUI.Binding
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal class DependencyAttribute : Attribute
    {
        public DependencyAttribute(Type implementorType)
        {
            Implementor = implementorType;
        }

        internal Type Implementor { get; private set; }
    }
}