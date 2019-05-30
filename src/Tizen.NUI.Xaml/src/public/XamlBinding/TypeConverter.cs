﻿using System;
using System.ComponentModel;
using System.Globalization;

namespace Tizen.NUI.XamlBinding
{
    /// <summary>
    /// The class to converter Type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class TypeConverter
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool CanConvertFrom(Type sourceType)
        {
            if (sourceType == null)
                throw new ArgumentNullException(nameof(sourceType));

            return sourceType == typeof(string);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ConvertFrom is obsolete as of version 2.2.0. Please use ConvertFromInvariantString (string) instead.")]
        public virtual object ConvertFrom(object o)
        {
            return null;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ConvertFrom is obsolete as of version 2.2.0. Please use ConvertFromInvariantString (string) instead.")]
        public virtual object ConvertFrom(CultureInfo culture, object o)
        {
            return null;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual object ConvertFromInvariantString(string value)
        {
#pragma warning disable 0618 // retain until ConvertFrom removed
            return ConvertFrom(CultureInfo.InvariantCulture, value);
#pragma warning restore
        }
    }
}