// Copyright (c) 2024 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Tizen.NUI.Visuals
{
    /// <summary>
    /// The visual which can display simple text.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextVisual : VisualBase
    {
        #region Constructor
        /// <summary>
        /// Creates an visual object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextVisual() : this(Interop.VisualObject.VisualObjectNew(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal TextVisual(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal TextVisual(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
            Type = (int)Tizen.NUI.Visual.Type.Text;
        }
        #endregion

        #region Visual Properties
        /// <summary>
        /// The Text property.<br />
        /// The text to display in the UTF-8 format.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.TextVisualProperty.Text, string.IsNullOrEmpty(value) ? "" : value);
            }
            get
            {
                string ret = "";
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.TextVisualProperty.Text);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// The requested font family to use.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.TextVisualProperty.FontFamily, string.IsNullOrEmpty(value) ? "" : value);
            }
            get
            {
                string ret = "";
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.TextVisualProperty.FontFamily);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// The size of font in points.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float PointSize
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.TextVisualProperty.PointSize, value);
            }
            get
            {
                float ret = 0.0f;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.TextVisualProperty.PointSize);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// The single-line or multi-line layout option.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MultiLine
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.TextVisualProperty.MultiLine, value);
            }
            get
            {
                bool ret = false;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.TextVisualProperty.MultiLine);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// The line horizontal alignment.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.HorizontalAlignment HorizontalAlignment
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.TextVisualProperty.HorizontalAlignment, value);
            }
            get
            {
                int ret = (int)Tizen.NUI.HorizontalAlignment.Begin;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.TextVisualProperty.HorizontalAlignment);
                propertyValue?.Get(out ret);
                return (Tizen.NUI.HorizontalAlignment)ret;
            }
        }

        /// <summary>
        /// The line vertical alignment.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.VerticalAlignment VerticalAlignment
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.TextVisualProperty.VerticalAlignment, value);
            }
            get
            {
                int ret = (int)Tizen.NUI.VerticalAlignment.Top;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.TextVisualProperty.VerticalAlignment);
                propertyValue?.Get(out ret);
                return (Tizen.NUI.VerticalAlignment)ret;
            }
        }

        /// <summary>
        /// The color of the text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.Color TextColor
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.TextVisualProperty.TextColor, value);
            }
            get
            {
                Tizen.NUI.Color ret = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                using (var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.TextVisualProperty.TextColor))
                {
                    propertyValue?.Get(ret);
                }
                return ret;
            }
        }

        /// <summary>
        /// Whether the mark-up processing is enabled.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableMarkup
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.TextVisualProperty.EnableMarkup, value);
            }
            get
            {
                bool ret = false;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.TextVisualProperty.EnableMarkup);
                propertyValue?.Get(out ret);
                return ret;
            }
        }
        #endregion
    }
}