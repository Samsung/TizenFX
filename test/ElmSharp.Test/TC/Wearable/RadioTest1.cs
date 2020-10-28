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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp.Test.Wearable
{
    class RadioTest1 : WearableTestCase
    {
        public override string TestName => "RadioTest1";
        public override string TestDescription => "To test basic operation of Radio";

        Label _lb1;

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            Radio rd1 = new Radio(window)
            {
                StateValue = 1,
                Text = "<span color=#ffffff>Value #1</span>",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };
            Radio rd2 = new Radio(window)
            {
                StateValue = 2,
                Text = "<span color=#ffffff>Value #2</span>",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };
            Radio rd3 = new Radio(window)
            {
                StateValue = 3,
                Text = "<span color=#ffffff>Value #3</span>",
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };
            rd2.SetGroup(rd1);
            rd3.SetGroup(rd2);

            rd1.ValueChanged += OnRadioValueChanged;
            rd2.ValueChanged += OnRadioValueChanged;
            rd3.ValueChanged += OnRadioValueChanged;

            _lb1 = new Label(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1
            };

            box.PackEnd(_lb1);
            box.PackEnd(rd1);
            box.PackEnd(rd2);
            box.PackEnd(rd3);

            _lb1.Show();
            rd1.Show();
            rd2.Show();
            rd3.Show();
        }

        void OnRadioValueChanged(object sender, EventArgs e)
        {
            _lb1.Text = string.Format("Value Changed: {0}", ((Radio)sender).GroupValue);
            _lb1.EdjeObject["elm.text"].TextStyle = "DEFAULT='color=#ffffff'";
        }
    }
}
