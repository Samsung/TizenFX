/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Class with the text and style parameters to be rendered into a pixel buffer.
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RendererParameters : Disposable
    {
        internal RendererParameters(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RendererParameters obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.RendererParameters.delete_RendererParameters(swigCPtr);
        }

        /// <summary>
        /// Construct RendererParameters
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RendererParameters() : this(Interop.RendererParameters.new_RendererParameters__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The text to be rendered
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text
        {
            set
            {
                Interop.RendererParameters.RendererParameters_text_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.RendererParameters_text_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The horizontal alignment: one of HorizontalAlignment.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment HorizontalAlignment
        {
            set
            {
                string alignment = "begin";
                switch(value)
                {
                    case HorizontalAlignment.Begin: {
                        alignment = "begin";
                        break;
                    }
                    case HorizontalAlignment.Center: {
                        alignment = "center";
                        break;
                    }
                    case HorizontalAlignment.End: {
                        alignment = "end";
                        break;
                    }
                    default : {
                        break;
                    }
                }
                Interop.RendererParameters.RendererParameters_horizontalAlignment_set(swigCPtr, alignment);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.RendererParameters_horizontalAlignment_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                HorizontalAlignment alignment = HorizontalAlignment.Begin;
                switch(ret)
                {
                    case "begin": {
                        alignment = HorizontalAlignment.Begin;
                        break;
                    }
                    case "center": {
                        alignment = HorizontalAlignment.Center;
                        break;
                    }
                    case "end": {
                        alignment = HorizontalAlignment.End;
                        break;
                    }
                    default : {
                        break;
                    }
                }
                return alignment;
            }
        }

        /// <summary>
        /// The vertical alignment: one of VerticalAlignment.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment VerticalAlignment
        {
            set
            {
                string alignment = "top";
                switch(value)
                {
                    case VerticalAlignment.Top: {
                        alignment = "top";
                        break;
                    }
                    case VerticalAlignment.Center: {
                        alignment = "center";
                        break;
                    }
                    case VerticalAlignment.Bottom: {
                        alignment = "bottom";
                        break;
                    }
                    default : {
                        break;
                    }
                }
                Interop.RendererParameters.RendererParameters_verticalAlignment_set(swigCPtr, alignment);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.RendererParameters_verticalAlignment_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                VerticalAlignment alignment = VerticalAlignment.Top;
                switch(ret)
                {
                    case "top": {
                        alignment = VerticalAlignment.Top;
                        break;
                    }
                    case "center": {
                        alignment = VerticalAlignment.Center;
                        break;
                    }
                    case "bottom": {
                        alignment = VerticalAlignment.Bottom;
                        break;
                    }
                    default : {
                        break;
                    }
                }
                return alignment;
            }
        }

        /// <summary>
        /// The font's family.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            set
            {
                Interop.RendererParameters.RendererParameters_fontFamily_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.RendererParameters_fontFamily_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The font's weight: one of {"thin", "ultraLight", "extraLight", "light", "demiLight", "semiLight", "book", "normal", "regular", "medium", "demiBold", "semiBold", "bold", "ultraBold", "extraBold", "black", "heavy", "extraBlack"}.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontWeight
        {
            set
            {
                Interop.RendererParameters.RendererParameters_fontWeight_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.RendererParameters_fontWeight_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The font's width: one of {"ultraCondensed", "extraCondensed", "condensed", "semiCondensed", "normal", "semiExpanded", "expanded", "extraExpanded", "ultraExpanded"}.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontWidth
        {
            set
            {
                Interop.RendererParameters.RendererParameters_fontWidth_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.RendererParameters_fontWidth_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The font's slant. one of {"normal", "roman", "italic", "oblique"}
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontSlant
        {
            set
            {
                Interop.RendererParameters.RendererParameters_fontSlant_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.RendererParameters_fontSlant_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The type of layout: one of TextLayout {"singleLine", "multiLine", "circular"}
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLayout Layout
        {
            set
            {
                string textLayout = "singleLine";
                switch(value)
                {
                    case TextLayout.SingleLine: {
                        textLayout = "singleLine";
                        break;
                    }
                    case TextLayout.MultiLine: {
                        textLayout = "multiLine";
                        break;
                    }
                    case TextLayout.Circular: {
                        textLayout = "circular";
                        break;
                    }
                    default : {
                        break;
                    }
                }
                Interop.RendererParameters.RendererParameters_layout_set(swigCPtr, textLayout);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.RendererParameters_layout_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                TextLayout textLayout = TextLayout.SingleLine;
                switch(ret)
                {
                    case "singleLine": {
                        textLayout = TextLayout.SingleLine;
                        break;
                    }
                    case "multiLine": {
                        textLayout = TextLayout.MultiLine;
                        break;
                    }
                    case "circular": {
                        textLayout = TextLayout.Circular;
                        break;
                    }
                    default : {
                        break;
                    }
                }
                return textLayout;
            }
        }

        /// <summary>
        /// The text alignment within the arc: one of CircularAlignment. The @p horizontalAlignment and @p verticalAlignment can be used to align the text within the text area.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularAlignment CircularAlignment
        {
            set
            {
                string alignment = "begin";
                switch(value)
                {
                    case CircularAlignment.Begin: {
                        alignment = "begin";
                        break;
                    }
                    case CircularAlignment.Center: {
                        alignment = "center";
                        break;
                    }
                    case CircularAlignment.End: {
                        alignment = "end";
                        break;
                    }
                    default : {
                        break;
                    }
                }
                Interop.RendererParameters.RendererParameters_circularAlignment_set(swigCPtr, alignment);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.RendererParameters_circularAlignment_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                CircularAlignment alignment = CircularAlignment.Begin;
                switch(ret)
                {
                    case "begin": {
                        alignment = CircularAlignment.Begin;
                        break;
                    }
                    case "center": {
                        alignment = CircularAlignment.Center;
                        break;
                    }
                    case "end": {
                        alignment = CircularAlignment.End;
                        break;
                    }
                    default : {
                        break;
                    }
                }
                return alignment;
            }
        }

        /// <summary>
        /// The default text's color. Default is white.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 TextColor
        {
            set
            {
                Interop.RendererParameters.RendererParameters_textColor_set(swigCPtr, Vector4.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Vector4 ret = new Vector4(Interop.RendererParameters.RendererParameters_textColor_get(swigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The font's size (in points).
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float FontSize
        {
            set
            {
                Interop.RendererParameters.RendererParameters_fontSize_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.RendererParameters.RendererParameters_fontSize_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The width in pixels of the boundaries where the text is going to be laid-out.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TextWidth
        {
            set
            {
                Interop.RendererParameters.RendererParameters_textWidth_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.RendererParameters.RendererParameters_textWidth_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The height in pixels of the boundaries where the text is going to be laid-out.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TextHeight
        {
            set
            {
                Interop.RendererParameters.RendererParameters_textHeight_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.RendererParameters.RendererParameters_textHeight_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The radius in pixels of the circular text.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Radius
        {
            set
            {
                Interop.RendererParameters.RendererParameters_radius_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.RendererParameters.RendererParameters_radius_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The begin angle in degrees of the text area on the circle. The top of the circle is 0°, the right side 90°, the bottom 180° and the left 270°.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BeginAngle
        {
            set
            {
                Interop.RendererParameters.RendererParameters_beginAngle_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.RendererParameters.RendererParameters_beginAngle_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The increment angle in degrees of the text area on the circle. The @p incrementAngle defines a direction. If positive, the text will be laid out clockwise.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float IncrementAngle
        {
            set
            {
                Interop.RendererParameters.RendererParameters_incrementAngle_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.RendererParameters.RendererParameters_incrementAngle_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Whether the ellipsis layout option is enabled.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EllipsisEnabled
        {
            set
            {
                Interop.RendererParameters.RendererParameters_ellipsisEnabled_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                bool ret = Interop.RendererParameters.RendererParameters_ellipsisEnabled_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Whether the mark-up processor is enabled.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MarkupEnabled
        {
            set
            {
                Interop.RendererParameters.RendererParameters_markupEnabled_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                bool ret = Interop.RendererParameters.RendererParameters_markupEnabled_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Whether a default color has been set.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsTextColorSet
        {
            set
            {
                Interop.RendererParameters.RendererParameters_isTextColorSet_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                bool ret = Interop.RendererParameters.RendererParameters_isTextColorSet_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

    }

    /// <summary>
    /// Class with info of the embedded items layout.
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EmbeddedItemInfo : Disposable
    {

        internal EmbeddedItemInfo(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(EmbeddedItemInfo obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.EmbeddedItemInfo.delete_EmbeddedItemInfo(swigCPtr);
        }

        /// <summary>
        /// Construct EmbeddedItemInfo
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EmbeddedItemInfo() : this(Interop.EmbeddedItemInfo.new_EmbeddedItemInfo__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Index to the character within the string.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint CharacterIndex
        {
            set
            {
                Interop.EmbeddedItemInfo.EmbeddedItemInfo_characterIndex_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.EmbeddedItemInfo.EmbeddedItemInfo_characterIndex_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Index to the glyph
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GlyphIndex
        {
            set
            {
                Interop.EmbeddedItemInfo.EmbeddedItemInfo_glyphIndex_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.EmbeddedItemInfo.EmbeddedItemInfo_glyphIndex_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The layout position within the buffer (top, left corner).
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Position
        {
            set
            {
                Interop.EmbeddedItemInfo.EmbeddedItemInfo_position_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Vector2 ret = new Vector2(Interop.EmbeddedItemInfo.EmbeddedItemInfo_position_get(swigCPtr), swigCMemOwn);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The size within the buffer of the embedded item.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size Size
        {
            set
            {
                Interop.EmbeddedItemInfo.EmbeddedItemInfo_size_set(swigCPtr, Size.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Size ret = new Size(Interop.EmbeddedItemInfo.EmbeddedItemInfo_size_get(swigCPtr), swigCMemOwn);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The rotated size within the buffer of the embedded item.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size RotatedSize
        {
            set
            {
                Interop.EmbeddedItemInfo.EmbeddedItemInfo_rotatedSize_set(swigCPtr, Size.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Size ret = new Size(Interop.EmbeddedItemInfo.EmbeddedItemInfo_rotatedSize_get(swigCPtr), swigCMemOwn);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Rotation angle of the pixel buffer in degrees.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Degree Angle
        {
            set
            {
                Interop.EmbeddedItemInfo.EmbeddedItemInfo_angle_set(swigCPtr, Degree.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Degree ret = new Degree(Interop.EmbeddedItemInfo.EmbeddedItemInfo_angle_get(swigCPtr), swigCMemOwn);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Whether the color of the image is multiplied by the color of the text.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.ColorBlendingMode ColorBlendingMode
        {
            set
            {
                Interop.EmbeddedItemInfo.EmbeddedItemInfo_colorBlendingMode_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Tizen.NUI.ColorBlendingMode ret = Interop.EmbeddedItemInfo.EmbeddedItemInfo_colorBlendingMode_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }

    /// <summary>
    /// Class with the parameters needed to build a shadow for the given pixel buffer.
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ShadowParameters : Disposable
    {

        internal ShadowParameters(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ShadowParameters obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ShadowParameters.delete_ShadowParameters(swigCPtr);
        }

        /// <summary>
        /// Construct ShadowParameters
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ShadowParameters() : this(Interop.ShadowParameters.new_ShadowParameters__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The input pixel buffer used to create the shadow.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PixelBuffer Input
        {
            set
            {
                Interop.ShadowParameters.ShadowParameters_input_set(swigCPtr, PixelBuffer.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                PixelBuffer ret = new PixelBuffer(Interop.ShadowParameters.ShadowParameters_input_get(swigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The color of the text.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 TextColor
        {
            set
            {
                Interop.ShadowParameters.ShadowParameters_textColor_set(swigCPtr, Vector4.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Vector4 ret = new Vector4(Interop.ShadowParameters.ShadowParameters_textColor_get(swigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The color of the shadow.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 Color
        {
            set
            {
                Interop.ShadowParameters.ShadowParameters_color_set(swigCPtr, Vector4.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Vector4 ret = new Vector4(Interop.ShadowParameters.ShadowParameters_color_get(swigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The offset of the shadow.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Offset
        {
            set
            {
                Interop.ShadowParameters.ShadowParameters_offset_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Vector2 ret = new Vector2(Interop.ShadowParameters.ShadowParameters_offset_get(swigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Whether to blend the shadow.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool blendShadow
        {
            set
            {
                Interop.ShadowParameters.ShadowParameters_blendShadow_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                bool ret = Interop.ShadowParameters.ShadowParameters_blendShadow_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }

    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static partial class TextUtils
    {
        /// <summary>
        /// Renders text into a pixel buffer.
        /// @note: Can process a mark-up string.
        /// @note: It does the font selection, RTL reordering, shaping and layouting.
        /// @note: The width of the pixel buffer may be different to the given @e textWidth
        ///        due to some padding pixels added.
        ///
        ///  The text is laid-out for the given size @e (textWidth,textHeight).
        ///  If the @e multiLineEnabled option is enabled, the text will wrap in lines.
        ///  If the @e ellipsisEnabled option is enabled, the text will be ellided if
        ///  there is no more space for new lines.
        ///
        ///  It won't be rendered the parts of the text exceeding the boundaries of
        ///  the given width and height.
        ///
        ///  If the given @e textHeight is zero, a big enough pixel buffer will be created
        ///  to render the full text.
        ///
        ///  If the given @e textWidth is zero, the 'natural size' of the text will be
        ///  used to create the pixel buffer to render the full text.
        ///
        ///  If the radius is not zero, the text will be laid-out following a circular path.
        ///  In that case the text is laid-out in a single line.
        ///
        /// If the mark-up string contains embedded items, the @p embeddedItemLayout vector
        /// contains the layout info of each embedded item.
        /// </summary>
        /// <param name="textParameters">The text and style options.</param>
        /// <param name="embeddedItemLayout">The layout info of the embedded items</param>
        /// <returns>A pixel buffer with the text rendered on it.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer Render(RendererParameters textParameters, ref EmbeddedItemInfo[] embeddedItemLayout)
        {
            int count = 0;
            int length = 0;
            global::System.IntPtr returnItem = IntPtr.Zero;
            PixelBuffer ret = new PixelBuffer(Interop.TextUtils.TextUtils_Render(RendererParameters.getCPtr(textParameters), ref returnItem, ref count, ref length), true);

            embeddedItemLayout = new EmbeddedItemInfo[count];
            for(int i=0; i< count; i++) {
                IntPtr p = new IntPtr((returnItem.ToInt32() + i * length));
                embeddedItemLayout[i] = new EmbeddedItemInfo(p, false);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates a shadow for the text given in the input pixel buffer.
        /// The function returns a RGBA8888 pixel buffer with the text and its shadow rendered on it.
        ///
        /// The pixel format of the @e input pixel buffer could be an A8 or an RGBA8888. If it's
        /// an A8 pixel buffer, it uses the given @e textColor to give color to the text. Otherwise
        /// it uses the color of the @e input pixel buffer.
        /// </summary>
        /// <param name="shadowParameters">The parameters needed to create the text's shadow.</param>
        /// <returns>A pixel buffer with the text and the shadow rendered on it.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer CreateShadow(ShadowParameters shadowParameters)
        {
            PixelBuffer ret = new PixelBuffer(Interop.TextUtils.TextUtils_CreateShadow(ShadowParameters.getCPtr(shadowParameters)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Converts a @p pixelBuffer with pixel format A8 to RGBA8888 using the given @p color.
        /// @note Does nothing if the @p pixelBuffer is not A8.
        /// </summary>
        /// <param name="pixelBuffer">The pixel buffer with pixel format A8</param>
        /// <param name="color">The color used to convert to RGBA8888</param>
        /// <param name="multiplyByAlpha">multiplyByAlpha Whether to multiply the @p color with the alpha value of the @p pixel @p buffer.</param>
        /// <returns>The pixel buffer converted to RGBA8888.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer ConvertToRgba8888(PixelBuffer pixelBuffer, Vector4 color, bool multiplyByAlpha)
        {
            PixelBuffer ret = new PixelBuffer(Interop.TextUtils.TextUtils_ConvertToRgba8888(PixelBuffer.getCPtr(pixelBuffer), Vector4.getCPtr(color), multiplyByAlpha), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Updates the @p dst pixel buffer with the data from @p src pixel buffer.
        /// @note Both pixel buffers must have the same pixel format. Does nothing if both pixel format are different.
        /// @note The function does nothing if the @p src pixel buffer doesn't fit into the @p dst pixel buffer.
        ///
        /// The @p src pixel buffer could be blended with the @p dst pixel buffer if @p blend is set to @e true.
        /// </summary>
        /// <param name="src">The pixel buffer from where the data is read.</param>
        /// <param name="dst">The pixel buffer where the data is written.</param>
        /// <param name="x">The top left corner's X within the destination pixel buffer.</param>
        /// <param name="y">The top left corner's y within the destination pixel buffer.</param>
        /// <param name="blend">Whether to blend the source pixel buffer with the destination pixel buffer as background.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void UpdateBuffer(PixelBuffer src, PixelBuffer dst, uint x, uint y, bool blend)
        {
            Interop.TextUtils.TextUtils_UpdateBuffer(PixelBuffer.getCPtr(src), PixelBuffer.getCPtr(dst), x, y, blend);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }

}
