using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Tizen.Tapi;
using Tizen;
using System.Linq;

namespace XamarinForTizen.Tizen
{
    public class CommonPage : ContentPage
    {
        List<string> cplist = new List<string>();
        public CommonPage()
        {
            var cpNameBtn = new Button
            {
                Text = "CPName",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            cpNameBtn.Clicked += cpNameBtn_Clicked;

            var initBtn0 = new Button
            {
                Text = "InitTapimodem0",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            initBtn0.Clicked += initBtn0_Clicked;

            var initBtn1 = new Button
            {
                Text = "InitTapimodem1",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            initBtn1.Clicked += initBtn1_Clicked;

            var deinitBtn0 = new Button
            {
                Text = "DeinitTapimodem0",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            deinitBtn0.Clicked += deinitBtn0_Clicked;

            var deinitBtn1 = new Button
            {
                Text = "DeinitTapimodem1",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            deinitBtn1.Clicked += deinitBtn1_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        cpNameBtn, initBtn0, deinitBtn0, initBtn1, deinitBtn1
                    }
            };
        }

        private void deinitBtn1_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.handleModem1 != null)
                {
                    TapiManager.DeinitTapi(Globals.handleModem1);
                    Log.Debug(Globals.LogTag, "Deinit tapi is successful");
                }
                else
                    Log.Debug(Globals.LogTag, "TapiHandle is null");
                //Get the state of Tapi
                Log.Debug(Globals.LogTag, "Tapi state = " + TapiManager.State);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "inside deinit tapi exception = " + ex.ToString());
            }
        }

        private void deinitBtn0_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.handleModem0 != null)
                {
                    TapiManager.DeinitTapi(Globals.handleModem0);
                    Log.Debug(Globals.LogTag, "Deinit tapi is successful");
                }
                else
                    Log.Debug(Globals.LogTag, "TapiHandle is null");
                //Get the state of Tapi
                Log.Debug(Globals.LogTag, "Tapi state = " + TapiManager.State);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "inside deinit tapi exception = " + ex.ToString());
            }
        }

        private void initBtn1_Clicked(object sender, EventArgs e)
        {
            try
            {
                Globals.handleModem1 = TapiManager.InitTapi(cplist[1]);
                if (Globals.handleModem1 == null)
                    Log.Debug(Globals.LogTag, "Init tapi is not successful and TapiHandle is null");
                else
                    Log.Debug(Globals.LogTag, "Init tapi is successful");
                //Get the state of Tapi
                Log.Debug(Globals.LogTag, "Tapi state = " + TapiManager.State);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "inside init tapi exception = " + ex.ToString());
            }
        }

        private void initBtn0_Clicked(object sender, EventArgs e)
        {
            try
            {
                Globals.handleModem0 = TapiManager.InitTapi(cplist[0]);
                if (Globals.handleModem0 == null)
                    Log.Debug(Globals.LogTag, "Init tapi is not successful and TapiHandle is null");
                else
                    Log.Debug(Globals.LogTag, "Init tapi is successful");
                //Get the state of Tapi
                Log.Debug(Globals.LogTag, "Tapi state = " + TapiManager.State);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "inside init tapi exception = " + ex.ToString());
            }
        }

        private void cpNameBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                cplist = TapiManager.GetCpNames().ToList();
                if (cplist != null)
                {
                    Log.Debug(Globals.LogTag, "inside common button clicked ");
                    for (int i = 0; i < cplist.Count; i++)
                        Log.Debug(Globals.LogTag, "in test code = " + cplist[i]);

                    //Get the state of Tapi
                    Log.Debug(Globals.LogTag, "Tapi state = " + TapiManager.State);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Getcpnames throw exception = " + ex.ToString());
            }
        }
    }
}
