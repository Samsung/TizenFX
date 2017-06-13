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
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;

namespace TextTest
{
    class Example : NUIApplication
    {
        public Example() : base()
        {
        }

        public Example(string stylesheet) : base(stylesheet)
        {
        }

        public Example(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TextLabel pixelLabel = new TextLabel("Test Pixel Size 32.0f");
            pixelLabel.Position2D = new Position2D(10, 10);
            pixelLabel.PixelSize = 32.0f;
            pixelLabel.BackgroundColor = Color.Magenta;
            window.Add(pixelLabel);

            TextLabel pointLabel = new TextLabel("Test Point Size 32.0f");
            pointLabel.Position2D = new Position2D(10, 100);
            pointLabel.PointSize = 32.0f;
            pointLabel.BackgroundColor = Color.Red;
            window.Add(pointLabel);

            TextLabel ellipsis = new TextLabel("Ellipsis of TextLabel is enabled.");
            ellipsis.Size2D = new Size2D(100, 80);
            ellipsis.Position2D = new Position2D(10, 200);
            ellipsis.PointSize = 20.0f;
            ellipsis.Ellipsis = true;
            ellipsis.BackgroundColor = Color.Cyan;
            window.Add(ellipsis);

            TextLabel autoScrollStopMode = new TextLabel("AutoScrollStopMode is finish-loop.");
            autoScrollStopMode.Size2D = new Size2D(400, 50);
            autoScrollStopMode.Position2D = new Position2D(10, 300);
            autoScrollStopMode.PointSize = 15.0f;
            autoScrollStopMode.BackgroundColor = Color.Green;
            autoScrollStopMode.AutoScrollStopMode = AutoScrollStopMode.FinishLoop;
            autoScrollStopMode.EnableAutoScroll = true;
            window.Add(autoScrollStopMode);

            TextField field = new TextField();
            field.Size2D = new Size2D(400, 100);
            field.Position2D = new Position2D(10, 400);
            field.BackgroundColor = Color.Cyan;
            field.PlaceholderText = "input someth...";
            PropertyMap hiddenMap = new PropertyMap();
            hiddenMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.ShowLastCharacter));
            hiddenMap.Add(HiddenInputProperty.ShowDuration, new PropertyValue(2));
            hiddenMap.Add(HiddenInputProperty.SubstituteCount, new PropertyValue(4));
            hiddenMap.Add(HiddenInputProperty.SubstituteCharacter, new PropertyValue(0x23));
            field.HiddenInputSettings = hiddenMap;
            window.Add(field);

            InputMethod inputMethod = new InputMethod();
            inputMethod.PanelLayout = InputMethod.PanelLayoutType.Number;
            inputMethod.ActionButton = InputMethod.ActionButtonTitleType.Go;
            inputMethod.AutoCapital = InputMethod.AutoCapitalType.Word;
            inputMethod.Variation = 1;

            field.InputMethodSettings = inputMethod.OutputMap;

            TextEditor editor = new TextEditor();
            editor.Size2D = new Size2D(400, 100);
            editor.Position2D = new Position2D(10, 550);
            editor.BackgroundColor = Color.Magenta;
            editor.PlaceholderText = "input someth...";
            editor.PlaceholderTextColor = Color.Red;
            editor.EnableScrollBar = true;
            editor.Focusable = true;
            FocusManager.Instance.SetCurrentFocusView(editor);
            window.Add(editor);
            editor.TextChanged += (obj, e) => {
                Tizen.Log.Debug("NUI", "editor line count: " + e.TextEditor.LineCount);
            };

            editor.ScrollStateChanged += (obj, e)=> {
                Tizen.Log.Debug("NUI", "editor scroll state:" + e.ScrollState);
            };

            Tizen.Log.Debug("NUI",  "editor id: " + editor.ID);
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
