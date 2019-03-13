using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            public class CircleColorPart : Efl.Object, Efl.Gfx.Color
            {
                protected IntPtr _handle;
                public CircleColorPart(IntPtr CircleHandle)
                {
                    _handle = CircleHandle;
                }

                public virtual void SetColor(int r, int g, int b, int a)
                {
                    //Not Implemented
                }

                public virtual void GetColor(out int r, out int g, out int b, out int a)
                {
                    //Not Implemented
                    r = g = b = a = -1;
                }

                public void SetColorCode(System.String colorcode)
                {
                    //Not Implemented
                    return;
                }

                public System.String GetColorCode()
                {
                    //Not Implemented
                    return null;
                }

                public System.String GetColorClassCode(System.String color_class, Efl.Gfx.ColorClassLayer layer)
                {
                    //Not Implemented
                    return null;
                }

                public void SetColorClassCode(System.String color_class, Efl.Gfx.ColorClassLayer layer, System.String colorcode)
                {
                    //Not Implemented
                    return;
                }

                public System.String ColorCode
                {
                    //Not Implemented
                    get { return null; }
                    set { }
                }
            }
        }
    }
}
