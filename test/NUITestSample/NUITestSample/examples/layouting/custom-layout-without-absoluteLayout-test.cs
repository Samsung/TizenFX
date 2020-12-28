using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace SimpleLayout
{
    public class CustomLayout : LayoutGroup
    {
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            var accumulatedWidth = new LayoutLength(0);
            var maxHeight = 0;
            var measuredWidth = new LayoutLength(0);
            LayoutLength measuredHeight = new LayoutLength(0);
            MeasureSpecification.ModeType widthMode = widthMeasureSpec.Mode;
            MeasureSpecification.ModeType heightMode = heightMeasureSpec.Mode;

            bool isWidthExact = (widthMode == MeasureSpecification.ModeType.EXACTLY);
            bool isHeightExact = (heightMode == MeasureSpecification.ModeType.EXACTLY);

            // In this layout we will:
            //  Measuring the layout with the children in a horizontal configuration, one after another
            //  Set the required width to be the accumulated width of our children
            //  Set the required height to be the maximum height of any of our children

            for (uint i = 0; i < ChildCount; ++i)
            {
                var childLayout = GetChildAt(i);
                if (childLayout)
                {
                    MeasureChild(childLayout, widthMeasureSpec, heightMeasureSpec);
                    accumulatedWidth += childLayout.MeasuredWidth;
                    maxHeight = System.Math.Max(childLayout.MeasuredHeight.Value, maxHeight);
                }
            }

            measuredHeight.Value = maxHeight;
            measuredWidth = accumulatedWidth;

            if (isWidthExact)
            {
                measuredWidth = new LayoutLength(widthMeasureSpec.Size);
            }

            if (isHeightExact)
            {
                measuredHeight = new LayoutLength(heightMeasureSpec.Size);
            }

            // Finally, call this method to set the dimensions we would like
            SetMeasuredDimensions(new MeasuredSize(measuredWidth), new MeasuredSize(measuredHeight));
        }

        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            LayoutLength childTop = new LayoutLength(0);
            LayoutLength childLeft = new LayoutLength(0);

            // We want to vertically align the children to the middle
            var height = bottom - top;
            var middle = height / 2;

            // Horizontally align the children to the middle of the space they are given too
            var width = right - left;
            uint count = ChildCount;
            var childIncrement = 0;
            if (count > 0)
            {
                childIncrement = width.Value / System.Convert.ToInt32(count);
            }
            var center = childIncrement / 2;

            // Check layout direction
            var view = Owner;
            ViewLayoutDirectionType layoutDirection = view.LayoutDirection;

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

                LayoutItem childLayout = GetChildAt(itemIndex);
                if (childLayout)
                {
                    var childWidth = childLayout.MeasuredWidth;
                    var childHeight = childLayout.MeasuredHeight;

                    childTop = middle - (childHeight / 2);

                    var leftPosition = childLeft + center - childWidth / 2;

                    childLayout.Layout(leftPosition, childTop, leftPosition + childWidth, childTop + childHeight);
                    childLeft += childIncrement;
                }
            }
        }
    }
}

namespace SimpleLayout
{
    static class TestImages
    {
        //private const string resources = "./res";
        public static string resources = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        /// Child image filenames
        public static readonly string[] s_images = new string[]
        {
            resources + "/images/application-icon-101.png",
            resources + "/images/application-icon-102.png",
            resources + "/images/application-icon-103.png",
            resources + "/images/application-icon-104.png"
        };
    }

    class SimpleLayout : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void Initialize()
        {
            // Change the background color of Window to White
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            //Layer layer = new Layer();

            //window.AddLayer(layer);

            // Create a new view
            View customLayoutView = new View();
            customLayoutView.Name = "CustomLayoutView";
            customLayoutView.ParentOrigin = ParentOrigin.Center;
            customLayoutView.PivotPoint = PivotPoint.Center;
            customLayoutView.PositionUsesPivotPoint = true;
            // Set our Custom Layout on the view
            var layout = new CustomLayout();
            customLayoutView.Layout = layout;
            customLayoutView.SetProperty(LayoutItemWrapper.ChildProperty.WIDTH_SPECIFICATION, new PropertyValue(-2));  // -2 WRAP_CONTENT
            customLayoutView.SetProperty(LayoutItemWrapper.ChildProperty.HEIGHT_SPECIFICATION, new PropertyValue(350));
            customLayoutView.BackgroundColor = Color.Blue;
            window.Add(customLayoutView);

            // Add child image-views to the created view
            foreach (String image in TestImages.s_images)
            {
                customLayoutView.Add(CreateChildImageView(image, new Size2D(100, 100)));
            }
        }

        /// <summary>
        /// Helper function to create ImageViews with given filename and size..<br />
        /// </summary>
        /// <param name="filename"> The filename of the image to use.</param>
        /// <param name="size"> The size that the image should be loaded at.</param>
        /// <returns>The created ImageView.</returns>
        ImageView CreateChildImageView(String url, Size2D size)
        {
            ImageView imageView = new ImageView();
            ImageVisual imageVisual = new ImageVisual();

            imageVisual.URL = url;
            imageVisual.DesiredHeight = size.Height;
            imageVisual.DesiredWidth = size.Width;
            imageView.Image = imageVisual.OutputVisualMap;

            imageView.Name = "ImageView";
            imageView.HeightResizePolicy = ResizePolicyType.Fixed;
            imageView.WidthResizePolicy = ResizePolicyType.Fixed;
            return imageView;
        }

        static void _Main(string[] args)
        {
            SimpleLayout simpleLayout = new SimpleLayout();
            simpleLayout.Run(args);
        }
    }
}


