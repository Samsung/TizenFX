using System;
using Xamarin.Forms;

namespace XamarinForTizen.Tizen
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var commonBtn = new Button
            {
                Text = "Common",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            commonBtn.Clicked += CommonBtn_Clicked;

            var modemBtn = new Button
            {
                Text = "Modem",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            modemBtn.Clicked += ModemBtn_Clicked;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        commonBtn, modemBtn
                    }
            };
        }

        private async void ModemBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModemPage());
        }

        private async void CommonBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommonPage());
        }
    }
}
