/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System;

namespace Tizen.NUI.BaseComponents
{

    /// <summary>
    /// A control which renders a short text string.<br>
    /// Text labels are lightweight, non-editable and do not respond to user input.<br>
    /// </summary>
    public class TextLabel : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal TextLabel(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.TextLabel_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TextLabel obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;

                    //Unreference this instance from Registry.
                    Registry.Unregister(this);

                    NDalicPINVOKE.delete_TextLabel(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        internal class Property
        {
            internal static readonly int RENDERING_BACKEND = NDalicPINVOKE.TextLabel_Property_RENDERING_BACKEND_get();
            internal static readonly int TEXT = NDalicPINVOKE.TextLabel_Property_TEXT_get();
            internal static readonly int FONT_FAMILY = NDalicPINVOKE.TextLabel_Property_FONT_FAMILY_get();
            internal static readonly int FONT_STYLE = NDalicPINVOKE.TextLabel_Property_FONT_STYLE_get();
            internal static readonly int POINT_SIZE = NDalicPINVOKE.TextLabel_Property_POINT_SIZE_get();
            internal static readonly int MULTI_LINE = NDalicPINVOKE.TextLabel_Property_MULTI_LINE_get();
            internal static readonly int HORIZONTAL_ALIGNMENT = NDalicPINVOKE.TextLabel_Property_HORIZONTAL_ALIGNMENT_get();
            internal static readonly int VERTICAL_ALIGNMENT = NDalicPINVOKE.TextLabel_Property_VERTICAL_ALIGNMENT_get();
            internal static readonly int TEXT_COLOR = NDalicPINVOKE.TextLabel_Property_TEXT_COLOR_get();
            internal static readonly int SHADOW_OFFSET = NDalicPINVOKE.TextLabel_Property_SHADOW_OFFSET_get();
            internal static readonly int SHADOW_COLOR = NDalicPINVOKE.TextLabel_Property_SHADOW_COLOR_get();
            internal static readonly int UNDERLINE_ENABLED = NDalicPINVOKE.TextLabel_Property_UNDERLINE_ENABLED_get();
            internal static readonly int UNDERLINE_COLOR = NDalicPINVOKE.TextLabel_Property_UNDERLINE_COLOR_get();
            internal static readonly int UNDERLINE_HEIGHT = NDalicPINVOKE.TextLabel_Property_UNDERLINE_HEIGHT_get();
            internal static readonly int ENABLE_MARKUP = NDalicPINVOKE.TextLabel_Property_ENABLE_MARKUP_get();
            internal static readonly int ENABLE_AUTO_SCROLL = NDalicPINVOKE.TextLabel_Property_ENABLE_AUTO_SCROLL_get();
            internal static readonly int AUTO_SCROLL_SPEED = NDalicPINVOKE.TextLabel_Property_AUTO_SCROLL_SPEED_get();
            internal static readonly int AUTO_SCROLL_LOOP_COUNT = NDalicPINVOKE.TextLabel_Property_AUTO_SCROLL_LOOP_COUNT_get();
            internal static readonly int AUTO_SCROLL_GAP = NDalicPINVOKE.TextLabel_Property_AUTO_SCROLL_GAP_get();
            internal static readonly int LINE_SPACING = NDalicPINVOKE.TextLabel_Property_LINE_SPACING_get();
            internal static readonly int UNDERLINE = NDalicPINVOKE.TextLabel_Property_UNDERLINE_get();
            internal static readonly int SHADOW = NDalicPINVOKE.TextLabel_Property_SHADOW_get();
            internal static readonly int EMBOSS = NDalicPINVOKE.TextLabel_Property_EMBOSS_get();
            internal static readonly int OUTLINE = NDalicPINVOKE.TextLabel_Property_OUTLINE_get();
            internal static readonly int PIXEL_SIZE = NDalicManualPINVOKE.TextLabel_Property_PIXEL_SIZE_get();
            internal static readonly int ELLIPSIS = NDalicManualPINVOKE.TextLabel_Property_ELLIPSIS_get();
            internal static readonly int AUTO_SCROLL_STOP_MODE = NDalicManualPINVOKE.TextLabel_Property_AUTO_SCROLL_STOP_MODE_get();
            internal static readonly int AUTO_SCROLL_LOOP_DELAY = NDalicManualPINVOKE.TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get();

        }

        /// <summary>
        /// Creates the TextLabel control.
        /// </summary>
        public TextLabel() : this(NDalicPINVOKE.TextLabel_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Creates the TextLabel control.
        /// </summary>
        /// <param name="text">The text to display</param>
        public TextLabel(string text) : this(NDalicPINVOKE.TextLabel_New__SWIG_1(text), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        internal TextLabel(TextLabel handle) : this(NDalicPINVOKE.new_TextLabel__SWIG_1(TextLabel.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        [Obsolete("Please do not use! this will be deprecated")]
        public new static TextLabel DownCast(BaseHandle handle)
        {
            TextLabel ret = new TextLabel(NDalicPINVOKE.TextLabel_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Text property.<br>
        /// The text to display in UTF-8 format.<br>
        /// </summary>
        public string Text
        {
            get
            {
                string temp;
                GetProperty(TextLabel.Property.TEXT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.TEXT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// FontFamily property.<br>
        /// The requested font family to use.<br>
        /// </summary>
        public string FontFamily
        {
            get
            {
                string temp;
                GetProperty(TextLabel.Property.FONT_FAMILY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.FONT_FAMILY, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// FontStyle property.<br>
        /// The requested font style to use.<br>
        /// </summary>
        public PropertyMap FontStyle
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextLabel.Property.FONT_STYLE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.FONT_STYLE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// PointSize property.<br>
        /// The size of font in points.<br>
        /// </summary>
        public float PointSize
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextLabel.Property.POINT_SIZE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.POINT_SIZE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// MultiLine property.<br>
        /// The single-line or multi-line layout option.<br>
        /// </summary>
        public bool MultiLine
        {
            get
            {
                bool temp = false;
                GetProperty(TextLabel.Property.MULTI_LINE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.MULTI_LINE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// HorizontalAlignment property.<br>
        /// The line horizontal alignment.<br>
        /// </summary>
        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                string temp;
                if (GetProperty(TextLabel.Property.HORIZONTAL_ALIGNMENT).Get(out temp) == false)
                {
                    NUILog.Error("HorizontalAlignment get error!");
                }
                switch (temp)
                {
                    case "BEGIN":
                        return HorizontalAlignment.Begin;
                    case "CENTER":
                        return HorizontalAlignment.Center;
                    case "END":
                        return HorizontalAlignment.End;
                    default:
                        return HorizontalAlignment.Begin;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case HorizontalAlignment.Begin:
                    {
                        valueToString = "BEGIN";
                        break;
                    }
                    case HorizontalAlignment.Center:
                    {
                        valueToString = "CENTER";
                        break;
                    }
                    case HorizontalAlignment.End:
                    {
                        valueToString = "END";
                        break;
                    }
                    default:
                    {
                        valueToString = "BEGIN";
                        break;
                    }
                }
                SetProperty(TextLabel.Property.HORIZONTAL_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        }

        /// <summary>
        /// VerticalAlignment property.<br>
        /// The line vertical alignment.<br>
        /// </summary>
        public VerticalAlignment VerticalAlignment
        {
            get
            {
                string temp;
                if (GetProperty(TextLabel.Property.VERTICAL_ALIGNMENT).Get(out temp) == false)
                {
                    NUILog.Error("VerticalAlignment get error!");
                }

                switch (temp)
                {
                    case "TOP":
                        return VerticalAlignment.Top;
                    case "CENTER":
                        return VerticalAlignment.Center;
                    case "BOTTOM":
                        return VerticalAlignment.Bottom;
                    default:
                        return VerticalAlignment.Bottom;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case VerticalAlignment.Top:
                    {
                        valueToString = "TOP";
                        break;
                    }
                    case VerticalAlignment.Center:
                    {
                        valueToString = "CENTER";
                        break;
                    }
                    case VerticalAlignment.Bottom:
                    {
                        valueToString = "BOTTOM";
                        break;
                    }
                    default:
                    {
                        valueToString = "BOTTOM";
                        break;
                    }
                }
                SetProperty(TextLabel.Property.VERTICAL_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        }

        /// <summary>
        /// TextColor property.<br>
        /// The color of the text.<br>
        /// </summary>
        public Color TextColor
        {
            get
            {
                Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextLabel.Property.TEXT_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.TEXT_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// ShadowOffset property.<br>
        /// The drop shadow offset 0 indicates no shadow.<br>
        /// </summary>
        public Vector2 ShadowOffset
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(TextLabel.Property.SHADOW_OFFSET).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.SHADOW_OFFSET, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// ShadowColor property.<br>
        /// The color of a drop shadow.<br>
        /// </summary>
        public Vector4 ShadowColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextLabel.Property.SHADOW_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.SHADOW_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// UnderlineEnabled property.<br>
        /// The underline enabled flag.<br>
        /// </summary>
        public bool UnderlineEnabled
        {
            get
            {
                bool temp = false;
                GetProperty(TextLabel.Property.UNDERLINE_ENABLED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.UNDERLINE_ENABLED, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// UnderlineColor property.<br>
        /// Overrides the underline height from font metrics.<br>
        /// </summary>
        public Vector4 UnderlineColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(TextLabel.Property.UNDERLINE_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.UNDERLINE_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// UnderlineHeight property.<br>
        /// Overrides the underline height from font metrics.<br>
        /// </summary>
        public float UnderlineHeight
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextLabel.Property.UNDERLINE_HEIGHT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.UNDERLINE_HEIGHT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// EnableMarkup property.<br>
        /// Whether the mark-up processing is enabled.<br>
        /// </summary>
        public bool EnableMarkup
        {
            get
            {
                bool temp = false;
                GetProperty(TextLabel.Property.ENABLE_MARKUP).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.ENABLE_MARKUP, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// EnableAutoScroll property.<br>
        /// Starts or stops auto scrolling.<br>
        /// </summary>
        public bool EnableAutoScroll
        {
            get
            {
                bool temp = false;
                GetProperty(TextLabel.Property.ENABLE_AUTO_SCROLL).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.ENABLE_AUTO_SCROLL, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// AutoScrollSpeed property.<br>
        /// Sets the speed of scrolling in pixels per second.<br>
        /// </summary>
        public int AutoScrollSpeed
        {
            get
            {
                int temp = 0;
                GetProperty(TextLabel.Property.AUTO_SCROLL_SPEED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.AUTO_SCROLL_SPEED, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// AutoScrollLoopCount property.<br>
        /// Number of complete loops when scrolling enabled.<br>
        /// </summary>
        public int AutoScrollLoopCount
        {
            get
            {
                int temp = 0;
                GetProperty(TextLabel.Property.AUTO_SCROLL_LOOP_COUNT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.AUTO_SCROLL_LOOP_COUNT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// AutoScrollGap property.<br>
        /// Gap before scrolling wraps.<br>
        /// </summary>
        public float AutoScrollGap
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextLabel.Property.AUTO_SCROLL_GAP).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.AUTO_SCROLL_GAP, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// LineSpacing property.<br>
        /// The default extra space between lines in points.<br>
        /// </summary>
        public float LineSpacing
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextLabel.Property.LINE_SPACING).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.LINE_SPACING, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Underline property.<br>
        /// The default underline parameters.<br>
        /// </summary>
        public PropertyMap Underline
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextLabel.Property.UNDERLINE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.UNDERLINE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Shadow property.<br>
        /// The default shadow parameters.<br>
        /// </summary>
        public PropertyMap Shadow
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TextLabel.Property.SHADOW).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.SHADOW, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Emboss property.<br>
        /// The default emboss parameters.<br>
        /// </summary>
        public string Emboss
        {
            get
            {
                string temp;
                GetProperty(TextLabel.Property.EMBOSS).Get( out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.EMBOSS, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Outline property.<br>
        /// The default outline parameters.<br>
        /// </summary>
        public string Outline
        {
            get
            {
                string temp;
                GetProperty(TextLabel.Property.OUTLINE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.OUTLINE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// PixelSize property.<br>
        /// The size of font in pixels.<br>
        /// </summary>
        public float PixelSize
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextLabel.Property.PIXEL_SIZE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.PIXEL_SIZE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Ellipsis property.<br>
        /// Enable or disable the ellipsis.<br>
        /// </summary>
        public bool Ellipsis
        {
            get
            {
                bool temp = false;
                GetProperty(TextLabel.Property.ELLIPSIS).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.ELLIPSIS, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// AutoScrollLoopDelay property.<br>
        /// do something.<br>
        /// </summary>
        public float AutoScrollLoopDelay
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TextLabel.Property.AUTO_SCROLL_LOOP_DELAY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextLabel.Property.AUTO_SCROLL_LOOP_DELAY, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// AutoScrollStopMode property.<br>
        /// do something.<br>
        /// </summary>
        public AutoScrollStopMode AutoScrollStopMode
        {
            get
            {
                string temp;
                if(GetProperty(TextLabel.Property.AUTO_SCROLL_STOP_MODE).Get(out temp) == false)
                {
                    NUILog.Error("AutoScrollStopMode get error!");
                }
                switch (temp)
                {
                    case "FINISH_LOOP":
                    return AutoScrollStopMode.FinishLoop;
                    case "IMMEDIATE":
                    return AutoScrollStopMode.Immediate;
                    default:
                    return AutoScrollStopMode.FinishLoop;
                }
            }
            set
            {
                SetProperty(TextLabel.Property.AUTO_SCROLL_STOP_MODE, new Tizen.NUI.PropertyValue((int)value));
            }
        }

    }
}
