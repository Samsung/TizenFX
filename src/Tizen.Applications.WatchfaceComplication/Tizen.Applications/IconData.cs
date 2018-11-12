using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    class IconData : ComplicationData
    {
        private string _iconPath;
        private string _extraData;
        private string _screenReaderText;

        /// <summary>
        /// Initializes the IconData class.
        /// </summary>
        /// <param name="iconPath">The icon path.</param>
        /// <param name="extraData">The extra data.</param>
        /// <exception cref="ArgumentException">Thrown when parameter is invalid.</exception>
        /// <example>
        /// <code>
        ///     protected override ComplicationData OnDataUpdateRequested(string reqestAppId, ComplicationTypes type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationTypes.Icon)
        ///         {                
        ///             return new IconData("Icon", "extra");
        ///         }
        ///         else if (type == ComplicationTypes.LongText)
        ///         {
        ///             return new LongTextData("longlong", "icon path", "title", null);
        ///         }
        ///     }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public IconData(string iconPath, string extraData)
        {
            if (iconPath == null)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam, "icon path can not be null");
            _iconPath = iconPath;
            _extraData = extraData;
        }

        /// <summary>
        /// The icon path data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public string IconPath
        {
            get
            {
                return _iconPath;
            }
            set
            {
                if (value == null)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "icon path can not be null");
                _iconPath = value;
            }
        }

        /// <summary>
        /// The extra data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
            err = Interop.WatchfaceComplication.ProviderSetDataType(sharedData, ComplicationTypes.Icon);
            if (err != ComplicationError.None)
                return err;

            err = Interop.WatchfaceComplication.ProviderSetIconPath(sharedData, _iconPath);
            if (err != ComplicationError.None)
                return err;
            Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
            Interop.WatchfaceComplication.ProviderSetScreenReaderText(sharedData, _screenReaderText);
            return ComplicationError.None;
        }
    }
}
