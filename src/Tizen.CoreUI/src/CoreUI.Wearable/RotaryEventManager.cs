using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CoreUI
{
    namespace Wearable
    {
        internal static class CircleWidgetList
        {
            private static HashSet<string> _circleWidgetList = new HashSet<string>();
            static CircleWidgetList()
            {
                _circleWidgetList.Add("CoreUI.Wearable.CircleSlider");
                _circleWidgetList.Add("CoreUI.Wearable.CircleGenlist");
                _circleWidgetList.Add("CoreUI.Wearable.CircleProgressBar");
                _circleWidgetList.Add("CoreUI.Wearable.CircleScroller");
                _circleWidgetList.Add("CoreUI.Wearable.CircleSpinner");
                _circleWidgetList.Add("CoreUI.Wearable.CircleDatePicker");
                _circleWidgetList.Add("CoreUI.Wearable.CircleTimePicker");
            }

            public static bool Contains(string target)
            {
                return _circleWidgetList.Contains(target);
            }
        }

        /// <summary>
        /// The RotaryEventManager serves functions for the global rotary event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static class RotaryEventManager
        {
            static Dictionary<RotaryEventHandler, Interop.Eext.Eext_Rotary_Handler_Cb> s_rotaryEventHandlers = new Dictionary<RotaryEventHandler, Interop.Eext.Eext_Rotary_Handler_Cb>();

            /// <summary>
            /// Rotated will be triggered when the bezel of the device is rotated.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public static event RotaryEventHandler RotatedEvent
            {
                add
                {
                    if (s_rotaryEventHandlers.ContainsKey(value)) return;

                    Interop.Eext.Eext_Rotary_Handler_Cb cb = (data, infoPtr) =>
                    {
                        var info = Interop.Eext.FromIntPtr(infoPtr);
                        value.Invoke(new RotaryEventArgs
                        {
                            IsClockwise = info.Direction == Interop.Eext.Eext_Rotary_Event_Direction.Clockwise,
                            Timestamp = info.TimeStamp
                        });
                        return true;
                    };
                    Interop.Eext.eext_rotary_event_handler_add(cb, IntPtr.Zero);
                    s_rotaryEventHandlers[value] = cb;
                }

                remove
                {
                    Interop.Eext.Eext_Rotary_Handler_Cb cb;
                    if (s_rotaryEventHandlers.TryGetValue(value, out cb))
                    {
                        Interop.Eext.eext_rotary_event_handler_del(cb);
                        s_rotaryEventHandlers.Remove(value);
                    }
                }
            }

            static Dictionary<CoreUI.Object, RotaryEventHandler> s_rotaryObjectEventHandlers = new Dictionary<CoreUI.Object, RotaryEventHandler>();
            static Dictionary<CoreUI.Object, Interop.Eext.Eext_Rotary_Event_Cb> s_rotaryObjectEventMap = new Dictionary<CoreUI.Object, Interop.Eext.Eext_Rotary_Event_Cb>();

            /// <summary>
            /// Adds a handler for the rotary event on a specific CoreUI.Object.
            /// </summary>
            /// <param name="obj">Target CoreUI.Object.</param>
            /// <param name="handler">Event handler for the rotary event.</param>
            /// <since_tizen> 6 </since_tizen>
            public static void AddRotaryEventHandler(this CoreUI.Object obj, RotaryEventHandler handler)
            {
                EnableRotaryEventHandler(obj);

                if (s_rotaryObjectEventHandlers.ContainsKey(obj))
                {
                    s_rotaryObjectEventHandlers[obj] += handler;
                }
                else
                {
                    s_rotaryObjectEventHandlers[obj] = handler;
                }
            }

            /// <summary>
            /// Removes a handler on a specific EvasObject for the Rotary event.
            /// </summary>
            /// <param name="obj">Target CoreUI.Object.</param>
            /// <param name="handler">Event handler for the rotary event.</param>
            /// <since_tizen> 6 </since_tizen>
            public static void RemoveRotaryEventHandler(this CoreUI.Object obj, RotaryEventHandler handler)
            {
                if (s_rotaryObjectEventHandlers.ContainsKey(obj))
                {
                    s_rotaryObjectEventHandlers[obj] -= handler;
                    if (s_rotaryObjectEventHandlers[obj] == null)
                    {
                        DisableRotaryEventHandler(obj, false);
                        s_rotaryObjectEventHandlers.Remove(obj);
                    }
                }
            }

            /// <summary>
            /// Activates the widget that can take the rotary event.
            /// </summary>
            /// <param name="widget">The widget to activate.</param>
            /// <since_tizen> 6 </since_tizen>
            public static void RotaryEventActivate(this CoreUI.Object widget)
            {
                string type = widget.GetType().ToString();

                if (CircleWidgetList.Contains(type))
                    Interop.Eext.eext_rotary_object_event_activated_set(((ICircleWidget)widget).CircleHandle, true);
                else
                    Interop.Eext.eext_rotary_object_event_activated_set(widget.NativeHandle, true);
            }

            /// <summary>
            /// Deactivates the widget that is blocked from the rotary event.
            /// </summary>
            /// <param name="widget">The widget to deactivate.</param>
            /// <since_tizen> 6 </since_tizen>
            public static void RotaryEventDeactivate(this CoreUI.Object widget)
            {
                string type = widget.GetType().ToString();

                if (CircleWidgetList.Contains(type))
                    Interop.Eext.eext_rotary_object_event_activated_set(((ICircleWidget)widget).CircleHandle, false);
                else
                    Interop.Eext.eext_rotary_object_event_activated_set(widget.NativeHandle, false);
            }

            static void EnableRotaryEventHandler(CoreUI.Object obj)
            {
                if (!s_rotaryObjectEventMap.ContainsKey(obj))
                {
                    Interop.Eext.Eext_Rotary_Event_Cb cb = (d, o, i) =>
                    {
                        RotaryEventHandler events;
                        if (s_rotaryObjectEventHandlers.TryGetValue(obj, out events))
                        {
                            var info = Interop.Eext.FromIntPtr(i);
                            events?.Invoke(new RotaryEventArgs
                            {
                                IsClockwise = info.Direction == Interop.Eext.Eext_Rotary_Event_Direction.Clockwise,
                                Timestamp = info.TimeStamp
                            });
                        }
                        return true;
                    };
                    Interop.Eext.eext_rotary_object_event_callback_add(obj.NativeHandle, cb, IntPtr.Zero);
                    s_rotaryObjectEventMap[obj] = cb;

                    EventHandler delEventHandler = (s, e) => DisableRotaryEventHandler(obj, true);
                    CoreUI.EventCb callerCb = obj.GetInternalEventCallback(delEventHandler);
                    string key = "_EFL_EVENT_DEL";
                    obj.AddNativeEventHandler(CoreUI.Libs.Eo, key, callerCb, delEventHandler);
                }
            }

            static void DisableRotaryEventHandler(CoreUI.Object obj, bool removeHandler)
            {
                Interop.Eext.Eext_Rotary_Event_Cb cb;
                if (s_rotaryObjectEventMap.TryGetValue(obj, out cb))
                {
                    Interop.Eext.eext_rotary_object_event_callback_del(obj.NativeHandle, cb);
                    s_rotaryObjectEventMap.Remove(obj);
                }
                if (removeHandler && s_rotaryObjectEventHandlers.ContainsKey(obj))
                {
                    s_rotaryObjectEventHandlers.Remove(obj);
                }
            }
        }

        /// <summary>
        /// The Event handler for the Rotary event.
        /// </summary>
        /// <param name="args">The Rotary event argument.</param>
        /// <since_tizen> 6 </since_tizen>
        public delegate void RotaryEventHandler(RotaryEventArgs args);

        /// <summary>
        /// The RotaryEventArgs serves information for the triggered rotary event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public class RotaryEventArgs : EventArgs
        {
            /// <summary>
            /// Sets or gets the direction of clockwise.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public bool IsClockwise { get; set; }

            /// <summary>
            /// Sets or gets the value of timestamp.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public uint Timestamp { get; set; }
        }
    }
}
