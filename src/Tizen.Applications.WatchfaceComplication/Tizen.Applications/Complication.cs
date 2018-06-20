using System;
using System.Collections.Generic;
using Tizen.Applications;


namespace Tizen.Applications.WatchfaceComplication
{    
    public abstract class Complication : IEditable
    {
        private int _complicationId;
        private int _supportTypes;
        private string _defaultProviderId;
        private ComplicationType _defaultType;
        private Geometry _geometry;
        private State _state;
        private IEnumerable<Bundle> _candidates;
        private ShapeType _shapeType;
        private Interop.WatchfaceComplication.SafeComplicationHandle _handle;
        private Interop.WatchfaceComplication.ComplicationUpdatedCallback _updatedCallback;
        private int _editableId;

        public Complication(int complicationId, int supportTypes, string defaultProviderId, ComplicationType defaultType, ShapeType shapeType)
        {
            _complicationId = complicationId;
            _supportTypes = supportTypes;
            _defaultProviderId = defaultProviderId;
            _defaultType = defaultType;
            _shapeType = shapeType;

            ComplicationError ret = Interop.WatchfaceComplication.CreateComplication(complicationId, defaultProviderId, defaultType, supportTypes, shapeType, out _handle);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to create complication");
            }
            _updatedCallback = new Interop.WatchfaceComplication.ComplicationUpdatedCallback(ComplicationUpdate);
            ret = Interop.WatchfaceComplication.AddUpdatedCallback(_handle, _updatedCallback, IntPtr.Zero);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to add update callback");
            }
        }

        internal IntPtr Raw
        {
            get
            {
                return _handle.DangerousGetHandle();
            }
        }

        public int SupportTypes
        {
            get
            {
                return _supportTypes;
            }
        }
        
        Geometry IEditable.Geometry
        {
            get
            {
                return _geometry;
            }
            set
            {
                _geometry = value;
            }
        }        

        int IEditable.CurrentDataIndex
        {
            get
            {
                int curIdx;
                ComplicationError ret = Interop.WatchfaceComplication.GetCurrentIdx(_handle.DangerousGetHandle(), out curIdx);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get current idx");
                }
                return curIdx;
            }            
        }

        public int ComplicationId
        {
            get
            {
                return _complicationId;
            }
        }
                
        int IEditable.EditableId
        {
            get
            {
                int editableId;
                ComplicationError ret = Interop.WatchfaceComplication.GetCurrentIdx(_handle.DangerousGetHandle(), out editableId);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get current idx");
                }
                return editableId;
            }
            set
            {
                _editableId = value;
            }
        }
        string IEditable.Name
        {
            get
            {
                return null;
            }
        }

        State IEditable.State
        {
            get
            {
                return _state;
            }
        }

        Bundle IEditable.GetNthData(int index)
        {
            throw new NotImplementedException();
        }

        private void ComplicationUpdate(int complicationId,
            string providerId, ComplicationType type, IntPtr data, IntPtr userData)
        {
            if (_complicationId == complicationId)
                OnComplicationUpdate(providerId, type, new Bundle(new SafeBundleHandle(data, false)));
        }

        public ComplicationError SendUpdateRequest()
        {
            ComplicationError ret = Interop.WatchfaceComplication.SendUpdateRequest(_handle);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to get current idx");
            }
            return ret;
        }

        public ComplicationType GetType(Bundle data)
        {
            ComplicationType type;

            Interop.WatchfaceComplication.GetDataType(data.SafeBundleHandle, out type);
            return type;
        }

        public string GetShortText(Bundle data)
        {
            string shortText;

            Interop.WatchfaceComplication.GetShortText(data.SafeBundleHandle, out shortText);
            return shortText;
        }

        public string GetLongText(Bundle data)
        {
            string longText;

            Interop.WatchfaceComplication.GetShortText(data.SafeBundleHandle, out longText);
            return longText;
        }

        public string GetTitle(Bundle data)
        {
            string title;

            Interop.WatchfaceComplication.GetShortText(data.SafeBundleHandle, out title);
            return title;
        }

        public long GetTimestamp(Bundle data)
        {
            long timestamp;

            Interop.WatchfaceComplication.GetTimestamp(data.SafeBundleHandle, out timestamp);
            return timestamp;
        }

        public string GetImagePath(Bundle data)
        {
            string imagePath;

            Interop.WatchfaceComplication.GetShortText(data.SafeBundleHandle, out imagePath);
            return imagePath;
        }

        public double GetCurrentValue(Bundle data)
        {
            double curVal, minVal, maxVal;

            Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            return curVal;
        }

        public double GetMinValue(Bundle data)
        {
            double curVal, minVal, maxVal;

            Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            return minVal;
        }

        public double GetMaxValue(Bundle data)
        {
            double curVal, minVal, maxVal;

            Interop.WatchfaceComplication.GetRangedValue(data.SafeBundleHandle, out curVal, out minVal, out maxVal);
            return maxVal;
        }

        public string GetIconPath(Bundle data)
        {
            string iconPath;

            Interop.WatchfaceComplication.GetIconPath(data.SafeBundleHandle, out iconPath);
            return iconPath;
        }

        public string GetExtraData(Bundle data)
        {
            string extraData;

            Interop.WatchfaceComplication.GetIconPath(data.SafeBundleHandle, out extraData);
            return extraData;
        }

        protected virtual void OnComplicationUpdate(string providerId, ComplicationType type, Bundle data)
        {
        }        
    }
}
