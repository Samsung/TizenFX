using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            internal static class CircleWidgetList
            {
                private static HashSet<string> _circleWidgetList = new HashSet<string>();
                static CircleWidgetList()
                {
                    _circleWidgetList.Add("Efl.Ui.Wearable.CircleSlider");
                    _circleWidgetList.Add("Efl.Ui.Wearable.CircleGenlist");
                    _circleWidgetList.Add("Efl.Ui.Wearable.CircleProgressBar");
                    _circleWidgetList.Add("Efl.Ui.Wearable.CircleScroller");
                    _circleWidgetList.Add("Efl.Ui.Wearable.CircleSpinner");
                    _circleWidgetList.Add("Efl.Ui.Wearable.CircleDatePicker");
                    _circleWidgetList.Add("Efl.Ui.Wearable.CircleTimePicker");
                }

                public static bool Contains(string target)
                {
                    return _circleWidgetList.Contains(target);
                }
            }

            /// <summary>
            /// The RotaryEventManager serves functions for the global rotary event.
            /// </summary>
            public static class RotaryEventManager
            {
                static Dictionary<RotaryEventHandler, Interop.Eext.Eext_Rotary_Handler_Cb> s_rotaryEventHandlers = new Dictionary<RotaryEventHandler, Interop.Eext.Eext_Rotary_Handler_Cb>();

                /// <summary>
                /// Rotated will be triggered when the bezel of the device is rotated.
                /// </summary>
                public static event RotaryEventHandler Rotated
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

                static Dictionary<Efl.Object, RotaryEventHandler> s_rotaryObjectEventHandlers = new Dictionary<Efl.Object, RotaryEventHandler>();
                static Dictionary<Efl.Object, Interop.Eext.Eext_Rotary_Event_Cb> s_rotaryObjectEventMap = new Dictionary<Efl.Object, Interop.Eext.Eext_Rotary_Event_Cb>();

                /// <summary>
                /// Adds a handler for the rotary event on a specific Efl.Object.
                /// </summary>
                /// <param name="obj">Target Efl.Object.</param>
                /// <param name="handler">Event handler for the rotary event.</param>
                public static void AddRotaryEventHandler(this Efl.Object obj, RotaryEventHandler handler)
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
                /// <param name="obj">Target Efl.Object.</param>
                /// <param name="handler">Event handler for the rotary event.</param>
                public static void RemoveRotaryEventHandler(this Efl.Object obj, RotaryEventHandler handler)
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
                public static void RotaryEventActivate(this Efl.Object widget)
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
                public static void RotaryEventDeactivate(this Efl.Object widget)
                {
                    string type = widget.GetType().ToString();

                    if (CircleWidgetList.Contains(type))
                        Interop.Eext.eext_rotary_object_event_activated_set(((ICircleWidget)widget).CircleHandle, false);
                    else
                        Interop.Eext.eext_rotary_object_event_activated_set(widget.NativeHandle, false);
                }

                static void EnableRotaryEventHandler(Efl.Object obj)
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
                        obj.DelEvt += (s, e) => DisableRotaryEventHandler(obj, true);
                    }
                }

                static void DisableRotaryEventHandler(Efl.Object obj, bool removeHandler)
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
            public delegate void RotaryEventHandler(RotaryEventArgs args);

            /// <summary>
            /// The RotaryEventArgs serves information for the triggered rotary event.
            /// </summary>
            public class RotaryEventArgs : EventArgs
            {
                public bool IsClockwise { get; set; }
                public uint Timestamp { get; set; }
            }
        }
    }
}
