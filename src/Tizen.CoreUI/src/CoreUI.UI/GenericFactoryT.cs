using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace CoreUI.UI
{

/// <summary>Generic factory extend class.
/// </summary>
/// <since_tizen> 6 </since_tizen>
public interface IGenericFactoryExtended<T>
{
    /// <summary>Get PropertyBind in given type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.UI.IPropertyBind GetPropBind();
    /// <summary>Get FactoryBind in given type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.UI.IFactoryBind GetFactoryBind();
}

/// <summary>Generic factory part extend class.
/// </summary>
/// <since_tizen> 6 </since_tizen>
public interface IGenericFactoryPartExtended<T>
{
    /// <summary>Get PropertyBind in part of given type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.UI.IPropertyBind GetPropBind();
    /// <summary>Get FactoryBind in part of given type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.UI.IFactoryBind GetFactoryBind();
}

/// <summary>Helper factory class. Makes use of C# extension methods for easier property binding.
///
/// <code>
/// var factory = CoreUI.UI.GenericFactory&lt;CoreUI.UI.Button&gt;();
/// factory.Style().Bind("Name"); // The factory Style property is bound to the Name property for the given model.
/// </code>
/// </summary>
/// <since_tizen> 6 </since_tizen>
public class GenericFactory<T> : CoreUI.UI.GenericFactory, IGenericFactoryExtended<T>, IGenericFactoryPartExtended<T>
{
    /// <summary>Creates a new factory.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="parent">The parent of the factory.</param>
    public GenericFactory(CoreUI.Object parent = null)
        : base (parent, typeof(T))
    {
    }

    /// <summary>Get a propertyBind method from given type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual CoreUI.UI.IPropertyBind GetPropBind() { return this; }
    /// <summary>Get a FactoryBind method from givn type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual CoreUI.UI.IFactoryBind GetFactoryBind() { return this; }
}
    
}
