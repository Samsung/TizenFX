using System;
using System.Linq;
using System.Collections.Generic;
using ElmSharp;

namespace Tizen.Appium
{
    internal class EventObject
    {
        static Dictionary<string, EventObject> _eventObjectTable = new Dictionary<string, EventObject>();

        EvasObjectEvent _evaObjEvent = null;
        SmartEvent _smartEvent = null;
        Action _action;

        public string Id { get; private set; }

        public string ElementId { get; private set; }

        public EventType EventType { get; private set; }

        public string EventName { get; private set; }

        public bool Once { get; private set; }

        public static EventObject CreateEventObject(string id, string elmId, string evtName, bool once, Action action)
        {
            if (_eventObjectTable.ContainsKey(id))
            {
                return null;
            }

            try
            {
                var obj = new EventObject(id: id, elementId: elmId, eventName: evtName, once: once, action: action);
                _eventObjectTable.Add(id, obj);
                return obj;
            }
            catch (ArgumentException)
            {
                Log.Debug("Not available event name");
                return null;
            }
            catch (Exception e)
            {
                Log.Debug("It is failed to create event object" + e);
                return null;
            }
        }

        //for debugging
        public static void RemoveAll()
        {
            foreach (var item in _eventObjectTable.ToList())
            {
                (item.Value as EventObject)?.Unsubscribe();
            }
            _eventObjectTable.Clear();
            Log.Debug(" _eventObjectTable.count: " + _eventObjectTable.Count);
        }

        public static EventObject GetEventObject(string id)
        {
            if (_eventObjectTable.ContainsKey(id))
            {
                return _eventObjectTable[id];
            }
            else
            {
                return null;
            }
        }

        public static void RemoveEventObject(string id)
        {
            if (_eventObjectTable.ContainsKey(id))
            {
                _eventObjectTable.Remove(id);
            }
        }

        EventObject(string id, string elementId, string eventName, bool once, Action action)
        {
            Id = id;
            ElementId = elementId;
            EventName = eventName;
            Once = once;
            _action = action;

            if (Enum.GetNames(typeof(EvasObjectCallbackType)).Contains(eventName))
            {
                EventType = EventType.EvasObjectEvent;
            }
            else
            {
                EventType = EventType.SmartEvent;
            }
        }

        void EventHandler(object sender, EventArgs args)
        {
            _action?.Invoke();
            if (Once)
            {
                Unsubscribe();
            }
        }

        public bool Subscribe()
        {
            Log.Debug("[Subscribe] elementId: " + ElementId + ", subscriptionId: " + Id);

            var nativeView = ElementUtils.GetElementWrapper(ElementId)?.NativeView;
            if (nativeView == null)
            {
                Log.Debug("Not Supported Element");
                return false;
            }

            //TBD It conflicts with behavior of renderer.
            nativeView.PropagateEvents = true;

            if (EventType == EventType.EvasObjectEvent)
            {
                var type = EvasObjectCallbackType.Parse<EvasObjectCallbackType>(EventName);
                _evaObjEvent = new EvasObjectEvent(nativeView, type);
                _evaObjEvent.On += EventHandler;
            }
            else
            {
                _smartEvent = new SmartEvent(nativeView, EventName);
                _smartEvent.On += EventHandler;
            }

            return true;
        }

        public bool Unsubscribe()
        {
            Log.Debug("[Unsubscribe] elementId: " + ElementId + ", subscriptionId: " + Id);

            if (_evaObjEvent != null)
            {
                _evaObjEvent.On -= EventHandler;
            }

            if (_smartEvent != null)
            {
                _smartEvent.On -= EventHandler;
            }

            EventObject.RemoveEventObject(Id);

            return true;
        }
    }
}
