using System;
using Xamarin.Forms;
using Tizen;
using Tizen.Telephony;

namespace XamarinForTizen.Tizen
{
    public class NetworkPage : ContentPage
    {
        private static Network _network = null;
        public NetworkPage()
        {
            var cellBtn = new Button
            {
                Text = "Get cell ID",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            cellBtn.Clicked += cellBtn_Clicked;

            var lacBtn = new Button
            {
                Text = "Get LAC",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lacBtn.Clicked += lacBtn_Clicked;

            var mccBtn = new Button
            {
                Text = "Get Mcc",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            mccBtn.Clicked += mccBtn_Clicked;

            var mncBtn = new Button
            {
                Text = "Get Mnc",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            mncBtn.Clicked += mncBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        cellBtn, lacBtn, mccBtn, mncBtn
                    }
            };

            try
            {
                if (Globals.slotHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                    return;
                }

                _network = new Network(Globals.slotHandle);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Exception in network constructor: " + ex.ToString());
            }
        }

        private void mncBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Mnc: " + _network.Mnc);
        }

        private void mccBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Mcc: " + _network.Mcc);
        }

        private void lacBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Lac: " + _network.Lac);
        }

        private void cellBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Cell ID: " + _network.CellId);
        }
    }
}
