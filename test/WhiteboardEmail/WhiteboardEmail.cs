using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace WhiteboardEmail
{
    class Program : NUIApplication
    {
        class CustomBorder : DefaultBorder
        {
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
        ImageView emailView;
        TextEditor inputContent;
        DragAndDrop dnd;
    
        float fontScale = 1.1f;
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
               //Text = "E-mail",
               PointSize = 4 * fontScale,
               HorizontalAlignment = HorizontalAlignment.Center,
               Padding = new Extents(35,0,20,0),
            };

            Window.Instance.GetDefaultLayer().Add(windowMainView);
            windowMainView.Add(title);

            var labelSender = new TextLabel() {
            Text = "sender : samsung.kim@samsung.com",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Margin = new Extents(10,0,10,0),
            };

            windowMainView.Add(labelSender);

            var labelReceiver = new TextLabel() {
                Text = "receiver : samsung.shin@samsung.com",
                PointSize = 3 * fontScale,
                HorizontalAlignment = HorizontalAlignment.Begin,
                Margin = new Extents(10,0,10,0),
            };
            windowMainView.Add(labelReceiver);

            var labelTitle = new TextLabel() {
                Text = "title : DnD and Window Border!",
                PointSize = 3 * fontScale,
                HorizontalAlignment = HorizontalAlignment.Begin,
                Margin = new Extents(10,0,10,0),
            };
            windowMainView.Add(labelTitle);

            var menuView = new View()
            {
              Layout = new LinearLayout()
              {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.End,
                VerticalAlignment = VerticalAlignment.Center,
              },
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = 40,
            };
            var menuImage = new ImageView()
            {
              ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "addimage.png",
              WidthSpecification = 30,
              HeightSpecification = 30,
              Margin = new Extents(0,10,0,0),
            };
            var menuFile = new ImageView()
            {
              ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "file.png",
              WidthSpecification = 30,
              HeightSpecification = 30,
              Margin = new Extents(0,10,0,0),
            };
            var menuOption = new ImageView()
            {
              ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "send.png",
              WidthSpecification = 30,
              HeightSpecification = 30,
              Margin = new Extents(0,10,0,0),
            };

            menuView.Add(menuImage);
            menuView.Add(menuFile);
            menuView.Add(menuOption);
            windowMainView.Add(menuView);

            inputContent = new TextEditor()
            {
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = 150,
              BackgroundColor = new Color(1.0f, 0.9f, 0.8f, 0.3f),
              PointSize = 3 * fontScale,
              BorderlineWidth = 2.0f,
              BorderlineColor = new Color(1.0f, 0.4f, 0.0f, 1.0f),
              CornerRadius = new Vector4(0.1f, 0.1f, 0.1f, 0.1f),
              CornerRadiusPolicy = VisualTransformPolicyType.Relative,
              Margin = 10,
              LineWrapMode = LineWrapMode.Mixed,
            };
            windowMainView.Add(inputContent); 

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
              inputContent.Text = dragEvent.Data;
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
            CustomBorder customBorder = new CustomBorder("Email");
            app = new Program("", new Size2D(400, 350), new Position2D(1000, 550), customBorder);
            app.Run(args);
        }
    }
}
