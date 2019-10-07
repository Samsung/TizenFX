#if EFL_BETA

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace UIKit { namespace Ui {

/// <summary>Helper factory class. Makes use of C# extension methods for easier property binding.
///
/// <code>
/// var factory = UIKit.Ui.Factory&lt;UIKit.Ui.Button&gt;();
/// factory.Style().Bind("Name"); // The factory Style property is bound to the Name property for the given model.
/// </code>
///
/// Since EFL 1.23.
///
/// </summary>
public class ItemFactory<T> : UIKit.Ui.LayoutFactory, IDisposable
{
    /// <summary>Creates a new factory.</summary>
    public ItemFactory(UIKit.Object parent = null)
        : base (parent, typeof(T))
    {
    }
}

} }

#endif
