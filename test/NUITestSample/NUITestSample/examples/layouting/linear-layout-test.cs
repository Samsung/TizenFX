﻿using System;
using System.Threading;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;


namespace NUILinearLayoutSample
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

        View rootLayoutView, linearContainer;
        const int MAX_CHILDREN = 7;
        ImageView[] imageViews = new ImageView[MAX_CHILDREN];
        LinearLayout linearlayout;
        LayoutSize layoutsize;
        private void Initialize()
        {
            Console.WriteLine("Initialize()!");
            Window window = Window.Instance;
            window.BackgroundColor = Color.Green;

            rootLayoutView = new View();
            rootLayoutView.WidthSpecificationFixed = 1900;
            rootLayoutView.HeightSpecificationFixed = 1000;
            rootLayoutView.Position = new Position(0, 0, 0);
            rootLayoutView.BackgroundColor = Color.Green;
            //window.Add(rootLayoutView);

            linearContainer = new View();
            linearContainer.PositionUsesPivotPoint = true;
            linearContainer.PivotPoint = PivotPoint.Center;
            linearContainer.ParentOrigin = ParentOrigin.Center;
            linearContainer.BackgroundColor = Color.Yellow;
            linearContainer.KeyEvent += OnKeyEvent;
            linearContainer.Focusable = true;

            for (int index = 0; index < MAX_CHILDREN - 3; index++)
            {
                imageViews[index] = new ImageView(Images.s_images[index]);
                imageViews[index].WidthSpecificationFixed = 150;
                imageViews[index].HeightSpecificationFixed = 100;
                linearContainer.Add(imageViews[index]);
            }
            for (int index = MAX_CHILDREN - 3; index < MAX_CHILDREN; index++)
            {
                imageViews[index] = new ImageView(Images.s_images[index]);
                imageViews[index].WidthSpecificationFixed = 150;
                imageViews[index].HeightSpecificationFixed = 100;
                imageViews[index].Name = "t_image" + (index - 3);
                //test!
                //imageViews[index].WidthSpecification = ChildLayoutData.MatchParent;
                //imageViews[index].HeightSpecification = ChildLayoutData.MatchParent;
            }

            layoutsize = new LayoutSize(50, 50);
            Console.WriteLine($"## layoutsize width={layoutsize.Width}, height={layoutsize.Height}");

            linearlayout = new LinearLayout();
            linearlayout.LayoutAnimate = true;
            linearlayout.LinearOrientation = LinearLayout.Orientation.Vertical;

            Console.WriteLine($"## TP1");
            //Console.WriteLine($"linearlayout p=0x{LinearLayout.getCPtr(linearlayout).Handle.ToInt64():X},  layoutsize p=0x{LayoutSize.getCPtr(layoutsize).Handle.ToInt64():X}");

            linearlayout.CellPadding = layoutsize;
            Console.WriteLine($"## TP2");
            linearContainer.WidthSpecification = ChildLayoutData.WrapContent;
            linearContainer.HeightSpecification = ChildLayoutData.WrapContent;
            Console.WriteLine($"## TP3");
            linearContainer.Layout = linearlayout;
            Console.WriteLine($"## TP4");

            //var __layout = linearContainer.Layout as LinearLayout;
            var __layout = linearlayout;
            Console.WriteLine($"##  layout orientation={__layout.LinearOrientation}");
            var __cellpadding = __layout.CellPadding;
            Console.WriteLine($"##  layout cellpadding width={__cellpadding.Width}, height={ __cellpadding.Height}");

            //var rootLayout = new AbsoluteLayout();
            //rootLayoutView.Layout = rootLayout;
            //rootLayoutView.Add(linearContainer);

            window.Add(linearContainer);
            FocusManager.Instance.SetCurrentFocusView(linearContainer);
        }

        int cnt1 = 1;
        private bool OnKeyEvent(object source, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                Console.WriteLine($"key pressed name={e.Key.KeyPressedName}");
                switch (e.Key.KeyPressedName)
                {
                    case "Right":
                        if (cnt1 < 4 && cnt1 > 0)
                        {
                            linearContainer.Add(imageViews[cnt1 + 3]);
                            cnt1++;
                        }
                        break;

                    case "Left":
                        if (cnt1 - 1 < 4 && cnt1 - 1 > 0)
                        {
                            View tmp = linearContainer.FindChildByName("t_image" + (cnt1 - 1));
                            if (tmp != null)
                            {
                                linearContainer.Remove(tmp);
                                cnt1--;
                            }
                        }
                        break;

                    case "Up":
                        var vertical = new LinearLayout();
                        vertical.LayoutAnimate = true;
                        vertical.LinearOrientation = LinearLayout.Orientation.Vertical;
                        linearContainer.Layout = vertical;
                        break;

                    case "Down":
                        var horizon = new LinearLayout();
                        horizon.LayoutAnimate = true;
                        horizon.LinearOrientation = LinearLayout.Orientation.Horizontal;
                        horizon.CellPadding = new LayoutSize(200, 200);
                        linearContainer.Layout = horizon;
                        break;

                    case "Return":
                        if (linearContainer.LayoutDirection == ViewLayoutDirectionType.LTR) { linearContainer.LayoutDirection = ViewLayoutDirectionType.RTL; }
                        else { linearContainer.LayoutDirection = ViewLayoutDirectionType.LTR; }
                        break;
                }
            }
            return true;
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example layoutSample = new Example();
            layoutSample.Run(args);
        }

    }
}




