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
            btGroup.SetInternalItemheight((float)newValue);
        }
        internal static object GetInternalItemheightProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.GetInternalItemheight();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemPointSizeProperty = null;
        internal static void SetInternalItemPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            btGroup.SetInternalItemPointSize((float)newValue);
        }
        internal static object GetInternalItemPointSizeProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.GetInternalItemPointSize();
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemFontFamilyProperty = null;
        internal static void SetInternalItemFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            btGroup.SetInternalItemFontFamily((string)newValue);
        }
        internal static object GetInternalItemFontFamilyProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.GetInternalItemFontFamily();
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemTextColorProperty = null;
        internal static void SetInternalItemTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            btGroup.SetInternalItemTextColor((Color)newValue);
        }
        internal static object GetInternalItemTextColorProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.GetInternalItemTextColor();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemTextAlignmentProperty = null;
        internal static void SetInternalItemTextAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            btGroup.SetInternalItemTextAlignment((HorizontalAlignment)newValue);
        }
        internal static object GetInternalItemTextAlignmentProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.GetInternalItemTextAlignment();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OverLayBackgroundColorSelectorProperty = null;
        internal static void SetInternalOverLayBackgroundColorSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            btGroup.SetInternalOverLayBackgroundColorSelector((Selector<Color>)newValue);
        }
        internal static object GetInternalOverLayBackgroundColorSelectorProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.GetInternalOverLayBackgroundColorSelector();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemBackgroundImageUrlProperty = null;
        internal static void SetInternalItemBackgroundImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            btGroup.SetInternalItemBackgroundImageUrl((string)newValue);
        }
        internal static object GetInternalItemBackgroundImageUrlProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.GetInternalItemBackgroundImageUrl();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemBackgroundBorderProperty = null;
        internal static void SetInternalItemBackgroundBorderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            btGroup.SetInternalItemBackgroundBorder((Rectangle)newValue);
        }
        internal static object GetInternalItemBackgroundBorderProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.GetInternalItemBackgroundBorder();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemImageShadowProperty = null;
        internal static void SetInternalItemImageShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            btGroup.SetInternalItemImageShadow((ImageShadow)newValue);
        }
        internal static object GetInternalItemImageShadowProperty(BindableObject bindable)
        {
            ButtonGroup btGroup = (ButtonGroup)bindable;
            return btGroup.GetInternalItemImageShadow();
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
                    return GetInternalItemheight();
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
                    SetInternalItemheight(value);
                }
            }
        }

        private void SetInternalItemheight(float newValue)
        {
            if (itemGroup != null)
            {
                foreach (Button btn in itemGroup)
                {
                    btn.SizeHeight = (float)newValue;
                }
                itemheight = newValue;
            }
        }

        private float GetInternalItemheight()
        {
            return itemheight;
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
                    return GetInternalItemPointSize();
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
                    SetInternalItemPointSize(value);
                }
            }
        }

        private void SetInternalItemPointSize(float newValue)
        {
            if (itemGroup != null)
            {
                foreach (Button btn in itemGroup)
                {
                    btn.TextLabel.PointSize = (float)newValue;
                }
                itemPointSize = newValue;
            }
        }

        private float GetInternalItemPointSize()
        {
            return itemPointSize;
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
                    return GetInternalItemFontFamily();
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
                    SetInternalItemFontFamily(value);
                }
            }
        }

        private void SetInternalItemFontFamily(string newValue)
        {
            if (itemGroup != null && newValue != null)
            {
                foreach (Button btn in itemGroup)
                {
                    btn.TextLabel.FontFamily = newValue;
                }
                itemFontFamily = newValue;
            }
        }

        private string GetInternalItemFontFamily()
        {
            return itemFontFamily;
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
                    return GetInternalItemTextColor();
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
                    SetInternalItemTextColor(value);
                }
            }
        }

        private void SetInternalItemTextColor(Color newValue)
        {
            if (itemGroup != null && newValue != null)
            {
                foreach (Button btn in itemGroup)
                {
                    btn.TextLabel.TextColor = newValue;
                }
                itemTextColor = newValue;
            }
        }

        private Color GetInternalItemTextColor()
        {
            return itemTextColor;
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
                    return GetInternalItemTextAlignment();
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
                    SetInternalItemTextAlignment(value);
                }
            }
        }

        private void SetInternalItemTextAlignment(HorizontalAlignment newValue)
        {
            if (itemGroup != null)
            {
                foreach (Button btn in itemGroup)
                {
                    btn.TextLabel.HorizontalAlignment = newValue;
                }
                itemTextAlignment = newValue;
            }
        }

        private HorizontalAlignment GetInternalItemTextAlignment()
        {
            return itemTextAlignment;
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
                    return GetInternalOverLayBackgroundColorSelector();
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
                    SetInternalOverLayBackgroundColorSelector(value);
                }
            }
        }

        private void SetInternalOverLayBackgroundColorSelector(Selector<Color> newValue)
        {
            if (itemGroup != null && newValue != null)
            {
                foreach (Button btn in itemGroup)
                {
                    if (btn.OverlayImage != null)
                    {
                        btn.OverlayImage.BackgroundColor = newValue.All;
                    }
                }
                overLayBackgroundColorSelector = newValue;
            }
        }

        private Selector<Color> GetInternalOverLayBackgroundColorSelector()
        {
            return overLayBackgroundColorSelector;
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
                    return GetInternalItemBackgroundImageUrl();
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
                    SetInternalItemBackgroundImageUrl(value);
                }
            }
        }

        private void SetInternalItemBackgroundImageUrl(string newValue)
        {
            if (itemGroup != null && newValue != null)
            {
                foreach (Button btn in itemGroup)
                {
                    btn.BackgroundImage = newValue;
                }
                itemBackgroundImageUrl = newValue;
            }
        }

        private string GetInternalItemBackgroundImageUrl()
        {
            return itemBackgroundImageUrl;
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
                    return GetInternalItemBackgroundBorder();
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
                    SetInternalItemBackgroundBorder(value);
                }
            }
        }

        private void SetInternalItemBackgroundBorder(Rectangle newValue)
        {
            if (itemGroup != null && newValue != null)
            {
                foreach (Button btn in itemGroup)
                {
                    btn.BackgroundImageBorder = newValue;
                }
                itemBackgroundBorder = newValue;
            }
        }

        private Rectangle GetInternalItemBackgroundBorder()
        {
            return itemBackgroundBorder;
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
                    return GetInternalItemImageShadow();
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
                    SetInternalItemImageShadow(value);
                }
            }
        }

        private void SetInternalItemImageShadow(ImageShadow newValue)
        {
            if (itemGroup != null)
            {
                var shadow = newValue;
                foreach (Button btn in itemGroup)
                {
                    btn.ImageShadow = new ImageShadow(shadow);
                }
                itemImageShadow = new ImageShadow(shadow);
            }
        }

        private ImageShadow GetInternalItemImageShadow()
        {
            return itemImageShadow;
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
