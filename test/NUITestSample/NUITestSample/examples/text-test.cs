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
        TextLabel _pointLabel;
        Boolean _colorToggle;

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

        private bool LabelTouched(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                Animation textColorAnimation = new Animation(1000);
                if (_colorToggle)
                {
                    textColorAnimation.AnimateTo(_pointLabel, "TextColorAnimatable", Color.Blue );
                    _colorToggle = false;
                }
                else
                {
                     textColorAnimation.AnimateTo(_pointLabel, "TextColorAnimatable", Color.Green );
                    _colorToggle = true;
                }
                textColorAnimation.Play();
            }
            return true;
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

            _pointLabel = new TextLabel("Test Point Size 32.0f");
            _pointLabel.Position2D = new Position2D(10, 100);
            _pointLabel.PointSize = 32.0f;
            _pointLabel.BackgroundColor = Color.Red;
            //_pointLabel.TextColorAnimatable = Color.Green; // Set initial text color using animatable property
            _pointLabel.TouchEvent += LabelTouched;
            _colorToggle = true;

            window.Add(_pointLabel);


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
            field.PlaceholderTextFocused = "input someth... focused";
            field.Focusable = true;
            PropertyMap hiddenMap = new PropertyMap();
            hiddenMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.ShowLastCharacter));
            hiddenMap.Add(HiddenInputProperty.ShowLastCharacterDuration, new PropertyValue(2));
            hiddenMap.Add(HiddenInputProperty.SubstituteCount, new PropertyValue(4));
            hiddenMap.Add(HiddenInputProperty.SubstituteCharacter, new PropertyValue(0x23));
            field.HiddenInputSettings = hiddenMap;
            field.EnableSelection = true;
            field.EnableShiftSelection = false;
            window.Add(field);

            InputMethod inputMethod = new InputMethod();
            inputMethod.PanelLayout = InputMethod.PanelLayoutType.Number;
            inputMethod.ActionButton = InputMethod.ActionButtonTitleType.Go;
            inputMethod.AutoCapital = InputMethod.AutoCapitalType.Word;
            inputMethod.Variation = 1;

            field.InputMethodSettings = inputMethod.OutputMap;

            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Add("placeholderText", new PropertyValue("Placeholder Text"));
            propertyMap.Add("placeholderTextFocused", new PropertyValue("Placeholder Text Focused"));
            propertyMap.Add("placeholderColor", new PropertyValue(Color.Red));
            propertyMap.Add("placeholderPointSize", new PropertyValue(15.0f));

            PropertyMap fontStyleMap = new PropertyMap();
            fontStyleMap.Add("weight", new PropertyValue("bold"));
            fontStyleMap.Add("width", new PropertyValue("condensed"));
            fontStyleMap.Add("slant", new PropertyValue("italic"));
            propertyMap.Add("placeholderFontStyle", new PropertyValue(fontStyleMap));

            TextEditor editor = new TextEditor();
            editor.Size2D = new Size2D(400, 100);
            editor.Position2D = new Position2D(10, 550);
            editor.BackgroundColor = Color.Magenta;
            editor.EnableScrollBar = true;
            editor.EnableSelection = true;
            editor.Focusable = true;
            editor.Placeholder = propertyMap;
            editor.MaxLength = 10;
            window.Add(editor);
            editor.TextChanged += (obj, e) => {
                Tizen.Log.Debug("NUI", "editor line count: " + e.TextEditor.LineCount);
            };

            editor.ScrollStateChanged += (obj, e)=> {
                Tizen.Log.Debug("NUI", "editor scroll state:" + e.ScrollState);
            };
            editor.MaxLengthReached += (obj, e)=> {
                Tizen.Log.Debug("NUI", "editor max length: "+ e.TextEditor.MaxLength);
            };

            Tizen.Log.Debug("NUI",  "editor id: " + editor.ID);

            FocusManager.Instance.SetCurrentFocusView(editor);
            editor.UpFocusableView = field;
            field.DownFocusableView = editor;

            NUILog.Debug($"### field.EnableShiftSelection={field.EnableShiftSelection}, editor.EnableShiftSelection={editor.EnableShiftSelection}");

        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
