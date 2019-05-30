using System;
using System.ComponentModel;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The class NullExtension.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiled("Tizen.NUI.Xaml.Build.Tasks.NullExtension")]
    [AcceptEmptyServiceProvider]
    public class NullExtension : IMarkupExtension
    {
        /// <summary>
        /// Provide value tye service provideer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return null;
        }
    }
}
