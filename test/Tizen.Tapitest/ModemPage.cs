using System;
using Xamarin.Forms;
using Tizen;
using Tizen.Tapi;
using System.Threading.Tasks;

namespace XamarinForTizen.Tizen
{
    public class ModemPage : ContentPage
    {
        Modem modem = null;
        public ModemPage()
        {
            try
            {
                modem = new Modem(Globals.handleModem0);
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Modem constructor throws exception = " + ex.ToString());
            }

            var processPowerCommandBtn = new Button
            {
                Text = "ProcessPowerCommand",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            processPowerCommandBtn.Clicked += processPowerBtn_Clicked;

            var flightModeBtn = new Button
            {
                Text = "SetGetFlightMode",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            flightModeBtn.Clicked += FlightModeBtn_Clicked;

            var miscMeVersionBtn = new Button
            {
                Text = "GetMiscMeVersion_async_and_sync",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            miscMeVersionBtn.Clicked += MiscVersionBtn_Clicked;

            var miscMeSnBtn = new Button
            {
                Text = "GetMiscMeSn_async_and_sync",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            miscMeSnBtn.Clicked += MiscMeSnBtn_Clicked;

            var miscMeImeiBtn = new Button
            {
                Text = "GetMiscMeImei_async_and_sync",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            miscMeImeiBtn.Clicked += MiscMeImeiBtn_Clicked;

            var checkPowerBtn = new Button
            {
                Text = "CheckPowerStatus",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            checkPowerBtn.Clicked += CheckPowerBtn_Clicked;

            var deviceInfoBtn = new Button
            {
                Text = "GetDeviceInfo",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            deviceInfoBtn.Clicked += DeviceInfoBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        processPowerCommandBtn, flightModeBtn, miscMeVersionBtn, miscMeSnBtn, miscMeImeiBtn, checkPowerBtn, deviceInfoBtn
                    }
            };
        }

        private async void DeviceInfoBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "GetDeviceInfo call start");
                MiscDeviceInfo info = await modem.GetDeviceInfo();
                if (info!= null)
                {
                    Log.Debug(Globals.LogTag, "MiscDeviceInfo data is -- ");
                    Log.Debug(Globals.LogTag, "DeviceName = " + info.DeviceName);
                    Log.Debug(Globals.LogTag, "VendorName = " + info.VendorName);
                }
                Log.Debug(Globals.LogTag, "GetDeviceInfo call end");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Getdeviceinfo ,exception = " + ex.ToString());
            }
        }

        private void CheckPowerBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "CheckPowerStatus call start");
                PhonePowerStatus status = modem.CheckPowerStatus();
                Log.Debug(Globals.LogTag, "power status = " + status);
                Log.Debug(Globals.LogTag, "CheckPowerStatus call end");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "CheckPowerStatus ,exception = " + ex.ToString());
            }
        }

        private async void MiscMeImeiBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "GetMiscMeImei async call start");
                string info = await modem.GetMiscMeImei();
                if (info != null)
                {
                    Log.Debug(Globals.LogTag, "MiscImei number is -- " + info);
                }

                Log.Debug(Globals.LogTag, "GetMiscMeImei async call end");
                Log.Debug(Globals.LogTag, "GetMiscMeImei sync call start");
                string infosync = modem.MiscMeImeiSync;
                if (infosync != null)
                {
                    Log.Debug(Globals.LogTag, "MiscImei number is -- " +infosync);
                }

                Log.Debug(Globals.LogTag, "GetMiscMeImei sync call end");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "GetMiscMeImei ,exception = " + ex.ToString());
            }
        }

        private async void MiscMeSnBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "GetMiscMeSn async call start");
                MiscSerialNumberInformation info = await modem.GetMiscMeSn();
                if (info != null)
                {
                    Log.Debug(Globals.LogTag, "MiscSerialNumberInformation data is -- ");
                    Log.Debug(Globals.LogTag, "Esn = " + info.Esn);
                    Log.Debug(Globals.LogTag, "Imei = " + info.Imei);
                    Log.Debug(Globals.LogTag, "ImeiSv = " + info.ImeiSv);
                    Log.Debug(Globals.LogTag, "Meid = " + info.MeId);
                }

                Log.Debug(Globals.LogTag, "GetMiscMeSn async call end");
                Log.Debug(Globals.LogTag, "GetMiscMeSn sync call start");
                MiscSerialNumberInformation infosync = modem.MiscMeSnSync;
                if (infosync != null)
                {
                    Log.Debug(Globals.LogTag, "MiscSerialNumberInformation data is -- ");
                    Log.Debug(Globals.LogTag, "Esn = " + infosync.Esn);
                    Log.Debug(Globals.LogTag, "Imei = " + infosync.Imei);
                    Log.Debug(Globals.LogTag, "ImeiSv = " + infosync.ImeiSv);
                    Log.Debug(Globals.LogTag, "Meid = " + infosync.MeId);
                }

                Log.Debug(Globals.LogTag, "GetMiscMeSn sync call end");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "GetMiscMeSn ,exception = " + ex.ToString());
            }
        }

        private async void FlightModeBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Modem flightmode call start");
                await modem.SetFlightMode(PowerFlightModeRequest.Enter);
                Log.Debug(Globals.LogTag, "Modem flightmode set Enter success");
                bool isFlightMode = await modem.GetFlightMode();
                Log.Debug(Globals.LogTag, "Modem flightmode get success , flightmode = "+ isFlightMode);
                await modem.SetFlightMode(PowerFlightModeRequest.Leave);
                Log.Debug(Globals.LogTag, "Modem flightmode set Leave success");
                isFlightMode = await modem.GetFlightMode();
                Log.Debug(Globals.LogTag, "Modem flightmode get success , flightmode = " + isFlightMode);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Modem flightmode ,exception = " + ex.ToString());
            }
        }

        private async void processPowerBtn_Clicked(object sender, EventArgs e)
        {
            TapiHandle handle = Globals.handleModem0;
            try
            {
                handle.NotificationChanged += Handle_NotiPowerStatusChanged;
                handle.RegisterNotiEvent(Notification.ModemPower);
                Log.Debug(Globals.LogTag, "Modem powercommand call start");
                await modem.ProcessPowerCommand(PhonePowerCommand.Off);
                Log.Debug(Globals.LogTag, "Modem powercommand call off success");
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Modem processpower command ,exception = " + ex.ToString());
            }

            finally
            {
                handle.DeregisterNotiEvent(Notification.ModemPower);
                handle.NotificationChanged -= Handle_NotiPowerStatusChanged;
            }
        }

        private async void MiscVersionBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "GetMiscMeVersion async call start");
                MiscVersionInformation info = await modem.GetMiscMeVersion();
                if (info!=null)
                {
                    Log.Debug(Globals.LogTag, "MiscVersionInformation data is -- ");
                    Log.Debug(Globals.LogTag, "Version = " + info.VersionMask.ToString());
                    Log.Debug(Globals.LogTag, "CalculationDate = " + info.CalculationDate);
                    Log.Debug(Globals.LogTag, "Erinam = " + info.EriNam.ToString());
                    Log.Debug(Globals.LogTag, "EriVersion = " + info.EriVersion);
                    Log.Debug(Globals.LogTag, "Hwversion = " + info.HwVersion);
                    Log.Debug(Globals.LogTag, "Swversion = " + info.SwVersion);
                    Log.Debug(Globals.LogTag, "ModelId = " + info.ModelId);
                    Log.Debug(Globals.LogTag, "Prlnam = " + info.PrlNam.ToString());
                    Log.Debug(Globals.LogTag, "Prlversion = " + info.PrlVersion);
                    Log.Debug(Globals.LogTag, "Productcode = " + info.ProductCode);
                }

                Log.Debug(Globals.LogTag, "GetMiscMeVersion async call end");
                Log.Debug(Globals.LogTag, "GetMiscMeVersion sync call start");
                MiscVersionInformation infosync = modem.MiscMeVersionSync;
                if (infosync != null)
                {
                    Log.Debug(Globals.LogTag, "MiscVersionInformation data is -- ");
                    Log.Debug(Globals.LogTag, "Version = " + infosync.VersionMask.ToString());
                    Log.Debug(Globals.LogTag, "CalculationDate = " + infosync.CalculationDate);
                    Log.Debug(Globals.LogTag, "Erinam = " + infosync.EriNam.ToString());
                    Log.Debug(Globals.LogTag, "EriVersion = " + infosync.EriVersion);
                    Log.Debug(Globals.LogTag, "Hwversion = " + infosync.HwVersion);
                    Log.Debug(Globals.LogTag, "Swversion = " + infosync.SwVersion);
                    Log.Debug(Globals.LogTag, "ModelId = " + infosync.ModelId);
                    Log.Debug(Globals.LogTag, "Prlnam = " + infosync.PrlNam.ToString());
                    Log.Debug(Globals.LogTag, "Prlversion = " + infosync.PrlVersion);
                    Log.Debug(Globals.LogTag, "Productcode = " + infosync.ProductCode);
                }

                Log.Debug(Globals.LogTag, "GetMiscMeVersion sync call end");
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "GetMiscMeVersion ,exception = " + ex.ToString());
            }
        }

        private void Handle_PropertyPowerStatusChanged(object sender, PropertyChangedEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Handle_PropertyPowerStatusChanged event receive");
            //Log.Debug(Globals.LogTag, "Handle_PropertyPowerStatusChanged event receive, status = " + e.Data + e.Property);
        }

        private void Handle_NotiPowerStatusChanged(object sender, NotificationChangedEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Handle_NotiPowerStatusChanged event receive, status = " + e.Data + ", Notification Value = " +e.Id);
        }
    }
}
