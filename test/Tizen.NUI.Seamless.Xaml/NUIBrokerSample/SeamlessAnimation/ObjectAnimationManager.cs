using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI;

namespace NUIBrokerSample
{
    class ObjectAnimationManager
    {
        private XamlPage xamlPage;
        private Position defaultPosition = new Position(0, 0);

        public ObjectAnimationManager(XamlPage xamlPage)
        {
            this.xamlPage = xamlPage;
        }
        
        public void StartIconAnimationByDirection(bool direction)
        {
            if(direction)
            {
                xamlPage.mainView.Hide();
                xamlPage.picture.Hide();
                defaultPosition = xamlPage.mainViewModel.MainPosition;

                Animation ani = new Animation(500);
                ani.DefaultAlphaFunction = GetSineInOut80();
                ani.AnimateTo(xamlPage.IconView, "Position", new Position(0, 150));
                ani.AnimateTo(xamlPage.AddView, "Position", new Position(30, 180));

                ani.AnimateTo(xamlPage.IconView, "Scale", new Vector3(1.3f, 1.3f, 1.3f));
                ani.AnimateTo(xamlPage.AddView, "Scale", new Vector3(0.5f, 0.5f, 0.5f));

                ani.AnimateTo(xamlPage.MainProfileText, "Position", new Position(0, 220));

                ani.AnimateTo(xamlPage.AnimationView, "Size", new Size(Window.Instance.WindowSize));
                ani.AnimateTo(xamlPage.AnimationView, "Position", new Position(0, 0));

                ani.AnimateTo(xamlPage.cinematicText, "Position", new Position(0, 320));

                ani.Play();

            }
            else
            {
                int startTime = 200;
                int endTime = 400;
                xamlPage.mainView.Show();
                xamlPage.picture.Show();

                Animation ani = new Animation(endTime);
                ani.DefaultAlphaFunction = GetSineInOut80();
                ani.AnimateTo(xamlPage.IconView, "Position", new Position(-160, 80), startTime, endTime);
                ani.AnimateTo(xamlPage.AddView, "Position", new Position(160, 80), startTime, endTime);

                ani.AnimateTo(xamlPage.IconView, "Scale", new Vector3(1.0f, 1.0f, 1.0f), startTime, endTime);
                ani.AnimateTo(xamlPage.AddView, "Scale", new Vector3(1.0f, 1.0f, 1.0f), startTime, endTime);

                ani.AnimateTo(xamlPage.MainProfileText, "Position", new Position(0, 60), startTime, endTime);

                ani.AnimateTo(xamlPage.AnimationView, "Size", new Size(470, 600), startTime, endTime);
                ani.AnimateTo(xamlPage.AnimationView, "Position", defaultPosition);

                ani.AnimateTo(xamlPage.cinematicText, "Position", new Position(0, 150));

                ani.Play();

            }
        }


        private AlphaFunction GetSineInOut80()
        {
            return new AlphaFunction(new Vector2(0.45f, 0.43f), new Vector2(0.41f, 1.0f));
        }
    }
}
