using System;

namespace Tizen.NUI.Xaml
{
    internal interface IXamlTypeResolver
    {
        Type Resolve(string qualifiedTypeName, IServiceProvider serviceProvider = null);
        bool TryResolve(string qualifiedTypeName, out Type type);
    }
}