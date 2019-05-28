using System.ComponentModel;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The interface IReferenceProvider.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IReferenceProvider
	{
        /// <summary>
        /// Find provider by name.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        object FindByName(string name);
	}
}