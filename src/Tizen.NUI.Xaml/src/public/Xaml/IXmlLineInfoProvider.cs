using System.ComponentModel;
using System.Xml;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The interface IXmlLineInfoProvider.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IXmlLineInfoProvider
    {
        /// <summary>
        /// Attribute XmlLineInfo.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        IXmlLineInfo XmlLineInfo { get; }
    }
}