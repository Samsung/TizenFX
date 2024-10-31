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
        private PWEngine.BrushType mBrushType;

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

        private static readonly Dictionary<PWEngine.BrushType, Action> BrushConfigs = new Dictionary<PWEngine.BrushType, Action>
        {
            { PWEngine.BrushType.Stroke, () => PWEngine.SetStrokeType(0) },
            { PWEngine.BrushType.VarStroke, () => PWEngine.SetStrokeType(6) },
            { PWEngine.BrushType.VarStrokeInc, () => PWEngine.SetStrokeType(7) },
            { PWEngine.BrushType.SprayBrush, () =>
                {
                    PWEngine.SetStrokeType(1);
                    PWEngine.SetBrushTexture(0);
                    PWEngine.SetBrushDistance(3.0f);
                }
            },
            { PWEngine.BrushType.DotBrush, () =>
                {
                    PWEngine.SetStrokeType(1);
                    PWEngine.SetBrushTexture(1);
                    PWEngine.SetBrushDistance(2.0f);
                }
            },
            { PWEngine.BrushType.DashedLine, () =>
                {
                    PWEngine.SetStrokeType(5);
                    PWEngine.SetDashArray("1 3");
                }
            },
            { PWEngine.BrushType.Highlighter, () =>
                {
                    PWEngine.SetStrokeType(1);
                    PWEngine.SetBrushTexture(3);
                    PWEngine.SetBrushDistance(0.25f);
                }
            },
            { PWEngine.BrushType.SoftBrush, () =>
                {
                    PWEngine.SetStrokeType(1);
                    PWEngine.SetBrushTexture(4);
                    PWEngine.SetBrushDistance(1.0f);
                }
            },
            { PWEngine.BrushType.SharpBrush, () => PWEngine.SetStrokeType(8) },
        };

        private ImageView mImgView;
        public BrushIcon(PWEngine.BrushType brushType) : base()
        {
            mBrushType = brushType;

            mImgView = new ImageView();
            mImgView.Size2D = new Size2D(48, 48);

            string url = $"{FrameworkInformation.ResourcePath}images/light/{GetIconUrl(brushType)}.png";

            InitializeIcon(url, new Color("#17234d"));
        }

        private string GetIconUrl(PWEngine.BrushType brushType)
        {
            return IconMap.ContainsKey(brushType) ? IconMap[brushType] : string.Empty;
        }


        public PWEngine.BrushType GetBrushType() => mBrushType;


        public override bool IconClick(object sender, View.TouchEventArgs args)
        {
            if (base.IconClick(sender, args))
            {
                if (BrushConfigs.ContainsKey(GetBrushType()))
                {
                    BrushConfigs[GetBrushType()].Invoke();
                }

            }
            return true;
        }

    }
}