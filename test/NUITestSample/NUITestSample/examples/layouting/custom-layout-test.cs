using System;
using System.Threading;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace CustomLayoutByAbsoluteLayout
{
    static class Images
    {
        public static string resources = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        public static readonly string[] s_images = new string[]
        {
            resources + "images/gallery-1.jpg",
            resources + "images/gallery-2.jpg",
            resources + "images/gallery-3.jpg",
            resources + "images/gallery-4.jpg",
            resources + "images/image-1.jpg",
            resources + "images/image-2.jpg",
            resources + "images/image-3.jpg",
        };
    }

    public class CustomLayoutHorizental : LayoutGroup
    {
        private static LayoutItem[] childLayouts = new LayoutItem[10];

        public CustomLayoutHorizental()
        {
            Console.WriteLine($"CustomLayoutHorizental() constructor!");
        }
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            Console.WriteLine($"CustomLayoutHorizental OnMeasure() START");

            var accumulatedWidth = new LayoutLength(0);
            var maxHeight = new LayoutLength(0);

            // this is needed, otherwise the child's LayoutItem is garbage collected!
            for (uint i = 0; i < ChildCount; ++i)
            {
                childLayouts[i] = GetChildAt(i);
            }

            // In this layout we will:
            //  Measuring the layout with the children in a horizontal configuration, one after another
            //  Set the required width to be the accumulated width of our children
            //  Set the required height to be the maximum height of any of our children
            for (uint i = 0; i < ChildCount; ++i)
            {
                var childLayout = childLayouts[i];

                Console.WriteLine($"child count={ChildCount}, i={i}");
                if (childLayout)
                {
                    MeasureChild(childLayout, widthMeasureSpec, heightMeasureSpec);
                    accumulatedWidth += childLayout.MeasuredWidth;
                    maxHeight.Value = System.Math.Max(childLayout.MeasuredHeight.Value, maxHeight.Value);
                    Console.WriteLine($"child layout is not NULL! accumulatedWidth={accumulatedWidth.Value}, i={i}");
                }
            }
            // Finally, call this method to set the dimensions we would like
            SetMeasuredDimensions(new MeasuredSize(accumulatedWidth), new MeasuredSize(maxHeight));
            Console.WriteLine($"CustomLayoutHorizental OnMeasure() accumlated width={accumulatedWidth.Value}, maxHeight={maxHeight.Value} END");
        }
        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            Console.WriteLine($"CustomLayoutHorizental OnLayout() START");

            LayoutLength childTop = new LayoutLength(0);
            LayoutLength childLeft = new LayoutLength(0);

            // We want to vertically align the children to the middle
            var height = bottom - top;
            var middle = height / 2;

            // Horizontally align the children to the middle of the space they are given too
            var width = right - left;
            uint count = ChildCount;
            Console.WriteLine($"child count={count}");

            var childIncrement = 0;
            if (count > 0)
            {
                childIncrement = width.Value / System.Convert.ToInt32(count);
            }
            var center = childIncrement / 2;

            // Check layout direction
            var view = GetOwner();
            ViewLayoutDirectionType layoutDirection = view.LayoutDirection;

            // this is needed, otherwise the child's LayoutItem is garbage collected!
            for (uint i = 0; i < ChildCount; ++i)
            {
                childLayouts[i] = GetChildAt(i);
            }

            for (uint i = 0; i < count; i++)
            {
                uint itemIndex;
                // If RTL, then layout the last item first
                if (layoutDirection == ViewLayoutDirectionType.RTL)
                {
                    itemIndex = count - 1 - i;
                }
                else
                {
                    itemIndex = i;
                }

                var childLayout = childLayouts[itemIndex];
                if (childLayout)
                {
                    var childWidth = childLayout.MeasuredWidth;
                    var childHeight = childLayout.MeasuredHeight;

                    childTop = middle - (childHeight / 2);

                    var leftPosition = childLeft + center - childWidth / 2;

                    childLayout.Layout(leftPosition, childTop, leftPosition + childWidth, childTop + childHeight);
                    childLeft += childIncrement;

                    Console.WriteLine($"child layout is not NULL! childWidth={childWidth.Value}, i={i}");
                }
            }
            Console.WriteLine($"CustomLayoutHorizental OnLayout() END");
        }
    }

    public class CustomLayoutVertical : LayoutGroup
    {
        public CustomLayoutVertical()
        {
            this.LayoutAnimate = true;
        }

        private static LayoutItem[] childLayouts = new LayoutItem[10];

        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            var accumulatedHeight = new LayoutLength(0);
            var maxWidth = new LayoutLength(0);

            for (uint i = 0; i < ChildCount; ++i)
            {
                childLayouts[i] = GetChildAt(i);
            }

            for (uint i = 0; i < ChildCount; ++i)
            {
                var childLayout = childLayouts[i];
                if (childLayout)
                {
                    MeasureChild(childLayout, widthMeasureSpec, heightMeasureSpec);
                    accumulatedHeight += childLayout.MeasuredHeight;
                    maxWidth.Value = System.Math.Max(childLayout.MeasuredWidth.Value, maxWidth.Value);
                    Console.WriteLine($"CustomLayoutVertical child layout is not NULL! accumulatedHeight={accumulatedHeight.Value}, i={i}");
                }
            }
            SetMeasuredDimensions(new MeasuredSize(maxWidth), new MeasuredSize(accumulatedHeight));
            Console.WriteLine($"CustomLayoutVertical OnMeasure() max width={maxWidth.Value}, accumulated Height={accumulatedHeight.Value}");
        }

        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            LayoutLength childTop = new LayoutLength(0);
            LayoutLength childLeft = new LayoutLength(0);

            var height = bottom - top;
            var width = right - left;
            var middle = width / 2;

            uint count = ChildCount;
            var childIncrement = 0;
            if (count > 0)
            {
                childIncrement = height.Value / System.Convert.ToInt32(count);
            }
            var center = childIncrement / 2;

            var view = GetOwner();
            ViewLayoutDirectionType layoutDirection = view.LayoutDirection;

            for (uint i = 0; i < ChildCount; ++i)
            {
                childLayouts[i] = GetChildAt(i);
            }

            for (uint i = 0; i < count; i++)
            {
                uint itemIndex;
                if (layoutDirection == ViewLayoutDirectionType.RTL)
                {
                    itemIndex = count - 1 - i;
                }
                else
                {
                    itemIndex = i;
                }

                var childLayout = childLayouts[itemIndex];
                if (childLayout)
                {
                    var childWidth = childLayout.MeasuredWidth;
                    var childHeight = childLayout.MeasuredHeight;

                    childLeft = middle - (childWidth / 2);

                    var topPosition = childTop + center - childHeight / 2;

                    childLayout.Layout(childLeft, topPosition, childLeft + childWidth, topPosition + childHeight);
                    childTop += childIncrement;

                    Console.WriteLine($"CustomLayoutVertical child layout is not NULL! childWidth={childWidth.Value}, i={i}");
                }
            }
            Console.WriteLine($"CustomLayoutVertical OnLayout() END");
        }
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

        static View rootLayoutView, linearContainer;
        const int MAX_CHILDREN = 7;
        static ImageView[] imageViews = new ImageView[MAX_CHILDREN];
        static CustomLayoutHorizental horizontalLayout;
        static CustomLayoutVertical verticalLayout;
        static AbsoluteLayout rootLayout;

        private void Initialize()
        {
            Console.WriteLine("Initialize()!");
            Window window = Window.Instance;
            window.BackgroundColor = Color.Green;

            rootLayoutView = new View();
            rootLayoutView.WidthSpecificationFixed = 1900;
            rootLayoutView.HeightSpecificationFixed = 1000;
            rootLayoutView.Position = new Position(0, 0, 0);
            rootLayoutView.BackgroundColor = Color.Magenta;

            linearContainer = new View();
            linearContainer.PositionUsesPivotPoint = true;
            linearContainer.PivotPoint = PivotPoint.Center;
            linearContainer.ParentOrigin = ParentOrigin.Center;
            //linearContainer.BackgroundColor = Color.Yellow;
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
            }

            horizontalLayout = new CustomLayoutHorizental();
            verticalLayout = new CustomLayoutVertical();
            horizontalLayout.LayoutAnimate = true;
            linearContainer.Layout = horizontalLayout;

            rootLayout = new AbsoluteLayout();
            rootLayoutView.Layout = rootLayout;

            rootLayoutView.Add(linearContainer);
            window.Add(rootLayoutView);
            FocusManager.Instance.SetCurrentFocusView(linearContainer);
            FocusManager.Instance.FocusIndicator = new View();
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
                        linearContainer.Layout = verticalLayout;
                        break;

                    case "Down":
                        linearContainer.Layout = horizontalLayout;
                        break;

                    case "Return":
                        if (linearContainer.LayoutDirection == ViewLayoutDirectionType.LTR) { linearContainer.LayoutDirection = ViewLayoutDirectionType.RTL; }
                        else { linearContainer.LayoutDirection = ViewLayoutDirectionType.LTR; }
                        break;
                }
            }
            return true;
        }
    }
}
