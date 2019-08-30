#define EFL_BETA
#if EFL_BETA

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Efl {

/// <summary>Represents a bindable property as used by <see cref="Efl.Ui.ItemFactory&lt;T&gt;" /> instances.
///
/// <para>It is internally instantiated and returned by generated extension methods.</para>
/// </summary>
public class BindableProperty<T>
{

    /// <summary>Creates a new bindable property with the source name <c>name</c>.</summary>
    public BindableProperty(string name, Efl.Ui.IPropertyBind binder)
    {
        this.propertyName = name;
        this.partName = null;
        this.binder = binder;
    }

    /// <summary>Creates a new bindable property for part <c>part</c>.</summary>
    public BindableProperty(string partName, string partProperty, Efl.Ui.IPropertyBind binder)
    {
        this.partName = partName;
        this.propertyName = partProperty;
        this.binder = binder;
    }

    /// <summary>Binds the model property <c>modelProperty</c> to the property <c>name</c> set in the constructor.</summary>
    public Eina.Error Bind(string modelProperty)
    {
        if (this.partName == null)
        {
            return this.binder.PropertyBind(this.propertyName, modelProperty);
        }
        else
        {
            var partHolder = this.binder as Efl.IPart;

            if (partHolder == null)
            {
                throw new InvalidOperationException($"Failed to cast binder {binder} to IPart");
            }

            var partBinder = partHolder.GetPart(this.partName) as Efl.Ui.IPropertyBind;

            if (partBinder != null)
            {
                return partBinder.PropertyBind(this.propertyName, modelProperty);
            }
            else
            {
                throw new InvalidOperationException($"Failed to get part {this.partName}");
            }
        }
    }

    string propertyName;
    string partName;
    Efl.Ui.IPropertyBind binder;
}

/// <summary>Represents bindable parts as used by <see cref="Efl.Ui.ItemFactory&lt;T&gt;" /> instances.
///
/// <para>It is internally instantiated and returned by generated extension methods.</para>
/// </summary>
public class BindablePart<T>
{
    /// <summary>Creates a new bindable property with the binder <c>binder</c>.</summary>
    public BindablePart(string partName, Efl.Ui.IPropertyBind binder)
    {
        this.PartName = partName;
        this.Binder = binder;
    }

    /// <summary>The name of the part this instance wraps.</summary>
    public string PartName { get; private set; }
    /// <summary>The binder that will be used to bind the properties.</summary>
    public Efl.Ui.IPropertyBind Binder { get; private set; }

}

/// <summary>Represents bindable factory parts as used by <see cref="Efl.Ui.ItemFactory&lt;T&gt;" /> instances.
/// </summary>
public class BindableFactoryPart<T>
{
    /// <summary>Creates a new bindable factory part with the binder <c>binder</c>.</summary>
    public BindableFactoryPart(string partName, Efl.Ui.IFactoryBind binder)
    {
        this.PartName = partName;
        this.Binder = binder;
    }

    /// <summary>The name of the part this instance wraps.</summary>
    public string PartName { get; private set; }
    /// <summary>The binder that will be used to bind the properties.</summary>
    public Efl.Ui.IFactoryBind Binder { get; private set; }

    /// <summary>Binds the given factory to this part.</summary>
    public Eina.Error BindFactory(Efl.Ui.IFactory factory)
    {
        this.Binder.FactoryBind(this.PartName, factory);
        return Eina.Error.NO_ERROR;
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
