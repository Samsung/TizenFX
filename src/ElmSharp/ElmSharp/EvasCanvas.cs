/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace ElmSharp
{
    /// <summary>
    /// Low-level Evas canvas functions. Subgroups will be present more than the high-level ones, though.
    /// Most of these functions deal with low-level Evas actions like:
    /// create/destroy raw canvases, not bound to any displaying engine.
    /// tell a canvas, I got focused (in a windowing context, for example).
    /// tell a canvas, a region should not be calculated anymore in rendering.
    /// tell a canvas, to render its contents immediately.
    /// Most users will be using Evas by means of the Ecore_Evas wrapper, which deals with all the above mentioned issues automatically for them. Thus, you will be looking at this section only if you're building low-level stuff.
    /// The groups within, present you functions that deal with the canvas directly too, and not yet with its objects. They are the functions you need to use at a minimum to get a working canvas.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EvasCanvas
    {
        IntPtr _handle = IntPtr.Zero;
        Dictionary<EventData, Interop.Evas.EvasCallback> _eventDatas = new Dictionary<EventData, Interop.Evas.EvasCallback>();

        internal EvasCanvas(IntPtr evasObject)
        {
            _handle = CreateHandle(evasObject);
        }

        /// <summary>
        /// Gets the current known default pointer coordinates.
        /// This function returns the current known canvas unit coordinates of the mouse pointer.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Point Pointer
        {
            get
            {
                int mx, my;
                Interop.Evas.evas_pointer_canvas_xy_get(_handle, out mx, out my);
                return new Point { X = mx, Y = my };
            }
        }

        /// <summary>
        /// Gets or sets the image cache.
        /// This function returns the image cache size of the canvas in bytes.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int ImageCacheSize
        {
            get
            {
                return Interop.Evas.evas_image_cache_get(_handle);
            }
            set
            {
                Interop.Evas.evas_image_cache_set(_handle, value);
            }
        }

        /// <summary>
        /// Flushes the image cache of the canvas.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void FlushImageCache()
        {
            Interop.Evas.evas_image_cache_flush(_handle);
        }

        /// <summary>
        /// Adds a damage rectangle.
        /// </summary>
        /// <param name="x">The rectangle's top left corner's horizontal coordinate.</param>
        /// <param name="y">The rectangle's top left corner's vertical coordinate.</param>
        /// <param name="width">The rectangle's width.</param>
        /// <param name="height">The rectangle's height.</param>
        /// <since_tizen> preview </since_tizen>
        public void AddDamageRectangle(int x, int y, int width, int height)
        {
            Interop.Evas.evas_damage_rectangle_add(_handle, x, y, width, height);
        }

        /// <summary>
        /// Adds an "obscured region" to an Evas canvas.
        /// </summary>
        /// <param name="x">The rectangle's top left corner's horizontal coordinate.</param>
        /// <param name="y">The rectangle's top left corner's vertical coordinate.</param>
        /// <param name="width">The rectangle's width.</param>
        /// <param name="height">The rectangle's height.</param>
        /// <since_tizen> preview </since_tizen>
        public void AddObscuredRectangle(int x, int y, int width, int height)
        {
            Interop.Evas.evas_obscured_rectangle_add(_handle, x, y, width, height);
        }

        /// <summary>
        /// Removes all the "obscured regions" from an Evas canvas.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void ClearObscuredRectangle()
        {
            Interop.Evas.evas_obscured_clear(_handle);
        }

        /// <summary>
        /// Adds or registers an event to a given canvas event.
        /// </summary>
        /// <param name="type">The type of event that triggers.</param>
        /// <param name="action">The action to be called when the event is triggered.</param>
        /// <since_tizen> preview </since_tizen>
        public void AddEventAction(EvasObjectCallbackType type, Action action)
        {
            if (action != null)
            {
                var eventData = new EventData(type, action);

                if (!_eventDatas.ContainsKey(eventData))
                {
                    var evasCallback = new Interop.Evas.EvasCallback((d, o, t) => action());
                    Interop.Evas.evas_event_callback_add(_handle, (Interop.Evas.ObjectCallbackType)type, evasCallback, IntPtr.Zero);
                    _eventDatas.Add(eventData, evasCallback);
                }
            }
        }

        /// <summary>
        /// Deletes an event to a given canvas event.
        /// </summary>
        /// <param name="type">The type of event that triggers.</param>
        /// <param name="action">The action to be called when the event is triggered</param>
        /// <since_tizen> preview </since_tizen>
        public void DeleteEventAction(EvasObjectCallbackType type, Action action)
        {
            if (action != null)
            {
                var eventData = new EventData(type, action);
                Interop.Evas.EvasCallback evasCallback = null;
                _eventDatas.TryGetValue(eventData, out evasCallback);

                if (evasCallback != null)
                {
                    Interop.Evas.evas_event_callback_del(_handle, (Interop.Evas.ObjectCallbackType)type, evasCallback);
                    _eventDatas.Remove(eventData);
                }
            }
        }

        /// <summary>
        /// Creates an Evas canvas handle.
        /// </summary>
        /// <param name="evasObject">EvasObject</param>
        /// <returns>Handle IntPtr.</returns>
        IntPtr CreateHandle(IntPtr evasObject)
        {
            return Interop.Evas.evas_object_evas_get(evasObject);
        }

        class EventData
        {
            public EvasObjectCallbackType Type { get; set; }
            public Action Action { get; set; }

            public EventData(EvasObjectCallbackType type, Action action)
            {
                Type = type;
                Action = action;
            }

            /// <summary>
            /// Indicates whether this instance and a specified object are equal.
            /// </summary>
            /// <param name="obj">The object to compare with the current instance.</param>
            /// <returns>
            /// true if the object and this instance are of the same type and represent the same value,
            /// otherwise false.
            /// </returns>
            public override bool Equals(object obj)
            {
                EventData e = obj as EventData;
                if (e == null)
                {
                    return false;
                }
                return (Type == e.Type) && (Action == e.Action);
            }

            public override int GetHashCode()
            {
                int hashCode = Type.GetHashCode();
                hashCode ^= Action.GetHashCode();
                return hashCode;
            }
        }
    }
}