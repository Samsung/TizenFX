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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The default Tab style
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultTabStyle : StyleBase
    {
        /// <summary>
        /// Return default Tab style
        /// </summary>
        internal protected override ViewStyle GetViewStyle()
        {
            TabStyle style = new TabStyle
            {
                BackgroundColor = Color.Yellow,
                Size = new Size(480, 80),
                UnderLine = new ViewStyle
                {
                    Size = new Size(0, 6),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 1),
                },
                Text = new TextLabelStyle
                {
                    PointSize = DefaultStyle.PointSizeTitle,
                    TextColor = new Selector<Color>
                    {
                        Normal = Color.Black,
                        Selected = new Color(0.05f, 0.63f, 0.9f, 1),
                    },
                },
            };
            return style;
        }
    }
}
