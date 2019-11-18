using System;
using System.Collections.Generic;
using System.Text;
using static Interop.NotificationEx;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class Style
        {
            private Color _color;
            private Padding _padding;
            private Geometry _geometry;
            private Color _bgColor;
            internal IntPtr NativeHandle { get; set; }

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

            public Style(Padding padding, Color color, Geometry geometry, Color backgroundColor) : this(padding, color, geometry)
            {                
                Interop.NotificationEx.StyleSetBackgroundColor(NativeHandle,
                    backgroundColor == null ? IntPtr.Zero : backgroundColor.NativeHandle);
            }

            public Style(Padding padding, Color color, Geometry geometry, string backgroundImagePath) : this(padding, color, geometry)
            {                
                Interop.NotificationEx.StyleSetBackgroundImage(NativeHandle, backgroundImagePath);
            }

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

            ~Style()
            {
                Interop.NotificationEx.StyleDestroy(NativeHandle);
            }

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
