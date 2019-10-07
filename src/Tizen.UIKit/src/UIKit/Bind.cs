#if EFL_BETA

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.ComponentModel;

namespace UIKit {

/// <summary>Represents a bindable property as used by <see cref="UIKit.Ui.ItemFactory&lt;T&gt;" /> instances.
///
/// <para>It is internally instantiated and returned by generated extension methods.</para>
///
/// Since EFL 1.23.
/// </summary>
public class BindableProperty<T>
{

    /// <summary>Creates a new bindable property with the source name <c>name</c>.</summary>
    public BindableProperty(string name, UIKit.Ui.IPropertyBind binder)
    {
        this.propertyName = name;
        this.partName = null;
        this.binder = binder;
    }

    /// <summary>Creates a new bindable property for part <c>part</c>.</summary>
    public BindableProperty(string partName, string partProperty, UIKit.Ui.IPropertyBind binder)
    {
        this.partName = partName;
        this.propertyName = partProperty;
        this.binder = binder;
    }

    /// <summary>Binds the model property <c>modelProperty</c> to the property <c>name</c> set in the constructor.</summary>
    public UIKit.DataTypes.Error Bind(string modelProperty)
    {
        if (this.partName == null)
        {
            return this.binder.BindProperty(this.propertyName, modelProperty);
        }
        else
        {
            var partHolder = this.binder as UIKit.IPart;

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

            var partBinder = partMethod.Invoke(partHolder, new System.Object[] { this.partName }) as UIKit.Ui.IPropertyBind;
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

    string propertyName;
    string partName;
    UIKit.Ui.IPropertyBind binder;
}

/// <summary>Represents bindable parts as used by <see cref="UIKit.Ui.ItemFactory&lt;T&gt;" /> instances.
///
/// <para>It is internally instantiated and returned by generated extension methods.</para>
///
/// Since EFL 1.23.
/// </summary>
public class BindablePart<T>
{
    /// <summary>Creates a new bindable property with the binder <c>binder</c>.</summary>
    public BindablePart(string partName, UIKit.Ui.IPropertyBind binder)
    {
        this.PartName = partName;
        this.Binder = binder;
    }

    /// <summary>The name of the part this instance wraps.</summary>
    public string PartName { get; private set; }
    /// <summary>The binder that will be used to bind the properties.</summary>
    public UIKit.Ui.IPropertyBind Binder { get; private set; }

}

/// <summary>Represents bindable factory parts as used by <see cref="UIKit.Ui.ItemFactory&lt;T&gt;" /> instances.
///
/// Since EFL 1.23.
/// </summary>
public class BindableFactoryPart<T>
{
    /// <summary>Creates a new bindable factory part with the binder <c>binder</c>.</summary>
    public BindableFactoryPart(string partName, UIKit.Ui.IFactoryBind binder)
    {
        this.PartName = partName;
        this.Binder = binder;
    }

    /// <summary>The name of the part this instance wraps.</summary>
    public string PartName { get; private set; }
    /// <summary>The binder that will be used to bind the properties.</summary>
    public UIKit.Ui.IFactoryBind Binder { get; private set; }

    /// <summary>Binds the given factory to this part.</summary>
    public UIKit.DataTypes.Error BindFactory(UIKit.Ui.IFactory factory)
    {
        return this.Binder.BindFactory(this.PartName, factory);
    }
}

namespace Csharp
{

/// <summary>Helper class to differentiate between factory extension methods.
///
/// For internal use only.</summary>
public class ExtensionTag<TBase, TInherited>
    where TInherited : TBase
{
}

}

}

#endif
