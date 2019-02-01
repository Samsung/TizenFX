/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
            /// <summary>
            /// The RotaryEventManager serves functions for the global Rotary event like Galaxy Gear.
            /// </summary>
            /// <since_tizen> preview </since_tizen>
            public static class RotaryEventManager
            {
                static Dictionary<RotaryEventHandler, Interop.Eext.Eext_Rotary_Handler_Cb> s_rotaryEventHandlers = new Dictionary<RotaryEventHandler, Interop.Eext.Eext_Rotary_Handler_Cb>();

                /// <summary>
                /// Rotated will be triggered when the rotatable device like the Galaxy Gear Bezel is rotated.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
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
            }


            /// <summary>
            /// The RotaryEventManager serves extension functions for the Rotary event to EvasObject on a device like Galaxy Gear.
            /// </summary>
            /// <since_tizen> preview </since_tizen>
            public static class RotaryEventExtensions
            {
                static Dictionary<CircleSlider, RotaryEventHandler> s_rotaryObjectEventHandlers = new Dictionary<CircleSlider, RotaryEventHandler>();
                static Dictionary<CircleSlider, Interop.Eext.Eext_Rotary_Event_Cb> s_rotaryObjectEventMap = new Dictionary<CircleSlider, Interop.Eext.Eext_Rotary_Event_Cb>();

                /// <summary>
                /// Adds a handler for the Rotary event on a specific EvasObject.
                /// </summary>
                /// <param name="obj">Target EvasObject.</param>
                /// <param name="handler">Event handler for the Rotary event.</param>
                /// <since_tizen> preview </since_tizen>
                public static void AddRotaryEventHandler(this CircleSlider obj, RotaryEventHandler handler)
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
                /// <param name="obj">Target EvasObject.</param>
                /// <param name="handler">Event handler for Rotary event.</param>
                /// <since_tizen> preview </since_tizen>
                public static void RemoveRotaryEventHandler(this CircleSlider obj, RotaryEventHandler handler)
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
                /// Activates this Circle widget that can take the Rotary event.
                /// </summary>
                /// <param name="widget">Target the Circle widget.</param>
                /// <since_tizen> preview </since_tizen>
                public static void Activate(this ICircleWidget widget)
                {
                    Interop.Eext.eext_rotary_object_event_activated_set(widget.CircleHandle, true);
                }

                /// <summary>
                /// Deactivates this circle widget that is blocked from the Rotary event.
                /// </summary>
                /// <param name="widget">Target the Circle widget.</param>
                /// <since_tizen> preview </since_tizen>
                public static void Deactivate(this ICircleWidget widget)
                {
                    Interop.Eext.eext_rotary_object_event_activated_set(widget.CircleHandle, false);
                }

                /// <summary>
                /// Activates this object that can take the Rotary event.
                /// </summary>
                /// <param name="obj">Target object.</param>
                /// <since_tizen> preview </since_tizen>
                public static void Activate(this CircleSlider obj)
                {
                    Interop.Eext.eext_rotary_object_event_activated_set(obj.CircleHandle, true);
                }

                /// <summary>
                /// Deactivates this object that is blocked from the Rotary event.
                /// </summary>
                /// <param name="obj">Target object.</param>
                /// <since_tizen> preview </since_tizen>
                public static void Deactivate(this CircleSlider obj)
                {
                    Interop.Eext.eext_rotary_object_event_activated_set(obj.CircleHandle, false);
                }

                static void EnableRotaryEventHandler(CircleSlider obj)
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
                        Interop.Eext.eext_rotary_object_event_callback_add(obj.CircleHandle, cb, IntPtr.Zero);
                        s_rotaryObjectEventMap[obj] = cb;
                        // (JWH) should be considered
                        //obj.Deleted += (s, e) => DisableRotaryEventHandler(obj, true);
                    }
                }

                static void DisableRotaryEventHandler(CircleSlider obj, bool removeHandler)
                {
                    Interop.Eext.Eext_Rotary_Event_Cb cb;
                    if (s_rotaryObjectEventMap.TryGetValue(obj, out cb))
                    {
                        Interop.Eext.eext_rotary_object_event_callback_del(obj.CircleHandle, cb);
                        s_rotaryObjectEventMap.Remove(obj);
                    }
                    if (removeHandler && s_rotaryObjectEventHandlers.ContainsKey(obj))
                    {
                        s_rotaryObjectEventHandlers.Remove(obj);
                    }
                }
            }

            /// <summary>
            /// Handler for the Rotary event.
            /// </summary>
            /// <param name="args">The Rotary event information.</param>
            /// <since_tizen> preview </since_tizen>
            public delegate void RotaryEventHandler(RotaryEventArgs args);

            /// <summary>
            /// The RotaryEventArgs serves information for the triggered Rotary event.
            /// </summary>
            /// <since_tizen> preview </since_tizen>
            public class RotaryEventArgs : EventArgs
            {
                /// <summary>
                /// IsClockwise is true when the Rotary device rotated in the clockwise direction, or false on counter clockwise.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public bool IsClockwise { get; set; }

                /// <summary>
                /// Timestamp of the Rotary event.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public uint Timestamp { get; set; }
            }
        }
    }
}
