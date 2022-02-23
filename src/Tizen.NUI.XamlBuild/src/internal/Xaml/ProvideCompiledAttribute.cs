using System;

namespace Tizen.NUI.Xaml
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    internal sealed class ProvideCompiledAttribute : Attribute
    {
        public string CompiledVersion { get; }

        public ProvideCompiledAttribute (string compiledVersion)
        {
            CompiledVersion = compiledVersion;
        }
    }
}