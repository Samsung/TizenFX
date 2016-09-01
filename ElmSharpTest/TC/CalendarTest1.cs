using System;
using System.Collections.Generic;
using ElmSharp;

namespace ElmSharp.Test
{
    class CalendarTest1 : TestCaseBase
    {
        public override string TestName => "CalendarTest1";
        public override string TestDescription => "To test basic operation of Calendar";

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            Calendar calendar = new Calendar(window)
            {
                FirstDayOfWeek = DayOfWeek.Monday,
                WeekDayNames = new List<string>() { "S", "M", "T", "W", "T", "F", "S" }
            };

            Label label1 = new Label(window) {
                Text = string.Format("WeekDayLabel.Count={0}", calendar.WeekDayNames.Count),
            };

            Label label2 = new Label(window) {
                Text = string.Format("WeekDayLabel.FirstDayOfWeek={0}", calendar.FirstDayOfWeek),
            };

            Label label3 = new Label(window) {
                Text = string.Format("WeekDayLabel.SelectedDate={0}", calendar.SelectedDate),
            };

            calendar.DateChanged += (object sender, DateChangedEventArgs e) =>
            {
                label1.Text = string.Format("Old.Day={0}, Month={1}, Year={2}", e.OldDate.Day, e.OldDate.Month, e.OldDate.Year);
                label2.Text = string.Format("New.Day={0}, Month={1}, Year={2}", e.NewDate.Day, e.NewDate.Month, e.NewDate.Year);
            };

            calendar.DisplayedMonthChanged += (object sender, DisplayedMonthChangedEventArgs e) =>
            {
                label3.Text = string.Format("Old Month={0}, New Month={1}", e.OldMonth, e.NewMonth);
            };

            calendar.Resize(600, 600);
            calendar.Move(0, 300);
            calendar.Show();

            label1.Resize(600, 100);
            label1.Move(0, 0);
            label1.Show();

            label2.Resize(600, 100);
            label2.Move(0, 100);
            label2.Show();

            label3.Resize(600, 100);
            label3.Move(0, 200);
            label3.Show();
        }

    }
}