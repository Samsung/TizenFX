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
           
    private int width = 300;
    private bool hide = false;
    private string title;
    private View borderView;
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
        ImageView galleryView;
        DragAndDrop dnd;
    
        float fontScale = 1.5f;
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            // Create DnD Instance
            dnd = DragAndDrop.Instance;

            //fopu

            Window.Instance.KeyEvent += OnKeyEvent;
            //Window.Instance.WindowPosition = new Position(700, 300); 
            //Window.Instance.WindowSize = new Size(500, 500); 
            Window.Instance.BackgroundColor = Color.White;

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
               //Text = "Gallery",
               PointSize = 4 * fontScale,
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
            CustomBorder customBorder = new CustomBorder("Gallery");
            app = new Program("", new Size2D(500, 500), new Position2D(700, 300), customBorder);
            app.Run(args);
        }
    }
}
