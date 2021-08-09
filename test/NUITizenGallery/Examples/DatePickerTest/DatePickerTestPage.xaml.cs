using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NUITizenGallery
{
    public partial class DatePickerTestPage : ContentPage
    {
        private DateTime date;
        private DatePicker datePicker;

        private void dateButtonClicked(object sender, ClickedEventArgs e)
        {
            datePicker = new DatePicker()
            {
                Size = new Size(600, 339),
                Date = date,
            };

            var btn1 = new Button() { Text = "Set", };
            btn1.Clicked += (object s, ClickedEventArgs a) =>
            {
                date = datePicker.Date;
                text1.Text=datePicker.Date.Year + "/" + datePicker.Date.Month + "/" + datePicker.Date.Day;
                Navigator?.Pop();
            };

            var btn2 = new Button() { Text = "Cancel", };
            btn2.Clicked += (object s, ClickedEventArgs a) =>
            {
                Navigator?.Pop();
            };

            View[] actions = {btn1, btn2};
            var dialogPage = new DialogPage()
            {
                Content = new AlertDialog()
                {
                    Title = "Set Date",
                    Content = datePicker,
                    Actions =  actions,
                },
            };

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(dialogPage);
        }

        private void setMinButtonClicked(object sender, ClickedEventArgs e)
        {
            text1.Text="1970/1/1";
            date = new DateTime(1970, 1, 1);
        }

        private void setMaxButtonClicked(object sender, ClickedEventArgs e)
        {
            text1.Text="2100/12/31";
            date = new DateTime(2100, 12, 31);
        }

        public DatePickerTestPage()
        {
            InitializeComponent();
            date = DateTime.Now;
            text1.Text= date.Year + "/" + date.Month + "/" + date.Day;
            dateButton.Clicked += dateButtonClicked;
            setMinButton.Clicked += setMinButtonClicked;
            setMaxButton.Clicked += setMaxButtonClicked;
        }
    }
}
