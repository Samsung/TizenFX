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

        private PushButton button;
        private TextEditor editor;
        private ImfManager imfManager;


        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Add("placeholderText", new PropertyValue("TextEditor Placeholder Text"));
            propertyMap.Add("placeholderColor", new PropertyValue(Color.Red));
            propertyMap.Add("placeholderPointSize", new PropertyValue(12.0f));

            PropertyMap fontStyleMap = new PropertyMap();
            fontStyleMap.Add("weight", new PropertyValue("bold"));
            fontStyleMap.Add("width", new PropertyValue("condensed"));
            fontStyleMap.Add("slant", new PropertyValue("italic"));
            propertyMap.Add("placeholderFontStyle", new PropertyValue(fontStyleMap));


            editor = new TextEditor()
            {
                Size2D = new Size2D(500, 300),
                Position2D = new Position2D(10, 550),
                BackgroundColor = Color.Magenta,
                Focusable = true,
                Placeholder = propertyMap
            };

            window.Add(editor);

            editor.TextChanged += (obj, e) => {
                Tizen.Log.Fatal("NUI", "editor line count: " + e.TextEditor.LineCount);
            };

            editor.ScrollStateChanged += (obj, e) => {
                Tizen.Log.Fatal("NUI", "editor scroll state:" + e.ScrollState);
            };

            editor.KeyEvent += OnKeyEvent;


            Tizen.Log.Debug("NUI", "editor id: " + editor.ID);

            imfManager = ImfManager.Get();
            imfManager.AutoEnableInputPanel(false);
            imfManager.SetInputPanelUserData("layouttype = 1 & entrylimit = 255 & action = clearall_for_voice_commit & caller = org.volt.search - all");


            // send privatecommand event
            ImfManager.ImfEventData imfevent = new ImfManager.ImfEventData(ImfManager.ImfEvent.PrivateCommand, "", 0, 0);
            imfManager.EventReceived += ImfManager_ImfManagerEventReceived;

            imfManager.LanguageChanged += ImfManager_LanguageChanged;

            imfManager.Activated += (obj, e) => {
                Tizen.Log.Debug("NUI", "ImfManager Activated !!!!!");
            };
            imfManager.StatusChanged += (obj, e) => {
                Tizen.Log.Debug("NUI", "ImfManager StatusChanged: !!!!!" + e.StatusChanged);
            };
            imfManager.Resized += (obj, e) =>
            {
                Tizen.Log.Debug("NUI", "ImfManager Resized !!!!!");
            };
            imfManager.KeyboardTypeChanged += (obj, e) => {
                Tizen.Log.Debug("NUI", "ImfManager KeyboardTypeChanged: !!!!!" + e.KeyboardType);
            };

            button = new PushButton()
            {
                LabelText = "Button",
                Size2D = new Size2D(400, 200),
                Position2D = new Position2D(10, -10),
                ParentOrigin = ParentOrigin.BottomLeft,
                PivotPoint = PivotPoint.BottomLeft,
                PositionUsesPivotPoint = true,
                Focusable = true
            };

            window.Add(button);

            button.UpFocusableView = editor;
            editor.DownFocusableView = button;

            FocusManager.Instance.SetCurrentFocusView(button);
        }

        private bool OnKeyEvent(object source, View.KeyEventArgs e)
        {
            Tizen.Log.Debug("NUI", "KeyEvent called !!!!!");
            if (e.Key.State != Key.StateType.Down || editor.Focusable == false)
            {
                Tizen.Log.Debug("NUI", "KeyEvent ignored !!!!!");
                return false;
            }
            switch (e.Key.KeyPressedName)
            {
                case "Return":
                    Tizen.Log.Debug("NUI", "KeyPressedName: Return !!!!!");
                    ShowImf();
                    return true;
                case "Select":
                    Tizen.Log.Debug("NUI", "KeyPressedName: Select !!!!!");
                    HideImf();
                    return true;
                case "Cancel":
                    Tizen.Log.Debug("NUI", "KeyPressedName: Cancel !!!!!");
                    HideImf();
                    return true;
                case "Down":
                    Tizen.Log.Debug("NUI", "KeyPressedName: Down !!!!!");
                    HideImf();
                    return MoveFocusTo(button);
            }
            return false;
        }

        private void ShowImf()
        {
            imfManager.Activate();
            imfManager.ShowInputPanel();
            Tizen.Log.Debug("NUI", "IME showed !!!!!");
        }

        private bool MoveFocusTo(View view)
        {
            if (view == null) return false;
            return FocusManager.Instance.SetCurrentFocusView(view);
        }

        private void HideImf()
        {
            imfManager.Deactivate();
            imfManager.HideInputPanel();
            Tizen.Log.Debug("NUI", "IME hided !!!!!");
        }

        public ImfManager.ImfCallbackData ImfManager_ImfManagerEventReceived(object sender, ImfManager.EventReceivedEventArgs e)
        {
            Tizen.Log.Debug("NUI", "ImfManager_ImfManagerEventReceived()!");

            Tizen.Log.Debug("NUI", "e.ImfEventData.PredictiveString= " + e?.ImfEventData?.PredictiveString);
            Tizen.Log.Debug("NUI", "e.ImfEventData.CursorOffset= " + e?.ImfEventData?.CursorOffset);
            Tizen.Log.Debug("NUI", "e.ImfEventData.EventName= " + e?.ImfEventData?.EventName);
            Tizen.Log.Debug("NUI", "e.ImfEventData.NumberOfChars= " + e?.ImfEventData?.NumberOfChars);

            ImfManager.ImfCallbackData callbackData = new ImfManager.ImfCallbackData(true, 0, e.ImfEventData.PredictiveString, false);
            Tizen.Log.Debug("NUI", "ImfManager return callbackData!!!");
            return callbackData;
        }

        public void ImfManager_LanguageChanged(object sender, EventArgs args)
        {
            Tizen.Log.Debug("NUI", "ImfManager LanguageChanged!!!");
            return;
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
