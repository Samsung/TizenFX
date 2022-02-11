
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;


namespace Tizen.NUI.Samples
{
  public class BorderWindowTest2 : IExample
  {
    private Window win;
    private Window subWindowOne = null;
    private Window subWindowTwo = null;

    private static readonly string ResourcePath = "/home/puro/workspace/tizen/submit/TizenFX/src/Tizen.NUI/res/";

    private static readonly string DefaultMinimalizeIcon = ResourcePath + "minimalize.png";
    private static readonly string DefaultMaximalizeIcon = ResourcePath + "maximalize.png";
    private static readonly string DefaultPreviousIcon = ResourcePath + "smallwindow.png";
    private static readonly string DefaultCloseIcon = ResourcePath + "close.png";

    private static readonly string imagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/Dali/";


    class TestWindow : BorderWindowInterface
    {
        public override View CreateBorderView()
      {
            View rootView = base.CreateBorderView();
            rootView.CornerRadius = new Vector4(0, 0, 0.3f, 0.3f);
            rootView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;
            return rootView;
      }
      // public override View CreateBorderView()
      // {
      //       View rootView = new View()
      //       {
      //           WidthResizePolicy = ResizePolicyType.FillToParent,
      //           HeightResizePolicy = ResizePolicyType.FillToParent,
      //           BackgroundColor = Color.Red,
      //       };

      //       View borderView = new View()
      //       {
      //           Layout = new LinearLayout()
      //           {
      //               LinearOrientation = LinearLayout.Orientation.Horizontal,
      //           },
      //           WidthSpecification = LayoutParamPolicies.MatchParent,
      //           HeightSpecification = LayoutParamPolicies.MatchParent,
      //       };

      //       ImageView minimalizeIcon = new ImageView()
      //       {
      //           ResourceUrl = DefaultMinimalizeIcon,
      //       };

      //       ImageView maximalizeIcon = new ImageView()
      //       {
      //           ResourceUrl = DefaultMaximalizeIcon,
      //       };

      //       ImageView closeIcon = new ImageView()
      //       {
      //           ResourceUrl = DefaultCloseIcon,
      //       };

      //       borderView.Add(minimalizeIcon);
      //       borderView.Add(maximalizeIcon);
      //       borderView.Add(closeIcon);
      //       rootView.Add(borderView);

      //       minimalizeIcon.TouchEvent += OnMinTouched;
      //       maximalizeIcon.TouchEvent += OnMaxTouched;
      //       closeIcon.TouchEvent += OnCloseTouched;

      //       return rootView;
      // }
    }

    void CreateSubWindowOne()
    {
      if (subWindowOne == null)
      {
        subWindowOne = new Window("subwin1", new Rectangle(20, 20, 800, 800), true);
        TestWindow testWin = new TestWindow();
        // testWin.Height = 100;
        // testWin.MinSize = new Size2D(200, 200);
        subWindowOne.SetTransparency(true);
        subWindowOne.BackgroundColor = Color.Transparent;
        subWindowOne.EnableBorderWindow(testWin);

        var root = new ImageView()
        {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          ResourceUrl = imagePath+"background.jpg",
          CornerRadius = new Vector4(0.03f, 0.03f, 0, 0),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        subWindowOne.Add(root);

        TextLabel text = new TextLabel("Hello Tizen NUI World");
        text.HorizontalAlignment = HorizontalAlignment.Center;
        text.VerticalAlignment = VerticalAlignment.Center;
        text.TextColor = Color.Yellow;
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
        subWindowTwo = new Window("subwin1", new Rectangle(60, 20, 800, 800), true);
        TestWindow testWin = new TestWindow();
        // testWin.Height = 100;
        // testWin.MinSize = new Size2D(200, 200);
        subWindowTwo.SetTransparency(true);
        subWindowTwo.BackgroundColor = Color.Transparent;
        subWindowTwo.EnableBorderWindow(testWin);

        var root = new ImageView()
        {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          ResourceUrl = imagePath+"netflexbg.jpg",
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
          ResourceUrl = imagePath+"background1.jpg",
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
          ResourceUrl = imagePath+"background.jpg",
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
          ResourceUrl = imagePath+"netflex.png",
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
