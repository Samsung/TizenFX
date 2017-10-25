using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Tizen;
using Tizen.Telephony;

namespace XamarinForTizen.Tizen
{
    public class SimPage : ContentPage
    {
        private static Sim _sim = null;
        private ChangeNotificationEventArgs.Notification[] notiArr = { ChangeNotificationEventArgs.Notification.SimStatus,
                                                                       ChangeNotificationEventArgs.Notification.SimCallForwardingIndicatorState };
        public SimPage()
        {
            var changedBtn = new Button
            {
                Text = "Is sim changed",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            changedBtn.Clicked += changedBtn_Clicked;

            var operatorBtn = new Button
            {
                Text = "Get operator",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            operatorBtn.Clicked += operatorBtn_Clicked;

            var iccIdBtn = new Button
            {
                Text = "Get Icc id",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            iccIdBtn.Clicked += iccIdBtn_Clicked;

            var msinBtn = new Button
            {
                Text = "Get Msin",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            msinBtn.Clicked += msinBtn_Clicked;

            var spnBtn = new Button
            {
                Text = "Get SPN",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            spnBtn.Clicked += spnBtn_Clicked;

            var stateBtn = new Button
            {
                Text = "Get sim state",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            stateBtn.Clicked += stateBtn_Clicked;

            var appListBtn = new Button
            {
                Text = "Get sim application list",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            appListBtn.Clicked += appListBtn_Clicked;

            var subscriberBtn = new Button
            {
                Text = "Get subscriber number",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            subscriberBtn.Clicked += subscriberBtn_Clicked;

            var subscriberIdBtn = new Button
            {
                Text = "Get subscriber ID",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            subscriberIdBtn.Clicked += subscriberIdBtn_Clicked;

            var lockStateBtn = new Button
            {
                Text = "Get lock state",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lockStateBtn.Clicked += lockStateBtn_Clicked;

            var groupIdBtn = new Button
            {
                Text = "Get group ID1",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            groupIdBtn.Clicked += groupIdBtn_Clicked;

            var cfIndiStateBtn = new Button
            {
                Text = "Get call forwarding indicator state",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            cfIndiStateBtn.Clicked += cfIndiStateBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        changedBtn, operatorBtn, iccIdBtn, msinBtn, spnBtn, stateBtn, appListBtn, subscriberBtn,
                        subscriberIdBtn, lockStateBtn, groupIdBtn, cfIndiStateBtn
                    }
            };

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
                _sim = new Sim(Globals.slotHandle);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Exception in Sim constructor: " + ex.ToString());
            }
        }

        private void SlotHandle_ChangeNotification(object sender, ChangeNotificationEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Change notification: " + e.NotificationType);
        }

        private void cfIndiStateBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Call forwarding indicator state: " + _sim.CallForwardingIndicatorState);
        }

        private void groupIdBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Group ID1: " + _sim.GroupId1);
        }

        private void lockStateBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Sim lock state: " + _sim.CurrentLockState);
        }

        private void subscriberIdBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Subscriber ID: " + _sim.SubscriberId);
        }

        private void subscriberBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Subscriber Number: " + _sim.SubscriberNumber);
        }

        private void appListBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Application list: " + _sim.ApplicationList);
        }

        private void stateBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Sim state: " + _sim.CurrentState);
        }

        private void spnBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Spn: " + _sim.Spn);
        }

        private void msinBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Msin: " + _sim.Msin);
        }

        private void iccIdBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Icc id: " + _sim.IccId);
        }

        private void operatorBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Operator: " + _sim.Operator);
        }

        private void changedBtn_Clicked(object sender, EventArgs e)
        {
            if (_sim == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Is sim changed: " + _sim.IsChanged);
        }
    }
}
