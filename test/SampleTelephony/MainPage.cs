using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Tizen;
using Tizen.Telephony;

namespace XamarinForTizen.Tizen
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var initBtn = new Button
            {
                Text = "Initialize",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            initBtn.Clicked += initBtn_Clicked;

            var callBtn = new Button
            {
                Text = "Call",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            callBtn.Clicked += callBtn_Clicked;

            var ModemBtn = new Button
            {
                Text = "Modem",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            ModemBtn.Clicked += ModemBtn_Clicked;

            var NetworkBtn = new Button
            {
                Text = "Network",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            NetworkBtn.Clicked += NetworkBtn_Clicked;

            var simBtn = new Button
            {
                Text = "Sim",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            simBtn.Clicked += simBtn_Clicked;

            var deinitBtn = new Button
            {
                Text = "Deinitialize",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            deinitBtn.Clicked += deinitBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        initBtn, callBtn, ModemBtn, NetworkBtn, simBtn, deinitBtn
                    }
            };

            try
            {
                Manager.StateChanged += Manager_StateChanged;
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Exception in registering for state changed event: " + ex.ToString());
            }
        }

        private void Manager_StateChanged(object sender, StateEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Telephony state changed: " + e.CurrentState);
        }

        private void deinitBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Manager.Deinit();
                Globals.slotHandle = null;
                Log.Debug(Globals.LogTag, "Deinit successful");
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Telephony deinit exception: " + ex.ToString());
            }
        }

        private async void callBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallPage());
        }

        private async void ModemBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModemPage());
        }

        private async void NetworkBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NetworkPage());
        }

        private async void simBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SimPage());
        }

        private void initBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                List<SlotHandle> simList = Manager.Init().ToList();
                if (simList.Count == 0)
                {
                    Log.Debug(Globals.LogTag, "SimList count is zero");
                    return;
                }

                Log.Debug(Globals.LogTag, "Telephony initialized successfully");
                Globals.slotHandle = simList.ElementAt(0);
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Telephony init exception: " + ex.ToString());
            }
        }
    }
}
