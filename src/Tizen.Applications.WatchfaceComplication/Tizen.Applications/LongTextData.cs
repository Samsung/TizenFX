using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the LongTextData class for the LongText type complication.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    public class LongTextData : ComplicationData
    {
        private string _longText;
        private string _iconPath;
        private string _title;
        private string _extraData;
        private string _screenReaderText;

        /// <summary>
        /// Initializes the LongTextData class.
        /// </summary>
        /// <param name="longText">The long text.</param>
        /// <param name="iconPath">The icon path.</param>
        /// <param name="title">The title.</param>
        /// <param name="extraData">The extra data.</param>
        /// <exception cref="ArgumentException">Thrown when parameter is invalid.</exception>
        /// <example>
        /// <code>
        ///     protected override ComplicationData OnDataUpdateRequested(string reqestAppId, ComplicationTypes type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationTypes.ShortText)
        ///         {
        ///             return new ShortTextData("short", "icon path", "title", "extra");
        ///         }
        ///         else if (type == ComplicationTypes.LongText)
        ///         {
        ///             return new LongTextData("longlong", "icon path", "title", null);
        ///         }
        ///     }
        /// </code>
        /// </example>
        /// <since_tizen> 5.5 </since_tizen>
        public LongTextData(string longText, string iconPath, string title, string extraData)
        {
            if (longText == null)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam, "fail to create short text");
            _longText = longText;
            _iconPath = iconPath;
            _title = title;
            _extraData = extraData;
        }

        /// <summary>
        /// The long text data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 5.5 </since_tizen>
        public string LongText
        {
            get
            {
                return _longText;
            }
            set
            {
                if (value == null)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "fail to create short text");
                _longText = value;
            }
        }

        /// <summary>
        /// The icon path data.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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
        /// The title data.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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
        /// The extra data.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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
        /// The information about the screen reader text of complication data.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public string ScreenReaderText
        {
            get
            {
                return _screenReaderText;
            }
            set
            {
                _screenReaderText = value;
            }
        }

        internal override ComplicationError UpdateSharedData(IntPtr sharedData)
        {
            Bundle b = new Bundle();
            ComplicationError err = ComplicationError.None;
            err = Interop.WatchfaceComplication.ProviderSetDataType(sharedData, ComplicationTypes.LongText);
            if (err != ComplicationError.None)
                return err;

            err = Interop.WatchfaceComplication.ProviderSetLongText(sharedData, _longText);
            if (err != ComplicationError.None)
                return err;
            Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
            Interop.WatchfaceComplication.ProviderSetTitle(sharedData, _title);
            Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
            Interop.WatchfaceComplication.ProviderSetScreenReaderText(sharedData, _screenReaderText);
            return ComplicationError.None;
        }
    }
}
