using System;
using Xamarin.Forms;
using Tizen;
using Tizen.Tapi;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace XamarinForTizen.Tizen
{
    public class CallPage : ContentPage
    {
        Call call = null;
        uint incomingCallHandle = 0;
        uint activeCallHandle = 0;
        uint heldCallHandle = 0;
        Entry entry;
        string num;

        Notification[] arrNoti = { Notification.NetworkDefaultSubscription, Notification.IdleVoiceCall , Notification.ActiveVoiceCall, Notification.HeldVoiceCall, Notification.DialingVoiceCall,
                                       Notification.AlertVoiceCall, Notification.IncomingVoiceCall, Notification.HeldCallInfo, Notification.ActiveCallInfo,
                                       Notification.JoinedCallInfo, Notification.CallSoundRingbackTone, Notification.CallSoundWbamr, Notification.CallSoundPath, Notification.CallPreferredVoiceSubscription};
        public CallPage()
        {
            try
            {
                call = new Call(Globals.handleModem0);
                RegisterNotiCallEvents(Globals.handleModem0);
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Call constructor throws exception = " + ex.ToString());
            }

            var dialCallBtn = new Button
            {
                Text = "DialCall",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            dialCallBtn.Clicked += DialCallBtn_Clicked;

            var ansCallBtn = new Button
            {
                Text = "AnswerCall",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            ansCallBtn.Clicked += AnsCallBtn_Clicked;

            var endCallBtn = new Button
            {
                Text = "EndCall",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            endCallBtn.Clicked += EndCallBtn_Clicked;

            var holdCallBtn = new Button
            {
                Text = "HoldCall",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            holdCallBtn.Clicked += HoldCallBtn_Clicked;

            var activeCallBtn = new Button
            {
                Text = "ActiveCall",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            activeCallBtn.Clicked += ActiveCallBtn_Clicked;

            var swapCallBtn = new Button
            {
                Text = "SwapCall",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            swapCallBtn.Clicked += SwapCallBtn_Clicked;

            var joinCallBtn = new Button
            {
                Text = "JoinCall",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            joinCallBtn.Clicked += JoinCallBtn_Clicked;

            var splitCallBtn = new Button
            {
                Text = "SplitCall",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            splitCallBtn.Clicked += SplitCallBtn_Clicked;

            var transferCallBtn = new Button
            {
                Text = "TransferCall",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            transferCallBtn.Clicked += TransferCallBtn_Clicked;

            var setMuteStBtn = new Button
            {
                Text = "SetCallMuteStatus",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            setMuteStBtn.Clicked += SetMuteStBtn_Clicked;

            var setVolumeInfoBtn = new Button
            {
                Text = "SetCallVolumeInfo",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            setVolumeInfoBtn.Clicked += SetVolumeInfoBtn_Clicked;

            var setSoundPathBtn = new Button
            {
                Text = "SetCallSoundPath",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            setSoundPathBtn.Clicked += SetSoundPathBtn_Clicked;

            var getCallBtn = new Button
            {
                Text = "GetCallStatus",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getCallBtn.Clicked += GetCallBtn_Clicked;

            var getAllCallBtn = new Button
            {
                Text = "GetAllCallStatus",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            getAllCallBtn.Clicked += GetAllCallBtn_Clicked;

            var preferredCallSubscriptionBtn = new Button
            {
                Text = "SetGetPreferredVoicesubscription",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            preferredCallSubscriptionBtn.Clicked += PreferredSubscriptionBtn_Clicked;

            entry = new Entry
            {
                IsVisible = false,
                Keyboard = Keyboard.Telephone,
                Placeholder = "Enter phone number",
                HeightRequest = 80,
                BackgroundColor = new Color(255,255,255)
            };
            entry.Completed += Entry_Completed;

            ScrollView scrollView = new ScrollView()
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        getCallBtn, getAllCallBtn, preferredCallSubscriptionBtn, dialCallBtn, entry, ansCallBtn, endCallBtn, holdCallBtn, activeCallBtn, swapCallBtn, joinCallBtn, transferCallBtn,
                        splitCallBtn, setMuteStBtn, setVolumeInfoBtn, setSoundPathBtn
                    }
                },
                VerticalOptions = LayoutOptions.Center
            };

            Content = scrollView;
        }

        private async void ActiveCallBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Activate call start");
                uint x = await call.ActiveCall(heldCallHandle);
                Log.Debug(Globals.LogTag, "Activate call end, call id = " + x);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Activate call ,exception = " + ex.ToString());
            }
        }

        private async void HoldCallBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Hold call start");
                uint x = await call.HoldCall(activeCallHandle);
                Log.Debug(Globals.LogTag, "Hold call end, call id = " + x);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Hold call ,exception = " + ex.ToString());
            }
        }

        private async void EndCallBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var action = await DisplayActionSheet("Operation", "Cancel", null, Enum.GetNames(typeof(CallEndType)));
                Log.Debug(Globals.LogTag, "Action: " + action);
                if (action != null)
                {
                    Log.Debug(Globals.LogTag, "End call start");
                    CallEndType type = (CallEndType)Enum.Parse(typeof(CallEndType), action);
                    CallEndData data = await call.EndCall(activeCallHandle, type);
                    Log.Debug(Globals.LogTag, "End call success, call id = " + data.Id + ", end type = " + data.Type);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "End call ,exception = " + ex.ToString());
            }
        }

        private async void AnsCallBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var action = await DisplayActionSheet("Operation", "Cancel", null, Enum.GetNames(typeof(CallAnswerType)));
                Log.Debug(Globals.LogTag, "Action: " + action);
                if (action != null)
                {
                    Log.Debug(Globals.LogTag, "Answer call start .. incoming call id  = "+incomingCallHandle);
                    CallAnswerType type = (CallAnswerType)Enum.Parse(typeof(CallAnswerType), action);
                    uint x = await call.AnswerCall(incomingCallHandle, type);
                    Log.Debug(Globals.LogTag, "Answer call end, call id = " + x);
                }
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "AnswerCall ,exception = " + ex.ToString());
            }
        }

        private void DialCallBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Dial call start");
                entry.IsVisible = true;
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Dial call ,exception = " + ex.ToString());
            }
        }

        private async void Entry_Completed(object sender, EventArgs e)
        {
            try
            {
                num = entry.Text;
                entry.IsVisible = false;
                entry.ClearValue(Entry.TextProperty);
                Log.Debug(Globals.LogTag, "Phone Number entered = " + num);
                var action = await DisplayActionSheet("Operation", "Cancel", null, Enum.GetNames(typeof(CallType)));
                Log.Debug(Globals.LogTag, "Action: " + action);
                if (action != null)
                {
                    CallType type = (CallType)Enum.Parse(typeof(CallType), action);
                    CallInformation info = new CallInformation(type, EmergencyType.Default, num);
                    await call.DialCall(info);
                    Log.Debug(Globals.LogTag, "Dial call end");
                }
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Entry_Completed Dial call ,exception = " + ex.ToString());
            }
        }

        private void GetCallBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "GetCallStatus call start");
                CallStatus data = call.GetCallStatus((int)activeCallHandle);
                Log.Debug(Globals.LogTag, "GetCallStatus call end, callstatus, id = " + data.CallHandle + ",number = " + data.PhoneNumber + ",volte call =" + data.IsVolteCall +
                        ",state = " + data.State + ",type = " + data.Type + ",conference call = " + data.IsConferenceState + ",Mo call = " + data.IsMoCall);
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "GetCallStatus ,exception = " + ex.ToString());
            }
        }

        private void GetAllCallBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "GetAllCallStatus call start");
                List<CallStatus> callStatusList = call.GetAllCallStatus().ToList();
                if (callStatusList.Count > 0)
                {
                    foreach (CallStatus stat in callStatusList)
                    {
                        Log.Debug(Globals.LogTag, "isconference = " + stat.IsConferenceState + ", handle =" + stat.CallHandle + ", type =" + stat.Type);
                        Log.Debug(Globals.LogTag, "ismocall = " + stat.IsMoCall + ", isvoltecall =" + stat.IsVolteCall);
                        Log.Debug(Globals.LogTag, "number = " + stat.PhoneNumber + ", state =" + stat.State);
                    }
                }

                else
                {
                    Log.Debug(Globals.LogTag, "There are no current calls !!");
                }

                Log.Debug(Globals.LogTag, "GetAllCallStatus call end");
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "GetAllCallStatus ,exception = " + ex.ToString());
            }
        }

        private async void SwapCallBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Swap call start");
                uint p = activeCallHandle;
                uint q = heldCallHandle;
                uint x = await call.SwapCall(activeCallHandle, heldCallHandle);
                await Task.Delay(3000);
                if (p == heldCallHandle && q == activeCallHandle)
                {
                    Log.Debug(Globals.LogTag, "Swap call ends with success, call id = "+x);
                }

                else
                {
                    Log.Debug(Globals.LogTag, "Swap call gets failed");
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Swap call ,exception = " + ex.ToString());
            }
        }

        private async void JoinCallBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Join call start");
                uint x = await call.JoinCall(activeCallHandle, heldCallHandle);
                Log.Debug(Globals.LogTag, "Join call ends with success, call id = "+x);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Join call ,exception = " + ex.ToString());
            }
        }

        private async void SplitCallBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Split call start");
                var action = await DisplayActionSheet("Operation", "Cancel", null, "Active call", "Held Call");
                Log.Debug(Globals.LogTag, "Action: " + action);
                if (action != null)
                {
                    uint handle;
                    if (action == "Active call")
                        handle = activeCallHandle;
                    else
                        handle = heldCallHandle;
                    uint x = await call.SplitCall(handle);
                    Log.Debug(Globals.LogTag, "Split call ends with success, call id = " + x);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Split call ,exception = " + ex.ToString());
            }
        }

        private async void TransferCallBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Transfer call starts");
                uint x = await call.TransferCall(activeCallHandle);
                Log.Debug(Globals.LogTag, "Transfer call ends with success, call id = " + x);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Transfer call ,exception = " + ex.ToString());
            }
        }

        private async void SetVolumeInfoBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Set call volume info start");
                var actionDev = await DisplayActionSheet("Device", "Cancel", null, Enum.GetNames(typeof(SoundDevice)));
                var actionType = await DisplayActionSheet("Type", "Cancel", null, Enum.GetNames(typeof(SoundType)));
                var actionVolume = await DisplayActionSheet("Volume", "Cancel", null, Enum.GetNames(typeof(SoundVolume)));
                Log.Debug(Globals.LogTag, "Action: Device = " + actionDev + ", type = " + actionType +", Volume = " + actionVolume);
                if (actionDev != null && actionType != null && actionVolume != null)
                {
                    SoundDevice device = (SoundDevice)Enum.Parse(typeof(SoundDevice), actionDev);
                    SoundType type = (SoundType)Enum.Parse(typeof(SoundType), actionType);
                    SoundVolume volume = (SoundVolume)Enum.Parse(typeof(SoundVolume), actionVolume);
                    CallVolumeRecord volumeRecord = new CallVolumeRecord(device, type, volume);
                    await call.SetCallVolumeInfo(volumeRecord);
                    Log.Debug(Globals.LogTag, "Set call volume info ends with success");
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Set call volume info ,exception = " + ex.ToString());
            }
        }

        private async void SetMuteStBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Set call mute status start");
                var actionPath = await DisplayActionSheet("Path", "Cancel", null, Enum.GetNames(typeof(SoundMutePath)));
                var actionSt = await DisplayActionSheet("Mute Status", "Cancel", null, Enum.GetNames(typeof(SoundMuteStatus)));
                Log.Debug(Globals.LogTag, "Action: path = " + actionPath + ", mute status = "+ actionSt);
                if (actionPath != null && actionSt != null)
                {
                    SoundMutePath path = (SoundMutePath)Enum.Parse(typeof(SoundMutePath), actionPath);
                    SoundMuteStatus status = (SoundMuteStatus)Enum.Parse(typeof(SoundMuteStatus), actionSt);
                    CallMuteStatusRecord record = new CallMuteStatusRecord(path, status);
                    await call.SetCallMuteStatus(record);
                    Log.Debug(Globals.LogTag, "Set call mute status ends");
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Set mute status, exception = " + ex.ToString());
            }
        }

        private async void SetSoundPathBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Set call sound path start");
                var actionPath = await DisplayActionSheet("Operation", "Cancel", null, Enum.GetNames(typeof(SoundPath)));
                var actionVolume = await DisplayActionSheet("Operation", "Cancel", null, Enum.GetNames(typeof(ExtraVolume)));
                Log.Debug(Globals.LogTag, "Action: Path = " + actionPath + ", Volume = "+ actionVolume);
                if (actionPath != null && actionVolume != null)
                {
                    SoundPath path = (SoundPath)Enum.Parse(typeof(SoundPath), actionPath);
                    ExtraVolume volume = (ExtraVolume)Enum.Parse(typeof(ExtraVolume), actionVolume);
                    CallSoundPathInfo pathInfo = new CallSoundPathInfo(path, volume);
                    await call.SetCallSoundPath(pathInfo);
                    Log.Debug(Globals.LogTag, "Set call sound path ends with success");
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Set call sound path,exception = " + ex.ToString());
            }
        }

        public async void PreferredSubscriptionBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var action = await DisplayActionSheet("Operation", "Cancel", null, Enum.GetNames(typeof(CallPreferredVoiceSubscription)));
                Log.Debug(Globals.LogTag, "Action: " + action);
                if (action != null)
                {
                    CallPreferredVoiceSubscription subscription = (CallPreferredVoiceSubscription)Enum.Parse(typeof(CallPreferredVoiceSubscription), action);
                    Log.Debug(Globals.LogTag, "CallPreferredVoiceSubscription start -- Set subscription to "+ subscription);
                    await call.SetCallPreferredVoiceSubscription(subscription);
                    CallPreferredVoiceSubscription subs = call.GetCallPreferredVoiceSubscription();
                    Log.Debug(Globals.LogTag, "Current CallPreferredVoiceSubscription = " + subs);
                    if (subs == subscription)
                        Log.Debug(Globals.LogTag, "CallPreferredVoiceSubscription set and get subscription is successful");
                    else
                        Log.Debug(Globals.LogTag, "CallPreferredVoiceSubscription set and get subscription has failed");
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "PreferredVoiceSubscription ,exception = " + ex.ToString());
            }
        }

        private void RegisterNotiCallEvents(TapiHandle handle)
        {
            handle.PropertyChanged += Handle_CallPropertyChanged;

            handle.NotificationChanged += Handle_CallNotificationChanged;
            foreach (Notification i in arrNoti)
            {
                handle.RegisterNotiEvent(i);
            }
            handle.RegisterPropEvent(Property.NetworkPsType);
        }

        private void Handle_CallPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Handle_CallPropertyChanged event receive, " + e.Property + e.Data);
        }

        private void Handle_CallNotificationChanged(object sender, NotificationChangedEventArgs e)
        {
            try
            {
                Notification id = e.Id;
                Log.Debug(Globals.LogTag, "Handle_CallNotificationChanged event receive, Notification Value = " + id);
                switch (id)
                {
                    case Notification.NetworkDefaultSubscription:
                        Log.Debug(Globals.LogTag, "Notification.NetworkDefaultSubscription event receive , data =" +e.Data);
                        break;
                    case Notification.IdleVoiceCall:
                        Log.Debug(Globals.LogTag, "Notification.IdleVoiceCall event receive");
                        CallIdleStatusNotificationData status = (CallIdleStatusNotificationData)e.Data;
                        Log.Debug(Globals.LogTag, "CallIdleStatusNotificationData , notiid = " + status.NotiId + ", end cause = " + status.EndCause);
                        break;
                    case Notification.ActiveVoiceCall:
                        activeCallHandle = (uint)e.Data;
                        Log.Debug(Globals.LogTag, "Notification.ActiveVoiceCall event receive, notiid = " + e.Id + ", callid= " + activeCallHandle);
                        break;
                    case Notification.HeldVoiceCall:
                        heldCallHandle = (uint)e.Data;
                        Log.Debug(Globals.LogTag, "Notification.HeldVoiceCall event receive, notiid = " + e.Id + ", callid= " + heldCallHandle);
                        break;
                    case Notification.AlertVoiceCall:
                        Log.Debug(Globals.LogTag, "Notification.AlertVoiceCall event receive, notiid = " + e.Id + ", callid= " + e.Data);
                        break;
                    case Notification.DialingVoiceCall:
                        Log.Debug(Globals.LogTag, "Notification.DialingVoiceCall event receive, notiid = " + e.Id + ", callid= " + e.Data);
                        break;
                    case Notification.IncomingVoiceCall:
                        Log.Debug(Globals.LogTag, "Notification.IncomingVoiceCall event receive");
                        CallIncomingInfo info = (CallIncomingInfo)e.Data;
                        incomingCallHandle = info.CallHandle;
                        Log.Debug(Globals.LogTag, "CallIncomingInfo data , callid = " + incomingCallHandle + ", callernumber = " + info.CallerNumber + ", calltype= " + info.CallType
                                 + ", callmode = " + info.CliMode + ", active line = " + info.ActiveLine + ", nocli cause = " + info.CliCause + ",isfwded = " + info.IsForwarded
                                 + ", name = " + info.NameInfo.Name + ", namemode = " + info.NameInfo.NameMode);
                        break;
                    case Notification.HeldCallInfo:
                        Log.Debug(Globals.LogTag, "Notification.HeldCallInfo event receive, notiid = " + e.Id + ", data= " + e.Data);
                        break;
                    case Notification.ActiveCallInfo:
                        Log.Debug(Globals.LogTag, "Notification.ActiveCallInfo event receive, notiid = " + e.Id + ", data= " + e.Data);
                        break;
                    case Notification.JoinedCallInfo:
                        Log.Debug(Globals.LogTag, "Notification.JoinedCallInfo event receive, notiid = " + e.Id + ", data= " + e.Data);
                        break;
                    case Notification.CallSoundRingbackTone:
                        Log.Debug(Globals.LogTag, "Notification.CallSoundRingbackTone event receive, notiid = " + e.Id + ", data= " + e.Data);
                        break;
                    case Notification.CallPreferredVoiceSubscription:
                        Log.Debug(Globals.LogTag, "Notification.CallPreferredVoiceSubscription event receive, notiid = " + e.Id + ", data= " + e.Data);
                        break;
                    case Notification.CallSoundWbamr:
                        Log.Debug(Globals.LogTag, "Notification.CallSoundWbamr event receive, notiid = " + e.Id + ", data= " + e.Data);
                        break;
                    case Notification.CallSoundPath:
                        Log.Debug(Globals.LogTag, "Notification.CallSoundPath event receive, notiid = " + e.Id + ", data= " + e.Data);
                        break;
                }

                Log.Debug(Globals.LogTag, "Handle_CallNotificationChanged event receive end");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Handle_CallNotificationChanged event exception = "+ex.ToString());
            }
        }

        }
}
