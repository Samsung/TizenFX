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
    public class PencilTool : ToolBase
    {
        public override PenWaveToolType Type => PenWaveToolType.Pencil;

        private static readonly string popupBgUrl = $"{FrameworkInformation.ResourcePath}images/light/canvas_popup_bg.png";

        private PenInk ink;
        private uint mCurrentShapeId;
        private bool mIsDrawing = false;

        private Icon pencilIcon;
        private Icon sizeIcon;
        private Icon colorIcon;


        public PencilTool() : base(new PencilToolActionHandler())
        {
            ink = new PenInk();

            InitializePencilTool();
        }

        public PencilTool(PenInk penInk) : base(new PencilToolActionHandler())
        {
            ink = penInk ?? new PenInk();

            InitializePencilTool();
        }

        private void InitializePencilTool()
        {
            pencilIcon = new BrushIcon(PWEngine.BrushType.Stroke); // 현재 선택된 브러쉬 타입으로 업데이트 필요
            AddIcon(pencilIcon);

            sizeIcon = new SizeIcon(12.0f);
            AddIcon(sizeIcon);

            colorIcon = new ColorIcon(Color.Black); // 현재 선택된 색상으로 업데이트 필요
            AddIcon(colorIcon);
        }

        protected override void OnIconSelected(object sender)
        {
            base.OnIconSelected(sender);
            if (sender is BrushIcon)
            {
                Tizen.Log.Info("NUI", $"BrushIcon Selected\n");
                CreateBrushIconsView();
            }
            else if (sender is SizeIcon)
            {
                Tizen.Log.Info("NUI", $"SizeIcon Selected\n");
                CreateSizeIconsView();
            }
            else if (sender is ColorIcon)
            {
                Tizen.Log.Info("NUI", $"ColorIcon Selected\n");
                CreateColorIconsView();
            }
        }

        private void CreateBrushIconsView()
        {
            var view = new ImageView
            {
                BackgroundImage = popupBgUrl,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new GridLayout { Columns = 1, RowSpacing = 4 }
            };
            AddIcons(view, ink.BrushTypes, brushType => new BrushIcon(brushType));
            Position2D position = new Position2D((int)pencilIcon.ScreenPosition.X, (int)pencilIcon.ScreenPosition.Y + 60);
            PopupManager.ShowPopup(view, position);
        }

        private void CreateSizeIconsView()
        {
            var view = new ImageView
            {
                BackgroundImage = popupBgUrl,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new GridLayout { Columns = 1, RowSpacing = 4 }
            };
            AddIcons(view, ink.Sizes, size => new SizeIcon(size));
            Position2D position = new Position2D((int)sizeIcon.ScreenPosition.X, (int)sizeIcon.ScreenPosition.Y + 60);
            PopupManager.ShowPopup(view, position);
        }

        private void CreateColorIconsView()
        {
            var view = new ImageView
            {
                BackgroundImage = popupBgUrl,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new GridLayout { Columns = 1, RowSpacing = 4 }
            };
            AddIcons(view, ink.Colors, color => new ColorIcon(color));
            Position2D position = new Position2D((int)colorIcon.ScreenPosition.X, (int)colorIcon.ScreenPosition.Y + 60);
            PopupManager.ShowPopup(view, position);
        }

        private void AddIcons<T>(View rootView, IEnumerable<T>items, Func<T, Icon> iconFactory)
        {
            var view = new View
            {
                Layout = new GridLayout { Columns = 4, ColumnSpacing = 16, RowSpacing = 16 },
            };
            foreach (var item in items)
            {
                var icon = iconFactory(item);
                view.Add(icon);
                icon.IconSelected += OnPopUnIconSelected;
            }
            rootView.Add(view);
        }

        private void OnPopUnIconSelected(object sender)
        {
            if (sender is BrushIcon)
            {
                pencilIcon.DefaultImage.ResourceUrl = IconStateManager.Instance.CurrentPressedIcon.DefaultImage.ResourceUrl;
            }
            else if (sender is SizeIcon)
            {
                sizeIcon.DefaultImage.Size2D = IconStateManager.Instance.CurrentPressedIcon.DefaultImage.Size2D;
            }
            else if (sender is ColorIcon)
            {
                colorIcon.DefaultImage.Color = (sender as ColorIcon).GetColor();
            }
        }

    }


}