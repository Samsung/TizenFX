/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.PenWave
{
    public class CanvasTool : ToolBase
    {
        public override ToolBase.ToolType Type => ToolBase.ToolType.Canvas;

        private static readonly string popupBgUrl = $"{FrameworkInformation.ResourcePath}images/light/canvas_popup_bg.png";
        private static readonly List<Color> BgColors = new List<Color>
                        {
                            new Color("#FFFEFE"),
                            new Color("#F0F0F0"),
                            new Color("#B7B7B7"),
                            new Color("#E3F2FF"),
                            new Color("#202022"),
                            new Color("#515151"),
                            new Color("#17234D"),
                            new Color("#090E21"),
                        };

        public CanvasTool()
        {

        }

        protected override void StartDrawing(Vector2 position, uint touchTime)
        {
        }

        protected override void ContinueDrawing(Vector2 position, uint touchTime)
        {
        }

        protected override void EndDrawing()
        {
        }

        protected override void Deactivate()
        {
            EndDrawing();
        }

        public override View GetUI()
        {
            View rootView = new View
            {
                // Layout = new LinearLayout()
                // {
                //     LinearOrientation = LinearLayout.Orientation.Horizontal,
                // },
                Layout = new GridLayout { Columns = 1, RowSpacing = 4 }
            };
            var icon = new PalettIcon();
            rootView.Add(icon);
            icon.IconSelected += OnIconSelected;

            MakePopup(rootView);

            return rootView;
        }

        private void MakePopup(View rootView)
        {
            var bgImage = new ImageView
            {
                BackgroundImage = popupBgUrl,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new GridLayout { Columns = 1, RowSpacing = 4 }
            };
            AddIconsToView(bgImage, BgColors, color => new BackgroundColorIcon(color));
            rootView.Add(bgImage);
        }

        private void AddIconsToView<T>(View rootView, IEnumerable<T>items, Func<T, Icon> iconFactory)
        {
            var view = new View
            {
                // Layout = new LinearLayout()
                // {
                //     LinearOrientation = LinearLayout.Orientation.Horizontal,
                // },
                Layout = new GridLayout { Columns = 4, ColumnSpacing = 8, RowSpacing = 8 },
            };
            foreach (var item in items)
            {
                var icon = iconFactory(item);
                view.Add(icon);
                // icon.IconSelected += OnIconSelected;
            }
            rootView.Add(view);
        }

        // protected override void OnIconSelected()
        // {
        //     base.OnIconSelected();


        // }

    }
}
