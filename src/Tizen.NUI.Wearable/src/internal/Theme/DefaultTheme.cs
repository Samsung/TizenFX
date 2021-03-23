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

using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Wearable
{
    internal class DefaultThemeCreator : IThemeCreator
    {
        private DefaultThemeCreator() { }

        public static IThemeCreator Instance { get; set; } = new DefaultThemeCreator();

        public Theme Create()
        {
            var theme = new Theme()
            {
                Id = Tizen.NUI.DefaultThemeCreator.DefaultId,
                Version = Tizen.NUI.DefaultThemeCreator.DefaultVersion
            };

            theme.AddStyleWithoutClone("Tizen.NUI.Wearable.CircularPagination", new CircularPaginationStyle()
            {
                IndicatorSize = new Size(10, 10),
                IndicatorImageURL = new Selector<string>()
                {
                    Normal = FrameworkInformation.ResourcePath + "nui_component_default_pagination_normal_dot.png",
                    Selected = FrameworkInformation.ResourcePath + "nui_component_default_pagination_focus_dot.png",
                },
                CenterIndicatorImageURL = new Selector<string>()
                {
                    Normal = FrameworkInformation.ResourcePath + "nui_wearable_circular_pagination_center_normal_dot.png",
                    Selected = FrameworkInformation.ResourcePath + "nui_wearable_circular_pagination_center_focus_dot.png",
                },
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Wearable.CircularProgress", new CircularProgressStyle()
            {
                Thickness = 6,
                MaxValue = 100,
                MinValue = 0, 
                CurrentValue = 0,
                TrackColor = new Color(0, 0.16f, 0.3f, 1),
                ProgressColor = new Color(0, 0.55f, 1, 1)
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Wearable.CircularScrollbar", new CircularScrollbarStyle()
            {
                Thickness = 10,
                TrackSweepAngle = 60,
                TrackColor = new Color(1, 1, 1, 0.15f),
                ThumbColor = new Color(0.6f, 0.6f, 0.6f, 1)
            });

            theme.AddStyleWithoutClone("Tizen.NUI.Wearable.CircularSlider", new CircularSliderStyle()
            {
                Thickness = 6,
                MaxValue = 100,
                MinValue = 0,
                CurrentValue = 0,
                TrackColor = new Color(0, 0.16f, 0.3f, 1),
                ProgressColor = new Color(0, 0.55f, 1, 1),
                ThumbSize = new Size(19, 19),
                ThumbColor = new Color(0, 0.55f, 1, 1)
            });

            return theme;
        }

        public HashSet<ExternalThemeKeyList> GetExternalThemeKeyListSet() => null;
    }
}
