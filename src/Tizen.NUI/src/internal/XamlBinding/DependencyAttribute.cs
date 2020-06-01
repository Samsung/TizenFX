using System;

namespace Tizen.NUI.Binding
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal class DependencyAttribute : Attribute
    {
        public DependencyAttribute(System.Type implementorType)
        {
            Implementor = implementorType;
        }

        internal System.Type Implementor { get; private set; }
    }
}