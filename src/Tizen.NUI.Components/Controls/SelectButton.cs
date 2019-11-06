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

        private ImageView checkShadowImage;
        private ImageView checkBackgroundImage;
        private ImageView checkImage;

        private SelectButtonAttributes selectButtonAttributes;

        private Extents selectableImagePadding = null;

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
        /// Creates a new instance of a SelectButton with attributes.
        /// </summary>
        /// <param name="attributes">Create SelectButton by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectButton(SelectButtonAttributes attributes) : base(attributes)
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
        /// Check image's resource url in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CheckImageURL
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckImageAttributes();
                    if (selectButtonAttributes.CheckImageAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.CheckImageAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.CheckImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Check image's resource url selector in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector CheckImageURLSelector
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckImageAttributes();
                    selectButtonAttributes.CheckImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Check image's opacity in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CheckImageOpacity
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                CreateCheckImageAttributes();
                if (selectButtonAttributes.CheckImageAttributes.Opacity == null)
                {
                    selectButtonAttributes.CheckImageAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.CheckImageAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Check image's opacity selector in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector CheckImageOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckImageAttributes();
                    selectButtonAttributes.CheckImageAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Check image's size in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size CheckImageSize
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.Size ?? new Size(0, 0, 0);
            }
            set
            {
                CreateCheckImageAttributes();
                selectButtonAttributes.CheckImageAttributes.Size = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Background image's resource url in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CheckBackgroundImageURL
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckBackgroundImageAttributes();
                    if (selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Background image's resource url selector in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector CheckBackgroundImageURLSelector
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckBackgroundImageAttributes();
                    selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Background image's opacity in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CheckBackgroundImageOpacity
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                CreateCheckBackgroundImageAttributes();
                if (selectButtonAttributes.CheckBackgroundImageAttributes.Opacity == null)
                {
                    selectButtonAttributes.CheckBackgroundImageAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.CheckBackgroundImageAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Background image's opacity selector in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector CheckBackgroundImageOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckBackgroundImageAttributes();
                    selectButtonAttributes.CheckBackgroundImageAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Shadow image's resource url in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CheckShadowImageURL
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckShadowImageAttributes();
                    if (selectButtonAttributes.CheckShadowImageAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.CheckShadowImageAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.CheckShadowImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Shadow image's resource url selector in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector CheckShadowImageURLSelector
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckShadowImageAttributes();
                    selectButtonAttributes.CheckShadowImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Shadow image's opacity in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CheckShadowImageOpacity
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                CreateCheckShadowImageAttributes();
                if (selectButtonAttributes.CheckShadowImageAttributes.Opacity == null)
                {
                    selectButtonAttributes.CheckShadowImageAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.CheckShadowImageAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Shadow image's opacity selector in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector CheckShadowImageOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckShadowImageAttributes();
                    selectButtonAttributes.CheckShadowImageAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// CheckImage left padding in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents SelectableImagePadding
        {
            get
            {
                return selectableImagePadding;
            }
            set
            {
                CreateCheckImageAttributes();
                CreateCheckBackgroundImageAttributes();
                CreateCheckShadowImageAttributes();

                selectButtonAttributes.CheckImageAttributes.Padding.CopyFrom(value);
                selectButtonAttributes.CheckBackgroundImageAttributes.Padding.CopyFrom(value);
                selectButtonAttributes.CheckShadowImageAttributes.Padding.CopyFrom(value);

                if (null == selectableImagePadding)
                {
                    selectableImagePadding = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                    {
                        selectButtonAttributes.CheckImageAttributes.Padding.Start = start;
                        selectButtonAttributes.CheckImageAttributes.Padding.End = end;
                        selectButtonAttributes.CheckImageAttributes.Padding.Top = top;
                        selectButtonAttributes.CheckImageAttributes.Padding.Bottom = bottom;

                        selectButtonAttributes.CheckBackgroundImageAttributes.Padding.Start = start;
                        selectButtonAttributes.CheckBackgroundImageAttributes.Padding.End = end;
                        selectButtonAttributes.CheckBackgroundImageAttributes.Padding.Top = top;
                        selectButtonAttributes.CheckBackgroundImageAttributes.Padding.Bottom = bottom;

                        selectButtonAttributes.CheckShadowImageAttributes.Padding.Start = start;
                        selectButtonAttributes.CheckShadowImageAttributes.Padding.End = end;
                        selectButtonAttributes.CheckShadowImageAttributes.Padding.Top = top;
                        selectButtonAttributes.CheckShadowImageAttributes.Padding.Bottom = bottom;

                        RelayoutRequest();
                    }, value.Start, value.End, value.Top, value.Bottom);
                }
                else
                {
                    selectableImagePadding.CopyFrom(value);
                }

                RelayoutRequest();
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
            SelectButtonAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as SelectButtonAttributes;
            if (tempAttributes != null)
            {
                attributes = selectButtonAttributes = tempAttributes;
                RelayoutRequest();
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
                if (checkShadowImage != null)
                {
                    Remove(checkShadowImage);
                    checkShadowImage.Dispose();
                    checkShadowImage = null;
                }
                if (checkBackgroundImage != null)
                {
                    Remove(checkBackgroundImage);
                    checkBackgroundImage.Dispose();
                    checkBackgroundImage = null;
                }
                if (checkImage != null)
                {
                    Remove(checkImage);
                    checkImage.Dispose();
                    checkImage = null;
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Update SelectButton by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            if (selectButtonAttributes.CheckImageAttributes != null)
            {
                if (checkImage == null)
                {
                    checkImage = new ImageView();
                    checkImage.Name = "CheckImage";
                    Add(checkImage);
                }
                ApplyAttributes(checkImage, selectButtonAttributes.CheckImageAttributes);  
            }
            else
            {
                if (checkImage != null)
                {
                    Remove(checkImage);
                    checkImage.Dispose();
                    checkImage = null;
                }
            }

            if (selectButtonAttributes.CheckShadowImageAttributes != null)
            {
                if (checkShadowImage == null)
                {
                    checkShadowImage = new ImageView();
                    checkShadowImage.Name = "CheckShadowImage";
                    Add(checkShadowImage);
                }
                ApplyAttributes(checkShadowImage, selectButtonAttributes.CheckShadowImageAttributes);
            }
            else
            {
                if (checkShadowImage != null)
                {
                    Remove(checkShadowImage);
                    checkShadowImage.Dispose();
                    checkShadowImage = null;
                }
            }

            if (selectButtonAttributes.CheckBackgroundImageAttributes != null)
            {
                if (checkBackgroundImage == null)
                {
                    checkBackgroundImage = new ImageView();
                    checkBackgroundImage.Name = "CheckBackgroundImage";
                    Add(checkBackgroundImage);
                }
                ApplyAttributes(checkBackgroundImage, selectButtonAttributes.CheckBackgroundImageAttributes);
            }
            else
            {
                if (checkBackgroundImage != null)
                {
                    Remove(checkBackgroundImage);
                    checkBackgroundImage.Dispose();
                    checkBackgroundImage = null;
                }
            }

            UpdateTextAttributes();
            base.OnUpdate();

            checkShadowImage?.RaiseToTop();
            checkBackgroundImage?.RaiseToTop();
            checkImage?.RaiseToTop();
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
            if (IsEnabled == false)
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

        /// <summary>
        /// Get SelectButton attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new SelectButtonAttributes();
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
            selectButtonAttributes = attributes as SelectButtonAttributes;
            if (selectButtonAttributes == null)
            {
                throw new Exception("SelectButton attribute parse error.");
            }

            selectButtonAttributes.IsSelectable = true;
            LayoutDirectionChanged += SelectButtonLayoutDirectionChanged;
        }

        private void UpdateTextAttributes()
        {
            if (selectButtonAttributes.TextAttributes != null)
            {
                selectButtonAttributes.TextAttributes.PositionUsesPivotPoint = true;
                selectButtonAttributes.TextAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
                selectButtonAttributes.TextAttributes.PivotPoint = Tizen.NUI.PivotPoint.TopLeft;
                selectButtonAttributes.TextAttributes.WidthResizePolicy = ResizePolicyType.Fixed;
                selectButtonAttributes.TextAttributes.HeightResizePolicy = ResizePolicyType.Fixed;

                int iconWidth = (int)CheckImageSize.Width;

                int textPaddingLeft = selectButtonAttributes.TextAttributes.Padding.Start;
                int textPaddingRight = selectButtonAttributes.TextAttributes.Padding.End;

                if(selectButtonAttributes.TextAttributes.Size == null)
                {
                    selectButtonAttributes.TextAttributes.Size = new Size(Size2D.Width - iconWidth - SelectableImagePadding.Start - SelectableImagePadding.End - textPaddingLeft - textPaddingRight, Size2D.Height);
                }
                
                if(selectButtonAttributes.TextAttributes.Position == null)
                {
                    selectButtonAttributes.TextAttributes.Position = new Position(SelectableImagePadding.Start + iconWidth + SelectableImagePadding.End + textPaddingLeft, 0);
                }
                
                selectButtonAttributes.TextAttributes.VerticalAlignment = VerticalAlignment.Center;
            }
        }

        private void SelectButtonLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            if (selectButtonAttributes == null || selectButtonAttributes.TextAttributes == null)
            {
                return;
            }

            UpdateTextAttributes();

            int iconWidth = (int)CheckImageSize.Width;

            int textPaddingLeft = selectButtonAttributes.TextAttributes.Padding.Start;
            int textPaddingRight = selectButtonAttributes.TextAttributes.Padding.End;
            int pos = 0;
            if (LayoutDirection == ViewLayoutDirectionType.RTL)
            {
                selectButtonAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.End;
                selectButtonAttributes.TextAttributes.Position.X = textPaddingRight;
				pos = (int)(selectButtonAttributes.TextAttributes.Size.Width) + textPaddingLeft + textPaddingRight;
                if (IconPadding != null)
				{
                    pos += IconPadding.End;
				}

            }
            else if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                selectButtonAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.Begin;
                selectButtonAttributes.TextAttributes.Position.X = iconWidth + textPaddingLeft;
                if (IconPadding != null)
				{
                    selectButtonAttributes.TextAttributes.Position.X += (IconPadding.Start + IconPadding.End); 
                    pos = IconPadding.Start;
				}
            }
			
			checkShadowImage.Position2D.X = checkBackgroundImage.Position2D.X = checkImage.Position2D.X = pos;

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

        private void CreateCheckImageAttributes()
        {
            if (selectButtonAttributes.CheckImageAttributes == null)
            {
                selectButtonAttributes.CheckImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint =  Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        private void CreateCheckBackgroundImageAttributes()
        {
            if (selectButtonAttributes.CheckBackgroundImageAttributes == null)
            {
                selectButtonAttributes.CheckBackgroundImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        private void CreateCheckShadowImageAttributes()
        {
            if (selectButtonAttributes.CheckShadowImageAttributes == null)
            {
                selectButtonAttributes.CheckShadowImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint =  Tizen.NUI.PivotPoint.TopLeft,
                };
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
