using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TestFramework
{
    public class TestMainPage : ContentPage
    {
        TestManager manager;
        Button runbutton;
        Button rerunbutton;
        Label label;

	public void initialize(){
	    manager = new TestManager();
            manager.TestExecutionDone += MyTestRunner_TestCaseDone;
	}

	public TestMainPage()
        {
	    initialize();
            Title = "C# Test Application";

            runbutton = new Button
            {
                Text = "Run",
                FontSize = 20,
                Image = "cat.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            runbutton.Clicked += OnRunButtonClicked;

            rerunbutton = new Button
            {
                Text = "Rerun",
                FontSize = 20,
                Image = "cat.png",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            rerunbutton.Clicked += OnRerunButtonClicked;
            rerunbutton.IsEnabled = false;

            label = new Label
            {
                Text = "Test Pending",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout
            {
                Children= {
                    runbutton,
                    rerunbutton,
                    label
                }            
            };

            Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);
        }

        void OnRunButtonClicked(object sender, EventArgs e)
        {
            runbutton.IsEnabled = false;
            label.Text = "Result Pending";
            manager.RunTestFromTCList();
        }

        void OnRerunButtonClicked(object sender, EventArgs e)
        {
            manager.RerunTestFromTCList();
        }

        void MyTestRunner_TestCaseDone(object sender, TestExecutionDoneEventArgs e)
        {
            label.Text = "TOTAL : " + e.Total + ", " + "PASS : " + e.Pass + ", " + "FAIL : " + e.Fail + Environment.NewLine;
            rerunbutton.IsEnabled = true;
        }
    }
}
