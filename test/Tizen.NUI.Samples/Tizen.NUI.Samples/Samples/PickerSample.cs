using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.ObjectModel;

namespace Tizen.NUI.Samples
{
    public class PickerSample : IExample
    {
        private static int pickerWidth = 160;
        private static int pickerHeight = 339;
        private Window window;
        private Picker picker;

        private void onValueChanged(object sender, ValueChangedEventArgs e)
        {
            Console.WriteLine("Value is " + e.Value);
        }

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.White;

            String[] textValue = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten"};

            picker = new Picker()
            {
                Size = new Size(pickerWidth, pickerHeight),
                Position = new Position(Window.Instance.Size.Width / 2 - pickerWidth / 2, Window.Instance.Size.Height/ 2 - pickerHeight / 2),
                MinValue = 1,
                MaxValue = 10,
                CurrentValue = 3,
                DisplayedValues = new ReadOnlyCollection<string>(textValue),
            };
            picker.ValueChanged += onValueChanged;
            window.Add(picker);
        }
        public void Deactivate()
        {
            window.Remove(picker);
            picker.Dispose();
            picker = null;
        }
    }
}
