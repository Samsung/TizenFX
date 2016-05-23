using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended EventArgs class containing details about the recording limit.
    /// </summary>
    public class RecordingLimitReachedEventArgs : EventArgs
    {
		private RecordingLimitType _type = RecordingLimitType.Size;

		internal RecordingLimitReachedEventArgs(RecordingLimitType type)
		{
			_type = type;
		}

        /// <summary>
        /// The limitation type.
        /// </summary>
        public RecordingLimitType Type
        {
            get
			{
				return _type;
			}
        }
    }
}
