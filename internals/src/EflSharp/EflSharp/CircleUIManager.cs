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

                public CircleUIManager(Efl.Ui.Stack naviframe)
                {
                    _handle = Interop.Eext.eext_circle_surface_naviframe_add(naviframe.NativeHandle);
                }

                public CircleUIManager()
                {
                    _handle = IntPtr.Zero;
                }

                public void RegisterCircleObject(ICircleWidget circleObject)
                {
                    if (NativeHandle != IntPtr.Zero)
                        Interop.Eext.eext_circle_object_connect(NativeHandle, circleObject.CircleHandle);
                }

                public void UnRegisterCircleObject(ICircleWidget circleObject)
                {
                    if (NativeHandle != IntPtr.Zero)
                        Interop.Eext.eext_circle_object_disconnect(NativeHandle, circleObject.CircleHandle);
                }

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
