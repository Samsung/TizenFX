
// using System;
// using Tizen.NUI;
// using Tizen.NUI.BaseComponents;
// using Tizen.NUI.Components;

// namespace Tizen.NUI.Samples
// {
//   public class BorderWindowTest : IExample
//   {
//     private Window win;
//     private Window subWindow;
//     void Initialize()
//     {
//         win = NUIApplication.GetDefaultWindow();
//         win.WindowSize = new Size2D(500, 400);
//         win.BackgroundColor = Color.Blue;
//         win.TouchEvent += (s, e) =>
//         {
//             Tizen.Log.Error("gab_test", $"win.TouchEvent\n");
//             win.RequestMoveToServer();
//         };

//         TextLabel test1 = new TextLabel()
//         {
//             Text = "800x600",
//             BackgroundColor = Color.Yellow,
//             Size = new Size(100, 50),
//             Position = new Position(50, 50),

//         };
//         win.Add(test1);
//         test1.TouchEvent += (s, e) =>
//         {
//             Tizen.Log.Error("gab_test", $"test1.TouchEvent\n");
//             win.WindowSize = new Size2D(800, 600);
//             return true;
//         };

//         TextLabel test2 = new TextLabel()
//         {
//             Text = "300x300",
//             BackgroundColor = Color.Yellow,
//             Size = new Size(100, 50),
//             Position = new Position(50, 150),

//         };
//         win.Add(test2);
//         test2.TouchEvent += (s, e) =>
//         {
//             Tizen.Log.Error("gab_test", $"test2.TouchEvent\n");
//             win.WindowSize = new Size2D(300, 300);
//             return true;
//         };

//         TextLabel test3 = new TextLabel()
//         {
//             Text = "RequestResize",
//             BackgroundColor = Color.Yellow,
//             Size = new Size(200, 200),
//             Position = new Position(100, 200),

//         };
//         win.Add(test3);
//         test3.TouchEvent += (s, e) =>
//         {
//             Tizen.Log.Error("gab_test", $"test3.TouchEvent\n");
//             win.RequestResizeToServer(Window.ResizeDirection.BottomLeft);
//             return true;
//         };

//         // Window.BorderStyle style = new Window.BorderStyle();
//         // win.EnableBorderWindow(style);

//         // TextLabel text = new TextLabel("Hello Tizen NUI World");
//         // text.HorizontalAlignment = HorizontalAlignment.Center;
//         // text.VerticalAlignment = VerticalAlignment.Center;
//         // text.TextColor = Color.Blue;
//         // text.PointSize = 12.0f;
//         // text.HeightResizePolicy = ResizePolicyType.FillToParent;
//         // text.WidthResizePolicy = ResizePolicyType.FillToParent;
//         // win.Add(text);

//         // Animation animation = new Animation(2000);
//         // animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
//         // animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
//         // animation.Looping = true;
//         // animation.Play();

//         // ContentPage page = new ContentPage()
//         // {
//         //     WidthSpecification = LayoutParamPolicies.MatchParent,
//         //     HeightSpecification = LayoutParamPolicies.MatchParent,
//         //     BackgroundColor = Color.Cyan,

//         // };

//         // page.AppBar = new AppBar()
//         // {
//         //     Title = "     this is AppBar",
//         //     WidthSpecification = 495,
//         //     HeightSpecification = 100,
//         //     BackgroundColor = Color.Yellow,
//         // };

//         // page.Content = new View()
//         // {
//         //     BackgroundColor = Color.Blue,
//         //     Layout = new LinearLayout()
//         //     {
//         //         LinearOrientation = LinearLayout.Orientation.Horizontal,
//         //     },
//         //     WidthSpecification = LayoutParamPolicies.MatchParent,
//         //     HeightSpecification = LayoutParamPolicies.MatchParent,
//         // };

//         // var content1 = new View()
//         // {
//         //     BackgroundColor = Color.Magenta,
//         //     WidthSpecification = LayoutParamPolicies.MatchParent,
//         //     HeightSpecification = LayoutParamPolicies.MatchParent,
//         // };
//         // page.Content.Add(content1);

//         // var content2 = new View()
//         // {
//         //     BackgroundColor = Color.Green,
//         //     WidthSpecification = LayoutParamPolicies.MatchParent,
//         //     HeightSpecification = LayoutParamPolicies.MatchParent,
//         // };
//         // page.Content.Add(content2);

//         // win.GetDefaultLayer().Add(page);

//         // Window.BorderStyle style1 = new Window.BorderStyle();
//         // subWindow = new Window("subwin1", style1, new Rectangle(20, 20, 300, 300), false);
//         // subWindow.BackgroundColor = Color.Red;
//         // View dummy = new View()
//         //     {
//         //         Size = new Size(100, 100),
//         //         Position = new Position(50, 50),
//         //         BackgroundColor = Color.Yellow,
//         //     };
//         // LongPressGestureDetector detector = new LongPressGestureDetector();
//         // detector.Attach(dummy);
//         // detector.Detected  += (s, e) =>
//         // {
//         //     Tizen.Log.Error("NUI", $"LongPressGestureDetector\n");
//         //     win.WindowSize -= new Size2D(10, 10);

//         // };

//         // subWindow.Add(dummy);

//         // // subWindow.KeyEvent += OnKeyEvent;
//     }

//     public void OnKeyEvent(object sender, Window.KeyEventArgs e)
//     {
//       // win.WindowSize = new Size2D(500, 500);
//       Tizen.Log.Error("NUI", $"OnKeyEvent===\n");
//     }

//     public void Activate()
//     {
//       Initialize();
//     }

//     public void Deactivate()
//     {
//     }

//   }
// }
