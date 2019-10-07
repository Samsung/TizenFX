using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using UIKit.DataTypes;

#if EFL_BETA

namespace UIKit {

/// <summary>Generic <see cref="UIKit.IModel" /> implementation for MVVM models based on <see cref="UIKit.UserModel&lt;T&gt;" />
///
/// Since EFL 1.23.
/// </summary>
public class GenericModel<T> : UIKit.Object, UIKit.IModel, IDisposable
{
   private UIKit.IModel model;

   /// <summary>Creates a new model wrapping <c>model</c>.</summary>
   public GenericModel (UIKit.IModel model, UIKit.Object parent = null) : base(parent)
   {
       this.model = model;
   }

   /// <summary>The list of properties available in the wrapped model.</summary>
   public UIKit.DataTypes.Iterator< System.String> Properties
   {
      get { return GetProperties(); }
   }

   /// <summary>The number of children in the wrapped model.</summary>
   public  uint ChildrenCount
   {
      get { return GetChildrenCount(); }
   }

   /// <summary>The list of properties available in the wrapped model.</summary>
   public UIKit.DataTypes.Iterator<System.String> GetProperties()
   {
       return model.GetProperties();
   }

   /// <summary>Gets the value of the given property in the wrapped model.</summary>
   public UIKit.DataTypes.Value GetProperty(  System.String property)
   {
       return model.GetProperty(property);
   }

   /// <summary>Sets the value of the given property in the given model.</summary>
   public UIKit.DataTypes.Future SetProperty(  System.String property,   UIKit.DataTypes.Value value)
   {
       return model.SetProperty(property, value);
   }

   /// <summary>Returns the number of children in the wrapped model.</summary>
   public uint GetChildrenCount()
   {
       return model.GetChildrenCount();
   }

   /// <summary>Returns an <see cref="UIKit.DataTypes.Future" /> that will resolve when the property is ready to be read.</summary>
   public UIKit.DataTypes.Future GetPropertyReady(  System.String property)
   {
       return model.GetPropertyReady(property);
   }

   /// <summary>Gets a number of children from the wrapped model.</summary>
   public UIKit.DataTypes.Future GetChildrenSlice(  uint start,   uint count)
   {
       return model.GetChildrenSlice(start, count);
   }

   /// <summary>Adds a new object to the wrapper model.</summary>
   public void Add(T o)
   {
      UIKit.IModel child = (UIKit.IModel)this.AddChild();
      ModelHelper.SetProperties(o, child);
   }

   /// <summary>Adds a new childs to the model and returns it.</summary>
   public UIKit.Object AddChild()
   {
       return model.AddChild();
   }

   /// <summary>Deletes the given <c>child</c> from the wrapped model.</summary>
   public void DelChild( UIKit.Object child)
   {
       model.DelChild(child);
   }

   /// <summary>Gets the element at the specified <c>index</c>.</summary>
   async public System.Threading.Tasks.Task<T> GetAtAsync(uint index)
   {
       using (UIKit.DataTypes.Value v = await GetChildrenSliceAsync(index, 1))
       {
           if (v.GetValueType().IsContainer())
           {
               var child = (UIKit.IModel)v[0];
               T obj = (T)Activator.CreateInstance(typeof(T), new System.Object[] {});
               ModelHelper.GetProperties(obj, child);
               return obj;
           }
           else
           {
               throw new System.InvalidOperationException("GetChildrenSlice must have returned a container");
           }
       }
   }

   /// <summary>Async wrapper around <see cref="SetProperty(System.String, UIKit.DataTypes.Value)" />.</summary>
   public System.Threading.Tasks.Task<UIKit.DataTypes.Value> SetPropertyAsync(  System.String property,  UIKit.DataTypes.Value value, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
       return model.SetPropertyAsync(property, value, token);
   }

   /// <summary>Async wrapper around <see cref="GetPropertyReady(System.String)" />.</summary>
   public System.Threading.Tasks.Task<UIKit.DataTypes.Value> GetPropertyReadyAsync(  System.String property, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
       return model.GetPropertyReadyAsync(property, token);
   }

   /// <summary>Async wrapper around <see cref="GetChildrenSlice(uint, uint)" />.</summary>
   public System.Threading.Tasks.Task<UIKit.DataTypes.Value> GetChildrenSliceAsync(  uint start,  uint count, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
       return model.GetChildrenSliceAsync(start, count, token);
   }

   /// <summary>Event triggered when properties on the wrapped model changes.</summary>
   public event EventHandler<UIKit.ModelPropertiesChangedEventArgs> PropertiesChangedEvent
   {
      add {
          model.PropertiesChangedEvent += value;
      }
      remove {
          model.PropertiesChangedEvent -= value;
      }
   }

   /// <summary>Event triggered when a child is added from the wrapped model.</summary>
   public event EventHandler<UIKit.ModelChildAddedEventArgs> ChildAddedEvent
   {
      add {
          model.ChildAddedEvent += value;
      }
      remove {
          model.ChildAddedEvent -= value;
      }
   }

   /// <summary>Event triggered when a child is removed from the wrapped model.</summary>
   public event EventHandler<UIKit.ModelChildRemovedEventArgs> ChildRemovedEvent
   {
      add {
          model.ChildRemovedEvent += value;
      }
      remove {
          model.ChildRemovedEvent -= value;
      }
   }

   /// <summary>Event triggered when the number of children changes.</summary>
   public event EventHandler ChildrenCountChangedEvent
   {
      add {
          model.ChildrenCountChangedEvent += value;
      }
      remove {
          model.ChildrenCountChangedEvent -= value;
      }
   }
}

}

#endif
