namespace Tizen.Appium.Dbus
{
    internal class DbusNames
    {
        public static readonly string BusName = "org.tizen.appium";
        public static readonly string ObjectPath = "/org/tizen/appium";
        public static readonly string InterfaceName = "org.tizen.appium";
    }

    internal class MethodNames
    {
        public static readonly string GetCenterX = "GetCenterX";
        public static readonly string GetCenterY = "GetCenterY";
        public static readonly string GetX = "GetX";
        public static readonly string GetY = "GetY";
        public static readonly string GetWidth = "GetWidth";
        public static readonly string GetHeight = "GetHeight";
        public static readonly string GetText = "GetText";
        public static readonly string GetProperty = "GetProperty";
        public static readonly string SetProperty = "SetProperty";
        public static readonly string SubscribeEvent = "SubscribeEvent";
        public static readonly string UnsubscribeEvent = "UnsubscribeEvent";
        public static readonly string ResetEvent = "ResetEvent";
    }

    internal class SignalNames
    {
        public static readonly string Event = "Event";
    }

    internal class Params
    {
        public static readonly string ElementId = "elementId";
        public static readonly string PropertyName = "propertyName";
        public static readonly string EventName = "eventName";
        public static readonly string SubscriptionId = "subscriptionId";
        public static readonly string Value = "value";
        public static readonly string Once = "once";
        public static readonly string Return = "return";
    }
}
