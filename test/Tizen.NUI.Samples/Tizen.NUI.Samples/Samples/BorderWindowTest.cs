
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
    private VideoView videoView = null;
    private static readonly string imagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/Dali/";
    private static readonly string videoPath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "v.mp4";


    class TestWindow : BorderWindowInterface
    {

      private VideoView videoView = null;
      private PinchGestureDetector winPinchGestureDetector = null;

      public override void CreateBorderView(View rootView)
      {
            // rootView.BackgroundColor = new Color(1, 0, 0, 0.3f);
            rootView.CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f);
            rootView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;
            // rootView.Layout = new LinearLayout()
            // {
            //     LinearOrientation = LinearLayout.Orientation.Horizontal,
            // };
            // rootView.WidthSpecification = LayoutParamPolicies.MatchParent;
            // rootView.HeightSpecification = LayoutParamPolicies.MatchParent;


            View borderView = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearAlignment = LinearLayout.Alignment.End,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            var title = new TextLabel()
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

            var play = new Button()
            {
                Text = "p",
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.BottomLeft,
                ParentOrigin = ParentOrigin.BottomLeft,
                Size = new Size(50, 50),
            };
            play.TouchEvent += (s, e) =>
            {
              if (e.Touch.GetState(0) == PointStateType.Down)
              {
                if (videoView != null)
                {
                  videoView.Play();
                }
              }

              return true;
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
            borderView.Add(play);
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

            winPinchGestureDetector = new PinchGestureDetector();
            winPinchGestureDetector.Attach(rootView);
            float preScale = 1;
            winPinchGestureDetector.Detected += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"winPinchGestureDetector {e.PinchGesture.Scale}, {e.PinchGesture.State}\n");
                if (e.PinchGesture.State == Gesture.StateType.Started)
                {
                    preScale = 1;
                }
                else if (e.PinchGesture.State == Gesture.StateType.Finished || e.PinchGesture.State == Gesture.StateType.Cancelled)
                {
                  Tizen.Log.Error("NUI", $"winPinchGestureDetector {preScale} {e.PinchGesture.Scale}\n");
                  if (preScale > e.PinchGesture.Scale)
                    {
                        if (base.Window.IsMaximized())
                        {
                          base.Window.Maximize(false);
                        }
                        else
                        {
                          if (videoView != null)
                          {
                            videoView.Pause();
                          }
                          base.Window.Minimize(true);
                        }
                    }
                    else
                    {
                        base.Window.Maximize(true);
                    }
                }
            };

      }

      public override bool  OnCloseTouched(object sender, View.TouchEventArgs e)
      {
        if (videoView != null)
        {
          videoView.Stop();
          videoView.Dispose();
        }
        base.OnCloseTouched(sender, e);
        return true;
      }

      public override bool  OnMinTouched(object sender, View.TouchEventArgs e)
      {
        if (videoView != null)
        {
          videoView.Pause();
        }
        base.OnMinTouched(sender, e);
        return true;
      }

      public void SetVideoView(VideoView view)
      {
        videoView = view;
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
          ResourceUrl = imagePath+"download1.jpeg",
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
        subWindowTwo = new Window("subwin1", new Rectangle(60, 20, 800, 800), true);
        TestWindow testWin = new TestWindow();
        testWin.Height = 50;
        subWindowTwo.SetTransparency(true);
        subWindowTwo.BackgroundColor = Color.Transparent;
        subWindowTwo.EnableBorderWindow(testWin);

        var root = new ImageView()
        {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          ResourceUrl = imagePath+"download3.jpeg",
          CornerRadius = new Vector4(0.03f, 0.03f, 0, 0),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };

        videoView = new VideoView()
        {
          ResourceUrl = videoPath,
          Underlay = false,
          Looping = true,
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          PositionUsesPivotPoint = true,
          ParentOrigin = ParentOrigin.Center,
          PivotPoint = PivotPoint.Center,
          CornerRadius = new Vector4(0.03f, 0.03f, 0, 0),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        testWin.SetVideoView(videoView);
        subWindowTwo.Add(videoView);
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
          ResourceUrl = imagePath+"download2.jpeg",
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
