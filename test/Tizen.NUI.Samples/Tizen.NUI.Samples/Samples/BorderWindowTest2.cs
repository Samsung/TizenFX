
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
  public class BorderWindowTest2 : IExample
  {
    private Window win;

    private static readonly string ResourcePath = "/home/puro/workspace/tizen/submit/TizenFX/src/Tizen.NUI/res/";

    private static readonly string DefaultMinimalizeIcon = ResourcePath + "minimalize.png";
    private static readonly string DefaultMaximalizeIcon = ResourcePath + "maximalize.png";
    private static readonly string DefaultPreviousIcon = ResourcePath + "smallwindow.png";
    private static readonly string DefaultCloseIcon = ResourcePath + "close.png";


    class TestWindow : BorderWindowInterface
    {
      public override View CreateBorderView()
      {
            View rootView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Red,
            };

            View borderView = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            ImageView minimalizeIcon = new ImageView()
            {
                ResourceUrl = DefaultMinimalizeIcon,
            };

            ImageView maximalizeIcon = new ImageView()
            {
                ResourceUrl = DefaultMaximalizeIcon,
            };

            ImageView closeIcon = new ImageView()
            {
                ResourceUrl = DefaultCloseIcon,
            };

            borderView.Add(minimalizeIcon);
            borderView.Add(maximalizeIcon);
            borderView.Add(closeIcon);
            rootView.Add(borderView);

            minimalizeIcon.TouchEvent += OnMinTouched;
            maximalizeIcon.TouchEvent += OnMaxTouched;
            closeIcon.TouchEvent += OnCloseTouched;

            return rootView;
      }
    }

    void CreateDefaultSubWindow()
    {
        Window subWindow = new Window("subwin1", new Rectangle(20, 20, 700, 400), false);
        TestWindow testWin = new TestWindow();
        testWin.Height = 100;
        subWindow.EnableBorderWindow(testWin);

        TextLabel text = new TextLabel("Hello Tizen NUI World");
        text.HorizontalAlignment = HorizontalAlignment.Center;
        text.VerticalAlignment = VerticalAlignment.Center;
        text.TextColor = Color.Yellow;
        text.HeightResizePolicy = ResizePolicyType.FillToParent;
        text.WidthResizePolicy = ResizePolicyType.FillToParent;
        subWindow.Add(text);

        Animation animation = new Animation(2000);
        animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
        animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
        animation.Looping = true;
        animation.Play();
    }



    void Initialize()
    {
        win = NUIApplication.GetDefaultWindow();
        // TestWindow testWindow = new TestWindow();
        // testWindow = (TestWindow)win;
        win.BackgroundColor = new Vector4(0.5f, 0.1f, 0.5f, 1);


        TextLabel defaultView = new TextLabel()
        {
            BackgroundColor = Color.Blue,
            Text = "Create Default SubWindow",
            Size = new Size(400, 50),
            Position = new Position(50, 50),
        };
        win.Add(defaultView);
        defaultView.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateDefaultSubWindow();
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
