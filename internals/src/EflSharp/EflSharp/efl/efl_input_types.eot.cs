#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Pointer {

/// <summary>Pointer event type. Represents which kind of event this is.
/// (Since EFL 1.19)</summary>
public enum Action
{
/// <summary>Not a valid event, or nothing new happened (eg. when querying current state of touch points).</summary>
None = 0,
/// <summary>Mouse or equivalent pointer moved.</summary>
Move = 1,
/// <summary>Mouse button or equivalent pointer pressed down. Always followed by up or cancel.</summary>
Down = 2,
/// <summary>Mouse button or equivalent pointer released. See also cancel.</summary>
Up = 3,
/// <summary>Special event happening after a down if the up counterpart can not happen (eg. another window forcibly stole the focus).</summary>
Cancel = 4,
/// <summary>Mouse or pointer entered the object.</summary>
In = 5,
/// <summary>Mouse or pointer exited the object.</summary>
Out = 6,
/// <summary>Mouse wheel scroll, horizontally or vertically.</summary>
Wheel = 7,
/// <summary>Axis event (pen, stick, ...).</summary>
Axis = 8,
}

}

}

namespace Efl {

namespace Pointer {

/// <summary>Pointer flags indicating whether a double or triple click is under way.
/// (Since EFL 1.19)</summary>
public enum Flags
{
/// <summary>No extra mouse button data</summary>
None = 0,
/// <summary>This mouse button press was the 2nd press of a double click</summary>
DoubleClick = 1,
/// <summary>This mouse button press was the 3rd press of a triple click</summary>
TripleClick = 2,
}

}

}

namespace Efl {

namespace Input {

/// <summary>Special flags set during an input event propagation.
/// (Since EFL 1.19)</summary>
public enum Flags
{
/// <summary>No fancy flags set</summary>
None = 0,
/// <summary>This event is being delivered and has been processed, so it should be put &quot;on hold&quot; until the flag is unset. The event should be used for informational purposes and maybe some indications visually, but not actually perform anything.</summary>
Processed = 1,
/// <summary>This event flag indicates the event occurs while scrolling; for example, DOWN event occurs during scrolling. The event should be used for informational purposes and maybe some indications visually, but not actually perform anything.</summary>
Scrolling = 2,
}

}

}

namespace Efl {

namespace Input {

/// <summary>How the mouse pointer should be handled by EFL.
/// In the mode <c>autograb</c>, when a mouse button is pressed down over an object and held down, with the mouse pointer being moved outside of it, the pointer still behaves as being bound to that object, albeit out of its drawing region. When the button is released, the event will be fed to the object, that may check if the final position is over it or not and do something about it.
/// 
/// In the mode <c>nograb</c>, the pointer will always be bound to the object right below it.
/// (Since EFL 1.19)</summary>
public enum ObjectPointerMode
{
/// <summary>Default, X11-like.</summary>
AutoGrab = 0,
/// <summary>Pointer always bound to the object right below it.</summary>
NoGrab = 1,
/// <summary>Useful on object with &quot;repeat events&quot; enabled, where mouse/touch up and down events WON&apos;T be repeated to objects and these objects wont be auto-grabbed.
/// (Since EFL 1.2)</summary>
NoGrabNoRepeatUpdown = 2,
}

}

}

namespace Efl {

namespace Input {

/// <summary>Keys for the generic values of all events.
/// (Since EFL 1.19)</summary>
public enum Value
{
/// <summary>Not a valid value type.</summary>
None = 0,
/// <summary>Timestamp of this event in seconds.</summary>
Timestamp = 1,
/// <summary>ID of the button that triggered this event (unsigned int). Prefer the method <c>button</c> to read this value. Default: 0.</summary>
Button = 2,
/// <summary>32-bit bit mask (unsigned int). Prefer the method <c>buttons_pressed</c> to read this value. Default: 0.</summary>
ButtonsPressed = 3,
/// <summary>ID of the finger or tool (eg. pen) that triggered this event. Prefer the property <c>tool</c> to read this value. Default: 0.</summary>
Tool = 4,
/// <summary>Absolute X position where this event occurred, in pixels. Relative to the window. Default: last known position. This value may be smoothed out or even extrapolated by EFL.</summary>
X = 5,
/// <summary>Absolute Y position where this event occurred, in pixels. Relative to the window. Default: last known position. This value may be smoothed out or even extrapolated by EFL.</summary>
Y = 6,
/// <summary>Relative X movement, in pixels. Range: unbounded. Default: 0.</summary>
Dx = 7,
/// <summary>Relative Y movement, in pixels. Range: unbounded. Default: 0.</summary>
Dy = 8,
/// <summary>Previous X position of the pointer, in pixels. Default: last known position, may be equal to x.</summary>
PreviousX = 9,
/// <summary>Previous Y position of the pointer, in pixels. Default: last known position, may be equal to y.</summary>
PreviousY = 10,
/// <summary>Absolute X position where this event occurred. Default: 0. This value will be set from the hardware input without any smoothing or extrapolation. For an axis input event, this is the raw value set by the driver (undefined range and unit).</summary>
RawX = 11,
/// <summary>Absolute X position where this event occurred. Default: 0. This value will be set from the hardware input without any smoothing or extrapolation. For an axis input event, this is the raw value set by the driver (undefined range and unit).</summary>
RawY = 12,
/// <summary>Average radius of the pressed area under a finger or tool, in pixels. Default is 1.</summary>
Radius = 13,
/// <summary>Spread over X of the pressed area under a finger or tool, in pixels. Default is 1.</summary>
RadiusX = 14,
/// <summary>Spread over Y of the pressed area under a finger or tool, in pixels. Default is 1.</summary>
RadiusY = 15,
/// <summary>Pressure applied to the button, touch or pen tip. Range: [0, 1]. Default is 1.</summary>
Pressure = 16,
/// <summary>Relative distance along physical Z axis. Range: [0, 1]. Default is 0.</summary>
Distance = 17,
/// <summary>Angle of tool about the Z axis from positive X axis. Range: [-PI, PI]. Unit: Radians.</summary>
Azimuth = 18,
/// <summary>Angle of tool about plane of sensor from positive Z axis. Range: [0.0, PI]. Unit: Radians.</summary>
Tilt = 19,
/// <summary>Current tilt along the X axis of the tablet&apos;s current logical orientation, in radians off the tablet&apos;s Z axis. Range: [-PI, PI]. Unit: Radians.</summary>
TiltX = 20,
/// <summary>Current tilt along the Y axis of the tablet&apos;s current logical orientation, in radians off the tablet&apos;s Z axis. Range: [-PI, PI]. Unit: Radians.</summary>
TiltY = 21,
/// <summary>Rotation of tool about its major axis from its &quot;natural&quot; position. Range: [-PI, PI] Unit: Radians.</summary>
Twist = 22,
/// <summary>Delta movement of the wheel in discrete steps (int). Default: 0.</summary>
WheelDelta = 23,
/// <summary>Delta movement of the wheel in radians. Default: 0.</summary>
WheelAngle = 24,
/// <summary>Direction of the wheel (horizontal = 1 or vertical = 0). Default: 0. Prefer the property <c>wheel_horizontal</c> to read.</summary>
WheelHorizontal = 25,
/// <summary>Current position of the slider on the tool. Range: [-1, 1]. Default: 0.</summary>
Slider = 26,
}

}

}

namespace Efl {

namespace Input {

/// <summary>Key modifiers such as Control, Alt, etc...
/// This enum may be used as a bitmask with OR operations, depending on the API.
/// 
/// The available keys may vary depending on the physical keyboard layout, or language and keyboard settings, or depending on the platform.
/// (Since EFL 1.20)</summary>
public enum Modifier
{
/// <summary>No key modifier</summary>
None = 0,
/// <summary>Alt key modifier</summary>
Alt = 1,
/// <summary>Control key modifier (&quot;Ctrl&quot; key)</summary>
Control = 2,
/// <summary>Shift key modifier</summary>
Shift = 4,
/// <summary>Meta key modifier (often the &quot;Windows&quot; key)</summary>
Meta = 8,
/// <summary>AltGr key modifier (not present on all keyboards)</summary>
Altgr = 16,
/// <summary>Hyper key modifier (may be &quot;Windows&quot; key)</summary>
Hyper = 32,
/// <summary>Super key modifier (may be &quot;Windows&quot; key)</summary>
Super = 64,
}

}

}

namespace Efl {

namespace Input {

/// <summary>Key locks such as Num Lock, Scroll Lock and Caps Lock.
/// This enum may be used as a bitmask with OR operations, depending on the API.
/// 
/// The available keys may vary depending on the physical keyboard layout, or language and keyboard settings, or depending on the platform.
/// (Since EFL 1.20)</summary>
public enum Lock
{
/// <summary>No key modifier</summary>
None = 0,
/// <summary>Num Lock for numeric key pad use</summary>
Num = 1,
/// <summary>Caps Lock for writing in all caps</summary>
Caps = 2,
/// <summary>Scroll Lock</summary>
Scroll = 4,
/// <summary>Shift Lock</summary>
Shift = 8,
}

}

}

