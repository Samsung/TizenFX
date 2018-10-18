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
        private const string LogTag = "WatchfaceComplication";

        /// <summary>
        /// Initializes the ComplicationProvider class.
        /// </summary>
        /// <param name="providerId">The id of the complication provider.</param>
        /// <exception cref="ArgumentException">Thrown when providerId is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationTypes type, Bundle contextData)
        ///     {
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        protected ComplicationProvider(string providerId)
        {
            ComplicationError err = Interop.WatchfaceComplication.AddUpdateRequestedCallback(providerId, DataUpdateRequested, IntPtr.Zero);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to create provider");
            _providerId = providerId;
        }

        /// <summary>
        /// Destructor of the provider class.
        /// </summary>
        ~ComplicationProvider()
        {
            Interop.WatchfaceComplication.RemoveUpdateRequestedCallback(_providerId, DataUpdateRequested);
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

        internal ComplicationError SetComplicationData(IntPtr b, ComplicationTypes type)
        {
            ComplicationError err = ComplicationError.None;
            err = Interop.WatchfaceComplication.ProviderSetDataType(b, type);
            if (err != ComplicationError.None)
                return err;
            switch (type)
            {
                case ComplicationTypes.ShortText:
                    err = Interop.WatchfaceComplication.ProviderSetShortText(b, _shortText);
                    Interop.WatchfaceComplication.ProviderSetIconPath(b, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetTitle(b, _title);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
                case ComplicationTypes.LongText:
                    err = Interop.WatchfaceComplication.ProviderSetLongText(b, _longText);
                    Interop.WatchfaceComplication.ProviderSetIconPath(b, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetTitle(b, _title);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
                case ComplicationTypes.RangedValue:
                    Interop.WatchfaceComplication.ProviderSetLongText(b, _shortText);
                    Interop.WatchfaceComplication.ProviderSetIconPath(b, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetTitle(b, _title);
                    err = Interop.WatchfaceComplication.ProviderSetRangedValue(b, _currentValue, _minValue, _maxValue);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
                case ComplicationTypes.Time:
                    err = Interop.WatchfaceComplication.ProviderSetTimestamp(b, _timestamp);
                    Interop.WatchfaceComplication.ProviderSetIconPath(b, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
                case ComplicationTypes.Icon:
                    err = Interop.WatchfaceComplication.ProviderSetIconPath(b, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
                case ComplicationTypes.Image:
                    err = Interop.WatchfaceComplication.ProviderSetImagePath(b, _imagePath);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
            }
            return err;
        }

        private void DataUpdateRequested(string providerId, string reqAppId, ComplicationTypes type,
            IntPtr context, IntPtr sharedData, IntPtr userData)
        {
            Bundle bContext = new Bundle(new SafeBundleHandle(context, false));
            OnDataUpdateRequested(reqAppId, type, bContext);
            ComplicationError err = SetComplicationData(sharedData, type);
            if (err != ComplicationError.None)
                Log.Error(LogTag, "Set complication data error : " + err);
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the complication data update request event comes from watchface complication.
        /// </summary>
        /// <param name="reqestAppId">The application ID of application which sent update request.</param>
        /// <param name="type">The requested type.</param>
        /// <param name="contextData">The complication's context which is set by complication setup application.</param>
        /// <since_tizen> 5 </since_tizen>
        protected abstract void OnDataUpdateRequested(string reqestAppId, ComplicationTypes type, Bundle contextData);


        /// <summary>
        /// The information about the title of complication data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// The information about the short text of complication data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string ShortText
        {
            get
            {
                return _shortText;
            }
            set
            {
                _shortText = value;
            }
        }

        /// <summary>
        /// The information about the long text of complication data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string LongText
        {
            get
            {
                return _longText;
            }
            set
            {
                _longText = value;
            }
        }

        /// <summary>
        /// The information about the timestamp of complication data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public long Timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                _timestamp = value;
            }
        }

        /// <summary>
        /// The information about the image path of complication data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }

        /// <summary>
        /// The information about the current range value of complication data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public double RangeCurrent
        {
            get
            {
                return _currentValue;
            }
            set
            {
                _currentValue = value;
            }
        }

        /// <summary>
        /// The information about the min range value of complication data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public double RangeMin
        {
            get
            {
                return _minValue;
            }
            set
            {
                _minValue = value;
            }
        }

        /// <summary>
        /// The information about the max range value of complication data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public double RangeMax
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
            }
        }

        /// <summary>
        /// The information about the icon path of complication data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string IconPath
        {
            get
            {
                return _iconPath;
            }
            set
            {
                _iconPath = value;
            }
        }

        /// <summary>
        /// The information about the extra data of complication data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string ExtraData
        {
            get
            {
                return _extraData;
            }
            set
            {
                _extraData = value;
            }
        }

        /// <summary>
        /// Emits the update event for complications.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when updatedProviderId is invalid.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
        public void NotifyUpdate()
        {
            ComplicationError err = Interop.WatchfaceComplication.NotifyUpdate(_providerId);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to notify");
        }

        /// <summary>
        /// Gets the received event type.
        /// </summary>
        /// <param name="recvAppCtrl">The appcontrol received event args.</param>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     EventTypes type = ComplicationProvider.GetEventType(e.ReceivedAppControl);
        ///     if (type == EventTypes.EventDoubleTap)
        ///     {
        ///         // do something
        ///     }
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>Complication event type</returns>
        /// <since_tizen> 5 </since_tizen>
        public static EventTypes GetEventType(ReceivedAppControl recvAppCtrl)
        {
            EventTypes type;
            ComplicationError err = Interop.WatchfaceComplication.GetEventType(recvAppCtrl.SafeAppControlHandle, out type);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get event");
            return type;
        }

        /// <summary>
        /// Gets the received event target provider ID.
        /// </summary>
        /// <param name="recvAppCtrl">The appcontrol received event args.</param>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     string providerId = ComplicationProvider.GetEventProviderId(e.ReceivedAppControl);
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>Event target provider ID</returns>
        /// <since_tizen> 5 </since_tizen>
        public static string GetEventProviderId(ReceivedAppControl recvAppCtrl)
        {
            string providerId = string.Empty;
            ComplicationError err = Interop.WatchfaceComplication.GetEventProviderId(recvAppCtrl.SafeAppControlHandle, out providerId);
            if (err != ComplicationError.None && err != ComplicationError.NoData)
                ErrorFactory.ThrowException(err, "fail to get event");
            return providerId;
        }

        /// <summary>
        /// Gets the received event target complication type.
        /// </summary>
        /// <param name="recvAppCtrl">The appcontrol received event args.</param>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     ComplicationTypes type = ComplicationProvider.GetEventComplicationType(e.ReceivedAppControl);
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>Event target complication type</returns>
        /// <since_tizen> 5 </since_tizen>
        public static ComplicationTypes GetEventComplicationType(ReceivedAppControl recvAppCtrl)
        {
            ComplicationTypes type;
            ComplicationError err = Interop.WatchfaceComplication.GetEventComplicationType(recvAppCtrl.SafeAppControlHandle, out type);
            if (err != ComplicationError.None && err != ComplicationError.NoData)
                ErrorFactory.ThrowException(err, "fail to get complication type");
            return type;
        }

        /// <summary>
        /// Gets the received event target complication context.
        /// </summary>
        /// <param name="e">The appcontrol received event args.</param>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     Bundle context = ComplicationProvider.GetEventContext(e.ReceivedAppControl);
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>Event target complication context</returns>
        /// <since_tizen> 5 </since_tizen>
        public static Bundle GetEventContext(AppControlReceivedEventArgs e)
        {
            SafeBundleHandle bHandle;
            ComplicationError err = Interop.WatchfaceComplication.GetEventContext(e.ReceivedAppControl.SafeAppControlHandle, out bHandle);
            if (err != ComplicationError.None)
            {
                if (err == ComplicationError.NoData)
                    return null;
                ErrorFactory.ThrowException(err, "fail to get complication context");
            }

            return new Bundle(bHandle);
        }

        /// <summary>
        /// Checks the provider's complication data is valid.
        /// </summary>
        /// <param name="type">The complication type to check.</param>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationTypes type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationTypes.Icon)
        ///         {
        ///             this.SetIconPath("icon path");
        ///             this.SetExtraData("extra data");
        ///         }
        ///         bool isValid = this.IsDataValid(type);
        ///         if (!isValid)
        ///             Log.Error("test", "Invalid data, cannot send data to complication");
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <returns>true if complication data is valid</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool IsDataValid(ComplicationTypes type)
        {
            bool isValid = false;
            Bundle shared = new Bundle();
            SetComplicationData(shared.SafeBundleHandle.DangerousGetHandle(), type);
            ComplicationError err = Interop.WatchfaceComplication.ProviderSharedDataIsValid(shared.SafeBundleHandle.DangerousGetHandle(), out isValid);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get complication context");
            return isValid;
        }
    }
}
