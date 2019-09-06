#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>This enum type describes the state of a touch event.</summary>
[Efl.Eo.BindingEntity]
public enum GestureTouchState
{
/// <summary>Gesture Touch State unknown</summary>
Unknown = 0,
/// <summary>First fingure touch down</summary>
Begin = 1,
/// <summary>fingure touch update</summary>
Update = 2,
/// <summary>Last fingure touch up</summary>
End = 3,
}

}

}

namespace Efl {

namespace Canvas {

/// <summary>This enum type describes the state of a gesture.</summary>
[Efl.Eo.BindingEntity]
public enum GestureState
{
/// <summary>No gesture state</summary>
None = 0,
/// <summary>A continuous gesture has started.</summary>
Started = 1,
/// <summary>A gesture continues.</summary>
Updated = 2,
/// <summary>A gesture has finished.</summary>
Finished = 3,
/// <summary>A gesture was canceled.</summary>
Canceled = 4,
}

}

}

namespace Efl {

namespace Canvas {

/// <summary>This enum type describes the state of a gesture recognizer.</summary>
[Efl.Eo.BindingEntity]
public enum GestureRecognizerResult
{
/// <summary>The event does not change the state of the recognizer.</summary>
Ignore = 1,
/// <summary>The event changed the internal state of the recognizer, but it isn&apos;t clear yet if it is a  gesture or not. The recognizer needs to filter more events to decide.</summary>
Maybe = 2,
/// <summary>The gesture has been triggered</summary>
Trigger = 4,
/// <summary>The gesture has been finished successfully.</summary>
Finish = 8,
/// <summary>The event made it clear that it is not a gesture. If the gesture recognizer was in Triggered state before, then the gesture is canceled.</summary>
Cancel = 16,
/// <summary>The gesture result mask</summary>
ResultMask = 255,
}

}

}

namespace Efl {

namespace Canvas {

/// <summary>This enum type describes the state of a touch event.</summary>
[Efl.Eo.BindingEntity]
public enum GestureRecognizerType
{
Tap = 0,
DoubleTap = 1,
TripleTap = 2,
LongTap = 3,
Momentum = 4,
Flick = 5,
Zoom = 6,
}

}

}

