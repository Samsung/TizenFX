using System;

namespace Tizen.NUI.Xaml
{
    internal interface IValueProvider
    {
        object ProvideValue(IServiceProvider serviceProvider);
    }
}