using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    //Please expand Window size, When it runs on Ubuntu.
    public class TimePickerSample : IExample
    {
        private static int pickerWidth = 580;
        private static int pickerHeight = 339;
        private Window window;
        private TimePicker timePicker;

        private void TimeChanged(object sender, TimeChangedEventArgs e)
        {
            Console.WriteLine(" Time " + e.Hour + " " + e.Minute);
        }

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.White;

            timePicker = new TimePicker()
            {
                Size = new Size(pickerWidth, pickerHeight),
                Position = new Position(Window.Instance.Size.Width / 2 - pickerWidth / 2, Window.Instance.Size.Height/ 2 - pickerHeight / 2),
                Hour = 12,
                Minute = 30,
                Is24HourView = false,
            };
            timePicker.TimeChanged += TimeChanged;
            window.Add(timePicker);
        }
        
        public void Deactivate()
        {
            window.Remove(timePicker);
            timePicker.Dispose();
            timePicker = null;
        }
    }
}
