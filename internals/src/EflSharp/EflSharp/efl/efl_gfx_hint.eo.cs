#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gfx {

public partial class Constants
{
    /// <summary>Use with <see cref="Efl.Gfx.IHint.GetHintWeight"/>.</summary>
    public static readonly double HintExpand = 1.000000;
}
}

}

namespace Efl {

namespace Gfx {

public partial class Constants
{
    /// <summary>Use with <see cref="Efl.Gfx.IHint.GetHintAlign"/>.</summary>
    public static readonly double HintAlignLeft = 0.000000;
}
}

}

namespace Efl {

namespace Gfx {

public partial class Constants
{
    /// <summary>Use with <see cref="Efl.Gfx.IHint.GetHintAlign"/>.</summary>
    public static readonly double HintAlignRight = 1.000000;
}
}

}

namespace Efl {

namespace Gfx {

public partial class Constants
{
    /// <summary>Use with <see cref="Efl.Gfx.IHint.GetHintAlign"/>.</summary>
    public static readonly double HintAlignTop = 0.000000;
}
}

}

namespace Efl {

namespace Gfx {

public partial class Constants
{
    /// <summary>Use with <see cref="Efl.Gfx.IHint.GetHintAlign"/>.</summary>
    public static readonly double HintAlignBottom = 1.000000;
}
}

}

namespace Efl {

namespace Gfx {

public partial class Constants
{
    /// <summary>Use with <see cref="Efl.Gfx.IHint.GetHintAlign"/>.</summary>
    public static readonly double HintAlignCenter = 0.500000;
}
}

}

namespace Efl {

namespace Gfx {

/// <summary>Efl graphics hint interface
/// (Since EFL 1.22)</summary>
[Efl.Gfx.HintConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IHint : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Defines the aspect ratio to respect when scaling this object.
/// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
/// 
/// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.
/// (Since EFL 1.22)</summary>
/// <param name="mode">Mode of interpretation.</param>
/// <param name="sz">Base size to use for aspecting.</param>
void GetHintAspect(out Efl.Gfx.HintAspect mode, out Eina.Size2D sz);
    /// <summary>Defines the aspect ratio to respect when scaling this object.
/// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
/// 
/// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.
/// (Since EFL 1.22)</summary>
/// <param name="mode">Mode of interpretation.</param>
/// <param name="sz">Base size to use for aspecting.</param>
void SetHintAspect(Efl.Gfx.HintAspect mode, Eina.Size2D sz);
    /// <summary>Hints on the object&apos;s maximum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Values -1 will be treated as unset hint components, when queried by managers.
/// 
/// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
/// 
/// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
/// (Since EFL 1.22)</summary>
/// <returns>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</returns>
Eina.Size2D GetHintSizeMax();
    /// <summary>Hints on the object&apos;s maximum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Values -1 will be treated as unset hint components, when queried by managers.
/// 
/// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
/// 
/// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
/// (Since EFL 1.22)</summary>
/// <param name="sz">Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</param>
void SetHintSizeMax(Eina.Size2D sz);
    /// <summary>Get the &quot;intrinsic&quot; maximum size of this object.
/// (Since EFL 1.22)</summary>
/// <returns>Maximum size (hint) in pixels.</returns>
Eina.Size2D GetHintSizeRestrictedMax();
        /// <summary>Read-only maximum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="Efl.Gfx.IHint.HintSizeMax"/> hints.
/// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.
/// (Since EFL 1.22)</summary>
/// <returns>Maximum size (hint) in pixels.</returns>
Eina.Size2D GetHintSizeCombinedMax();
    /// <summary>Hints on the object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Value 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
/// 
/// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
/// (Since EFL 1.22)</summary>
/// <returns>Minimum size (hint) in pixels.</returns>
Eina.Size2D GetHintSizeMin();
    /// <summary>Hints on the object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Value 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
/// 
/// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
/// (Since EFL 1.22)</summary>
/// <param name="sz">Minimum size (hint) in pixels.</param>
void SetHintSizeMin(Eina.Size2D sz);
    /// <summary>Get the &quot;intrinsic&quot; minimum size of this object.
/// (Since EFL 1.22)</summary>
/// <returns>Minimum size (hint) in pixels.</returns>
Eina.Size2D GetHintSizeRestrictedMin();
        /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="Efl.Gfx.IHint.HintSizeMin"/> hints.
/// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.
/// (Since EFL 1.22)</summary>
/// <returns>Minimum size (hint) in pixels.</returns>
Eina.Size2D GetHintSizeCombinedMin();
    /// <summary>Hints for an object&apos;s margin or padding space.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
/// (Since EFL 1.22)</summary>
/// <param name="l">Integer to specify left padding.</param>
/// <param name="r">Integer to specify right padding.</param>
/// <param name="t">Integer to specify top padding.</param>
/// <param name="b">Integer to specify bottom padding.</param>
void GetHintMargin(out int l, out int r, out int t, out int b);
    /// <summary>Hints for an object&apos;s margin or padding space.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
/// (Since EFL 1.22)</summary>
/// <param name="l">Integer to specify left padding.</param>
/// <param name="r">Integer to specify right padding.</param>
/// <param name="t">Integer to specify top padding.</param>
/// <param name="b">Integer to specify bottom padding.</param>
void SetHintMargin(int l, int r, int t, int b);
    /// <summary>Hints for an object&apos;s weight.
/// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
/// 
/// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
/// 
/// Note: Default weight hint values are 0.0, for both axis.
/// (Since EFL 1.22)</summary>
/// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
/// <param name="y">Non-negative double value to use as vertical weight hint.</param>
void GetHintWeight(out double x, out double y);
    /// <summary>Hints for an object&apos;s weight.
/// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
/// 
/// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
/// 
/// Note: Default weight hint values are 0.0, for both axis.
/// (Since EFL 1.22)</summary>
/// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
/// <param name="y">Non-negative double value to use as vertical weight hint.</param>
void SetHintWeight(double x, double y);
    /// <summary>Hints for an object&apos;s alignment.
/// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
/// 
/// For the horizontal component, 0.0 means the start of the axis in the direction that the current language reads, 1.0 means the end of the axis.
/// 
/// For the vertical component, 0.0 to the top, 1.0 means to the bottom.
/// 
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Note: Default alignment hint values are 0.5, for both axes.
/// (Since EFL 1.22)</summary>
/// <param name="x">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end.</param>
/// <param name="y">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end.</param>
void GetHintAlign(out double x, out double y);
    /// <summary>Hints for an object&apos;s alignment.
/// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
/// 
/// For the horizontal component, 0.0 means the start of the axis in the direction that the current language reads, 1.0 means the end of the axis.
/// 
/// For the vertical component, 0.0 to the top, 1.0 means to the bottom.
/// 
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Note: Default alignment hint values are 0.5, for both axes.
/// (Since EFL 1.22)</summary>
/// <param name="x">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end.</param>
/// <param name="y">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end.</param>
void SetHintAlign(double x, double y);
    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
/// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
/// 
/// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
/// 
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Note: Default fill hint values are true, for both axes.
/// (Since EFL 1.22)</summary>
/// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
/// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
void GetHintFill(out bool x, out bool y);
    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
/// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
/// 
/// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
/// 
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Note: Default fill hint values are true, for both axes.
/// (Since EFL 1.22)</summary>
/// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
/// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
void SetHintFill(bool x, bool y);
                                                                                    /// <summary>Object hints changed.
    /// (Since EFL 1.22)</summary>
    event EventHandler HintsChangedEvent;
    /// <summary>Defines the aspect ratio to respect when scaling this object.
    /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
    /// 
    /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.
    /// (Since EFL 1.22)</summary>
    /// <value>Mode of interpretation.</value>
    (Efl.Gfx.HintAspect, Eina.Size2D) HintAspect {
        get;
        set;
    }
    /// <summary>Hints on the object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</value>
    Eina.Size2D HintSizeMax {
        get;
        set;
    }
    /// <summary>Internal hints for an object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is internal and meant for widget developers to define the absolute maximum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Applications should use <see cref="Efl.Gfx.IHint.HintSizeMax"/> instead.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Maximum size (hint) in pixels.</value>
    Eina.Size2D HintSizeRestrictedMax {
        get;
    }
    /// <summary>Read-only maximum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="Efl.Gfx.IHint.HintSizeMax"/> hints.
    /// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.
    /// (Since EFL 1.22)</summary>
    /// <value>Maximum size (hint) in pixels.</value>
    Eina.Size2D HintSizeCombinedMax {
        get;
    }
    /// <summary>Hints on the object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Value 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Minimum size (hint) in pixels.</value>
    Eina.Size2D HintSizeMin {
        get;
        set;
    }
    /// <summary>Internal hints for an object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Values 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="Efl.Gfx.IHint.HintSizeMin"/> instead.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Minimum size (hint) in pixels.</value>
    Eina.Size2D HintSizeRestrictedMin {
        get;
    }
    /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="Efl.Gfx.IHint.HintSizeMin"/> hints.
    /// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.
    /// (Since EFL 1.22)</summary>
    /// <value>Minimum size (hint) in pixels.</value>
    Eina.Size2D HintSizeCombinedMin {
        get;
    }
    /// <summary>Hints for an object&apos;s margin or padding space.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// (Since EFL 1.22)</summary>
    /// <value>Integer to specify left padding.</value>
    (int, int, int, int) HintMargin {
        get;
        set;
    }
    /// <summary>Hints for an object&apos;s weight.
    /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
    /// 
    /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
    /// 
    /// Note: Default weight hint values are 0.0, for both axis.
    /// (Since EFL 1.22)</summary>
    /// <value>Non-negative double value to use as horizontal weight hint.</value>
    (double, double) HintWeight {
        get;
        set;
    }
    /// <summary>Hints for an object&apos;s alignment.
    /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
    /// 
    /// For the horizontal component, 0.0 means the start of the axis in the direction that the current language reads, 1.0 means the end of the axis.
    /// 
    /// For the vertical component, 0.0 to the top, 1.0 means to the bottom.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default alignment hint values are 0.5, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <value>Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end.</value>
    (double, double) HintAlign {
        get;
        set;
    }
    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
    /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
    /// 
    /// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default fill hint values are true, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</value>
    (bool, bool) HintFill {
        get;
        set;
    }
}
/// <summary>Efl graphics hint interface
/// (Since EFL 1.22)</summary>
public sealed class HintConcrete :
    Efl.Eo.EoWrapper
    , IHint
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(HintConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private HintConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_hint_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IHint"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private HintConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Object hints changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler HintsChangedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event HintsChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnHintsChangedEvent(EventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
#pragma warning disable CS0628
    /// <summary>Defines the aspect ratio to respect when scaling this object.
    /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
    /// 
    /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.
    /// (Since EFL 1.22)</summary>
    /// <param name="mode">Mode of interpretation.</param>
    /// <param name="sz">Base size to use for aspecting.</param>
    public void GetHintAspect(out Efl.Gfx.HintAspect mode, out Eina.Size2D sz) {
                                 var _out_sz = new Eina.Size2D.NativeStruct();
                        Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_aspect_get_ptr.Value.Delegate(this.NativeHandle,out mode, out _out_sz);
        Eina.Error.RaiseIfUnhandledException();
                sz = _out_sz;
                         }
    /// <summary>Defines the aspect ratio to respect when scaling this object.
    /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
    /// 
    /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.
    /// (Since EFL 1.22)</summary>
    /// <param name="mode">Mode of interpretation.</param>
    /// <param name="sz">Base size to use for aspecting.</param>
    public void SetHintAspect(Efl.Gfx.HintAspect mode, Eina.Size2D sz) {
                 Eina.Size2D.NativeStruct _in_sz = sz;
                                        Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_aspect_set_ptr.Value.Delegate(this.NativeHandle,mode, _in_sz);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints on the object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <returns>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</returns>
    public Eina.Size2D GetHintSizeMax() {
         var _ret_var = Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_max_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hints on the object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <param name="sz">Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</param>
    public void SetHintSizeMax(Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_max_set_ptr.Value.Delegate(this.NativeHandle,_in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the &quot;intrinsic&quot; maximum size of this object.
    /// (Since EFL 1.22)</summary>
    /// <returns>Maximum size (hint) in pixels.</returns>
    public Eina.Size2D GetHintSizeRestrictedMax() {
         var _ret_var = Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_restricted_max_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; maximum size.
    /// (Since EFL 1.22)</summary>
    /// <param name="sz">Maximum size (hint) in pixels.</param>
    protected void SetHintSizeRestrictedMax(Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_restricted_max_set_ptr.Value.Delegate(this.NativeHandle,_in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Read-only maximum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="Efl.Gfx.IHint.HintSizeMax"/> hints.
    /// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.
    /// (Since EFL 1.22)</summary>
    /// <returns>Maximum size (hint) in pixels.</returns>
    public Eina.Size2D GetHintSizeCombinedMax() {
         var _ret_var = Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_combined_max_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hints on the object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Value 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <returns>Minimum size (hint) in pixels.</returns>
    public Eina.Size2D GetHintSizeMin() {
         var _ret_var = Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_min_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hints on the object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Value 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <param name="sz">Minimum size (hint) in pixels.</param>
    public void SetHintSizeMin(Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_min_set_ptr.Value.Delegate(this.NativeHandle,_in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the &quot;intrinsic&quot; minimum size of this object.
    /// (Since EFL 1.22)</summary>
    /// <returns>Minimum size (hint) in pixels.</returns>
    public Eina.Size2D GetHintSizeRestrictedMin() {
         var _ret_var = Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_restricted_min_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; minimum size.
    /// (Since EFL 1.22)</summary>
    /// <param name="sz">Minimum size (hint) in pixels.</param>
    protected void SetHintSizeRestrictedMin(Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_restricted_min_set_ptr.Value.Delegate(this.NativeHandle,_in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="Efl.Gfx.IHint.HintSizeMin"/> hints.
    /// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.
    /// (Since EFL 1.22)</summary>
    /// <returns>Minimum size (hint) in pixels.</returns>
    public Eina.Size2D GetHintSizeCombinedMin() {
         var _ret_var = Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_combined_min_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hints for an object&apos;s margin or padding space.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// (Since EFL 1.22)</summary>
    /// <param name="l">Integer to specify left padding.</param>
    /// <param name="r">Integer to specify right padding.</param>
    /// <param name="t">Integer to specify top padding.</param>
    /// <param name="b">Integer to specify bottom padding.</param>
    public void GetHintMargin(out int l, out int r, out int t, out int b) {
                                                                                                         Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_margin_get_ptr.Value.Delegate(this.NativeHandle,out l, out r, out t, out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Hints for an object&apos;s margin or padding space.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// (Since EFL 1.22)</summary>
    /// <param name="l">Integer to specify left padding.</param>
    /// <param name="r">Integer to specify right padding.</param>
    /// <param name="t">Integer to specify top padding.</param>
    /// <param name="b">Integer to specify bottom padding.</param>
    public void SetHintMargin(int l, int r, int t, int b) {
                                                                                                         Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_margin_set_ptr.Value.Delegate(this.NativeHandle,l, r, t, b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Hints for an object&apos;s weight.
    /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
    /// 
    /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
    /// 
    /// Note: Default weight hint values are 0.0, for both axis.
    /// (Since EFL 1.22)</summary>
    /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
    /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
    public void GetHintWeight(out double x, out double y) {
                                                         Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_weight_get_ptr.Value.Delegate(this.NativeHandle,out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints for an object&apos;s weight.
    /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
    /// 
    /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
    /// 
    /// Note: Default weight hint values are 0.0, for both axis.
    /// (Since EFL 1.22)</summary>
    /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
    /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
    public void SetHintWeight(double x, double y) {
                                                         Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_weight_set_ptr.Value.Delegate(this.NativeHandle,x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints for an object&apos;s alignment.
    /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
    /// 
    /// For the horizontal component, 0.0 means the start of the axis in the direction that the current language reads, 1.0 means the end of the axis.
    /// 
    /// For the vertical component, 0.0 to the top, 1.0 means to the bottom.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default alignment hint values are 0.5, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <param name="x">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end.</param>
    /// <param name="y">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end.</param>
    public void GetHintAlign(out double x, out double y) {
                                                         Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_align_get_ptr.Value.Delegate(this.NativeHandle,out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints for an object&apos;s alignment.
    /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
    /// 
    /// For the horizontal component, 0.0 means the start of the axis in the direction that the current language reads, 1.0 means the end of the axis.
    /// 
    /// For the vertical component, 0.0 to the top, 1.0 means to the bottom.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default alignment hint values are 0.5, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <param name="x">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end.</param>
    /// <param name="y">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end.</param>
    public void SetHintAlign(double x, double y) {
                                                         Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_align_set_ptr.Value.Delegate(this.NativeHandle,x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
    /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
    /// 
    /// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default fill hint values are true, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
    /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
    public void GetHintFill(out bool x, out bool y) {
                                                         Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_fill_get_ptr.Value.Delegate(this.NativeHandle,out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
    /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
    /// 
    /// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default fill hint values are true, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
    /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
    public void SetHintFill(bool x, bool y) {
                                                         Efl.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_fill_set_ptr.Value.Delegate(this.NativeHandle,x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Defines the aspect ratio to respect when scaling this object.
    /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
    /// 
    /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.
    /// (Since EFL 1.22)</summary>
    /// <value>Mode of interpretation.</value>
    public (Efl.Gfx.HintAspect, Eina.Size2D) HintAspect {
        get {
            Efl.Gfx.HintAspect _out_mode = default(Efl.Gfx.HintAspect);
            Eina.Size2D _out_sz = default(Eina.Size2D);
            GetHintAspect(out _out_mode,out _out_sz);
            return (_out_mode,_out_sz);
        }
        set { SetHintAspect( value.Item1,  value.Item2); }
    }
    /// <summary>Hints on the object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</value>
    public Eina.Size2D HintSizeMax {
        get { return GetHintSizeMax(); }
        set { SetHintSizeMax(value); }
    }
    /// <summary>Internal hints for an object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is internal and meant for widget developers to define the absolute maximum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Applications should use <see cref="Efl.Gfx.IHint.HintSizeMax"/> instead.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Maximum size (hint) in pixels.</value>
    public Eina.Size2D HintSizeRestrictedMax {
        get { return GetHintSizeRestrictedMax(); }
        protected set { SetHintSizeRestrictedMax(value); }
    }
    /// <summary>Read-only maximum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="Efl.Gfx.IHint.HintSizeMax"/> hints.
    /// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.
    /// (Since EFL 1.22)</summary>
    /// <value>Maximum size (hint) in pixels.</value>
    public Eina.Size2D HintSizeCombinedMax {
        get { return GetHintSizeCombinedMax(); }
    }
    /// <summary>Hints on the object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Value 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Minimum size (hint) in pixels.</value>
    public Eina.Size2D HintSizeMin {
        get { return GetHintSizeMin(); }
        set { SetHintSizeMin(value); }
    }
    /// <summary>Internal hints for an object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Values 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="Efl.Gfx.IHint.HintSizeMin"/> instead.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Minimum size (hint) in pixels.</value>
    public Eina.Size2D HintSizeRestrictedMin {
        get { return GetHintSizeRestrictedMin(); }
        protected set { SetHintSizeRestrictedMin(value); }
    }
    /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="Efl.Gfx.IHint.HintSizeMin"/> hints.
    /// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.
    /// (Since EFL 1.22)</summary>
    /// <value>Minimum size (hint) in pixels.</value>
    public Eina.Size2D HintSizeCombinedMin {
        get { return GetHintSizeCombinedMin(); }
    }
    /// <summary>Hints for an object&apos;s margin or padding space.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// (Since EFL 1.22)</summary>
    /// <value>Integer to specify left padding.</value>
    public (int, int, int, int) HintMargin {
        get {
            int _out_l = default(int);
            int _out_r = default(int);
            int _out_t = default(int);
            int _out_b = default(int);
            GetHintMargin(out _out_l,out _out_r,out _out_t,out _out_b);
            return (_out_l,_out_r,_out_t,_out_b);
        }
        set { SetHintMargin( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Hints for an object&apos;s weight.
    /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
    /// 
    /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
    /// 
    /// Note: Default weight hint values are 0.0, for both axis.
    /// (Since EFL 1.22)</summary>
    /// <value>Non-negative double value to use as horizontal weight hint.</value>
    public (double, double) HintWeight {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetHintWeight(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetHintWeight( value.Item1,  value.Item2); }
    }
    /// <summary>Hints for an object&apos;s alignment.
    /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
    /// 
    /// For the horizontal component, 0.0 means the start of the axis in the direction that the current language reads, 1.0 means the end of the axis.
    /// 
    /// For the vertical component, 0.0 to the top, 1.0 means to the bottom.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default alignment hint values are 0.5, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <value>Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end.</value>
    public (double, double) HintAlign {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetHintAlign(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetHintAlign( value.Item1,  value.Item2); }
    }
    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
    /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
    /// 
    /// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default fill hint values are true, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</value>
    public (bool, bool) HintFill {
        get {
            bool _out_x = default(bool);
            bool _out_y = default(bool);
            GetHintFill(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetHintFill( value.Item1,  value.Item2); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.HintConcrete.efl_gfx_hint_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_hint_aspect_get_static_delegate == null)
            {
                efl_gfx_hint_aspect_get_static_delegate = new efl_gfx_hint_aspect_get_delegate(hint_aspect_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintAspect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_aspect_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_aspect_get_static_delegate) });
            }

            if (efl_gfx_hint_aspect_set_static_delegate == null)
            {
                efl_gfx_hint_aspect_set_static_delegate = new efl_gfx_hint_aspect_set_delegate(hint_aspect_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintAspect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_aspect_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_aspect_set_static_delegate) });
            }

            if (efl_gfx_hint_size_max_get_static_delegate == null)
            {
                efl_gfx_hint_size_max_get_static_delegate = new efl_gfx_hint_size_max_get_delegate(hint_size_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_max_get_static_delegate) });
            }

            if (efl_gfx_hint_size_max_set_static_delegate == null)
            {
                efl_gfx_hint_size_max_set_static_delegate = new efl_gfx_hint_size_max_set_delegate(hint_size_max_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintSizeMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_max_set_static_delegate) });
            }

            if (efl_gfx_hint_size_restricted_max_get_static_delegate == null)
            {
                efl_gfx_hint_size_restricted_max_get_static_delegate = new efl_gfx_hint_size_restricted_max_get_delegate(hint_size_restricted_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeRestrictedMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_max_get_static_delegate) });
            }

            if (efl_gfx_hint_size_combined_max_get_static_delegate == null)
            {
                efl_gfx_hint_size_combined_max_get_static_delegate = new efl_gfx_hint_size_combined_max_get_delegate(hint_size_combined_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeCombinedMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_combined_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_combined_max_get_static_delegate) });
            }

            if (efl_gfx_hint_size_min_get_static_delegate == null)
            {
                efl_gfx_hint_size_min_get_static_delegate = new efl_gfx_hint_size_min_get_delegate(hint_size_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_min_get_static_delegate) });
            }

            if (efl_gfx_hint_size_min_set_static_delegate == null)
            {
                efl_gfx_hint_size_min_set_static_delegate = new efl_gfx_hint_size_min_set_delegate(hint_size_min_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintSizeMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_min_set_static_delegate) });
            }

            if (efl_gfx_hint_size_restricted_min_get_static_delegate == null)
            {
                efl_gfx_hint_size_restricted_min_get_static_delegate = new efl_gfx_hint_size_restricted_min_get_delegate(hint_size_restricted_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeRestrictedMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_min_get_static_delegate) });
            }

            if (efl_gfx_hint_size_combined_min_get_static_delegate == null)
            {
                efl_gfx_hint_size_combined_min_get_static_delegate = new efl_gfx_hint_size_combined_min_get_delegate(hint_size_combined_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeCombinedMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_combined_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_combined_min_get_static_delegate) });
            }

            if (efl_gfx_hint_margin_get_static_delegate == null)
            {
                efl_gfx_hint_margin_get_static_delegate = new efl_gfx_hint_margin_get_delegate(hint_margin_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintMargin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_margin_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_margin_get_static_delegate) });
            }

            if (efl_gfx_hint_margin_set_static_delegate == null)
            {
                efl_gfx_hint_margin_set_static_delegate = new efl_gfx_hint_margin_set_delegate(hint_margin_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintMargin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_margin_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_margin_set_static_delegate) });
            }

            if (efl_gfx_hint_weight_get_static_delegate == null)
            {
                efl_gfx_hint_weight_get_static_delegate = new efl_gfx_hint_weight_get_delegate(hint_weight_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintWeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_weight_get_static_delegate) });
            }

            if (efl_gfx_hint_weight_set_static_delegate == null)
            {
                efl_gfx_hint_weight_set_static_delegate = new efl_gfx_hint_weight_set_delegate(hint_weight_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintWeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_weight_set_static_delegate) });
            }

            if (efl_gfx_hint_align_get_static_delegate == null)
            {
                efl_gfx_hint_align_get_static_delegate = new efl_gfx_hint_align_get_delegate(hint_align_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_align_get_static_delegate) });
            }

            if (efl_gfx_hint_align_set_static_delegate == null)
            {
                efl_gfx_hint_align_set_static_delegate = new efl_gfx_hint_align_set_delegate(hint_align_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_align_set_static_delegate) });
            }

            if (efl_gfx_hint_fill_get_static_delegate == null)
            {
                efl_gfx_hint_fill_get_static_delegate = new efl_gfx_hint_fill_get_delegate(hint_fill_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_fill_get_static_delegate) });
            }

            if (efl_gfx_hint_fill_set_static_delegate == null)
            {
                efl_gfx_hint_fill_set_static_delegate = new efl_gfx_hint_fill_set_delegate(hint_fill_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_fill_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.HintConcrete.efl_gfx_hint_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_hint_aspect_get_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.Gfx.HintAspect mode,  out Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_aspect_get_api_delegate(System.IntPtr obj,  out Efl.Gfx.HintAspect mode,  out Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_get_api_delegate> efl_gfx_hint_aspect_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_get_api_delegate>(Module, "efl_gfx_hint_aspect_get");

        private static void hint_aspect_get(System.IntPtr obj, System.IntPtr pd, out Efl.Gfx.HintAspect mode, out Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_hint_aspect_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        mode = default(Efl.Gfx.HintAspect);        Eina.Size2D _out_sz = default(Eina.Size2D);
                            
                try
                {
                    ((IHint)ws.Target).GetHintAspect(out mode, out _out_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                sz = _out_sz;
                        
            }
            else
            {
                efl_gfx_hint_aspect_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out mode, out sz);
            }
        }

        private static efl_gfx_hint_aspect_get_delegate efl_gfx_hint_aspect_get_static_delegate;

        
        private delegate void efl_gfx_hint_aspect_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.HintAspect mode,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_aspect_set_api_delegate(System.IntPtr obj,  Efl.Gfx.HintAspect mode,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_set_api_delegate> efl_gfx_hint_aspect_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_set_api_delegate>(Module, "efl_gfx_hint_aspect_set");

        private static void hint_aspect_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.HintAspect mode, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_hint_aspect_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Size2D _in_sz = sz;
                                            
                try
                {
                    ((IHint)ws.Target).SetHintAspect(mode, _in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_aspect_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode, sz);
            }
        }

        private static efl_gfx_hint_aspect_set_delegate efl_gfx_hint_aspect_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_max_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_get_api_delegate> efl_gfx_hint_size_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_get_api_delegate>(Module, "efl_gfx_hint_size_max_get");

        private static Eina.Size2D.NativeStruct hint_size_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeMax();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_hint_size_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_max_get_delegate efl_gfx_hint_size_max_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_size_max_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_set_api_delegate> efl_gfx_hint_size_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_set_api_delegate>(Module, "efl_gfx_hint_size_max_set");

        private static void hint_size_max_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_max_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_sz = sz;
                            
                try
                {
                    ((IHint)ws.Target).SetHintSizeMax(_in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_hint_size_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_gfx_hint_size_max_set_delegate efl_gfx_hint_size_max_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_restricted_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_restricted_max_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_max_get_api_delegate> efl_gfx_hint_size_restricted_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_max_get_api_delegate>(Module, "efl_gfx_hint_size_restricted_max_get");

        private static Eina.Size2D.NativeStruct hint_size_restricted_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_restricted_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeRestrictedMax();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_hint_size_restricted_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_restricted_max_get_delegate efl_gfx_hint_size_restricted_max_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_restricted_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_size_restricted_max_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_max_set_api_delegate> efl_gfx_hint_size_restricted_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_max_set_api_delegate>(Module, "efl_gfx_hint_size_restricted_max_set");

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_combined_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_combined_max_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_combined_max_get_api_delegate> efl_gfx_hint_size_combined_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_combined_max_get_api_delegate>(Module, "efl_gfx_hint_size_combined_max_get");

        private static Eina.Size2D.NativeStruct hint_size_combined_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_combined_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeCombinedMax();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_hint_size_combined_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_combined_max_get_delegate efl_gfx_hint_size_combined_max_get_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_min_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_get_api_delegate> efl_gfx_hint_size_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_get_api_delegate>(Module, "efl_gfx_hint_size_min_get");

        private static Eina.Size2D.NativeStruct hint_size_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeMin();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_hint_size_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_min_get_delegate efl_gfx_hint_size_min_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_size_min_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_set_api_delegate> efl_gfx_hint_size_min_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_set_api_delegate>(Module, "efl_gfx_hint_size_min_set");

        private static void hint_size_min_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_min_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_sz = sz;
                            
                try
                {
                    ((IHint)ws.Target).SetHintSizeMin(_in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_hint_size_min_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_gfx_hint_size_min_set_delegate efl_gfx_hint_size_min_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_restricted_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_restricted_min_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_get_api_delegate> efl_gfx_hint_size_restricted_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_get_api_delegate>(Module, "efl_gfx_hint_size_restricted_min_get");

        private static Eina.Size2D.NativeStruct hint_size_restricted_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_restricted_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeRestrictedMin();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_hint_size_restricted_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_restricted_min_get_delegate efl_gfx_hint_size_restricted_min_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_restricted_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_size_restricted_min_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate> efl_gfx_hint_size_restricted_min_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate>(Module, "efl_gfx_hint_size_restricted_min_set");

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_combined_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_combined_min_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_combined_min_get_api_delegate> efl_gfx_hint_size_combined_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_combined_min_get_api_delegate>(Module, "efl_gfx_hint_size_combined_min_get");

        private static Eina.Size2D.NativeStruct hint_size_combined_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_combined_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeCombinedMin();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_hint_size_combined_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_combined_min_get_delegate efl_gfx_hint_size_combined_min_get_static_delegate;

        
        private delegate void efl_gfx_hint_margin_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int l,  out int r,  out int t,  out int b);

        
        public delegate void efl_gfx_hint_margin_get_api_delegate(System.IntPtr obj,  out int l,  out int r,  out int t,  out int b);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_get_api_delegate> efl_gfx_hint_margin_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_get_api_delegate>(Module, "efl_gfx_hint_margin_get");

        private static void hint_margin_get(System.IntPtr obj, System.IntPtr pd, out int l, out int r, out int t, out int b)
        {
            Eina.Log.Debug("function efl_gfx_hint_margin_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        l = default(int);        r = default(int);        t = default(int);        b = default(int);                                            
                try
                {
                    ((IHint)ws.Target).GetHintMargin(out l, out r, out t, out b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_hint_margin_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out l, out r, out t, out b);
            }
        }

        private static efl_gfx_hint_margin_get_delegate efl_gfx_hint_margin_get_static_delegate;

        
        private delegate void efl_gfx_hint_margin_set_delegate(System.IntPtr obj, System.IntPtr pd,  int l,  int r,  int t,  int b);

        
        public delegate void efl_gfx_hint_margin_set_api_delegate(System.IntPtr obj,  int l,  int r,  int t,  int b);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_set_api_delegate> efl_gfx_hint_margin_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_set_api_delegate>(Module, "efl_gfx_hint_margin_set");

        private static void hint_margin_set(System.IntPtr obj, System.IntPtr pd, int l, int r, int t, int b)
        {
            Eina.Log.Debug("function efl_gfx_hint_margin_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((IHint)ws.Target).SetHintMargin(l, r, t, b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_hint_margin_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), l, r, t, b);
            }
        }

        private static efl_gfx_hint_margin_set_delegate efl_gfx_hint_margin_set_static_delegate;

        
        private delegate void efl_gfx_hint_weight_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_gfx_hint_weight_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_get_api_delegate> efl_gfx_hint_weight_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_get_api_delegate>(Module, "efl_gfx_hint_weight_get");

        private static void hint_weight_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_gfx_hint_weight_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((IHint)ws.Target).GetHintWeight(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_weight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_hint_weight_get_delegate efl_gfx_hint_weight_get_static_delegate;

        
        private delegate void efl_gfx_hint_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_gfx_hint_weight_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_set_api_delegate> efl_gfx_hint_weight_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_set_api_delegate>(Module, "efl_gfx_hint_weight_set");

        private static void hint_weight_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_hint_weight_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IHint)ws.Target).SetHintWeight(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_weight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_hint_weight_set_delegate efl_gfx_hint_weight_set_static_delegate;

        
        private delegate void efl_gfx_hint_align_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_gfx_hint_align_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_align_get_api_delegate> efl_gfx_hint_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_align_get_api_delegate>(Module, "efl_gfx_hint_align_get");

        private static void hint_align_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_gfx_hint_align_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((IHint)ws.Target).GetHintAlign(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_hint_align_get_delegate efl_gfx_hint_align_get_static_delegate;

        
        private delegate void efl_gfx_hint_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_gfx_hint_align_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_align_set_api_delegate> efl_gfx_hint_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_align_set_api_delegate>(Module, "efl_gfx_hint_align_set");

        private static void hint_align_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_hint_align_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IHint)ws.Target).SetHintAlign(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_hint_align_set_delegate efl_gfx_hint_align_set_static_delegate;

        
        private delegate void efl_gfx_hint_fill_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool x, [MarshalAs(UnmanagedType.U1)] out bool y);

        
        public delegate void efl_gfx_hint_fill_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool x, [MarshalAs(UnmanagedType.U1)] out bool y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_get_api_delegate> efl_gfx_hint_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_get_api_delegate>(Module, "efl_gfx_hint_fill_get");

        private static void hint_fill_get(System.IntPtr obj, System.IntPtr pd, out bool x, out bool y)
        {
            Eina.Log.Debug("function efl_gfx_hint_fill_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(bool);        y = default(bool);                            
                try
                {
                    ((IHint)ws.Target).GetHintFill(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_hint_fill_get_delegate efl_gfx_hint_fill_get_static_delegate;

        
        private delegate void efl_gfx_hint_fill_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool x, [MarshalAs(UnmanagedType.U1)] bool y);

        
        public delegate void efl_gfx_hint_fill_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool x, [MarshalAs(UnmanagedType.U1)] bool y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_set_api_delegate> efl_gfx_hint_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_set_api_delegate>(Module, "efl_gfx_hint_fill_set");

        private static void hint_fill_set(System.IntPtr obj, System.IntPtr pd, bool x, bool y)
        {
            Eina.Log.Debug("function efl_gfx_hint_fill_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IHint)ws.Target).SetHintFill(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_hint_fill_set_delegate efl_gfx_hint_fill_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxHintConcrete_ExtensionMethods {
    
    public static Efl.BindableProperty<Eina.Size2D> HintSizeMax<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IHint, T>magic = null) where T : Efl.Gfx.IHint {
        return new Efl.BindableProperty<Eina.Size2D>("hint_size_max", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> HintSizeRestrictedMax<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IHint, T>magic = null) where T : Efl.Gfx.IHint {
        return new Efl.BindableProperty<Eina.Size2D>("hint_size_restricted_max", fac);
    }

    
    public static Efl.BindableProperty<Eina.Size2D> HintSizeMin<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IHint, T>magic = null) where T : Efl.Gfx.IHint {
        return new Efl.BindableProperty<Eina.Size2D>("hint_size_min", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> HintSizeRestrictedMin<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IHint, T>magic = null) where T : Efl.Gfx.IHint {
        return new Efl.BindableProperty<Eina.Size2D>("hint_size_restricted_min", fac);
    }

    
    
    
    
    
}
#pragma warning restore CS1591
#endif
