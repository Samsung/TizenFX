#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

namespace Ui {

namespace Focus {

/// <summary>Focus directions.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public enum Direction
{
/// <summary>previous direction</summary>
Previous = 0,
/// <summary>next direction</summary>
Next = 1,
/// <summary>up direction</summary>
Up = 2,
/// <summary>down direction</summary>
Down = 3,
/// <summary>right direction</summary>
Right = 4,
/// <summary>left direction</summary>
Left = 5,
/// <summary>last direction</summary>
Last = 6,
}
}
}
}

namespace UIKit {

namespace Ui {

namespace Focus {

/// <summary>Focus Movement Policy.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public enum MovePolicy
{
/// <summary>Move focus by mouse click or touch. Elementary focus is set on mouse click and this is checked at mouse up time. (default)</summary>
Click = 0,
/// <summary>Move focus by mouse in. Elementary focus is set on mouse move when the mouse pointer is moved into an object.</summary>
MoveIn = 1,
/// <summary>Move focus by key. Elementary focus is set on key input like Left, Right, Up, Down, Tab, or Shift+Tab.</summary>
KeyOnly = 2,
}
}
}
}

namespace UIKit {

namespace Ui {

namespace Focus {

/// <summary>Focus Autoscroll Mode</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public enum AutoscrollMode
{
/// <summary>Directly show the focused region or item automatically.</summary>
Show = 0,
/// <summary>Do not show the focused region or item automatically.</summary>
None = 1,
/// <summary>Bring in the focused region or item automatically which might invole the scrolling.</summary>
BringIn = 2,
}
}
}
}

