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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Dialog class shows a popup content with background scrim.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Dialog : Control
    {
        private View popupContent = null;
        private View scrim = null;
        private bool enableScrim = true;

        /// <summary>
        /// Creates a new instance of Dialog.
        /// </summary>
        /// <param name="content">The content to set to Content of Dialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dialog(View content = null) : base()
        {
            EnableScrim = true;
            EnableDismissOnScrim = true;

            //FIXME: Needs to separate GUI implementation codes to style cs file.
            var scrim = new VisualView();
            scrim.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.5f);
            //FIXME: Needs to set proper size to Scrim.
            scrim.Size = NUIApplication.GetDefaultWindow().Size;
            scrim.TouchEvent += (object source, TouchEventArgs e) =>
            {
                if ((EnableDismissOnScrim == true) && (e.Touch.GetState(0) == PointStateType.Up))
                {
                    //TODO: To show hide animation.
                    this.Hide();
                    this.Dispose();
                }
                return true;
            };

            Scrim = scrim;

            if (content != null)
            {
                content.RaiseAbove(scrim);
                Content = content;
            }
        }

        /// <summary>
        /// Popup content of Dialog. Content is added to Children automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Content
        {
            get
            {
                return popupContent;
            }
            set
            {
                if (popupContent == value)
                {
                    return;
                }

                if (popupContent != null)
                {
                    Remove(popupContent);
                }

                popupContent = value;
                if (popupContent == null)
                {
                    return;
                }

                popupContent.Relayout += PopupContentRelayout;

                //FIXME: Needs to separate GUI implementation codes to style cs file.
                CalculateContentPosition();

                Add(popupContent);

                if (Scrim != null)
                {
                    popupContent.RaiseAbove(Scrim);
                }
            }
        }

        private void PopupContentRelayout(object sender, EventArgs e)
        {
            //FIXME: Needs to separate GUI implementation codes to style cs file.
            CalculateContentPosition();
        }

        private void CalculateContentPosition()
        {
            var size = popupContent.Size2D;
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

            popupContent.Position2D = new Position2D((parentSize.Width - size.Width) / 2, (parentSize.Height - size.Height) / 2);
        }

        /// <summary>
        /// Indicates to show scrim behind popup content.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableScrim
        {
            get
            {
                return enableScrim;
            }
            set
            {
                if (enableScrim == value)
                {
                    return;
                }

                enableScrim = value;

                if ((Scrim != null) && (enableScrim != Scrim.Visibility))
                {
                    if (enableScrim)
                    {
                        Scrim.Show();
                    }
                    else
                    {
                        Scrim.Hide();
                    }
                }
            }
        }

        /// <summary>
        /// Indicates to dismiss popup content by touching on scrim.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableDismissOnScrim { get; set; }

        /// <summary>
        /// Scrim covers background behind popup content.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal View Scrim
        {
            get
            {
                return scrim;
            }
            set
            {
                if (scrim == value)
                {
                    return;
                }

                if (scrim != null)
                {
                    Remove(scrim);
                }

                scrim = value;
                if (scrim == null)
                {
                    return;
                }

                Add(scrim);

                if (Content != null)
                {
                    Content.RaiseAbove(scrim);
                }
            }
        }

        /// <summary>
        /// Dispose Dialog and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (popupContent != null)
                {
                    popupContent.Relayout -= PopupContentRelayout;
                    Utility.Dispose(popupContent);
                }

                if (scrim != null)
                {
                    Utility.Dispose(scrim);
                }
            }

            base.Dispose(type);
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
    }
}
