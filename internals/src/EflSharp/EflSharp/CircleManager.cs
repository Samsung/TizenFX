using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            public sealed class CircleManager
            {
                private static CircleManager instance = null;
                System.Collections.Generic.List<CircleSurface> surfaces = new System.Collections.Generic.List<CircleSurface>();
                private Efl.Ui.Wearable.CircleSurface sur = null;

                private CircleManager()
                {

                }
                public static CircleManager Instance
                {
                    get
                    {
                        if (instance == null)
                        {
                            instance = new CircleManager();
                        }
                        return instance;
                    }
                }

                public void RegisterCircleObject(Efl.Object target, ICircleWidget circleObject)
                {
                    if (this.sur == null)
                    {
                        string type = target.GetType().ToString();
                        if (type.CompareTo("Efl.Ui.Win") == 0)
                            sur = new Efl.Ui.Wearable.CircleSurface((Efl.Ui.Win)target);
                    }

                    //Link circle object to surface
                    Interop.Eext.eext_circle_object_connect(sur.Handle, circleObject.CircleHandle);
                }

                public void UnRegisterCircleObject(CircleSurface sur, ICircleWidget circleObject)
                {
                    //Unlink circle object to surface
                    //Interop.Eext.eext_circle_object_disconnect(sur.Handle, circleObject.CircleHandle);
                }
            }
        }
    }
}
