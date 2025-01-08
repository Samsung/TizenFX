
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;
    public class LottieAnimationViewDynamicPropertyTest : IExample
    {

        const int NUM_OF_VIEW = 5;
        const int TIMER_INTERVAL = 3000;
        const string tag = "NUITEST";
        Window win;
        View root;
        Timer timer;
        List<LottieAnimationView> lavList = new();
        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(win.Size.Width, win.Size.Height, 0),
                BackgroundColor = Color.Yellow,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
            };
            win.Add(root);

            timer = new Timer(TIMER_INTERVAL);
            timer.Tick += OnTick;
            timer.Start();
        }

        int cnt;
        bool OnTick(object sender, Timer.TickEventArgs e)
        {
            bool ret = false;
            // ret = Test1();
            // ret = Test2();
            ret = Test3();
            // ret = Test4();
            // ret = Test5();
            return ret;
        }

        //create objects => explicit dispose => create objects => implicit dispose
        bool Test1()
        {
            switch (cnt % 4)
            {
                case 0:
                    MakeAll();
                    break;
                case 1:
                    DisposeAll();
                    break;
                case 2:
                    MakeAll();
                    break;
                case 3:
                    ImplicitDispose();
                    break;
                default:
                    DisposeAll();
                    break;
            }
            cnt++;
            return true;
        }

        //create objects => implicit dispose => force full GC
        bool Test2()
        {
            switch (cnt % 3)
            {
                case 0:
                    MakeAll();
                    break;
                case 1:
                    ImplicitDispose();
                    break;
                case 2:
                    ForceFullGC();
                    break;
                default:
                    DisposeAll();
                    break;
            }
            cnt++;
            return true;
        }

        //create objects with same as before. Let's check whether leak occured or not.
        bool Test3()
        {
            if (timer.Interval == TIMER_INTERVAL)
            {
                // Change the interval more tight, to check memory leak
                timer.Interval = TIMER_INTERVAL / 10;
            }

            MakeAll();
            if (cnt % 2 == 0)
            {
                ForceFullGC();
            }
            cnt++;
            return true;
        }

        //create objects first, and change ImageView property what might give effort to lottie images.
        //Let's check whether dynamic callback still called or not.
        bool Test4()
        {
            if (cnt == 0)
            {
                MakeAll();
            }
            else
            {
                LottieAnimationView lav = null;
                if (lavList?.Count > 0)
                {
                    lav = lavList[0];
                }
                if (lav != null)
                {
                    // TODO : It will not affect to lottie image, but will create new visual.
                    //        Let's make this sample works well in future.
                    tlog.Debug(tag, $"non-Lottie relative property change start");
                    lav.FastTrackUploading = true;
                    lav.Play();
                    tlog.Debug(tag, $"non-Lottie relative property change done");
                }
            }
            cnt++;
            return cnt < 2;
        }

        global::System.Random rand = new global::System.Random();
        bool Test5()
        {
            var lav = new LottieAnimationView();
            lav.Size2D = new Size2D(300, 300);
            lav.Position2D = new Position2D(rand.Next(10, 1000), rand.Next(10, 1000));
            if (cnt++ % 2 == 0)
            {
                lav.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "a.json";
            }
            else
            {
                lav.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "done.json";
            }
            lav.LoopCount = -1;
            lav.BackgroundColor = Color.White;
            root.Add(lav);
            lav.Play();

            var ret = lav.GetContentInfo();
            tlog.Fatal(tag, $"ret.Count {ret.Count}");
            foreach (var item in ret)
            {
                tlog.Fatal(tag, $"item:({item.Item1}, {item.Item2}, {item.Item3})");
            }
            return true;
        }

        void ForceFullGC()
        {
            tlog.Debug(tag, "ForceFullGC start");
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
            tlog.Debug(tag, "ForceFullGC end");
        }

        void MakeAll()
        {
            tlog.Debug(tag, $"MakeAll() start");
            int width = (int)(root.Size.Width / (NUM_OF_VIEW + 2));
            for (int i = 0; i < NUM_OF_VIEW; i++)
            {
                LottieAnimationView lav;
                if (lavList?.Count > i)
                {
                    lav = lavList[i];
                }
                else
                {
                    lav = new LottieAnimationView();
                    lavList?.Add(lav);
                    root.Add(lav);
                }
                lav.Size2D = new Size2D(width, width);
                lav.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "done.json";
                lav.LoopCount = -1;
                lav.BackgroundColor = Color.White;

                LottieAnimationViewDynamicProperty pro = new LottieAnimationViewDynamicProperty
                {
                    KeyPath = "Shape Layer 1.Ellipse 1.Fill 1",
                    Property = LottieAnimationView.VectorProperty.FillColor,
                    Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(OnFillColor),
                };

                if (i % 1 == 0)
                {
                    lav.DoActionExtension(pro);
                }

                if (i % 2 == 0)
                {
                    pro.KeyPath = "**";
                    pro.Property = LottieAnimationView.VectorProperty.StrokeColor;
                    pro.Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(OnStrokColor);
                    lav.DoActionExtension(pro);
                }

                if (i % 3 == 0)
                {
                    pro.KeyPath = "**";
                    pro.Property = LottieAnimationView.VectorProperty.StrokeWidth;
                    pro.Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(OnStrokWidth);
                    lav.DoActionExtension(pro);
                }

                if (i % 4 == 0)
                {
                    pro.KeyPath = "Shape Layer 2.Shape 1";
                    pro.Property = LottieAnimationView.VectorProperty.TransformRotation;
                    pro.Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(OnTransformRotation);
                    lav.DoActionExtension(pro);
                }
                lav.Play();
            }

            {
                LottieAnimationView lav;
                if (lavList?.Count > NUM_OF_VIEW + 0)
                {
                    lav = lavList[NUM_OF_VIEW + 0];
                }
                else
                {
                    lav = new LottieAnimationView();
                    lavList?.Add(lav);
                    root.Add(lav);
                }
                lav.Size2D = new Size2D(width, width);
                lav.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "30.json";
                lav.LoopCount = -1;
                lav.BackgroundColor = Color.Black;
                lav.Play();
            }
            {
                LottieAnimationView lav;
                if (lavList?.Count > NUM_OF_VIEW + 1)
                {
                    lav = lavList[NUM_OF_VIEW + 1];
                }
                else
                {
                    lav = new LottieAnimationView();
                    lavList?.Add(lav);
                    root.Add(lav);
                }
                lav.Size2D = new Size2D(width, width);
                lav.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "100.json";
                lav.LoopCount = -1;
                lav.BackgroundColor = Color.Black;

                LottieAnimationViewDynamicProperty pro = new LottieAnimationViewDynamicProperty
                {
                    // KeyPath = "**",
                    KeyPath = "Shape Layer 1.Trim Paths 1",
                    Property = LottieAnimationView.VectorProperty.TrimEnd,
                    Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(OnTrimEnd),
                };
                lav.DoActionExtension(pro);
                LottieAnimationViewDynamicProperty pro1 = new LottieAnimationViewDynamicProperty
                {
                    // KeyPath = "**",
                    KeyPath = "Shape Layer 1.Trim Paths 1",
                    Property = LottieAnimationView.VectorProperty.TrimStart,
                    Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(OnTrimStart),
                };
                lav.DoActionExtension(pro1);
                lav.Play();
            }
            tlog.Debug(tag, $"MakeAll() end");
        }

        void DisposeAll()
        {
            tlog.Debug(tag, $"DisposeAll() start");
            lavList?.Clear();
            int childNum = (int)root.ChildCount;
            for (int i = childNum - 1; i >= 0; i--)
            {
                var child = root.GetChildAt((uint)i);
                if (child != null)
                {
                    child.Unparent();
                    child.Dispose();
                }
            }
            tlog.Debug(tag, $"DisposeAll() end");
        }

        void ImplicitDispose()
        {
            tlog.Debug(tag, $"ImplicitDispose() start");
            lavList?.Clear();
            int childNum = (int)root.ChildCount;
            for (int i = childNum - 1; i >= 0; i--)
            {
                var child = root.GetChildAt((uint)i);
                if (child != null)
                {
                    child.Unparent();
                }
            }
            tlog.Debug(tag, $"ImplicitDispose() end");
        }

        private PropertyValue OnFillColor(int returnType, uint frameNumber)
        {
            tlog.Debug(tag, $"OnFillColor() returnType={returnType} frameNumber={frameNumber}");
            if (frameNumber < 60)
            {
                return new PropertyValue(new Vector3(0, 0, 1));
            }
            else
            {
                return new PropertyValue(new Vector3(1, 0, 0));
            }
        }

        private PropertyValue OnStrokColor(int returnType, uint frameNumber)
        {
            tlog.Debug(tag, $"OnStrokColor() returnType={returnType} frameNumber={frameNumber}");
            if (frameNumber < 60)
            {
                return new PropertyValue(new Vector3(1, 0, 1));
            }
            else
            {
                return new PropertyValue(new Vector3(1, 1, 0));
            }
        }

        private PropertyValue OnStrokWidth(int returnType, uint frameNumber)
        {
            tlog.Debug(tag, $"OnStrokWidth() returnType={returnType} frameNumber={frameNumber}");

            if (frameNumber < 60)
            {
                return new PropertyValue(2.0f);
            }
            else
            {
                return new PropertyValue(5.0f);
            }
        }

        private PropertyValue OnTransformRotation(int returnType, uint frameNumber)
        {
            tlog.Debug(tag, $"OnTransformRotation() returnType={returnType} frameNumber={frameNumber}");

            return new PropertyValue(frameNumber * 20.0f);
        }

        private PropertyValue OnTrimEnd(int returnType, uint frameNumber)
        {
            tlog.Debug(tag, $"OnTrimEnd() returnType={returnType} frameNumber={frameNumber}");

            return new PropertyValue(new Vector2(0.0f, 30.0f));
        }

        private PropertyValue OnTrimStart(int returnType, uint frameNumber)
        {
            tlog.Debug(tag, $"OnTrimStart() returnType={returnType} frameNumber={frameNumber}");

            return new PropertyValue(0.0f);
        }

        public void Deactivate()
        {
            root.Unparent();
            timer.Stop();
            DisposeAll();
            root.Dispose();
            lavList?.Clear();
            lavList = null;
        }
    }
}
