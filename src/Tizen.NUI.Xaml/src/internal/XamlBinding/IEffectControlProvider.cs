using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// When implemented in a renderer, registers a platform-specific effect on an element.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IEffectControlProvider
    {
        /// <summary>
        /// Registers the effect with the element by establishing the parent-child relations needed for rendering on the specific platform.
        /// </summary>
        /// <param name="effect">The effect to register.</param>
        void RegisterEffect(Effect effect);
    }
}
