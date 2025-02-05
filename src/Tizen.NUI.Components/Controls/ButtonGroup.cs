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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ButtonGroup is a group of buttons which can be set common property<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ButtonGroup : BindableObject, global::System.IDisposable
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemheightProperty = null;
        internal static void SetInternalItemheightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            if (btGroup.itemGroup != null && newValue != null)
            {
                foreach (Button btn in btGroup.itemGroup)
                {
                    btn.SizeHeight = (float)newValue;
                }
                btGroup.itemheight = (float)newValue;
            }
        }
        internal static object GetInternalItemheightProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.itemheight;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemPointSizeProperty = null;
        internal static void SetInternalItemPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            if (btGroup.itemGroup != null && newValue != null)
            {
                foreach (Button btn in btGroup.itemGroup)
                {
                    btn.TextLabel.PointSize = (float)newValue;
                }
                btGroup.itemPointSize = (float)newValue;
            }
        }
        internal static object GetInternalItemPointSizeProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.itemPointSize;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemFontFamilyProperty = null;
        internal static void SetInternalItemFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            if (btGroup.itemGroup != null && newValue != null)
            {
                foreach (Button btn in btGroup.itemGroup)
                {
                    btn.TextLabel.FontFamily = (string)newValue;
                }
                btGroup.itemFontFamily = (string)newValue;
            }
        }
        internal static object GetInternalItemFontFamilyProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.itemFontFamily;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemTextColorProperty = null;
        internal static void SetInternalItemTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            if (btGroup.itemGroup != null && newValue != null)
            {
                foreach (Button btn in btGroup.itemGroup)
                {
                    btn.TextLabel.TextColor = (Color)newValue;
                }
                btGroup.itemTextColor = (Color)newValue;
            }
        }
        internal static object GetInternalItemTextColorProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.itemTextColor;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemTextAlignmentProperty = null;
        internal static void SetInternalItemTextAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            if (btGroup.itemGroup != null && newValue != null)
            {
                foreach (Button btn in btGroup.itemGroup)
                {
                    btn.TextLabel.HorizontalAlignment = (HorizontalAlignment)newValue;
                }
                btGroup.itemTextAlignment = (HorizontalAlignment)newValue;
            }
        }
        internal static object GetInternalItemTextAlignmentProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.itemTextAlignment;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OverLayBackgroundColorSelectorProperty = null;
        internal static void SetInternalOverLayBackgroundColorSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            if (btGroup.itemGroup != null && newValue != null)
            {
                foreach (Button btn in btGroup.itemGroup)
                {
                    if (btn.OverlayImage != null)
                    {
                        btn.OverlayImage.BackgroundColor = ((Selector<Color>)newValue).All;
                    }
                }
                btGroup.overLayBackgroundColorSelector = (Selector<Color>)newValue;
            }
        }
        internal static object GetInternalOverLayBackgroundColorSelectorProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.overLayBackgroundColorSelector;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemBackgroundImageUrlProperty = null;
        internal static void SetInternalItemBackgroundImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            if (btGroup.itemGroup != null && newValue != null)
            {
                foreach (Button btn in btGroup.itemGroup)
                {
                    btn.BackgroundImage = (string)newValue;
                }
                btGroup.itemBackgroundImageUrl = (string)newValue;
            }
        }
        internal static object GetInternalItemBackgroundImageUrlProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.itemBackgroundImageUrl;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemBackgroundBorderProperty = null;
        internal static void SetInternalItemBackgroundBorderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            if (btGroup.itemGroup != null && newValue != null)
            {
                foreach (Button btn in btGroup.itemGroup)
                {
                    btn.BackgroundImageBorder = (Rectangle)newValue;
                }
                btGroup.itemBackgroundBorder = (Rectangle)newValue;
            }
        }
        internal static object GetInternalItemBackgroundBorderProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.itemBackgroundBorder;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemImageShadowProperty = null;
        internal static void SetInternalItemImageShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            if (btGroup.itemGroup != null)
            {
                var shadow = (ImageShadow)newValue;
                foreach (Button btn in btGroup.itemGroup)
                {
                    btn.ImageShadow = new ImageShadow(shadow);
                }
                btGroup.itemImageShadow = new ImageShadow(shadow);
            }
        }
        internal static object GetInternalItemImageShadowProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.itemImageShadow;
        }

        static ButtonGroup()
        {
            if (NUIApplication.IsUsingXaml)
            {
                ItemheightProperty = BindableProperty.Create(nameof(Itemheight), typeof(float), typeof(ButtonGroup), 0.0f,
                    propertyChanged: SetInternalItemheightProperty, defaultValueCreator: GetInternalItemheightProperty);
                ItemPointSizeProperty = BindableProperty.Create(nameof(ItemPointSize), typeof(float), typeof(ButtonGroup), 0.0f,
                    propertyChanged: SetInternalItemPointSizeProperty, defaultValueCreator: GetInternalItemPointSizeProperty);
                ItemFontFamilyProperty = BindableProperty.Create(nameof(ItemFontFamily), typeof(string), typeof(ButtonGroup), string.Empty,
                    propertyChanged: SetInternalItemFontFamilyProperty, defaultValueCreator: GetInternalItemFontFamilyProperty);
                ItemTextColorProperty = BindableProperty.Create(nameof(ItemTextColor), typeof(Color), typeof(ButtonGroup), Color.Black,
                    propertyChanged: SetInternalItemTextColorProperty, defaultValueCreator: GetInternalItemTextColorProperty);
                ItemTextAlignmentProperty = BindableProperty.Create(nameof(ItemTextAlignment), typeof(HorizontalAlignment), typeof(ButtonGroup), new HorizontalAlignment(),
                    propertyChanged: SetInternalItemTextAlignmentProperty, defaultValueCreator: GetInternalItemTextAlignmentProperty);
                OverLayBackgroundColorSelectorProperty = BindableProperty.Create(nameof(OverLayBackgroundColorSelector), typeof(Selector<Color>), typeof(ButtonGroup), new Selector<Color>(),
                    propertyChanged: SetInternalOverLayBackgroundColorSelectorProperty, defaultValueCreator: GetInternalOverLayBackgroundColorSelectorProperty);
                ItemBackgroundImageUrlProperty = BindableProperty.Create(nameof(ItemBackgroundImageUrl), typeof(string), typeof(ButtonGroup), string.Empty,
                    propertyChanged: SetInternalItemBackgroundImageUrlProperty, defaultValueCreator: GetInternalItemBackgroundImageUrlProperty);
                ItemBackgroundBorderProperty = BindableProperty.Create(nameof(ItemBackgroundBorder), typeof(Rectangle), typeof(ButtonGroup), new Rectangle(),
                    propertyChanged: SetInternalItemBackgroundBorderProperty, defaultValueCreator: GetInternalItemBackgroundBorderProperty);
                ItemImageShadowProperty = BindableProperty.Create(nameof(ItemImageShadow), typeof(ImageShadow), typeof(ButtonGroup), null,
                    propertyChanged: SetInternalItemImageShadowProperty, defaultValueCreator: GetInternalItemImageShadowProperty);
            }
        }

        /// <summary>
        /// Construct an button group.
        /// </summary>
        /// <param name="view">root view</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ButtonGroup(View view) : base()
        {
            itemGroup = new List<Button>();
            if ((root = view) == null)
            {
                throw new Exception("Root view is null.");
            }
        }

        /// <summary>
        /// Get group item number.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Count
        {
            get
            {
                return itemGroup.Count;
            }
        }

        /// <summary>
        /// Check if the button exists.
        /// </summary>
        /// <param name="bt">button item</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Contains(Button bt)
        {
            return itemGroup.Contains(bt);
        }

        /// <summary>
        /// Get button item index.
        /// </summary>
        /// <param name="bt">button item</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetIndex(Button bt)
        {
            return itemGroup.IndexOf(bt);
        }

        /// <summary>
        /// Get item by index.
        /// </summary>
        /// <param name="index">item index.</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button GetItem(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new Exception("button index error");
            }
            return itemGroup[index];
        }

        /// <summary>
        /// Add item into group.
        /// </summary>
        /// <param name="bt">button item.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddItem(Button bt)
        {
            if (itemGroup.Contains(bt))
            {
                return;
            }
            itemGroup.Add(bt);
            root.Add(bt);
        }

        /// <summary>
        /// The item to removed.
        /// </summary>
        /// <param name="bt">button item.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveItem(Button bt)
        {
            if (null == bt) return;
            if (!itemGroup.Contains(bt))
            {
                return;
            }
            itemGroup.Remove(bt);
            root.Remove(bt);
            bt.Dispose();
        }

        /// <summary>
        /// Remove item by index.
        /// </summary>
        /// <param name="index">item index.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveItem(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new Exception("button index error");
            }
            Button bt = itemGroup[index];
            itemGroup.Remove(bt);
            root.Remove(bt);
            bt.Dispose();
        }

        /// <summary>
        /// Remove all items.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAll()
        {
            foreach (Button bt in itemGroup)
            {
                root.Remove(bt);
                bt.Dispose();
            }
            itemGroup.Clear();
        }

        /// <summary>
        /// Update button by style.
        /// </summary>
        /// <param name="btStyle">button style.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateButton(ButtonStyle btStyle)
        {
            if (Count == 0) return;

            int buttonWidth = (int)root.Size.Width / Count;
            int buttonHeight = (int)Math.Max(btStyle?.Size?.Height ?? 0.0f, itemheight);
            foreach (Button btnTemp in itemGroup)
            {
                btnTemp.Size = new Size(buttonWidth, buttonHeight);
            }

            int pos = 0;
            if (root.LayoutDirection == ViewLayoutDirectionType.RTL)
            {
                for (int i = Count - 1; i >= 0; i--)
                {
                    itemGroup[i].PositionX = pos;
                    pos += (int)(itemGroup[i].Size.Width);
                }
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    itemGroup[i].PositionX = pos;
                    pos += (int)(itemGroup[i].Size.Width);
                }
            }

            if (btStyle == null || btStyle.Text == null || btStyle.Text.TextColor == null) return;
            ItemTextColor = btStyle.Text.TextColor.All;
        }

        /// <summary>
        /// Common height for all of the Items
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Itemheight
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ItemheightProperty);
                }
                else
                {
                    return (float)GetInternalItemheightProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemheightProperty, value);
                }
                else
                {
                    SetInternalItemheightProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Get or set point size of item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ItemPointSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ItemPointSizeProperty);
                }
                else
                {
                    return (float)GetInternalItemPointSizeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemPointSizeProperty, value);
                }
                else
                {
                    SetInternalItemPointSizeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Get or set font family of item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ItemFontFamily
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(ItemFontFamilyProperty);
                }
                else
                {
                    return (string)GetInternalItemFontFamilyProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemFontFamilyProperty, value);
                }
                else
                {
                    SetInternalItemFontFamilyProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Get or set text color of item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ItemTextColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(ItemTextColorProperty);
                }
                else
                {
                    return (Color)GetInternalItemTextColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemTextColorProperty, value);
                }
                else
                {
                    SetInternalItemTextColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Get or set text alignment of item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment ItemTextAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (HorizontalAlignment)GetValue(ItemTextAlignmentProperty);
                }
                else
                {
                    return (HorizontalAlignment)GetInternalItemTextAlignmentProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemTextAlignmentProperty, value);
                }
                else
                {
                    SetInternalItemTextAlignmentProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Get or set background color of item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> OverLayBackgroundColorSelector
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Selector<Color>)GetValue(OverLayBackgroundColorSelectorProperty);
                }
                else
                {
                    return (Selector<Color>)GetInternalOverLayBackgroundColorSelectorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OverLayBackgroundColorSelectorProperty, value);
                }
                else
                {
                    SetInternalOverLayBackgroundColorSelectorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The mutually exclusive with "backgroundColor" and "background" type Map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ItemBackgroundImageUrl
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(ItemBackgroundImageUrlProperty);
                }
                else
                {
                    return (string)GetInternalItemBackgroundImageUrlProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemBackgroundImageUrlProperty, value);
                }
                else
                {
                    SetInternalItemBackgroundImageUrlProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Get or set background border of item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle ItemBackgroundBorder
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Rectangle)GetValue(ItemBackgroundBorderProperty);
                }
                else
                {
                    return (Rectangle)GetInternalItemBackgroundBorderProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemBackgroundBorderProperty, value);
                }
                else
                {
                    SetInternalItemBackgroundBorderProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Get or set shadow resource of item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow ItemImageShadow
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ImageShadow)GetValue(ItemImageShadowProperty);
                }
                else
                {
                    return (ImageShadow)GetInternalItemImageShadowProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemImageShadowProperty, value);
                }
                else
                {
                    SetInternalItemImageShadowProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            if (disposed) return;
            if (itemGroup != null)
            {
                RemoveAll();
                itemGroup = null;
            }
            disposed = true;
        }

        private List<Button> itemGroup;
        private View root = null;
        private bool disposed = false;
        private float itemheight;
        private float itemPointSize;
        private string itemFontFamily;
        private Color itemTextColor = new Color();
        private HorizontalAlignment itemTextAlignment;
        private Selector<Color> overLayBackgroundColorSelector = new Selector<Color>();
        private string itemBackgroundImageUrl;
        private Rectangle itemBackgroundBorder = new Rectangle();
        private ImageShadow itemImageShadow;
    }
}
