using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
     
            /// <summary>
            /// Circle slider is a circular designed widget used to select a value in a range by the Rotary event.
            /// </summary>
            /// <since_tizen> preview </since_tizen>
            public class CircleGenlist : Efl.Ui.List, ICircleWidget
            {
                CircleSurface _surface;
                IntPtr _handle;

                public virtual IntPtr CircleHandle => _handle;
                public virtual CircleSurface CircleSurface => _surface;
                
                public CircleGenlist(Efl.Ui.Win parent, CircleSurface surface = null) : base(parent)
                {
                    if (surface == null)
                    {
                        _handle = Interop.Eext.eext_circle_object_genlist_add(this.NativeHandle, IntPtr.Zero);
                    }
                    else
                    {
                        _handle = Interop.Eext.eext_circle_object_genlist_add(this.NativeHandle, surface.Handle);
                    }

                    EnrollCircleContent();
                }
                public void EnrollCircleContent()
                {
                    elm_layout_content_set(this.NativeHandle, "efl.swallow.vg", CircleHandle);
                }
                [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
                internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);
            }
        }
    }
}
