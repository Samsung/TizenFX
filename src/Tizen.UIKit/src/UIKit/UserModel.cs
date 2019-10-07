using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

namespace UIKit {

#if EFL_BETA

internal class ModelHelper
{
    /// FIXME Move this to eina_value.cs and be a static method of Value?
    static internal UIKit.DataTypes.Value ValueFromProperty<T>(T source, PropertyInfo property)
    {
        return new UIKit.DataTypes.Value(property.GetValue(source));
    }

    static internal void SetPropertyFromValue<T>(T target, PropertyInfo property, UIKit.DataTypes.Value v)
    {
        property.SetValue(target, v.Unwrap());
    }

    /// <summary>Sets the properties of the <paramref name="child"/> from the properties of the given object
    /// <paramref name="o"/>.</summary>
    static internal void SetProperties<T>(T o, UIKit.IModel child)
    {
        var properties = typeof(T).GetProperties();
        foreach(var prop in properties)
        {
            child.SetProperty(prop.Name, ValueFromProperty(o, prop));
        }
    }

    /// <summary>Sets the properties of <paramref name="o"/> from the properties of <paramref name="child"/>.</summary>
    static internal void GetProperties<T>(T o, UIKit.IModel child)
    {
        var properties = typeof(T).GetProperties();
        foreach(var prop in properties)
        {
            using (var v = child.GetProperty(prop.Name))
            {
                SetPropertyFromValue(o, prop, v);
            }
        }
    }
}

/// <summary>Helper class to simplify the creation of MVVM Models based on <see cref="UIKit.IModel" />.
///
/// <para>This class works together with <see cref="UIKit.GenericModel&lt;T&gt;" /> to wrap user defined classes as MVVM models.
/// Example:</para>
///
/// <code>
/// public class PersonModel
/// {
///     public string Name { get; set; }
///     public int Age { get; set; }
/// }
/// // Instantiating the model
/// var modelData = new UIKit.UserModel&lt;PersonModel&gt;(parent);
/// modelData.Add(new PersonModel { Name = "John", Age = 30 };
/// var model = new UIKit.GenericModel&lt;PersonModel&gt;(modelData, parent);
/// PersonModel p = await model.GetAtAsync(0);
/// </code>
///
/// Since EFL 1.23.
/// </summary>
[UIKit.Wrapper.BindingEntity]
public class UserModel<T> : UIKit.MonoModelInternal, IDisposable
{
   /// <summary>Creates a new model.</summary>
   /// <param name="parent">The parent of the model.</param>
   public UserModel (UIKit.Object parent = null) : base(UIKit.MonoModelInternal.efl_mono_model_internal_class_get(), parent)
   {
     var properties = typeof(T).GetProperties();
     foreach(var prop in properties)
     {
        AddProperty(prop.Name, UIKit.DataTypes.ValueTypeBridge.GetManaged(prop.PropertyType));
     }
   }

   /// <summary>Disposes of this instance.</summary>
   ~UserModel()
   {
       Dispose(false);
   }

   /// <summary>Adds a new child to the model wrapping the properites of <c>o</c>
   ///
   /// <para>Reflection is used to instantiate a new <see cref="UIKit.IModel" /> for this child and
   /// set the mirroring properties correctly.</para>
   /// </summary>
   ///
   /// <param name="o">The user model instance to be added to this model.</param>
   public void Add (T o)
   {
       UIKit.IModel child = (UIKit.IModel) this.AddChild();
       ModelHelper.SetProperties(o, child);
   }
}

#endif

}
