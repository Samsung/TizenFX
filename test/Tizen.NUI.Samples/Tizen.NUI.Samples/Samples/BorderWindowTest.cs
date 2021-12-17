
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
  public class BorderWindowTest : IExample
  {
    private Window win;
    private Window subWindow;
    void Initialize()
    {
        win = NUIApplication.GetDefaultWindow();
        win.WindowSize = new Size2D(500, 600);





        ContentPage page = new ContentPage()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent,
            HeightSpecification = LayoutParamPolicies.MatchParent,
            BackgroundColor = Color.Cyan,
        };

        page.AppBar = new AppBar()
        {
            Title = "     this is AppBar",
            WidthSpecification = 495,
            HeightSpecification = 100,
            BackgroundColor = Color.Yellow,
        };

        page.Content = new View()
        {
            BackgroundColor = Color.Blue,
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
            },
            WidthSpecification = LayoutParamPolicies.MatchParent,
            HeightSpecification = LayoutParamPolicies.MatchParent,
        };

        var content1 = new View()
        {
            BackgroundColor = Color.Magenta,
            WidthSpecification = LayoutParamPolicies.MatchParent,
            HeightSpecification = LayoutParamPolicies.MatchParent,
        };
        page.Content.Add(content1);

        var content2 = new View()
        {
            BackgroundColor = Color.Green,
            WidthSpecification = LayoutParamPolicies.MatchParent,
            HeightSpecification = LayoutParamPolicies.MatchParent,
        };
        page.Content.Add(content2);

        win.GetDefaultLayer().Add(page);

        Window.BorderStyle style = new Window.BorderStyle();

        subWindow = new Window("subwin1", style, new Rectangle(300, 300, 300, 300), false);
        subWindow.BackgroundColor = Color.Blue;
        View dummy = new View()
            {
                Size = new Size(100, 100),
                Position = new Position(50, 50),
                BackgroundColor = Color.Yellow,
            };
        subWindow.Add(dummy);
        // subWindow.EnableBorderWindow();

        subWindow.KeyEvent += OnKeyEvent;
    }

    public void OnKeyEvent(object sender, Window.KeyEventArgs e)
    {
      // win.WindowSize = new Size2D(500, 500);
      Tizen.Log.Error("NUI", $"OnKeyEvent===\n");
      //  win.EnableBorderWindowRootLayer(new Size2D(500, 500), new Position2D(0, 0));
      // win.EnableBorderWindow();
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

