using System;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The class NullExtension.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [ProvideCompiled("Tizen.NUI.Xaml.Build.Tasks.NullExtension")]
    [AcceptEmptyServiceProvider]
    public class NullExtension : IMarkupExtension
    {
        /// <summary>
        /// Provide value tye service provideer.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return null;
        }
    }
}
