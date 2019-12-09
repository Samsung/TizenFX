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
using System;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// SelectButton is base class of CheckBox and RadioButton.
    /// It can be used as selector and add into group for single-choice or multiple-choice .
    /// User can handle Navigation by adding/inserting/deleting NavigationItem.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SelectButton : Button
    {
        /// <summary>
        /// Item group which is used to manager all SelectButton in it.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected SelectGroup itemGroup = null;

        private ImageControl selectableImage;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new SelectButtonStyle Style => ViewStyle as SelectButtonStyle;

        /// <summary>
        /// Creates a new instance of a SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectButton() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a SelectButton with style.
        /// </summary>
        /// <param name="style">Create SelectButton by special style defined in UX.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectButton(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a SelectButton with style.
        /// </summary>
        /// <param name="style">Create SelectButton by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectButton(SelectButtonStyle style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// An event for the item selected signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SelectEventArgs> SelectedEvent;

        /// <summary>
        /// Index of selection in selection group. If selection is not in the group, return -1;
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Index
        {
            get
            {
                if (itemGroup != null)
                {
                    return itemGroup.GetIndex(this);
                }

                return -1;
            }
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            SelectButtonStyle selectButtonStyle = StyleManager.Instance.GetAttributes(style) as SelectButtonStyle;
            if (null != selectButtonStyle)
            {
                Style?.CopyFrom(selectButtonStyle);
                UpdateUIContent();
            }
        }

        /// <summary>
        /// Dispose SelectButton and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (selectableImage != null)
                {
                    Remove(selectableImage);
                    selectableImage.Dispose();
                    selectableImage = null;
                }
            }

            base.Dispose(type);
        }

        private void UpdateUIContent()
        {
            UpdateTextAttributes();
            base.OnUpdate();

            selectableImage?.RaiseToTop();
        }

        /// <summary>
        /// Called after a key event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event.</param>
        /// <returns>True if the key event should be consumed.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnKey(Key key)
        {
            if (IsEnabled == false)
            {
                return false;
            }
            bool ret = base.OnKey(key);
            if (key.State == Key.StateType.Up)
            {
                if (key.KeyPressedName == "Return")
                {
                    OnSelect();
                }
            }

            return ret;
        }

        /// <summary>
        /// Called after a touch event is received by the owning view.<br />
        /// CustomViewBehaviour.REQUIRES_TOUCH_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br />
        /// </summary>
        /// <param name="touch">The touch event.</param>
        /// <returns>True if the event should be consumed.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnTouch(Touch touch)
        {
            if (false == IsEnabled)
            {
                return false;
            }

            PointStateType state = touch.GetState(0);
            bool ret = base.OnTouch(touch);
            switch (state)
            {
                case PointStateType.Up:
                    OnSelect();
                    break;
                default:
                    break;
            }
            return ret;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            SelectButtonStyle selectButtonStyle = viewStyle as SelectButtonStyle;

            if (null != selectButtonStyle)
            {
                if (selectableImage == null)
                {
                    selectableImage = new ImageControl();
                    selectableImage.Name = "SelectableImage";
                    Add(selectableImage);

                    selectableImage.RaiseToTop();
                }

                selectableImage.ApplyStyle(selectButtonStyle.SelectableImage);
            }
        }

        /// <summary>
        /// Get SelectButton attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new SelectButtonStyle();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior after pressing return key by user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnSelected()
        {
        }

        private void Initialize()
        {
            if (null == Style) return;
            if (null == selectableImage)
            {
                selectableImage = new ImageControl();
                selectableImage.Name = "SelectableImage";
                Add(selectableImage);

                selectableImage.RaiseToTop();
            }
            if (style != null)
            {
                Style.SelectableImage.PositionUsesPivotPoint = true;
                Style.SelectableImage.ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
                Style.SelectableImage.PivotPoint = Tizen.NUI.PivotPoint.TopLeft;

            if (null == Style.SelectableImage)
            {
                Style.SelectableImage = new ImageControlStyle();
            }
            Style.SelectableImage.PositionUsesPivotPoint = true;
            Style.SelectableImage.ParentOrigin = NUI.ParentOrigin.TopLeft;
            Style.SelectableImage.PivotPoint = NUI.PivotPoint.TopLeft;

            Style.IsSelectable = true;
            LayoutDirectionChanged += SelectButtonLayoutDirectionChanged;
        }

        private void UpdateTextAttributes()
        {
            if (null == Style) return;
            if (null == selectableImage) return;
            if (null != Style.Text)
            {
                Style.Text.PositionUsesPivotPoint = true;
                Style.Text.ParentOrigin = NUI.ParentOrigin.TopLeft;
                Style.Text.PivotPoint = NUI.PivotPoint.TopLeft;
                Style.Text.WidthResizePolicy = ResizePolicyType.Fixed;
                Style.Text.HeightResizePolicy = ResizePolicyType.Fixed;

                int iconWidth = (int)selectableImage.SizeWidth;

                int textPaddingLeft = Style.Text.Padding?.Start ?? 0;
                int textPaddingRight = Style.Text.Padding?.End ?? 0;
                int imagePaddingStart = selectableImage.Padding?.Start ?? 0;
                int imagePaddingEnd = selectableImage.Padding?.End ?? 0;

                if (null == Style.Text.Size && null != Size2D)
                {
                    Style.Text.Size = new Size(Size2D.Width - iconWidth - imagePaddingStart - imagePaddingEnd - textPaddingLeft - textPaddingRight, Size2D.Height);
                }
                
                if(null == Style.Text.Position)
                {
                    Style.Text.Position = new Position(imagePaddingStart + iconWidth + imagePaddingEnd + textPaddingLeft, 0);
                }

                Style.Text.VerticalAlignment = VerticalAlignment.Center;
            }
        }

        private void SelectButtonLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            if (null == Style || null == Style.Text) return;
            if (null == selectableImage) return;

            UpdateTextAttributes();

            int iconWidth = (int)selectableImage.SizeWidth;

            int textPaddingLeft = Style.Text.Padding?.Start ?? 0;
            int textPaddingRight = Style.Text.Padding?.End ?? 0;
            int pos = 0;
            int sizeWidth = (int)(Style.Text.Size?.Width ?? 0);
            if (null == Style.Text.Position)
            {
                Style.Text.Position = new Position(0, 0, 0);
            }
            if (LayoutDirection == ViewLayoutDirectionType.RTL)
            {
                Style.Text.HorizontalAlignment = HorizontalAlignment.End;
                
                Style.Text.Position.X = textPaddingRight;
				pos = sizeWidth + textPaddingLeft + textPaddingRight;
                if (null != Style.Icon?.Padding)
                {
                    pos += Style.Icon.Padding.End;
                }
            }
            else if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                Style.Text.HorizontalAlignment = HorizontalAlignment.Begin;
                Style.Text.Position.X = iconWidth + textPaddingLeft;
                if (null != Style.Icon?.Padding)
				{
                    Style.Text.Position.X += (Style.Icon.Padding.Start + Style.Icon.Padding.End); 
                    pos = Style.Icon.Padding.Start;
				}
            }
            if (null == selectableImage.Position2D)
            {
                selectableImage.Position2D = new Position2D(0, 0);
            }
            selectableImage.Position2D.X = pos;
        }

        private void OnSelect()
        {    
            OnSelected();

            if (SelectedEvent != null)
            {
                SelectEventArgs eventArgs = new SelectEventArgs();
                eventArgs.IsSelected = IsSelected;
                SelectedEvent(this, eventArgs);
            }
        }

        /// <summary>
        /// SelectEventArgs is a class to record item selected arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class SelectEventArgs : EventArgs
        {
            /// <summary> Select state of SelectButton </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsSelected;
        }
    }
}
