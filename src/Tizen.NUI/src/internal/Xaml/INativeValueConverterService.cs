using System;

namespace Tizen.NUI.Xaml.Internals
{
    internal interface INativeValueConverterService
    {
        bool ConvertTo(object value, Type toType, out object nativeValue);
    }
}