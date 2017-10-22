using System;
using Xamarin.Forms;
using Tizen;
using Tizen.Telephony;

namespace XamarinForTizen.Tizen
{
    public class ModemPage : ContentPage
    {
        private static Modem _modem = null;
        public ModemPage()
        {
            var imeiBtn = new Button
            {
                Text = "Get IMEI",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            imeiBtn.Clicked += imeiBtn_Clicked;

            var powerBtn = new Button
            {
                Text = "Get power status",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            powerBtn.Clicked += powerBtn_Clicked;

            var meidBtn = new Button
            {
                Text = "Get MEID",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            meidBtn.Clicked += meidBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        imeiBtn, powerBtn, meidBtn
                    }
            };

            try
            {
                if (Globals.slotHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                    return;
                }

                _modem = new Modem(Globals.slotHandle);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Exception in modem constructor: " + ex.ToString());
            }
        }

        private void meidBtn_Clicked(object sender, EventArgs e)
        {
            if (_modem == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "MEID: " + _modem.Meid);
        }

        private void powerBtn_Clicked(object sender, EventArgs e)
        {
            if (_modem == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Power Status: " + _modem.CurrentPowerStatus);
        }

        private void imeiBtn_Clicked(object sender, EventArgs e)
        {
            if (_modem == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "IMEI: " + _modem.Imei);
        }
    }
}
