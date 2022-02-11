
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


    class TestWindow : DefaultBorder
    {
      private int width = 500;
      private bool hide = false;
      private View rootView;
      private View borderView;
      private TextLabel title;

      public override void CreateBorderView(View rootView)
      {
          this.rootView = rootView;
          rootView.BackgroundColor = new Color(1, 1, 1, 0.3f);
          rootView.CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f);
          rootView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;

          borderView = new View()
          {
              Layout = new LinearLayout()
              {
                  LinearAlignment = LinearLayout.Alignment.End,
                  LinearOrientation = LinearLayout.Orientation.Horizontal,
              },
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = LayoutParamPolicies.MatchParent,
          };
          title = new TextLabel()
          {
            Text = "CustomBorder",
            Size = new Size(300, 50),
            Position = new Position(60, 0),
            PositionUsesPivotPoint = true,
            PivotPoint = PivotPoint.BottomLeft,
            ParentOrigin = ParentOrigin.BottomLeft,
          };

          var minimalizeIcon = new Button()
          {
              Text = "m",
              PositionUsesPivotPoint = true,
              PivotPoint = PivotPoint.BottomLeft,
              ParentOrigin = ParentOrigin.BottomLeft,
              Size = new Size(50, 50),
          };

          var maximalizeIcon = new Button()
          {
              Text = "M",
              PositionUsesPivotPoint = true,
              PivotPoint = PivotPoint.BottomLeft,
              ParentOrigin = ParentOrigin.BottomLeft,
              Size = new Size(50, 50),
          };

          var closeIcon = new Button()
          {
              Text = "C",
              PositionUsesPivotPoint = true,
              PivotPoint = PivotPoint.BottomLeft,
              ParentOrigin = ParentOrigin.BottomLeft,
              Size = new Size(50, 50),
          };


          var leftPadding = new View()
          {
              PositionUsesPivotPoint = true,
              PivotPoint = PivotPoint.BottomLeft,
              ParentOrigin = ParentOrigin.BottomLeft,
              Size = new Size(50, 50),
          };

          var rightPadding = new View()
          {
              PositionUsesPivotPoint = true,
              PivotPoint = PivotPoint.BottomLeft,
              ParentOrigin = ParentOrigin.BottomLeft,
              Size = new Size(50, 50),
          };

          rootView.Add(leftPadding);
          rootView.Add(title);
          borderView.Add(minimalizeIcon);
          borderView.Add(maximalizeIcon);
          borderView.Add(closeIcon);
          borderView.Add(rightPadding);
          rootView.Add(borderView);

          minimalizeIcon.TouchEvent += OnMinTouched;
          maximalizeIcon.TouchEvent += OnMaxTouched;
          closeIcon.TouchEvent += OnCloseTouched;
          leftPadding.TouchEvent += OnLeftCornerTouched;
          rightPadding.TouchEvent += OnRightCornerTouched;
      }

      public override void OnCreated(View rootView)
      {
        base.OnCreated(rootView);
      }

      public override bool  OnCloseTouched(object sender, View.TouchEventArgs e)
      {
        base.OnCloseTouched(sender, e);
        return true;
      }

      public override bool  OnMinTouched(object sender, View.TouchEventArgs e)
      {
        base.OnMinTouched(sender, e);
        return true;
      }

      public override void OnResized(int width, int height)
      {
        if (rootView != null)
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
          base.OnResized(width, height);
        }
      }

      public override uint GetBorderLineThickness()
      {
        return base.GetBorderLineThickness();
      }

      public override uint GetTouchThickness()
      {
        return base.GetTouchThickness();
      }

      public override uint GetBorderHeight()
      {
        return base.GetBorderHeight();
      }

      public override Size2D GetMinSize()
      {
        return base.GetMinSize();
      }

      public override Size2D GetMaxSize()
      {
        return base.GetMaxSize();
      }

      public override void SetWindow(Window window)
      {
        base.SetWindow(window);
      }

      public override Window GetWindow()
      {
        return base.GetWindow();
      }

      public override void Dispose()
      {
        base.Dispose();
      }

    }

    void CreateSubWindowOne()
    {
      if (subWindowOne == null)
      {
        subWindowOne = new Window("subwin1", new Rectangle(20, 20, 800, 800), false);
        subWindowOne.EnableBorderWindow();

        var root = new ImageView()
        {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbfood.png",
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
        subWindowTwo = new Window("subwin1", new Rectangle(60, 20, 800, 800), false);
        TestWindow testWin = new TestWindow();
        subWindowTwo.EnableBorderWindow(testWin);

        var root = new ImageView()
        {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "maldives.png",
          CornerRadius = new Vector4(0.03f, 0.03f, 0, 0),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
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
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "background.png",
          Layout = new LinearLayout()
          {
              LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
              LinearOrientation = LinearLayout.Orientation.Horizontal,
              CellPadding = new Size(10, 10),
          }


        };
        win.Add(root);

        var imageViewA = new ImageView()
        {
          PositionUsesPivotPoint = true,
          PivotPoint = PivotPoint.BottomLeft,
          ParentOrigin = ParentOrigin.BottomLeft,
          Size = new Size(150, 150),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbfood.png",
          CornerRadius = 0.3f,
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        root.Add(imageViewA);
        imageViewA.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateSubWindowOne();
          }
          return true;
        };

        var imageViewB = new ImageView()
        {
          PositionUsesPivotPoint = true,
          PivotPoint = PivotPoint.BottomLeft,
          ParentOrigin = ParentOrigin.BottomLeft,
          Size = new Size(150, 150),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "maldives.png",
          CornerRadius = 0.3f,
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        root.Add(imageViewB);
        imageViewB.TouchEvent += (s, e) =>
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
