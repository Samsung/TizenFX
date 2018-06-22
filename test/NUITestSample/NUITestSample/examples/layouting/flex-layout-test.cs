using System;
using System.Threading;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIFlexLayoutSample
{
    static class Images
    {
        public static string resources = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        public static readonly string[] s_images = new string[]
        {
            resources + "images/application-icon-101.png",
            resources + "images/application-icon-102.png",
            resources + "images/application-icon-103.png",
            resources + "images/application-icon-104.png",
            resources + "images/image-1.jpg",
            resources + "images/image-2.jpg",
            resources + "images/image-3.jpg",
        };
    }

    class Example : NUIApplication
    {
        public Example() : base()
        {
            Console.WriteLine("Example()!");
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        View flexContainer;
        const int MAX_CHILDREN = 7;
        ImageView[] imageViews = new ImageView[MAX_CHILDREN];
        private void Initialize()
        {
            Console.WriteLine("Initialize()!");
            Window window = Window.Instance;
            window.BackgroundColor = Color.Green;

            flexContainer = new View();
            flexContainer.PositionUsesPivotPoint = true;
            flexContainer.PivotPoint = PivotPoint.Center;
            flexContainer.ParentOrigin = ParentOrigin.Center;
            flexContainer.BackgroundColor = Color.Yellow;

            for (int index = 0; index < MAX_CHILDREN - 3; index++)
            {
                imageViews[index] = new ImageView(Images.s_images[index]);
                imageViews[index].WidthSpecificationFixed = 100;
                imageViews[index].HeightSpecificationFixed = 100;
                flexContainer.Add(imageViews[index]);
            }
            for (int index = MAX_CHILDREN - 3; index < MAX_CHILDREN; index++)
            {
                imageViews[index] = new ImageView(Images.s_images[index]);
                imageViews[index].WidthSpecificationFixed = 200;
                imageViews[index].HeightSpecificationFixed = 200;
                imageViews[index].Name = "t_image" + (index - 3);
            }

            var layout = new FlexLayout();
            layout.LayoutAnimate = true;
            layout.Direction = FlexLayout.FlexDirection.ColumnReverse;
            flexContainer.WidthSpecificationFixed = 500;
            flexContainer.HeightSpecificationFixed = 500;
            flexContainer.Layout = layout;

            window.Add(flexContainer);
            window.KeyEvent += OnKeyEvent;
        }

        int cnt1 = 1;
        private void OnKeyEvent(object source, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                Console.WriteLine($"key pressed name={e.Key.KeyPressedName}");
                switch (e.Key.KeyPressedName)
                {
                    case "Right":
                        if (cnt1 < 4 && cnt1 > 0)
                        {
                            flexContainer.Add(imageViews[cnt1 + 3]);
                            cnt1++;
                        }
                        break;

                    case "Left":
                        if (cnt1 - 1 < 4 && cnt1 - 1 > 0)
                        {
                            View tmp = flexContainer.FindChildByName("t_image" + (cnt1 - 1));
                            if (tmp != null)
                            {
                                flexContainer.Remove(tmp);
                                cnt1--;
                            }
                        }
                        break;

                    case "Up":
                        var vertical = new FlexLayout();
                        vertical.LayoutAnimate = true;
                        vertical.Direction = FlexLayout.FlexDirection.Column;
                        flexContainer.Layout = vertical;
                        break;

                    case "Down":
                        var horizon = new FlexLayout();
                        horizon.LayoutAnimate = true;
                        horizon.Direction = FlexLayout.FlexDirection.Row;
                        flexContainer.Layout = horizon;
                        break;

                    case "Return":
                        if (flexContainer.LayoutDirection == ViewLayoutDirectionType.LTR) { flexContainer.LayoutDirection = ViewLayoutDirectionType.RTL; }
                        else { flexContainer.LayoutDirection = ViewLayoutDirectionType.LTR; }
                        break;

                    case "1":
                        var tmpLayout = flexContainer.Layout as FlexLayout;
                        if (tmpLayout.WrapType == FlexLayout.FlexWrapType.NoWrap) { tmpLayout.WrapType = FlexLayout.FlexWrapType.Wrap; }
                        else { tmpLayout.WrapType = FlexLayout.FlexWrapType.NoWrap; }
                        break;
                }
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example layoutSample = new Example();
            layoutSample.Run(args);
        }

    }
}
