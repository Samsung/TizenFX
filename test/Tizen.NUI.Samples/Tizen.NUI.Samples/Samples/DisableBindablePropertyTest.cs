
using global::System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;
    public class DisableBindablePropertyTest : IExample
    {
        private const int NUMBER_OF_VIEW = 300;
        private const int MIN_SIZE = 100;
        private const int MAX_SIZE = 200;
        private const int MIN_POSITION = 10;
        private const int MAX_POSITION = 1000;
        private const int MAX_TEST_REPEAT = 200;
        private const int TIMER_TICK_MS = 5;

        private Window win;
        private View rootView;
        private Random rand = new Random();
        private Timer timer;
        int repeat = 0;

        public void Activate()
        {
            //test speed
            PropertySetGetTest();

            //test memory
            //ViewDisposeTest();
        }

        private void ViewDisposeTest()
        {
            win = NUIApplication.GetDefaultWindow();

            rootView = new View()
            {
                Size = new Size(100, 100),
                BackgroundColor = Color.Blue,
            };
            win.Add(rootView);

            repeat = 0;
            timer = new Timer(TIMER_TICK_MS);
            timer.Tick += OnViewDispose;
            timer.Start();
            tlog.Fatal("NT", $"view create/dipose timer start! should be {TIMER_TICK_MS * MAX_TEST_REPEAT}ms");
        }

        private bool OnViewDispose(object source, Timer.TickEventArgs e)
        {
            repeat++;
            if (repeat % 2 == 0)
            {
                //create child
                //tlog.Fatal("NT", $"create views");
                for (int i = 0; i < NUMBER_OF_VIEW; i++)
                {
                    var child = new View()
                    {
                        Size2D = new Size2D(rand.Next(MIN_SIZE, MAX_SIZE), rand.Next(MIN_SIZE, MAX_SIZE)),
                        Position2D = new Position2D(rand.Next(MIN_POSITION, MAX_POSITION), rand.Next(MIN_POSITION, MAX_POSITION)),
                        BackgroundColor = new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), 1),
                    };
                    rootView.Add(child);
                }
            }
            else
            {
                //dispose child
                //tlog.Fatal("NT", $"dispose views");
                int childCnt = (int)rootView.ChildCount;

                for (int i = childCnt - 1; i >= 0; i--)
                {
                    var child = rootView.GetChildAt((uint)i);
                    rootView.Remove(child);
                    child.Dispose();
                }
            }

            if (repeat > MAX_TEST_REPEAT)
            {
                tlog.Fatal("NT", $"view create/dipose timer end!");
                return false;
            }
            return true;
        }


        public void Deactivate()
        {
            DisposeChildOfRootView();
            timer.Stop();
            timer.Dispose();
            rootView.Unparent();
            rootView.Dispose();
        }

        private void PropertySetGetTest()
        {
            win = NUIApplication.GetDefaultWindow();

            rootView = new View()
            {
                Size = new Size(100, 100),
                BackgroundColor = Color.Blue,
            };
            win.Add(rootView);

            for (int i = 0; i < NUMBER_OF_VIEW; i++)
            {
                var child = new View()
                {
                    Size2D = new Size2D(rand.Next(MIN_SIZE, MAX_SIZE), rand.Next(MIN_SIZE, MAX_SIZE)),
                    Position2D = new Position2D(rand.Next(MIN_POSITION, MAX_POSITION), rand.Next(MIN_POSITION, MAX_POSITION)),
                    BackgroundColor = new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), 1),
                };
                rootView.Add(child);
            }
            repeat = 0;
            timer = new Timer(TIMER_TICK_MS);
            timer.Tick += OnChangeProperties;
            timer.Start();
            tlog.Fatal("NT", $"property change timer start! should be {TIMER_TICK_MS * MAX_TEST_REPEAT}ms");
        }

        private bool OnChangeProperties(object source, Timer.TickEventArgs e)
        {
            uint childCnt = rootView.ChildCount;

            for (uint i = 0; i < childCnt; i++)
            {
                int w = rand.Next(MIN_SIZE, MAX_SIZE);
                int h = rand.Next(MIN_SIZE, MAX_SIZE);
                int x = rand.Next(MIN_POSITION, MAX_POSITION);
                int y = rand.Next(MIN_POSITION, MAX_POSITION);
                float r = (float)rand.NextDouble();
                float g = (float)rand.NextDouble();
                float b = (float)rand.NextDouble();

                var child = rootView.GetChildAt(i);
                child.Size2D = new Size(w, h);
                child.Position2D = new Position2D(x, y);
                child.BackgroundColor = new Color(r, g, b, 1);
            }

            if (repeat++ > MAX_TEST_REPEAT)
            {
                tlog.Fatal("NT", $"property change timer end!");
                return false;
            }
            return true;
        }

        private void DisposeChildOfRootView()
        {
            int childCnt = (int)rootView.ChildCount;

            for (int i = childCnt - 1; i >= 0; i--)
            {
                var child = rootView.GetChildAt((uint)i);
                rootView.Remove(child);
                child.Dispose();
            }
        }
    }
}
