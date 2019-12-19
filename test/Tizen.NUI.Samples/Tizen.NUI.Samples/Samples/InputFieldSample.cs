using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class InputFieldSample : IExample
    {
        private TextLabel guideText;
        private View rootView;
        InputField inputField;
        InputFieldStyle inputFieldAttrs;

        public void Activate()
        {
            Window window = Window.Instance;

            rootView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 0.8f),
                Focusable = true
            };
            window.Add(rootView);
            rootView.TouchEvent += OnRootViewTouchEvent;
            CreateInputField();
            CreateGuideText();
        }

        private void CreateGuideText()
        {
            guideText = new TextLabel();
            guideText.Size2D = new Size2D(1600, 150);
            guideText.Position2D = new Position2D(30, 30);
            guideText.TextColor = Color.Blue;
            guideText.BackgroundColor = Color.White;
            guideText.PointSize = 15;
            guideText.MultiLine = true;
            guideText.Focusable = true;
            rootView.Add(guideText);
            guideText.Text =
                "Tips: \n" +
                "This InputField is created with attibutes; \n" +
                "User can input text after press on it; \n" +
                "User can exit the sample by press \"Esc\" key after touch on any area except the InputField.";
        }

        private void CreateInputField()
        {
            inputFieldAttrs = new InputFieldStyle();
            inputFieldAttrs.Space = 24;
            inputFieldAttrs.BackgroundImageAttributes = new ImageViewStyle
            {
                ResourceUrl = new Selector<string> { All = CommonResource.GetFHResourcePath() + "1. Action bar/search_bg.png" },
                Border = new Selector<Rectangle> { All = new Rectangle(45, 45, 0, 0) }
            };

            inputFieldAttrs.InputBoxAttributes = new TextFieldStyle
            {
                TextColor = new Selector<Color>
                {
                    Normal = new Color(0, 0, 0, 1),
                    Pressed = new Color(0, 0, 0, 1),
                    Disabled = new Color(0, 0, 0, 0.4f)
                },
                PlaceholderTextColor = new Selector<Color>
                {
                    All = new Color(0, 0, 0, 0.4f)
                },
                HorizontalAlignment =  HorizontalAlignment.Begin,
                VerticalAlignment =  VerticalAlignment.Center,
                FontFamily = "SamsungOne 500",
                PointSize = new Selector<float?>
                {
                    All = 38
                },
                CursorWidth = 2,
            };

            inputField = new InputField(inputFieldAttrs);
            inputField.Size2D = new Size2D(1600, 95);
            inputField.Position2D = new Position2D(100, 300);
            //inputField.Focusable = true;
            rootView.Add(inputField);
            inputField.FocusGained += onFocusGained;
            inputField.FocusLost += onFocusLost;
            //inputField.TouchEvent += onTouchEvent;
            inputField.HintText = "Please input key word...";
        }

        private bool OnRootViewTouchEvent(object sender, View.TouchEventArgs e)
        {
            FocusManager.Instance.SetCurrentFocusView(rootView);
            return false;
        }

        private void onFocusLost(object sender, EventArgs e)
        {
            
        }

        private void onFocusGained(object sender, EventArgs e)
        {
            
        }

        //private bool onTouchEvent(object sender, View.TouchEventArgs e)
        //{
        //    return false;
        //}

        public void Deactivate()
        {
            if (inputField != null)
            {
                inputField.FocusGained -= onFocusGained;
                inputField.FocusLost -= onFocusLost;
                //inputField.TouchEvent -= onTouchEvent;
                rootView.Remove(inputField);
                inputField.Dispose();
                inputField = null;
            }
            if (rootView != null)
            {
                rootView.TouchEvent -= OnRootViewTouchEvent;
                Window.Instance.Remove(rootView);
                rootView.Dispose();
            }
        }
    }
}
