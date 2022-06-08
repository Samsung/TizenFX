using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Uix.Sticker
{
    /// <summary>
    /// Provides data for the <see cref="StickerConsumer.Inserted"/> event.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public class InsertedEventArgs : EventArgs
    {
        private StickerData _data;
        internal InsertedEventArgs(IntPtr data)
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
