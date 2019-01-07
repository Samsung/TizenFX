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

namespace ElmSharp.Test.Wearable
{
    public class ScreenInformationTest : WearableTestCase
    {
        public override string TestName => "ScreenInformationTest";
        public override string TestDescription => "To get screen information";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            box.Show();
            conformant.SetContent(box);
            Label label = new Label(window);
            label.SetAlignment(-1, 0);
            label.SetWeight(1, 0);
            label.Text = string.Format("<span color=#FFFFFF , font_size=30>ScreenSize : {0}x{1}", window.ScreenSize.Width, window.ScreenSize.Height);
            label.Show();
            box.PackEnd(label);
            Label label2 = new Label(window);
            label2.SetAlignment(-1, 0);
            label2.SetWeight(1, 0);
            label2.Text = string.Format("<span color=#FFFFFF , font_size=30>ScreenDPI : xdpi : {0} ydpi : {1}", window.ScreenDpi.X, window.ScreenDpi.Y);
            label2.Show();
            box.PackEnd(label2);
        }
    }
}
