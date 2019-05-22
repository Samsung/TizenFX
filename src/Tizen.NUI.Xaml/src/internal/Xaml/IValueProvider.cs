using System;

namespace Tizen.NUI.Xaml
{
    public interface IValueProvider
    {
        object ProvideValue(IServiceProvider serviceProvider);
    }
}