using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Tizen;
using Tizen.Telephony;

namespace XamarinForTizen.Tizen
{
    public class CallPage : ContentPage
    {
        private static Call _call = null;
        private ChangeNotificationEventArgs.Notification[] notiArr = { ChangeNotificationEventArgs.Notification.CallPreferredVoiceSubscription,
                                                                       ChangeNotificationEventArgs.Notification.VoiceCallStatusDialing,
                                                                       ChangeNotificationEventArgs.Notification.VoiceCallStatusIncoming };
        public CallPage()
        {
            var subsBtn = new Button
            {
                Text = "Get preferred voice subscription",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            subsBtn.Clicked += subsBtn_Clicked;

            var callListBtn = new Button
            {
                Text = "Get call list",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            callListBtn.Clicked += callListBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        subsBtn, callListBtn
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
                _call = new Call(Globals.slotHandle);
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Exception in call constructor: " + ex.ToString());
            }
        }

        private void SlotHandle_ChangeNotification(object sender, ChangeNotificationEventArgs e)
        {
            Log.Debug(Globals.LogTag, "Change notification: " + e.NotificationType);
        }

        private void callListBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (_call == null)
                {
                    Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                    return;
                }

                List<CallHandle> handleList = _call.GetCallHandleList().ToList();
                if (handleList.Count == 0)
                {
                    Log.Debug(Globals.LogTag, "Call handle list is empty");
                    return;
                }

                foreach (CallHandle handle in handleList)
                {
                    Log.Debug(Globals.LogTag, "HandleId: " + handle.HandleId);
                    Log.Debug(Globals.LogTag, "Number: " + handle.Number);
                    Log.Debug(Globals.LogTag, "Type: " + handle.Type);
                    Log.Debug(Globals.LogTag, "Status: " + handle.Status);
                    Log.Debug(Globals.LogTag, "Direction: " + handle.Direction);
                    Log.Debug(Globals.LogTag, "ConferenceStatus: " + handle.ConferenceStatus);
                }
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Exception caught in getting call list: " + ex.ToString());
            }
        }

        private void subsBtn_Clicked(object sender, EventArgs e)
        {
            if (_call == null)
            {
                Log.Debug(Globals.LogTag, "Telephony is not initialized/there are no sim slot handles");
                return;
            }

            Log.Debug(Globals.LogTag, "Preferred voice subscription: " + _call.PreferredVoiceSubscription);
        }
    }
}
