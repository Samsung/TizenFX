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

            var getCfBtn = new Button
            {
                Text = "Get call forward info",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getCfBtn.Clicked += getCfBtn_Clicked;

            var getMwBtn = new Button
            {
                Text = "Get message waiting info",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getMwBtn.Clicked += getMwBtn_Clicked;

            var getMbBtn = new Button
            {
                Text = "Get mailbox info",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getMbBtn.Clicked += getMbBtn_Clicked;

            var getCphsBtn = new Button
            {
                Text = "Get CPHS info",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getCphsBtn.Clicked += getCphsBtn_Clicked;

            var getCphsNetNameBtn = new Button
            {
                Text = "Get CPHS operator name",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getCphsNetNameBtn.Clicked += getCphsNetNameBtn_Clicked;

            var getFacilityBtn = new Button
            {
                Text = "Get sim facility",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getFacilityBtn.Clicked += getFacilityBtn_Clicked;

            var getLockInfoBtn = new Button
            {
                Text = "Get sim lock status",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getLockInfoBtn.Clicked += getLockInfoBtn_Clicked;

            var getImpiBtn = new Button
            {
                Text = "Get sim IMPI",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getImpiBtn.Clicked += getImpiBtn_Clicked;

            var getImpuBtn = new Button
            {
                Text = "Get sim IMPU",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getImpuBtn.Clicked += getImpuBtn_Clicked;

            var getDomainBtn = new Button
            {
                Text = "Get sim domain",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getDomainBtn.Clicked += getDomainBtn_Clicked;

            var getPcscfBtn = new Button
            {
                Text = "Get sim P-CSCF",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getPcscfBtn.Clicked += getPcscfBtn_Clicked;

            var getIsimSvcTableBtn = new Button
            {
                Text = "Get ISIM service table",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getIsimSvcTableBtn.Clicked += getIsimSvcTableBtn_Clicked;

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

            ScrollView scrollView = new ScrollView()
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        SimInitInfoBtn, SimPropertiesBtn, appListBtn, iccIdBtn, langPrefBtn, getCfBtn, getCphsBtn, getMbBtn,
                        getMwBtn, getCphsNetNameBtn, getFacilityBtn, getLockInfoBtn, getImpiBtn, getImpuBtn, getDomainBtn,
                        getPcscfBtn, getIsimSvcTableBtn, msisdnBtn, oplmnwactBtn, spnBtn, autnBtn, powerBtn, apduBtn, atrBtn
                    }
                },
                VerticalOptions = LayoutOptions.Center
            };
            Content = scrollView;
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

        private async void getIsimSvcTableBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get ISIM service table start");
                Log.Debug(Globals.LogTag, "ISIM service: " + Encoding.UTF8.GetString(await sim.SimGetIsimServiceTable()));
                Log.Debug(Globals.LogTag, "Sim get ISIM service table success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get ISIM service table exception: " + ex.ToString());
            }
        }

        private async void getPcscfBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get P-CSCF start");
                SimPcscfList pcsf = await sim.SimGetPcscf();
                Log.Debug(Globals.LogTag, "Data count: " + pcsf.Count);
                List<SimPcscf> list = pcsf.List.ToList();
                for (int i = 0; i < pcsf.Count; i++)
                {
                    Log.Debug(Globals.LogTag, "PcscfList[" + i + "].Type: " + list[i].Type);
                    Log.Debug(Globals.LogTag, "PcscfList[" + i + "].Data: " + list[i].Pcscf);
                }

                Log.Debug(Globals.LogTag, "Sim get P-CSCF success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get P-CSCF exception: " + ex.ToString());
            }
        }

        private async void getDomainBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get domain start");
                Log.Debug(Globals.LogTag, "Domain: " + await sim.SimGetDomain());
                Log.Debug(Globals.LogTag, "Sim get domain success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get domain exception: " + ex.ToString());
            }
        }

        private async void getImpuBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get IMPU start");
                SimImpuList impu = await sim.SimGetImpu();
                Log.Debug(Globals.LogTag, "Data count: " + impu.Count);
                List<string> list = impu.List.ToList();
                for (int i = 0; i < impu.Count; i++)
                {
                    Log.Debug(Globals.LogTag, "Data count[" + i + "]: " + list[i]);
                }

                Log.Debug(Globals.LogTag, "Sim get IMPU success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get IMPU exception: " + ex.ToString());
            }
        }

        private async void getImpiBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get IMPI start");
                string impi = await sim.SimGetImpi();
                Log.Debug(Globals.LogTag, "IMPI: " + impi);
                Log.Debug(Globals.LogTag, "Sim get IMPI success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get IMPI exception: " + ex.ToString());
            }
        }

        private async void getLockInfoBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get lock status start");
                SimLockInfo info = await sim.SimGetLockInfo(SimLockType.PS);
                Log.Debug(Globals.LogTag, "Lock type: " + info.Type);
                Log.Debug(Globals.LogTag, "Status: " + info.Status);
                Log.Debug(Globals.LogTag, "Retry counts: " + info.RetryCount);
                Log.Debug(Globals.LogTag, "Sim get lock status success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get lock status exception: " + ex.ToString());
            }
        }

        private async void getFacilityBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get facility start");
                SimFacilityInfo info = await sim.SimGetFacility(SimLockType.PS);
                Log.Debug(Globals.LogTag, "Lock type: " + info.Type);
                Log.Debug(Globals.LogTag, "Status: " + info.Status);
                Log.Debug(Globals.LogTag, "Sim get facility success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get facility exception: " + ex.ToString());
            }
        }

        private async void getCphsNetNameBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get CPHS net name start");
                SimCphsNetName name = await sim.SimGetCphsNetName();
                Log.Debug(Globals.LogTag, "Full name: " + name.FullName);
                Log.Debug(Globals.LogTag, "Short name: " + name.ShortName);
                Log.Debug(Globals.LogTag, "Sim get CPHS net name success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get CPHS net name exception: " + ex.ToString());
            }
        }

        private async void getCphsBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get CPHS info start");
                SimCphsInfo info = await sim.SimGetCphsInfo();
                Log.Debug(Globals.LogTag, "CPHS phase: " + info.CphsPhase);
                Log.Debug(Globals.LogTag, "CPHS CSP: " + info.CphsServiceTable.CustomerServiceProfile);
                Log.Debug(Globals.LogTag, "CPHS SST: " + info.CphsServiceTable.ServiceStringTable);
                Log.Debug(Globals.LogTag, "CPHS Mailboxnumbers: " + info.CphsServiceTable.MailboxNumbers);
                Log.Debug(Globals.LogTag, "CPHS Operator short form name: " + info.CphsServiceTable.OperatorNameShortForm);
                Log.Debug(Globals.LogTag, "CPHS information numbers: " + info.CphsServiceTable.InformationNumbers);
                Log.Debug(Globals.LogTag, "Sim get CPHS info success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get CPHS info exception: " + ex.ToString());
            }
        }

        private async void getMbBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get mailbox info start");
                SimMailboxList mbList = await sim.SimGetMailboxInfo();
                Log.Debug(Globals.LogTag, "Mb count: " + mbList.Count);
                List<SimMailboxNumber> list = mbList.List.ToList();
                for (int i = 0; i < mbList.Count; i++)
                {
                    Log.Debug(Globals.LogTag, "MbList[" + i + "].IsCphs: " + list[i].IsCphs);
                    Log.Debug(Globals.LogTag, "MbList[" + i + "].RecIndex: " + list[i].RecIndex);
                    Log.Debug(Globals.LogTag, "MbList[" + i + "].ProfileNumber: " + list[i].ProfileNumber);
                    Log.Debug(Globals.LogTag, "MbList[" + i + "].MbType: " + list[i].MbType);
                    Log.Debug(Globals.LogTag, "MbList[" + i + "].AlphaMaxLength: " + list[i].AlphaMaxLength);
                    Log.Debug(Globals.LogTag, "MbList[" + i + "].AlphaId: " + list[i].AlphaId);
                    Log.Debug(Globals.LogTag, "MbList[" + i + "].Ton: " + list[i].Ton);
                    Log.Debug(Globals.LogTag, "MbList[" + i + "].Npi: " + list[i].Npi);
                    Log.Debug(Globals.LogTag, "MbList[" + i + "].Number: " + list[i].Number);
                    Log.Debug(Globals.LogTag, "MbList[" + i + "].CcId: " + list[i].CcId);
                    Log.Debug(Globals.LogTag, "MbList[" + i + "].Ext1Id: " + list[i].Ext1Id);
                }

                Log.Debug(Globals.LogTag, "Sim get mailbox info success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get mailbox info exception: " + ex.ToString());
            }
        }

        private async void getMwBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get message waiting info start");
                SimMessageWaitingResponse resp = await sim.SimGetMessageWaitingInfo();
                Log.Debug(Globals.LogTag, "Is CPHS: " + resp.IsCphs);
                Log.Debug(Globals.LogTag, "MWIS profile count: " + resp.MwList.ProfileCount);
                List<SimMwis> mwis = resp.MwList.MwList.ToList();
                for (int i = 0; i < resp.MwList.ProfileCount; i++)
                {
                    Log.Debug(Globals.LogTag, "MWisList[" + i + "].RecIndex: " + mwis[i].RecIndex);
                    Log.Debug(Globals.LogTag, "MWisList[" + i + "].IndicatorStatus: " + mwis[i].IndicatorStatus);
                    Log.Debug(Globals.LogTag, "MWisList[" + i + "].VoiceCount: " + mwis[i].VoiceCount);
                    Log.Debug(Globals.LogTag, "MWisList[" + i + "].FaxCount: " + mwis[i].FaxCount);
                    Log.Debug(Globals.LogTag, "MWisList[" + i + "].EmailCount: " + mwis[i].EmailCount);
                    Log.Debug(Globals.LogTag, "MWisList[" + i + "].OtherCount: " + mwis[i].OtherCount);
                    Log.Debug(Globals.LogTag, "MWisList[" + i + "].VideoCount: " + mwis[i].VideoCount);
                }

                Log.Debug(Globals.LogTag, "CPHSMW.Voice1: " + resp.CphsMw.IsVoice1);
                Log.Debug(Globals.LogTag, "CPHSMW.Voice2: " + resp.CphsMw.IsVoice2);
                Log.Debug(Globals.LogTag, "CPHSMW.Fax: " + resp.CphsMw.IsFax);
                Log.Debug(Globals.LogTag, "CPHSMW.Data: " + resp.CphsMw.IsData);
                Log.Debug(Globals.LogTag, "Sim get message waiting info success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get message waiting info exception: " + ex.ToString());
            }
        }

        private async void getCfBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Sim get call forward info start");
                SimCallForwardResponse resp = await sim.SimGetCallForwardInfo();
                Log.Debug(Globals.LogTag, "Is CPHS: " + resp.IsCphs);
                Log.Debug(Globals.LogTag, "CFIS profile count: " + resp.CfList.ProfileCount);
                List<SimCfis> cfis = resp.CfList.CfisList.ToList();
                for (int i = 0; i < resp.CfList.ProfileCount; i++)
                {
                    Log.Debug(Globals.LogTag, "CfisList[" + i + "].RecIndex: " + cfis[i].RecIndex);
                    Log.Debug(Globals.LogTag, "CfisList[" + i + "].MspNum: " + cfis[i].MspNum);
                    Log.Debug(Globals.LogTag, "CfisList[" + i + "].CfuStatus: " + cfis[i].CfuStatus);
                    Log.Debug(Globals.LogTag, "CfisList[" + i + "].Ton: " + cfis[i].Ton);
                    Log.Debug(Globals.LogTag, "CfisList[" + i + "].Npi: " + cfis[i].Npi);
                    Log.Debug(Globals.LogTag, "CfisList[" + i + "].CfuNum: " + cfis[i].CfuNum);
                    Log.Debug(Globals.LogTag, "CfisList[" + i + "].Cc2Id: " + cfis[i].Cc2Id);
                    Log.Debug(Globals.LogTag, "CfisList[" + i + "].Ext7Id: " + cfis[i].Ext7Id);
                }

                Log.Debug(Globals.LogTag, "CPHSCF.Line1: " + resp.CphsCf.Line1);
                Log.Debug(Globals.LogTag, "CPHSCF.Line2: " + resp.CphsCf.Line2);
                Log.Debug(Globals.LogTag, "CPHSCF.Fax: " + resp.CphsCf.Fax);
                Log.Debug(Globals.LogTag, "CPHSCF.Data: " + resp.CphsCf.Data);
                Log.Debug(Globals.LogTag, "Sim get call forward info success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Sim get call forward info exception: " + ex.ToString());
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
