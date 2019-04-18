using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding.Internals
{
    [Flags]
    internal enum InvalidationTrigger
    {
        Undefined = 0,
        MeasureChanged = 1 << 0,
        HorizontalOptionsChanged = 1 << 1,
        VerticalOptionsChanged = 1 << 2,
        SizeRequestChanged = 1 << 3,
        RendererReady = 1 << 4,
        MarginChanged = 1 << 5
    }
}