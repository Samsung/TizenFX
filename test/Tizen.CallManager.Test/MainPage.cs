using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Tizen;
using Tizen.CallManager;

namespace XamarinForTizen.Tizen
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var initBtn = new Button
            {
                Text = "Initialize",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            initBtn.Clicked += initBtn_Clicked;

            var dialBtn = new Button
            {
                Text = "Dial & end voice call",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            dialBtn.Clicked += dialBtn_Clicked;

            var holdBtn = new Button
            {
                Text = "Hold & unhold voice call",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            holdBtn.Clicked += holdBtn_Clicked;

            var answerBtn = new Button
            {
                Text = "Answer incoming call",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            answerBtn.Clicked += answerBtn_Clicked;

            var alertBtn = new Button
            {
                Text = "Start & Stop alert",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            alertBtn.Clicked += alertBtn_Clicked;

            var rejectBtn = new Button
            {
                Text = "Reject incoming call",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            rejectBtn.Clicked += rejectBtn_Clicked;

            var swapBtn = new Button
            {
                Text = "Swap call",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            swapBtn.Clicked += swapBtn_Clicked;

            var joinBtn = new Button
            {
                Text = "Join calls",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            joinBtn.Clicked += joinBtn_Clicked;

            var splitBtn = new Button
            {
                Text = "Split call",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            splitBtn.Clicked += splitBtn_Clicked;

            var getAllCallListBtn = new Button
            {
                Text = "Get all call list",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getAllCallListBtn.Clicked += getAllCallListBtn_Clicked;

            var getConfCallListBtn = new Button
            {
                Text = "Get conf call list",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getConfCallListBtn.Clicked += getConfCallListBtn_Clicked;

            var getCallDataBtn = new Button
            {
                Text = "Get all call data",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getCallDataBtn.Clicked += getCallDataBtn_Clicked;

            var statusBtn = new Button
            {
                Text = "Get call status",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            statusBtn.Clicked += statusBtn_Clicked;

            var deinitBtn = new Button
            {
                Text = "Deinitialize",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            deinitBtn.Clicked += deinitBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        initBtn, dialBtn, holdBtn, answerBtn, alertBtn, rejectBtn, swapBtn, joinBtn, splitBtn,
                        getAllCallListBtn, getConfCallListBtn, getCallDataBtn, statusBtn, deinitBtn
                    }
            };
        }

        private void getCallDataBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                Globals.cmHandle.GetAllCallData(out CallData incoming, out CallData active, out CallData held);
                if (incoming == null)
                {
                    Log.Debug(Globals.LogTag, "No incoming call");
                }

                else
                {
                    Log.Debug(Globals.LogTag, "Incoming call Id: " + incoming.Id);
                    Log.Debug(Globals.LogTag, "Incoming call number: " + incoming.CallNumber);
                }

                if (active == null)
                {
                    Log.Debug(Globals.LogTag, "No active calls");
                }

                else
                {
                    Log.Debug(Globals.LogTag, "Active call Id: " + active.Id);
                    Log.Debug(Globals.LogTag, "Active call number: " + active.CallNumber);
                }

                if (held == null)
                {
                    Log.Debug(Globals.LogTag, "No held calls");
                }

                else
                {
                    Log.Debug(Globals.LogTag, "Held call Id: " + held.Id);
                    Log.Debug(Globals.LogTag, "Held call number: " + held.CallNumber);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Get all call data exception: " + ex.ToString());
            }
        }

        private void getConfCallListBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                List<ConferenceCallData> confCallList = Globals.cmHandle.AllConferenceCalls.ToList();
                if (confCallList.Count == 0)
                {
                    Log.Debug(Globals.LogTag, "Conf call list is empty");
                    return;
                }

                for (int i = 0; i < confCallList.Count; i++)
                {
                    Log.Debug(Globals.LogTag, "ID[" + i + "]: " + confCallList[i].Id);
                    Log.Debug(Globals.LogTag, "Number[" + i + "]: " + confCallList[i].CallNumber);
                    Log.Debug(Globals.LogTag, "PersonId[" + i + "]: " + confCallList[i].PersonId);
                    Log.Debug(Globals.LogTag, "Mode[" + i + "]: " + confCallList[i].Mode);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Get all conf call list exception: " + ex.ToString());
            }
        }

        private void getAllCallListBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                List<CallData> callDataList = Globals.cmHandle.AllCalls.ToList();
                if (callDataList.Count == 0)
                {
                    Log.Debug(Globals.LogTag, "Call data list is empty");
                    return;
                }

                for (int i = 0; i < callDataList.Count; i++)
                {
                    Log.Debug(Globals.LogTag, "Call ID[" + i +"]: " + callDataList[i].Id);
                    Log.Debug(Globals.LogTag, "Number[" + i + "]: " + callDataList[i].CallNumber);
                    Log.Debug(Globals.LogTag, "Call direction[" + i + "]: " + callDataList[i].Direction);
                    Log.Debug(Globals.LogTag, "Name[" + i + "]: " + callDataList[i].CallingName);
                    Log.Debug(Globals.LogTag, "Call type[" + i + "]: " + callDataList[i].Type);
                    Log.Debug(Globals.LogTag, "Call state[" + i + "]: " + callDataList[i].State);
                    Log.Debug(Globals.LogTag, "Member count[" + i + "]: " + callDataList[i].MemberCount);
                    Log.Debug(Globals.LogTag, "Is Ecc[" + i + "]: " + callDataList[i].IsEmergency);
                    Log.Debug(Globals.LogTag, "Call domain[" + i + "]: " + callDataList[i].Domain);
                    Log.Debug(Globals.LogTag, "Start time[" + i + "]: " + callDataList[i].StartTime);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Get all call list exception: " + ex.ToString());
            }
        }

        private void splitBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                Globals.cmHandle.SplitCall(1);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Split call exception: " + ex.ToString());
            }
        }

        private void joinBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                Globals.cmHandle.JoinCall();
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Join call exception: " + ex.ToString());
            }
        }

        private void swapBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                Globals.cmHandle.SwapCall();
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Swap call exception: " + ex.ToString());
            }
        }

        private void statusBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                Log.Debug(Globals.LogTag, "Call status: " + Globals.cmHandle.CallStatus);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Get call status exception: " + ex.ToString());
            }
        }

        private void rejectBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                Globals.cmHandle.RejectCall();
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Reject call exception: " + ex.ToString());
            }
        }

        private async void alertBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                Globals.cmHandle.CallStatusChanged += CmHandle_CallStatusChanged;
                Globals.cmHandle.StopAlert();
                await Task.Delay(5000);
                Globals.cmHandle.StartAlert();
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Call alert exception: " + ex.ToString());
            }
        }

        private void CmHandle_CallStatusChanged(object sender, CallStatusChangedEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Call status changed: " + e.CallNumber + e.Status);
        }

        private void answerBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                Globals.cmHandle.AnswerCall(CallAnswerType.Normal);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Answer call exception: " + ex.ToString());
            }
        }

        private async void holdBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                Globals.HoldTest = true;
                Globals.cmHandle.DialCall(Globals.Number, CallType.Voice, MultiSimSlot.Default);
                await Task.Delay(20000);
                Globals.cmHandle.HoldCall();
                await Task.Delay(8000);
                Globals.cmHandle.UnholdCall();
                await Task.Delay(8000);
                Globals.cmHandle.EndCall(1, CallReleaseType.AllActiveCalls);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Hold call exception: " + ex.ToString());
            }
        }

        private async void dialBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                Globals.cmHandle.DialCall(Globals.Number, CallType.Voice, MultiSimSlot.Default);
                await Task.Delay(20000);
                Globals.cmHandle.EndCall(1, CallReleaseType.AllCalls);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Dial call exception: " + ex.ToString());
            }
        }

        private void deinitBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle == null)
                {
                    Log.Debug(Globals.LogTag, "Not initialized!!!!!");
                    return;
                }

                CallManager.DeinitCm(Globals.cmHandle);
                Globals.cmHandle = null;
                Log.Debug(Globals.LogTag, "Callmanager deinitialized successfully");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Callmanager deinit exception: " + ex.ToString());
            }
        }

        private void initBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Globals.cmHandle != null)
                {
                    Log.Debug(Globals.LogTag, "Already initialized!!!!!");
                    return;
                }

                Globals.cmHandle = CallManager.InitCm();
                Globals.cmHandle.EnableRecovery("Tizen.CallManager.Test");
                Log.Debug(Globals.LogTag, "Callmanager initialization is successful");
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Callmanager init exception: " + ex.ToString());
            }
        }

        private async void CmHandle_CallEventChangedAsync(object sender, CallEventEventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Call event changed handler, CallEvent: " + e.Event);
                if (e.EventData != null)
                {
                    Log.Debug(Globals.LogTag, "Call ID: " + e.EventData.Id);
                    Log.Debug(Globals.LogTag, "Sim slot: " + e.EventData.SimSlot);
                    Log.Debug(Globals.LogTag, "Call end cause: " + e.EventData.EndCause);
                }

                if (Globals.DialTest && e.Event == CallEvent.Active)
                {
                    Globals.DialTest = false;
                    await Task.Delay(3000);
                    Globals.cmHandle.EndCall(e.EventData.Id, CallReleaseType.ByCallHandle);
                }

                if (Globals.HoldTest && e.Event == CallEvent.Active)
                {
                    await Task.Delay(3000);
                    Globals.cmHandle.HoldCall();
                }

                if (Globals.HoldTest && e.Event == CallEvent.Held)
                {
                    Globals.HoldTest = false;
                    await Task.Delay(8000);
                    Globals.cmHandle.UnholdCall();
                    await Task.Delay(8000);
                    Globals.cmHandle.EndCall(e.EventData.Id, CallReleaseType.AllActiveCalls);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "End call exception: " + ex.ToString());
            }
        }

        ~MainPage()
        {
            if (Globals.cmHandle != null)
            {
                CallManager.DeinitCm(Globals.cmHandle);
                Globals.cmHandle = null;
            }
        }
    }
}
