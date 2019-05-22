using System;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The interface IValueProvider.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public interface IValueProvider
    {
        /// <summary>
        /// Provider value.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        object ProvideValue(IServiceProvider serviceProvider);
    }
}