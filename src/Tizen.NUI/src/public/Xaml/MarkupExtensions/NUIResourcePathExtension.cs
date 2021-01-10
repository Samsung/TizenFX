using System;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty(nameof(FilePath))]
    [AcceptEmptyServiceProvider]
    public class NUIResourcePathExtension : IMarkupExtension<string>
    {
        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NUIResourcePathExtension()
        {
        }

        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FilePath { get; set; }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvideValue(IServiceProvider serviceProvider) => FrameworkInformation.ResourcePath + FilePath;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
        }
    }
}
