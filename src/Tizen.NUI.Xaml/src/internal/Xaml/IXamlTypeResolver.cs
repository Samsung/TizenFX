using System;

namespace Tizen.NUI.Xaml
{
    public interface IXamlTypeResolver
    {
        Type Resolve(string qualifiedTypeName, IServiceProvider serviceProvider = null);
        bool TryResolve(string qualifiedTypeName, out Type type);
    }
}