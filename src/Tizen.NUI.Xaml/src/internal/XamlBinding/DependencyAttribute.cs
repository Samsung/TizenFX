using System;

namespace Tizen.NUI.XamlBinding
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