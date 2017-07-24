using System;
using Xamarin.Forms;
using Tizen;
using Tizen.Tapi;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinForTizen.Tizen
{
    public class SimPage : ContentPage
    {
        Sim sim = null;
        public SimPage()
        {
            try
            {
                sim = new Sim(Globals.handleModem0);
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim constructor throws exception = " + ex.ToString());
            }

            var SimInitInfoBtn = new Button
            {
                Text = "SimInitInfo",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            SimInitInfoBtn.Clicked += SimInitInfoBtn_Clicked;

            var SimPropertiesBtn = new Button
            {
                Text = "Get sim properties(Type, Imsi, Ecc)",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            SimPropertiesBtn.Clicked += SimPropertiesBtn_Clicked;

            var appListBtn = new Button
            {
                Text = "Get sim application list",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            appListBtn.Clicked += appListBtn_Clicked;

            var iccIdBtn = new Button
            {
                Text = "Get sim ICCID",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            iccIdBtn.Clicked += iccIdBtn_Clicked;

            var langPrefBtn = new Button
            {
                Text = "Set & get sim language preference",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            langPrefBtn.Clicked += langPrefBtn_Clicked;

            var msisdnBtn = new Button
            {
                Text = "Get sim MSISDN",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            msisdnBtn.Clicked += msisdnBtn_Clicked;

            var oplmnwactBtn = new Button
            {
                Text = "Get sim OPLMNWACT",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            oplmnwactBtn.Clicked += oplmnwactBtn_Clicked;

            var spnBtn = new Button
            {
                Text = "Get sim SPN",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            spnBtn.Clicked += spnBtn_Clicked;

            var autnBtn = new Button
            {
                Text = "Sim authentication",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            autnBtn.Clicked += autnBtn_Clicked;

            var powerBtn = new Button
            {
                Text = "Sim change power state",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            powerBtn.Clicked += powerBtn_Clicked;

            var apduBtn = new Button
            {
                Text = "Sim APDU",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            apduBtn.Clicked += apduBtn_Clicked;

            var atrBtn = new Button
            {
                Text = "Sim ATR",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            atrBtn.Clicked += atrBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        SimInitInfoBtn, SimPropertiesBtn, appListBtn, iccIdBtn, langPrefBtn, msisdnBtn, oplmnwactBtn,
                        spnBtn, autnBtn, powerBtn, apduBtn, atrBtn
                    }
            };
        }

        private async void atrBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim request ATR call start");
                SimAtrResponse resp = await sim.SimRequestAtr();
                Log.Debug(Globals.LogTag, "Atr response length: " + resp.AtrRespLength);
                for (int i = 0; i < resp.AtrRespLength; i++)
                {
                    Log.Debug(Globals.LogTag, "[" + i + "]'s byte: [0x" + resp.AtrResponse[i] + "]");
                }

                Log.Debug(Globals.LogTag, "Sim request ATR call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim request ATR exception: " + ex.ToString());
            }
        }

        private async void apduBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim request APDU call start");
                SimApdu apdu = new SimApdu(Encoding.ASCII.GetBytes("0070000000"));
                SimApduResponse resp = await sim.SimRequestApdu(apdu);
                Log.Debug(Globals.LogTag, "Apdu response length: " + resp.ApduLength);
                for (int i = 0; i < resp.ApduLength; i++)
                {
                    Log.Debug(Globals.LogTag, "[" + i + "]'s byte: [0x" + resp.ApduResponse[i] + "]");
                }

                Log.Debug(Globals.LogTag, "Sim request APDU call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim request APDU exception: " + ex.ToString());
            }
        }

        private async void powerBtn_Clicked(object sender, EventArgs e)
        {
            TapiHandle handle = Globals.handleModem0;
            try
            {
                Log.Debug(Globals.LogTag, "Sim set power state call start");
                handle.NotificationChanged += Handle_NotiPowerStateChanged;
                handle.RegisterNotiEvent(Notification.SimStatus);
                bool state = await sim.SimSetPowerState(SimPowerState.Off);
                if (state)
                {
                    await sim.SimSetPowerState(SimPowerState.On);
                }

                Log.Debug(Globals.LogTag, "Sim set power state call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim set power state exception: " + ex.ToString());
            }

            finally
            {
                handle.DeregisterNotiEvent(Notification.SimStatus);
                handle.NotificationChanged -= Handle_NotiPowerStateChanged;
            }
        }

        private void Handle_NotiPowerStateChanged(object sender, NotificationChangedEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Sim status noti event received, Status: " + e.Data + " Noti value: " + e.Id);
        }

        private async void autnBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                SimAuthenticationData authData = new SimAuthenticationData(SimAuthenticationType.Auth3G, 4, 4, Encoding.ASCII.GetBytes("qwerty"), Encoding.ASCII.GetBytes("asdf"));
                Log.Debug(Globals.LogTag, "Sim execute authentication call start");
                SimAuthenticationResponse authResp = await sim.SimExecuteAuthentication(authData);
                Log.Debug(Globals.LogTag, "Response auth type: " + authResp.AuthType);
                Log.Debug(Globals.LogTag, "Response auth result: " + authResp.AuthResult);
                Log.Debug(Globals.LogTag, "Response data: " + authResp.ResponseData);
                Log.Debug(Globals.LogTag, "Auth key: " + authResp.AuthKey);
                Log.Debug(Globals.LogTag, "Cipher data: " + authResp.CipherData);
                Log.Debug(Globals.LogTag, "Integrity data: " + authResp.IntegrityData);
                Log.Debug(Globals.LogTag, "Sim execute authentication call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get SPN exception: " + ex.ToString());
            }
        }

        private async void spnBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get SPN call start");
                SimSpn spn = await sim.SimGetSpn();
                Log.Debug(Globals.LogTag, "SPN display condition: " + spn.DisplayCondition);
                Log.Debug(Globals.LogTag, "SPN name: " + spn.Spn);
                Log.Debug(Globals.LogTag, "Sim get SPN call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get SPN exception: " + ex.ToString());
            }
        }

        private async void oplmnwactBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get oplmnwact call start");
                SimOplmnwactList oplmnwact = await sim.SimGetOplmnwact();
                Log.Debug(Globals.LogTag, "Sim OPLMNWACT count: " + oplmnwact.Count);
                List<SimOplmnwact> oplmnList = oplmnwact.List.ToList();
                for (int i = 0; i < oplmnwact.Count; i++)
                {
                    Log.Debug(Globals.LogTag, "Oplmn.list[" + i + "].Plmn: " + oplmnList[i].Plmn);
                    Log.Debug(Globals.LogTag, "Oplmn.list[" + i + "].IsUmt: " + oplmnList[i].IsUmts);
                    Log.Debug(Globals.LogTag, "Oplmn.list[" + i + "].IsGsm: " + oplmnList[i].IsGsm);
                }

                Log.Debug(Globals.LogTag, "Sim get oplmnwact call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get oplmnwact exception: " + ex.ToString());
            }
        }

        private async void msisdnBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get msisdn call start");
                SimMsisdnList msisdn = await sim.SimGetMsisdn();
                Log.Debug(Globals.LogTag, "Sim MSISDN count: " + msisdn.Count);
                List<SimSubscriberInfo> subs = msisdn.List.ToList();
                for (int i = 0; i < msisdn.Count; i++)
                {
                    Log.Debug(Globals.LogTag, "Msisdn.list[" + i + "].Number: " + subs[i].Number);
                    Log.Debug(Globals.LogTag, "Msisdn.list[" + i + "].Name: " +subs[i].Name);
                }

                Log.Debug(Globals.LogTag, "Sim get msisdn call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get msisdn exception: " + ex.ToString());
            }
        }

        private async void langPrefBtn_Clicked(object sender, EventArgs e)
        {
            SimLanguagePreference current = await sim.SimGetLanguagePreference();
            try
            {
                Log.Debug(Globals.LogTag, "Sim get language preference call start");
                foreach (SimLanguagePreference pref in Enum.GetValues(typeof(SimLanguagePreference)))
                {
                    if (pref == SimLanguagePreference.Unspecified)
                    {
                        break;
                    }

                    Log.Debug(Globals.LogTag, "Setting sim language preference with " + pref);
                    bool setFlag = await sim.SimSetLanguagePreference(pref);
                    if (setFlag)
                    {
                        Log.Debug(Globals.LogTag, "Current sim language preference: " + await sim.SimGetLanguagePreference());
                    }
                }

                Log.Debug(Globals.LogTag, "Sim get language preference call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get language preference exception: " + ex.ToString());
            }

            finally
            {
                await sim.SimSetLanguagePreference(current);
            }
        }

        private async void iccIdBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get ICC ID call start");
                SimIccIdInfo info = await sim.SimGetIccId();
                if (info == null)
                {
                    Log.Debug(Globals.LogTag, "Sim icc id info is null");
                    return;
                }

                Log.Debug(Globals.LogTag, "Sim ICC ID length: " + info.IccLength);
                Log.Debug(Globals.LogTag, "Sim ICC ID: " + info.IccNumber);
                Log.Debug(Globals.LogTag, "Sim get ICC ID call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get ICC ID exception: " + ex.ToString());
            }
        }

        private void appListBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get app list call start");
                byte app = sim.SimGetApplicationList();
                Log.Debug(Globals.LogTag, "Sim app list: " + app);
                if ((app & (byte)SimAppType.Sim) != 0)
                {
                    Log.Debug(Globals.LogTag, "[SIM]");
                }

                if ((app & (byte)SimAppType.Usim) != 0)
                {
                    Log.Debug(Globals.LogTag, "[USIM]");
                }

                if ((app & (byte)SimAppType.Csim) != 0)
                {
                    Log.Debug(Globals.LogTag, "[CSIM]");
                }

                if ((app & (byte)SimAppType.Isim) != 0)
                {
                    Log.Debug(Globals.LogTag, "[ISIM]");
                }

                Log.Debug(Globals.LogTag, "Sim get app list call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get app list exception: " + ex.ToString());
            }
        }

        private void SimPropertiesBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim type call start");
                Log.Debug(Globals.LogTag, "Sim card type: " + sim.SimType);
                Log.Debug(Globals.LogTag, "Sim type call success");

                Log.Debug(Globals.LogTag, "Sim imsi info call start");
                SimImsiInfo imsi = sim.Imsi;
                if (imsi == null)
                {
                    Log.Debug(Globals.LogTag, "Imsi info is null");
                    return;
                }

                Log.Debug(Globals.LogTag, "Sim Mcc: " + imsi.Mcc);
                Log.Debug(Globals.LogTag, "Sim Mnc: " + imsi.Mnc);
                Log.Debug(Globals.LogTag, "Sim Msin: " + imsi.Msin);
                Log.Debug(Globals.LogTag, "Sim imsi info call success");

                Log.Debug(Globals.LogTag, "Sim ecc info call start");
                SimEccInfoList eccList = sim.Ecc;
                Log.Debug(Globals.LogTag, "Sim ECC count: " + eccList.Count);
                List<SimEccInfo> ecc = eccList.EccList.ToList();
                for (int i = 0; i < eccList.Count; i++)
                {
                    Log.Debug(Globals.LogTag, "EccList.list[" + i + "].Name: " + ecc[i].Name);
                    Log.Debug(Globals.LogTag, "EccList.list[" + i + "].Number: " + ecc[i].Number);
                    Log.Debug(Globals.LogTag, "EccList.list[" + i + "].Category: " + ecc[i].Category);
                }

                Log.Debug(Globals.LogTag, "Sim ecc info call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get properties exception: " + ex.ToString());
            }
        }

        private void SimInitInfoBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim init info call start");
                SimInitInfo info = sim.InitInfo;
                if (info == null)
                {
                    Log.Debug(Globals.LogTag, "Sim init info is null");
                    return;
                }

                Log.Debug(Globals.LogTag, "Sim status: " + info.Status);
                Log.Debug(Globals.LogTag, "Sim card changed flag: " + info.IsCardChanged);
                Log.Debug(Globals.LogTag, "Sim init info call success");
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim init info exception: " + ex.ToString());
            }
        }
    }
}
