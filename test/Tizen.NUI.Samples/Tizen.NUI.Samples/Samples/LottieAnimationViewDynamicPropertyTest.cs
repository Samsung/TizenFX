using Tizen.NUI.BaseComponents;
using Tizen.NUI;

namespace Tizen.NUI.Samples
{
    public class LottieAnimationViewDynamicPropertyTest : IExample
    {
        const int NUM_OF_VIEW = 10;
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
                    Padding = new Extents(3, 3, 3, 3),
                },
            };
            win.Add(root);

            timer = new Timer(3000);
            timer.Tick += onTick;
            timer.Start();
        }

        int cnt;
        bool onTick(object sender, Timer.TickEventArgs e)
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
                    GcAll();
                    break;
                default:
                    DisposeAll();
                    break;
            }
            cnt++;
            return true;
        }

        void MakeAll()
        {
            Tizen.Log.Debug("NUITEST", $"MakeAll() start");
            for (int i = 0; i < NUM_OF_VIEW; i++)
            {
                var lav = new LottieAnimationView();
                lav.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "done.json";
                lav.LoopCount = -1;
                lav.BackgroundColor = Color.White;
                root.Add(lav);

                LottieAnimationView.DynamicProperty pro;
                pro.KeyPath = "Shape Layer 1.Ellipse 1.Fill 1";
                pro.Property = LottieAnimationView.VectorProperty.FillColor;
                pro.Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(onFillColor);
                lav.SetDynamicProperty(pro);

                pro.KeyPath = "**";
                pro.Property = LottieAnimationView.VectorProperty.StrokeColor;
                pro.Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(onStrokColor);
                lav.SetDynamicProperty(pro);

                pro.KeyPath = "**";
                pro.Property = LottieAnimationView.VectorProperty.StrokeWidth;
                pro.Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(onStrokWidth);
                lav.SetDynamicProperty(pro);

                pro.KeyPath = "Shape Layer 2.Shape 1";
                pro.Property = LottieAnimationView.VectorProperty.TransformRotation;
                pro.Callback = new Tizen.NUI.BaseComponents.LottieAnimationView.DynamicPropertyCallbackType(onTransformRotation);
                lav.SetDynamicProperty(pro);

                lav.Play();
            }
            Tizen.Log.Debug("NUITEST", $"MakeAll() end");
        }

        void DisposeAll()
        {
            Tizen.Log.Debug("NUITEST", $"DisposeAll() start");
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
            Tizen.Log.Debug("NUITEST", $"DisposeAll() end");
        }

        void GcAll()
        {
            Tizen.Log.Debug("NUITEST", $"GcAll() start");
            int childNum = (int)root.ChildCount;
            for (int i = childNum - 1; i >= 0; i--)
            {
                var child = root.GetChildAt((uint)i);
                if (child != null)
                {
                    child.Unparent();
                }
            }
            Tizen.Log.Debug("NUITEST", $"GcAll() end");
        }

        private PropertyValue onFillColor(int returnType, uint frameNumber)
        {
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
