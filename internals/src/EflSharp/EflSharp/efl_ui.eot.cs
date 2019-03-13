#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Return error code when setting the style on a widget.</summary>
public enum ThemeApplyResult
{
/// <summary>Failed to apply theme. The widget may become unusable.</summary>
Fail = 0,
/// <summary>Successfully applied the default style. The widget may look different from the rest of the UI if a custom theme is in use, but it should be usable.</summary>
Default = 1,
/// <summary>Successfully applied the requested style from the current theme.</summary>
Success = 3,
}
} } 
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>Focus directions.</summary>
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
} } } 
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>Focus Movement Policy.
/// 1.10</summary>
public enum MovePolicy
{
/// <summary>Move focus by mouse click or touch. Elementary focus is set on mouse click and this is checked at mouse up time. (default)</summary>
Click = 0,
/// <summary>Move focus by mouse in. Elementary focus is set on mouse move when the mouse pointer is moved into an object.</summary>
In = 1,
/// <summary>Move focus by key. Elementary focus is set on key input like Left, Right, Up, Down, Tab, or Shift+Tab.</summary>
KeyOnly = 2,
}
} } } 
namespace Efl { namespace Ui { 
/// <summary>Slider&apos;s indicator visibility mode.
/// 1.13</summary>
public enum SliderIndicatorVisibleMode
{
/// <summary>show indicator on mouse down or change in slider value</summary>
OnDrag = 0,
/// <summary>Always show the indicator.</summary>
Always = 1,
/// <summary>Show the indicator on focus</summary>
OnFocus = 2,
/// <summary>Never show the indicator</summary>
None = 3,
}
} } 
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>Focus Autoscroll Mode
/// 1.10</summary>
public enum AutoscrollMode
{
/// <summary>Directly show the focused region or item automatically.</summary>
Show = 0,
/// <summary>Do not show the focused region or item automatically.</summary>
None = 1,
/// <summary>Bring in the focused region or item automatically which might invole the scrolling.</summary>
BringIn = 2,
}
} } } 
namespace Efl { namespace Ui { 
/// <summary>Software cursor mode.
/// 1.7</summary>
public enum SoftcursorMode
{
/// <summary>Auto-detect if a software cursor should be used (default).</summary>
Auto = 0,
/// <summary>Always use a softcursor.</summary>
On = 1,
/// <summary>Never use a softcursor.</summary>
Off = 2,
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Accessibility</summary>
public enum Activate
{
/// <summary>Activate default</summary>
Default = 0,
/// <summary>Activate up</summary>
Up = 1,
/// <summary>Activate down</summary>
Down = 2,
/// <summary>Activate right</summary>
Right = 3,
/// <summary>Activate left</summary>
Left = 4,
/// <summary>Activate back</summary>
Back = 5,
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Widget orientation mode, or how the theme handles screen orientation.
/// Note: Support for this feature is highly dependent on the theme in use. At the time of writing, the default theme for EFL does not implement support for orientation modes.</summary>
public enum WidgetOrientationMode
{
/// <summary>Default or automatic mode: if the widget&apos;s theme supports orientation, it will be handled automatically.</summary>
Default = 0,
/// <summary>No signal is sent to the widget&apos;s theme. Widget&apos;s theme will not change according to the window or screen orientation.</summary>
Disabled = 1,
}
} } 
