using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Tizen;
using Tizen.Telephony;

namespace XamarinForTizen.Tizen
{
    public class SimPage : ContentPage
    {
        private static Sim _sim = null;
        public SimPage()
        {
            var changedBtn = new Button
            {
                Text = "Is sim changed",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            changedBtn.Clicked += changedBtn_Clicked;

            var operatorBtn = new Button
            {
                Text = "Get operator",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            operatorBtn.Clicked += operatorBtn_Clicked;

            var iccIdBtn = new Button
            {
                Text = "Get Icc id",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            iccIdBtn.Clicked += iccIdBtn_Clicked;

            var msinBtn = new Button
            {
                Text = "Get Msin",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            msinBtn.Clicked += msinBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        changedBtn, operatorBtn, iccIdBtn, msinBtn
                    }
            };

            try
            {
                if (Globals.slotHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                    return;
                }

                _sim = new Sim(Globals.slotHandle);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Exception in Sim constructor: " + ex.ToString());
            }
        }

        private void msinBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Msin: " + _sim.Msin);
        }

        private void iccIdBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Icc id: " + _sim.IccId);
        }

        private void operatorBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Operator: " + _sim.Operator);
        }

        private void changedBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Is sim changed: " + _sim.IsChanged);
        }
    }
}
