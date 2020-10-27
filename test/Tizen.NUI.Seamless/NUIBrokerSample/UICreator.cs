using System;
using System.Collections.Generic;
using System.Text;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIBrokerSample
{
    class UICreator
    {
        private Color MAIN_TEXT_COLOR = new Color(0.95f, 0.95f, 0.95f, 1.0f);
        private Color SUB_TEXT_COLOR = new Color(0.70f, 0.70f, 0.70f, 1.0f);
        private Color INFO_TEXT_COLOR = new Color(0.3f, 0.3f, 0.3f, 1.0f);

        private Color CONTENTS_TEXT_COLOR = new Color(0.6f, 0.6f, 0.6f, 1.0f);

        private float MAIN_TEXT_POINT_SIZE;
        private float PROFILE_TEXT_POINT_SIZE;
        private float SUB_TEXT_POINT_SIZE;

        private float INFO_TEXT_POINT_SIZE;
        private float CONTENTS_TEXT_POINT_SIZE;

        public View AnimationView;
        public View IconView;
        public View AddView;

        public View MainView;

        public TextLabel MainProfileText;
        public TextLabel SubProfileText;

        //Touch/Launching Animation
        public bool isStartingProcess = false;
        private Vector2 prePos = new Vector2(0, 0);
        private Vector2 firstPos = new Vector2(0, 0);
        private Animation startAni;

        private NUIApplication application;

        public UICreator(NUIApplication app)
        {
            application = app;
            CreateFHubSize();
        }
        private void CreateMobileSize()
        {
            MAIN_TEXT_POINT_SIZE = 8.0f;
            PROFILE_TEXT_POINT_SIZE = 6.0f;
            SUB_TEXT_POINT_SIZE = 3.0f;

            INFO_TEXT_POINT_SIZE = 3.0f;
            CONTENTS_TEXT_POINT_SIZE = 3.0f;
        }


        private void CreateFHubSize()
        {
            MAIN_TEXT_POINT_SIZE = 32.0f;
            PROFILE_TEXT_POINT_SIZE = 14.0f;
            SUB_TEXT_POINT_SIZE = 11.0f;

            INFO_TEXT_POINT_SIZE = 13.0f;
            CONTENTS_TEXT_POINT_SIZE = 12.0f;
        }

        public void CreateUI()
        {
            ImageView bgView = new ImageView()
            {
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/familyboard_setting_bg1.png",
                Size = new Size(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height),
            };

            Window.Instance.Add(bgView);
            MainView = new View()
            {
                Size = new Size(470, 600),
                //Size = new Size(50, 50),
                BackgroundColor = Color.Black,
                CornerRadius = 10.0f,
                Position = new Position(-50, 500),
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.TopCenter,
                PositionUsesPivotPoint = true,
            };


            Window.Instance.Add(MainView);
            AnimationView = new View()
            {
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.TopCenter,
                PositionUsesPivotPoint = true,
                Size = new Size(470, 600),
                Position = new Position(-50, 500),
            };
            Window.Instance.Add(AnimationView);
            MainView.TouchEvent += View_TouchEvent; ;


            ImageView imgView = new ImageView()
            {
                ParentOrigin = ParentOrigin.BottomCenter,
                PivotPoint = PivotPoint.BottomCenter,
                PositionUsesPivotPoint = true,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/pic_1.jpg",
                //Position = new Position(0, -30, 0),
                Size = new Size(360, 360),
            };
            MainView.Add(imgView);

            TextLabel contents = new TextLabel()
            {
                Text = "Beautiful, dreamy and dramtic\n instrumental neo classical piano scores\n from movies and tv series.\n",
                MultiLine = true,
                TextColor = CONTENTS_TEXT_COLOR,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                PointSize = CONTENTS_TEXT_POINT_SIZE,
                Position = new Position(0, 250, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                Opacity = 0.0f,
            };
            MainView.Add(contents);

            CreateTopProfile(MainView);

            PropertyMap map = new PropertyMap();
            map.Insert("weight", new PropertyValue("bold"));

            TextLabel text = new TextLabel("Cinematic Piano")
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                TextColor = MAIN_TEXT_COLOR,
                PointSize = MAIN_TEXT_POINT_SIZE,
                Position = new Position(0, 150, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                FontStyle = map,
            };
            MainView.Add(text);

            CreateInfo(MainView);

            View play_btn = new View()
            {
                ParentOrigin = ParentOrigin.BottomCenter,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.White,
                Position = new Position(0, -40),
                Size = new Size(52, 52),
                CornerRadius = 26.0f,
            };

            ImageView play_icon = new ImageView()
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/play-128.png",
                Color = Color.Black,
                Size = new Size(20, 20),
            };

            play_btn.Add(play_icon);
            MainView.Add(play_btn);
        }


        public void CreateTopProfile(View view)
        {
            IconView = new View()
            {
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.White,
                Position = new Position(-160, 80, 0),
                Size = new Size(76, 76, 0),
                CornerRadius = 38.0f,
            };

            View profileContainer_inner = new View()
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.Black,
                Size = new Size(74, 74, 0),
                CornerRadius = 37.0f,
            };

            ImageView profileImage = new ImageView()
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/profile.jpg",
                Size = new Size(62, 62, 0),
                CornerRadius = 31.0f,
            };
            IconView.Add(profileContainer_inner);
            profileContainer_inner.Add(profileImage);
            AnimationView.Add(IconView);

            PropertyMap map = new PropertyMap();
            map.Insert("weight", new PropertyValue("bold"));
            MainProfileText = new TextLabel("PIANO DAILY")
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                TextColor = MAIN_TEXT_COLOR,
                PointSize = PROFILE_TEXT_POINT_SIZE,
                Position = new Position(0, 60, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                FontStyle = map,
            };
            AnimationView.Add(MainProfileText);
            SubProfileText = new TextLabel("July 2020")
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                TextColor = SUB_TEXT_COLOR,
                PointSize = SUB_TEXT_POINT_SIZE,
                Position = new Position(0, 90, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };
            AnimationView.Add(SubProfileText);



            AddView = new View()
            {
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.White,
                Position = new Position(160, 80),
                Size = new Size(60, 60),
                CornerRadius = 30.0f,
            };
            ImageView add_icon = new ImageView()
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/add.png",
                Size = new Size(15, 15),
            };
            AddView.Add(add_icon);
            AnimationView.Add(AddView);
        }

        public void CreateInfo(View view)
        {
            int posY = 210;
            TextLabel info1 = new TextLabel()
            {
                Text = "9,465\n",
                TextColor = INFO_TEXT_COLOR,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                PointSize = INFO_TEXT_POINT_SIZE,
                Position = new Position(-35, posY, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };
            view.Add(info1);
            ImageView info1_icon = new ImageView()
            {
                ParentOrigin = ParentOrigin.TopCenter,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/bar-chart-5-128.png",
                Color = INFO_TEXT_COLOR,
                Position = new Position(-85, posY, 0),
                Size = new Size(15, 15),
            };
            view.Add(info1_icon);


            TextLabel info2 = new TextLabel()
            {
                Text = "5h 35m\n",
                TextColor = INFO_TEXT_COLOR,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                PointSize = INFO_TEXT_POINT_SIZE,
                Position = new Position(65, posY, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };
            view.Add(info2);

            ImageView info2_icon = new ImageView()
            {
                ParentOrigin = ParentOrigin.TopCenter,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/clock-128.png",
                Color = INFO_TEXT_COLOR,
                Position = new Position(10, posY, 0),
                Size = new Size(15, 15),
            };
            //view.Add(info2_icon);

        }
        private bool View_TouchEvent(object source, View.TouchEventArgs e)
        {

            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                prePos = e.Touch.GetScreenPosition(0);
                firstPos = prePos;

                startAni = new Animation(150);
                startAni.AnimateTo(MainView, "Scale", new Vector3(0.9f, 0.9f, 1.0f));
                startAni.AnimateTo(AnimationView, "Scale", new Vector3(0.9f, 0.9f, 1.0f));
                startAni.Play();
            }
            else if (e.Touch.GetState(0) == PointStateType.Motion)
            {
                Vector2 curPos = e.Touch.GetScreenPosition(0);
                float moveX = curPos.X - prePos.X;
                float moveY = curPos.Y - prePos.Y;
                Position mPos = MainView.Position;
                MainView.Position = new Position(mPos.X + moveX, mPos.Y + moveY);
                AnimationView.Position = new Position(mPos.X + moveX, mPos.Y + moveY);

                prePos = curPos;
            }
            else if (e.Touch.GetState(0) == PointStateType.Up)
            {
                Vector2 curPos = e.Touch.GetScreenPosition(0);
                float moveX = Math.Abs(curPos.X - firstPos.X);
                float moveY = Math.Abs(curPos.Y - firstPos.Y);

                if (moveX < 5 && moveY < 5 && !isStartingProcess)
                {
                    Tizen.Log.Error("MYLOG", "launch app");
                    launchApplication();
                }
                if (startAni != null)
                {
                    startAni.Clear();
                    startAni.Dispose();
                    startAni = null;
                }
                startAni = new Animation(150);
                startAni.AnimateTo(MainView, "Scale", new Vector3(1.0f, 1.0f, 1.0f));
                startAni.AnimateTo(AnimationView, "Scale", new Vector3(1.0f, 1.0f, 1.0f));
                startAni.Play();
            }

            return true;
        }

        private void launchApplication()
        {
            AppControl appControl = new AppControl();
            appControl.ApplicationId = "org.tizen.example.NUIMusicPlayer";
            application.SendLaunchRequest(appControl);
        }

    }
}
