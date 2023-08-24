using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Tizen.NUI.Xaml
{
    [Flags]
    internal enum XamlCompilationOptions
    {
        Skip = 1 << 0,
        Compile = 1 << 1
    }
}
 
