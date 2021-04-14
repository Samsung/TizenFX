/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Dialog class shows a dialog with content.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class Dialog : Control
    {
        private View content = null;

        /// <summary>
        /// Creates a new instance of Dialog.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Dialog() : base()
        {
            Layout = new AbsoluteLayout();

            this.Relayout += OnRelayout;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                this.Relayout -= OnRelayout;

                if (content != null)
                {
                    Utility.Dispose(content);
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Popup content of Dialog.
        /// Content is added as a child of Dialog automatically.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public View Content
        {
            get
            {
                return content;
            }
            set
            {
                if (content == value)
                {
                    return;
                }

                if (content != null)
                {
                    Remove(content);
                }

                content = value;
                if (content == null)
                {
                    return;
                }

                Add(content);
            }
        }

        /// <summary>
        /// Initialize AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            SetAccessibilityConstructor(Role.Dialog);
            AppendAccessibilityAttribute("sub-role", "Alert");
            Show(); // calls AddPopup()
        }

        /// <summary>
        /// Informs AT-SPI bridge about the set of AT-SPI states associated with this object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override AccessibilityStates AccessibilityCalculateStates()
        {
            var states = base.AccessibilityCalculateStates();
            states.Set(AccessibilityState.Modal, true);
            return states;
        }

        private void OnRelayout(object sender, EventArgs e)
        {
            //FIXME: Needs to separate GUI implementation codes to style cs file.
            CalculateContentPosition();
        }

        private void CalculateContentPosition()
        {
            var size = Size2D;
            var parent = GetParent();
            Size2D parentSize;

            if ((parent != null) && (parent is View))
            {
                parentSize = ((View)parent).Size;
            }
            else
            {
                parentSize = NUIApplication.GetDefaultWindow().Size;
            }

            Position2D = new Position2D((parentSize.Width - size.Width) / 2, (parentSize.Height - size.Height) / 2);
        }
    }
}
