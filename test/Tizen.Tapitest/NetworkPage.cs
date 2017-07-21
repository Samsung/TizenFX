using Xamarin.Forms;
using Tizen.Tapi;
using System;
using Tizen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinForTizen.Tizen
{
    public class NetworkPage : ContentPage
    {
        Network network = null;
        double height = 62.0;
        Notification[] arrNoti = { Notification.NetworkCellInfo, Notification.NetworkRegistrationStatus, Notification.NetworkIdentity, Notification.NetworkChange, Notification.NetworkDefaultDataSubscription, Notification.NetworkDefaultSubscription };
        Property[] arrProp = { Property.NetworkCellId, Property.NetworkSignalLevel, Property.NetworkPsType, Property.NetworkName, Property.NetworkCircuitStatus,
                                Property.NetworkNameOption, Property.NetworkPlmn, Property.NetworkServiceType, Property.NetworkPacketStatus};
        public NetworkPage()
        {
            try
            {
                network = new Network(Globals.handleModem0);
                RegisterNwEvents(Globals.handleModem0);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Network constructor throws exception = " + ex.ToString());
            }

            var searchNwBtn = new Button
            {
                Text = "SearchNetwork",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            searchNwBtn.Clicked += SearchNwBtn_Clicked;

            var selectAutoNwBtn = new Button
            {
                Text = "SelectAutoNetwork",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            selectAutoNwBtn.Clicked += SelectAutoNwBtn_Clicked;

            var selectManualNwBtn = new Button
            {
                Text = "SelectManualNetwork",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            selectManualNwBtn.Clicked += SelectManualNwBtn_Clicked;

            var getNwModeBtn = new Button
            {
                Text = "GetNetworkSelectionMode",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            getNwModeBtn.Clicked += GetNwModeBtn_Clicked;

            var getPrefPlmnBtn = new Button
            {
                Text = "GetPreferredPlmn",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            getPrefPlmnBtn.Clicked += GetPrefPlmnBtn_Clicked;

            var setPrefPlmnBtn = new Button
            {
                Text = "SetPreferredPlmn",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            setPrefPlmnBtn.Clicked += SetPrefPlmnBtn_Clicked;

            var cancelSearchBtn = new Button
            {
                Text = "CancelSearch",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            cancelSearchBtn.Clicked += CancelSearchBtn_Clicked;

            var getServBtn = new Button
            {
                Text = "GetNetworkServing",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            getServBtn.Clicked += GetServBtn_Clicked;

            var setgetModeBtn = new Button
            {
                Text = "SetGetNetworkMode",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            setgetModeBtn.Clicked += SetGetModeBtn_Clicked;

            var getNeighborBtn = new Button
            {
                Text = "GetNeighborCell",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            getNeighborBtn.Clicked += GetNeighborBtn_Clicked;

            var setemergencyBtn = new Button
            {
                Text = "SetEmergency",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            setemergencyBtn.Clicked += SetEmergencyModeBtn_Clicked;

            var setgetRoamPrefBtn = new Button
            {
                Text = "SetGetRoamPreference",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            setgetRoamPrefBtn.Clicked += SetGetRoamPrefBtn_Clicked;

            var setgetDataSubsBtn = new Button
            {
                Text = "SetGetDefaultDataSubscription",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            setgetDataSubsBtn.Clicked += SetGetDataSubsBtn_Clicked;

            var setgetNwSubsBtn = new Button
            {
                Text = "SetGetDefaultSubscription",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = height
            };
            setgetNwSubsBtn.Clicked += SetGetNwSubsBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        searchNwBtn, selectAutoNwBtn, selectManualNwBtn, getNwModeBtn, getPrefPlmnBtn, setPrefPlmnBtn, cancelSearchBtn , getServBtn ,
                        setgetModeBtn, getNeighborBtn, setemergencyBtn, setgetRoamPrefBtn, setgetDataSubsBtn, setgetNwSubsBtn
                    }
            };
        }

        private void RegisterNwEvents(TapiHandle handle)
        {
            handle.PropertyChanged += Handle_NwPropertyChanged;

            handle.NotificationChanged += Handle_NwNotificationChanged;
            foreach (Notification i in arrNoti)
            {
                handle.RegisterNotiEvent(i);
            }

            foreach (Property i in arrProp)
            {
                handle.RegisterPropEvent(i);
            }
        }

        private void Handle_NwNotificationChanged(object sender, NotificationChangedEventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Handle_NwNotificationChanged event receive, Notification Value = " + e.Id);
                switch (e.Id)
                {
                    case Notification.NetworkCellInfo:
                        NetworkCellNoti data = (NetworkCellNoti)e.Data;
                        Log.Debug(Globals.LogTag, "NetworkCellInfo event receive, Lac = " + data.Lac + ", cell id = " + data.CellId);
                        break;
                    case Notification.NetworkRegistrationStatus:
                        NetworkRegistrationStatus status = (NetworkRegistrationStatus)e.Data;
                        Log.Debug("NetworkRegistrationStatus event receive , circuit status = ", status.CircuitStatus + ", isroaming = " + status.IsRoaming + ", packetstatus = " + status.PacketStatus + ", type = " + status.Type);
                        break;
                    case Notification.NetworkIdentity:
                        NetworkIdentityNoti noti = (NetworkIdentityNoti)e.Data;
                        Log.Debug("NetworkIdentity event receive , fullname = ", noti.FullName + ", plmn = " + noti.Plmn + ", shortname = " + noti.ShortName);
                        break;
                    case Notification.NetworkChange:
                        NetworkChangeNoti changeNoti = (NetworkChangeNoti)e.Data;
                        Log.Debug("NetworkChange event receive , plmn = ", changeNoti.Plmn + ", act = " + changeNoti.Act);
                        break;
                    case Notification.NetworkDefaultDataSubscription:
                        Log.Debug(Globals.LogTag, "NetworkDefaultDataSubscription event receive, data = " + e.Data);
                        break;
                    case Notification.NetworkDefaultSubscription:
                        Log.Debug(Globals.LogTag, "NetworkDefaultSubscription event receive, data = " + e.Data);
                        break;
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Handle_NwNotificationChanged event exception = " + ex.ToString());
            }
        }

        private void Handle_NwPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Handle_NwPropertyChanged property receive, Property Value = " + e.Property);
                switch (e.Property)
                {
                    case Property.NetworkSignalLevel:
                        Log.Debug(Globals.LogTag, "NetworkSignalLevel property receive, data = " + e.Data);
                        break;
                    case Property.NetworkPsType:
                        Log.Debug(Globals.LogTag, "NetworkPsType property receive, data = " + e.Data);
                        break;
                    case Property.NetworkCellId:
                        Log.Debug(Globals.LogTag, "NetworkCellId property receive, data = " + (uint)e.Data);
                        break;
                    case Property.NetworkCircuitStatus:
                        Log.Debug(Globals.LogTag, "NetworkCircuitStatus property receive, data = " + e.Data);
                        break;
                    case Property.NetworkPacketStatus:
                        Log.Debug(Globals.LogTag, "NetworkPacketStatus property receive, data = " + e.Data);
                        break;
                    case Property.NetworkPlmn:
                        Log.Debug(Globals.LogTag, "NetworkPacketStatus property receive, data = " + e.Data);
                        break;
                    case Property.NetworkName:
                        Log.Debug(Globals.LogTag, "NetworkName property receive, data = " + e.Data);
                        break;
                    case Property.NetworkNameOption:
                        Log.Debug(Globals.LogTag, "NetworkNameOption property receive, data = " + e.Data);
                        break;
                    case Property.NetworkServiceType:
                        Log.Debug(Globals.LogTag, "NetworkServiceType property receive, data = " + e.Data);
                        break;
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Handle_NwPropertyChanged event exception = " + ex.ToString());
            }
        }

        private async void SearchNwBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "SearchNetwork start");
                NetworkPlmnList list = await network.SearchNetwork();
                if (list != null)
                {
                    Log.Debug(Globals.LogTag, "SearchNetwork list is not null");
                    Log.Debug(Globals.LogTag, "nwcount = " + list.NetworkCount);
                    List<NetworkIdentity> idList = list.NetworkList.ToList();
                    foreach (NetworkIdentity i in idList)
                    {
                        Log.Debug(Globals.LogTag, "name = " + i.Name);
                        Log.Debug(Globals.LogTag, "plmn = " + i.Plmn);
                        Log.Debug(Globals.LogTag, "plmnid = " + i.PlmnId);
                        Log.Debug(Globals.LogTag, "plmntype = " + i.PlmnType);
                        Log.Debug(Globals.LogTag, "serviceprovidername = " + i.ServiceProviderName);
                        Log.Debug(Globals.LogTag, "system type = " + i.SystemType);
                    }
                }

                Log.Debug(Globals.LogTag, "SearchNetwork end");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "SearchNetwork ,exception = " + ex.ToString());
            }
        }

        private async void SetPrefPlmnBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "SetNetworkPreferredPlmn start");
                var action = await DisplayActionSheet("Operation", "Cancel", null, Enum.GetNames(typeof(NetworkPreferredPlmnOp)));
                Log.Debug(Globals.LogTag, "Action: " + action);
                if (action != null)
                {
                    NetworkPreferredPlmnOp operation = (NetworkPreferredPlmnOp)Enum.Parse(typeof(NetworkPreferredPlmnOp), action);
                    if (operation == NetworkPreferredPlmnOp.Add)
                    {
                        NetworkPreferredPlmnInfo info = new NetworkPreferredPlmnInfo();
                        info.Index = 0;
                        info.Plmn = "45000";
                        info.SystemType = NetworkSystemType.Gsm;
                        info.NetworkName = "AAA";
                        info.ServiceProviderName = "A";
                        await network.SetNetworkPreferredPlmn(operation, info);
                    }
                    else
                    {
                        IEnumerable<NetworkPreferredPlmnInfo> infoList = await network.GetNetworkPreferredPlmn();
                        if (infoList.Count() > 0)
                        {
                            NetworkPreferredPlmnInfo info = infoList.First();
                            await network.SetNetworkPreferredPlmn(operation, info);
                        }
                    }
                }

                Log.Debug(Globals.LogTag, "SetNetworkPreferredPlmn end");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "SetNetworkPreferredPlmn ,exception = " + ex.ToString());
            }
        }

        private async void GetPrefPlmnBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "GetNetworkPreferredPlmn start");
                IEnumerable<NetworkPreferredPlmnInfo> infoList = await network.GetNetworkPreferredPlmn();
                Log.Debug(Globals.LogTag, "GetNetworkPreferredPlmn count = " + infoList.Count());
                if (infoList.Count() > 0)
                {
                    List<NetworkPreferredPlmnInfo> data = infoList.ToList();
                    foreach (NetworkPreferredPlmnInfo info in data)
                    {
                        Log.Debug(Globals.LogTag, "plmn = " + info.Plmn + " index = " + info.Index + " type = " + info.SystemType + " nwname = " + info.NetworkName);
                    }
                }

                Log.Debug(Globals.LogTag, "GetNetworkPreferredPlmn end");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "GetNetworkPreferredPlmn ,exception = " + ex.ToString());
            }
        }

        private async void GetNwModeBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "GetNetworkSelectionMode start");
                NetworkSelectionMode mode = await network.GetNetworkSelectionMode();
                Log.Debug(Globals.LogTag, "GetNetworkSelectionMode end , mode = " + mode);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "GetNetworkSelectionMode ,exception = " + ex.ToString());
            }
        }

        private async void SelectManualNwBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                string plmn = Globals.handleModem0.GetStringProperty(Property.NetworkPlmn);
                int act = Globals.handleModem0.GetIntProperty(Property.NetworkAct);

                Log.Debug(Globals.LogTag, "SelectNetworkManual start --" + plmn + " , " + act);
                await network.SelectNetworkManual(plmn, act);
                Log.Debug(Globals.LogTag, "SelectNetworkManual end");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "SelectNetworkManual ,exception = " + ex.ToString());
            }
        }

        private async void SelectAutoNwBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "SelectNetworkAutomatic start");
                await network.SelectNetworkAutomatic();
                Log.Debug(Globals.LogTag, "SelectNetworkAutomatic end");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "SelectNetworkAutomatic ,exception = " + ex.ToString());
            }
        }

        private async void GetServBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "GetNetworkServing start");
                NetworkServing serving = await network.GetNetworkServing();
                Log.Debug(Globals.LogTag, "GetNetworkServing , plmn = "+serving.Plmn + ",type = "+serving.SystemType);
                NetworkAreaInfo info = serving.AreaInfo;
                Log.Debug(Globals.LogTag, "areainfo , Lac = " + info.Lac);
                NetworkCdmaSysInfo cdmaInfo = info.CdmaInfo;
                if (cdmaInfo != null)
                {
                    Log.Debug(Globals.LogTag, "cdmainfo, basestationid = " + cdmaInfo.BaseStationId + ",basestnlati= "+ cdmaInfo.BaseStationLatitude + ",basestnlongi= " + cdmaInfo.BaseStationLongitude+ ",carrier= " + cdmaInfo.Carrier +
                        ",id= " + cdmaInfo.NetworkId + ",regzone= " + cdmaInfo.RegistrationZone + ",sysid= " + cdmaInfo.SystemId + ",offset= " + cdmaInfo.PilotOffset);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "GetNetworkServing ,exception = " + ex.ToString());
            }
        }

        private async void SetGetModeBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Set and get NetworkMode start");
                var action = await DisplayActionSheet("Operation", "Cancel", null, Enum.GetNames(typeof(NetworkMode)));
                Log.Debug(Globals.LogTag, "Action: " + action);
                if (action != null)
                {
                    NetworkMode mode = (NetworkMode)Enum.Parse(typeof(NetworkMode), action);
                    await network.SetNetworkMode(mode);
                    NetworkMode curMode = await network.GetNetworkMode();
                    if (curMode == mode)
                    {
                        Log.Debug(Globals.LogTag, "Set and get NetworkMode is success, currentmode = " + curMode);
                    }

                    else
                    {
                        Log.Debug(Globals.LogTag, "Set and get NetworkMode has failed, currentmode = " + curMode + ", while the network mode was set to " +mode);
                    }
                }

            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Set and Get NetworkMode ,exception = " + ex.ToString());
            }
        }

        private async void GetNeighborBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "GetNeighborCellNetwork start");
                NetworkNeighboringCell cell = await network.GetNeighborCellNetwork();
                NetworkServingCell servcell = cell.ServingCell;
                List<NetworkGeranCell> geranlist =  cell.GeranList.ToList();
                List<NetworkLteCell> ltelist = cell.LteList.ToList();
                List<NetworkUmtsCell> umtslist = cell.UmtsList.ToList();
                Log.Debug(Globals.LogTag, "NetworkServingCell, type = " + servcell.SystemType + ",mobilecountrycode = " + servcell.MobileCountryCode + ",mobilenetworkcode = " + servcell.MobileNetworkCode);
                global::Tizen.Tapi.Cell info = servcell.CellInfo;
                if (info != null)
                {
                    Log.Debug(Globals.LogTag, "geraninfo, lac = " + info.GeranCell.Lac + ",cellid= " + info.GeranCell.CellId + ",bsic= " + info.GeranCell.Bsic  +
                        ",rxlev= " + info.GeranCell.Rxlev + ",bcch= " + info.GeranCell.Bcch);
                    Log.Debug(Globals.LogTag, "lteinfo, earfcn = " + info.LteCell.Earfcn + ",cellid= " + info.LteCell.CellId + ",physicalid= " + info.LteCell.PhysicalId +
                        ",rssi= " + info.LteCell.Rssi + ",tac = " + info.LteCell.Tac);
                    Log.Debug(Globals.LogTag, "umtsinfo, arfcn = " + info.UmtsCell.Arfcn + ",cellid= " + info.UmtsCell.CellId + ",lac= " + info.UmtsCell.Lac +
                        ",psc= " + info.UmtsCell.Psc + ",rscp= " + info.UmtsCell.Rscp);
                }

                foreach (NetworkGeranCell c in geranlist)
                {
                    Log.Debug(Globals.LogTag, "geraninfo, lac = " + c.Lac + ",cellid= " + c.CellId + ",bsic= " + c.Bsic + ",rxlev= " + c.Rxlev + ",bcch= " + c.Bcch);
                }
                foreach (NetworkLteCell c in ltelist)
                {
                    Log.Debug(Globals.LogTag, "lteinfo, earfcn = " + c.Earfcn + ",cellid= " + c.CellId + ",physicalid= " + c.PhysicalId +
                        ",rssi= " + c.Rssi + ",tac = " + c.Tac);
                }
                foreach (NetworkUmtsCell c in umtslist)
                {
                    Log.Debug(Globals.LogTag, "umtsinfo, arfcn = " + c.Arfcn + ",cellid= " + c.CellId + ",lac= " + c.Lac +
                        ",psc= " + c.Psc + ",rscp= " + c.Rscp);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "GetNeighborCellNetwork ,exception = " + ex.ToString());
            }
        }
        private async void CancelSearchBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "CancelNetworkManualSearch start");
                await network.CancelNetworkManualSearch();
                Log.Debug(Globals.LogTag, "CancelNetworkManualSearch end");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "CancelNetworkManualSearch ,exception = " + ex.ToString());
            }
        }

        private async void SetEmergencyModeBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "SetEmergencyCallbackMode start");
                var action = await DisplayActionSheet("Operation", "Cancel", null, Enum.GetNames(typeof(NetworkEmergencyCallbackMode)));
                Log.Debug(Globals.LogTag, "Action: " + action);
                if (action != null)
                {
                    NetworkEmergencyCallbackMode mode = (NetworkEmergencyCallbackMode)Enum.Parse(typeof(NetworkEmergencyCallbackMode), action);
                    await network.SetEmergencyCallbackMode(mode);
                    Log.Debug(Globals.LogTag, "SetEmergencyCallbackMode ends");
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "SetEmergencyCallbackMode ,exception = " + ex.ToString());
            }
        }
        private async void SetGetRoamPrefBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Set and get roaming preference start");
                var action = await DisplayActionSheet("Operation", "Cancel", null, Enum.GetNames(typeof(NetworkPreferred)));
                Log.Debug(Globals.LogTag, "Action: " + action);
                if (action != null)
                {
                    NetworkPreferred mode = (NetworkPreferred)Enum.Parse(typeof(NetworkPreferred), action);
                    await network.SetRoamingPreference(mode);
                    NetworkPreferred curMode = await network.GetRoamingPreference();
                    if (curMode == mode)
                    {
                        Log.Debug(Globals.LogTag, "Set and get roaming preference is success, currentmode = " + curMode);
                    }

                    else
                    {
                        Log.Debug(Globals.LogTag, "Set and get roaming preference has failed, currentmode = " + curMode + ", while the network mode was set to " + mode);
                    }
                }

            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Set and Get roaming preference ,exception = " + ex.ToString());
            }
        }
        private async void SetGetNwSubsBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Set and get default subscription start");
                await network.SetNetworkDefaultSubscription();
                NetworkDefaultSubscription subs = network.GetNetworkDefaultSubscription();
                Log.Debug(Globals.LogTag, "Set and get default subscription ends, Default subscription is = " + subs);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Set and get default subscription, exception = " + ex.ToString());
            }
        }

        private async void SetGetDataSubsBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Set and get default data subscription start");
                await network.SetDefaultDataSubscription();
                NetworkDefaultDataSubscription subs = network.GetDefaultDataSubscription();
                Log.Debug(Globals.LogTag, "Set and get default data subscription ends, Default subscription is = " + subs);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Set and get default data subscription, exception = " + ex.ToString());
            }
        }
    }
}
