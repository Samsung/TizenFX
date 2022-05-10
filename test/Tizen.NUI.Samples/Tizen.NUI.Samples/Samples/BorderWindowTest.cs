
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;


namespace Tizen.NUI.Samples
{
  public class BorderWindowTest : IExample
  {
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
        title = new TextLabel()
        {
          Text = "CustomBorder",
          Position = new Position(20, 0),
        };
        topView.Add(title);
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
        };

        maximalizeIcon = new ImageView()
        {
            ResourceUrl = MaximalizeIcon,
        };

        closeIcon = new ImageView()
        {
            ResourceUrl = CloseIcon,
        };

        leftCornerIcon = new ImageView()
        {
            ResourceUrl = LeftCornerIcon,
        };

        rightCornerIcon = new ImageView()
        {
          ResourceUrl = RightCornerIcon,
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
      }
      else
      {
        subWindowOne.Minimize(false);
      }
    }

    void CreateSubWindowTwo()
    {
      if (subWindowTwo == null)
      {
        IBorderInterface customBorder = new CustomBorder();
        subWindowTwo = new Window("subwin1", customBorder, new Rectangle(60, 20, 800, 800), false);

        var root = new View(){
          Layout = new LinearLayout()
          {
              LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
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
              LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
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
              LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
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
              LinearAlignment = LinearLayout.Alignment.Center,
              LinearOrientation = LinearLayout.Orientation.Vertical,
          }
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

        var customBorder = new View()
        {
          Size = new Size(150, 180),
          Layout = new LinearLayout()
          {
              LinearAlignment = LinearLayout.Alignment.Center,
              LinearOrientation = LinearLayout.Orientation.Vertical,
          }
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
