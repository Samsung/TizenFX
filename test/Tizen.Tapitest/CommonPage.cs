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

            var getIntPropBtn = new Button
            {
                Text = "GetIntProperty",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getIntPropBtn.Clicked += GetIntPropBtn_Clicked;

            var getStrPropBtn = new Button
            {
                Text = "GetStringProperty",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getStrPropBtn.Clicked += GetStrPropBtn_Clicked;

            var getReadyBtn = new Button
            {
                Text = "GetReadyState",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getReadyBtn.Clicked += GetReadyBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        cpNameBtn, initBtn0, deinitBtn0, initBtn1, deinitBtn1, getIntPropBtn, getStrPropBtn, getReadyBtn
                    }
            };
        }

        private void GetReadyBtn_Clicked(object sender, EventArgs e)
        {
            //Get the state of Tapi
            int s = TapiManager.State;
            if (s == 0)
                Log.Debug(Globals.LogTag, "Tapi state, result = false");
            else if (s == 1)
                Log.Debug(Globals.LogTag, "Tapi state, result = true");
            else
                Log.Debug(Globals.LogTag, "Tapi state, result = " + s);
        }

        private async void GetStrPropBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var action = await DisplayActionSheet("Operation", "Cancel", null, "Network Name", "Network Spn Name", "Network Name Option");
                Log.Debug(Globals.LogTag, "Action: " + action);
                if (action != null)
                {
                    Property p = Property.NetworkPlmn;
                    if (action == "Network Name")
                        p = Property.NetworkName;
                    else if (action == "Network Spn Name")
                        p = Property.NetworkSpnName;
                    else if (action == "Network Name Option")
                        p = Property.NetworkNameOption;
                    if (Globals.handleModem0 != null)
                    {
                        string val = Globals.handleModem0.GetStringProperty(p);
                        Log.Debug(Globals.LogTag, "String property result = " + val);
                    }
                    else if (Globals.handleModem1 != null)
                    {
                        string val = Globals.handleModem1.GetStringProperty(p);
                        Log.Debug(Globals.LogTag, "String property result = " + val);
                    }
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "GetStringProperty tapi exception = " + ex.ToString());
            }
        }

        private async void GetIntPropBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var action = await DisplayActionSheet("Operation", "Cancel", null, "Ps Type", "Power", "Dongle Status");
                Log.Debug(Globals.LogTag, "Action: " + action);
                if (action != null)
                {
                    Property p = Property.NetworkPlmn;
                    if (action == "Ps Type")
                        p = Property.NetworkPsType;
                    else if (action == "Power")
                        p = Property.ModemPower;
                    else if (action == "Dongle Status")
                        p = Property.ModemDongleStatus;
                    if (Globals.handleModem0 != null)
                    {
                        int val = Globals.handleModem0.GetIntProperty(p);
                        Log.Debug(Globals.LogTag, "Int property result = " + val);
                    }
                    else if (Globals.handleModem1 != null)
                    {
                        int val = Globals.handleModem1.GetIntProperty(p);
                        Log.Debug(Globals.LogTag, "Int property result = " + val);
                    }
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "GetIntProperty tapi exception = " + ex.ToString());
            }
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
                        Log.Debug(Globals.LogTag, "Cp name = " + cplist[i]);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Getcpnames throw exception = " + ex.ToString());
            }
        }
    }
}
