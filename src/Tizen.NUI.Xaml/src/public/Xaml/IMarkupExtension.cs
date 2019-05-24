using System;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The interface IMarkupExtension.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public interface IMarkupExtension<out T> : IMarkupExtension
    {
        /// <summary>
        /// The API ProvideValue.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        new T ProvideValue(IServiceProvider serviceProvider);
    }

    /// <summary>
    /// The interface IMarkupExtension.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public interface IMarkupExtension
    {
        /// <summary>
        /// The API ProvideValue.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        object ProvideValue(IServiceProvider serviceProvider);
    }

    /// <summary>
    /// The class AcceptEmptyServiceProviderAttribute.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class AcceptEmptyServiceProviderAttribute : Attribute
    {
    }
}