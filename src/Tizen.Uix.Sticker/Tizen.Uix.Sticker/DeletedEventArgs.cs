using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Uix.Sticker
{
    /// <summary>
    /// Provides data for the <see cref="StickerConsumer.Deleted"/> event.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public class DeletedEventArgs : EventArgs
    {
        private StickerData _data;
        internal DeletedEventArgs(IntPtr data)
        {
            _data = new StickerData(data);
        }

        /// <summary>
        /// Gets the sticker data.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public StickerData Data
        {
            get
            {
                return _data;
            }
        }
    }
}
