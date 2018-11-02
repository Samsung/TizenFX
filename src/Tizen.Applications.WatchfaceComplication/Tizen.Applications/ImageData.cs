using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication.Tizen.Applications
{
    class ImageData : ComplicationData
    {
        private string _imagePath;
        private string _extraData;
        private string _screenReaderText;

        /// <summary>
        /// Initializes the IconData class.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <param name="extraData">The extra data.</param>
        /// <exception cref="ArgumentException">Thrown when parameter is invalid.</exception>
        /// <example>
        /// <code>
        ///     protected override ComplicationData OnDataUpdateRequested(string reqestAppId, ComplicationTypes type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationTypes.Image)
        ///         {
        ///             return new ImageData("Image path", "extra");
        ///         }
        ///         else if (type == ComplicationTypes.LongText)
        ///         {
        ///             return new LongTextData("longlong", "icon path", "title", null);
        ///         }
        ///     }
        /// </code>
        /// </example>
        /// <since_tizen> 5.5 </since_tizen>
        public ImageData(string imagePath, string extraData)
        {
            if (imagePath == null)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam, "image path can not be null");
            _imagePath = imagePath;
            _extraData = extraData;
        }

        /// <summary>
        /// The iamge path data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 5.5 </since_tizen>
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                if (value == null)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "image path can not be null");
                _imagePath = value;
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
        /// <since_tizen> 5 </since_tizen>
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
            err = Interop.WatchfaceComplication.ProviderSetDataType(sharedData, ComplicationTypes.Image);
            if (err != ComplicationError.None)
                return err;

            err = Interop.WatchfaceComplication.ProviderSetImagePath(sharedData, _imagePath);
            if (err != ComplicationError.None)
                return err;
            Interop.WatchfaceComplication.ProviderSetExtraData(sharedData, _extraData);
            Interop.WatchfaceComplication.ProviderSetScreenReaderText(sharedData, _screenReaderText);
            return ComplicationError.None;
        }
    }
}
