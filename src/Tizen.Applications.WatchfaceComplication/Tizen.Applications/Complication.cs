using System;
using System.Collections.Generic;
using Tizen.Applications;


namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the Complication class for the watch application which using watchface complication.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public abstract class Complication : IEditable, IDisposable
    {
        private int _complicationId;
        private int _supportTypes;
        private string _defaultProviderId;
        private ComplicationType _defaultType;
        private Highlight _highlight;
        private IntPtr _handle;
        private Interop.WatchfaceComplication.ComplicationUpdatedCallback _updatedCallback;
        private Interop.WatchfaceComplication.ComplicationErrorCallback _errorCallback;
        private int _editableId;
        private bool _disposed = false;

        /// <summary>
        /// Initializes the Complication class.
        /// </summary>
        /// <param name="complicationId">The id of the complication.</param>
        /// <param name="supportTypes">The complication support types.</param>
        /// <param name="supportEvents">The complication's support events.</param>
        /// <param name="defaultProviderId">The complication's default provider ID.</param>
        /// <param name="defaultType">The complication's default type.</param>
        /// <exception cref="ArgumentException">Thrown when editableId is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationType defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        ///    {
        ///    }
        /// }
        /// _complication = new MyComplication(_complicationId, (int)(ComplicationType.ShortText | ComplicationType.Image),
        ///       (int) EventType.EventNone, _complicationProviderId, ComplicationType.ShortText, _complicationBtn);
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public Complication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId, ComplicationType defaultType)
        {
            _complicationId = complicationId;
            _supportTypes = supportTypes;
            _defaultProviderId = defaultProviderId;
            _defaultType = defaultType;

            ComplicationError ret = Interop.WatchfaceComplication.CreateComplication(complicationId, defaultProviderId, defaultType, supportTypes, supportEvents, out _handle);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to create complication");
            }
            _updatedCallback = new Interop.WatchfaceComplication.ComplicationUpdatedCallback(ComplicationUpdatedCallback);
            _errorCallback = new Interop.WatchfaceComplication.ComplicationErrorCallback(ComplicationErrorCallback);
            ret = Interop.WatchfaceComplication.AddUpdatedCallback(_handle, _updatedCallback, _errorCallback, IntPtr.Zero);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to add update callback");
            }
        }

        /// <summary>
        /// Destructor of the complication class.
        /// </summary>
        ~Complication()
        {
            Dispose(false);
        }

        internal IntPtr Raw
        {
            get
            {
                return _handle;
            }
        }

        /// <summary>
        /// Gets the support types.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int SupportTypes
        {
            get
            {
                return _supportTypes;
            }
        }

        /// <summary>
        /// The information of editable geometry.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Highlight IEditable.Highlight
        {
            get
            {
                return _highlight;
            }
            set
            {
                _highlight = value;
            }
        }

        /// <summary>
        /// The information of editable's current data index.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        int IEditable.CurrentDataIndex
        {
            get
            {
                int curIdx;
                ComplicationError ret = Interop.WatchfaceComplication.GetCurrentIdx(_handle, out curIdx);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get current idx");
                }
                return curIdx;
            }
        }

        /// <summary>
        /// The information of complication ID.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int ComplicationId
        {
            get
            {
                return _complicationId;
            }
        }

        /// <summary>
        /// The information of editable ID.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        int IEditable.EditableId
        {
            get
            {
                return _editableId;
            }
            set
            {
                _editableId = value;
            }
        }

        /// <summary>
        /// The information of editable name.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        string IEditable.Name
        {
            get
            {
                string editableName = "";
                Interop.WatchfaceComplication.GetEditableName(_handle, out editableName);
                return editableName;
            }
        }

        /// <summary>
        /// Gets the editable's current data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when editableId is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        /// MyComplication comp = new MyComplication();
        /// Bundle curData = comp.GetCurrentData();
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        Bundle IEditable.GetCurrentData()
        {
            SafeBundleHandle bundleHandle;
            ComplicationError err = Interop.WatchfaceComplication.GetCurrentData(_handle, out bundleHandle);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "Can not get current data");
            Bundle data = new Bundle(bundleHandle);
            return data;
        }

        private void ComplicationUpdatedCallback(int complicationId,
            string providerId, ComplicationType type, IntPtr data, IntPtr userData)
        {
            if (_complicationId == complicationId)
                OnComplicationUpdated(providerId, type, new Bundle(new SafeBundleHandle(data, false)));
        }

        private void ComplicationErrorCallback(int complicationId,
            string providerId, ComplicationType type, ComplicationError error, IntPtr userData)
        {
            if (_complicationId == complicationId)
                OnComplicationError(providerId, type, error);
        }

        /// <summary>
        /// Sends the complication update requests.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when editableId is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        /// MyComplication comp = new MyComplication();
        /// ComplicationError err = comp.SendUpdateRequest();
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public ComplicationError SendUpdateRequest()
        {
            ComplicationError ret = Interop.WatchfaceComplication.SendUpdateRequest(_handle);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to get current idx");
            }
            return ret;
        }

        /// <summary>
        /// Gets the complication data type.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when editableId is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        /// ComplicationType type = comp.GetType(dupData);
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public ComplicationType GetType(Bundle data)
        {
            ComplicationType type;

            ComplicationError err = Interop.WatchfaceComplication.GetDataType(data.SafeBundleHandle, out type);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");
            return type;
        }

        /// <summary>
        /// Gets the short text.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationType defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        ///    {
        ///        if (type == ComplicationType.ShortText)
        ///        {
        ///            string shortText = this.GetShortText(data);
        ///            layout.Text = shortText;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public string GetShortText(Bundle data)
        {
            string shortText;

            ComplicationError err = Interop.WatchfaceComplication.GetShortText(data.SafeBundleHandle, out shortText);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");
            return shortText;
        }

        /// <summary>
        /// Gets the long text.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationType defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        ///    {
        ///        if (type == ComplicationType.LongText)
        ///        {
        ///            string longText = this.GetLongText(data);
        ///            layout.Text = longText;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public string GetLongText(Bundle data)
        {
            string longText;

            ComplicationError err = Interop.WatchfaceComplication.GetLongText(data.SafeBundleHandle, out longText);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");
            return longText;
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationType defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        ///    {
        ///        if (type == ComplicationType.ShortText)
        ///        {
        ///            string title = this.GetTitle(data);
        ///            layout.Text = title;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public string GetTitle(Bundle data)
        {
            string title;

            ComplicationError err = Interop.WatchfaceComplication.GetTitle(data.SafeBundleHandle, out title);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");
            return title;
        }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationType defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        ///    {
        ///        if (type == ComplicationType.Time)
        ///        {
        ///            long time = this.GetTime(data);
        ///            layout.Text = time;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public long GetTimestamp(Bundle data)
        {
            long timestamp;

            ComplicationError err = Interop.WatchfaceComplication.GetTimestamp(data.SafeBundleHandle, out timestamp);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");
            return timestamp;
        }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationType defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        ///    {
        ///        if (type == ComplicationType.Image)
        ///        {
        ///            string imagePath = this.GetImagePath(data);
        ///            layout.Text = imagePath;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public string GetImagePath(Bundle data)
        {
            string imagePath;

            ComplicationError err = Interop.WatchfaceComplication.GetImagePath(data.SafeBundleHandle, out imagePath);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");
            return imagePath;
        }

        /// <summary>
        /// Gets the current value of ranged type data.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationType defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        ///    {
        ///        if (type == ComplicationType.RangedValue)
        ///        {
        ///            double currentValue = this.GetCurrentValueOfRange(data);
        ///            layout.Text = currentValue;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public double GetCurrentValueOfRange(Bundle data)
        {
            double curVal, minVal, maxVal;

            ComplicationError err = Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");
            return curVal;
        }

        /// <summary>
        /// Gets the minimum value of ranged type data.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationType defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        ///    {
        ///        if (type == ComplicationType.RangedValue)
        ///        {
        ///            double currentValue = this.GetCurrentValueOfRange(data);
        ///            layout.Text = currentValue;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public double GetMinValueOfRange(Bundle data)
        {
            double curVal, minVal, maxVal;

            ComplicationError err = Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");
            return minVal;
        }

        /// <summary>
        /// Gets the max value of ranged type data.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationType defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        ///    {
        ///        if (type == ComplicationType.RangedValue)
        ///        {
        ///            double maxValue = this.GetMaxValueOfRange(data);
        ///            layout.Text = maxValue;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public double GetMaxValueOfRange(Bundle data)
        {
            double curVal, minVal, maxVal;

            ComplicationError err = Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");
            return maxVal;
        }

        /// <summary>
        /// Gets the icon path.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationType defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        ///    {
        ///        if (type == ComplicationType.Icon)
        ///        {
        ///            string iconPath = this.GetIconPath(data);
        ///            layout.Text = iconPath;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public string GetIconPath(Bundle data)
        {
            string iconPath;

            ComplicationError err = Interop.WatchfaceComplication.GetIconPath(data.SafeBundleHandle, out iconPath);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");
            return iconPath;
        }

        /// <summary>
        /// Gets the extra data.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationType defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        ///    {
        ///        if (type == ComplicationType.Icon)
        ///        {
        ///            string extraData = this.GetExtraData(data);
        ///            layout.Text = extraData;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public static string GetExtraData(Bundle data)
        {
            string extraData;

            ComplicationError err = Interop.WatchfaceComplication.GetIconPath(data.SafeBundleHandle, out extraData);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");
            return extraData;
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the complication update event comes.
        /// </summary>
        /// <param name="providerId">The updated provider's ID.</param>
        /// <param name="type">The updated type.</param>
        /// <param name="data">The updated data.</param>
        /// <since_tizen> 5 </since_tizen>
        protected virtual void OnComplicationUpdated(string providerId, ComplicationType type, Bundle data)
        {
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the complication error occurs.
        /// </summary>
        /// <param name="providerId">The updated provider's ID.</param>
        /// <param name="type">The updated type.</param>
        /// <param name="errorReason">The occured error.</param>
        /// <since_tizen> 5 </since_tizen>
        protected virtual void OnComplicationError(string providerId, ComplicationType type, ComplicationError errorReason)
        {
        }

        /// <summary>
        /// Releases the unmanaged resources used by the Complication class specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Interop.WatchfaceComplication.Destroy(_handle);
                }
                Interop.WatchfaceComplication.RemoveUpdatedCallback(_handle, _updatedCallback);
                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the Complication class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}