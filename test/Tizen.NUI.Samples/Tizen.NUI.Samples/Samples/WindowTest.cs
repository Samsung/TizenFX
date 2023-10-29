
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class WindowTest : IExample
    {
        string tag = "NUITEST";
        Window mainWin;
        int screenWidth;
        int screenHeight;

        int addingInput;
        Timer tm;
        bool manualRotation;
        int rotationCount;
        private Window subWindow = null;

        private const string KEY_NUM_1 = "1";
        private const string KEY_NUM_2 = "2";
        private const string KEY_NUM_3 = "3";
        private const string KEY_NUM_4 = "4";
        private const string KEY_NUM_5 = "5";
        private const string KEY_NUM_6 = "6";
        private const string KEY_NUM_7 = "7";
        private const string KEY_NUM_8 = "8";
        private const string KEY_NUM_9 = "9";
        private const string KEY_NUM_0 = "0";

        private static readonly string ImagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/Dali/CubeTransitionEffect/";

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
                topView.Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(20, 20),
                };
                title = new TextLabel()
                {
                    Text = "CustomBorder",
                };

                var button = new Button()
                {
                    Text = "AlwaysOnTop",
                };
                button.Clicked += (s, e) =>
                {
                    BorderWindow.EnableFloatingMode(true);
                };
                topView.Add(title);
                topView.Add(button);
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
                    AccessibilityHighlightable = true,
                };

                maximalizeIcon = new ImageView()
                {
                    ResourceUrl = MaximalizeIcon,
                    AccessibilityHighlightable = true,
                };

                closeIcon = new ImageView()
                {
                    ResourceUrl = CloseIcon,
                    AccessibilityHighlightable = true,
                };

                leftCornerIcon = new ImageView()
                {
                    ResourceUrl = LeftCornerIcon,
                    AccessibilityHighlightable = true,
                };

                rightCornerIcon = new ImageView()
                {
                    ResourceUrl = RightCornerIcon,
                    AccessibilityHighlightable = true,
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

                minimalizeIcon.AccessibilityActivated += (s, e) =>
                {
                    MinimizeBorderWindow();
                };
                maximalizeIcon.AccessibilityActivated += (s, e) =>
                {
                    MaximizeBorderWindow();
                };
                closeIcon.AccessibilityActivated += (s, e) =>
                {
                    CloseBorderWindow();
                };

                minimalizeIcon.AccessibilityNameRequested += (s, e) =>
                {
                    e.Name = "Minimize";
                };
                maximalizeIcon.AccessibilityNameRequested += (s, e) =>
                {
                    e.Name = "Maximize";
                };
                closeIcon.AccessibilityNameRequested += (s, e) =>
                {
                    e.Name = "Close";
                };
                leftCornerIcon.AccessibilityNameRequested += (s, e) =>
                {
                    e.Name = "Resize";
                };
                rightCornerIcon.AccessibilityNameRequested += (s, e) =>
                {
                    e.Name = "Resize";
                };

                minimalizeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
                maximalizeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
                closeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
                leftCornerIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
                rightCornerIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);

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
                UpdateIcons();
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




        void Initialize()
        {
            mainWin = NUIApplication.GetDefaultWindow();
            mainWin.KeyEvent += OnKeyEvent;
            mainWin.TouchEvent += WinTouchEvent;
            mainWin.BackgroundColor = Color.Cyan;

            Information.TryGetValue<int>("http://tizen.org/feature/screen.width", out screenWidth);
            Information.TryGetValue<int>("http://tizen.org/feature/screen.height", out screenHeight);
            log.Fatal(tag, $"Initialize= screenWidth {screenWidth}, screenHeight {screenHeight} ");
            Rectangle inputRegion = new Rectangle(0, 0, screenWidth, screenHeight / 2);
            mainWin.IncludeInputRegion(inputRegion);

            addingInput = 0;

            TextLabel text = new TextLabel("NUI Window Test");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.Blue;
            text.PointSize = 12.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            mainWin.Add(text);

            List<Window.WindowOrientation> list = new List<Window.WindowOrientation>();

            list.Add(Window.WindowOrientation.Landscape);
            list.Add(Window.WindowOrientation.LandscapeInverse);
            list.Add(Window.WindowOrientation.NoOrientationPreference);
            list.Add(Window.WindowOrientation.Portrait);
            list.Add(Window.WindowOrientation.PortraitInverse);

            mainWin.SetAvailableOrientations(list);

            Animation animation = new Animation(2000);
            animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
            animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
            animation.Looping = true;
            animation.Play();

            manualRotation = false;
            rotationCount = 0;
        }

        private bool Tm_Tick(object source, Timer.TickEventArgs e)
        {
            bool rotating = mainWin.IsWindowRotating();
            log.Fatal(tag, $"window is Rotating: {rotating}");
            if (rotating && manualRotation)
            {
                rotationCount++;
                if (rotationCount > 100)
                {
                    log.Fatal(tag, $"call SendRotationCompletedAcknowledgement");
                    mainWin.SendRotationCompletedAcknowledgement();
                    rotationCount = 0;
                }
            }
            return true;
        }

        private void WinTouchEvent(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                Vector2 touchpoint = e.Touch.GetScreenPosition(0);
                log.Fatal(tag, $"WinTouchEvent={touchpoint.X}, {touchpoint.Y}");
                int xPosition = 0;
                if (addingInput == 0)
                {
                    if (touchpoint.Y > (screenHeight / 2 - 50))
                    {
                        int yPostion = screenHeight / 2 + 1;
                        int height = screenHeight / 2;
                        log.Fatal(tag, $"WinTouchEvent= Include {xPosition},{yPostion} {screenWidth}x{height} ");
                        mainWin.IncludeInputRegion(new Rectangle(xPosition, yPostion, screenWidth, height));
                        addingInput = 1;
                    }
                }
                else
                {
                    if (touchpoint.Y > (screenHeight - 50))
                    {
                        int yPostion = screenHeight / 2 + 1;
                        int height = screenHeight / 2;
                        log.Fatal(tag, $"WinTouchEvent= Exclude {xPosition},{yPostion} {screenWidth}x{height} ");
                        mainWin.ExcludeInputRegion(new Rectangle(xPosition, yPostion, screenWidth, height));
                        addingInput = 0;
                    }
                }
            }
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                log.Fatal(tag, $"key down! key={e.Key.KeyPressedName}");

                switch (e.Key.KeyPressedName)
                {
                    case "XF86Back":
                    case "Escape":
                        //Exit();
                        break;

                    case KEY_NUM_0:
                        CreateSubWindow();
                        break;

                    case KEY_NUM_1:
                        log.Fatal(tag, $"SetClass test");
                        mainWin.SetClass("windowTitle", "windowClass");
                        break;

                    case KEY_NUM_2:
                        log.Fatal(tag, $"Maximize test");
                        if (mainWin.IsMaximized())
                        {
                            log.Fatal(tag, $"Unset Maximize");
                            mainWin.Maximize(false);
                        }
                        else
                        {
                            log.Fatal(tag, $"Set Maximize");
                            mainWin.Maximize(true);
                        }
                        break;

                    case KEY_NUM_3:
                        log.Fatal(tag, $"Set MaximumSize test");
                        mainWin.SetMaximumSize(new Size2D(700, 700));
                        break;

                    case KEY_NUM_4:
                        log.Fatal(tag, $"Set MimimumSize test");
                        mainWin.SetMimimumSize(new Size2D(100, 100));
                        break;

                    case KEY_NUM_5:
                        log.Fatal(tag, $"manual rotation test");
                        if (manualRotation == false)
                        {
                            manualRotation = true;
                            tm = new Timer(100);
                            tm.Tick += Tm_Tick;
                            tm.Start();
                            log.Fatal(tag, $"Enable manual rotation");
                        }
                        else
                        {
                            manualRotation = false;
                            log.Fatal(tag, $"Disable manual rotation");
                        }
                        mainWin.SetNeedsRotationCompletedAcknowledgement(manualRotation);
                        break;

                    case KEY_NUM_6:
                        log.Fatal(tag, $"Fullscreen Test");
                        if (mainWin.GetFullScreen() == false)
                        {
                            mainWin.SetFullScreen(true);
                        }
                        else
                        {
                            mainWin.SetFullScreen(false);
                        }
                        break;

                    case KEY_NUM_7:
                        log.Fatal(tag, $"Raise Test");
                        mainWin.Raise();
                        break;

                    case KEY_NUM_8:
                        log.Fatal(tag, $"Lower Test");
                        mainWin.Lower();
                        break;

                    case KEY_NUM_9:
                        log.Fatal(tag, $"Activate Test");
                        mainWin.Activate();
                        break;

                    default:
                        log.Fatal(tag, $"no test!");
                        break;
                }
            }
        }

        void CreateSubWindow()
        {
            if (subWindow == null)
            {
                CustomBorder customBorder = new CustomBorder();
                subWindow = new Window("subwin", customBorder, new Rectangle(60, 20, 800, 800), false);
                subWindow.InterceptTouchEvent += (s, e) =>
                {
                    Tizen.Log.Error("NUI", $"subWindow.InterceptTouchEvent\n");
                    if (e.Touch.GetState(0) == PointStateType.Down)
                    {
                        customBorder.OverlayBorderShow();
                    }
                    return false;
                };

                var root = new View()
                {
                    Layout = new LinearLayout()
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                    },
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    BackgroundColor = Color.Brown,
                };

                var image = new ImageView()
                {
                    Size = new Size(300, 300),
                    ResourceUrl = ImagePath + "gallery-large-5.jpg",
                    CornerRadius = new Vector4(0.03f, 0.03f, 0, 0),
                    CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                };
                root.Add(image);
                subWindow.GetDefaultLayer().Add(root);

                List<Window.WindowOrientation> list = new List<Window.WindowOrientation>();

                list.Add(Window.WindowOrientation.Landscape);
                list.Add(Window.WindowOrientation.LandscapeInverse);
                list.Add(Window.WindowOrientation.NoOrientationPreference);
                list.Add(Window.WindowOrientation.Portrait);
                list.Add(Window.WindowOrientation.PortraitInverse);

                subWindow.SetAvailableOrientations(list);

                subWindow.Moved += OnSubWindowMoved;
                subWindow.KeyEvent += OnSubWindowKeyEvent;
                subWindow.MoveCompleted += OnSubWindowMoveCompleted;
                subWindow.ResizeCompleted += OnSubWindowResizeCompleted;
            }
            else
            {
                subWindow.Minimize(false);
            }
        }

        private void OnSubWindowMoved(object sender, WindowMovedEventArgs e)
        {
            Position2D position = e.WindowPosition;
            log.Fatal(tag, $"OnSubWindowMoved() called!, x:{position.X}, y:{position.Y}");
        }

        private void OnSubWindowMoveCompleted(object sender, WindowMoveCompletedEventArgs e)
        {
            Position2D position = e.WindowCompletedPosition;
            log.Fatal(tag, $"OnSubWindowMoveCompleted() called!, x:{position.X}, y:{position.Y}");
        }

        private void OnSubWindowResizeCompleted(object sender, WindowResizeCompletedEventArgs e)
        {
            Size2D size = e.WindowCompletedSize;
            log.Fatal(tag, $"OnSubWindowResizeCompleted() called!, width:{size.Width}, height:{size.Height}");
        }


        public void OnSubWindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                log.Fatal(tag, $"key down! key={e.Key.KeyPressedName}");

                switch (e.Key.KeyPressedName)
                {
                    case "XF86Back":
                    case "Escape":
                        //Exit();
                        break;

                    case KEY_NUM_0:
                        log.Fatal(tag, $"Remove Available Orientation test");
                        subWindow.RemoveAvailableOrientation(Window.WindowOrientation.Portrait);
                        break;

                    case KEY_NUM_1:
                        log.Fatal(tag, $"Set/Get Orientation test");
                        subWindow.SetPreferredOrientation(Window.WindowOrientation.Portrait);
                        Window.WindowOrientation currentPreferredOrientation = subWindow.GetPreferredOrientation();
                        log.Fatal(tag, $"current Preferred Orientation: {currentPreferredOrientation}");
                        Window.WindowOrientation currentOrientation = subWindow.GetCurrentOrientation();
                        log.Fatal(tag, $"current Orientation: {currentOrientation}");
                        break;

                    case KEY_NUM_2:
                        log.Fatal(tag, $"Set Accept Focus test");
                        subWindow.SetAcceptFocus(true);
                        if (subWindow.IsFocusAcceptable())
                        {
                            log.Fatal(tag, $"focus is acceptable");
                        }
                        else
                        {
                            log.Fatal(tag, $"focus is not acceptable");
                        }
                        break;

                    case KEY_NUM_3:
                        log.Fatal(tag, $"visible/show/hide test");
                        if (subWindow.IsVisible())
                        {
                            log.Fatal(tag, $"subwindow is hideing");
                            subWindow.Hide();
                        }
                        else
                        {
                            log.Fatal(tag, $"subwindow is showing");
                            subWindow.Show();
                        }
                        break;

                    case KEY_NUM_4:
                        log.Fatal(tag, $"Get/Set, Notification Level test");
                        if (subWindow.Type != WindowType.Notification)
                        {
                            log.Fatal(tag, $"Set notification window type");
                            subWindow.Type = WindowType.Notification;
                            log.Fatal(tag, $"Set notification level with high");
                            subWindow.SetNotificationLevel(NotificationLevel.High);
                            if (subWindow.GetNotificationLevel() == NotificationLevel.High)
                            {
                                log.Fatal(tag, $"Current notificaiton level is high");
                            }
                            else
                            {
                                log.Fatal(tag, $"Current notificaiton level is not high");
                            }
                        }
                        break;

                    case KEY_NUM_5:
                        log.Fatal(tag, $"opaque test");
                        if (subWindow.IsOpaqueState())
                        {
                            log.Fatal(tag, $"Set opaque state with false");
                            subWindow.SetOpaqueState(false);
                        }
                        else
                        {
                            log.Fatal(tag, $"Set opaque state with true");
                            subWindow.SetOpaqueState(true);
                        }
                        break;

                    case KEY_NUM_6:
                        log.Fatal(tag, $"Set/Get ScreenOffMode test");
                        if (subWindow.GetScreenOffMode() == ScreenOffMode.Timout)
                        {
                            log.Fatal(tag, $"SetScreenOffMode with ScreenOffMode.Never");
                            subWindow.SetScreenOffMode(ScreenOffMode.Never);
                        }
                        else
                        {
                            log.Fatal(tag, $"SetScreenOffMode with ScreenOffMode.Timout");
                            subWindow.SetScreenOffMode(ScreenOffMode.Timout);
                        }

                        break;

                    case KEY_NUM_7:
                        log.Fatal(tag, $"Set/Get Brightness test");
                        subWindow.SetBrightness(95);
                        int currentBrightness = subWindow.GetBrightness();
                        log.Fatal(tag, $"Current Brightness: {currentBrightness}");
                        break;

                    case KEY_NUM_8:
                        log.Fatal(tag, $"Get/Set WindowPosition Test");
                        subWindow.WindowPosition = new Position2D(10, 10);
                        log.Fatal(tag, $"subWindow x: {subWindow.WindowPosition.X}, y: {subWindow.WindowPosition.Y}");
                        //log.Fatal(tag, $"WindowPosition : " + subWindow.WindowPosition);
                        break;

                    case KEY_NUM_9:
                        log.Fatal(tag, $"Get/Set WindowPositionSize Test");
                        Rectangle rec = new Rectangle(20, 10, 100, 200);
                        subWindow.WindowPositionSize = rec;
                        log.Fatal(tag, $"WindowPositionSize : " + subWindow.WindowPositionSize);
                        break;

                    default:
                        log.Fatal(tag, $"no test!");
                        break;
                }
            }
        }
	public void Activate() { Initialize(); }
	public void Deactivate() { }
    }
}
