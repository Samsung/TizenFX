using Tizen.Appium.Dbus;

namespace Tizen.Appium
{
    internal class SubscribeEventMethod : IDbusMethod
    {
        public string Name => MethodNames.SubscribeEvent;

        public string Signature => "sssb";

        public string ReturnSignature => "b";

        public string[] Args => new string[] {
            Params.ElementId, Params.EventName, Params.SubscriptionId, Params.Once };

        public Arguments Run(Arguments args)
        {
            Log.Debug("SubscribeEvent");

            var elementId = (string)args[Params.ElementId];
            var eventName = (string)args[Params.EventName];
            var id = (string)args[Params.SubscriptionId];
            var once = (bool)args[Params.Once];
            var ret = new Arguments();

            Log.Debug("elementId:" + elementId + ", eventName:" + eventName + ", id:" + id + ", once:" + once);

            var evtObj = EventObject.CreateEventObject(id, elementId, eventName, once, () =>
            {
                TizenAppiumDbus.Connection.BroadcaseSignal(SignalNames.Event, args, "sss");
            });

            if (evtObj == null)
            {
                Log.Debug("Not available ID:" + id + ". it is already used for other event.");
                ret.SetArgument(Params.Return, false);
            }
            else
            {
                var retVal = evtObj.Subscribe();
                ret.SetArgument(Params.Return, retVal);
            }

            return ret;
        }
    }
}
