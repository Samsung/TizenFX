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
using System.Collections;
using System.Collections.Generic;

namespace ElmSharp
{
    /// <summary>
    /// The EdjeObject is a class that the evas object exists in.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EdjeObject
    {
        IntPtr _edjeHandle;
        Dictionary<SignalData, Interop.Elementary.Edje_Signal_Cb> _signalDatas = new Dictionary<SignalData, Interop.Elementary.Edje_Signal_Cb>();

        internal EdjeObject(IntPtr handle)
        {
            _edjeHandle = handle;
        }

        /// <summary>
        /// Checks whether an edje part exists in a given edje object's group definition.
        /// This function returns if a given part exists in the edje group bound to object obj
        /// </summary>
        /// <remarks>This call is useful, for example, when one could expect a given GUI element, depending on the theme applied to object.</remarks>
        /// <param name="part">The part's name to check for existence in object's group.</param>
        /// <returns>TRUE, if the edje part exists in the object's group, otherwise FALSE.</returns>
        /// <since_tizen> preview </since_tizen>
        public EdjeTextPartObject this[string part]
        {
            get
            {
                if (Interop.Elementary.edje_object_part_exists(_edjeHandle, part))
                {
                    return new EdjeTextPartObject(_edjeHandle, part);
                }
                return null;
            }
        }

        /// <summary>
        /// Sends or emits an edje signal to a given edje object.
        /// </summary>
        /// <param name="emission">The signal's "emission" string</param>
        /// <param name="source">The signal's "source" string</param>
        /// <since_tizen> preview </since_tizen>
        public void EmitSignal(string emission, string source)
        {
            Interop.Elementary.edje_object_signal_emit(_edjeHandle, emission, source);
        }

        /// <summary>
        /// Deletes the object Color class.
        /// This function deletes any values at the object level for the specified object and Color class.
        /// </summary>
        /// <remarks>Deleting the Color class defined in the theme file.</remarks>
        /// <param name="part">The Color class to be deleted.</param>
        /// <since_tizen> preview </since_tizen>
        public void DeleteColorClass(string part)
        {
            Interop.Elementary.edje_object_color_class_del(_edjeHandle, part);
        }

        /// <summary>
        /// Sets the object Color class.
        /// </summary>
        /// <param name="colorClass">The Color class name.</param>
        /// <param name="red">The object red value.</param>
        /// <param name="green">The object green value.</param>
        /// <param name="blue">The object blue value.</param>
        /// <param name="alpha">The object alpha value.</param>
        /// <param name="outlineRed">The outline red value.</param>
        /// <param name="outlineGreen">The outline green value.</param>
        /// <param name="outlineBlue">The outline blue value.</param>
        /// <param name="outlineAlpha">The outline alpha value.</param>
        /// <param name="shadowRed">The shadow red value.</param>
        /// <param name="shadowGreen">The shadow green value.</param>
        /// <param name="shadowBlue">The shadow blue value.</param>
        /// <param name="shadowAlpha">The shadow alpha value.</param>
        /// <returns>True if succeeds, otherwise False.</returns>
        /// <since_tizen> preview </since_tizen>
        public bool SetColorClass(string colorClass, int red, int green, int blue, int alpha, int outlineRed, int outlineGreen, int outlineBlue, int outlineAlpha,
            int shadowRed, int shadowGreen, int shadowBlue, int shadowAlpha)
        {
            return Interop.Elementary.edje_object_color_class_set(_edjeHandle, colorClass, red, green, blue, alpha, outlineRed, outlineGreen, outlineBlue, outlineAlpha,
                shadowRed, shadowGreen, shadowBlue, shadowAlpha);
        }

        /// <summary>
        /// Gets the object Color class.
        /// </summary>
        /// <param name="colorClass">The Color class name.</param>
        /// <param name="red">The object red value.</param>
        /// <param name="green">The object green value.</param>
        /// <param name="blue">The object blue value.</param>
        /// <param name="alpha">The object alpha value.</param>
        /// <param name="outlineRed">The outline red value.</param>
        /// <param name="outlineGreen">The outline green value.</param>
        /// <param name="outlineBlue">The outline blue value.</param>
        /// <param name="outlineAlpha">The outline alpha value.</param>
        /// <param name="shadowRed">The shadow red value.</param>
        /// <param name="shadowGreen">The shadow green value.</param>
        /// <param name="shadowBlue">The shadow blue value.</param>
        /// <param name="shadowAlpha">The shadow alpha value.</param>
        /// <returns>True if succeeds, otherwise False.</returns>
        /// <since_tizen> preview </since_tizen>
        public bool GetColorClass(string colorClass, out int red, out int green, out int blue, out int alpha, out int outlineRed, out int outlineGreen, out int outlineBlue, out int outlineAlpha,
            out int shadowRed, out int shadowGreen, out int shadowBlue, out int shadowAlpha)
        {
            return Interop.Elementary.edje_object_color_class_get(_edjeHandle, colorClass, out red, out green, out blue, out alpha, out outlineRed, out outlineGreen, out outlineBlue, out outlineAlpha,
                out shadowRed, out shadowGreen, out shadowBlue, out shadowAlpha);
        }

        /// <summary>
        /// Sets the Edje text class.
        /// </summary>
        /// <param name="textClass">The text class name.</param>
        /// <param name="font">Font name.</param>
        /// <param name="fontSize">Font size.</param>
        /// <returns>True if succeeds, otherwise False.</returns>
        /// <since_tizen> preview </since_tizen>
        public bool SetTextClass(string textClass, string font, int fontSize)
        {
            return Interop.Elementary.edje_object_text_class_set(_edjeHandle, textClass, font, fontSize);
        }

        /// <summary>
        /// Gets the Edje text class.
        /// </summary>
        /// <param name="textClass">The text class name.</param>
        /// <param name="font">Font name.</param>
        /// <param name="fontSize">Font size.</param>
        /// <returns>True if succeeds, otherwise False.</returns>
        /// <since_tizen> preview </since_tizen>
        public bool GetTextClass(string textClass, out string font, out int fontSize)
        {
            return Interop.Elementary.edje_object_text_class_get(_edjeHandle, textClass, out font, out fontSize);
        }

        /// <summary>
        /// Adds Action for an arriving edje signal, emitted by a given Ejde object.
        /// </summary>
        /// <param name="emission">The signal's "emission" string.</param>
        /// <param name="source">The signal's "source" string.</param>
        /// <param name="action">The action to be executed when the signal is emitted.</param>
        /// <since_tizen> preview </since_tizen>
        public void AddSignalAction(string emission, string source, Action<string, string> action)
        {
            if (emission != null && source != null && action != null)
            {
                var signalData = new SignalData(emission, source, action);
                if (!_signalDatas.ContainsKey(signalData))
                {
                    var signalCallback = new Interop.Elementary.Edje_Signal_Cb((d, o, e, s) =>
                    {
                        action(e, s);
                    });

                    Interop.Elementary.edje_object_signal_callback_add(_edjeHandle, emission, source, signalCallback, IntPtr.Zero);
                    _signalDatas.Add(signalData, signalCallback);
                }
            }
        }

        /// <summary>
        /// Deletes a signal-triggered action from an object.
        /// </summary>
        /// <param name="emission">The signal's "emission" string.</param>
        /// <param name="source">The signal's "source" string.</param>
        /// <param name="action">The action to be executed when the signal is emitted.</param>
        /// <since_tizen> preview </since_tizen>
        public void DeleteSignalAction(string emission, string source, Action<string, string> action)
        {
            if (emission != null && source != null && action != null)
            {
                var signalData = new SignalData(emission, source, action);

                Interop.Elementary.Edje_Signal_Cb signalCallback = null;
                _signalDatas.TryGetValue(signalData, out signalCallback);

                if (signalCallback != null)
                {
                    Interop.Elementary.edje_object_signal_callback_del(_edjeHandle, emission, source, signalCallback);
                    _signalDatas.Remove(signalData);
                }
            }
        }

        class SignalData : IEquatable<SignalData>
        {
            public string Emission { get; set; }
            public string Source { get; set; }

            public Action<string, string> Action { get; set; }

            public SignalData(string emission, string source, Action<string, string> action)
            {
                Emission = emission;
                Source = source;
                Action = action;
            }

            public override bool Equals(object other)
            {
                return Equals(other as SignalData);
            }

            public bool Equals(SignalData other) {
                if (other == null)
                {
                    return false;
                }
                return (Emission == other.Emission) && (Source == other.Source) && (Action == other.Action);
            }

            public override int GetHashCode()
            {
                int hashCode = Emission.GetHashCode();
                hashCode ^= Source.GetHashCode();
                hashCode ^= Action.GetHashCode();
                return hashCode;
            }
        }
    }

    /// <summary>
    /// The EdjeTextPartObject is a class dealing with parts of type text.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EdjeTextPartObject
    {
        string _part;
        IntPtr _edjeHandle;

        internal EdjeTextPartObject(IntPtr edjeHandle, string part)
        {
            _edjeHandle = edjeHandle;
            _part = part;
        }

        /// <summary>
        /// Gets the name of the EdjeTextPartObject.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Name { get { return _part; } }

        /// <summary>
        /// Gets or sets the text for an object part.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string Text
        {
            get
            {
                return Interop.Elementary.edje_object_part_text_get(_edjeHandle, _part);
            }
            set
            {
                Interop.Elementary.edje_object_part_text_set(_edjeHandle, _part, value);
            }
        }

        /// <summary>
        /// Sets or gets the style of the object part.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string TextStyle
        {
            get
            {
                return Interop.Elementary.edje_object_part_text_style_user_peek(_edjeHandle, _part);
            }
            set
            {
                if (value == null)
                {
                    Interop.Elementary.edje_object_part_text_style_user_pop(_edjeHandle, _part);
                }
                else
                {
                    Interop.Elementary.edje_object_part_text_style_user_push(_edjeHandle, _part, value);
                }
            }
        }

        /// <summary>
        /// Gets the geometry of a given edje part, in a given edje object's group definition, relative to the object's area.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Rect Geometry
        {
            get
            {
                int x, y, w, h;
                Interop.Elementary.edje_object_part_geometry_get(_edjeHandle, _part, out x, out y, out w, out h);
                return new Rect(x, y, w, h);
            }
        }

        /// <summary>
        /// Gets the native width and height.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Size TextBlockNativeSize
        {
            get
            {
                int w;
                int h;
                IntPtr part = Interop.Elementary.edje_object_part_object_get(_edjeHandle, _part);
                Interop.Evas.evas_object_textblock_size_native_get(part, out w, out h);
                return new Size(w, h);
            }
        }

        /// <summary>
        /// Gets the formatted width and height.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Size TextBlockFormattedSize
        {
            get
            {
                int w;
                int h;
                IntPtr part = Interop.Elementary.edje_object_part_object_get(_edjeHandle, _part);
                Interop.Evas.evas_object_textblock_size_formatted_get(part, out w, out h);
                return new Size(w, h);
            }
        }
    }
}