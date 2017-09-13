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
    public class EvasImageTest1 : TestCaseBase
    {
        public override string TestName => "EvasImageTest1";
        public override string TestDescription => "To test EvasImage proxy feature";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            Box horizentalBox = new Box(window)
            {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            horizentalBox.Show();

            Button realObject1 = new Button(window) {
                Text = "It is RealObject",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            realObject1.Show();

            Image realObject2 = new Image(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            realObject2.Load(Path.Combine(TestRunner.ResourceDir, "picture.png"));
            realObject2.Show();

            horizentalBox.PackEnd(realObject1);
            horizentalBox.PackEnd(realObject2);

            EvasImage proxyObject = new EvasImage(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 0.5,
            };
            Button toggle = new Button(window)
            {
                Text = "Change Source",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 0.1,
            };
            toggle.Show();

            EvasObject proxyedObject = realObject1;
            toggle.Clicked += (s, e) =>
            {
                if (proxyedObject == realObject1)
                {
                    proxyedObject = realObject2;
                }
                else
                {
                    proxyedObject = realObject1;
                }
                proxyObject.SetSource(proxyedObject);
            };


            proxyObject.IsFilled = true;
            proxyObject.SetSource(realObject1);
            proxyObject.Show();

            box.PackEnd(horizentalBox);
            box.PackEnd(proxyObject);
            box.PackEnd(toggle);
        }
    }
}
