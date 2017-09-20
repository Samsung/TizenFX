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

namespace ElmSharp.Test
{
    public class EvasImageTest2 : TestCaseBase
    {
        public override string TestName => "EvasImageTest2";
        public override string TestDescription => "To test EvasImage";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            Image realObject2 = new Image(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            realObject2.Load(Path.Combine(TestRunner.ResourceDir, "picture.png"));
            realObject2.Show();

            EvasImage img1 = new EvasImage(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            img1.IsFilled = true;
            img1.File = Path.Combine(TestRunner.ResourceDir, "picture.png");
            img1.Show();

            EvasImage img2 = new EvasImage(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            img2.IsFilled = true;
            img2.SetStream(new FileStream(Path.Combine(TestRunner.ResourceDir, "picture.png"), FileMode.Open, FileAccess.Read));
            img2.Show();

            EvasImage img3 = new EvasImage(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            img3.IsFilled = true;
            img3.SetSource(realObject2);
            img3.Show();
            img3.IsSourceVisible = true;

            box.PackEnd(realObject2);
            box.PackEnd(img1);
            box.PackEnd(img2);
            box.PackEnd(img3);
        }
    }
}
