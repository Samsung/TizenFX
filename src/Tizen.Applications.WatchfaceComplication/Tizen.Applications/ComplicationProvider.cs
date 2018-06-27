using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    public abstract class ComplicationProvider
    {
        private string _providerId;
        private string _title;
        private string _shortText;
        private string _longText;
        private long _timestamp;
        private string _imagePath;
        private double _currentValue;
        private double _minValue;
        private double _maxValue;
        private string _iconPath;
        private string _extraData;

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
        }

        private void DataUpdateRequested(string providerId, string reqAppId, ComplicationType type,
            IntPtr context, IntPtr sharedData, IntPtr userData)
        {
            OnDataUpdateRequested(reqAppId, type, new Bundle(new SafeBundleHandle(context, false)));
            ComplicationError err;

            err = Interop.WatchfaceComplication.ProviderSetType(sharedData, type);
            switch (type)
            {
                case ComplicationType.ShortText:
                    err = Interop.WatchfaceComplication.ProviderSetShortText(sharedData, _shortText);
                    err = Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
                    err = Interop.WatchfaceComplication.ProviderSetTitle(sharedData, _title);
                    err = Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
                case ComplicationType.LongText:
                    err = Interop.WatchfaceComplication.ProviderSetLongText(sharedData, _longText);
                    err = Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
                    err = Interop.WatchfaceComplication.ProviderSetTitle(sharedData, _title);
                    err = Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
                case ComplicationType.RangedValue:
                    err = Interop.WatchfaceComplication.ProviderSetLongText(sharedData, _shortText);
                    err = Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
                    err = Interop.WatchfaceComplication.ProviderSetTitle(sharedData, _title);
                    err = Interop.WatchfaceComplication.ProviderSetRangedValue(sharedData, _currentValue, _minValue, _maxValue);
                    err = Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
                case ComplicationType.Time:
                    err = Interop.WatchfaceComplication.ProviderSetTimestamp(sharedData, _timestamp);
                    err = Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
                    err = Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
                case ComplicationType.Icon:
                    err = Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
                    err = Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
                case ComplicationType.Image:
                    err = Interop.WatchfaceComplication.ProviderSetImagePath(sharedData, _imagePath);
                    err = Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
                    break;
            }
        }

        protected virtual void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        {

        }

        public ComplicationError SetTitle(string title)
        {
            _title = title;
            return ComplicationError.None;
        }

        public ComplicationError SetShortText(string shortText)
        {
            _shortText = shortText;
            return ComplicationError.None;
        }

        public ComplicationError SetLongText(string longText)
        {
            _longText = longText;
            return ComplicationError.None;
        }

        public ComplicationError SetTimestamp(long timestamp)
        {
            _timestamp = timestamp;
            return ComplicationError.None;
        }

        public ComplicationError SetImagePath(string imagePath)
        {
            _imagePath = imagePath;
            return ComplicationError.None;
        }

        public ComplicationError SetRangedValue(double currentValue, double minValue, double maxValue)
        {
            _currentValue = currentValue;
            _minValue = minValue;
            _maxValue = maxValue;
            return ComplicationError.None;
        }

        public ComplicationError SetIconPath(string iconPath)
        {
            _iconPath = iconPath;
            return ComplicationError.None;
        }

        public ComplicationError SetExtraData(string extraData)
        {
            _extraData = extraData;
            return ComplicationError.None;
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
