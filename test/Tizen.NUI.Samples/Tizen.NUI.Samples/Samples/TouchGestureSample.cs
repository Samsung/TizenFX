using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class TouchGestureSample : IExample
    {
        private View root;
        // private View frontView;
        // private TextLabel backView;
        // private TapGestureDetector tapGestureDetector;
        // private LongPressGestureDetector longPressGestureDetector;

        private static readonly string imagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/gallery-medium-1.jpg";
        private Window window;
        ImageView bgView;
        private TapGestureDetector bgTapGestureDetector, imageViewTapGestureDetector;


        private View GetViewTree()
        {
            View bg = new View()
            {
                BackgroundColor = Color.Yellow,
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                ParentOrigin = ParentOrigin.TopLeft,
                Position = new Position(100, 100),
                Size = new Size(100, 300),
                Name = "BG",
            };

            bg.TouchEvent += (s, e) =>
            {
                Tizen.Log.Error("SHTEST", $"bgTouched {e.Touch.GetState(0u)}");
                return true;
            };

            bgTapGestureDetector = new TapGestureDetector();
            bgTapGestureDetector.Attach(bg);
            bgTapGestureDetector.Detected += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"OnTap bgTapped\n");
            };

            ImageView imageView = new ImageView()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
                Size = new Size(80, 80),
                ResourceUrl = imagePath,
                Name = "IMAGE",
            };

            imageView.TouchEvent += (s, e) =>
            {
                Tizen.Log.Error("SHTEST", $"imageViewTouched {e.Touch.GetState(0u)}");
                return false;
            };

            imageViewTapGestureDetector = new TapGestureDetector();
            imageViewTapGestureDetector.Attach(imageView);
            imageViewTapGestureDetector.Detected += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"OnTap imageViewTapped\n");
            };

            bg.Add(imageView);
            return bg;
        }

        public void Activate()
        {
            // NUIApplication.SetGeometryHittestEnabled(true);
            Window window = NUIApplication.GetDefaultWindow();
            // window.Title = "Window";

            // View defaultView = GetViewTree();
            // defaultView.OffScreenRendering = View.OffScreenRenderingType.RefreshAlways;

            root = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
            };
            // root.TouchEvent += (s, e) =>
            // {
            //     Tizen.Log.Error("SHTEST", $"root touched {e.Touch.GetState(0u)}");
            //     return false;
            // };
            // root.Add(defaultView);
            // window.Add(root);

            // arabic
            var textLabel = new TextLabel
            {
                LayoutDirectionPolicy = TextLayoutDirectionPolicy.Inherit,
                LayoutDirection = ViewLayoutDirectionType.RTL,
                EnableMarkup = true,
                Text = "*قد تختلف معدلات الشاشة المدعومة حسب الطراز."
            };

            // farsi
            var textLabel2 = new TextLabel
            {
                LayoutDirectionPolicy = TextLayoutDirectionPolicy.Inherit,
                LayoutDirection = ViewLayoutDirectionType.RTL,
                EnableMarkup = true,
                Text = "*نسبت‌های صفحه‌نمایش پشتیبانی‌شده بسته به مدل متفاوت خواهند بود."
            };

            // urdu
            var textLabel3 = new TextLabel
            {
                LayoutDirectionPolicy = TextLayoutDirectionPolicy.Inherit,
                LayoutDirection = ViewLayoutDirectionType.RTL,
                EnableMarkup = true,
                Text = "*تائید کردہ اسکرین تناسب ماڈل کے لحاظ سے مختلف ہو سکتے ہیں۔"
            };

            // hebrew
            var textLabel4 = new TextLabel
            {
                LayoutDirectionPolicy = TextLayoutDirectionPolicy.Inherit,
                LayoutDirection = ViewLayoutDirectionType.RTL,
                EnableMarkup = true,
                Text = "*יחסי גובה-רוחב הנתמכים עשויים להשתנות בהתאם לדגם."
            };

            // sorani
            var textLabel5 = new TextLabel
            {
                LayoutDirectionPolicy = TextLayoutDirectionPolicy.Inherit,
                LayoutDirection = ViewLayoutDirectionType.RTL,
                EnableMarkup = true,
                Text = "* ڕەنگە ڕێژەی شاشەی پشتیوانیکراو بەگوێرەی مۆدێل بگۆڕێت."
            };

            var textLabel6 = new TextLabel
            {
                LayoutDirectionPolicy = TextLayoutDirectionPolicy.Inherit,
                LayoutDirection = ViewLayoutDirectionType.RTL,
                EnableMarkup = true,
                Text = "&#x200f;*قد تختلف معدلات الشاشة المدعومة حسب الطراز."
            };
            root.Add(textLabel);
            root.Add(textLabel2);
            root.Add(textLabel3);
            root.Add(textLabel4);
            root.Add(textLabel5);
            root.Add(textLabel6);
            window.Add(root);


            // root = new View();
            // root.Size = new Size(1920, 1080);

            // window.WheelEvent += (s, e) =>
            // {
            //     Tizen.Log.Error("NUI", $"window WheelEvent!!!!{e.Wheel.Type}\n");
            // };

            // frontView = new View
            // {
            //     Size = new Size(300, 300),
            //     Position = new Position(150, 170),
            //     BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f),
            //     Focusable = true,
            //     FocusableInTouch = true,
            // };
            // frontView.TouchEvent += OnFrontTouchEvent;
            // frontView.WheelEvent += (s, e) =>
            // {
            //     Tizen.Log.Error("NUI", $"frontView WheelEvent!!!!{e.Wheel.Type}\n");
            //     if (e.Wheel.Type == Wheel.WheelType.CustomWheel)
            //     {
            //         // rotary event
            //     }
            //     else if (e.Wheel.Type == Wheel.WheelType.MouseWheel)
            //     {
            //         // mouse wheel event
            //     }
            //     return false;
            // };

            // var middleView = new View
            // {
            //     Size = new Size(300, 300),
            //     Position = new Position(110, 120),
            //     BackgroundColor = new Color(0.0f, 1.0f, 0.0f, 1.0f),
            //     Focusable = true,
            //     FocusableInTouch = true,
            // };


            // // The default the maximum allowed time is 500ms.
            // // If you want to change this time, do as below.
            // // But keep in mind this is a global option. Affects all gestures.
            // GestureOptions.Instance.SetDoubleTapTimeout(300);
            // tapGestureDetector = new TapGestureDetector();
            // tapGestureDetector.Attach(frontView);
            // tapGestureDetector.SetMaximumTapsRequired(2);
            // tapGestureDetector.Detected += (s, e) =>
            // {
            //     Tizen.Log.Error("NUI", $"OnTap {e.TapGesture.NumberOfTaps}\n");
            // };

            // backView = new TextLabel
            // {
            //     Size = new Size(300, 300),
            //     Text = "Back View",
            //     Position = new Position(50, 70),
            //     PointSize = 11,
            //     BackgroundColor = new Color(1.0f, 1.0f, 0.0f, 1.0f),
            //     Focusable = true,
            //     FocusableInTouch = true,
            // };
            // backView.TouchEvent += OnBackTouchEvent;
            // backView.WheelEvent += (s, e) =>
            // {
            //     Tizen.Log.Error("NUI", $"backView WheelEvent!!!!{e.Wheel.Type}\n");
            //     return true;
            // };

            // // The default the minimum holding time is 500ms.
            // // If you want to change this time, do as below.
            // // But keep in mind this is a global option. Affects all gestures.
            // GestureOptions.Instance.SetLongPressMinimumHoldingTime(300);

            // longPressGestureDetector = new LongPressGestureDetector();
            // longPressGestureDetector.Attach(backView);
            // longPressGestureDetector.Detected += (s, e) =>
            // {
            //     Tizen.Log.Error("NUI", $"OnLongPress\n");
            // };

            // backView.Add(middleView);
            // backView.Add(frontView);
            // root.Add(backView);
            // window.Add(root);
            // window.TouchEvent += (s, e) =>
            // {
            //     Tizen.Log.Error("NUI", $"window {e.Touch.GetState(0)} ================================\n");
            // };
        }

        // private bool OnFrontTouchEvent(object source, View.TouchEventArgs e)
        // {
        //     Tizen.Log.Error("NUI", $"OnFrontTouchEvent {e.Touch.GetState(0)}\n");
        //     if (e.Touch.GetState(0) == PointStateType.Down)
        //     {
        //         frontView.Unparent();
        //     }
        //     return true;
        // }


        private bool OnBackTouchEvent(object source, View.TouchEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnBackTouchEvent {e.Touch.GetState(0)}\n");
            return false;
        }

        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
