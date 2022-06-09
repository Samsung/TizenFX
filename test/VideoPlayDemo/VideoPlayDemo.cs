using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace VideoPlayDemo
{
    class Program : NUIApplication
    {
        class CustomBorder : DefaultBorder
        {
          private static readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource;
          private static readonly string MaximalizeIcon = ResourcePath + "/maximalize.png";
          private static readonly string CloseIcon = ResourcePath + "/close.png";
          private static readonly string PlayIcon = ResourcePath + "/play.png";
          private static readonly string PauseIcon = ResourcePath + "/pause.png";
          private static readonly string SettingIcon = ResourcePath + "/setting.png";
          private static readonly string SettingPressIcon = ResourcePath + "/setting_press.png";
          private static readonly string VolumeIcon = ResourcePath + "/volume.png";
          private static readonly string VolumePressIcon = ResourcePath + "/volume_press.png";
          // private static readonly string LeftCornerIcon = ResourcePath + "/leftCorner.png";
          // private static readonly string RightCornerIcon = ResourcePath + "/rightCorner.png";

          private int width = 300;
          private bool hide = false;
          private string title;
          private View borderView;
          private TextLabel titleLabel;
          private Rectangle preWinPositonSize;
          private ImageView playPauseIcon;
          private ImageView maximalizeIcon;
          private ImageView closeIcon;
          private ImageView settingIcon;
          private ImageView volumeIcon;
          private View leftCornerIcon;
          private View rightCornerIcon;
          private VideoView videoView;
          private bool isPlay = false;

          public CustomBorder(string title) : base()
          {
            OverlayMode = true;
            BorderLineThickness = 1;
            this.title = title;
            this.videoView = videoView;
            MinSize = new Size2D(600, 400);
          }

          public void SetVideoView(VideoView videoView)
          {
            this.videoView = videoView;
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
              LinearAlignment = LinearLayout.Alignment.CenterVertical,
              CellPadding = new Size2D(50, 50),
            };

            titleLabel = new TextLabel()
            {
              Text = title,
              TextColor = Color.White,
            };
            topView.Add(titleLabel);
            return true;
          }

          public override bool CreateBottomBorderView(View bottomView)
          {
            bottomView.SizeHeight = 124;

            var contentsView = new View()
            {
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = LayoutParamPolicies.MatchParent,
              Layout = new LinearLayout()
              {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.Center,
                CellPadding = new Size2D(8, 0),
              },
              BackgroundColor = Color.Transparent,
            };

            playPauseIcon = new ImageView()
            {
                ResourceUrl = PlayIcon,
            };

            maximalizeIcon = new ImageView()
            {
                ResourceUrl = MaximalizeIcon,
            };

            closeIcon = new ImageView()
            {
                ResourceUrl = CloseIcon,
            };

            leftCornerIcon = new View()
            {
                Size2D = new Size2D(50, 50),
            };

            rightCornerIcon = new View()
            {
                Size2D = new Size2D(50, 50),
            };
            contentsView.Add(playPauseIcon);
            contentsView.Add(maximalizeIcon);
            contentsView.Add(closeIcon);

            bottomView.Layout = new RelativeLayout();
            RelativeLayout.SetRightRelativeOffset(rightCornerIcon, 1.0f);
            RelativeLayout.SetHorizontalAlignment(rightCornerIcon, RelativeLayout.Alignment.End);
            RelativeLayout.SetVerticalAlignment(rightCornerIcon, RelativeLayout.Alignment.End);
            RelativeLayout.SetVerticalAlignment(leftCornerIcon, RelativeLayout.Alignment.End);
            bottomView.Add(leftCornerIcon);
            bottomView.Add(rightCornerIcon);
            bottomView.Add(contentsView);



            playPauseIcon.TouchEvent += OnPlayPauseIconTouched;
            maximalizeIcon.TouchEvent += OnMaximizeIconTouched;
            closeIcon.TouchEvent += OnCloseIconTouched;
            leftCornerIcon.TouchEvent += OnLeftBottomCornerIconTouched;
            rightCornerIcon.TouchEvent += OnRightBottomCornerIconTouched;

            return true;
          }

          public override void OnCreated(View borderView)
          {
            base.OnCreated(borderView);
            this.borderView = borderView;
            BorderWindow.EnableFloatingMode(true);
          }

          public override void OnResized(int width, int height)
          {
            if (borderView != null && titleLabel != null)
            {
              if (this.width > width && hide == false)
              {
                titleLabel.Hide();
                hide = true;
              }
              else if (this.width < width && hide == true)
              {
                titleLabel.Show();
                hide = false;
              }
            }
            base.OnResized(width, height);
            // UpdateIcons();
          }

          // private void UpdateIcons()
          // {
          //   if (BorderWindow != null && borderView != null)
          //   {
          //       if (BorderWindow.IsMaximized() == true)
          //       {
          //           if (maximalizeIcon != null)
          //           {
          //               maximalizeIcon.ResourceUrl = RestoreIcon;
          //           }
          //       }
          //       else
          //       {
          //           if (maximalizeIcon != null)
          //           {
          //               maximalizeIcon.ResourceUrl = MaximalizeIcon;
          //           }
          //       }
          //   }
          // }

          public override bool OnMaximizeIconTouched(object sender, View.TouchEventArgs e)
          {
            base.OnMaximizeIconTouched(sender, e);
            if (e.Touch.GetState(0) == PointStateType.Up && videoView != null)
            {
              if (BorderWindow.IsMaximized() == true)
              {
                videoView.Underlay = true;
              }
              else
              {
                videoView.Underlay = false;
              }
            }
            return true;
          }

          public override bool OnCloseIconTouched(object sender, View.TouchEventArgs e)
          {
              if (e.Touch.GetState(0) == PointStateType.Up && app != null)
              {
                  app.Exit();
              }
              return true;
          }

          public bool OnPlayPauseIconTouched(object sender, View.TouchEventArgs e)
          {
            if (e.Touch.GetState(0) == PointStateType.Up && videoView != null)
            {
              if (isPlay == true)
              {
                isPlay = false;
                videoView.Pause();
                playPauseIcon.ResourceUrl = PlayIcon;
              }
              else
              {
                isPlay = true;
                videoView.Play();
                playPauseIcon.ResourceUrl = PauseIcon;
              }
            }
            return true;
          }
        }

        public Program(string styleSheet, Size2D windowSize, Position2D windowPosition, IBorderInterface borderInterface) : base(styleSheet, windowSize, windowPosition, borderInterface)
        {
        }

        public static Program app;
        static CustomBorder customBorder;
        View windowMainView;
        VideoView videoView;
        Window win = null;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            win = NUIApplication.GetDefaultWindow();
            win.KeyEvent += OnKeyEvent;

            windowMainView = new View()
            {
               Layout = new LinearLayout()
               {
                  LinearOrientation = LinearLayout.Orientation.Vertical,
               },
               WidthSpecification = LayoutParamPolicies.MatchParent,
               HeightSpecification = LayoutParamPolicies.MatchParent,
               BackgroundColor = Color.Black,
               CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
               CornerRadiusPolicy = VisualTransformPolicyType.Relative,
               ClippingMode = ClippingModeType.ClipToBoundingBox,
            };
            win.Add(windowMainView);


            videoView = new VideoView()
            {
              Underlay = false,
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = LayoutParamPolicies.MatchParent,
              ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "02_gallery_video.mp4",
              Looping = true,
            };
            customBorder.SetVideoView(videoView);
            windowMainView.Add(videoView);
            videoView.Play();
            videoView.Pause();
            win.SetTransparency(true);

            win.InterceptTouchEvent += (s, e) => 
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                  customBorder.OverlayBorderShow();
                }
                return true;
            };
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            customBorder = new CustomBorder("  Video");
            app = new Program("", new Size2D(600, 400), new Position2D(500, 100), customBorder);
            app.Run(args);
        }
    }
}
