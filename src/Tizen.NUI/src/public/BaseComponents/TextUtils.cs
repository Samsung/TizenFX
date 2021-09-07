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

extern alias TizenSystemSettings;
using TizenSystemSettings.Tizen.System;
using System;
using System.ComponentModel;
using Tizen.NUI.Text;

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
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.RendererParameters.DeleteRendererParameters(swigCPtr);
        }

        /// <summary>
        /// Construct RendererParameters
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RendererParameters() : this(Interop.RendererParameters.NewRendererParameters(), true)
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
                Interop.RendererParameters.TextSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.TextGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                switch (value)
                {
                    case HorizontalAlignment.Begin:
                        {
                            alignment = "begin";
                            break;
                        }
                    case HorizontalAlignment.Center:
                        {
                            alignment = "center";
                            break;
                        }
                    case HorizontalAlignment.End:
                        {
                            alignment = "end";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                Interop.RendererParameters.HorizontalAlignmentSet(SwigCPtr, alignment);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.HorizontalAlignmentGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                HorizontalAlignment alignment = HorizontalAlignment.Begin;
                switch (ret)
                {
                    case "begin":
                        {
                            alignment = HorizontalAlignment.Begin;
                            break;
                        }
                    case "center":
                        {
                            alignment = HorizontalAlignment.Center;
                            break;
                        }
                    case "end":
                        {
                            alignment = HorizontalAlignment.End;
                            break;
                        }
                    default:
                        {
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
                switch (value)
                {
                    case VerticalAlignment.Top:
                        {
                            alignment = "top";
                            break;
                        }
                    case VerticalAlignment.Center:
                        {
                            alignment = "center";
                            break;
                        }
                    case VerticalAlignment.Bottom:
                        {
                            alignment = "bottom";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                Interop.RendererParameters.VerticalAlignmentSet(SwigCPtr, alignment);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.VerticalAlignmentGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                VerticalAlignment alignment = VerticalAlignment.Top;
                switch (ret)
                {
                    case "top":
                        {
                            alignment = VerticalAlignment.Top;
                            break;
                        }
                    case "center":
                        {
                            alignment = VerticalAlignment.Center;
                            break;
                        }
                    case "bottom":
                        {
                            alignment = VerticalAlignment.Bottom;
                            break;
                        }
                    default:
                        {
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
                Interop.RendererParameters.FontFamilySet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.FontFamilyGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.FontWeightSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.FontWeightGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.FontWidthSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.FontWidthGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.FontSlantSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.FontSlantGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                switch (value)
                {
                    case TextLayout.SingleLine:
                        {
                            textLayout = "singleLine";
                            break;
                        }
                    case TextLayout.MultiLine:
                        {
                            textLayout = "multiLine";
                            break;
                        }
                    case TextLayout.Circular:
                        {
                            textLayout = "circular";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                Interop.RendererParameters.LayoutSet(SwigCPtr, textLayout);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.LayoutGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                TextLayout textLayout = TextLayout.SingleLine;
                switch (ret)
                {
                    case "singleLine":
                        {
                            textLayout = TextLayout.SingleLine;
                            break;
                        }
                    case "multiLine":
                        {
                            textLayout = TextLayout.MultiLine;
                            break;
                        }
                    case "circular":
                        {
                            textLayout = TextLayout.Circular;
                            break;
                        }
                    default:
                        {
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
                switch (value)
                {
                    case CircularAlignment.Begin:
                        {
                            alignment = "begin";
                            break;
                        }
                    case CircularAlignment.Center:
                        {
                            alignment = "center";
                            break;
                        }
                    case CircularAlignment.End:
                        {
                            alignment = "end";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                Interop.RendererParameters.CircularAlignmentSet(SwigCPtr, alignment);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.RendererParameters.CircularAlignmentGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                CircularAlignment alignment = CircularAlignment.Begin;
                switch (ret)
                {
                    case "begin":
                        {
                            alignment = CircularAlignment.Begin;
                            break;
                        }
                    case "center":
                        {
                            alignment = CircularAlignment.Center;
                            break;
                        }
                    case "end":
                        {
                            alignment = CircularAlignment.End;
                            break;
                        }
                    default:
                        {
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
                Interop.RendererParameters.TextColorSet(SwigCPtr, Vector4.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Vector4 ret = new Vector4(Interop.RendererParameters.TextColorGet(SwigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.FontSizeSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.RendererParameters.FontSizeGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.TextWidthSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.RendererParameters.TextWidthGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.TextHeightSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.RendererParameters.TextHeightGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.RadiusSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.RendererParameters.RadiusGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.BeginAngleSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.RendererParameters.BeginAngleGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.IncrementAngleSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.RendererParameters.IncrementAngleGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.EllipsisEnabledSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                bool ret = Interop.RendererParameters.EllipsisEnabledGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.MarkupEnabledSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                bool ret = Interop.RendererParameters.MarkupEnabledGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.RendererParameters.IsTextColorSetSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                bool ret = Interop.RendererParameters.IsTextColorSetGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Minimum size of line.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MinLineSize
        {
            set
            {
                Interop.RendererParameters.MinLineSizeSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.RendererParameters.MinLineSizeGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Padding of TextLabel.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents Padding
        {
            set
            {
                Interop.RendererParameters.PaddingSet(SwigCPtr, Extents.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Extents ret = new Extents(Interop.RendererParameters.PaddingGet(SwigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.EmbeddedItemInfo.DeleteEmbeddedItemInfo(swigCPtr);
        }

        /// <summary>
        /// Construct EmbeddedItemInfo
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EmbeddedItemInfo() : this(Interop.EmbeddedItemInfo.NewEmbeddedItemInfo(), true)
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
                Interop.EmbeddedItemInfo.CharacterIndexSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.EmbeddedItemInfo.CharacterIndexGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.EmbeddedItemInfo.GlyphIndexSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.EmbeddedItemInfo.GlyphIndexGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.EmbeddedItemInfo.PositionSet(SwigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Vector2 ret = new Vector2(Interop.EmbeddedItemInfo.PositionGet(SwigCPtr), SwigCMemOwn);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.EmbeddedItemInfo.SizeSet(SwigCPtr, Size.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Size ret = new Size(Interop.EmbeddedItemInfo.SizeGet(SwigCPtr), SwigCMemOwn);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.EmbeddedItemInfo.RotatedSizeSet(SwigCPtr, Size.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Size ret = new Size(Interop.EmbeddedItemInfo.RotatedSizeGet(SwigCPtr), SwigCMemOwn);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.EmbeddedItemInfo.AngleSet(SwigCPtr, Degree.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Degree ret = new Degree(Interop.EmbeddedItemInfo.AngleGet(SwigCPtr), SwigCMemOwn);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.EmbeddedItemInfo.ColorBlendingModeSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Tizen.NUI.ColorBlendingMode ret = Interop.EmbeddedItemInfo.ColorBlendingModeGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ShadowParameters.DeleteShadowParameters(swigCPtr);
        }

        /// <summary>
        /// Construct ShadowParameters
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ShadowParameters() : this(Interop.ShadowParameters.NewShadowParameters(), true)
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
                Interop.ShadowParameters.InputSet(SwigCPtr, PixelBuffer.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                PixelBuffer ret = new PixelBuffer(Interop.ShadowParameters.InputGet(SwigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.ShadowParameters.TextColorSet(SwigCPtr, Vector4.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Vector4 ret = new Vector4(Interop.ShadowParameters.TextColorGet(SwigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.ShadowParameters.ColorSet(SwigCPtr, Vector4.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Vector4 ret = new Vector4(Interop.ShadowParameters.ColorGet(SwigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.ShadowParameters.OffsetSet(SwigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Vector2 ret = new Vector2(Interop.ShadowParameters.OffsetGet(SwigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                Interop.ShadowParameters.BlendShadowSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                bool ret = Interop.ShadowParameters.BlendShadowGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }
    }

    /// <summary>
    /// </summary>
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
            PixelBuffer ret = new PixelBuffer(Interop.TextUtils.Render(RendererParameters.getCPtr(textParameters), ref returnItem, ref count, ref length), true);

            embeddedItemLayout = new EmbeddedItemInfo[count];
            for (int i = 0; i < count; i++)
            {
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
            PixelBuffer ret = new PixelBuffer(Interop.TextUtils.CreateShadow(ShadowParameters.getCPtr(shadowParameters)), true);
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
            PixelBuffer ret = new PixelBuffer(Interop.TextUtils.ConvertToRgba8888(PixelBuffer.getCPtr(pixelBuffer), Vector4.getCPtr(color), multiplyByAlpha), true);
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
            Interop.TextUtils.UpdateBuffer(PixelBuffer.getCPtr(src), PixelBuffer.getCPtr(dst), x, y, blend);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Splits the text in pages of the size given in @p textParameters
        /// @note The returned indices are indices to utf32 characters. The input text is encoded in utf8.
        /// <returns> An array with the indices of the last character of each page </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Tizen.NUI.PropertyArray GetLastCharacterIndex(RendererParameters textParameters)
        {
            Tizen.NUI.PropertyArray ret = new Tizen.NUI.PropertyArray(Interop.TextUtils.GetLastCharacterIndex(RendererParameters.getCPtr(textParameters)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

#if PROFILE_TV
        private const float FontSizeScaleSmall = 0.8f;
        private const float FontSizeScaleNormal = 1.0f;
        private const float FontSizeScaleLarge = 1.5f;
        private const float FontSizeScaleHuge = 1.9f;
        private const float FontSizeScaleGiant = 2.5f;
#elif PROFILE_WEARABLE
        // The following values from 'system-settings/libutil/sstu.c'
        private const float FontSizeScaleSmall = 0.9f;
        private const float FontSizeScaleNormal = 1.0f;
        private const float FontSizeScaleLarge = 1.1f;
        private const float FontSizeScaleHuge = 1.9f;
        private const float FontSizeScaleGiant = 2.5f;
#else   // PROFILE_MOBILE and etc
        // The following values from 'system-settings/libutil/sstu.c'
        private const float FontSizeScaleSmall = 0.8f;
        private const float FontSizeScaleNormal = 1.0f;
        private const float FontSizeScaleLarge = 1.5f;
        private const float FontSizeScaleHuge = 1.9f;
        private const float FontSizeScaleGiant = 2.5f;
#endif

        /// <summary>
        /// It returns a float value according to SystemSettingsFontSize.
        /// The returned value can be used for FontSizeScale property.
        /// <param name="systemSettingsFontSize">The SystemSettingsFontSize enum value.</param>
        /// <returns> A float value for FontSizeScale property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float GetFontSizeScale(SystemSettingsFontSize systemSettingsFontSize)
        {
            float ret = FontSizeScaleNormal;

            switch (systemSettingsFontSize)
            {
                case SystemSettingsFontSize.Small:
                    ret = FontSizeScaleSmall;
                    break;
                case SystemSettingsFontSize.Normal:
                    ret = FontSizeScaleNormal;
                    break;
                case SystemSettingsFontSize.Large:
                    ret = FontSizeScaleLarge;
                    break;
                case SystemSettingsFontSize.Huge:
                    ret = FontSizeScaleHuge;
                    break;
                case SystemSettingsFontSize.Giant:
                    ret = FontSizeScaleGiant;
                    break;
            }

            return ret;
        }

        /// <summary>
        /// It returns a string value according to FontWidthType.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontWidthType">The FontWidthType enum value.</param>
        /// <returns> A string value for FontStyle.Width property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetFontWidthString(FontWidthType fontWidthType)
        {
            string value = fontWidthType.ToString();
            if (!string.IsNullOrEmpty(value))
            {
                char[] charArray = value.ToCharArray();
                charArray[0] = Char.ToLower(charArray[0]);
                value = new string(charArray);
            }
            else
            {
                value = "none"; // The default value.
            }

            return value;
        }

        /// <summary>
        /// It returns a string value according to FontWeightType.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontWeightType">The FontWeightType enum value.</param>
        /// <returns> A string value for FontStyle.Weight property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetFontWeightString(FontWeightType fontWeightType)
        {
            string value = fontWeightType.ToString();
            if (!string.IsNullOrEmpty(value))
            {
                char[] charArray = value.ToCharArray();
                charArray[0] = Char.ToLower(charArray[0]);
                value = new string(charArray);
            }
            else
            {
                value = "none"; // The default value.
            }

            return value;
        }

        /// <summary>
        /// It returns a string value according to FontSlantType.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontSlantType">The FontSlantType enum value.</param>
        /// <returns> A string value for FontStyle.Slant property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetFontSlantString(FontSlantType fontSlantType)
        {
            string value = fontSlantType.ToString();
            if (!string.IsNullOrEmpty(value))
            {
                char[] charArray = value.ToCharArray();
                charArray[0] = Char.ToLower(charArray[0]);
                value = new string(charArray);
            }
            else
            {
                value = "none"; // The default value.
            }

            return value;
        }

        /// <summary>
        /// It returns a FontWidthType value according to fontWidthString.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontWidthString">The FontWidth string value.</param>
        /// <returns> A FontWidthType value for FontStyle.Width property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FontWidthType GetFontWidthType(string fontWidthString)
        {
            FontWidthType value;

            if (!(Enum.TryParse(fontWidthString, true, out value) && Enum.IsDefined(typeof(FontWidthType), value)))
            {
                value = FontWidthType.None; // If parsing fails, set a default value.
            }

            return value;
        }

        /// <summary>
        /// It returns a FontWeightType value according to fontWeightString.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontWeightString">The FontWeight string value.</param>
        /// <returns> A FontWeightType value for FontStyle.Weight property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FontWeightType GetFontWeightType(string fontWeightString)
        {
            FontWeightType value;

            if (!(Enum.TryParse(fontWeightString, true, out value) && Enum.IsDefined(typeof(FontWeightType), value)))
            {
                value = FontWeightType.None; // If parsing fails, set a default value.
            }

            return value;
        }

        /// <summary>
        /// It returns a FontSlantType value according to fontSlantString.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontSlantString">The FontSlant string value.</param>
        /// <returns> A FontSlantType value for FontStyle.Slant property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FontSlantType GetFontSlantType(string fontSlantString)
        {
            FontSlantType value;

            if (!(Enum.TryParse(fontSlantString, true, out value) && Enum.IsDefined(typeof(FontSlantType), value)))
            {
                value = FontSlantType.None; // If parsing fails, set a default value.
            }

            return value;
        }

        /// <summary>
        /// This method converts a FontStyle struct to a PropertyMap and returns it.
        /// The returned map can be used for set FontStyle PropertyMap in the SetFontStyle method.
        /// <param name="fontStyle">The FontStyle struct value.</param>
        /// <returns> A PropertyMap for FontStyle property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetFontStyleMap(FontStyle fontStyle)
        {
            var map = new PropertyMap();
            var width = new PropertyValue(GetFontWidthString(fontStyle.Width));
            var weight = new PropertyValue(GetFontWeightString(fontStyle.Weight));
            var slant = new PropertyValue(GetFontSlantString(fontStyle.Slant));

            map.Add("width", width);
            map.Add("weight", weight);
            map.Add("slant", slant);

            return map;
        }

        /// <summary>
        /// This method converts a FontStyle map to a struct and returns it.
        /// The returned struct can be returned to the user as a FontStyle in the GetFontStyle method.
        /// <param name="map">The FontStyle PropertyMap.</param>
        /// <returns> A FontStyle struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FontStyle GetFontStyleStruct(PropertyMap map)
        {
            string width = "none";
            string weight = "none";
            string slant = "none";
            map.Find(0, "width")?.Get(out width);
            map.Find(0, "weight")?.Get(out weight);
            map.Find(0, "slant")?.Get(out slant);

            var fontStyle = new FontStyle();
            fontStyle.Width = GetFontWidthType(width);
            fontStyle.Weight = GetFontWeightType(weight);
            fontStyle.Slant = GetFontSlantType(slant);

            return fontStyle;
        }

        /// <summary>
        /// This method converts a InputFilter struct to a PropertyMap and returns it. <br />
        /// The returned map can be used for set InputFilter PropertyMap in the SetInputFilter method. <br />
        /// <param name="inputFilter">The InputFilter struct value.</param>
        /// <returns> A PropertyMap for InputFilter property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetInputFilterMap(InputFilter inputFilter)
        {
            var map = new PropertyMap();
            var accepted = inputFilter.Accepted != null ? new PropertyValue(inputFilter.Accepted) : new PropertyValue("");
            var rejected = inputFilter.Rejected != null ? new PropertyValue(inputFilter.Rejected) : new PropertyValue("");
            map.Add(0, accepted);
            map.Add(1, rejected);

            return map;
        }

        /// <summary>
        /// This method converts a InputFilter map to a struct and returns it. <br />
        /// The returned struct can be returned to the user as a InputFilter in the GetInputFilter method. <br />
        /// <param name="map">The InputFilter PropertyMap.</param>
        /// <returns> A InputFilter struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static InputFilter GetInputFilterStruct(PropertyMap map)
        {
            string accepted = "";
            string rejected = "";
            map.Find(0)?.Get(out accepted);
            map.Find(1)?.Get(out rejected);

            var inputFilter = new InputFilter();
            inputFilter.Accepted = accepted;
            inputFilter.Rejected = rejected;

            return inputFilter;

        }

        /// <summary>
        /// This method converts a Underline struct to a PropertyMap and returns it.
        /// The returned map can be used for set Underline PropertyMap in the SetUnderline method.
        /// <param name="underline">The Underline struct value.</param>
        /// <returns> A PropertyMap for Underline property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetUnderlineMap(Underline underline)
        {
            var map = new PropertyMap();

            map.Add("enable", new PropertyValue(underline.Enable));

            if (underline.Color != null)
                map.Add("color", new PropertyValue(underline.Color));

            if (underline.Height != null)
                map.Add("height", new PropertyValue((float)underline.Height));

            return map;
        }

        /// <summary>
        /// This method converts a Underline map to a struct and returns it.
        /// The returned struct can be returned to the user as a Underline in the GetUnderline method.
        /// <param name="map">The Underline PropertyMap.</param>
        /// <returns> A Underline struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Underline GetUnderlineStruct(PropertyMap map)
        {
            Color color = new Color();
            map.Find(0, "enable").Get(out bool enable);
            map.Find(0, "color").Get(color);
            map.Find(0, "height").Get(out float height);

            var underline = new Underline();
            underline.Enable = enable;
            underline.Color = color;
            underline.Height = height;

            return underline;
        }

        /// <summary>
        /// This method converts a Shadow struct to a PropertyMap and returns it.
        /// The returned map can be used for set Shadow PropertyMap in the SetShadow method.
        /// <param name="shadow">The Shadow struct value.</param>
        /// <returns> A PropertyMap for Shadow property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetShadowMap(Tizen.NUI.Text.Shadow shadow)
        {
            var map = new PropertyMap();

            if (shadow.Offset != null)
                map.Add("offset", new PropertyValue(shadow.Offset));

            if (shadow.Color != null)
                map.Add("color", new PropertyValue(shadow.Color));

            if (shadow.BlurRadius != null)
                map.Add("blurRadius", new PropertyValue((float)shadow.BlurRadius));

            return map;
        }

        /// <summary>
        /// This method converts a Shadow map to a struct and returns it.
        /// The returned struct can be returned to the user as a Shadow in the GetShadow method.
        /// <param name="map">The Shadow PropertyMap.</param>
        /// <returns> A Shadow struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Tizen.NUI.Text.Shadow GetShadowStruct(PropertyMap map)
        {
            Vector2 offset = new Vector2();
            Color color = new Color();
            map.Find(0, "offset").Get(offset);
            map.Find(0, "color").Get(color);
            map.Find(0, "blurRadius").Get(out float blurRadius);

            var shadow = new Tizen.NUI.Text.Shadow();
            shadow.Offset = offset;
            shadow.Color = color;
            shadow.BlurRadius = blurRadius;

            return shadow;
        }

        /// <summary>
        /// This method converts a Outline struct to a PropertyMap and returns it.
        /// The returned map can be used for set Outline PropertyMap in the SetOutline method.
        /// <param name="outline">The Outline struct value.</param>
        /// <returns> A PropertyMap for Outline property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetOutlineMap(Outline outline)
        {
            var map = new PropertyMap();

            if (outline.Color != null)
                map.Add("color", new PropertyValue(outline.Color));

            if (outline.Width != null)
                map.Add("width", new PropertyValue((float)outline.Width));

            return map;
        }

        /// <summary>
        /// This method converts a Outline map to a struct and returns it.
        /// The returned struct can be returned to the user as a Outline in the GetOutline method.
        /// <param name="map">The Outline PropertyMap.</param>
        /// <returns> A Outline struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Outline GetOutlineStruct(PropertyMap map)
        {
            Color color = new Color();
            map.Find(0, "color").Get(color);
            map.Find(0, "width").Get(out float width);

            var outline = new Outline();
            outline.Color = color;
            outline.Width = width;

            return outline;
        }

        /// <summary>
        /// It returns a string value according to FontSizeType.
        /// The returned value can be used for TextFit PropertyMap.
        /// <param name="fontSizeType">The FontSizeType enum value.</param>
        /// <returns> A string value for TextFit.FontSizeType property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetFontSizeString(FontSizeType fontSizeType)
        {
            string value = fontSizeType.ToString();
            if (!string.IsNullOrEmpty(value))
            {
                char[] charArray = value.ToCharArray();
                charArray[0] = Char.ToLower(charArray[0]);
                value = new string(charArray);
            }
            else
            {
                value = "pointSize"; // The default value.
            }

            return value;
        }

        /// <summary>
        /// It returns a FontSizeType value according to fontSizeString.
        /// The returned value can be used for FontStyle PropertyMap.
        /// <param name="fontSizeString">The FontSizeType string value.</param>
        /// <returns> A FontSizeType value for TextFit.FontSizeType property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FontSizeType GetFontSizeType(string fontSizeString)
        {
            FontSizeType value;

            if (!(Enum.TryParse(fontSizeString, true, out value) && Enum.IsDefined(typeof(FontSizeType), value)))
            {
                value = FontSizeType.PointSize; // If parsing fails, set a default value.
            }

            return value;
        }

        /// <summary>
        /// This method converts a TextFit struct to a PropertyMap and returns it.
        /// The returned map can be used for set TextFit PropertyMap in the SetTextFit method.
        /// <param name="textFit">The TextFit struct value.</param>
        /// <returns> A PropertyMap for TextFit property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetTextFitMap(TextFit textFit)
        {
            var map = new PropertyMap();
            map.Add("enable", new PropertyValue(textFit.Enable));
            map.Add("fontSizeType", new PropertyValue(GetFontSizeString(textFit.FontSizeType)));

            if (textFit.MinSize != null)
                map.Add("minSize", new PropertyValue((float)textFit.MinSize));

            if (textFit.MaxSize != null)
                map.Add("maxSize", new PropertyValue((float)textFit.MaxSize));

            if (textFit.StepSize != null)
                map.Add("stepSize", new PropertyValue((float)textFit.StepSize));

            return map;
        }

        /// <summary>
        /// This method converts a TextFit map to a struct and returns it.
        /// The returned struct can be returned to the user as a TextFit in the GetTextFit method.
        /// <param name="map">The TextFit PropertyMap.</param>
        /// <returns> A TextFit struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TextFit GetTextFitStruct(PropertyMap map)
        {
            map.Find(0, "enable").Get(out bool enable);
            map.Find(0, "minSize").Get(out float minSize);
            map.Find(0, "maxSize").Get(out float maxSize);
            map.Find(0, "stepSize").Get(out float stepSize);
            map.Find(0, "fontSizeType").Get(out string fontSizeType);

            var textFit = new TextFit();
            textFit.Enable = enable;
            textFit.MinSize = minSize;
            textFit.MaxSize = maxSize;
            textFit.StepSize = stepSize;
            textFit.FontSizeType = GetFontSizeType(fontSizeType);

            return textFit;
        }

        /// <summary>
        /// This method converts a Placeholder struct to a PropertyMap and returns it.
        /// The returned map can be used for set Placeholder PropertyMap in the SetPlaceholder method.
        /// <param name="placeholder">The Placeholder struct value.</param>
        /// <returns> A PropertyMap for Placeholder property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetPlaceholderMap(Placeholder placeholder)
        {
            var map = new PropertyMap();

            if (placeholder.Text != null)
                map.Add("text", new PropertyValue(placeholder.Text));

            if (placeholder.TextFocused != null)
                map.Add("textFocused", new PropertyValue(placeholder.TextFocused));

            if (placeholder.Color != null)
                map.Add("color", new PropertyValue(placeholder.Color));

            if (placeholder.FontFamily != null)
                map.Add("fontFamily", new PropertyValue(placeholder.FontFamily));

            if (placeholder.FontStyle != null)
                map.Add("fontStyle", new PropertyValue(GetFontStyleMap((FontStyle)placeholder.FontStyle)));

            if (placeholder.PointSize != null && placeholder.PixelSize != null)
                map.Add("pointSize", new PropertyValue((float)placeholder.PointSize));

            else if (placeholder.PointSize != null)
                map.Add("pointSize", new PropertyValue((float)placeholder.PointSize));

            else if (placeholder.PixelSize != null)
                map.Add("pixelSize", new PropertyValue((float)placeholder.PixelSize));

            map.Add("ellipsis", new PropertyValue(placeholder.Ellipsis));

            return map;
        }

        /// <summary>
        /// This method converts a Placeholder map to a struct and returns it.
        /// The returned struct can be returned to the user as a Placeholder in the GetPlaceholder method.
        /// <param name="map">The Placeholder PropertyMap.</param>
        /// <returns> A Placeholder struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Placeholder GetPlaceholderStruct(PropertyMap map)
        {
            string text = "";
            string textFocused = "";
            Color color = new Color();
            string fontFamily = null;
            var fontStyle = new PropertyMap();
            PropertyValue pointSizeValue = null;
            PropertyValue pixelSizeValue = null;
            bool ellipsis = false;

            map.Find(0)?.Get(out text);
            map.Find(1)?.Get(out textFocused);
            map.Find(2).Get(color);
            map.Find(3)?.Get(out fontFamily);
            map.Find(4).Get(fontStyle);
            pointSizeValue = map.Find(5);
            pixelSizeValue = map.Find(6);
            map.Find(7)?.Get(out ellipsis);

            var placeholder = new Placeholder();
            placeholder.Text = text;
            placeholder.TextFocused = textFocused;
            placeholder.Color = color;
            placeholder.FontFamily = fontFamily;
            placeholder.Ellipsis = ellipsis;
            placeholder.FontStyle = GetFontStyleStruct(fontStyle);

            if (pointSizeValue != null)
            {
                pointSizeValue.Get(out float pointSize);
                placeholder.PointSize = pointSize;
            }

            if (pixelSizeValue != null)
            {
                pixelSizeValue.Get(out float pixelSize);
                placeholder.PixelSize = pixelSize;
            }

            return placeholder;
        }

        /// <summary>
        /// This method converts a HiddenInput struct to a PropertyMap and returns it.
        /// The returned map can be used for set HiddenInputSettings PropertyMap in the SetHiddenInput method.
        /// <param name="hiddenInput">The HiddenInput struct value.</param>
        /// <returns> A PropertyMap for HiddenInput property. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetHiddenInputMap(HiddenInput hiddenInput)
        {
            var map = new PropertyMap();

            map.Add(0, new PropertyValue((int)hiddenInput.Mode));

            if (hiddenInput.SubstituteCharacter != null)
                map.Add(1, new PropertyValue(Convert.ToInt32(hiddenInput.SubstituteCharacter)));

            if (hiddenInput.SubstituteCount != null)
                map.Add(2, new PropertyValue((int)hiddenInput.SubstituteCount));

            if (hiddenInput.ShowLastCharacterDuration != null)
                map.Add(3, new PropertyValue((int)hiddenInput.ShowLastCharacterDuration));

            return map;
        }

        /// <summary>
        /// This method converts a HiddenInputSettings map to a struct and returns it.
        /// The returned struct can be returned to the user as a HiddenInput in the GetHiddenInput method.
        /// <param name="map">The HiddenInput PropertyMap.</param>
        /// <returns> A HiddenInput struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HiddenInput GetHiddenInputStruct(PropertyMap map)
        {
            PropertyValue value = null;

            var hiddenInput = new HiddenInput();

            value = map.Find(0);
            if (value != null)
            {
                value.Get(out int mode);
                hiddenInput.Mode = (HiddenInputModeType)mode;
            }

            value = map.Find(1);
            if (value != null)
            {
                value.Get(out int substituteCharacter);
                hiddenInput.SubstituteCharacter = Convert.ToChar(substituteCharacter);
            }

            value = map.Find(2);
            if (value != null)
            {
                value.Get(out int substituteCount);
                hiddenInput.SubstituteCount = substituteCount;
            }

            value = map.Find(3);
            if (value != null)
            {
                value.Get(out int showLastCharacterDuration);
                hiddenInput.ShowLastCharacterDuration = showLastCharacterDuration;
            }

            return hiddenInput;
        }

        /// <summary>
        /// This method converts a fileName string to a PropertyMap and returns it.
        /// The returned map can be used for set SelectionHandleImageLeft, SelectionHandleImageRight PropertyMap in the SetSelectionHandleImage method.
        /// <param name="fileName">The file path string value for SelectionHandleImage.</param>
        /// <returns> A PropertyMap for SelectionHandleImageLeft, SelectionHandleImageRight properties. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PropertyMap GetFileNameMap(string fileName)
        {
            return new PropertyMap().Add("filename", new PropertyValue(fileName));
        }

        /// <summary>
        /// This method converts a SelectionHandleImageLeft, SelectionHandleImageRight map to a struct and returns it.
        /// The returned struct can be returned to the user as a SelectionHandleImage in the GetSelectionHandleImage method.
        /// <param name="leftImageMap">The SelectionHandleImageLeft PropertyMap.</param>
        /// <param name="rightImageMap">The SelectionHandleImageRight PropertyMap.</param>
        /// <returns> A SelectionHandleImage struct. </returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SelectionHandleImage GetSelectionHandleImageStruct(PropertyMap leftImageMap, PropertyMap rightImageMap)
        {
            string leftImageUrl = null;
            string rightImageUrl = null;

            var selectionHandleImage = new SelectionHandleImage();

            leftImageMap.Find(0, "filename")?.Get(out leftImageUrl);
            rightImageMap.Find(0, "filename")?.Get(out rightImageUrl);

            selectionHandleImage.LeftImageUrl = leftImageUrl;
            selectionHandleImage.RightImageUrl = rightImageUrl;

            return selectionHandleImage;
        }

        /// <summary>
        /// Copy the previously selected text into the clipboard and return the copied value.
        /// </summary>
        /// <param name="textView">The textEditor/textField control from which the text is copied.</param>
        /// <returns>The copied text.</returns>
        /// <since_tizen> 9 </since_tizen>
        public static string CopyToClipboard(View textView)
        {
            string copiedText ="";
            Type textViewType = textView.GetType();

            if(textViewType.Equals(typeof(TextEditor))){
                copiedText = Interop.TextEditor.CopyText(textView.SwigCPtr);
            }else  if(textViewType.Equals(typeof(TextField))){
                copiedText = Interop.TextField.CopyText(textView.SwigCPtr);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return copiedText;
        }

        /// <summary>
        /// Cut the previously selected text from the text control and into the clipboard and return the cut value.
        /// </summary>
        /// <param name="textView">The textEditor/textField control from which the text is cut.</param>
        /// <returns>The cut text.</returns>
        /// <since_tizen> 9 </since_tizen>
        public static string CutToClipboard(View textView)
        {
            string cutText = "";
            Type textViewType = textView.GetType();

            if(textViewType.Equals(typeof(TextEditor))){
                cutText = Interop.TextEditor.CutText(textView.SwigCPtr);
            }else  if(textViewType.Equals(typeof(TextField))){
                cutText = Interop.TextField.CutText(textView.SwigCPtr);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return cutText;
        }

        /// <summary>
        /// Paste the most recently copied/cut text from the clipboard and into the text control.
        /// </summary>
        /// <param name="textView">The textEditor/textField control into which the text is pasted.</param>
        /// <since_tizen> 9 </since_tizen>
        public static void PasteTo(View textView)
        {
            Type textViewType = textView.GetType();

            if(textViewType.Equals(typeof(TextEditor))){
                Interop.TextEditor.PasteText(textView.SwigCPtr);
            }else  if(textViewType.Equals(typeof(TextField))){
                Interop.TextField.PasteText(textView.SwigCPtr);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
