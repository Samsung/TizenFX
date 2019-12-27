/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.Gfx {
/// <since_tizen> 6 </since_tizen>
public static partial class Constants
{
    /// <summary>Use with <see cref="CoreUI.Gfx.IHint.HintWeight"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly double HintExpand = 1.000000;
}
}

namespace CoreUI.Gfx {
/// <since_tizen> 6 </since_tizen>
public static partial class Constants
{
    /// <summary>Use with <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly double HintAlignLeft = 0.000000;
}
}

namespace CoreUI.Gfx {
/// <since_tizen> 6 </since_tizen>
public static partial class Constants
{
    /// <summary>Use with <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly double HintAlignRight = 1.000000;
}
}

namespace CoreUI.Gfx {
/// <since_tizen> 6 </since_tizen>
public static partial class Constants
{
    /// <summary>Use with <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly double HintAlignTop = 0.000000;
}
}

namespace CoreUI.Gfx {
/// <since_tizen> 6 </since_tizen>
public static partial class Constants
{
    /// <summary>Use with <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly double HintAlignBottom = 1.000000;
}
}

namespace CoreUI.Gfx {
/// <since_tizen> 6 </since_tizen>
public static partial class Constants
{
    /// <summary>Use with <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly double HintAlignCenter = 0.500000;
}
}

namespace CoreUI.Gfx {
    /// <summary>CoreUI graphics hint interface</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Gfx.IHintNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IHint : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Defines the aspect ratio to respect when scaling this object.
        /// 
        /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
        /// 
        /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
        /// <param name="mode">Mode of interpretation.</param>
        /// <param name="sz">Base size to use for aspecting.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetHintAspect(out CoreUI.Gfx.HintAspect mode, out CoreUI.DataTypes.Size2D sz);

        /// <summary>Defines the aspect ratio to respect when scaling this object.
        /// 
        /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
        /// 
        /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
        /// <param name="mode">Mode of interpretation.</param>
        /// <param name="sz">Base size to use for aspecting.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetHintAspect(CoreUI.Gfx.HintAspect mode, CoreUI.DataTypes.Size2D sz);

        /// <summary>Hints on the object&apos;s maximum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Values -1 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <returns>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetHintSizeMax();

        /// <summary>Hints on the object&apos;s maximum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Values -1 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <param name="sz">Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</param>
        /// <since_tizen> 6 </since_tizen>
        void SetHintSizeMax(CoreUI.DataTypes.Size2D sz);

        /// <summary>Internal hints for an object&apos;s maximum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Values -1 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is internal and meant for widget developers to define the absolute maximum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Applications should use <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> instead.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <returns>Maximum size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetHintSizeRestrictedMax();

        /// <summary>Read-only maximum size combining both <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> hints.
        /// 
        /// <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="CoreUI.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.</summary>
        /// <returns>Maximum size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetHintSizeCombinedMax();

        /// <summary>Hints on the object&apos;s minimum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Value 0 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <returns>Minimum size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetHintSizeMin();

        /// <summary>Hints on the object&apos;s minimum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Value 0 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <param name="sz">Minimum size (hint) in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetHintSizeMin(CoreUI.DataTypes.Size2D sz);

        /// <summary>Internal hints for an object&apos;s minimum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Values 0 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> instead.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.<br/>
        /// <b>Note:</b> Get the &quot;intrinsic&quot; minimum size of this object.</summary>
        /// <returns>Minimum size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetHintSizeRestrictedMin();

        /// <summary>Read-only minimum size combining both <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> hints.
        /// 
        /// <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="CoreUI.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
        /// <returns>Minimum size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetHintSizeCombinedMin();

        /// <summary>Hints for an object&apos;s margin or padding space.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
        /// <param name="l">Integer to specify left padding.</param>
        /// <param name="r">Integer to specify right padding.</param>
        /// <param name="t">Integer to specify top padding.</param>
        /// <param name="b">Integer to specify bottom padding.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetHintMargin(out int l, out int r, out int t, out int b);

        /// <summary>Hints for an object&apos;s margin or padding space.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
        /// <param name="l">Integer to specify left padding.</param>
        /// <param name="r">Integer to specify right padding.</param>
        /// <param name="t">Integer to specify top padding.</param>
        /// <param name="b">Integer to specify bottom padding.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetHintMargin(int l, int r, int t, int b);

        /// <summary>Hints for an object&apos;s weight.
        /// 
        /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="CoreUI.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
        /// 
        /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
        /// 
        /// <b>NOTE: </b>Default weight hint values are 0.0, for both axis.</summary>
        /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
        /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetHintWeight(out double x, out double y);

        /// <summary>Hints for an object&apos;s weight.
        /// 
        /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="CoreUI.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
        /// 
        /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
        /// 
        /// <b>NOTE: </b>Default weight hint values are 0.0, for both axis.</summary>
        /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
        /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetHintWeight(double x, double y);

        /// <summary>Hints for an object&apos;s alignment.
        /// 
        /// These are hints on how to align this object inside the boundaries of its container/manager.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.</summary>
        /// <param name="x">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <param name="y">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetHintAlign(out CoreUI.Gfx.Align x, out CoreUI.Gfx.Align y);

        /// <summary>Hints for an object&apos;s alignment.
        /// 
        /// These are hints on how to align this object inside the boundaries of its container/manager.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.</summary>
        /// <param name="x">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <param name="y">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetHintAlign(CoreUI.Gfx.Align x, CoreUI.Gfx.Align y);

        /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="CoreUI.Gfx.IHint.HintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
        /// 
        /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="CoreUI.Gfx.IHint.HintMargin"/> set on objects should add up to the object space on the final scene composition.
        /// 
        /// See documentation of possible users: in Evas, they are the <see cref="CoreUI.UI.Box"/> &quot;box&quot; and <see cref="CoreUI.UI.Table"/> &quot;table&quot; smart objects.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// <b>NOTE: </b>Default fill hint values are true, for both axes.</summary>
        /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
        /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetHintFill(out bool x, out bool y);

        /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="CoreUI.Gfx.IHint.HintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
        /// 
        /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="CoreUI.Gfx.IHint.HintMargin"/> set on objects should add up to the object space on the final scene composition.
        /// 
        /// See documentation of possible users: in Evas, they are the <see cref="CoreUI.UI.Box"/> &quot;box&quot; and <see cref="CoreUI.UI.Table"/> &quot;table&quot; smart objects.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// <b>NOTE: </b>Default fill hint values are true, for both axes.</summary>
        /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
        /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetHintFill(bool x, bool y);

        /// <summary>Object hints changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler HintsChanged;
        /// <summary>Defines the aspect ratio to respect when scaling this object.
        /// 
        /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
        /// 
        /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
        /// <value>Mode of interpretation.</value>
        /// <since_tizen> 6 </since_tizen>
        (CoreUI.Gfx.HintAspect, CoreUI.DataTypes.Size2D) HintAspect {
            get;
            set;
        }

        /// <summary>Hints on the object&apos;s maximum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Values -1 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <value>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D HintSizeMax {
            get;
            set;
        }

        /// <summary>Internal hints for an object&apos;s maximum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Values -1 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is internal and meant for widget developers to define the absolute maximum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Applications should use <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> instead.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.<br/>
        /// <b>Note on writing:</b> This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; maximum size.</summary>
        /// <value>Maximum size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D HintSizeRestrictedMax {
            get;
        }

        /// <summary>Read-only maximum size combining both <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> hints.
        /// 
        /// <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="CoreUI.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.</summary>
        /// <value>Maximum size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D HintSizeCombinedMax {
            get;
        }

        /// <summary>Hints on the object&apos;s minimum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Value 0 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <value>Minimum size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D HintSizeMin {
            get;
            set;
        }

        /// <summary>Internal hints for an object&apos;s minimum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Values 0 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> instead.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.<br/>
        /// <b>Note on writing:</b> This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; minimum size.<br/>
        /// <b>Note on reading:</b> Get the &quot;intrinsic&quot; minimum size of this object.</summary>
        /// <value>Minimum size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D HintSizeRestrictedMin {
            get;
        }

        /// <summary>Read-only minimum size combining both <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> hints.
        /// 
        /// <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="CoreUI.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
        /// <value>Minimum size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D HintSizeCombinedMin {
            get;
        }

        /// <summary>Hints for an object&apos;s margin or padding space.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
        /// <value>Integer to specify left padding.</value>
        /// <since_tizen> 6 </since_tizen>
        (int, int, int, int) HintMargin {
            get;
            set;
        }

        /// <summary>Hints for an object&apos;s weight.
        /// 
        /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="CoreUI.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
        /// 
        /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
        /// 
        /// <b>NOTE: </b>Default weight hint values are 0.0, for both axis.</summary>
        /// <value>Non-negative double value to use as horizontal weight hint.</value>
        /// <since_tizen> 6 </since_tizen>
        (double, double) HintWeight {
            get;
            set;
        }

        /// <summary>Hints for an object&apos;s alignment.
        /// 
        /// These are hints on how to align this object inside the boundaries of its container/manager.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.</summary>
        /// <value>Controls the horizontal alignment.</value>
        /// <since_tizen> 6 </since_tizen>
        (CoreUI.Gfx.Align, CoreUI.Gfx.Align) HintAlign {
            get;
            set;
        }

        /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="CoreUI.Gfx.IHint.HintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
        /// 
        /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="CoreUI.Gfx.IHint.HintMargin"/> set on objects should add up to the object space on the final scene composition.
        /// 
        /// See documentation of possible users: in Evas, they are the <see cref="CoreUI.UI.Box"/> &quot;box&quot; and <see cref="CoreUI.UI.Table"/> &quot;table&quot; smart objects.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// <b>NOTE: </b>Default fill hint values are true, for both axes.</summary>
        /// <value><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</value>
        /// <since_tizen> 6 </since_tizen>
        (bool, bool) HintFill {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IHintNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_gfx_hint_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_gfx_hint_aspect_get_static_delegate == null)
            {
                efl_gfx_hint_aspect_get_static_delegate = new efl_gfx_hint_aspect_get_delegate(hint_aspect_get);
            }

            if (methods.Contains("GetHintAspect"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_aspect_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_aspect_get_static_delegate) });
            }

            if (efl_gfx_hint_aspect_set_static_delegate == null)
            {
                efl_gfx_hint_aspect_set_static_delegate = new efl_gfx_hint_aspect_set_delegate(hint_aspect_set);
            }

            if (methods.Contains("SetHintAspect"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_aspect_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_aspect_set_static_delegate) });
            }

            if (efl_gfx_hint_size_max_get_static_delegate == null)
            {
                efl_gfx_hint_size_max_get_static_delegate = new efl_gfx_hint_size_max_get_delegate(hint_size_max_get);
            }

            if (methods.Contains("GetHintSizeMax"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_max_get_static_delegate) });
            }

            if (efl_gfx_hint_size_max_set_static_delegate == null)
            {
                efl_gfx_hint_size_max_set_static_delegate = new efl_gfx_hint_size_max_set_delegate(hint_size_max_set);
            }

            if (methods.Contains("SetHintSizeMax"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_max_set_static_delegate) });
            }

            if (efl_gfx_hint_size_restricted_max_get_static_delegate == null)
            {
                efl_gfx_hint_size_restricted_max_get_static_delegate = new efl_gfx_hint_size_restricted_max_get_delegate(hint_size_restricted_max_get);
            }

            if (methods.Contains("GetHintSizeRestrictedMax"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_max_get_static_delegate) });
            }

            if (efl_gfx_hint_size_combined_max_get_static_delegate == null)
            {
                efl_gfx_hint_size_combined_max_get_static_delegate = new efl_gfx_hint_size_combined_max_get_delegate(hint_size_combined_max_get);
            }

            if (methods.Contains("GetHintSizeCombinedMax"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_combined_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_combined_max_get_static_delegate) });
            }

            if (efl_gfx_hint_size_min_get_static_delegate == null)
            {
                efl_gfx_hint_size_min_get_static_delegate = new efl_gfx_hint_size_min_get_delegate(hint_size_min_get);
            }

            if (methods.Contains("GetHintSizeMin"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_min_get_static_delegate) });
            }

            if (efl_gfx_hint_size_min_set_static_delegate == null)
            {
                efl_gfx_hint_size_min_set_static_delegate = new efl_gfx_hint_size_min_set_delegate(hint_size_min_set);
            }

            if (methods.Contains("SetHintSizeMin"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_min_set_static_delegate) });
            }

            if (efl_gfx_hint_size_restricted_min_get_static_delegate == null)
            {
                efl_gfx_hint_size_restricted_min_get_static_delegate = new efl_gfx_hint_size_restricted_min_get_delegate(hint_size_restricted_min_get);
            }

            if (methods.Contains("GetHintSizeRestrictedMin"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_min_get_static_delegate) });
            }

            if (efl_gfx_hint_size_combined_min_get_static_delegate == null)
            {
                efl_gfx_hint_size_combined_min_get_static_delegate = new efl_gfx_hint_size_combined_min_get_delegate(hint_size_combined_min_get);
            }

            if (methods.Contains("GetHintSizeCombinedMin"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_combined_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_combined_min_get_static_delegate) });
            }

            if (efl_gfx_hint_margin_get_static_delegate == null)
            {
                efl_gfx_hint_margin_get_static_delegate = new efl_gfx_hint_margin_get_delegate(hint_margin_get);
            }

            if (methods.Contains("GetHintMargin"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_margin_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_margin_get_static_delegate) });
            }

            if (efl_gfx_hint_margin_set_static_delegate == null)
            {
                efl_gfx_hint_margin_set_static_delegate = new efl_gfx_hint_margin_set_delegate(hint_margin_set);
            }

            if (methods.Contains("SetHintMargin"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_margin_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_margin_set_static_delegate) });
            }

            if (efl_gfx_hint_weight_get_static_delegate == null)
            {
                efl_gfx_hint_weight_get_static_delegate = new efl_gfx_hint_weight_get_delegate(hint_weight_get);
            }

            if (methods.Contains("GetHintWeight"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_weight_get_static_delegate) });
            }

            if (efl_gfx_hint_weight_set_static_delegate == null)
            {
                efl_gfx_hint_weight_set_static_delegate = new efl_gfx_hint_weight_set_delegate(hint_weight_set);
            }

            if (methods.Contains("SetHintWeight"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_weight_set_static_delegate) });
            }

            if (efl_gfx_hint_align_get_static_delegate == null)
            {
                efl_gfx_hint_align_get_static_delegate = new efl_gfx_hint_align_get_delegate(hint_align_get);
            }

            if (methods.Contains("GetHintAlign"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_align_get_static_delegate) });
            }

            if (efl_gfx_hint_align_set_static_delegate == null)
            {
                efl_gfx_hint_align_set_static_delegate = new efl_gfx_hint_align_set_delegate(hint_align_set);
            }

            if (methods.Contains("SetHintAlign"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_align_set_static_delegate) });
            }

            if (efl_gfx_hint_fill_get_static_delegate == null)
            {
                efl_gfx_hint_fill_get_static_delegate = new efl_gfx_hint_fill_get_delegate(hint_fill_get);
            }

            if (methods.Contains("GetHintFill"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_fill_get_static_delegate) });
            }

            if (efl_gfx_hint_fill_set_static_delegate == null)
            {
                efl_gfx_hint_fill_set_static_delegate = new efl_gfx_hint_fill_set_delegate(hint_fill_set);
            }

            if (methods.Contains("SetHintFill"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_fill_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_gfx_hint_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_hint_aspect_get_delegate(System.IntPtr obj, System.IntPtr pd,  out CoreUI.Gfx.HintAspect mode,  out CoreUI.DataTypes.Size2D sz);

        
        internal delegate void efl_gfx_hint_aspect_get_api_delegate(System.IntPtr obj,  out CoreUI.Gfx.HintAspect mode,  out CoreUI.DataTypes.Size2D sz);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_aspect_get_api_delegate> efl_gfx_hint_aspect_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_aspect_get_api_delegate>(Module, "efl_gfx_hint_aspect_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_aspect_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.Gfx.HintAspect mode, out CoreUI.DataTypes.Size2D sz)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_aspect_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                mode = default(CoreUI.Gfx.HintAspect);CoreUI.DataTypes.Size2D _out_sz = default(CoreUI.DataTypes.Size2D);

                try
                {
                    ((IHint)ws.Target).GetHintAspect(out mode, out _out_sz);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

        sz = _out_sz;
        
            }
            else
            {
                efl_gfx_hint_aspect_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out mode, out sz);
            }
        }

        private static efl_gfx_hint_aspect_get_delegate efl_gfx_hint_aspect_get_static_delegate;

        
        private delegate void efl_gfx_hint_aspect_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Gfx.HintAspect mode,  CoreUI.DataTypes.Size2D sz);

        
        internal delegate void efl_gfx_hint_aspect_set_api_delegate(System.IntPtr obj,  CoreUI.Gfx.HintAspect mode,  CoreUI.DataTypes.Size2D sz);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_aspect_set_api_delegate> efl_gfx_hint_aspect_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_aspect_set_api_delegate>(Module, "efl_gfx_hint_aspect_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_aspect_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.HintAspect mode, CoreUI.DataTypes.Size2D sz)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_aspect_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _in_sz = sz;

                try
                {
                    ((IHint)ws.Target).SetHintAspect(mode, _in_sz);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_aspect_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), mode, sz);
            }
        }

        private static efl_gfx_hint_aspect_set_delegate efl_gfx_hint_aspect_set_static_delegate;

        
        private delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_max_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_max_get_api_delegate> efl_gfx_hint_size_max_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_max_get_api_delegate>(Module, "efl_gfx_hint_size_max_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D hint_size_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_size_max_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeMax();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_hint_size_max_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_hint_size_max_get_delegate efl_gfx_hint_size_max_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D sz);

        
        internal delegate void efl_gfx_hint_size_max_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D sz);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_max_set_api_delegate> efl_gfx_hint_size_max_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_max_set_api_delegate>(Module, "efl_gfx_hint_size_max_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_size_max_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Size2D sz)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_size_max_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _in_sz = sz;

                try
                {
                    ((IHint)ws.Target).SetHintSizeMax(_in_sz);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_size_max_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sz);
            }
        }

        private static efl_gfx_hint_size_max_set_delegate efl_gfx_hint_size_max_set_static_delegate;

        
        private delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_restricted_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_restricted_max_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_max_get_api_delegate> efl_gfx_hint_size_restricted_max_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_max_get_api_delegate>(Module, "efl_gfx_hint_size_restricted_max_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D hint_size_restricted_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_size_restricted_max_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeRestrictedMax();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_hint_size_restricted_max_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_hint_size_restricted_max_get_delegate efl_gfx_hint_size_restricted_max_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_restricted_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D sz);

        
        internal delegate void efl_gfx_hint_size_restricted_max_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D sz);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_max_set_api_delegate> efl_gfx_hint_size_restricted_max_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_max_set_api_delegate>(Module, "efl_gfx_hint_size_restricted_max_set");

        
        private delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_combined_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_combined_max_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_combined_max_get_api_delegate> efl_gfx_hint_size_combined_max_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_combined_max_get_api_delegate>(Module, "efl_gfx_hint_size_combined_max_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D hint_size_combined_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_size_combined_max_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeCombinedMax();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_hint_size_combined_max_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_hint_size_combined_max_get_delegate efl_gfx_hint_size_combined_max_get_static_delegate;

        
        private delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_min_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_min_get_api_delegate> efl_gfx_hint_size_min_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_min_get_api_delegate>(Module, "efl_gfx_hint_size_min_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D hint_size_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_size_min_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeMin();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_hint_size_min_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_hint_size_min_get_delegate efl_gfx_hint_size_min_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D sz);

        
        internal delegate void efl_gfx_hint_size_min_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D sz);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_min_set_api_delegate> efl_gfx_hint_size_min_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_min_set_api_delegate>(Module, "efl_gfx_hint_size_min_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_size_min_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Size2D sz)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_size_min_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _in_sz = sz;

                try
                {
                    ((IHint)ws.Target).SetHintSizeMin(_in_sz);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_size_min_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sz);
            }
        }

        private static efl_gfx_hint_size_min_set_delegate efl_gfx_hint_size_min_set_static_delegate;

        
        private delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_restricted_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_restricted_min_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_min_get_api_delegate> efl_gfx_hint_size_restricted_min_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_min_get_api_delegate>(Module, "efl_gfx_hint_size_restricted_min_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D hint_size_restricted_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_size_restricted_min_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeRestrictedMin();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_hint_size_restricted_min_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_hint_size_restricted_min_get_delegate efl_gfx_hint_size_restricted_min_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_restricted_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D sz);

        
        internal delegate void efl_gfx_hint_size_restricted_min_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D sz);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate> efl_gfx_hint_size_restricted_min_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate>(Module, "efl_gfx_hint_size_restricted_min_set");

        
        private delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_combined_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_gfx_hint_size_combined_min_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_combined_min_get_api_delegate> efl_gfx_hint_size_combined_min_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_combined_min_get_api_delegate>(Module, "efl_gfx_hint_size_combined_min_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D hint_size_combined_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_size_combined_min_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IHint)ws.Target).GetHintSizeCombinedMin();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_hint_size_combined_min_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_hint_size_combined_min_get_delegate efl_gfx_hint_size_combined_min_get_static_delegate;

        
        private delegate void efl_gfx_hint_margin_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int l,  out int r,  out int t,  out int b);

        
        internal delegate void efl_gfx_hint_margin_get_api_delegate(System.IntPtr obj,  out int l,  out int r,  out int t,  out int b);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_margin_get_api_delegate> efl_gfx_hint_margin_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_margin_get_api_delegate>(Module, "efl_gfx_hint_margin_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_margin_get(System.IntPtr obj, System.IntPtr pd, out int l, out int r, out int t, out int b)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_margin_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                l = default(int);r = default(int);t = default(int);b = default(int);
                try
                {
                    ((IHint)ws.Target).GetHintMargin(out l, out r, out t, out b);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_margin_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out l, out r, out t, out b);
            }
        }

        private static efl_gfx_hint_margin_get_delegate efl_gfx_hint_margin_get_static_delegate;

        
        private delegate void efl_gfx_hint_margin_set_delegate(System.IntPtr obj, System.IntPtr pd,  int l,  int r,  int t,  int b);

        
        internal delegate void efl_gfx_hint_margin_set_api_delegate(System.IntPtr obj,  int l,  int r,  int t,  int b);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_margin_set_api_delegate> efl_gfx_hint_margin_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_margin_set_api_delegate>(Module, "efl_gfx_hint_margin_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_margin_set(System.IntPtr obj, System.IntPtr pd, int l, int r, int t, int b)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_margin_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IHint)ws.Target).SetHintMargin(l, r, t, b);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_margin_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), l, r, t, b);
            }
        }

        private static efl_gfx_hint_margin_set_delegate efl_gfx_hint_margin_set_static_delegate;

        
        private delegate void efl_gfx_hint_weight_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        internal delegate void efl_gfx_hint_weight_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_weight_get_api_delegate> efl_gfx_hint_weight_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_weight_get_api_delegate>(Module, "efl_gfx_hint_weight_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_weight_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_weight_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                x = default(double);y = default(double);
                try
                {
                    ((IHint)ws.Target).GetHintWeight(out x, out y);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_weight_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out x, out y);
            }
        }

        private static efl_gfx_hint_weight_get_delegate efl_gfx_hint_weight_get_static_delegate;

        
        private delegate void efl_gfx_hint_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        internal delegate void efl_gfx_hint_weight_set_api_delegate(System.IntPtr obj,  double x,  double y);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_weight_set_api_delegate> efl_gfx_hint_weight_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_weight_set_api_delegate>(Module, "efl_gfx_hint_weight_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_weight_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_weight_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IHint)ws.Target).SetHintWeight(x, y);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_weight_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), x, y);
            }
        }

        private static efl_gfx_hint_weight_set_delegate efl_gfx_hint_weight_set_static_delegate;

        
        private delegate void efl_gfx_hint_align_get_delegate(System.IntPtr obj, System.IntPtr pd,  out CoreUI.Gfx.Align x,  out CoreUI.Gfx.Align y);

        
        internal delegate void efl_gfx_hint_align_get_api_delegate(System.IntPtr obj,  out CoreUI.Gfx.Align x,  out CoreUI.Gfx.Align y);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_align_get_api_delegate> efl_gfx_hint_align_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_align_get_api_delegate>(Module, "efl_gfx_hint_align_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_align_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.Gfx.Align x, out CoreUI.Gfx.Align y)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_align_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                x = default(CoreUI.Gfx.Align);y = default(CoreUI.Gfx.Align);
                try
                {
                    ((IHint)ws.Target).GetHintAlign(out x, out y);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_align_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out x, out y);
            }
        }

        private static efl_gfx_hint_align_get_delegate efl_gfx_hint_align_get_static_delegate;

        
        private delegate void efl_gfx_hint_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Gfx.Align x,  CoreUI.Gfx.Align y);

        
        internal delegate void efl_gfx_hint_align_set_api_delegate(System.IntPtr obj,  CoreUI.Gfx.Align x,  CoreUI.Gfx.Align y);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_align_set_api_delegate> efl_gfx_hint_align_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_align_set_api_delegate>(Module, "efl_gfx_hint_align_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_align_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.Align x, CoreUI.Gfx.Align y)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_align_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IHint)ws.Target).SetHintAlign(x, y);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_align_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), x, y);
            }
        }

        private static efl_gfx_hint_align_set_delegate efl_gfx_hint_align_set_static_delegate;

        
        private delegate void efl_gfx_hint_fill_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool x, [MarshalAs(UnmanagedType.U1)] out bool y);

        
        internal delegate void efl_gfx_hint_fill_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool x, [MarshalAs(UnmanagedType.U1)] out bool y);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_fill_get_api_delegate> efl_gfx_hint_fill_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_fill_get_api_delegate>(Module, "efl_gfx_hint_fill_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_fill_get(System.IntPtr obj, System.IntPtr pd, out bool x, out bool y)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_fill_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                x = default(bool);y = default(bool);
                try
                {
                    ((IHint)ws.Target).GetHintFill(out x, out y);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_fill_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out x, out y);
            }
        }

        private static efl_gfx_hint_fill_get_delegate efl_gfx_hint_fill_get_static_delegate;

        
        private delegate void efl_gfx_hint_fill_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool x, [MarshalAs(UnmanagedType.U1)] bool y);

        
        internal delegate void efl_gfx_hint_fill_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool x, [MarshalAs(UnmanagedType.U1)] bool y);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_fill_set_api_delegate> efl_gfx_hint_fill_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_fill_set_api_delegate>(Module, "efl_gfx_hint_fill_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void hint_fill_set(System.IntPtr obj, System.IntPtr pd, bool x, bool y)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_fill_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IHint)ws.Target).SetHintFill(x, y);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_fill_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), x, y);
            }
        }

        private static efl_gfx_hint_fill_set_delegate efl_gfx_hint_fill_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.Gfx {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class HintExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> HintSizeMax<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IHint, T>magic = null) where T : CoreUI.Gfx.IHint {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("hint_size_max", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> HintSizeRestrictedMax<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IHint, T>magic = null) where T : CoreUI.Gfx.IHint {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("hint_size_restricted_max", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> HintSizeMin<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IHint, T>magic = null) where T : CoreUI.Gfx.IHint {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("hint_size_min", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> HintSizeRestrictedMin<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IHint, T>magic = null) where T : CoreUI.Gfx.IHint {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("hint_size_restricted_min", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

