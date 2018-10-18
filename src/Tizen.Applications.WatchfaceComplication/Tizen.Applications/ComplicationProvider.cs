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
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
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

        internal ComplicationError SetComplicationData(IntPtr b, ComplicationType type)
        {
            ComplicationError err = ComplicationError.None;
            err = Interop.WatchfaceComplication.ProviderSetDataType(b, type);
            if (err != ComplicationError.None)
                return err;
            switch (type)
            {
                case ComplicationType.ShortText:
                    err = Interop.WatchfaceComplication.ProviderSetShortText(b, _shortText);
                    Interop.WatchfaceComplication.ProviderSetIconPath(b, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetTitle(b, _title);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
                case ComplicationType.LongText:
                    err = Interop.WatchfaceComplication.ProviderSetLongText(b, _longText);
                    Interop.WatchfaceComplication.ProviderSetIconPath(b, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetTitle(b, _title);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
                case ComplicationType.RangedValue:
                    Interop.WatchfaceComplication.ProviderSetLongText(b, _shortText);
                    Interop.WatchfaceComplication.ProviderSetIconPath(b, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetTitle(b, _title);
                    err = Interop.WatchfaceComplication.ProviderSetRangedValue(b, _currentValue, _minValue, _maxValue);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
                case ComplicationType.Time:
                    err = Interop.WatchfaceComplication.ProviderSetTimestamp(b, _timestamp);
                    Interop.WatchfaceComplication.ProviderSetIconPath(b, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
                case ComplicationType.Icon:
                    err = Interop.WatchfaceComplication.ProviderSetIconPath(b, _iconPath);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
                case ComplicationType.Image:
                    err = Interop.WatchfaceComplication.ProviderSetImagePath(b, _imagePath);
                    Interop.WatchfaceComplication.ProviderSetExtraData(b, _extraData);
                    break;
            }
            return err;
        }

        private void DataUpdateRequested(string providerId, string reqAppId, ComplicationType type,
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
        protected virtual void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        {

        }

        /// <summary>
        /// Sets the title of complication data.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <example>
        /// <code>
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationType.ShortText)
        ///         {
        ///             this.SetTitle("Title");
        ///             this.SetShortText("csharp short text");
        ///         }
        ///     }
        /// }
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
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationType.ShortText)
        ///         {
        ///             this.SetTitle("Title");
        ///             this.SetShortText("csharp short text");
        ///         }
        ///     }
        /// }
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
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationType.ShortText)
        ///         {
        ///             this.SetTitle("Title");
        ///             this.SetLongText("csharp long text");
        ///         }
        ///     }
        /// }
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
        /// <example>
        /// <code>
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationType.Time)
        ///         {
        ///             DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        ///             long ms = (long)(DateTime.UtcNow - epoch).TotalMilliseconds;
        ///             long result = ms / 1000;
        ///             this.SetTimestamp(result);
        ///         }
        ///     }
        /// }
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
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationType.Image)
        ///         {
        ///             this.SetImagePath("image path");
        ///         }
        ///     }
        /// }
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
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationType.RangedValue)
        ///         {
        ///             this.SetRangedValue(30, 0, 100);
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void SetRangedValue(double currentValue, double minValue, double maxValue)
        {
            if (minValue > maxValue || currentValue < minValue || currentValue > maxValue)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam,
                    "invaild ranged value (" + currentValue + "," + minValue + "," + maxValue + ")");
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
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationType.Icon)
        ///         {
        ///             this.SetIconPath("icon path");
        ///         }
        ///     }
        /// }
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
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationType.Icon)
        ///         {
        ///             this.SetIconPath("icon path");
        ///             this.SetExtraData("extra data");
        ///         }
        ///     }
        /// }
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
        /// <exception cref="ArgumentException">Thrown when updatedProviderId is invalid.</exception>
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
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     EventType type = ComplicationProvider.GetEventType(e.ReceivedAppControl);
        ///     if (type == EventType.EventDoubleTap)
        ///     {
        ///         // do something
        ///     }
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>Complication event type</returns>
        /// <since_tizen> 5 </since_tizen>
        public static EventType GetEventType(ReceivedAppControl recvAppCtrl)
        {
            EventType type;
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
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     ComplicationType type = ComplicationProvider.GetEventComplicationType(e.ReceivedAppControl);
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>Event target complication type</returns>
        /// <since_tizen> 5 </since_tizen>
        public static ComplicationType GetEventComplicationType(ReceivedAppControl recvAppCtrl)
        {
            ComplicationType type = ComplicationType.NoData;
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
        /// <example>
        /// <code>
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationType type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationType.Icon)
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
        public bool IsDataValid(ComplicationType type)
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
