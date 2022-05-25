using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace WhiteboardMyApps
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
        View gridView;
        DragAndDrop dnd;
    
        float fontScale = 4.0f;
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        View CreateItem(string file, string name)
        {
            var itemView = new View()
            {
                WidthSpecification = 151,
                HeightSpecification = 151,
                BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "frame.png",
                Layout = new LinearLayout()
                {
                  LinearOrientation = LinearLayout.Orientation.Vertical,
                  HorizontalAlignment = HorizontalAlignment.Center,
                  VerticalAlignment = VerticalAlignment.Center,
                },
            };
            itemView.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                  itemView.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "frame.png";
                }
                else if (e.Touch.GetState(0) == PointStateType.Down)
                {
                  itemView.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "framep.png";
                }
                return true;
            };

            var child = new ImageView() {
                WidthSpecification = 122,
                HeightSpecification = 102,
                ResourceUrl = file,
            };

            var itemName = new TextLabel() {
                Text = name,
                PointSize = 3 * fontScale,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin =  new Extents(0, 0, 2, 2),
            };

            itemView.Add(child);
            itemView.Add(itemName);

            GridLayout.SetHorizontalStretch(itemView, GridLayout.StretchFlags.Expand);
            GridLayout.SetVerticalStretch(itemView, GridLayout.StretchFlags.Expand);
            GridLayout.SetHorizontalAlignment(itemView, GridLayout.Alignment.Center);
            GridLayout.SetVerticalAlignment(itemView, GridLayout.Alignment.Center);

            return itemView;
        }

        void Initialize()
        {
            // Create DnD Instance
            dnd = DragAndDrop.Instance;

            Window.Instance.KeyEvent += OnKeyEvent;
            //Window.Instance.WindowPosition = new Position(1000, 400); 
            //Window.Instance.WindowSize = new Size(500, 500); 
            //Window.Instance.BackgroundColor = Color.White;

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
               //Text = "My apps",
               PointSize = 4 * fontScale,
               HorizontalAlignment = HorizontalAlignment.Center,
               Padding = new Extents(35,0,20,0),
            };

            gridView = new View()
            {
              Layout = new GridLayout()
              {
                Columns = 3,
                Rows = 1,
              },
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            Window.Instance.GetDefaultLayer().Add(windowMainView);
            windowMainView.Add(title);
            windowMainView.Add(gridView);

            var faceBookItem = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "facebook.png", "facebook");
            gridView.Add(faceBookItem);

            var spotifyItem = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "spoti.png", "spotify");
            gridView.Add(spotifyItem);
        
            var instagramItem = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "instagram.png", "instagram");
            gridView.Add(instagramItem);

            var soundCloudItem = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "soundcloud.png", "soundcloud");
            gridView.Add(soundCloudItem);

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
              string[] itemData = dragEvent.Data.Split(',');
              var itemView = CreateItem(itemData[0], itemData[1]);
              gridView.Add(itemView);
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
            CustomBorder customBorder = new CustomBorder(" My apps");
            app = new Program("", new Size2D(500, 350), new Position2D(1000, 250), customBorder);
            app.Run(args);
        }
    }
}
