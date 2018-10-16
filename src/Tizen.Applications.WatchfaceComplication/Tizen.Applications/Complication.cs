using System;
using System.Collections.Generic;
using Tizen.Applications;


namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the Complication class for the watch application which using watchface complication.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public abstract class Complication : IEditable
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

        /// <summary>
        /// Initializes the Complication class.
        /// </summary>
        /// <param name="complicationId">The id of the complication.</param>
        /// <param name="supportTypes">The complication support types.</param>
        /// <param name="supportEvents">The complication's support events.</param>
        /// <param name="defaultProviderId">The complication's default provider ID.</param>
        /// <param name="defaultType">The complication's default type.</param>
        /// <exception cref="ArgumentException">Thrown when editableId is invalid.</exception>
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
            set
            {
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
                return null;
            }
        }

        /// <summary>
        /// Gets the editable's current data.
        /// </summary>
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
        /// <example>
        /// <code>
        /// ComplicationType type = comp.GetType(dupData);
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public ComplicationType GetType(Bundle data)
        {
            ComplicationType type;

            Interop.WatchfaceComplication.GetDataType(data.SafeBundleHandle, out type);
            return type;
        }

        /// <summary>
        /// Gets the short text.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
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

            Interop.WatchfaceComplication.GetShortText(data.SafeBundleHandle, out shortText);
            return shortText;
        }

        /// <summary>
        /// Gets the long text.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
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

            Interop.WatchfaceComplication.GetLongText(data.SafeBundleHandle, out longText);
            return longText;
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
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

            Interop.WatchfaceComplication.GetTitle(data.SafeBundleHandle, out title);
            return title;
        }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
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

            Interop.WatchfaceComplication.GetTimestamp(data.SafeBundleHandle, out timestamp);
            return timestamp;
        }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
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

            Interop.WatchfaceComplication.GetImagePath(data.SafeBundleHandle, out imagePath);
            return imagePath;
        }

        /// <summary>
        /// Gets the current value of ranged type data.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
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

            Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            return curVal;
        }

        /// <summary>
        /// Gets the minimum value of ranged type data.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
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

            Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            return minVal;
        }

        /// <summary>
        /// Gets the max value of ranged type data.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
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

            Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            return maxVal;
        }

        /// <summary>
        /// Gets the icon path.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
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

            Interop.WatchfaceComplication.GetIconPath(data.SafeBundleHandle, out iconPath);
            return iconPath;
        }

        /// <summary>
        /// Gets the extra data.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
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
        public string GetExtraData(Bundle data)
        {
            string extraData;

            Interop.WatchfaceComplication.GetIconPath(data.SafeBundleHandle, out extraData);
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
        /// <param name="error">The occured error.</param>
        /// <since_tizen> 5 </since_tizen>
        protected virtual void OnComplicationError(string providerId, ComplicationType type, ComplicationError error)
        {
        }
    }
}