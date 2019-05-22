namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The interface IReferenceProvider.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
	public interface IReferenceProvider
	{
        /// <summary>
        /// Find provider by name.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        object FindByName(string name);
	}
}