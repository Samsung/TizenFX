using System;
using ElmSharp;
using Tizen.Appium.Dbus;
using TSystemInfo = Tizen.System.Information;

namespace Tizen.Appium
{
    internal class GetCenterYMethod : IDbusMethod
    {
        public string Name => MethodNames.GetCenterY;

        public string Signature => "s";

        public string ReturnSignature => "i";

        public string[] Args => new string[] { Params.ElementId };

        //The element should be shown bigger than Minimun size for testing.
        int MinisumSize = 2;

        public Arguments Run(Arguments args)
        {
            Log.Debug("GetCenterY");

            var elementId = (string)args[Params.ElementId];
            var ret = new Arguments();

            var nativeView = ElementUtils.GetElementWrapper(elementId)?.NativeView;
            if (nativeView == null)
            {
                Log.Debug("Not Found Element");
                ret.SetArgument(Params.Return, -1);
                return ret;
            }

            ret.SetArgument(Params.Return, GetCenterY(nativeView));
            return ret;
        }

        int GetCenterY(EvasObject obj)
        {
            if (obj == null)
                return -1;

            int screenHeight;
            TSystemInfo.TryGetValue("http://tizen.org/feature/screen.height", out screenHeight);

            if ((obj.Geometry.Y > screenHeight) || (obj.Geometry.Y + obj.Geometry.Height) < 0)
            {
                return -1;
            }

            var x1 = Math.Max(0, obj.Geometry.Y);
            var x2 = Math.Min(screenHeight, obj.Geometry.Y + obj.Geometry.Height);

            if ((x2 - x1) < MinisumSize)
            {
                return -1;
            }
            else
            {
                return (int)((x1 + x2) / 2);
            }
        }
    }
}
