
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
  public class BorderWindowTest : IExample
  {
    private Window win;

    private static readonly string ResourcePath = "/home/puro/workspace/tizen/submit/TizenFX/src/Tizen.NUI/res/";

    private static readonly string DefaultMinimalizeIcon = ResourcePath + "minimalize.png";
    private static readonly string DefaultMaximalizeIcon = ResourcePath + "maximalize.png";
    private static readonly string DefaultPreviousIcon = ResourcePath + "smallwindow.png";
    private static readonly string DefaultCloseIcon = ResourcePath + "close.png";

    void CreateDefaultSubWindow()
    {
        var subWindow = new Window("subwin1", new Rectangle(20, 20, 700, 400), false);
        subWindow.EnableBorderWindow();
        // subWindow.BackgroundColor = Color.White;


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

    void CreateCustomSubWindow()
    {
        var subWindow = new Window("subwin1", new Rectangle(20, 20, 700, 400), false);

        TextLabel title = new TextLabel
        {
            Text = "Custom1",
            TextColor = Color.Yellow,
        };

        var customView = new View()
        {
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                // LinearAlignment = LinearLayout.Alignment.CenterVertical,
            },
            WidthSpecification = LayoutParamPolicies.MatchParent,
            HeightSpecification = LayoutParamPolicies.MatchParent,
            BackgroundColor = Color.Red,
        };

        ImageView min = new ImageView()
        {
            ResourceUrl = DefaultMinimalizeIcon,
        };

        ImageView max = new ImageView()
        {
            ResourceUrl = DefaultMaximalizeIcon,
        };

        ImageView close = new ImageView()
        {
            ResourceUrl = DefaultCloseIcon,
        };

        customView.Add(title);
        customView.Add(min);
        customView.Add(max);
        customView.Add(close);

        Window.BorderStyle style = new Window.BorderStyle();
        style.BorderView = customView;
        style.MinimalizeIcon = min;
        style.MaximalizeIcon = max;
        style.CloseIcon = close;

        subWindow.EnableBorderWindow(style);


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

        TextLabel customView = new TextLabel()
        {
            BackgroundColor = Color.Green,
            Text = "Create Custom SubWindow",
            Size = new Size(400, 50),
            Position = new Position(50, 150),
        };
        win.Add(customView);
        customView.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateCustomSubWindow();
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
