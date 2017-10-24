using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Tizen;
using Tizen.Telephony;

namespace XamarinForTizen.Tizen
{
    public class NetworkPage : ContentPage
    {
        private static Network _network = null;
        private ChangeNotificationEventArgs.Notification[] notiArr = { ChangeNotificationEventArgs.Notification.NetworkBsId,
                                                                       ChangeNotificationEventArgs.Notification.NetworkBsLatitude,
                                                                       ChangeNotificationEventArgs.Notification.NetworkBsLongitude,
                                                                       ChangeNotificationEventArgs.Notification.NetworkCellid,
                                                                       ChangeNotificationEventArgs.Notification.NetworkDefaultDataSubscription,
                                                                       ChangeNotificationEventArgs.Notification.NetworkDefaultSubscription,
                                                                       ChangeNotificationEventArgs.Notification.NetworkId,
                                                                       ChangeNotificationEventArgs.Notification.NetworkLac,
                                                                       ChangeNotificationEventArgs.Notification.NetworkNetworkName,
                                                                       ChangeNotificationEventArgs.Notification.NetworkPsType,
                                                                       ChangeNotificationEventArgs.Notification.NetworkRoamingStatus,
                                                                       ChangeNotificationEventArgs.Notification.NetworkServiceState,
                                                                       ChangeNotificationEventArgs.Notification.NetworkSignalstrengthLevel,
                                                                       ChangeNotificationEventArgs.Notification.NetworkSystemId,
                                                                       ChangeNotificationEventArgs.Notification.NetworkTac };
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

            var nwNameBtn = new Button
            {
                Text = "Get network name",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            nwNameBtn.Clicked += nwNameBtn_Clicked;

            var nwNameOptionBtn = new Button
            {
                Text = "Get network name option",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            nwNameOptionBtn.Clicked += nwNameOptionBtn_Clicked;

            var roamingStatusBtn = new Button
            {
                Text = "Get roaming status",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            roamingStatusBtn.Clicked += roamingStatusBtn_Clicked;

            var rssiBtn = new Button
            {
                Text = "Get RSSI",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            rssiBtn.Clicked += rssiBtn_Clicked;

            var serviceStateBtn = new Button
            {
                Text = "Get service state",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            serviceStateBtn.Clicked += serviceStateBtn_Clicked;

            var typeBtn = new Button
            {
                Text = "Get network type",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            typeBtn.Clicked += typeBtn_Clicked;

            var psTypeBtn = new Button
            {
                Text = "Get PS type",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            psTypeBtn.Clicked += psTypeBtn_Clicked;

            var dataSubsBtn = new Button
            {
                Text = "Get default data subscription",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            dataSubsBtn.Clicked += dataSubsBtn_Clicked;

            var defaultSubsBtn = new Button
            {
                Text = "Get default subscription",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            defaultSubsBtn.Clicked += defaultSubsBtn_Clicked;

            var selectionModeBtn = new Button
            {
                Text = "Get selection mode",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            selectionModeBtn.Clicked += selectionModeBtn_Clicked;

            var tacBtn = new Button
            {
                Text = "Get TAC",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            tacBtn.Clicked += tacBtn_Clicked;

            var systemIdBtn = new Button
            {
                Text = "Get system ID",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            systemIdBtn.Clicked += systemIdBtn_Clicked;

            var nwIdBtn = new Button
            {
                Text = "Get network ID",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            nwIdBtn.Clicked += nwIdBtn_Clicked;

            var baseStationIdBtn = new Button
            {
                Text = "Get base station ID",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            baseStationIdBtn.Clicked += baseStationIdBtn_Clicked;

            var baseStationLongitudeBtn = new Button
            {
                Text = "Get base station longitude",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            baseStationLongitudeBtn.Clicked += baseStationLongitudeBtn_Clicked;

            var baseStationLatitudeBtn = new Button
            {
                Text = "Get base station latitude",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            baseStationLatitudeBtn.Clicked += baseStationLatitudeBtn_Clicked;

            ScrollView scrollView = new ScrollView()
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        cellBtn, lacBtn, mccBtn, mncBtn, nwNameBtn, nwNameOptionBtn, roamingStatusBtn, rssiBtn,
                        serviceStateBtn, typeBtn, psTypeBtn, dataSubsBtn, defaultSubsBtn, selectionModeBtn, tacBtn,
                        systemIdBtn, nwIdBtn, baseStationIdBtn, baseStationLatitudeBtn, baseStationLongitudeBtn
                    }
                },
                VerticalOptions = LayoutOptions.Center
            };

            Content = scrollView;

            try
            {
                if (Globals.slotHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                    return;
                }

                Globals.slotHandle.ChangeNotification += SlotHandle_ChangeNotification;
                List<ChangeNotificationEventArgs.Notification> notiList = new List<ChangeNotificationEventArgs.Notification>();
                foreach (ChangeNotificationEventArgs.Notification noti in notiArr)
                {
                    notiList.Add(noti);
                }

                Globals.slotHandle.SetNotificationId(notiList);
                _network = new Network(Globals.slotHandle);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Exception in network constructor: " + ex.ToString());
            }
        }

        private void SlotHandle_ChangeNotification(object sender, ChangeNotificationEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Change notification: " + e.NotificationType);
        }

        private void baseStationLatitudeBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Base station latitude: " + _network.BaseStationLatitude);
        }

        private void baseStationLongitudeBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Base Station longitude: " + _network.BaseStationLongitude);
        }

        private void baseStationIdBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Base station ID: " + _network.BaseStationId);
        }

        private void nwIdBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Network ID: " + _network.NetworkId);
        }

        private void systemIdBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "System ID: " + _network.SystemId);
        }

        private void tacBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "TAC: " + _network.Tac);
        }

        private void selectionModeBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Selection mode: " + _network.NetworkSelectionMode);
        }

        private void defaultSubsBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Default subscription: " + _network.NetworkDefaultSubscription);
        }

        private void dataSubsBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Default data subscription: " + _network.NetworkDefaultDataSubscription);
        }

        private void psTypeBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Network PS type: " + _network.NetworkPsType);
        }

        private void typeBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Network type: " + _network.NetworkType);
        }

        private void serviceStateBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Network service state: " + _network.NetworkServiceState);
        }

        private void rssiBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Current Rssi: " + _network.CurrentRssi);
        }

        private void roamingStatusBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Roaming status: " + _network.RoamingStatus);
        }

        private void nwNameOptionBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Network name option: " + _network.NetworkNameOption);
        }

        private void nwNameBtn_Clicked(object sender, EventArgs e)
        {
            if (_network == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Network name: " + _network.NetworkName);
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
