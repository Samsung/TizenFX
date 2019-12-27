using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.ComponentModel;

namespace CoreUI {

/// <summary>Represents a bindable property as used by <see cref="CoreUI.UI.GenericFactory&lt;T&gt;" /> instances.
///
/// <para>It is internally instantiated and returned by generated extension methods.</para>
/// </summary>
/// <since_tizen> 6 </since_tizen>
public class BindableProperty<T>
{

    /// <summary>Creates a new bindable property with the source name
    /// <c>name</c>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="name">The property name of the bind.</param>
    /// <param name="binder">The binder that will be used to bind the properties.</param>
    public BindableProperty(string name, CoreUI.UI.IPropertyBind binder)
    {
        this.propertyName = name;
        this.partName = null;
        this.binder = binder;
    }

    /// <summary>Creates a new bindable property for part <c>part</c>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="partName">The name of the part this instance wraps.</param>
    /// <param name="partProperty">The property name of the bind.</param>
    /// <param name="binder">Yhe binder that will be used to bind the properties.</param>
    public BindableProperty(string partName, string partProperty, CoreUI.UI.IPropertyBind binder)
    {
        this.partName = partName;
        this.propertyName = partProperty;
        this.binder = binder;
    }

    /// <summary>Binds the model property <c>modelProperty</c> to the property
    /// <c>name</c> set in the constructor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="modelProperty">The model property</param>
    public CoreUI.DataTypes.Error Bind(string modelProperty)
    {
        if (this.partName == null)
        {
            return this.binder.BindProperty(this.propertyName, modelProperty);
        }
        else
        {
            var partHolder = this.binder as CoreUI.IPart;

            if (partHolder == null)
            {
                throw new InvalidOperationException($"Failed to cast binder {binder} to IPart");
            }

            // We rely on reflection as GetPart is protected and not generated in IPart.
            var partMethod = partHolder.GetType().GetMethod("GetPart", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (partMethod == null)
            {
                throw new InvalidOperationException($"Failed to get 'GetPart' method on property binder");
            }

            var partBinder = partMethod.Invoke(partHolder, new System.Object[] { this.partName }) as CoreUI.UI.IPropertyBind;
            if (partBinder != null)
            {
                return partBinder.BindProperty(this.propertyName, modelProperty);
            }
            else
            {
                throw new InvalidOperationException($"Failed to get part {this.partName}");
            }
        }
    }

    /// <summary>
    ///   The property name of the bind.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    string propertyName;
    /// <summary>
    ///   The name of the part this instance wraps.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    string partName;
    /// <summary>
    ///   The binder that will be used to bind the properties.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    CoreUI.UI.IPropertyBind binder;
}

/// <summary>Represents bindable parts as used by <see cref="CoreUI.UI.GenericFactory&lt;T&gt;" /> instances.
///
/// <para>It is internally instantiated and returned by generated extension methods.</para>
/// </summary>
/// <since_tizen> 6 </since_tizen>
public class BindablePart<T>
{
    /// <summary>Creates a new bindable property with the binder <c>binder</c>.
    ///</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="partName">The name of the part this instance wraps.</param>
    /// <param name="binder">Yhe binder that will be used to bind the properties.</param>
    public BindablePart(string partName, CoreUI.UI.IPropertyBind binder)
    {
        this.PartName = partName;
        this.Binder = binder;
    }

    /// <summary>The name of the part this instance wraps.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public string PartName { get; private set; }
    /// <summary>The binder that will be used to bind the properties.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.IPropertyBind Binder { get; private set; }

}

/// <summary>Represents bindable factory parts as used by <see cref="CoreUI.UI.GenericFactory&lt;T&gt;" /> instances.
/// </summary>
/// <since_tizen> 6 </since_tizen>
public class BindableFactoryPart<T>
{
    /// <summary>Creates a new bindable factory part with the binder <c>binder</c>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
        /// <param name="partName">The name of the part this instance wraps.</param>
    /// <param name="binder">Yhe binder that will be used to bind the properties.</param>
    public BindableFactoryPart(string partName, CoreUI.UI.IFactoryBind binder)
    {
        this.PartName = partName;
        this.Binder = binder;
    }

    /// <summary>The name of the part this instance wraps.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public string PartName { get; private set; }
    /// <summary>The binder that will be used to bind the properties.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public CoreUI.UI.IFactoryBind Binder { get; private set; }

    /// <summary>Binds the given factory to this part.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="factory">The factory to be used.</param>
    public CoreUI.DataTypes.Error BindFactory(CoreUI.UI.IFactory factory)
    {
        return this.Binder.BindFactory(this.PartName, factory);
    }
}

namespace Csharp
{

/// <summary>Helper class to differentiate between factory extension methods.
///
/// For internal use only.</summary>
/// <since_tizen> 6 </since_tizen>
[EditorBrowsable(EditorBrowsableState.Never)]
public class ExtensionTag<TBase, TInherited>
    where TInherited : TBase
{
}

}

}
