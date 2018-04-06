using System;
using Xamarin.Forms;
using Tizen.Appium.Dbus;

namespace Tizen.Appium
{
    internal class GetPropertyMethod : IDbusMethod
    {
        public string Name => MethodNames.GetProperty;

        public string Signature => "ss";

        public string ReturnSignature => "s";

        public string[] Args => new string[] { Params.ElementId, Params.PropertyName };

        public Arguments Run(Arguments args)
        {
            Log.Debug("GetProperty");

            var elementId = (string)args[Params.ElementId];
            var propertyName = (string)args[Params.PropertyName];

            var ret = new Arguments();

            var element = ElementUtils.GetElementWrapper(elementId)?.Element;
            if (element == null)
            {
                Log.Debug("Not Found Element");
                ret.SetArgument(Params.Return, string.Empty);
                return ret;
            }

            var value = element.GetType().GetProperty(propertyName)?.GetValue(element);
            if (value != null)
            {
                if (value is Element)
                {
                    var id = ElementUtils.GetIdByElement((Element)value);
                    if (!String.IsNullOrEmpty(id))
                    {
                        value = id;
                    }
                }

                ret.SetArgument(Params.Return, value.ToString());
                return ret;
            }

            Log.Debug(elementId + " element does not have " + propertyName + " property.");
            ret.SetArgument(Params.Return, String.Empty);

            return ret;
        }
    }
}
