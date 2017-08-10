using System;
using Xamarin.Forms;
using Tizen;
using Tizen.Tapi;
using System.Collections.Generic;
using System.Linq;

namespace XamarinForTizen.Tizen
{
    public class SsPage : ContentPage
    {
        Ss ss = null;
        public SsPage()
        {
            try
            {
                ss = new Ss(Globals.handleModem0);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Ss constructor throws exception = " + ex.ToString());
            }

            var setCfBtn = new Button
            {
                Text = "Set SS call forward",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            setCfBtn.Clicked += setCfBtn_Clicked;

            var getCfBtn = new Button
            {
                Text = "Get SS call forward status",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getCfBtn.Clicked += getCfBtn_Clicked;

            var setcwBtn = new Button
            {
                Text = "Set SS call waiting",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            setcwBtn.Clicked += setcwBtn_Clicked;

            var getcwBtn = new Button
            {
                Text = "Get SS call waiting status",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getcwBtn.Clicked += getcwBtn_Clicked;

            var setCliBtn = new Button
            {
                Text = "Set SS CLI status",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            setCliBtn.Clicked += setCliBtn_Clicked;

            var getCliBtn = new Button
            {
                Text = "Get SS CLI status",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getCliBtn.Clicked += getCliBtn_Clicked;

            var setBarringBtn = new Button
            {
                Text = "Set SS barring",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            setBarringBtn.Clicked += setBarringBtn_Clicked;

            var getBarringBtn = new Button
            {
                Text = "Get SS barring status",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getBarringBtn.Clicked += getBarringBtn_Clicked;

            var changeBarringPwBtn = new Button
            {
                Text = "Change SS barring password",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            changeBarringPwBtn.Clicked += changeBarringPwBtn_Clicked;

            var sendUssdBtn = new Button
            {
                Text = "Ss send USSD request",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            sendUssdBtn.Clicked += sendUssdBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        setCfBtn, getCfBtn, setcwBtn, getcwBtn, setCliBtn, getCliBtn, setBarringBtn, getBarringBtn,
                        changeBarringPwBtn, sendUssdBtn
                    }
            };
        }

        private async void sendUssdBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Ss send ussd request start");
                SsUssdMsgInfo info = new SsUssdMsgInfo();
                info.Type = SsUssdType.UserInit;
                info.UssdString = "*123#";
                info.Length = info.UssdString.Length;
                SsUssdResponse resp = await ss.SsSendUssdRequest(info);
                Log.Debug(Globals.LogTag, "Type: " + resp.Type);
                Log.Debug(Globals.LogTag, "String: " + resp.UssdString);
                Log.Debug(Globals.LogTag, "Ss send ussd request success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Ss send ussd request exception: " + ex.ToString());
            }
        }

        private async void changeBarringPwBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Ss change barring password start");
                bool b = await ss.SsChangeBarringPassword("1111", "'1234", "1234");
                if (b)
                {
                    Log.Debug(Globals.LogTag, "Ss barring password changed successfully");
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Ss change barring password exception: " + ex.ToString());
            }
        }

        private async void getBarringBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Ss get barring status start");
                SsBarringResponse resp = await ss.SsGetBarringStatus(SsClass.AllTele, SsBarringType.Aob);
                Log.Debug(Globals.LogTag, "Record number: " + resp.RecordNumber);
                List<SsBarringRecord> rec = resp.Record.ToList();
                for (int i = 0; i < resp.RecordNumber; i++)
                {
                    Log.Debug(Globals.LogTag, "[" + i + "] Class: " + rec[i].Class);
                    Log.Debug(Globals.LogTag, "[" + i + "] Type: " + rec[i].BarringType);
                    Log.Debug(Globals.LogTag, "[" + i + "] Status: " + rec[i].Status);
                }

                Log.Debug(Globals.LogTag, "Ss get barring status success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Ss set barring exception: " + ex.ToString());
            }
        }

        private async void setBarringBtn_Clicked(object sender, EventArgs e)
        {
            TapiHandle handle = Globals.handleModem0;
            try
            {
                Log.Debug(Globals.LogTag, "Ss set barring start");
                handle.RegisterNotiEvent(Notification.SsNotifyBarring);
                handle.NotificationChanged += Handle_Barring_NotiEvent;
                SsBarringInfo info = new SsBarringInfo(SsClass.Voice, SsBarringMode.Activate, SsBarringType.Aob, "0000");
                SsBarringResponse resp = await ss.SsSetBarring(info);
                Log.Debug(Globals.LogTag, "Record number: " + resp.RecordNumber);
                List<SsBarringRecord> rec = resp.Record.ToList();
                for (int i = 0; i < resp.RecordNumber; i++)
                {
                    Log.Debug(Globals.LogTag, "[" + i + "] Class: " + rec[i].Class);
                    Log.Debug(Globals.LogTag, "[" + i + "] Type: " + rec[i].BarringType);
                    Log.Debug(Globals.LogTag, "[" + i + "] Status: " + rec[i].Status);
                }

                Log.Debug(Globals.LogTag, "Ss set barring success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Ss set barring exception: " + ex.ToString());
            }

            finally
            {
                handle.DeregisterNotiEvent(Notification.SsNotifyBarring);
                handle.NotificationChanged -= Handle_Barring_NotiEvent;
            }
        }

        private void Handle_Barring_NotiEvent(object sender, NotificationChangedEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Ss barring noti event received");
            SsBarringResponse resp = (SsBarringResponse)e.Data;
            Log.Debug(Globals.LogTag, "Record number: " + resp.RecordNumber);
            List<SsBarringRecord> rec = resp.Record.ToList();
            for (int i = 0; i < resp.RecordNumber; i++)
            {
                Log.Debug(Globals.LogTag, "[" + i + "] Class: " + rec[i].Class);
                Log.Debug(Globals.LogTag, "[" + i + "] Type: " + rec[i].BarringType);
                Log.Debug(Globals.LogTag, "[" + i + "] Status: " + rec[i].Status);
            }
        }

        private async void getCliBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Ss get CLI status start");
                SsCliResponse resp = await ss.SsGetCliStatus(SsCliType.Clip);
                Log.Debug(Globals.LogTag, "Type: " + resp.Type);
                Log.Debug(Globals.LogTag, "Status: " + resp.Status);
                Log.Debug(Globals.LogTag, "Ss get CLI status success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Ss get CLI status exception: " + ex.ToString());
            }
        }

        private async void setCliBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Ss set CLI start");
                bool b = await ss.SsSetCliStatus(SsCliType.Clip, SsCliStatus.Activated);
                if (b)
                {
                    Log.Debug(Globals.LogTag, "Ss set CLI status is success");
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Ss set CLI exception: " + ex.ToString());
            }
        }

        private async void getcwBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Ss get call waiting start");
                SsWaitingResponse resp = await ss.SsGetWaitingInfo(SsClass.Voice);
                Log.Debug(Globals.LogTag, "Record number: " + resp.RecordNumber);
                List<SsWaitingRecord> rec = resp.Record.ToList();
                for (int i = 0; i < resp.RecordNumber; i++)
                {
                    Log.Debug(Globals.LogTag, "[" + i + "] Class: " + rec[i].Class);
                    Log.Debug(Globals.LogTag, "[" + i + "] Status: " + rec[i].Status);
                }

                Log.Debug(Globals.LogTag, "Ss get call waiting success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Ss get call waiting exception: " + ex.ToString());
            }
        }

        private async void setcwBtn_Clicked(object sender, EventArgs e)
        {
            TapiHandle handle = Globals.handleModem0;
            try
            {
                Log.Debug(Globals.LogTag, "Ss set call waiting start");
                handle.RegisterNotiEvent(Notification.SsNotifyWaiting);
                handle.NotificationChanged += Handle_CallWaitingNoti;
                SsWaitingInfo info = new SsWaitingInfo(SsClass.Voice, SsCallWaitingMode.Activate);
                SsWaitingResponse resp = await ss.SsSetWaitingInfo(info);
                Log.Debug(Globals.LogTag, "Record number: " + resp.RecordNumber);
                List<SsWaitingRecord> rec = resp.Record.ToList();
                for (int i = 0; i < resp.RecordNumber; i++)
                {
                    Log.Debug(Globals.LogTag, "[" + i + "] Class: " + rec[i].Class);
                    Log.Debug(Globals.LogTag, "[" + i + "] Status: " + rec[i].Status);
                }

                Log.Debug(Globals.LogTag, "Ss set call waiting success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Ss set call waiting exception: " + ex.ToString());
            }

            finally
            {
                handle.DeregisterNotiEvent(Notification.SsNotifyWaiting);
                handle.NotificationChanged -= Handle_CallWaitingNoti;
            }
        }

        private void Handle_CallWaitingNoti(object sender, NotificationChangedEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Ss call waiting noti event is received");
            SsWaitingResponse resp = (SsWaitingResponse)e.Data;
            Log.Debug(Globals.LogTag, "Record number: " + resp.RecordNumber);
            List<SsWaitingRecord> rec = resp.Record.ToList();
            for (int i = 0; i < resp.RecordNumber; i++)
            {
                Log.Debug(Globals.LogTag, "[" + i + "] Class: " + rec[i].Class);
                Log.Debug(Globals.LogTag, "[" + i + "] Status: " + rec[i].Status);
            }
        }

        private async void getCfBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Ss get call forward start");
                SsForwardResponse resp = await ss.SsGetForwardStatus(SsClass.Voice, SsForwardCondition.NotReachable);
                Log.Debug(Globals.LogTag, "Record num: " + resp.RecordNumber);
                List<SsForwardRecord> rec = resp.Record.ToList();
                for (int i = 0; i < resp.RecordNumber; i++)
                {
                    Log.Debug(Globals.LogTag, "[" + i + "] Class: " + rec[i].Class);
                    Log.Debug(Globals.LogTag, "[" + i + "] Status: " + rec[i].Status);
                    Log.Debug(Globals.LogTag, "[" + i + "] ForwardCondition: " + rec[i].ForwardCondition);
                    Log.Debug(Globals.LogTag, "[" + i + "] IsFwNumPresent: " + rec[i].IsForwardingNumberPresent);
                    Log.Debug(Globals.LogTag, "[" + i + "] NoReplyTime:: " + rec[i].NoReplyTime);
                    Log.Debug(Globals.LogTag, "[" + i + "] Ton: " + rec[i].Ton);
                    Log.Debug(Globals.LogTag, "[" + i + "] Npi: " + rec[i].Npi);
                    Log.Debug(Globals.LogTag, "[" + i + "] Number: " + rec[i].ForwardingNumber);
                }

                Log.Debug(Globals.LogTag, "Ss get call forward success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Ss get call forward exception: " + ex.ToString());
            }
        }

        private async void setCfBtn_Clicked(object sender, EventArgs e)
        {
            TapiHandle handle = Globals.handleModem0;
            try
            {
                Log.Debug(Globals.LogTag, "Ss set call forward start");
                handle.RegisterNotiEvent(Notification.SsNotifyForwarding);
                handle.NotificationChanged += Handle_CallForwardNotiEvent;
                SsForwardInfo cfInfo = new SsForwardInfo(SsClass.Voice, SsForwardMode.Enable, SsForwardCondition.NotReachable, SsNoReplyTime.Time5Secs, SsForwardTypeOfNumber.National, SsForwardNumberingPlanIdentity.National, "9589874552");
                SsForwardResponse resp = await ss.SsSetForwardInfo(cfInfo);
                Log.Debug(Globals.LogTag, "Record num: " + resp.RecordNumber);
                List<SsForwardRecord> rec = resp.Record.ToList();
                for (int i = 0; i < resp.RecordNumber; i++)
                {
                    Log.Debug(Globals.LogTag, "[" + i + "] Class: " + rec[i].Class);
                    Log.Debug(Globals.LogTag, "[" + i + "] Status: " + rec[i].Status);
                    Log.Debug(Globals.LogTag, "[" + i + "] ForwardCondition: " + rec[i].ForwardCondition);
                    Log.Debug(Globals.LogTag, "[" + i + "] IsFwNumPresent: " + rec[i].IsForwardingNumberPresent);
                    Log.Debug(Globals.LogTag, "[" + i + "] NoReplyTime:: " + rec[i].NoReplyTime);
                    Log.Debug(Globals.LogTag, "[" + i + "] Ton: " + rec[i].Ton);
                    Log.Debug(Globals.LogTag, "[" + i + "] Npi: " + rec[i].Npi);
                    Log.Debug(Globals.LogTag, "[" + i + "] Number: " + rec[i].ForwardingNumber);
                }

                Log.Debug(Globals.LogTag, "Ss set call forward success");
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Ss set call forward exception: " + ex.ToString());
            }

            finally
            {
                handle.DeregisterNotiEvent(Notification.SsNotifyForwarding);
                handle.NotificationChanged -= Handle_CallForwardNotiEvent;
            }
        }

        private void Handle_CallForwardNotiEvent(object sender, NotificationChangedEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Call forward noti event received");
            SsForwardResponse resp = (SsForwardResponse)e.Data;
            Log.Debug(Globals.LogTag, "Record number: " + resp.RecordNumber);
            List<SsForwardRecord> rec = resp.Record.ToList();
            for (int i = 0; i < resp.RecordNumber; i++)
            {
                Log.Debug(Globals.LogTag, "[" + i + "] Class: " + rec[i].Class);
                Log.Debug(Globals.LogTag, "[" + i + "] Status: " + rec[i].Status);
                Log.Debug(Globals.LogTag, "[" + i + "] ForwardCondition: " + rec[i].ForwardCondition);
                Log.Debug(Globals.LogTag, "[" + i + "] IsFwNumPresent: " + rec[i].IsForwardingNumberPresent);
                Log.Debug(Globals.LogTag, "[" + i + "] NoReplyTime:: " + rec[i].NoReplyTime);
                Log.Debug(Globals.LogTag, "[" + i + "] Ton: " + rec[i].Ton);
                Log.Debug(Globals.LogTag, "[" + i + "] Npi: " + rec[i].Npi);
                Log.Debug(Globals.LogTag, "[" + i + "] Number: " + rec[i].ForwardingNumber);
            }
        }

        ~SsPage()
        {
        }
    }
}
