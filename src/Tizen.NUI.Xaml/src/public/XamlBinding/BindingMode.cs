using System.ComponentModel;

namespace Tizen.NUI.XamlBinding
{
    /// <summary>
    /// The direction of changes propagation for bindings.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BindingMode
    {
        /// <summary>
        /// When used in Bindings, indicates that the Binding should use the DefaultBindingMode. When used in BindableProperty declaration, defaults to BindingMode.OneWay.
        /// </summary>
        Default,

        /// <summary>
        /// Indicates that the binding should propagates changes from source (usually the View Model) to target (the BindableObject) in both directions.
        /// </summary>
        TwoWay,

        /// <summary>
        /// Indicates that the binding should only propagate changes from source (usually the View Model) to target (the BindableObject). This is the default mode for most BindableProperty values.
        /// </summary>
        OneWay,

        /// <summary>
        /// Indicates that the binding should only propagate changes from target (the BindableObject) to source (usually the View Model). This is mainly used for read-only BindableProperty values.
        /// </summary>
        OneWayToSource,

        /// <summary>
        /// Indicates that the binding will be applied only when the binding context changes and the value will not be monitored for changes with INotifyPropertyChanged.
        /// </summary>
        OneTime,
    }
}