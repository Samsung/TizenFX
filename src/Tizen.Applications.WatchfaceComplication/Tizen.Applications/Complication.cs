/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;


namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the Complication class for the watch application which using watchface complication.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class Complication : IEditable, IDisposable
    {
        private int _complicationId;
        private ComplicationTypes _supportTypes;
        private string _defaultProviderId;
        private ComplicationTypes _defaultType;
        private EventTypes _supportEvents;
        private Highlight _highlight;
        internal IntPtr _handle;
        private Interop.WatchfaceComplication.ComplicationUpdatedCallback _updatedCallback;
        private Interop.WatchfaceComplication.ComplicationErrorCallback _errorCallback;
        private IEnumerable<(string allowedProviderId, ComplicationTypes supportTypes)> _allowedList;
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
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <exception cref="ArgumentException">Thrown when the invalid parameter is passed.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have privilege to access this method.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///    }
        /// }
        /// _complication = new MyComplication(_complicationId, (int)(ComplicationTypes.ShortText | ComplicationTypes.Image),
        ///       (int) EventTypes.EventNone, _complicationProviderId, ComplicationTypes.ShortText, _complicationBtn);
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        protected Complication(int complicationId, ComplicationTypes supportTypes, EventTypes supportEvents, string defaultProviderId, ComplicationTypes defaultType)
        {
            _complicationId = complicationId;
            _supportTypes = supportTypes;
            _supportEvents = supportEvents;
            _defaultProviderId = defaultProviderId;
            _defaultType = defaultType;

            ComplicationError ret = Interop.WatchfaceComplication.CreateComplication(complicationId, defaultProviderId, defaultType, (int)supportTypes, (int)supportEvents, out _handle);
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
            Dispose(true);
        }

        /// <summary>
        /// Gets the support types.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ComplicationTypes SupportTypes
        {
            get
            {
                return _supportTypes;
            }
        }

        /// <summary>
        /// Gets the support event types.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public EventTypes SupportEvents
        {
            get
            {
                return _supportEvents;
            }
        }

        /// <summary>
        /// The information of the editable's highlight.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        /// The information of specific allowed provider id, support types list for complication
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<(string allowedProviderId, ComplicationTypes supportTypes)> AllowedList
        {
            get
            {
                return _allowedList;
            }
            set
            {
                _allowedList = value;
                if (_allowedList == null || _allowedList.Count() == 0)
                {
                    Interop.WatchfaceComplication.ClearAllowedList(_handle);
                }
                else
                {
                    IntPtr listRaw;
                    Interop.WatchfaceComplication.CreateAllowedList(out listRaw);
                    List<(string allowedProviderId, ComplicationTypes supportTypes)> list = _allowedList.ToList();
                    foreach (var item in list)
                    {
                        Interop.WatchfaceComplication.AddAllowedList(listRaw, item.allowedProviderId, (int)item.supportTypes);
                    }
                    Interop.WatchfaceComplication.ApplyAllowedList(_handle, listRaw);
                    Interop.WatchfaceComplication.DestroyAllowedList(listRaw);
                }

            }
        }

        /// <summary>
        /// The information of the complication's highlight.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Highlight Highlight
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
        /// The information of complication ID.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
        string IEditable.Name
        {
            get
            {
                string editableName = "";
                Interop.WatchfaceComplication.GetEditableName(_handle, out editableName);
                return editableName;
            }
            set
            {
                Interop.WatchfaceComplication.SetEditableName(_handle, value);
            }
        }

        /// <summary>
        /// Gets the editable's current data index.
        /// </summary>
        /// <returns>The index of current data</returns>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        /// MyComplication comp = new MyComplication();
        /// Bundle curData = comp.GetCurrentDataIndex();
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        int IEditable.GetCurrentDataIndex()
        {
            int curIdx;
            ComplicationError ret = Interop.WatchfaceComplication.GetCurrentIdx(_handle, out curIdx);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to get current idx");
            }
            return curIdx;
        }

        /// <summary>
        /// Gets the editable's current data.
        /// </summary>
        /// <returns>The current data</returns>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        /// MyComplication comp = new MyComplication();
        /// Bundle curData = comp.GetCurrentData();
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        Bundle IEditable.GetCurrentData()
        {
            SafeBundleHandle bundleHandle;
            ComplicationError err = Interop.WatchfaceComplication.GetCurrentData(_handle, out bundleHandle);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "Can not get current data");
            Bundle data = new Bundle(bundleHandle);
            return data;
        }

        /// <summary>
        /// Gets the current provider ID.
        /// </summary>
        /// <returns>The current provider ID</returns>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        /// MyComplication comp = new MyComplication();
        /// string providerId = comp.GetCurrentProviderId();
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public string GetCurrentProviderId()
        {
            string providerId = "";
            ComplicationError err = Interop.WatchfaceComplication.GetCurrentProviderId(_handle, out providerId);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "Can not get current provider id");
            return providerId;
        }

        /// <summary>
        /// Gets the current complication type.
        /// </summary>
        /// <returns>The current complication type</returns>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        /// MyComplication comp = new MyComplication();
        /// ComplicationTypes type = comp.GetCurrentType();
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public ComplicationTypes GetCurrentType()
        {
            ComplicationTypes type;
            ComplicationError err = Interop.WatchfaceComplication.GetCurrentType(_handle, out type);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "Can not get current provider type");
            return type;
        }

        private void ComplicationUpdatedCallback(int complicationId,
            string providerId, ComplicationTypes type, IntPtr data, IntPtr userData)
        {
            if (_complicationId == complicationId)
                OnComplicationUpdated(providerId, type, new Bundle(new SafeBundleHandle(data, false)));
        }

        private void ComplicationErrorCallback(int complicationId,
            string providerId, ComplicationTypes type, ComplicationError error, IntPtr userData)
        {
            if (_complicationId == complicationId)
                OnComplicationError(providerId, type, error);
        }

        /// <summary>
        /// Sends the complication update requests.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have privilege to access this method.</exception>
        /// <example>
        /// <code>
        /// MyComplication comp = new MyComplication();
        /// ComplicationError err = comp.SendUpdateRequest();
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public void SendUpdateRequest()
        {
            ComplicationError ret = Interop.WatchfaceComplication.SendUpdateRequest(_handle);
            if (ret != ComplicationError.None)
                ErrorFactory.ThrowException(ret, "Fail to get send request");
        }

        /// <summary>
        /// Transfers event to the provider.
        /// </summary>
        /// <param name="eventType">The complication event type.</param>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have privilege to access this method.</exception>
        /// <exception cref="ArgumentException">Thrown when the invalid argument is passed.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <example>
        /// <code>
        /// void OnButtonClicked()
        /// {
        ///     comp.TransferEvent(EventTypes.EventTap);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public void TransferEvent(EventTypes eventType)
        {
            ComplicationError ret = Interop.WatchfaceComplication.TransferEvent(_handle, eventType);
            if (ret != ComplicationError.None)
                ErrorFactory.ThrowException(ret, "Fail to transfer event");
        }

        /// <summary>
        /// Gets the complication data type.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <returns>The complication type of data</returns>
        /// <exception cref="ArgumentException">Thrown when the invalid argument is passed.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// ComplicationTypes type = Complication.GetType(dupData);
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static ComplicationTypes GetType(Bundle data)
        {
            ComplicationTypes type;

            ComplicationError err = Interop.WatchfaceComplication.GetDataType(data.SafeBundleHandle, out type);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get data type");
            return type;
        }

        /// <summary>
        /// Gets the short text.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <returns>The short text data</returns>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///        if (type == ComplicationTypes.ShortText)
        ///        {
        ///            string shortText = Complication.GetShortText(data);
        ///            layout.Text = shortText;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static string GetShortText(Bundle data)
        {
            string shortText;

            ComplicationError err = Interop.WatchfaceComplication.GetShortText(data.SafeBundleHandle, out shortText);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get short text");
            return shortText;
        }

        /// <summary>
        /// Gets the long text.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <returns>The long text data</returns>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///        if (type == ComplicationTypes.LongText)
        ///        {
        ///            string longText = Complication.GetLongText(data);
        ///            layout.Text = longText;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static string GetLongText(Bundle data)
        {
            string longText;

            ComplicationError err = Interop.WatchfaceComplication.GetLongText(data.SafeBundleHandle, out longText);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get long text");
            return longText;
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <returns>The title data</returns>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///        if (type == ComplicationTypes.ShortText)
        ///        {
        ///            string title = Complication.GetTitle(data);
        ///            layout.Text = title;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static string GetTitle(Bundle data)
        {
            string title;

            ComplicationError err = Interop.WatchfaceComplication.GetTitle(data.SafeBundleHandle, out title);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get title");
            return title;
        }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <returns>The timestamp data in long value</returns>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///        if (type == ComplicationTypes.Time)
        ///        {
        ///            long time = Complication.GetTimestamp(data);
        ///            layout.Text = time;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static long GetTimestamp(Bundle data)
        {
            long timestamp;

            ComplicationError err = Interop.WatchfaceComplication.GetTimestamp(data.SafeBundleHandle, out timestamp);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get timestamp");
            return timestamp;
        }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <returns>The image path data</returns>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///        if (type == ComplicationTypes.Image)
        ///        {
        ///            string imagePath = Complication.GetImagePath(data);
        ///            layout.Text = imagePath;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static string GetImagePath(Bundle data)
        {
            string imagePath;

            ComplicationError err = Interop.WatchfaceComplication.GetImagePath(data.SafeBundleHandle, out imagePath);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get image path");
            return imagePath;
        }

        /// <summary>
        /// Gets the current value of ranged type data.
        /// </summary>
        /// <returns>The current value of range type data</returns>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///        if (type == ComplicationTypes.RangedValue)
        ///        {
        ///            double currentValue = Complication.GetCurrentValueOfRange(data);
        ///            layout.Text = currentValue;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static double GetCurrentValueOfRange(Bundle data)
        {
            double curVal, minVal, maxVal;

            ComplicationError err = Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get value");
            return curVal;
        }

        /// <summary>
        /// Gets the minimum value of ranged type data.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <returns>The minimum value of range type data</returns>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///        if (type == ComplicationTypes.RangedValue)
        ///        {
        ///            double currentValue = Complication.GetMinValueOfRange(data);
        ///            layout.Text = currentValue;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static double GetMinValueOfRange(Bundle data)
        {
            double curVal, minVal, maxVal;

            ComplicationError err = Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get value");
            return minVal;
        }

        /// <summary>
        /// Gets the max value of ranged type data.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <returns>The maximum value of range type data</returns>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///        if (type == ComplicationTypes.RangedValue)
        ///        {
        ///            double maxValue = Complication.GetMaxValueOfRange(data);
        ///            layout.Text = maxValue;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static double GetMaxValueOfRange(Bundle data)
        {
            double curVal, minVal, maxVal;

            ComplicationError err = Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get value");
            return maxVal;
        }

        /// <summary>
        /// Gets the icon path.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <returns>The icon path data</returns>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///        if (type == ComplicationTypes.Icon)
        ///        {
        ///            string iconPath = Complication.GetIconPath(data);
        ///            layout.Text = iconPath;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static string GetIconPath(Bundle data)
        {
            string iconPath;

            ComplicationError err = Interop.WatchfaceComplication.GetIconPath(data.SafeBundleHandle, out iconPath);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get icon path");
            return iconPath;
        }

        /// <summary>
        /// Gets the extra data.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <returns>The extra string data</returns>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///        if (type == ComplicationTypes.Icon)
        ///        {
        ///            string extraData = Complication.GetExtraData(data);
        ///            layout.Text = extraData;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static string GetExtraData(Bundle data)
        {
            string extraData;

            ComplicationError err = Interop.WatchfaceComplication.GetExtraData(data.SafeBundleHandle, out extraData);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get extra data");
            return extraData;
        }

        /// <summary>
        /// Gets the screen reader text.
        /// </summary>
        /// <param name="data">The data from OnComplicationUpdate callback.</param>
        /// <returns>The screen reader text data</returns>
        /// <exception cref="ArgumentException">Thrown when data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        ///
        /// public class MyComplication : Complication
        /// {
        ///    public MyComplication(int complicationId, int supportTypes, int supportEvents, string defaultProviderId,
        ///        ComplicationTypes defaultType)
        ///        : base(complicationId, supportTypes, supportEvents, defaultProviderId, defaultType)
        ///    {
        ///    }
        ///    protected override void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data)
        ///    {
        ///        if (type == ComplicationTypes.LongText)
        ///        {
        ///            string screenReaderText = Complication.GetScreenReaderText(data);
        ///            layout.Text = screenReaderText;
        ///        }
        ///    }
        /// }
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static string GetScreenReaderText(Bundle data)
        {
            string screenReaderText;

            ComplicationError err = Interop.WatchfaceComplication.GetScreenReaderText(data.SafeBundleHandle, out screenReaderText);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get text");
            return screenReaderText;
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the complication update event comes.
        /// </summary>
        /// <param name="providerId">The updated provider's ID.</param>
        /// <param name="type">The updated type.</param>
        /// <param name="data">The updated data.</param>
        /// <since_tizen> 6 </since_tizen>
        protected abstract void OnComplicationUpdated(string providerId, ComplicationTypes type, Bundle data);

        /// <summary>
        /// Overrides this method to handle the behavior when the complication error occurs.
        /// </summary>
        /// <param name="providerId">The updated provider's ID.</param>
        /// <param name="type">The updated type.</param>
        /// <param name="errorReason">The occured error.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnComplicationError(string providerId, ComplicationTypes type, ComplicationError errorReason)
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
                Interop.WatchfaceComplication.RemoveUpdatedCallback(_handle, _updatedCallback);
                Interop.WatchfaceComplication.Destroy(_handle);
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
            GC.SuppressFinalize(this);
        }
    }
}