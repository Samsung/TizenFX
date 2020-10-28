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
            /// The CircleUIManager manages the circle widget to be drawn on the other widgets.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class CircleUIManager
            {
                IntPtr _handle;
                public IntPtr NativeHandle => _handle;

                public CircleUIManager(Efl.Ui.Win conformant)
                {
                    _handle = Interop.Eext.eext_circle_surface_conformant_add(conformant.NativeHandle);
                }

                public CircleUIManager(Efl.Object layout)
                {
                    _handle = Interop.Eext.eext_circle_surface_layout_add(layout.NativeHandle);
                }

                public CircleUIManager(Efl.Ui.Spotlight.Container container)
                {
                    _handle = Interop.Eext.eext_circle_surface_naviframe_add(container.NativeHandle);
                }

                public CircleUIManager()
                {
                    _handle = IntPtr.Zero;
                }

                /// <summary>
                /// Registers the circle object to the circle ui manager.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void RegisterCircleObject(ICircleWidget circleObject)
                {
                    if (NativeHandle != IntPtr.Zero)
                        Interop.Eext.eext_circle_object_connect(NativeHandle, circleObject.CircleHandle);
                }

                /// <summary>
                /// Unregisters the circle object from the circle ui manager.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void UnRegisterCircleObject(ICircleWidget circleObject)
                {
                    if (NativeHandle != IntPtr.Zero)
                        Interop.Eext.eext_circle_object_disconnect(NativeHandle, circleObject.CircleHandle);
                }

                /// <summary>
                /// Deletes the circle ui manager.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void Delete()
                {
                    if (NativeHandle != IntPtr.Zero)
                    {
                        Interop.Eext.eext_circle_surface_del(NativeHandle);
                        _handle = IntPtr.Zero;
                    }
                }
            }
        }
    }
}
