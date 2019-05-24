using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The class ArrayExtension.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [ContentProperty("Items")]
    [AcceptEmptyServiceProvider]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ArrayExtension : IMarkupExtension<Array>
    {
        /// <summary>
        /// Create a new ArrayExtension.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ArrayExtension()
        {
            Items = new List<object>();
        }

        /// <summary>
        /// Attribute Items.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList Items { get; }

        /// <summary>
        /// Attribute Type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Type Type { get; set; }

        /// <summary>
        /// Provide value tye service provideer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Array ProvideValue(IServiceProvider serviceProvider)
        {
            if (Type == null)
                throw new InvalidOperationException("Type argument mandatory for x:Array extension");

            if (Items == null)
                return null;

            var array = Array.CreateInstance(Type, Items.Count);
            for (var i = 0; i < Items.Count; i++)
                ((IList)array)[i] = Items[i];

            return array;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<Array>).ProvideValue(serviceProvider);
        }
    }
}