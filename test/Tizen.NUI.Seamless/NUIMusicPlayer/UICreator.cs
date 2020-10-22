using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIMusicPlayer
{
    public class UICreator
    {
        private Color MAIN_TEXT_COLOR = new Color(0.95f, 0.95f, 0.95f, 1.0f);
        private Color INFO_TEXT_COLOR = new Color(0.3f, 0.3f, 0.3f, 1.0f);
        private Color CONTENTS_TEXT_COLOR = new Color(0.4f, 0.4f, 0.4f, 1.0f);
        private Color SUB_TEXT_COLOR = new Color(0.70f, 0.70f, 0.70f, 1.0f);

        private float MAIN_TEXT_POINT_SIZE;
        private float INFO_TEXT_POINT_SIZE;
        private float PROFILE_TEXT_POINT_SIZE;
        private float CONTENTS_TEXT_POINT_SIZE;

        private float SUB_TEXT_POINT_SIZE;

        private View profileContainer;
        private View add_container;

        private TextLabel profile_text1;
        private TextLabel profile_text2;

        public UICreator()
        {
            CreateFHubSize();
        }
        public void CreateMobileSize()
        {
            MAIN_TEXT_POINT_SIZE = 16.0f;
            INFO_TEXT_POINT_SIZE = 5.0f;
            PROFILE_TEXT_POINT_SIZE = 5.0f;
            CONTENTS_TEXT_POINT_SIZE = 7.0f;

            SUB_TEXT_POINT_SIZE = 4.0f;
        }


        public void CreateFHubSize()
        {
            MAIN_TEXT_POINT_SIZE = 70.0f;
            INFO_TEXT_POINT_SIZE = 20.0f;
            PROFILE_TEXT_POINT_SIZE = 20.0f;
            CONTENTS_TEXT_POINT_SIZE = 30.0f;

            SUB_TEXT_POINT_SIZE = 13.0f;
        }

        public void CreateUI()
        {

            View view = new View()
            {
                Size = new Size(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height, 0),
                BackgroundColor = Color.Black,
            };
            Window.Instance.GetDefaultLayer().Add(view);

            profileContainer = new View()
            {
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.White,
                Position = new Position(0, 150, 0),
                Size = new Size(96, 96, 0),
                CornerRadius = 48.0f,
            };

            View profileContainer_inner = new View()
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.Black,
                Size = new Size(94, 94, 0),
                CornerRadius = 47.0f,
            };

            ImageView profileImage = new ImageView()
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/profile.jpg",
                Size = new Size(80, 80, 0),
                CornerRadius = 40.0f,
            };
            profileContainer.Add(profileContainer_inner);
            profileContainer_inner.Add(profileImage);
            view.Add(profileContainer);

            add_container = new View()
            {
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.White,
                Position = new Position(33, 183),
                Size = new Size(40, 40),
                CornerRadius = 20.0f,
            };
            ImageView add_icon = new ImageView()
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/add.png",
                Size = new Size(16, 16),
            };
            add_container.Add(add_icon);
            view.Add(add_container);

            ImageView back_btn = new ImageView()
            {
                ParentOrigin = ParentOrigin.BottomLeft,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/arrow-89-128.png",
                Position = new Position(50, -60),
                Size = new Size(40, 40),
            };
            back_btn.TouchEvent += Back_btn_TouchEvent;
            view.Add(back_btn);

            profile_text1 = new TextLabel("PIANO DAILY")
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                TextColor = MAIN_TEXT_COLOR,
                PointSize = PROFILE_TEXT_POINT_SIZE,
                Position = new Position(0, 207, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };
            view.Add(profile_text1);

            profile_text2 = new TextLabel("July 2020")
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                TextColor = SUB_TEXT_COLOR,
                PointSize = SUB_TEXT_POINT_SIZE,
                Position = new Position(0, 230, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };
            view.Add(profile_text2);


            TextLabel info1 = new TextLabel()
            {
                Text = "9,465\n",
                TextColor = INFO_TEXT_COLOR,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                PointSize = INFO_TEXT_POINT_SIZE,
                Position = new Position(-65, 400, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };
            view.Add(info1);
            ImageView info1_icon = new ImageView()
            {
                ParentOrigin = ParentOrigin.TopCenter,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/bar-chart-5-128.png",
                Color = INFO_TEXT_COLOR,
                Position = new Position(-125, 405, 0),
                Size = new Size(18, 18),
            };
            view.Add(info1_icon);


            TextLabel info2 = new TextLabel()
            {
                Text = "5h 35m\n",
                TextColor = INFO_TEXT_COLOR,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                PointSize = INFO_TEXT_POINT_SIZE,
                Position = new Position(65, 400, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };
            view.Add(info2);

            ImageView info2_icon = new ImageView()
            {
                ParentOrigin = ParentOrigin.TopCenter,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/clock-128.png",
                Color = INFO_TEXT_COLOR,
                Position = new Position(-2, 405, 0),
                Size = new Size(18, 18),
            };
            view.Add(info2_icon);



            PropertyMap map = new PropertyMap();
            map.Insert("weight", new PropertyValue("bold"));

            TextLabel text = new TextLabel("Cinematic Piano")
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                TextColor = MAIN_TEXT_COLOR,
                PointSize = MAIN_TEXT_POINT_SIZE,
                Position = new Position(0, 280, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                FontStyle = map,
            };
            view.Add(text);

            ImageView imgView = new ImageView()
            {
                ParentOrigin = ParentOrigin.BottomCenter,
                PivotPoint = PivotPoint.BottomCenter,
                PositionUsesPivotPoint = true,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/pic_1.jpg",
                //Position = new Position(0, -30, 0),
                Size = new Size(850, 850),
            };
            view.Add(imgView);


            TextLabel contents = new TextLabel()
            {
                Text = "Beautiful, dreamy and dramtic\n instrumental neo classical piano scores\n from movies and tv series.\n",
                MultiLine = true,
                TextColor = CONTENTS_TEXT_COLOR,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                PointSize = CONTENTS_TEXT_POINT_SIZE,
                Position = new Position(0, 500, 0),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };
            view.Add(contents);


            View play_btn = new View()
            {
                ParentOrigin = ParentOrigin.BottomCenter,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.White,
                Position = new Position(0, -70),
                Size = new Size(88, 88),
                CornerRadius = 44.0f,
            };


            ImageView play_icon = new ImageView()
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/play-128.png",
                Color = Color.Black,
                Size = new Size(26, 26),
            };

            play_btn.Add(play_icon);
            view.Add(play_btn);
        }

        private bool Back_btn_TouchEvent(object source, View.TouchEventArgs e)
        {
            if(e.Touch.GetState(0) == PointStateType.Up)
            {
                //HideObjects();
                //Window.Instance.SetIconified(true);
                //Exit();
            }
            return false;
        }

        public void HideObjects()
        {
            profileContainer.Hide();
            add_container.Hide();
            profile_text1.Hide();
            profile_text2.Hide();
        }

        public void ShowObjects()
        {
            profileContainer.Show();
            add_container.Show();
            profile_text1.Show();
            profile_text2.Show();
        }
    }
}
