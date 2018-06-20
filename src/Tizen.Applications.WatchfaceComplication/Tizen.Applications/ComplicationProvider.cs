using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    public abstract class ComplicationProvider
    {
        private Bundle _sharedData;
        private string _providerId;

        public string Id
        {
            get
            {
                return _providerId;
            }
        }

        public ComplicationProvider(string providerId)
        {
            Interop.WatchfaceComplication.AddUpdateRequestedCallback(providerId, DataUpdateRequested, IntPtr.Zero);
            _providerId = providerId;
            _sharedData = new Bundle();
        }

        private void DataUpdateRequested(string providerId, string reqAppId, ComplicationType type,
            IntPtr context, IntPtr sharedData, IntPtr userData)
        {
            OnDataUpdateRequested(reqAppId, type, new Bundle(new SafeBundleHandle(context, false)));
            Bundle nativeShared = new Bundle(new SafeBundleHandle(sharedData, false));
            foreach (string key in _sharedData.Keys)
            {
                string val = _sharedData.GetItem(key).ToString();
                nativeShared.AddItem(key, val);
            }
        }

        protected virtual void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        {

        }

        public int SetTitle(string title)
        {
            Interop.WatchfaceComplication.ProviderSetTitle(_sharedData.SafeBundleHandle, title);
            return 0;
        }

        public int SetShortText(string shortText)
        {
            Interop.WatchfaceComplication.ProviderSetShortText(_sharedData.SafeBundleHandle, shortText);
            return 0;
        }

        public int SetLongText(string longText)
        {
            Interop.WatchfaceComplication.ProviderSetLongText(_sharedData.SafeBundleHandle, longText);
            return 0;
        }

        public int SetTimestamp(long timestamp)
        {
            Interop.WatchfaceComplication.ProviderSetTimestamp(_sharedData.SafeBundleHandle, timestamp);
            return 0;
        }

        public int SetImagePath(string imagePath)
        {
            Interop.WatchfaceComplication.ProviderSetImagePath(_sharedData.SafeBundleHandle, imagePath);
            return 0;
        }

        public int SetRangedValue(double currentValue, double minValue, double maxValue)
        {
            Interop.WatchfaceComplication.ProviderSetRangedValue(_sharedData.SafeBundleHandle, currentValue, minValue, maxValue);
            return 0;
        }

        public int SetIconPath(string iconPath)
        {
            Interop.WatchfaceComplication.ProviderSetIconPath(_sharedData.SafeBundleHandle, iconPath);
            return 0;
        }

        public int SetExtraData(string extraData)
        {
            Interop.WatchfaceComplication.ProviderSetExtraData(_sharedData.SafeBundleHandle, extraData);
            return 0;
        }

        public int NotifyUpdate(string updatedProviderId)
        {
            Interop.WatchfaceComplication.NotifyUpdate(updatedProviderId);
            return 0;
        }

        static bool IsTouchLaunch(AppControlReceivedEventArgs e)
        {
            return false;
        }

        static string GetTouchLaunchProviderId(AppControlReceivedEventArgs e)
        {
            return "";
        }

        static ComplicationType GetTouchLaunchComplicationType(AppControlReceivedEventArgs e)
        {
            return ComplicationType.ShortText;
        }

        static Bundle GetTouchLaunchContext(AppControlReceivedEventArgs e)
        {
            return null;
        }
    }
}
