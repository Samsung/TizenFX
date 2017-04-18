using Tizen.Applications;

using System.Collections.Generic;
using System;

namespace TizenVDUIApplication19
{
    using Tizen.NUI;

    internal class Program : NUIApplication
    {
        private Timer myTimer;
        private List<View> myViewList;
        private const int numberOfObjects = 500;
        private Random myRandom;

        protected override void OnCreate()
        {
            base.OnCreate();

            Stage.Instance.BackgroundColor = Color.White;

            myViewList = new List<View>();

            myRandom = new Random();

            for (int i = 0; i < numberOfObjects; i++)
            {
                View v = new View();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.AnchorPoint = AnchorPoint.TopLeft;
                v.Size = new Size(100, 100, 0);

                myViewList.Add(v);

                Stage.Instance.GetDefaultLayer().Add(v);
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
                Stage.Instance.GetDefaultLayer().Remove(v);
            }

            myViewList.Clear();

            ////Add View

            GC.Collect();
            GC.WaitForPendingFinalizers();

            for (int i = 0; i < numberOfObjects; i++)
            {
                View v = new View();

                float intensity = myRandom.Next(0, 255) / 255.0f;
                v.BackgroundColor = new Color(intensity, intensity, intensity, 1);
                v.Position = new Position(myRandom.Next(0, 1820), myRandom.Next(0, 980), 0);
                v.AnchorPoint = AnchorPoint.TopLeft;
                v.Size = new Size(100, 100, 0);

                myViewList.Add(v);

                Stage.Instance.GetDefaultLayer().Add(v);
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

        private static void _Main(string[] args)
        {
            //Create an Application
            Program myProgram = new Program();
            myProgram.Run(args);
        }
    }
}