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
    public class BrushIcon : Icon
    {
        private PWEngine.BrushType brushType;
        private readonly IBrushStrategy brushStrategy;

        private static readonly Dictionary<PWEngine.BrushType, string> IconMap = new Dictionary<PWEngine.BrushType, string>
        {
            { PWEngine.BrushType.Stroke, "icon_pencil" },
            { PWEngine.BrushType.VarStroke, "icon_varstroke_dec" },
            { PWEngine.BrushType.VarStrokeInc, "icon_varstroke_inc" },
            { PWEngine.BrushType.SprayBrush, "icon_spray" },
            { PWEngine.BrushType.DotBrush, "icon_dot" },
            { PWEngine.BrushType.DashedLine, "icon_dashed_line" },
            { PWEngine.BrushType.Highlighter, "icon_highlighter" },
            { PWEngine.BrushType.SoftBrush, "icon_soft_brush" },
            { PWEngine.BrushType.SharpBrush, "icon_sharp_brush" },
        };

        private ImageView mImgView;
        public BrushIcon(PWEngine.BrushType brushType) : base()
        {
            brushStrategy = BrushStrategyFactory.GetBrushStrategy(brushType);

            this.brushType = brushType;

            mImgView = new ImageView();
            mImgView.Size2D = new Size2D(48, 48);

            InitializeIcon(new Color("#17234d"));
        }

        protected override string GetDefaultImageUrl()
        {
            return $"{FrameworkInformation.ResourcePath}images/light/{GetIconUrl(brushType)}.png";
        }

        protected override string GetSelectedImageUrl()
        {
            return $"{FrameworkInformation.ResourcePath}images/light/color_icon_selected.png";
        }

        private string GetIconUrl(PWEngine.BrushType brushType)
        {
            return IconMap.ContainsKey(brushType) ? IconMap[brushType] : string.Empty;
        }


        public PWEngine.BrushType GetBrushType() => brushType;


        public override bool IconClick(object sender, View.TouchEventArgs args)
        {
            if (base.IconClick(sender, args))
            {
                brushStrategy.ApplyBrushSettings();

            }
            return true;
        }

    }
}