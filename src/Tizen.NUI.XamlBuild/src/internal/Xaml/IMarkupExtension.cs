using System;

namespace Tizen.NUI.Xaml
{
    internal interface IMarkupExtension<out T> : IMarkupExtension
    {
        new T ProvideValue(IServiceProvider serviceProvider);
    }

    internal interface IMarkupExtension
    {
        object ProvideValue(IServiceProvider serviceProvider);
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal sealed class AcceptEmptyServiceProviderAttribute : Attribute
    {
    }
}