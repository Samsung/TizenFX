using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace WhiteboardGallery
{
    class Program : NUIApplication
    {
        class CustomBorder : DefaultBorder
        {
            float fontScale = 4.0f;
            private int width = 300;
            private bool hide = false;
            private string title;
            private View borderView;
            private Color backgroundColor;

            private TextLabel titleLabel;
            private Rectangle preWinPositonSize;

            public CustomBorder(string title) : base()
            {
                this.title = title;
            }

            public override bool CreateTopBorderView(View topView)
            {
                if (topView == null)
                {
                  return false;
                }
                topView.Layout = new LinearLayout()
                {
                  LinearOrientation = LinearLayout.Orientation.Horizontal,
                  LinearAlignment = LinearLayout.Alignment.CenterVertical,
                  CellPadding = new Size2D(20, 20),
                };

                titleLabel = new TextLabel()
                {
                  Text = title,
                  TextColor = Color.White,
                  PointSize = fontScale * 4,
                };
                topView.Add(titleLabel);
                return true;
            }

            public override bool CreateBottomBorderView(View bottomView)
            {
                base.CreateBottomBorderView(bottomView);
                return true;
            }

            public override void OnCreated(View borderView)
            {
                base.OnCreated(borderView);
                this.borderView = borderView;
                backgroundColor = new Color(borderView.BackgroundColor);
            }

            public override void OnMaximize(bool isMaximized)
            {
                if (isMaximized == true)
                {
                    if (borderView != null)
                    {
                        borderView.BackgroundColor = Color.White;
                    }
                }
                else
                {
                    if (borderView != null)
                    {
                        borderView.BackgroundColor = backgroundColor;
                    }
                }
                base.OnMaximize(isMaximized);
            }
/*
            public override bool OnMinimizeIconTouched(object sender, View.TouchEventArgs e)
            {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                  if (BorderWindow.IsMaximized() == true)
                  {
                    BorderWindow.Maximize(false);
                  }
                  preWinPositonSize = BorderWindow.WindowPositionSize;
                  BorderWindow.WindowPositionSize = new Rectangle(preWinPositonSize.X, preWinPositonSize.Y, 400, 0);
                }
                return true;
            }
*/

            public override void OnResized(int width, int height)
            {
              if (borderView != null)
              {
                if (this.width > width && hide == false)
                {
                  titleLabel.Hide();
                  hide = true;
                }
                else if (this.width < width && hide == true)
                {
                  titleLabel.Show();
                  hide = false;
                }
                base.OnResized(width, height);
              }
            }

            public override bool OnCloseIconTouched(object sender, View.TouchEventArgs e)
            {
                if (e.Touch.GetState(0) == PointStateType.Up && app != null)
                {
                    app.Exit();
                }
                return true;
            }
        }
        public Program(string styleSheet, Size2D windowSize, Position2D windowPosition, IBorderInterface borderInterface) : base(styleSheet, windowSize, windowPosition, borderInterface)
        {
        }
        public static Program app;

        View windowMainView;
        ImageView galleryView;
        DragAndDrop dnd;
    
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            // Create DnD Instance
            dnd = DragAndDrop.Instance;
            Window.Instance.KeyEvent += OnKeyEvent;

            windowMainView = new View()
            {
               Layout = new LinearLayout()
               {
                  LinearOrientation = LinearLayout.Orientation.Vertical,
               },
               WidthSpecification = LayoutParamPolicies.MatchParent,
               HeightSpecification = LayoutParamPolicies.MatchParent,
               BackgroundColor = Color.White,
               CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
               CornerRadiusPolicy = VisualTransformPolicyType.Relative,
               ClippingMode = ClippingModeType.ClipToBoundingBox,
            };

            var title = new TextLabel() {
               HorizontalAlignment = HorizontalAlignment.Center,
               Padding = new Extents(35,0,20,0),
            };

            var view = new View()
            {
              Layout = new GridLayout()
              {
                Columns = 1,
                Rows = 1,
              },
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            Window.Instance.GetDefaultLayer().Add(windowMainView);
            windowMainView.Add(title);
            windowMainView.Add(view);

            galleryView = new ImageView()
            {
               WidthSpecification = LayoutParamPolicies.MatchParent,
               HeightSpecification = LayoutParamPolicies.MatchParent,
               ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "maldives.png",
               CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
               CornerRadiusPolicy = VisualTransformPolicyType.Relative,
               Margin = 15,
               FittingMode = FittingModeType.ShrinkToFit,
            };
            view.Add(galleryView);

            // Add Drop Target A
            dnd.AddListener(windowMainView, OnTargetAppDnDFuncA);
        }

        public void OnTargetAppDnDFuncA(View targetView, DragEvent dragEvent)
        {
            if (dragEvent.DragType == DragType.Enter)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target A [Enter]");
            }
            else if (dragEvent.DragType == DragType.Leave)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target A [Leave]");
            }
            else if (dragEvent.DragType == DragType.Move)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target A [Move]: " + dragEvent.Position.X + " " + dragEvent.Position.Y);
            }
            else if (dragEvent.DragType == DragType.Drop)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target A [Drop] MimeType: " +  dragEvent.MimeType + " Data: " + dragEvent.Data);
              galleryView.ResourceUrl = dragEvent.Data;
            }
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            CustomBorder customBorder = new CustomBorder("  Gallery");
            app = new Program("", new Size2D(400, 300), new Position2D(1100, 100), customBorder);
            app.Run(args);
        }
    }
}
