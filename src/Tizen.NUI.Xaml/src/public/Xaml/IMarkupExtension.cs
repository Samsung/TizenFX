using System;
using System.ComponentModel;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The interface IMarkupExtension.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMarkupExtension<out T> : IMarkupExtension
    {
        /// <summary>
        /// The API ProvideValue.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        new T ProvideValue(IServiceProvider serviceProvider);
    }

    /// <summary>
    /// The interface IMarkupExtension.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMarkupExtension
    {
        /// <summary>
        /// The API ProvideValue.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        object ProvideValue(IServiceProvider serviceProvider);
    }

    /// <summary>
    /// The class AcceptEmptyServiceProviderAttribute.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class AcceptEmptyServiceProviderAttribute : Attribute
    {
    }
}