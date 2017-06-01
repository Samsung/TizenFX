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

namespace ElmSharp.Test
{
    class LabelTest2 : TestCaseBase
    {
        public override string TestName => "LabelTest2";
        public override string TestDescription => "To test basic operation of Label";

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            Label label1 = new Label(window);
            label1.Text = "[default valign=top] gyj <span valign=bottom>[bottom gyp]</span>, <span valign=top>[top gyp]</span>, <span valign=middle>[middle gyp]</span>";
            label1.TextStyle = "DEFAULT = 'color=#000000FF backing_color=#ff0000 backing=on font_size=25 align=left valign=top wrap=word'";
            label1.Resize(650, 0);
            var size = label1.EdjeObject["elm.text"].TextBlockFormattedSize;
            label1.Show();
            label1.Resize(size.Width, size.Height);
            label1.Move(0, 0);

            Label label2 = new Label(window);
            label2.Move(0, size.Height + 10);
            label2.Text = "[default valign=middle] gyj <span valign=bottom>[bottom gyp]</span>, <span valign=top>[top gyp]</span>, <span valign=middle>[middle gyp]</span>";
            label2.TextStyle = "DEFAULT = 'color=#000000FF backing_color=#ff0000 backing=on font_size=25 align=left valign=middle wrap=word'";
            label2.Resize(650, 0);
            size = label2.EdjeObject["elm.text"].TextBlockFormattedSize;
            label2.Show();
            label2.Resize(size.Width, size.Height);

            Label label3 = new Label(window);
            label3.Move(0, label2.Geometry.Y + size.Height + 10);
            label3.Text = "[default valign=bottom] gyj <span valign=bottom>[bottom gyp]</span>, <span valign=top>[top gyp]</span>, <span valign=middle>[middle gyp]</span>";
            label3.TextStyle = "DEFAULT = 'color=#000000FF backing_color=#ff0000 backing=on font_size=25 align=left valign=bottom wrap=word'";
            label3.Resize(650, 0);
            size = label3.EdjeObject["elm.text"].TextBlockFormattedSize;
            label3.Show();
            label3.Resize(size.Width, size.Height);

            Label label4 = new Label(window);
            label4.Move(0, label3.Geometry.Y + size.Height + 10);
            label4.Text = "<span color=#000000>[No TextStyle]</span>" +
                "<span color=#000000 valign=bottom>[bottom gyp]</span>, " +
                "<span color=#000000 valign=top>[top gyp]</span>, " +
                "<span color=#000000 valign=middle>[middle gyp]</span>";
            label4.Resize(650, 0);
            size = label4.EdjeObject["elm.text"].TextBlockFormattedSize;
            label4.Show();
            label4.Resize(size.Width, size.Height);

            Label label5 = new Label(window);
            label5.Move(0, label4.Geometry.Y + size.Height + 10);
            label5.Text = "<span valign=top color=#000000 font_size=50>[top gyp]</span>";
            label5.Resize(650, 0);
            size = label5.EdjeObject["elm.text"].TextBlockFormattedSize;
            label5.Show();
            label5.Resize(size.Width, size.Height);
        }

    }
}
