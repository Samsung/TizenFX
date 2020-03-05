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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabStyle is a class which saves Tab's ux data.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class TabStyle : ControlStyle
    {
        static TabStyle() { }

        /// <summary>
        /// Creates a new instance of a TabStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public TabStyle() : base()
        {
            ItemPadding = new Extents(0, 0, 0, 0);
            UseTextNaturalSize = false;
            ItemSpace = 0;

            UnderLine = new ViewStyle();
            Text = new TextLabelStyle();
        }

        /// <summary>
        /// Creates a new instance of a TabStyle with style.
        /// </summary>
        /// <param name="style">Create TabStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public TabStyle(TabStyle style) : base(style)
        {
            UnderLine = new ViewStyle();
            Text = new TextLabelStyle();

            if (null == style)
            {
                return;
            }

            if (style.UnderLine != null)
            {
                UnderLine?.CopyFrom(style.UnderLine);
            }

            if (style.Text != null)
            {
                Text?.CopyFrom(style.Text);
            }

            if (style.ItemPadding != null)
            {
                ItemPadding = new Extents(style.ItemPadding.Start, style.ItemPadding.End, style.ItemPadding.Top, style.ItemPadding.Bottom);
            }
            else
            {
                ItemPadding = new Extents(0, 0, 0, 0);
            }
            ItemSpace = style.ItemSpace;
            UseTextNaturalSize = style.UseTextNaturalSize;

            if (null != style.UnderLine)
            {
                UnderLine?.CopyFrom(style.UnderLine);
            }

            if (null != style.Text)
            {
                Text?.CopyFrom(style.Text);
            }
        }

        /// <summary>
        /// UnderLine's attributes.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ViewStyle UnderLine { get; set; }

        /// <summary>
        /// Text's attributes.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public TextLabelStyle Text { get; set; }

        /// <summary>
        /// Flag to decide if item is fill with item text's natural width.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool UseTextNaturalSize { get; set; }

        /// <summary>
        /// Gap between items.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public int ItemSpace { get; set; }

        /// <summary>
        /// Space in Tab.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Extents ItemPadding { get; set; }

        /// <summary>
        /// Style's clone function.
        /// </summary>
        /// <param name="bindableObject">The style that need to copy.</param>
        /// <since_tizen> 8 </since_tizen>>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);
            TabStyle tabStyle = bindableObject as TabStyle;

            if (null != tabStyle)
            {
                if (null != tabStyle.ItemPadding)
                {
                    ItemPadding?.CopyFrom(tabStyle.ItemPadding);
                }

                ItemSpace = tabStyle.ItemSpace;
                UseTextNaturalSize = tabStyle.UseTextNaturalSize;

                if (null != tabStyle.UnderLine)
                {
                    UnderLine?.CopyFrom(tabStyle.UnderLine);
                }

                if (null != tabStyle.Text)
                {
                    Text?.CopyFrom(tabStyle.Text);
                }
            }
        }
    }
}
