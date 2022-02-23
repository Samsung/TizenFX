using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Threading;

namespace Tizen.NUI
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IPerformanceProvider
    {
        void Stop(string reference, string tag, string path, string member);

        void Start(string reference, string tag, string path, string member);
    }
}
