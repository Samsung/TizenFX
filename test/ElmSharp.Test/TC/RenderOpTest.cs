/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.IO;

namespace ElmSharp.Test
{
    public class RenderOpTest : TestCaseBase
    {

        public override string TestName => "RenderOperationTest";
        public override string TestDescription => "RenderOperation test";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            RenderOp renderOp = RenderOp.Blend;

            var box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = Color.FromHex("00A0DC"),
            };
            box.SetLayoutCallback(() => { });
            box.Show();
            conformant.SetContent(box);;


            var label = new Label(window);
            label.Show();
            box.PackEnd(label);
            label.Geometry = new Rect(10, 10, 800, 100);
            label.Text = "RenderOperation : Blend(Default)";
            label.TextStyle = "DEFAULT = 'color=#000000FF font_size=25'";
            var size = label.EdjeObject["elm.text"].TextBlockFormattedSize;
            label.Geometry = new Rect(10, 10, size.Width+300, size.Height);

            var box11 = new Rectangle(window)
            {
                Color = Color.FromRgba(255, 0, 0, 200)
            };
            box.PackEnd(box11);
            box11.Show();
            box11.Geometry = new Rect(50, 70, 100, 300);

            var box12 = new Rectangle(window)
            {
                Color = Color.FromRgba(0, 255, 0, 200)
            };
            box.PackEnd(box12);
            box12.Show();
            box12.Geometry = new Rect(50+100, 70, 100, 300);

            var box13 = new Rectangle(window)
            {
                Color = Color.FromRgba(0, 0, 250, 200)
            };
            box.PackEnd(box13);
            box13.Show();
            box13.Geometry = new Rect(50+200, 70, 100, 300);

            var box2 = new Rectangle(window)
            {
                Color = Color.FromRgba(0, 255, 100, 200)
            };

            box.PackEnd(box2);
            box2.Show();
            box2.Geometry = new Rect(50, 70 + 100, 300, 300);

            box2.RenderOperation = renderOp;

            var btn = new Button(window) { Text = "Change Render operation" };
            box.PackEnd(btn);
            btn.Show();

            btn.Geometry = new Rect(50, 500, 600, 60);

            btn.Clicked += (s, e) =>
            {
                renderOp += 1;
                if (renderOp > RenderOp.Mul)
                {
                    renderOp = 0;
                }
                switch (renderOp)
                {
                    case RenderOp.Add:
                        label.Text = "RenderOperation : Add (d = d + s)";
                        break;
                    case RenderOp.AddRel:
                        label.Text = "RenderOperation : AddRel (d = d + s*da)";
                        break;
                    case RenderOp.Blend:
                        label.Text = "RenderOperation : Blend (d = d * (1 - sa) + s) default";
                        break;
                    case RenderOp.BlendRel:
                        label.Text = "RenderOperation : BlendRel (d = d*(1 - sa) + s*da)";
                        break;
                    case RenderOp.Copy:
                        label.Text = "RenderOperation : Copy (d = s)";
                        break;
                    case RenderOp.CopyRel:
                        label.Text = "RenderOperation : CopyRel (d = s*da)";
                        break;
                    case RenderOp.Mask:
                        label.Text = "RenderOperation : Mask (d = d*sa)";
                        break;
                    case RenderOp.Mul:
                        label.Text = "RenderOperation : Mul (d = d*s)";
                        break;
                    case RenderOp.Sub:
                        label.Text = "RenderOperation : Sub (d = d - s)";
                        break;
                    case RenderOp.SubRel:
                        label.Text = "RenderOperation : SubRel (d = d - s*da)";
                        break;
                    case RenderOp.Tint:
                        label.Text = "RenderOperation : Tint (d = d*s + d*(1 - sa) + s*(1 - da))";
                        break;
                    case RenderOp.TintRel:
                        label.Text = "RenderOperation : TintRel (d = d*(1 - sa + s))";
                        break;
                }
                box2.RenderOperation = renderOp;
            };

        }
    }
}
