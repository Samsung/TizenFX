using System;
using System.Collections.Generic;
using ElmSharp;

namespace ElmSharp.Test
{
    class DateTimeSelectorTest1 : TestCaseBase
    {
        public override string TestName => "DateTimeSelectorTest1";
        public override string TestDescription => "To test basic operation of DateTimeSelector";

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            DateTimeSelector dateTime = new DateTimeSelector(window)
            {
                MinimumDateTime = new DateTime(2015,1,1),
                MaximumDateTime = DateTime.Now,
                DateTime = DateTime.Now
            };

            Label label1 = new Label(window);

            Label label2 = new Label(window);

            Label label3 = new Label(window) {
                Text = string.Format("Current DateTime={0}", dateTime.DateTime),
            };

            dateTime.DateTimeChanged += (object sender, DateChangedEventArgs e) =>
            {
                label1.Text = string.Format("Old DateTime={0}", e.OldDate);
                label2.Text = string.Format("New DateTime={0}", e.NewDate);
                label3.Text = string.Format("Current DateTime={0}", dateTime.DateTime);
            };

            dateTime.Resize(600, 600);
            dateTime.Move(0, 300);
            dateTime.Show();

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