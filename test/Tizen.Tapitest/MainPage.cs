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

            var callgsmBtn = new Button
            {
                Text = "Call-Gsm",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            callgsmBtn.Clicked += CallgsmBtn_Clicked;

            var modemBtn = new Button
            {
                Text = "Modem",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            modemBtn.Clicked += ModemBtn_Clicked;

            var nwBtn = new Button
            {
                Text = "Network",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            nwBtn.Clicked += NwBtn_Clicked;

            var simBtn = new Button
            {
                Text = "Sim",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            simBtn.Clicked += simBtn_Clicked;

            var phonebookBtn = new Button
            {
                Text = "Phonebook",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            phonebookBtn.Clicked += phonebookBtn_Clicked;

            var ssBtn = new Button
            {
                Text = "Ss",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            ssBtn.Clicked += ssBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        commonBtn, callgsmBtn, modemBtn, nwBtn, simBtn, phonebookBtn, ssBtn
                    }
            };
        }

        private async void ssBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SsPage());
        }

        private async void phonebookBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PhonebookPage());
        }

        private async void simBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SimPage());
        }

        private async void NwBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NetworkPage());
        }

        private async void CallgsmBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallPage());
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
