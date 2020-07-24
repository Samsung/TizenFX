using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    public partial class DropDown
    {
        /// <summary>
        /// DropDownDataItem is a class to record all data which will be applied to DropDown item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        //[EditorBrowsable(EditorBrowsableState.Never)]
        public class DropDownDataItem
        {
            internal DropDownItemStyle itemDataStyle = new DropDownItemStyle();

            /// <summary>
            /// Creates a new instance of a DropDownItemData.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownDataItem()
            {
                itemDataStyle = (DropDownItemStyle)StyleManager.Instance.GetComponentStyle(this.GetType());
                Initialize();
            }

            /// <summary>
            /// Creates a new instance of a DropDownItemData with style.
            /// </summary>
            /// <param name="style">Create DropDownItemData by special style defined in UX.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownDataItem(string style)
            {
                if (style != null)
                {
                    ViewStyle viewStyle = StyleManager.Instance.GetViewStyle(style);
                    if (viewStyle == null)
                    {
                        throw new InvalidOperationException($"There is no style {style}");
                    }
                    itemDataStyle = viewStyle as DropDownItemStyle;
                }
                Initialize();
            }

            /// <summary>
            /// Creates a new instance of a DropDownItemData with style.
            /// </summary>
            /// <param name="style">Create DropDownItemData by style customized by user.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownDataItem(DropDownItemStyle style)
            {
                itemDataStyle.CopyFrom(style);
                Initialize();
            }

            /// <summary>
            /// DropDown item size.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size Size
            {
                get
                {
                    return itemDataStyle.Size;
                }
                set
                {
                    itemDataStyle.Size = value;
                }
            }

            /// <summary>
            /// DropDown item background color selector.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Selector<Color> BackgroundColor
            {
                get
                {
                    return itemDataStyle.BackgroundColor;
                }
                set
                {
                    if (null != itemDataStyle)
                    {
                        if (null == itemDataStyle.BackgroundColor)
                        {
                            itemDataStyle.BackgroundColor = new Selector<Color>();
                        }
                        itemDataStyle.BackgroundColor.Clone(value);
                    }
                }
            }

            /// <summary>
            /// DropDown item text string.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Text
            {
                get
                {
                    return itemDataStyle.Text?.Text?.All;
                }
                set
                {
                    if (null == itemDataStyle.Text.Text)
                    {
                        itemDataStyle.Text.Text = new Selector<string> { All = value };
                    }
                    else
                    {
                        itemDataStyle.Text.Text = value;
                    }
                }
            }

            /// <summary>
            /// DropDown item text's point size.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float PointSize
            {
                get
                {
                    return itemDataStyle.Text?.PointSize?.All ?? 0;
                }
                set
                {
                    if (null == itemDataStyle.Text.PointSize)
                    {
                        itemDataStyle.Text.PointSize = new Selector<float?> { All = value };
                    }
                    else
                    {
                        itemDataStyle.Text.PointSize = value;
                    }
                }
            }

            /// <summary>
            /// DropDown item text's font family.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string FontFamily
            {
                get
                {
                    return itemDataStyle.Text.FontFamily?.All;
                }
                set
                {
                    if (null == itemDataStyle.Text.FontFamily)
                    {
                        itemDataStyle.Text.FontFamily = new Selector<string> { All = value };
                    }
                    else
                    {
                        itemDataStyle.Text.FontFamily = value;
                    }
                }
            }

            /// <summary>
            /// DropDown item text's position.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Position TextPosition
            {
                get
                {
                    return itemDataStyle.Text?.Position;
                }
                set
                {
                    itemDataStyle.Text.Position = value;
                }
            }

            /// <summary>
            /// DropDown item's icon's resource url.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string IconResourceUrl
            {
                get
                {
                    return itemDataStyle.Icon?.ResourceUrl?.All;
                }
                set
                {
                    if (null == itemDataStyle.Icon.ResourceUrl)
                    {
                        itemDataStyle.Icon.ResourceUrl = new Selector<string> { All = value };
                    }
                    else
                    {
                        itemDataStyle.Icon.ResourceUrl = value;
                    }
                }
            }

            /// <summary>
            /// DropDown item's icon's size.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size IconSize
            {
                get
                {
                    return itemDataStyle.Icon?.Size;
                }
                set
                {
                    itemDataStyle.Icon.Size = value;
                }
            }

            /// <summary>
            /// DropDown item's icon's position.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Position IconPosition
            {
                get
                {
                    return itemDataStyle.Icon.Position;
                }
                set
                {
                    itemDataStyle.Icon.Position = value;
                }
            }

            /// <summary>
            /// DropDown item's check image's resource url.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string CheckImageResourceUrl
            {
                get
                {
                    return itemDataStyle.CheckImage?.ResourceUrl?.All;
                }
                set
                {
                    if (null == itemDataStyle.CheckImage.ResourceUrl)
                    {
                        itemDataStyle.CheckImage.ResourceUrl = new Selector<string> { All = value };
                    }
                    else
                    {
                        itemDataStyle.CheckImage.ResourceUrl = value;
                    }
                }
            }

            /// <summary>
            /// DropDown item's check image's size.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size CheckImageSize
            {
                get
                {
                    return itemDataStyle.CheckImage?.Size;
                }
                set
                {
                    itemDataStyle.CheckImage.Size = value;
                }
            }

            /// <summary>
            /// DropDown item's check image's right space.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int CheckImageGapToBoundary
            {
                get
                {
                    return itemDataStyle.CheckImageGapToBoundary;
                }
                set
                {
                    itemDataStyle.CheckImageGapToBoundary = value;
                }
            }

            /// <summary>
            /// Flag to decide DropDown item is selected or not.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsSelected
            {
                get
                {
                    return itemDataStyle.IsSelected;
                }
                set
                {
                    itemDataStyle.IsSelected = value;
                }
            }

            private void Initialize()
            {
                if (itemDataStyle == null)
                {
                    throw new Exception("DropDownDataItem style parse error.");
                }
            }
        }
    }
}
