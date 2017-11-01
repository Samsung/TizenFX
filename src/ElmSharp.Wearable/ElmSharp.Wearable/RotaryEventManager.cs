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

namespace ElmSharp.Wearable
{
    /// <summary>
    /// RotaryEventManager serve functions for global Rotary event like Galaxy Gear.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public static class RotaryEventManager
    {
        static Dictionary<RotaryEventHandler, Interop.Eext.Eext_Rotary_Handler_Cb> s_rotaryEventHandlers = new Dictionary<RotaryEventHandler, Interop.Eext.Eext_Rotary_Handler_Cb>();

        /// <summary>
        /// Rotated will triggered when rotatable device like Galaxy Gear Bezel is rotated.
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
    /// RotaryEventManager serve extension functions for Rotary event to EvasObject on device like Galaxy Gear.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public static class RotaryEventExtensions
    {
        static Dictionary<EvasObject, RotaryEventHandler> s_rotaryObjectEventHandlers = new Dictionary<EvasObject, RotaryEventHandler>();
        static Dictionary<EvasObject, Interop.Eext.Eext_Rotary_Event_Cb> s_rotaryObjectEventMap = new Dictionary<EvasObject, Interop.Eext.Eext_Rotary_Event_Cb>();

        /// <summary>
        /// Add a handler for Rotary event on specific EvasObject.
        /// </summary>
        /// <param name="obj">Target EvasObject</param>
        /// <param name="handler">Event handler for Rotary event</param>
        /// <since_tizen> preview </since_tizen>
        public static void AddRotaryEventHandler(this EvasObject obj, RotaryEventHandler handler)
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
        /// Remove a handler on specific EvasObject for Rotary event.
        /// </summary>
        /// <param name="obj">Target EvasObject</param>
        /// <param name="handler">Event handler for Rotary event</param>
        /// <since_tizen> preview </since_tizen>
        public static void RemoveRotaryEventHandler(this EvasObject obj, RotaryEventHandler handler)
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
        /// Activate this circle widget can take Rotary event.
        /// </summary>
        /// <param name="widget">Target circle widget</param>
        /// <since_tizen> preview </since_tizen>
        public static void Activate(this IRotaryActionWidget widget)
        {
            Interop.Eext.eext_rotary_object_event_activated_set(widget.CircleHandle, true);
        }

        /// <summary>
        /// Deactivate this circle widget is blocked from Rotary event.
        /// </summary>
        /// <param name="widget">Target circle widget</param>
        /// <since_tizen> preview </since_tizen>
        public static void Deactivate(this IRotaryActionWidget widget)
        {
            Interop.Eext.eext_rotary_object_event_activated_set(widget.CircleHandle, false);
        }

        /// <summary>
        /// Activate this object can take Rotary event.
        /// </summary>
        /// <param name="obj">Target object</param>
        /// <since_tizen> preview </since_tizen>
        public static void Activate(this EvasObject obj)
        {
            Interop.Eext.eext_rotary_object_event_activated_set(obj, true);
        }

        /// <summary>
        /// Deactivate this object is blocked from Rotary event.
        /// </summary>
        /// <param name="obj">Target object</param>
        /// <since_tizen> preview </since_tizen>
        public static void Deactivate(this EvasObject obj)
        {
            Interop.Eext.eext_rotary_object_event_activated_set(obj, false);
        }

        static void EnableRotaryEventHandler(EvasObject obj)
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
                Interop.Eext.eext_rotary_object_event_callback_add(obj, cb, IntPtr.Zero);
                s_rotaryObjectEventMap[obj] = cb;
                obj.Deleted += (s, e) => DisableRotaryEventHandler(obj, true);
            }
        }

        static void DisableRotaryEventHandler(EvasObject obj, bool removeHandler)
        {
            Interop.Eext.Eext_Rotary_Event_Cb cb;
            if (s_rotaryObjectEventMap.TryGetValue(obj, out cb))
            {
                Interop.Eext.eext_rotary_object_event_callback_del(obj, cb);
                s_rotaryObjectEventMap.Remove(obj);
            }
            if (removeHandler && s_rotaryObjectEventHandlers.ContainsKey(obj))
            {
                s_rotaryObjectEventHandlers.Remove(obj);
            }
        }
    }

    /// <summary>
    /// Handler for Rotary event
    /// </summary>
    /// <param name="args">Rotary event information</param>
    /// <since_tizen> preview </since_tizen>
    public delegate void RotaryEventHandler(RotaryEventArgs args);

    /// <summary>
    /// RotaryEventArgs serve information for triggered rotary event.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class RotaryEventArgs : EventArgs
    {
        /// <summary>
        /// IsClockwise is true when Rotary device rotated clockwise direction or false on counter clockwise.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsClockwise { get; set; }

        /// <summary>
        /// Timestamp of rotary event
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public uint Timestamp { get; set; }
    }
}
