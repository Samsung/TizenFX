
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
      private int width = 500;
      private bool hide = false;
      private View rootView;
      private View borderView;
      private TextLabel title;

      public CustomBorder() : base()
      {
        BorderHeight = 60;
      }

      public override void CreateBorderView(View rootView)
      {
          this.rootView = rootView;
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

          minimalizeIcon.TouchEvent += OnMinimizeIconTouched;
          maximalizeIcon.TouchEvent += OnMaximizeIconTouched;
          closeIcon.TouchEvent += OnCloseIconTouched;
          leftPadding.TouchEvent += OnLeftCornerIconTouched;
          rightPadding.TouchEvent += OnRightCornerIconTouched;
      }

      public override void OnCreated(View rootView)
      {
        base.OnCreated(rootView);
      }

      public override bool  OnCloseIconTouched(object sender, View.TouchEventArgs e)
      {
        base.OnCloseIconTouched(sender, e);
        return true;
      }

      public override bool  OnMinimizeIconTouched(object sender, View.TouchEventArgs e)
      {
        base.OnMinimizeIconTouched(sender, e);
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

      public override void Dispose()
      {
        base.Dispose();
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

        subWindowTwo.BackgroundColor = Color.Red;

        var root = new View(){
          Layout = new LinearLayout()
          {
              LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
          },
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          BackgroundColor = Color.Yellow,
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

        var imageViewA = new ImageView()
        {
          PositionUsesPivotPoint = true,
          PivotPoint = PivotPoint.BottomLeft,
          ParentOrigin = ParentOrigin.BottomLeft,
          Size = new Size(150, 150),
          ResourceUrl = imagePath + "gallery-large-9.jpg",
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
          ResourceUrl = imagePath + "gallery-large-5.jpg",
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
