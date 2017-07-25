
using System.Collections.Generic;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace TizenVDUIApplication19
{
    using Tizen.NUI;

    internal class Program : NUIApplication
    {
        private Timer myTimer;
        private List<View> myViewList;
        private const int numberOfObjects = 500;
        private Random myRandom;
        private const string resources = "/home/owner/apps_rw/NUISamples.TizenTV/res";

        protected override void OnCreate()
        {
            base.OnCreate();

            Window.Instance.BackgroundColor = Color.White;

            myViewList = new List<View>();

            myRandom = new Random();

            for (int i = 0; i < numberOfObjects; i++)
            {
                View v = new View();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            myTimer = new Timer(1000);

            myTimer.Tick += MyTimer_Tick;

            myTimer.Start();
        }

        private bool MyTimer_Tick(object source, System.EventArgs e)
        {
            //Remove current Scene,
            foreach (View v in myViewList)
            {
                Window.Instance.GetDefaultLayer().Remove(v);
            }

            myViewList.Clear();

            ////Add View

            GC.Collect();
            GC.WaitForPendingFinalizers();

            for (int i = 0; i < 50; i++)
            {
                TextLabel v = new TextLabel();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.Text = "label " + i;

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 50; i < 100; i++)
            {
                PushButton v = new PushButton();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.LabelText = "button " + i;

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 100; i < 150; i++)
            {
                ImageView v = new ImageView();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.ResourceUrl = resources + "/images/gallery-3.jpg";

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 150; i < 200; i++)
            {
                TextEditor v = new TextEditor();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.Text = "editor" + i;

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 200; i < 250; i++)
            {
                TextField v = new TextField();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.Text = "field " + i;

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 250; i < 300; i++)
            {
                CheckBoxButton v = new CheckBoxButton();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);
                v.LabelText = "check " + i;

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 300; i < 350; i++)
            {
                ScrollBar v = new ScrollBar();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 350; i < 400; i++)
            {
                Slider v = new Slider();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 400; i < 450; i++)
            {
                TableView v = new TableView(1, 1);

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            for (int i = 450; i < numberOfObjects; i++)
            {
                View v = new View();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.PivotPoint = PivotPoint.TopLeft;
                v.Size2D = new Size2D(100, 100);

                myViewList.Add(v);

                Window.Instance.GetDefaultLayer().Add(v);
            }

            return true;
        }

        protected override void OnPause()
        {
            //This function is called when the window's visibility is changed from visible to invisible.
            base.OnPause();
        }

        protected override void OnResume()
        {
            //This function is called when the window's visibility is changed from invisible to visible.
            base.OnResume();
        }

        protected override void OnTerminate()
        {
            //This function is called when the app exit normally.
            base.OnTerminate();
        }
        /*
        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            //This function is called when the system is low on memory.
            base.OnLowMemory(e);
        }
        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            //This function is called when the language is changed.
            base.OnLocaleChanged(e);
        }
        */
        private static void _Main(string[] args)
        {
            //Create an Application
            Program myProgram = new Program();
            myProgram.Run(args);
        }
    }
}