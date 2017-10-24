using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Wearable
{
    /// <summary>
    /// The CircleSurface presents a surface for drawing circular feature of circle widgets
    /// </summary>
    public class CircleSurface
    {
        IntPtr _handle;

        /// <summary>
        /// Creates and initializes a new instance of the CircleSurface class with surface on the Conformant widget.
        /// </summary>
        /// <param name="conformant">Conformant widget to create a surface.</param>
        public CircleSurface(Conformant conformant)
        {
            _handle = Interop.Eext.eext_circle_surface_conformant_add(conformant);
        }

        /// <summary>
        /// Creates and initializes a new instance of the CircleSurface class with surface on the Layout widget.
        /// </summary>
        /// <param name="layout">Layout widget to create a surface.</param>
        public CircleSurface(Layout layout)
        {
            _handle = Interop.Eext.eext_circle_surface_layout_add(layout);
        }

        /// <summary>
        /// Creates and initializes a new instance of the CircleSurface class with surface on the Naviframe widget.
        /// </summary>
        /// <param name="naviframe">Naviframe widget to create a surface.</param>
        public CircleSurface(Naviframe naviframe)
        {
            _handle = Interop.Eext.eext_circle_surface_naviframe_add(naviframe);
        }

        /// <summary>
        /// Creates and initializes a new instance of the CircleSurface class with no surface
        /// </summary>
        public CircleSurface()
        {
            _handle = IntPtr.Zero;
        }

        public IntPtr Handle => _handle;
    }
}
