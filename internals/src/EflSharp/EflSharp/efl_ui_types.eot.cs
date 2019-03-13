#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Permitted directions for dragging objects.</summary>
public enum DragDir
{
/// <summary>Not draggable in any direction.</summary>
None = 0,
/// <summary>Draggable horizontally.</summary>
X = 1,
/// <summary>Draggable vertically.</summary>
Y = 2,
/// <summary>Draggable in both directions.</summary>
Xy = 3,
}
} } 
