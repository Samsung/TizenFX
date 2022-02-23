using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// Template that specifies a group of styles and effects for controls.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ControlTemplate : ElementTemplate
    {
        /// <summary>
        /// For internal use only.
        /// </summary>
        public ControlTemplate()
        {
        }

        /// <summary>
        /// Creates a new control template for the specified control type.
        /// </summary>
        /// <param name="type">The type of control for which to create a template.</param>
        public ControlTemplate(Type type) : base(type)
        {
        }
    }
}
