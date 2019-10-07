#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

namespace Focus {

/// <summary>Focus directions.</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
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

namespace Efl {

namespace Ui {

namespace Focus {

/// <summary>Focus Movement Policy.</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
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

namespace Efl {

namespace Ui {

/// <summary>Slider&apos;s indicator visibility mode.</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
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
}
}

namespace Efl {

namespace Ui {

namespace Focus {

/// <summary>Focus Autoscroll Mode</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
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

namespace Efl {

namespace Ui {

/// <summary>Software cursor mode.</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Eo.BindingEntity]
public enum SoftcursorMode
{
/// <summary>Auto-detect if a software cursor should be used (default).</summary>
Auto = 0,
/// <summary>Always use a softcursor.</summary>
On = 1,
/// <summary>Never use a softcursor.</summary>
Off = 2,
}
}
}

namespace Efl {

namespace Ui {

/// <summary>Accessibility</summary>
[Efl.Eo.BindingEntity]
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
}
}

namespace Efl {

namespace Ui {

/// <summary>Widget orientation mode, or how the theme handles screen orientation.
/// Note: Support for this feature is highly dependent on the theme in use. At the time of writing, the default theme for EFL does not implement support for orientation modes.</summary>
[Efl.Eo.BindingEntity]
public enum WidgetOrientationMode
{
/// <summary>Default or automatic mode: if the widget&apos;s theme supports orientation, it will be handled automatically.</summary>
Default = 0,
/// <summary>No signal is sent to the widget&apos;s theme. Widget&apos;s theme will not change according to the window or screen orientation.</summary>
Disabled = 1,
}
}
}

namespace Efl {

namespace Ui {

/// <summary>Type of multi selectable object.</summary>
[Efl.Eo.BindingEntity]
public enum SelectMode
{
/// <summary>Only single child is selected. If a child is selected, previous selected child will be unselected.</summary>
Single = 0,
/// <summary>Allow multiple selection of children.</summary>
Multi = 1,
/// <summary>No child can be selected at all.</summary>
None = 2,
}
}
}

