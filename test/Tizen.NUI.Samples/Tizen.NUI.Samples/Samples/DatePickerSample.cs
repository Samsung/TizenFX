using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    //Please expand Window size, When it runs on Ubuntu.
    public class DatePickerSample : IExample
    {
        private static int pickerWidth = 600;
        private static int pickerHeight = 339;
        private Window window;
        private DatePicker datePicker;

        private void OnValueChanged(object sender, DateChangedEventArgs e)
        {
            Console.WriteLine(" Date is " + e.Day + " " + e.Month + " " + e.Year);
        }

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.White;

            datePicker = new DatePicker()
            {
                Size = new Size(pickerWidth, pickerHeight),
                Position = new Position(Window.Instance.Size.Width / 2 - pickerWidth / 2, Window.Instance.Size.Height/ 2 - pickerHeight / 2),

                Day = 1,
                Month = 10,
                Year = 2021,
            };
            datePicker.DateChanged += OnValueChanged;
            window.Add(datePicker);
        }
        public void Deactivate()
        {
            window.Remove(datePicker);
            datePicker.Dispose();
            datePicker = null;
        }
    }
}
