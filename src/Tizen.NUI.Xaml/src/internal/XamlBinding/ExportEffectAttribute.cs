using System;

namespace Tizen.NUI.XamlBinding
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal class ExportEffectAttribute : Attribute
    {
        public ExportEffectAttribute(Type effectType, string uniqueName)
        {
            if (uniqueName.Contains("."))
                throw new ArgumentException("uniqueName must not contain a .");
            Type = effectType;
            Id = uniqueName;
        }

        internal string Id { get; private set; }

        internal Type Type { get; private set; }
    }
}