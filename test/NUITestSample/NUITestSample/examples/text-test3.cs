/*
* Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Examples
{
    public class TextPropertyTest : NUIApplication
    {
        TextLabel label1;
        TextLabel label2;
        TextField field1;
        TextField field2;
        TextEditor editor1;
        TextEditor editor2;
        Window window;

        protected override void OnCreate()
        {
            base.OnCreate();
            window = Window.Instance;
            window.BackgroundColor = Color.White;
            label1 = new TextLabel()
            {
                Size2D = new Size2D(300, 156),
                Position2D = new Position2D(100, 300),
                BackgroundColor = Color.Green,
                PointSize = 28,
                Focusable = true,
                MultiLine = true,
                HorizontalAlignment = HorizontalAlignment.End,
                MatchSystemLanguageDirection = false,
                Text = "Hello world \nﻡﺮﺤﺑﺍ."
            };

            label2 = new TextLabel()
            {
                Size2D = new Size2D(300, 156),
                Position2D = new Position2D(100, 500),
                BackgroundColor = Color.Green,
                PointSize = 28,
                Focusable = true,
                MultiLine = true,
                HorizontalAlignment = HorizontalAlignment.End,
                MatchSystemLanguageDirection = true,
                Text = "Hello world \nﻡﺮﺤﺑﺍ."
            };
            field1 = new TextField()
            {
                Size2D = new Size2D(300, 156),
                Position2D = new Position2D(500, 300),
                BackgroundColor = Color.Yellow,
                PointSize = 28,
                Focusable = true,
                HorizontalAlignment = HorizontalAlignment.End,
                MatchSystemLanguageDirection = false,
                Text = "ﻡﺮﺤﺑﺍ."
            };

            field2 = new TextField()
            {
                Size2D = new Size2D(300, 156),
                Position2D = new Position2D(500, 500),
                BackgroundColor = Color.Yellow,
                PointSize = 28,
                Focusable = true,

                HorizontalAlignment = HorizontalAlignment.End,
                MatchSystemLanguageDirection = true,
                Text = "ﻡﺮﺤﺑﺍ."
            };
            editor1 = new TextEditor()
            {
                Size2D = new Size2D(300, 156),
                Position2D = new Position2D(900, 300),
                BackgroundColor = Color.Cyan,
                PointSize = 28,
                Focusable = true,
                HorizontalAlignment = HorizontalAlignment.End,
                MatchSystemLanguageDirection = false,
                Text = "Hello world \nﻡﺮﺤﺑﺍ."
            };

            editor2 = new TextEditor()
            {
                Size2D = new Size2D(300, 156),
                Position2D = new Position2D(900, 500),
                BackgroundColor = Color.Cyan,
                PointSize = 28,
                Focusable = true,
                HorizontalAlignment = HorizontalAlignment.End,
                MatchSystemLanguageDirection = true,
                Text = "Hello world \nﻡﺮﺤﺑﺍ."
            };

            window.Add(label1);
            window.Add(label2);
            window.Add(field1);
            window.Add(field2);
            window.Add(editor1);
            window.Add(editor2);
        }
    }
}
