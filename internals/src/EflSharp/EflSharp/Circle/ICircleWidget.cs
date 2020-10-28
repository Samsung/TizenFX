using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            /// <summary>
            /// The ICircleWidget interface.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public interface ICircleWidget
            {
                /// <summary>
                /// The CircleHandle is a native handle of circle widget.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                IntPtr CircleHandle { get; }
            }
        }
    }
}
