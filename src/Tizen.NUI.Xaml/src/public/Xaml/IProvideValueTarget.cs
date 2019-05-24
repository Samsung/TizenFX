namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The interface IProvideValueTarget.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public interface IProvideValueTarget
    {
        /// <summary>
        /// The API TargetObject.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        object TargetObject { get; }

        /// <summary>
        /// The API TargetObject.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        object TargetProperty { get; }
    }
}