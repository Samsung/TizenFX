using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the IconData class for the Icon type complication.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class IconData : ComplicationData
    {
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
            Type = ComplicationTypes.Icon;
            IconPath = iconPath;
            ExtraData = extraData;
        }

        /// <summary>
        /// The icon path data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public new string IconPath
        {
            get
            {
                return base.IconPath;
            }
            set
            {
                if (value == null)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "icon path can not be null");
                base.IconPath = value;
            }
        }

        /// <summary>
        /// The extra data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public new string ExtraData
        {
            get
            {
                return base.ExtraData;
            }
            set
            {
                base.ExtraData = value;
            }
        }

        /// <summary>
        /// The information about the screen reader text of complication data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public new string ScreenReaderText
        {
            get
            {
                return base.ScreenReaderText;
            }
            set
            {
                base.ScreenReaderText = value;
            }
        }
    }
}
