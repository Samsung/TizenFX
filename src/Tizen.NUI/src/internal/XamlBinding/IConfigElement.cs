using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// This interface is for internal use by platform renderers.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IConfigElement<out T> where T : Element
    {
        /// <summary>
        /// For internal use
        /// </summary>
        T Element { get; }
    }
}
