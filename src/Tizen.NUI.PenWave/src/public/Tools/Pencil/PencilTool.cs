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
        public override ToolBase.ToolType Type => ToolBase.ToolType.Pencil;

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
                var brushIconsView = CreateBrushIconsView();
                PopupManager.ShowPopup(brushIconsView);
            }
            else if (sender is SizeIcon)
            {
                Tizen.Log.Info("NUI", $"SizeIcon Selected\n");
                var sizeIconsView = CreateSizeIconsView();
                PopupManager.ShowPopup(sizeIconsView);
            }
            else if (sender is ColorIcon)
            {
                Tizen.Log.Info("NUI", $"ColorIcon Selected\n");
                var colorIconsView = CreateColorIconsView();
                PopupManager.ShowPopup(colorIconsView);
            }
        }

        private View CreateBrushIconsView()
        {
            var view = new ImageView
            {
                BackgroundImage = popupBgUrl,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new GridLayout { Columns = 1, RowSpacing = 4 }
            };
            AddIcons(view, ink.BrushTypes, brushType => new BrushIcon(brushType));
            view.Position2D = new Position2D((int)pencilIcon.ScreenPosition.X, (int)pencilIcon.ScreenPosition.Y + 60);
            return view;
        }

        private View CreateSizeIconsView()
        {
            var view = new ImageView
            {
                BackgroundImage = popupBgUrl,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new GridLayout { Columns = 1, RowSpacing = 4 }
            };
            AddIcons(view, ink.Sizes, size => new SizeIcon(size));
            view.Position2D = new Position2D((int)sizeIcon.ScreenPosition.X, (int)sizeIcon.ScreenPosition.Y + 60);
            return view;
        }

        private View CreateColorIconsView()
        {
            var view = new ImageView
            {
                BackgroundImage = popupBgUrl,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new GridLayout { Columns = 1, RowSpacing = 4 }
            };
            AddIcons(view, ink.Colors, color => new ColorIcon(color));
            view.Position2D = new Position2D((int)colorIcon.ScreenPosition.X, (int)colorIcon.ScreenPosition.Y + 60);
            return view;
        }

        private void AddIcons<T>(View rootView, IEnumerable<T>items, Func<T, Icon> iconFactory)
        {
            var view = new View
            {
                Layout = new GridLayout { Columns = 4, ColumnSpacing = 8, RowSpacing = 8 },
            };
            foreach (var item in items)
            {
                var icon = iconFactory(item);
                view.Add(icon);
            }
            rootView.Add(view);
        }

    }


}