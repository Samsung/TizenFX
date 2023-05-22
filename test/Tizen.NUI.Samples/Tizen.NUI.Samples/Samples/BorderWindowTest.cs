
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;


namespace Tizen.NUI.Samples
{
  using log = Tizen.Log;
  public class BorderWindowTest : IExample
  {
    string tag = "NUITEST";
    private const string KEY_BACK = "XF86Back";
    private const string KEY_ESCAPE = "Escape";
    private const string KEY_NUM_1 = "1";
    private const string KEY_NUM_2 = "2";
    private const string KEY_NUM_3 = "3";
    private const string KEY_NUM_4 = "4";
    private const string KEY_NUM_5 = "5";
    private const string KEY_PARENT_ABOVE = "6";
    private const string KEY_PARENT_BELOW = "7";

    private Window win;
    private Window subWindowOne = null;
    private Window subWindowTwo = null;
    private static readonly string imagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/Dali/CubeTransitionEffect/";


    class CustomBorder : DefaultBorder
    {
      private static readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
      private static readonly string MinimalizeIcon = ResourcePath + "/images/minimalize.png";
      private static readonly string MaximalizeIcon = ResourcePath + "/images/maximalize.png";
      private static readonly string RestoreIcon = ResourcePath + "/images/smallwindow.png";
      private static readonly string CloseIcon = ResourcePath + "/images/close.png";
      private static readonly string LeftCornerIcon = ResourcePath + "/images/leftCorner.png";
      private static readonly string RightCornerIcon = ResourcePath + "/images/rightCorner.png";

      private int width = 500;
      private bool hide = false;
      private View borderView;
      private TextLabel title;

      private ImageView minimalizeIcon;
      private ImageView maximalizeIcon;
      private ImageView closeIcon;
      private ImageView leftCornerIcon;
      private ImageView rightCornerIcon;

      private Rectangle preWinPositonSize;

      public CustomBorder() : base()
      {
        BorderHeight = 50;
        OverlayMode = true;
        BorderLineThickness = 0;
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
          VerticalAlignment = VerticalAlignment.Center,
          CellPadding = new Size2D(20, 20),
        };
        title = new TextLabel()
        {
          Text = "CustomBorder",
        };
        
        var button = new Button()
        {
          Text = "AlwaysOnTop",
        };
        button.Clicked += (s, e) =>
        {
          BorderWindow.EnableFloatingMode(true);
        };
        topView.Add(title);
        topView.Add(button);
        return true;
      }

      public override bool CreateBottomBorderView(View bottomView)
      {
        if (bottomView == null)
        {
            return false;
        }
        bottomView.Layout = new RelativeLayout();

        minimalizeIcon = new ImageView()
        {
            ResourceUrl = MinimalizeIcon,
            AccessibilityHighlightable = true,
        };

        maximalizeIcon = new ImageView()
        {
            ResourceUrl = MaximalizeIcon,
            AccessibilityHighlightable = true,
        };

        closeIcon = new ImageView()
        {
            ResourceUrl = CloseIcon,
            AccessibilityHighlightable = true,
        };

        leftCornerIcon = new ImageView()
        {
            ResourceUrl = LeftCornerIcon,
            AccessibilityHighlightable = true,
        };

        rightCornerIcon = new ImageView()
        {
            ResourceUrl = RightCornerIcon,
            AccessibilityHighlightable = true,
        };

        RelativeLayout.SetRightTarget(minimalizeIcon, maximalizeIcon);
        RelativeLayout.SetRightRelativeOffset(minimalizeIcon, 0.0f);
        RelativeLayout.SetHorizontalAlignment(minimalizeIcon, RelativeLayout.Alignment.End);
        RelativeLayout.SetRightTarget(maximalizeIcon, closeIcon);
        RelativeLayout.SetRightRelativeOffset(maximalizeIcon, 0.0f);
        RelativeLayout.SetHorizontalAlignment(maximalizeIcon, RelativeLayout.Alignment.End);
        RelativeLayout.SetRightTarget(closeIcon, rightCornerIcon);
        RelativeLayout.SetRightRelativeOffset(closeIcon, 0.0f);
        RelativeLayout.SetHorizontalAlignment(closeIcon, RelativeLayout.Alignment.End);
        RelativeLayout.SetRightRelativeOffset(rightCornerIcon, 1.0f);
        RelativeLayout.SetHorizontalAlignment(rightCornerIcon, RelativeLayout.Alignment.End);
        bottomView.Add(leftCornerIcon);
        bottomView.Add(minimalizeIcon);
        bottomView.Add(maximalizeIcon);
        bottomView.Add(closeIcon);
        bottomView.Add(rightCornerIcon);


        minimalizeIcon.TouchEvent += OnMinimizeIconTouched;
        maximalizeIcon.TouchEvent += OnMaximizeIconTouched;
        closeIcon.TouchEvent += OnCloseIconTouched;
        leftCornerIcon.TouchEvent += OnLeftBottomCornerIconTouched;
        rightCornerIcon.TouchEvent += OnRightBottomCornerIconTouched;

        minimalizeIcon.AccessibilityActivated += (s, e) =>
        {
            MinimizeBorderWindow();
        };
        maximalizeIcon.AccessibilityActivated += (s, e) =>
        {
            MaximizeBorderWindow();
        };
        closeIcon.AccessibilityActivated += (s, e) =>
        {
            CloseBorderWindow();
        };

        minimalizeIcon.AccessibilityNameRequested += (s, e) =>
        {
            e.Name = "Minimize";
        };
        maximalizeIcon.AccessibilityNameRequested += (s, e) =>
        {
            e.Name = "Maximize";
        };
        closeIcon.AccessibilityNameRequested += (s, e) =>
        {
            e.Name = "Close";
        };
        leftCornerIcon.AccessibilityNameRequested += (s, e) =>
        {
            e.Name = "Resize";
        };
        rightCornerIcon.AccessibilityNameRequested += (s, e) =>
        {
            e.Name = "Resize";
        };

        minimalizeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
        maximalizeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
        closeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
        leftCornerIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
        rightCornerIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);

        return true;
      }

      public override void CreateBorderView(View borderView)
      {
          this.borderView = borderView;
          borderView.CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f);
          borderView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;
          borderView.BackgroundColor = new Color(1, 1, 1, 0.3f);
      }

      public override void OnCreated(View borderView)
      {
        base.OnCreated(borderView);
        UpdateIcons();
      }

      public override bool OnCloseIconTouched(object sender, View.TouchEventArgs e)
      {
        base.OnCloseIconTouched(sender, e);
        return true;
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
          BorderWindow.WindowPositionSize = new Rectangle(preWinPositonSize.X, preWinPositonSize.Y, 500, 0);
        }
        return true;
      }

      public override void OnRequestResize()
      {
        if (borderView != null)
        {
          borderView.BackgroundColor = new Color(0, 1, 0, 0.3f); // 보더의 배경을 변경할 수 있습니다.
        }
      }

      public override void OnResized(int width, int height)
      {
        if (borderView != null)
        {
          if (this.width > width && hide == false)
          {
            title.Hide();
            hide = true;
          }
          else if (this.width < width && hide == true)
          {
            title.Show();
            hide = false;
          }
          borderView.BackgroundColor = new Color(1, 1, 1, 0.3f); //  리사이즈가 끝나면 보더의 색깔은 원래대로 돌려놓습니다.
          base.OnResized(width, height);
          UpdateIcons();
        }
      }

      private void UpdateIcons()
      {
        if (BorderWindow != null && borderView != null)
        {
            if (BorderWindow.IsMaximized() == true)
            {
                if (maximalizeIcon != null)
                {
                    maximalizeIcon.ResourceUrl = RestoreIcon;
                }
            }
            else
            {
                if (maximalizeIcon != null)
                {
                    maximalizeIcon.ResourceUrl = MaximalizeIcon;
                }
            }
        }
      }

    }


    private void OnKeyEvent(object sender, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down)
        {
            log.Debug(tag, $"key down! key={e.Key.KeyPressedName}");

            switch (e.Key.KeyPressedName)
            {
                case KEY_BACK:
                case KEY_ESCAPE:
                    break;

                case KEY_NUM_1:
                    subWindowOne.WindowPosition = new Position2D(10, 20);
                    break;

                case KEY_NUM_2:
                    subWindowOne.WindowPosition = new Position2D(-10, 20);
                    break;

                case KEY_NUM_3:

                    break;

                case KEY_NUM_4:
                    break;

                case KEY_NUM_5:
                    break;

                case KEY_PARENT_ABOVE:
                    break;

                case KEY_PARENT_BELOW:
                    break;

                default:
                    log.Debug(tag, $"no test!");
                    break;
            }
        }
    }

    private void OnWindowMoved(object sender, WindowMovedEventArgs e)
    {
        Position2D position = e.WindowPosition;
        log.Fatal(tag, $"OnWindowMoved() called!, x:{position.X}, y:{position.Y}");
    }

    private void OnWindowMoveCompleted(object sender, WindowMoveCompletedEventArgs e)
    {
        Position2D position = e.WindowCompletedPosition;
        log.Fatal(tag, $"OnWindowMoveCompleted() called!, x:{position.X}, y:{position.Y}");
    }

    private void OnWindowResizeCompleted(object sender, WindowResizeCompletedEventArgs e)
    {
        Size2D size = e.WindowCompletedSize;
        log.Fatal(tag, $"OnWindowResizeCompleted() called!, width:{size.Width}, height:{size.Height}");
    }

    void CreateSubWindowOne()
    {
      if (subWindowOne == null)
      {
        subWindowOne = new Window("subwin1", null, new Rectangle(20, 20, 800, 800), false);

        var root = new ImageView()
        {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          ResourceUrl = imagePath + "gallery-large-9.jpg",
          CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        subWindowOne.Add(root);

        TextLabel text = new TextLabel("Hello Tizen NUI World");
        text.HorizontalAlignment = HorizontalAlignment.Center;
        text.VerticalAlignment = VerticalAlignment.Center;
        text.TextColor = Color.CornflowerBlue;
        text.HeightResizePolicy = ResizePolicyType.FillToParent;
        text.WidthResizePolicy = ResizePolicyType.FillToParent;
        root.Add(text);

        Animation animation = new Animation(2000);
        animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
        animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
        animation.Looping = true;
        animation.Play();

        subWindowOne.KeyEvent += OnKeyEvent;
        subWindowOne.Moved += OnWindowMoved;
        subWindowOne.MoveCompleted += OnWindowMoveCompleted;
        subWindowOne.ResizeCompleted += OnWindowResizeCompleted;
      }
      else
      {
        subWindowOne.Minimize(false);
      }
    }

    private void OnWindowMoved2(object sender, WindowMovedEventArgs e)
    {
        Position2D position = e.WindowPosition;
        log.Fatal(tag, $"OnWindowMoved2() called!, x:{position.X}, y:{position.Y}");
    }

    private void OnWindowMoveCompleted2(object sender, WindowMoveCompletedEventArgs e)
    {
        Position2D position = e.WindowCompletedPosition;
        log.Fatal(tag, $"OnWindowMoveCompleted2() called!, x:{position.X}, y:{position.Y}");
    }

    private void OnWindowResizeCompleted2(object sender, WindowResizeCompletedEventArgs e)
    {
        Size2D size = e.WindowCompletedSize;
        log.Fatal(tag, $"OnWindowResizeCompleted2() called!, width:{size.Width}, height:{size.Height}");
    }

    void CreateSubWindowTwo()
    {
      if (subWindowTwo == null)
      {
        CustomBorder customBorder = new CustomBorder();
        subWindowTwo = new Window("subwin1", customBorder, new Rectangle(60, 20, 800, 800), false);
        subWindowTwo.InterceptTouchEvent += (s, e) => 
        {
            Tizen.Log.Error("NUI", $"subWindowTwo.InterceptTouchEvent\n");
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
              customBorder.OverlayBorderShow();
            }
            return false;
        };

        var root = new View()
        {
          Layout = new LinearLayout()
          {
            HorizontalAlignment = HorizontalAlignment.Center,
          },
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          BackgroundColor = Color.Brown,
        };

        var image = new ImageView()
        {
          Size = new Size(300, 300),
          ResourceUrl = imagePath + "gallery-large-5.jpg",
          CornerRadius = new Vector4(0.03f, 0.03f, 0, 0),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        root.Add(image);
        subWindowTwo.Add(root);

        subWindowTwo.Moved += OnWindowMoved2;
        subWindowTwo.MoveCompleted += OnWindowMoveCompleted2;
        subWindowTwo.ResizeCompleted += OnWindowResizeCompleted2;
      }
      else
      {
        subWindowTwo.Minimize(false);
      }
    }



    void Initialize()
    {
        win = NUIApplication.GetDefaultWindow();

        var root = new ImageView()
        {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          ResourceUrl = imagePath + "gallery-large-14.jpg",
          Layout = new LinearLayout()
          {
              HorizontalAlignment = HorizontalAlignment.Center,
              LinearOrientation = LinearLayout.Orientation.Horizontal,
              CellPadding = new Size(10, 10),
          }
        };
        win.Add(root);


        var appFunctionList = new View()
        {
          PositionUsesPivotPoint = true,
          PivotPoint = PivotPoint.BottomLeft,
          ParentOrigin = ParentOrigin.BottomLeft,
          BackgroundColor = new Color(0, 1, 1, 0.5f),
          Size = new Size(500, 200),
          CornerRadius = 0.3f,
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          Layout = new LinearLayout()
          {
              HorizontalAlignment = HorizontalAlignment.Center,
              LinearOrientation = LinearLayout.Orientation.Horizontal,
              CellPadding = new Size(10, 10),
              Padding = new Extents(10, 10, 10 , 10),
          }
        };
        root.Add(appFunctionList);

        var defaultBorder = new View()
        {
          Size = new Size(150, 180),
          Layout = new LinearLayout()
          {
              HorizontalAlignment = HorizontalAlignment.Center,
              VerticalAlignment = VerticalAlignment.Center,
              LinearOrientation = LinearLayout.Orientation.Vertical,
          },
          AccessibilityHighlightable = true,
        };

        var imageViewA = new ImageView()
        {
          Size = new Size(150, 150),
          ResourceUrl = imagePath + "gallery-large-9.jpg",
          CornerRadius = 0.3f,
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };

        var textViewA = new TextLabel()
        {
          Text = "Default",
        };

        defaultBorder.Add(imageViewA);
        defaultBorder.Add(textViewA);
        appFunctionList.Add(defaultBorder);
        defaultBorder.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateSubWindowOne();
          }
          return true;
        };
        defaultBorder.AccessibilityActivated += (s, e) =>
        {
            CreateSubWindowOne();
        };

        var customBorder = new View()
        {
          Size = new Size(150, 180),
          Layout = new LinearLayout()
          {
              HorizontalAlignment = HorizontalAlignment.Center,
              VerticalAlignment = VerticalAlignment.Center,
              LinearOrientation = LinearLayout.Orientation.Vertical,
          },
          AccessibilityHighlightable = true,
        };

        var imageViewB = new ImageView()
        {
          Size = new Size(150, 150),
          ResourceUrl = imagePath + "gallery-large-5.jpg",
          CornerRadius = 0.3f,
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        var textViewB = new TextLabel()
        {
          Text = "Custom",
        };

        customBorder.Add(imageViewB);
        customBorder.Add(textViewB);
        appFunctionList.Add(customBorder);
        customBorder.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateSubWindowTwo();
          }
          return true;
        };
        customBorder.AccessibilityActivated += (s, e) =>
        {
            CreateSubWindowTwo();
        };
    }

    public void Activate()
    {
      Initialize();
    }

    public void Deactivate()
    {
    }


  }
}
