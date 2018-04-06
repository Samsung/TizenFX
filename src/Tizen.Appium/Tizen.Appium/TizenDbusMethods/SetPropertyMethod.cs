using System;
using Xamarin.Forms;
using Tizen.Appium.Dbus;

namespace Tizen.Appium
{
    internal class SetPropertyMethod : IDbusMethod
    {
        public string Name => MethodNames.SetProperty;

        public string Signature => "sss";

        public string ReturnSignature => "b";

        public string[] Args => new string[] { Params.ElementId, Params.PropertyName, Params.Value };

        public Arguments Run(Arguments args)
        {
            Log.Debug("SetProperty");

            var elementId = (string)args[Params.ElementId];
            var propertyName = (string)args[Params.PropertyName];
            var newValue = (string)args[Params.Value];

            var ret = new Arguments();

            var element = ElementUtils.GetElementWrapper(elementId)?.Element;
            if (element == null)
            {
                Log.Debug("Not Found Element");
                ret.SetArgument(Params.Return, false);
                return ret;
            }

            var property = element.GetType().GetProperty(propertyName);
            if (property == null)
            {
                Log.Debug(elementId + " element does not have " + propertyName + " property.");
                ret.SetArgument(Params.Return, false);
                return ret;
            }

            try
            {
                if (property.GetValue(element) is Element)
                {
                    var obj = ElementUtils.GetElementWrapper(newValue).Element;
                    if (obj != null)
                    {
                        property.SetValue(element, obj);
                    }
                }
                else
                {
                    var valueType = property.GetValue(element).GetType();
                    var value = Convert.ChangeType(newValue, valueType);
                    Log.Debug(newValue + " is converted to " + value + "(" + value.GetType() + ")");
                    property.SetValue(element, value);
                }

                ret.SetArgument(Params.Return, true);
                return ret;
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
                ret.SetArgument(Params.Return, false);
                return ret;
            }
        }
    }
}
