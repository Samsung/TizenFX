using Tizen.NUI.BaseComponents;
using Tizen.NUI;

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
            timer.Tick += onTick;
            timer.Start();
        }

        int cnt;
        bool onTick(object sender, Timer.TickEventArgs e)
        {
            bool ret = false;
            //ret = test1();
            ret = test2();
            return ret;
        }

        //create objects => explicit dispose => create objects => implicit dispose
        bool test1()
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
        bool test2()
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
            int width = (int)(root.Size.Width / NUM_OF_VIEW);
            for (int i = 0; i < NUM_OF_VIEW; i++)
            {
                var lav = new LottieAnimationView();
                lav.Size2D = new Size2D(width, width);
                lav.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "done.json";
                lav.LoopCount = -1;
                lav.BackgroundColor = Color.White;
                root.Add(lav);

                LottieAnimationView.DynamicProperty pro;
                if (i % 1 == 0)
                {
                    pro.KeyPath = "Shape Layer 1.Ellipse 1.Fill 1";
                    pro.Property = LottieAnimationView.VectorProperty.FillColor;
                    pro.Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(onFillColor);
                    lav.DoActionExtension(pro);
                }

                if (i % 2 == 0)
                {
                    pro.KeyPath = "**";
                    pro.Property = LottieAnimationView.VectorProperty.StrokeColor;
                    pro.Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(onStrokColor);
                    lav.DoActionExtension(pro);
                }

                if (i % 3 == 0)
                {
                    pro.KeyPath = "**";
                    pro.Property = LottieAnimationView.VectorProperty.StrokeWidth;
                    pro.Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(onStrokWidth);
                    lav.DoActionExtension(pro);
                }

                if (i % 4 == 0)
                {

                    pro.KeyPath = "Shape Layer 2.Shape 1";
                    pro.Property = LottieAnimationView.VectorProperty.TransformRotation;
                    pro.Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(onTransformRotation);
                    lav.DoActionExtension(pro);
                }

                lav.Play();
            }
            tlog.Debug(tag, $"MakeAll() end");
        }

        void DisposeAll()
        {
            tlog.Debug(tag, $"DisposeAll() start");
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

        private PropertyValue onFillColor(int returnType, uint frameNumber)
        {
            tlog.Debug(tag, $"onFillColor() returnType={returnType} frameNumber={frameNumber}");
            if (frameNumber < 60)
            {
                return new PropertyValue(new Vector3(0, 0, 1));
            }
            else
            {
                return new PropertyValue(new Vector3(1, 0, 0));
            }
        }

        private PropertyValue onStrokColor(int returnType, uint frameNumber)
        {
            tlog.Debug(tag, $"onStrokColor() returnType={returnType} frameNumber={frameNumber}");
            if (frameNumber < 60)
            {
                return new PropertyValue(new Vector3(1, 0, 1));
            }
            else
            {
                return new PropertyValue(new Vector3(1, 1, 0));
            }
        }

        private PropertyValue onStrokWidth(int returnType, uint frameNumber)
        {
            tlog.Debug(tag, $"onStrokWidth() returnType={returnType} frameNumber={frameNumber}");

            if (frameNumber < 60)
            {
                return new PropertyValue(2.0f);
            }
            else
            {
                return new PropertyValue(5.0f);
            }
        }

        private PropertyValue onTransformRotation(int returnType, uint frameNumber)
        {
            tlog.Debug(tag, $"onTransformRotation() returnType={returnType} frameNumber={frameNumber}");

            return new PropertyValue(frameNumber * 20.0f);
        }

        public void Deactivate()
        {
            root.Unparent();
            timer.Stop();
            DisposeAll();
            root.Dispose();
        }
    }
}
