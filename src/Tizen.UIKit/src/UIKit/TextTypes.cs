#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

/// <summary>Bidirectionaltext type</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public enum TextBidirectionalType
{
/// <summary>Natural text type, same as neutral</summary>
Natural = 0,
/// <summary>Neutral text type, same as natural</summary>
Neutral = 0,
/// <summary>Left to right text type</summary>
Ltr = 1,
/// <summary>Right to left text type</summary>
Rtl = 2,
/// <summary>Inherit text type</summary>
Inherit = 3,
/// <summary>internal EVAS_BIDI_DIRECTION_ANY_RTL is not made for public. It should be opened to public when it is accepted to EFL upstream.</summary>
AnyRtl = 4,
}
}

