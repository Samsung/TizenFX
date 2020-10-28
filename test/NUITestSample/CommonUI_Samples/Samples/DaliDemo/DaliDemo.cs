using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NuiCommonUiSamples
{
    public class DaliDemo : Tizen.FH.NUI.FHNUIApplication
    {
        public DaliDemo() : base()
        {
        }

        public DaliDemo(string styleSheet) : base(styleSheet)
        {
        }

        private IExample curExample = null;

        private void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }

        private void DeleteDaliDemo()
        {
            Window.Instance.Remove(demo.mRootActor);
            demo.mRootActor.Dispose();
            demo = null;

            FullGC();
        }

        private void CreateDaliDemo()
        {
            demo = new DaliTableView((string name) =>
            {
                RunSample(name);
            });

            Assembly assembly = this.GetType().Assembly;

            Type exampleType = assembly.GetType("NuiCommonUiSamples.IExample");

            foreach (Type type in assembly.GetTypes())
            {
                if (exampleType.IsAssignableFrom(type) && type.Name != "SampleMain" && this.GetType() != type && true == type.IsClass)
                {
                    demo.AddExample(new Example(type.FullName, type.Name));
                }
            }
            demo.SortAlphabetically(true);

            demo.Initialize();

            Window.Instance.GetDefaultLayer().Add(demo.mRootActor);
        }

        private void OnBackNaviTouchEvent(object source, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                if (null != curExample)
                {
                    ExitSample();
                }
                else
                {
                    if (backNavigation != null)
                    {
                        Window.Instance.GetDefaultLayer().Remove(backNavigation);
                        backNavigation.Dispose();
                        backNavigation = null;
                    }

                    Exit();
                }
            }

            return;
        }

        private void RunSample(string name)
        {
            Assembly assembly = typeof(DaliDemo).Assembly;

            Type exampleType = assembly?.GetType(name);
            IExample example = assembly?.CreateInstance(name) as IExample;

            curPageIndex = demo.GetCurrentPageIndex();

            if (null != example)
            {
                DeleteDaliDemo();

                example.Activate();
            }

            curExample = example;

            backNavigation.Show();
            backNavigation.RaiseToTop();
        }

        private int curPageIndex = -1;

        private void ExitSample()
        {
            curExample?.Deactivate();
            curExample = null;

            FullGC();

            CreateDaliDemo();

            backNavigation.Hide();

            if (0 <= curPageIndex)
            {
                demo.ScrollTo((uint)curPageIndex);
            }
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            CreateDaliDemo();

            backNavigation = new Tizen.FH.NUI.Controls.Navigation("Back");
            backNavigation.PositionUsesPivotPoint = true;
            backNavigation.PivotPoint = PivotPoint.BottomLeft;
            backNavigation.ParentOrigin = ParentOrigin.BottomLeft;
            backNavigation.ItemTouchEvent += OnBackNaviTouchEvent;
            backNavigation.Hide();

            Tizen.FH.NUI.Controls.Navigation.NavigationItemData backItem = new Tizen.FH.NUI.Controls.Navigation.NavigationItemData("WhiteBackItem");
            backNavigation.AddItem(backItem);

            Window.Instance.GetDefaultLayer().Add(backNavigation);

            Window.Instance.KeyEvent += Instance_KeyEvent;

            int id = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            timerForExit.Tick += TimerForExit_Tick;
        }

        private bool TimerForExit_Tick(object source, Timer.TickEventArgs e)
        {
            int id = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
            backNavigation?.Dispose();
            backNavigation = null;

            DeleteDaliDemo();
            Exit();

            timerForExit.Dispose();
            return true;
        }

        private void Instance_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "BackSpace")
                {
                    if (null != curExample)
                    {
                        ExitSample();
                    }
                    else
                    {
                        timerForExit.Start();
                    }
                }
                else if (e.Key.KeyPressedName == "1")
                {
                    FullGC();
                }
            }
        }

        public void Deactivate()
        {
            demo = null;
        }

        private Tizen.NUI.Timer timerForExit = new Tizen.NUI.Timer(10);
        private DaliTableView demo;
        private Tizen.FH.NUI.Controls.Navigation backNavigation;
    }
}
