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
        private readonly string mIconPencil = "icon_pencil";
        private readonly string mIconVarStrokeDec = "icon_varstroke_dec";
        private readonly string mIconVarStrokeInc = "icon_varstroke_inc";
        private readonly string mIconSprayBrush = "icon_spray";
        private readonly string mIconDotBrush = "icon_dot";
        private readonly string mIconDashedLine = "icon_dashed_line";
        private readonly string mIconHighlighter = "icon_highlighter";
        private readonly string mIconSoftBrush = "icon_soft_brush";
        private readonly string mIconSharpBrush = "icon_sharp_brush";

        private PWEngine.BrushType mBrushType;
        private ImageView mImgView;
        public BrushIcon(PWEngine.BrushType brushType) : base()
        {
            this.Size2D = new Size2D(48, 48);
            mBrushType = brushType;

            mImgView = new ImageView();
            mImgView.Size2D = new Size2D(48, 48);

            string url = string.Format("{0}{1}/{2}.png", FrameworkInformation.ResourcePath + "images/", "light", GetUrl(brushType));

            mImgView.ResourceUrl = url;
            mImgView.Color = new Color("#17234d");
            this.Add(mImgView);
            this.TouchEvent += IconClick;
        }

        private string GetUrl(PWEngine.BrushType brushType)
        {
            string icon;
            switch(brushType)
            {
                case PWEngine.BrushType.Stroke:
                    icon = mIconPencil;
                    break;
                case PWEngine.BrushType.VarStroke:
                    icon = mIconVarStrokeDec;
                    break;
                case PWEngine.BrushType.VarStrokeInc:
                    icon = mIconVarStrokeInc;
                    break;
                case PWEngine.BrushType.SprayBrush:
                    icon = mIconSprayBrush;
                    break;
                case PWEngine.BrushType.DotBrush:
                    icon = mIconDotBrush;
                    break;
                case PWEngine.BrushType.DashedLine:
                    icon = mIconDashedLine;
                    break;
                case PWEngine.BrushType.Highlighter:
                    icon = mIconHighlighter;
                    break;
                case PWEngine.BrushType.SoftBrush:
                    icon = mIconSoftBrush;
                    break;
                case PWEngine.BrushType.SharpBrush:
                    icon = mIconSharpBrush;
                    break;
                default:
                    icon = "";
                    break;

            }
            return icon;
        }

        public override void OnStateChanged()
        {
        }

        public PWEngine.BrushType GetType()
        {
            return mBrushType;
        }

        protected bool IconClick(object sender, View.TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == PointStateType.Down)
            {
                switch(GetType())
                {
                    case PWEngine.BrushType.Stroke:
                        PWEngine.SetStrokeType(0);
                        break;
                    case PWEngine.BrushType.VarStroke:
                        PWEngine.SetStrokeType(6);
                        break;
                    case PWEngine.BrushType.VarStrokeInc:
                        PWEngine.SetStrokeType(7);
                        break;
                    case PWEngine.BrushType.SprayBrush:
                        PWEngine.SetStrokeType(1);
                        PWEngine.SetBrushTexture(0);
                        PWEngine.SetBrushDistance(3.0f);
                        break;
                    case PWEngine.BrushType.DotBrush:
                        PWEngine.SetStrokeType(1);
                        PWEngine.SetBrushTexture(1);
                        PWEngine.SetBrushDistance(2.0f);
                        break;
                    case PWEngine.BrushType.DashedLine:
                        PWEngine.SetStrokeType(5);
                        PWEngine.SetDashArray("1 3");
                        break;
                    case PWEngine.BrushType.Highlighter:
                        PWEngine.SetStrokeType(1);
                        PWEngine.SetBrushTexture(3);
                        PWEngine.SetBrushDistance(0.25f);
                        break;
                    case PWEngine.BrushType.SoftBrush:
                        PWEngine.SetStrokeType(1);
                        PWEngine.SetBrushTexture(4);
                        PWEngine.SetBrushDistance(1.0f);
                        break;
                    case PWEngine.BrushType.SharpBrush:
                        PWEngine.SetStrokeType(8);
                        break;
                    default:
                        break;
                }

            }
            return true;
        }

    }
}