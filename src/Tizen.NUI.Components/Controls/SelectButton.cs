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

        private ImageView selectableImageShadow;
        private ImageView selectableImageBackground;
        private ImageView selectableImage;

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
        /// Selectable image's resource url in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SelectableImageURL
        {
            get
            {
                return selectButtonAttributes?.SelectableImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateSelectableImageAttributes();
                    if (selectButtonAttributes.SelectableImageAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.SelectableImageAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.SelectableImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Selectable image's resource url selector in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector SelectableImageURLSelector
        {
            get
            {
                return selectButtonAttributes?.SelectableImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateSelectableImageAttributes();
                    selectButtonAttributes.SelectableImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Selectable image's opacity in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SelectableImageOpacity
        {
            get
            {
                return selectButtonAttributes?.SelectableImageAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                CreateSelectableImageAttributes();
                if (selectButtonAttributes.SelectableImageAttributes.Opacity == null)
                {
                    selectButtonAttributes.SelectableImageAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.SelectableImageAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Selectable image's opacity selector in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector SelectableImageOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.SelectableImageAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateSelectableImageAttributes();
                    selectButtonAttributes.SelectableImageAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Selectable image's size in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size SelectableImageImageSize
        {
            get
            {
                return selectButtonAttributes?.SelectableImageAttributes?.Size ?? new Size(0, 0, 0);
            }
            set
            {
                CreateSelectableImageAttributes();
                selectButtonAttributes.SelectableImageAttributes.Size = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The resource url of Selectable image's background in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SelectableImageBackgroundURL
        {
            get
            {
                return selectButtonAttributes?.SelectableImageBackgroundAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateSelectableImageBackgroundAttributes();
                    if (selectButtonAttributes.SelectableImageBackgroundAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.SelectableImageBackgroundAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.SelectableImageBackgroundAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The resource url selector of Selectable image's background in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector SelectableImageBackgroundURLSelector
        {
            get
            {
                return selectButtonAttributes?.SelectableImageBackgroundAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateSelectableImageBackgroundAttributes();
                    selectButtonAttributes.SelectableImageBackgroundAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The opacity of Selectable image's background in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SelectableImageBackgroundOpacity
        {
            get
            {
                return selectButtonAttributes?.SelectableImageBackgroundAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                CreateSelectableImageBackgroundAttributes();
                if (selectButtonAttributes.SelectableImageBackgroundAttributes.Opacity == null)
                {
                    selectButtonAttributes.SelectableImageBackgroundAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.SelectableImageBackgroundAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The opacity selector of Selectable image's background in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector SelectableImageBackgroundOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.SelectableImageBackgroundAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateSelectableImageBackgroundAttributes();
                    selectButtonAttributes.SelectableImageBackgroundAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The resource url of Selectable image's shadow in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SelectableImageShadowURL
        {
            get
            {
                return selectButtonAttributes?.SelectableImageShadowAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    SelectableImageShadowAttributes();
                    if (selectButtonAttributes.SelectableImageShadowAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.SelectableImageShadowAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.SelectableImageShadowAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The resource url selector of Selectable image's shadow in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector SelectableImageShadowURLSelector
        {
            get
            {
                return selectButtonAttributes?.SelectableImageShadowAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    SelectableImageShadowAttributes();
                    selectButtonAttributes.SelectableImageShadowAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The opacity of Selectable image's shadow in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SelectableImageShadowOpacity
        {
            get
            {
                return selectButtonAttributes?.SelectableImageShadowAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                SelectableImageShadowAttributes();
                if (selectButtonAttributes.SelectableImageShadowAttributes.Opacity == null)
                {
                    selectButtonAttributes.SelectableImageShadowAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.SelectableImageShadowAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The opacity selector of Selectable image's shadow in SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector SelectableImageShadowOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.SelectableImageShadowAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    SelectableImageShadowAttributes();
                    selectButtonAttributes.SelectableImageShadowAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Selectable Image padding in SelectButton.
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
                CreateSelectableImageAttributes();
                CreateSelectableImageBackgroundAttributes();
                SelectableImageShadowAttributes();

                selectButtonAttributes.SelectableImageAttributes.Padding.CopyFrom(value);
                selectButtonAttributes.SelectableImageBackgroundAttributes.Padding.CopyFrom(value);
                selectButtonAttributes.SelectableImageShadowAttributes.Padding.CopyFrom(value);

                if (null == selectableImagePadding)
                {
                    selectableImagePadding = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                    {
                        selectButtonAttributes.SelectableImageAttributes.Padding.Start = start;
                        selectButtonAttributes.SelectableImageAttributes.Padding.End = end;
                        selectButtonAttributes.SelectableImageAttributes.Padding.Top = top;
                        selectButtonAttributes.SelectableImageAttributes.Padding.Bottom = bottom;

                        selectButtonAttributes.SelectableImageBackgroundAttributes.Padding.Start = start;
                        selectButtonAttributes.SelectableImageBackgroundAttributes.Padding.End = end;
                        selectButtonAttributes.SelectableImageBackgroundAttributes.Padding.Top = top;
                        selectButtonAttributes.SelectableImageBackgroundAttributes.Padding.Bottom = bottom;

                        selectButtonAttributes.SelectableImageShadowAttributes.Padding.Start = start;
                        selectButtonAttributes.SelectableImageShadowAttributes.Padding.End = end;
                        selectButtonAttributes.SelectableImageShadowAttributes.Padding.Top = top;
                        selectButtonAttributes.SelectableImageShadowAttributes.Padding.Bottom = bottom;

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
                if (selectableImageShadow != null)
                {
                    Remove(selectableImageShadow);
                    selectableImageShadow.Dispose();
                    selectableImageShadow = null;
                }
                if (selectableImageBackground != null)
                {
                    Remove(selectableImageBackground);
                    selectableImageBackground.Dispose();
                    selectableImageBackground = null;
                }
                if (selectableImage != null)
                {
                    Remove(selectableImage);
                    selectableImage.Dispose();
                    selectableImage = null;
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
            if (selectButtonAttributes.SelectableImageAttributes != null)
            {
                if (selectableImage == null)
                {
                    selectableImage = new ImageView();
                    selectableImage.Name = "SelectableImage";
                    Add(selectableImage);
                }
                ApplyAttributes(selectableImage, selectButtonAttributes.SelectableImageAttributes);  
            }
            else
            {
                if (selectableImage != null)
                {
                    Remove(selectableImage);
                    selectableImage.Dispose();
                    selectableImage = null;
                }
            }

            if (selectButtonAttributes.SelectableImageShadowAttributes != null)
            {
                if (selectableImageShadow == null)
                {
                    selectableImageShadow = new ImageView();
                    selectableImageShadow.Name = "SelectableImageShadow";
                    Add(selectableImageShadow);
                }
                ApplyAttributes(selectableImageShadow, selectButtonAttributes.SelectableImageShadowAttributes);
            }
            else
            {
                if (selectableImageShadow != null)
                {
                    Remove(selectableImageShadow);
                    selectableImageShadow.Dispose();
                    selectableImageShadow = null;
                }
            }

            if (selectButtonAttributes.SelectableImageBackgroundAttributes != null)
            {
                if (selectableImageBackground == null)
                {
                    selectableImageBackground = new ImageView();
                    selectableImageBackground.Name = "SelectableImageBackground";
                    Add(selectableImageBackground);
                }
                ApplyAttributes(selectableImageBackground, selectButtonAttributes.SelectableImageBackgroundAttributes);
            }
            else
            {
                if (selectableImageBackground != null)
                {
                    Remove(selectableImageBackground);
                    selectableImageBackground.Dispose();
                    selectableImageBackground = null;
                }
            }

            UpdateTextAttributes();
            base.OnUpdate();

            selectableImageShadow?.RaiseToTop();
            selectableImageBackground?.RaiseToTop();
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

                int iconWidth = (int)SelectableImageImageSize.Width;

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

            int iconWidth = (int)SelectableImageImageSize.Width;

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
			
			selectableImageShadow.Position2D.X = selectableImageBackground.Position2D.X = selectableImage.Position2D.X = pos;

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

        private void CreateSelectableImageAttributes()
        {
            if (selectButtonAttributes.SelectableImageAttributes == null)
            {
                selectButtonAttributes.SelectableImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint =  Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        private void CreateSelectableImageBackgroundAttributes()
        {
            if (selectButtonAttributes.SelectableImageBackgroundAttributes == null)
            {
                selectButtonAttributes.SelectableImageBackgroundAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        private void SelectableImageShadowAttributes()
        {
            if (selectButtonAttributes.SelectableImageShadowAttributes == null)
            {
                selectButtonAttributes.SelectableImageShadowAttributes = new ImageAttributes()
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
