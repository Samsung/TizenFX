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
using ElmSharp;
using System.Collections.Generic;

namespace ElmSharp.Test
{
    public class LabelTest3 : TestCaseBase
    {
        public override string TestName => "LabelTest3";
        public override string TestDescription => "To test basic operation of Label";

        public override void Run(Window window)
        {
            Background bg = new Background(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.White
            };
            bg.Show();
            window.AddResizeObject(bg);

            Conformant conformant = new Conformant(window);
            conformant.Show();
            Scroller scroller = new Scroller(window);
            scroller.Show();
            conformant.SetContent(scroller);
            Box box = new Box(window);
            box.SetLayoutCallback(() => { });
            box.Show();
            scroller.SetContent(box);

            Size size;

            Label label1 = new Label(window);
            box.PackEnd(label1);
            Label label2 = new Label(window);
            box.PackEnd(label2);


            label1.Text = "Jo Ann Buckner";
            label1.TextStyle = "DEFAULT='color=#000000FF font_size=24 align=left valign=bottom wrap=word'";
            label1.Show();
            label1.Resize(100000, 0);
            size = label1.EdjeObject["elm.text"].TextBlockFormattedSize;
            label1.Geometry = new Rect(55, 213, size.Width, size.Height);

            label2.Text = "Customer Success Engineer";
            label2.TextStyle = "DEFAULT='color=#000000FF font_size=16 align=left valign=bottom wrap=word'";
            label2.Show();

            label2.Resize(100000, 0);
            size = label2.EdjeObject["elm.text"].TextBlockFormattedSize;
            label2.Geometry = new Rect(55, 300, size.Width, size.Height);


        }
    }
}
