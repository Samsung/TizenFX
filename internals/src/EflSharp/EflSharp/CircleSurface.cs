using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            /// <summary>
            /// The CircleSurface presents a surface for drawing the circular feature of circle widgets.
            /// </summary>
            /// <since_tizen> preview </since_tizen>
            public class CircleSurface
            {
                IntPtr _handle;

                /// <summary>
                /// Creates and initializes a new instance of the CircleSurface class with a surface on the Conformant widget.
                /// </summary>
                /// <param name="conformant">The Conformant widget to create a surface.</param>
                /// <since_tizen> preview </since_tizen>
                public CircleSurface(Efl.Ui.Win conformant)
                {
                    _handle = Interop.Eext.eext_circle_surface_conformant_add(conformant.NativeHandle);
                }

                /// <summary>
                /// Creates and initializes a new instance of the CircleSurface class with a surface on the Layout widget.
                /// </summary>
                /// <param name="layout">The Layout widget to create a surface.</param>
                /// <since_tizen> preview </since_tizen>
                public CircleSurface(Efl.Object layout)
                {
                    _handle = Interop.Eext.eext_circle_surface_layout_add(layout.NativeHandle);
                }

                /// <summary>
                /// Creates and initializes a new instance of the CircleSurface class with a surface on the Naviframe widget.
                /// </summary>
                /// <param name="naviframe">The Naviframe widget to create a surface.</param>
                /// <since_tizen> preview </since_tizen>
                public CircleSurface(Efl.Ui.Stack naviframe)
                {
                    _handle = Interop.Eext.eext_circle_surface_naviframe_add(naviframe.NativeHandle);
                }

                /// <summary>
                /// Creates and initializes a new instance of the CircleSurface class with no surface.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public CircleSurface()
                {
                    _handle = IntPtr.Zero;
                }

                /// <summary>
                /// Gets the handle for CircleSurface.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public IntPtr Handle => _handle;

                /// <summary>
                /// Deletes the given CircleSurface.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public void Delete()
                {
                    if (Handle != IntPtr.Zero)
                    {
                        Interop.Eext.eext_circle_surface_del(Handle);
                        _handle = IntPtr.Zero;
                    }
                }
                /*
                internal static CircleSurface CreateCircleSurface(efl.ui.Widget obj)
                    {
                        if (obj is Win) return new CircleSurface(obj as Win);
                        else if (obj is Naviframe) return new CircleSurface(obj as Naviframe);
                        else if (obj is Layout) return new CircleSurface(obj as Layout);
                        else return new CircleSurface();
                    }
                */
            }
        }
    }
}
