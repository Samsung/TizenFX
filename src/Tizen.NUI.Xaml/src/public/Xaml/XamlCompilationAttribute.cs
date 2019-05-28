using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Tizen.NUI.Xaml
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Flags]
    public enum XamlCompilationOptions
    {
        Skip = 1 << 0,
        Compile = 1 << 1
    }

    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class, Inherited = false)]
    public sealed class XamlCompilationAttribute : Attribute
    {
        public XamlCompilationAttribute(XamlCompilationOptions xamlCompilationOptions)
        {
            XamlCompilationOptions = xamlCompilationOptions;
        }

        public XamlCompilationOptions XamlCompilationOptions { get; set; }
    }

    internal static class XamlCExtensions
    {
        public static bool IsCompiled(this Type type)
        {
            var attr = type.GetTypeInfo().GetCustomAttribute<XamlCompilationAttribute>();
            if (attr != null)
                return attr.XamlCompilationOptions == XamlCompilationOptions.Compile;
            attr = type.GetTypeInfo().Module.GetCustomAttribute<XamlCompilationAttribute>();
            if (attr != null)
                return attr.XamlCompilationOptions == XamlCompilationOptions.Compile;
            attr = type.GetTypeInfo().Assembly.GetCustomAttribute<XamlCompilationAttribute>();
            if (attr != null)
                return attr.XamlCompilationOptions == XamlCompilationOptions.Compile;

            return false;
        }
    }
}