/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The base class for Children attributes in Components.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ViewAttributes : Attributes
    {
        static public T CreateView<T>(string style) where T : View, new()
        {
            T ret = new T();
            (Tizen.NUI.Components.StyleManager.Instance.GetAttributes("style") as ViewAttributes).ApplyToView(ret);
            return ret;
        }

        /// <summary>
        /// Construct ViewAttributes.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes() : base()
        {
            StyleManager.Instance.ThemeChangedEvent += OnThemeChangedEvent;
        }

        /// <summary>
        /// Constructs a ViewAttributes that is a copy of Attributes
        /// </summary>
        /// <param name="attributes">Construct Attributes</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes(ViewAttributes attributes)
        {
            if (attributes == null)
            {
                return;
            }

            if (attributes.Position != null)
            {
                Position = new Position(attributes.Position.X, attributes.Position.Y, attributes.Position.Z);
            }

            if (attributes.Size != null)
            {
                Size = new Size(attributes.Size.Width, attributes.Size.Height, attributes.Size.Depth);
            }

            if (attributes.BackgroundColor != null)
            {
                BackgroundColor = attributes.BackgroundColor.Clone() as ColorSelector;
            }

            if (attributes.PositionUsesPivotPoint != null)
            {
                PositionUsesPivotPoint = attributes.PositionUsesPivotPoint;
            }

            if (attributes.ParentOrigin != null)
            {
                ParentOrigin = new Position(attributes.ParentOrigin.X, attributes.ParentOrigin.Y, attributes.ParentOrigin.Z);
            }

            if (attributes.PivotPoint != null)
            {
                PivotPoint = new Position(attributes.PivotPoint.X, attributes.PivotPoint.Y, attributes.PivotPoint.Z);
            }

            if (attributes.WidthResizePolicy != null)
            {
                WidthResizePolicy = attributes.WidthResizePolicy;
            }

            if (attributes.HeightResizePolicy != null)
            {
                HeightResizePolicy = attributes.HeightResizePolicy;
            }

            if (attributes.MinimumSize != null)
            {
                MinimumSize = new Size2D(attributes.MinimumSize.Width, attributes.MinimumSize.Height);
            }

            if (attributes.SizeModeFactor != null)
            {
                SizeModeFactor = new Vector3(attributes.SizeModeFactor.X, attributes.SizeModeFactor.Y, attributes.SizeModeFactor.Z);
            }

            if (attributes.Opacity != null)
            {
                Opacity = attributes.Opacity.Clone() as FloatSelector;
            }

            PaddingLeft = attributes.PaddingLeft;
            PaddingRight = attributes.PaddingRight;
            PaddingTop = attributes.PaddingTop;
            PaddingBottom = attributes.PaddingBottom;

            StyleManager.Instance.ThemeChangedEvent += OnThemeChangedEvent;
        }

        /// <summary>
        /// View Position
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position Position
        {
            get;
            set;
        }
        /// <summary>
        /// View Size
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size Size
        {
            get;
            set;
        }
        /// <summary>
        /// View BackgroundColor
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector BackgroundColor
        {
            get;
            set;
        }
        /// <summary>
        /// View PositionUsesPivotPoint
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? PositionUsesPivotPoint
        {
            get;
            set;
        }
        /// <summary>
        /// View ParentOrigin
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position ParentOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// View PivotPoint
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position PivotPoint
        {
            get;
            set;
        }
        /// <summary>
        /// View WidthResizePolicy
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResizePolicyType? WidthResizePolicy
        {
            get;
            set;
        }
        /// <summary>
        /// View HeightResizePolicy
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResizePolicyType? HeightResizePolicy
        {
            get;
            set;
        }
        /// <summary>
        /// View MinimumSize
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D MinimumSize
        {
            get;
            set;
        }
        /// <summary>
        /// View SizeModeFactor
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 SizeModeFactor
        {
            get;
            set;
        }
        /// <summary>
        /// View Opacity
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector Opacity
        {
            get;
            set;
        }
        /// <summary>
        /// View left padding
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PaddingLeft
        {
            get;
            set;
        }
        /// <summary>
        /// View right padding
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PaddingRight
        {
            get;
            set;
        }
        /// <summary>
        /// View top padding
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PaddingTop
        {
            get;
            set;
        }
        /// <summary>
        /// View bottom padding
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PaddingBottom
        {
            get;
            set;
        }
        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new ViewAttributes(this);
        }

        /// <summary>
        /// Apply ViewAttributes to View.
        /// </summary>
        public virtual void ApplyToView(View view, ControlStates state = ControlStates.Normal)
        {
            if (view == null)
            {
                return;
            }

            if (Position != null)
            {
                view.Position = Position;
            }
            if (Size != null)
            {
                view.Size = Size;
            }
            if (MinimumSize != null)
            {
                view.MinimumSize = MinimumSize;
            }
            if (PositionUsesPivotPoint != null)
            {
                view.PositionUsesPivotPoint = PositionUsesPivotPoint.Value;
            }
            if (ParentOrigin != null)
            {
                view.ParentOrigin = ParentOrigin;
            }
            if (PivotPoint != null)
            {
                view.PivotPoint = PivotPoint;
            }
            if (WidthResizePolicy != null)
            {
                view.WidthResizePolicy = WidthResizePolicy.Value;
            }
            if (HeightResizePolicy != null)
            {
                view.HeightResizePolicy = HeightResizePolicy.Value;
            }
            if (SizeModeFactor != null)
            {
                view.SizeModeFactor = SizeModeFactor;
            }

            if (!appliedViews.ContainsKey(view))
            {
                appliedViews.Add(view, 0);
                RegisterStateChangeCallback(view);
            }
        }

        protected virtual void RegisterStateChangeCallback(View view)
        {
            view.FocusGained += (object sender, global::System.EventArgs e) =>
            {
                ApplyToView(view, ControlStates.Focused);
            };

            view.FocusLost += (object sender, global::System.EventArgs e) =>
            {
                ApplyToView(view, ControlStates.Normal);
            };
        }

        public void DisApplyToView(View view)
        {
            if (appliedViews.ContainsKey(view))
            {
                appliedViews.Remove(view);
            }
        }

        private void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            foreach (KeyValuePair<View, int> keyValuePair in appliedViews)
            {
                ApplyToView(keyValuePair.Key);
            }
        }

        private Dictionary<View, int> appliedViews = new Dictionary<View, int>();
    }
}
