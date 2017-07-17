using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.TC
{
    class ButtonTest1 : WearableTestCase
    {
        public override string TestName => "ButtonTest1";
        public override string TestDescription => "To test basic operation of Button";

        void SetButtonEventHandler(Button button)
        {
            button.Clicked += (s, e) =>
            {
                Log.Debug($"{button.Text} Clicked! : {button.BackgroundColor}");
                Log.Debug($"{button.Text} Clicked! : {button.ClassName}");
                Log.Debug($"{button.Text} Clicked! : {button.ClassName.ToLower()}");
                Log.Debug($"{button.Text} Clicked! : {button.ClassName.ToLower().Replace("elm_", "")}");
                Log.Debug($"{button.Text} Clicked! : {button.ClassName.ToLower().Replace("elm_", "") + "/" + "bg"}");
            };

            button.Pressed += (s, e) =>
            {
                Log.Debug("{button.Text} Pressed!");
            };

            button.Released += (s, e) =>
            {
                Log.Debug("{button.Text} Released!");
            };

            button.Repeated += (s, e) =>
            {
                Log.Debug("{button.Text} Repeated!");
            };

            button.Show();
        }

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();
            Log.Debug(square.ToString());

            Button button1 = new Button(window)
            {
                Text = "Button 1",
            };
            button1.SetPartColor("bg", Color.Red);
            SetButtonEventHandler(button1);
            button1.Resize(square.Width, square.Height/4);
            button1.Move(square.X, square.Y);

            Button button2 = new Button(window)
            {
                Text = "Button 2",
                BackgroundColor = Color.Red,
            };
            SetButtonEventHandler(button2);
            button2.Resize(square.Width, square.Height / 4);
            button2.Move(square.X, square.Y + square.Height / 4);

            Button button3 = new Button(window)
            {
                Text = "Button 3",
                BackgroundColor = new Color(125, 200, 255, 150)
            };
            SetButtonEventHandler(button3);
            button3.Resize(square.Width, square.Height / 4);
            button3.Move(square.X, square.Y + square.Height / 2);

            Button button4 = new Button(window)
            {
                Text = "Button 4",
                BackgroundColor = new Color(125, 200, 255, 10)
            };
            SetButtonEventHandler(button4);
            button4.Resize(square.Width, square.Height / 4);
            button4.Move(square.X, square.Y + square.Height * 3 / 4);
        }
    }
}
