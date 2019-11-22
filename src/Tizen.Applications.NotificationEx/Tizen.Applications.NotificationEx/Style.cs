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

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        /// <summary>
        /// The Style class.
        /// Using this class, developers are able to adjust style to items.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class Style
        {
            private Color _color;
            private Padding _padding;
            private Geometry _geometry;
            private Color _bgColor;
            internal IntPtr NativeHandle { get; set; }

            /// <summary>
            /// Initializes Style class.
            /// </summary>
            /// <param name="padding"> An item's padding. </param>
            /// <param name="color"> An item's color. </param>
            /// <param name="geometry"> An item's geometry. </param>            
            /// <since_tizen> 7 </since_tizen>
            public Style(Padding padding, Color color, Geometry geometry)
            {
                IntPtr handle;

                ErrorCode err = Interop.NotificationEx.StyleCreate(out handle,
                    color == null ? IntPtr.Zero : color.NativeHandle,
                    padding == null ? IntPtr.Zero : padding.NativeHandle,
                    geometry == null ? IntPtr.Zero : geometry.NativeHandle);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                NativeHandle = handle;
            }

            /// <summary>
            /// Initializes Style class.
            /// </summary>
            /// <param name="padding"> An item's padding. </param>
            /// <param name="color"> An item's color. </param>
            /// <param name="geometry"> An item's geometry. </param>
            /// <param name="backgroundColor"> An item's background color. </param>
            /// <since_tizen> 7 </since_tizen>
            public Style(Padding padding, Color color, Geometry geometry, Color backgroundColor) : this(padding, color, geometry)
            {
                Interop.NotificationEx.StyleSetBackgroundColor(NativeHandle,
                    backgroundColor == null ? IntPtr.Zero : backgroundColor.NativeHandle);
            }

            /// <summary>
            /// Initializes Style class.
            /// </summary>
            /// <param name="padding"> An item's padding. </param>
            /// <param name="color"> An item's color. </param>
            /// <param name="geometry"> An item's geometry. </param>
            /// <param name="backgroundImagePath"> An item's background image path. </param>
            /// <since_tizen> 7 </since_tizen>
            public Style(Padding padding, Color color, Geometry geometry, string backgroundImagePath) : this(padding, color, geometry)
            {
                Interop.NotificationEx.StyleSetBackgroundImage(NativeHandle, backgroundImagePath);
            }

            /// <summary>
            /// Initializes Style class.
            /// </summary>
            /// <param name="padding"> An item's padding. </param>
            /// <param name="color"> An item's color. </param>
            /// <param name="geometry"> An item's geometry. </param>
            /// <param name="backgroundColor"> An item's background color. </param>
            /// <param name="backgroundImagePath"> An item's background image path. </param>
            /// <since_tizen> 7 </since_tizen>
            public Style(Padding padding, Color color, Geometry geometry, Color backgroundColor, string backgroundImagePath) : this(padding, color, geometry)
            {
                Interop.NotificationEx.StyleSetBackgroundColor(NativeHandle,
                    backgroundColor == null ? IntPtr.Zero : backgroundColor.NativeHandle);

                Interop.NotificationEx.StyleSetBackgroundImage(NativeHandle, backgroundImagePath);
            }

            internal Style(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            /// <summary>
            /// Destructor of the Style class.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            ~Style()
            {
                Interop.NotificationEx.StyleDestroy(NativeHandle);
            }

            /// <summary>
            /// A padding value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public Padding Padding
            {
                get
                {
                    if (_padding != null)
                        return _padding;

                    IntPtr paddingPtr;
                    Interop.NotificationEx.StyleGetPadding(NativeHandle, out paddingPtr);
                    if (paddingPtr == IntPtr.Zero)
                        return null;
                    _padding = new Padding(paddingPtr);
                    return _padding;
                }
                private set
                {
                    if (value == null)
                        Interop.NotificationEx.StyleSetPadding(NativeHandle, IntPtr.Zero);
                    else
                        Interop.NotificationEx.StyleSetPadding(NativeHandle, value.NativeHandle);
                    _padding = value;
                }
            }

            /// <summary>
            /// A color value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public Color Color
            {
                get
                {
                    if (_color != null)
                        return _color;

                    IntPtr colorPtr;
                    Interop.NotificationEx.StyleGetColor(NativeHandle, out colorPtr);
                    if (colorPtr == IntPtr.Zero)
                        return null;
                    _color = new Color(colorPtr);
                    return _color;
                }
                private set
                {
                    if (value == null)
                        Interop.NotificationEx.StyleSetColor(NativeHandle, IntPtr.Zero);
                    else
                        Interop.NotificationEx.StyleSetColor(NativeHandle, value.NativeHandle);
                    _color = value;
                }

            }

            /// <summary>
            /// A geometry value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public Geometry Geometry
            {
                get
                {
                    if (_geometry != null)
                        return _geometry;

                    IntPtr geoPtr;
                    Interop.NotificationEx.StyleGetGeometry(NativeHandle, out geoPtr);
                    if (geoPtr == IntPtr.Zero)
                        return null;
                    _geometry = new Geometry(geoPtr);
                    return _geometry;
                }
                private set
                {
                    if (value == null)
                        Interop.NotificationEx.StyleSetGeometry(NativeHandle, IntPtr.Zero);
                    else
                        Interop.NotificationEx.StyleSetGeometry(NativeHandle, value.NativeHandle);
                    _geometry = value;
                }
            }

            /// <summary>
            /// A background color value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public Color BackgroundColor
            {
                get
                {
                    if (_bgColor != null)
                        return _bgColor;

                    IntPtr colorPtr;
                    Interop.NotificationEx.StyleGetBackgroundColor(NativeHandle, out colorPtr);
                    if (colorPtr == IntPtr.Zero)
                        return null;

                    _bgColor = new Color(colorPtr);
                    return _bgColor;
                }
                private set
                {
                    if (value == null)
                        Interop.NotificationEx.StyleSetBackgroundColor(NativeHandle, IntPtr.Zero);
                    else
                        Interop.NotificationEx.StyleSetBackgroundColor(NativeHandle, value.NativeHandle);
                    _bgColor = value;
                }
            }

            /// <summary>
            /// A background image path value.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public string BackgroundImagePath
            {
                get
                {
                    string imagePath;
                    Interop.NotificationEx.StyleGetBackgroundImage(NativeHandle, out imagePath);
                    return imagePath;
                }
                private set
                {
                    if (value == null)
                        Interop.NotificationEx.StyleSetBackgroundImage(NativeHandle, "");
                    else
                        Interop.NotificationEx.StyleSetBackgroundImage(NativeHandle, value);
                }
            }
        }
    }
}
