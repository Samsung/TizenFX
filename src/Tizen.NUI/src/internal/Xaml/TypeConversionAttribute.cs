using System;

namespace Tizen.NUI.Xaml
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    internal sealed class TypeConversionAttribute : Attribute
    {
        public Type TargetType { get; private set; }

        public TypeConversionAttribute(Type targetType)
        {
            TargetType = targetType;
        }
    }
}