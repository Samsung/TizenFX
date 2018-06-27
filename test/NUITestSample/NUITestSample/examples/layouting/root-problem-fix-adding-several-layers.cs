using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace RootProblemFixAddingSeveralLayers
{
    public class CustomLayout : LayoutGroup
    {
        protected override void OnMeasure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            var accumulatedWidth = new LayoutLength(0);
            var maxHeight = 0;
            var measuredWidth = new LayoutLength(0);
            LayoutLength measuredHeight = new LayoutLength(0);
            LayoutMeasureSpec.ModeType widthMode = widthMeasureSpec.Mode;
            LayoutMeasureSpec.ModeType heightMode = heightMeasureSpec.Mode;

            bool isWidthExact = (widthMode == LayoutMeasureSpec.ModeType.EXACTLY);
            bool isHeightExact = (heightMode == LayoutMeasureSpec.ModeType.EXACTLY);

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
            var view = GetOwner();
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

    static class TestImages
    {
        public static string resources = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        //private const string resources = "./res";
        /// Child image filenames
        public static readonly string[] s_images = new string[]
        {
            resources + "/images/application-icon-101.png",
            resources + "/images/application-icon-102.png",
            resources + "/images/application-icon-103.png",
            resources + "/images/application-icon-104.png"
        };
    }

    class Example : NUIApplication
    {
        private Layer _layer;
        private Layer _layer2;
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
            // Create first new view
            View view = new View();
            view.Name = "CustomLayoutView";
            //view.ParentOrigin = ParentOrigin.Center;
            //view.PivotPoint = PivotPoint.Center;
            //view.PositionUsesPivotPoint = true;
            // Set our Custom Layout on the first view
            var layout = new CustomLayout();
            view.Layout = layout;
            view.WidthSpecification = ChildLayoutData.WrapContent;
            view.HeightSpecificationFixed = 350;
            view.BackgroundColor = Color.Blue;

            // Create second View
            View littleView = new View();
            littleView.Name = "LittleView";
            // Set our Custom Layout on the little view
            var layout2 = new CustomLayout();
            littleView.Layout = layout2;
            littleView.SetProperty(LayoutItemWrapper.ChildProperty.WIDTH_SPECIFICATION, new PropertyValue(-2));
            littleView.SetProperty(LayoutItemWrapper.ChildProperty.HEIGHT_SPECIFICATION, new PropertyValue(-2));
            littleView.BackgroundColor = Color.Red;
            littleView.Position2D = new Position2D(50, 50);
            // Add second View to a Layer
            _layer2 = new Layer();
            window.AddLayer(_layer2);
            _layer2.Add(littleView);

            // Create single single ImageView in it's own Layer
            _layer = new Layer();
            window.AddLayer(_layer);
            //_layer.Add(CreateChildImageView(TestImages.s_images[1], new Size2D(100, 100)));
            _layer.Add(view);
            // Initially single ImageView is not on top.
            _layer2.Raise();
            // Add an ImageView directly to window
            window.Add(CreateChildImageView(TestImages.s_images[2], new Size2D(200, 200)));
            // Add child image-views to the created view
            foreach (String image in TestImages.s_images)
            {
                view.Add(CreateChildImageView(image, new Size2D(100, 100)));
                littleView.Add(CreateChildImageView(image, new Size2D(50, 50)));
            }
            // Example info
            TextLabel label = new TextLabel("Blue icon in a layer");
            label.ParentOrigin = ParentOrigin.TopCenter;
            label.Position2D = new Position2D(-50, 0);
            window.Add(label);
            // Add button to Raise or Lower the single ImageView
            PushButton button = new PushButton();
            button.LabelText = "Raise Layer";
            button.ParentOrigin = ParentOrigin.BottomCenter;
            button.PivotPoint = PivotPoint.BottomCenter;
            button.PositionUsesPivotPoint = true;
            window.Add(button);

            button.Focusable = true;
            button.KeyEvent += Button_KeyEvent;
            FocusManager.Instance.SetCurrentFocusView(button);
        }

        private bool Button_KeyEvent(object source, View.KeyEventArgs e)
        {
            PushButton sender = source as PushButton;
            if(e.Key.State == Key.StateType.Down)
            {
                if (sender.LabelText == "Raise Layer")
                {
                    _layer.RaiseToTop();
                    sender.LabelText = "Lower Layer";
                }
                else
                {
                    sender.LabelText = "Raise Layer";
                    _layer.LowerToBottom();
                }
            }
            return true;
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
            Example app = new Example();
            app.Run(args);
        }
    }
}


