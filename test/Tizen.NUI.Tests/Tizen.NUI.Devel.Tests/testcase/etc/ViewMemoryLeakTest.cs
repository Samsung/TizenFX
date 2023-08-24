
using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using global::System.Resources;

namespace Tizen.NUI.Devel.Tests
{
    [TestFixture]
    [Description("View memory leak Tests")]
    public class ViewMemoryLeakTests
    {
        private const string TAG = "NUITEST";

        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Destroy()
        {
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("view memory leak test")]
        [Property("SPEC", "local test")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "local test")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "dongsug.song")]
        public void ViewMemoryLeakTest()
        {
            /* TEST CODE */
            test1();
        }

        private View rootView;
        private Timer timer;
        private const uint numberOfTestCount = 1000;
        private const uint numberOfViews = 500;
        private int currentTestCount = 0;

        private TextLabel doGC, add500views, remove500views;
        void test1()
        {
            rootView = new View();
            rootView.Size2D = new Size2D(100, 100);
            rootView.Position2D = new Position2D(70, 70);
            rootView.Focusable = true;
            rootView.BackgroundColor = Color.Red;
            rootView.KeyEvent += RootView_KeyEvent;
            rootView.TouchEvent += RootView_TouchEvent;

            Window.Instance.GetDefaultLayer().Add(rootView);

            FocusManager.Instance.SetCurrentFocusView(rootView);

            CreateViews();

            timer = new Timer(1000);
            timer.Tick += Timer_Tick;

            doGC = new TextLabel()
            {
                Size = new Size(200, 100),
                Position = new Position(500, 500),
                Text = "Do GC!",
                BackgroundColor = Color.White,
            };
            doGC.TouchEvent += DoGC_TouchEvent;
            Window.Instance.GetDefaultLayer().Add(doGC);

            add500views = new TextLabel()
            {
                Size = new Size(200, 100),
                Position = new Position(500, 700),
                Text = "add500views",
                BackgroundColor = Color.White,
            };
            add500views.TouchEvent += add500views_TouchEvent;
            Window.Instance.GetDefaultLayer().Add(add500views);

            remove500views = new TextLabel()
            {
                Size = new Size(200, 100),
                Position = new Position(500, 900),
                Text = "remove500views",
                BackgroundColor = Color.White,
            };
            remove500views.TouchEvent += remove500views_TouchEvent;
            Window.Instance.GetDefaultLayer().Add(remove500views);
        }

        private bool remove500views_TouchEvent(object source, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                Tizen.Log.Debug("NUITEST", "remove500views");
                DestroyViews();
                var me = source as TextLabel;
                me.BackgroundColor = Color.Blue;
            }
            else
            {
                var me = source as TextLabel;
                me.BackgroundColor = Color.White;
            }
            return true;
        }

        private bool add500views_TouchEvent(object source, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                Tizen.Log.Debug("NUITEST", "add500views");
                CreateViews();
                var me = source as TextLabel;
                me.BackgroundColor = Color.Red;
            }
            else
            {
                var me = source as TextLabel;
                me.BackgroundColor = Color.White;
            }
            return true;
        }

        private bool DoGC_TouchEvent(object source, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                Tizen.Log.Debug("NUITEST", "Do GC!");
                GC.Collect();
                GC.WaitForPendingFinalizers();

                var me = source as TextLabel;
                me.BackgroundColor = Color.Red;
            }
            else
            {
                var me = source as TextLabel;
                me.BackgroundColor = Color.White;
            }
            return true;
        }

        bool onceFlag = false;
        private bool RootView_TouchEvent(object source, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                if (onceFlag == false)
                {
                    onceFlag = true;
                    timer.Start();

                    Tizen.Log.Debug("NUITEST", "TEST IS STARTED");
                }
            }
            return true;
        }

        private bool RootView_KeyEvent(object source, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    timer.Start();

                    Tizen.Log.Debug("NUITEST", $"TEST IS STARTED rootView's child cnt={rootView.ChildCount}");
                }
            }

            return false;
        }

        private bool Timer_Tick(object source, Timer.TickEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (currentTestCount == numberOfTestCount)
            {
                Tizen.Log.Debug("NUITEST", $"TEST IS FINISHED. rootView's child cnt={rootView.ChildCount}");
                onceFlag = false;
                currentTestCount = 0;
                return false;
            }

            if (currentTestCount % 2 == 0)
            {
                DestroyViews();
            }
            else
            {
                CreateViews();
            }

            currentTestCount++;

            return true;
        }

        View[] viewArray = new View[numberOfViews];
        bool workingFlag = false;
        private void CreateViews()
        {
            Tizen.Log.Debug("NUITEST", $"CreateViews() start, numberOfViews={numberOfViews}, rootView's child cnt={rootView.ChildCount}");
            if (workingFlag)
            {
                Tizen.Log.Debug("NUITEST", $"@@err CreateViews() working now! just return!");
                return;
            }
            workingFlag = true;

            for (uint i = 0; i < numberOfViews; i++)
            {
                View v = new View()
                {
                    Size = new Size(20, 20),
                    BackgroundColor = Color.Green
                };
                rootView.Add(v);

                //check ref count
                //viewArray[i] = v;
                //RefObject ro = v.GetObjectPtr();
                //RefObject rv = rootView.GetObjectPtr();
                //Tizen.Log.Debug("NUITEST", $"1) child.count={ro.ReferenceCount()}, parent cnt={rv.ReferenceCount()}");
            }
            Tizen.Log.Debug("NUITEST", $"CreateViews() end rootView's child cnt={rootView.ChildCount}\n");
            workingFlag = false;
        }

        private void DestroyViews()
        {
            if (workingFlag)
            {
                Tizen.Log.Debug("NUITEST", $"@@err DestroyViews() working now! just return!");
                return;
            }
            workingFlag = true;

            if (rootView != null)
            {
                if (rootView.ChildCount > 0)
                {
                    Tizen.Log.Debug("NUITEST", $"DestroyViews() start, rootView.ChildCount={rootView.ChildCount}");
                    for (int i = (int)rootView.ChildCount - 1; i >= 0; i--)
                    {
                        View v = rootView.GetChildAt((uint)i);
                        v.Unparent();
                        v.Dispose();
                    }
                    Tizen.Log.Debug("NUITEST", $"DestroyViews() end, rootView.ChildCount={rootView.ChildCount} \n");
                }
                //check ref count
                //for (uint i = 0; i < numberOfViews; i++)
                //{
                //    View v = viewArray[i];
                //    if(v != null)
                //    {
                //        RefObject ro = v.GetObjectPtr();
                //        RefObject rv = rootView.GetObjectPtr();

                //        Tizen.Log.Debug("NUITEST", $"1) child.count={ro.ReferenceCount()}, parent cnt={rv.ReferenceCount()}");

                //        v.Dispose();
                //        viewArray[i] = v = null;
                //    }
                //}
            }
            workingFlag = false;
        }
    }
}
