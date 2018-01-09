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
using ElmSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElmSharp.Test
{
    public class ImageTest5 : TestCaseBase
    {
        public override string TestName => "ImageTest5";
        public override string TestDescription => "TC of IsOpaque";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            var image = new Image(window)
            {
                IsFixedAspect = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            image.Show();

            Button kill = new Button(window)
            {
                Text = "Kill",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            kill.Show();

            kill.Clicked += async (s, e) =>
            {
                await image.LoadAsync(Path.Combine(TestRunner.ResourceDir, "img_1_a.png"));
                await Task.Delay(10);
                await image.LoadAsync(Path.Combine(TestRunner.ResourceDir, "img_2_a.png"));
                image.IsOpaque = false;
            };

            box.PackEnd(image);
            box.PackEnd(kill);
        }
    }
}
