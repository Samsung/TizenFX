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
    class ProgressBarTest2 : WearableTestCase
    {
        public override string TestName => "ProgressBarTest2";
        public override string TestDescription => "To test basic operation of ProgressBar";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Scroller scroller = new Scroller(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                ScrollBlock = ScrollBlock.None,
            };
            scroller.Show();
            conformant.SetContent(scroller);

            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            box.Show();
            scroller.SetContent(box);

            ProgressBar pb1 = new ProgressBar(window)
            {
                Text = "ProgressBar Test",
                Style = "process",
                Value = 0.1,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            pb1.PlayPulse();
            pb1.Show();

            ProgressBar pb2 = new ProgressBar(window)
            {
                Text = "ProgressBar Test",
                Style = "process/small",
                Value = 0.1,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            pb2.PlayPulse();
            pb2.Show();

            box.PackEnd(pb1);
            box.PackEnd(pb2);
        }
    }
}