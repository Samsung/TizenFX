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

namespace TextTest2
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

        private PushButton _button;
        private PushButton button2;
        private TextField _field;
        private TextEditor editor;


        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            _field = new TextField();
            _field.Size2D = new Size2D(500, 300);
            _field.Position2D = new Position2D(530, 550);
            _field.BackgroundColor = Color.Cyan;
            _field.PlaceholderText = "TextField input someth...";
            _field.Focusable = true;
            _field.EnableSelection = true;
            window.Add(_field);

            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Add("placeholderText", new PropertyValue("TextEditor Placeholder Text"));
            propertyMap.Add("placeholderColor", new PropertyValue(Color.Red));
            propertyMap.Add("placeholderPointSize", new PropertyValue(12.0f));

            PropertyMap fontStyleMap = new PropertyMap();
            fontStyleMap.Add("weight", new PropertyValue("bold"));
            fontStyleMap.Add("width", new PropertyValue("condensed"));
            fontStyleMap.Add("slant", new PropertyValue("italic"));
            propertyMap.Add("placeholderFontStyle", new PropertyValue(fontStyleMap));


            editor = new TextEditor();
            editor.Size2D = new Size2D(500, 300);
            editor.Position2D = new Position2D(10, 550);
            editor.BackgroundColor = Color.Magenta;
            editor.Focusable = true;
            editor.Placeholder = propertyMap;

            window.Add(editor);
            editor.TextChanged += (obj, e) => {
                Tizen.Log.Fatal("NUI", "editor line count: " + e.TextEditor.LineCount);
            };

            editor.ScrollStateChanged += (obj, e) => {
                Tizen.Log.Fatal("NUI", "editor scroll state:" + e.ScrollState);
            };

            Tizen.Log.Debug("NUI", "editor id: " + editor.ID);

            ImfManager imfManager = ImfManager.Get();
            // send privatecommand event
            ImfManager.ImfEventData imfevent = new ImfManager.ImfEventData(ImfManager.ImfEvent.PrivateCommand, "", 0, 0);
            imfManager.ImfManagerEventReceived += ImfManager_ImfManagerEventReceived;

            //imfmanager.imfManagerLanguageChanged += ImfManager_LanguageChanged;

            _button = new PushButton();
            _button.LabelText = "Button1";
            _button.Size2D = new Size2D(400, 200);
            _button.Position2D = new Position2D(10, -10);
            _button.ParentOrigin = ParentOrigin.BottomLeft;
            _button.PivotPoint = PivotPoint.BottomLeft;
            _button.PositionUsesPivotPoint = true;
            _button.Focusable = true;
            window.Add(_button);

            button2 = new PushButton();
            button2.LabelText = "Button2";
            button2.Size2D = new Size2D(400, 200);
            button2.ParentOrigin = ParentOrigin.BottomLeft;
            button2.PivotPoint = PivotPoint.BottomLeft;
            button2.Position2D = new Position2D(420, -10);
            button2.PositionUsesPivotPoint = true;
            button2.Focusable = true;
            window.Add(button2);

            _button.UpFocusableView = editor;
            FocusManager.Instance.PreFocusChange += OnPreFocusChange;
        }

        private View OnPreFocusChange(object source, FocusManager.PreFocusChangeEventArgs e)
        {
            if (!e.ProposedView && !e.CurrentView)
            {
                e.ProposedView = _button;
            }
            return e.ProposedView;
        }

        public ImfManager.ImfCallbackData ImfManager_ImfManagerEventReceived(object sender, ImfManager.ImfManagerEventReceivedEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "ImfManager_ImfManagerEventReceived()!");

            Tizen.Log.Fatal("NUI", "e.ImfEventData.PredictiveString= " + e?.ImfEventData?.PredictiveString);
            Tizen.Log.Fatal("NUI", "e.ImfEventData.PredictiveString= " + e?.ImfEventData?.CursorOffset);
            Tizen.Log.Fatal("NUI", "e.ImfEventData.PredictiveString= " + e?.ImfEventData?.EventName);
            Tizen.Log.Fatal("NUI", "e.ImfEventData.PredictiveString= " + e?.ImfEventData?.NumberOfChars);

            //Be able to compare VD specific private command with ImfEventData.predictiveString
            if (e.ImfEventData.PredictiveString == "IME_F31")
            {
                ImfManager.Get().Deactivate();
                ImfManager.Get().HideInputPanel();
                // Do Something the user wants
                Tizen.Log.Fatal("NUI", "ImfManager ImfEventData.PredictiveString: IME_F31!!!");
            }
            ImfManager.ImfCallbackData callbackData = new ImfManager.ImfCallbackData(true, 0, e.ImfEventData.PredictiveString, false);
            Tizen.Log.Fatal("NUI", "ImfManager return callbackData!!!");
            return callbackData;
        }

        //public void ImfManager_LanguageChanged(object sender, EventArgs args)
        //{
        //    Tizen.Log.Fatal("NUI", "ImfManager LanguageChanged!!!");
        //    return;
        //}

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
