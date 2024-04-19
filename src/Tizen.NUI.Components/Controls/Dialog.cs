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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Dialog class shows a dialog with content.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class Dialog : Control
    {
        /// <summary>
        /// ContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(Dialog), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Dialog)bindable;
            if (newValue != null)
            {
                instance.InternalContent = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Dialog)bindable;
            return instance.InternalContent;
        });

        private View content = null;

        private void Initialize()
        {
            Layout = new AbsoluteLayout();

            Relayout += OnRelayout;
            AddedToWindow += OnAddedToWindow;
            RemovedFromWindow += OnRemovedFromWindow;
        }

        /// <summary>
        /// Creates a new instance of Dialog.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Dialog() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of Dialog with style.
        /// </summary>
        /// <param name="style">Creates Dialog by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dialog(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Dialog with style.
        /// </summary>
        /// <param name="style">A style applied to the newly created Dialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dialog(ControlStyle style) : base(style)
        {
            Initialize();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            AddedToWindow -= OnAddedToWindow;
            RemovedFromWindow -= OnRemovedFromWindow;

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
                return GetValue(ContentProperty) as View;
            }
            set
            {
                SetValue(ContentProperty, value);
                NotifyPropertyChanged();
            }
        }
        private View InternalContent
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
            AccessibilityRole = Role.Dialog;
        }

        private void OnAddedToWindow(object sender, EventArgs e)
        {
            Show(); // calls RegisterDefaultLabel(); Hide() will call UnregisterDefaultLabel()
        }

        private void OnRemovedFromWindow(object sender, EventArgs e)
        {
            Hide();
        }

        /// <summary>
        /// Informs AT-SPI bridge about the set of AT-SPI states associated with this object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override AccessibilityStates AccessibilityCalculateStates()
        {
            var states = base.AccessibilityCalculateStates();

            states[AccessibilityState.Modal] = true;

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
