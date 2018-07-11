using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the ComplicationProvider class for the complication provider service application.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
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

        /// <summary>
        /// Initializes the ComplicationProvider class.
        /// </summary>
        /// <param name="providerId">The id of the complication provider.</param>
        /// <exception cref="ArgumentException">Thrown when providerId is invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public ComplicationProvider(string providerId)
        {
            Interop.WatchfaceComplication.AddUpdateRequestedCallback(providerId, DataUpdateRequested, IntPtr.Zero);
            _providerId = providerId;
        }

        /// <summary>
        /// Gets the provider ID.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Id
        {
            get
            {
                return _providerId;
            }
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


        /// <summary>
        /// Overrides this method to handle the behavior when the complication data update request event comes from watchface complication.
        /// </summary>
        /// <param name="reqestAppId">The application ID of application which sent update request.</param>
        /// <param name="type">The requested type.</param>
        /// <param name="contextData">The complication's context which is set by complication setup application.</param>
        /// <since_tizen> 5 </since_tizen>
        protected virtual void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        {

        }

        /// <summary>
        /// Sets the title of complication data.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void SetTitle(string title)
        {
            _title = title;
        }

        /// <summary>
        /// Sets the short text of complication data.
        /// </summary>
        /// <param name="shortText">The short text.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void SetShortText(string shortText)
        {
            _shortText = shortText;
        }

        /// <summary>
        /// Sets the long text of complication data.
        /// </summary>
        /// <param name="longText">The long text.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void SetLongText(string longText)
        {
            _longText = longText;
        }

        /// <summary>
        /// Sets the timestamp of complication data.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <exception cref="ArgumentException">Thrown when timestamp is invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void SetTimestamp(long timestamp)
        {
            _timestamp = timestamp;
        }

        /// <summary>
        /// Sets the image path of complication data.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void SetImagePath(string imagePath)
        {
            _imagePath = imagePath;
        }

        /// <summary>
        /// Sets the ranged value of complication data.
        /// </summary>
        /// <param name="currentValue">The current value of ranged value.</param>
        /// <param name="minValue">The min value of ranged value.</param>
        /// <param name="maxValue">The max value of ranged value.</param>
        /// <exception cref="ArgumentException">Thrown when value is invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void SetRangedValue(double currentValue, double minValue, double maxValue)
        {
            _currentValue = currentValue;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        /// <summary>
        /// Sets the icon path of complication data.
        /// </summary>
        /// <param name="iconPath">The icon path.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void SetIconPath(string iconPath)
        {
            _iconPath = iconPath;
        }

        /// <summary>
        /// Sets the extra data of complication data.
        /// </summary>
        /// <param name="extraData">The extra data.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void SetExtraData(string extraData)
        {
            _extraData = extraData;
        }

        /// <summary>
        /// Emits the update event for complications.
        /// </summary>
        /// <param name="updatedProviderId">The updated provider ID.</param>
        /// <exception cref="ArgumentException">Thrown when updatedProviderId is invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void NotifyUpdate(string updatedProviderId)
        {
            ComplicationError err = Interop.WatchfaceComplication.NotifyUpdate(updatedProviderId);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to notify");
        }

        /// <summary>
        /// Checks the provider application is launched by touch launch operation.
        /// </summary>
        /// <param name="e">The appcontrol received event args.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <returns>true if the provider is launched by touch launch operation, ortherwise false</returns>
        /// <since_tizen> 5 </since_tizen>
        static bool IsTouchLaunch(AppControlReceivedEventArgs e)
        {
            return false;
        }

        /// <summary>
        /// Gets the target provider id of touch launch operation.
        /// </summary>
        /// <param name="e">The appcontrol received event args.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <returns>Provider id</returns>
        /// <since_tizen> 5 </since_tizen>
        static string GetTouchLaunchProviderId(AppControlReceivedEventArgs e)
        {
            return "";
        }

        /// <summary>
        /// Gets the target complication type of touch launch operation.
        /// </summary>
        /// <param name="e">The appcontrol received event args.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <returns>Complication type</returns>
        /// <since_tizen> 5 </since_tizen>
        static ComplicationType GetTouchLaunchComplicationType(AppControlReceivedEventArgs e)
        {
            return ComplicationType.ShortText;
        }

        /// <summary>
        /// Gets the target complication's context of touch launch operation.
        /// </summary>
        /// <param name="e">The appcontrol received event args.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <returns>Context data</returns>
        /// <since_tizen> 5 </since_tizen>
        static Bundle GetTouchLaunchContext(AppControlReceivedEventArgs e)
        {
            return null;
        }
    }
}
