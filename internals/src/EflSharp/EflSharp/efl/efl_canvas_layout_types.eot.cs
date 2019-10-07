#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Type of a part in an Efl.Canvas.Layout object (edje object).</summary>
[Efl.Eo.BindingEntity]
public enum LayoutPartType
{
/// <summary>None type value, indicates invalid parts.</summary>
None = 0,
/// <summary>Rectangle type value.</summary>
Rectangle = 1,
/// <summary>Text type value.</summary>
Text = 2,
/// <summary>Image type value.</summary>
Image = 3,
/// <summary>Swallow  type value.</summary>
Swallow = 4,
/// <summary>Text block type value.</summary>
Textblock = 5,
/// <summary>Gradient type value.</summary>
Gradient = 6,
/// <summary>Group type value.</summary>
Group = 7,
/// <summary>Box type value.</summary>
Box = 8,
/// <summary>Table type value.</summary>
Table = 9,
/// <summary>External type value.</summary>
External = 10,
/// <summary>Proxy type value.</summary>
Proxy = 11,
/// <summary>Spacer type value</summary>
/// <since_tizen> 6 </since_tizen>
Spacer = 12,
/// <summary>Canvas 3D type: mesh node.</summary>
MeshNode = 13,
/// <summary>Canvas 3D type: light.</summary>
Light = 14,
/// <summary>Canvas 3D type: camera.</summary>
Camera = 15,
/// <summary>Snapshot</summary>
/// <since_tizen> 6 </since_tizen>
Snapshot = 16,
/// <summary>Vector</summary>
/// <since_tizen> 6 </since_tizen>
Vector = 17,
/// <summary>Last type value.</summary>
Last = 18,
}
}
}

namespace Edje {

[Efl.Eo.BindingEntity]
public enum Cursor
{
Main = 0,
SelectionBegin = 1,
SelectionEnd = 2,
PreeditStart = 3,
PreeditEnd = 4,
User = 5,
UserExtra = 6,
}
}

