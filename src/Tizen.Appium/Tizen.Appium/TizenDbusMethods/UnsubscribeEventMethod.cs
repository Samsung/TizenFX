using Tizen.Appium.Dbus;

namespace Tizen.Appium
{
    internal class UnsubscribeEventMethod : IDbusMethod
    {
        public string Name => MethodNames.UnsubscribeEvent;

        public string Signature => "s";

        public string ReturnSignature => "b";

        public string[] Args => new string[] { Params.SubscriptionId };

        public Arguments Run(Arguments args)
        {
            Log.Debug("Unsubscribe");

            var id = (string)args[Params.SubscriptionId];
            var ret = new Arguments();

            var evtObj = EventObject.GetEventObject(id);

            if (evtObj == null)
            {
                Log.Debug("Not available ID:" + id + ". There is no subscriber for this id.");
                ret.SetArgument(Params.Return, false);
            }
            else
            {
                var retVal = evtObj?.Unsubscribe();
                ret.SetArgument(Params.Return, retVal);
            }

            return ret;
        }
    }
}
