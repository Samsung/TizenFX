using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using CoreUI.DataTypes;

namespace CoreUI {

/// <summary>
/// Generic <see cref="CoreUI.IModel" /> helper class to ease manual implementation of C# models.
///
/// <para>It provides an expanded API like async helpers to get children.</para>
///
/// <para>For MVVM-based models, <see cref="CoreUI.UserModel&lt;T&gt;" /> provides a simpler API.</para>
/// </summary>
/// <since_tizen> 6 </since_tizen>
/// <typeparam name="T">The type of the child model. It is the type used when adding/removing/getting items to this
/// model.</typeparam>
public class GenericModel<T> : CoreUI.Object, CoreUI.IModel
{
   private CoreUI.IModel model;

   /// <summary>Creates a new model wrapping <c>model</c>.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <param name="model">The model to be wrapped.</param>
   /// <param name="parent">The parent of the model.</param>
   public GenericModel (CoreUI.IModel model, CoreUI.Object parent = null) : base(parent)
   {
       this.model = model;
   }

   /// <summary>The list of properties available in the wrapped model.</summary>
   /// <since_tizen> 6 </since_tizen>
   public IEnumerable<System.String> Properties
   {
      get { return GetProperties(); }
   }

   /// <summary>The number of children in the wrapped model.</summary>
   /// <since_tizen> 6 </since_tizen>
   public  uint ChildrenCount
   {
      get { return GetChildrenCount(); }
   }

   /// <summary>The list of properties available in the wrapped model.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <returns>The list of properties in the model.</returns>
   public IEnumerable<System.String> GetProperties()
   {
       return model.GetProperties();
   }

   /// <summary>Gets the value of the given property in the wrapped model.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <param name="property">The property of the model.</param>
   /// <returns>The value of the property.</returns>
   public CoreUI.DataTypes.Value GetProperty(System.String property)
   {
       return model.GetProperty(property);
   }

   /// <summary>Sets the value of the given property in the given model.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <param name="property">The property of the model.</param>
   /// <param name="value">The value of the property.</param>
   /// <returns>An <see cref="CoreUI.DataTypes.Future" /> that resolves when the property has
   /// been set or reports an error if it could not be set.</returns>
   public CoreUI.DataTypes.Future SetProperty(System.String property,   CoreUI.DataTypes.Value value)
   {
       return model.SetProperty(property, value);
   }

   /// <summary>Returns the number of children in the wrapped model.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <returns>The number of children.</returns>
   public uint GetChildrenCount()
   {
       return model.GetChildrenCount();
   }

   /// <summary>Returns an <see cref="CoreUI.DataTypes.Future" /> that will resolve when the property is ready to be read.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <param name="property">The property of the model.</param>
   /// <returns>An <see cref="CoreUI.DataTypes.Future" /> that resolves when the property is ready.</returns>
   public CoreUI.DataTypes.Future GetPropertyReady(System.String property)
   {
       return model.GetPropertyReady(property);
   }

   /// <summary>Gets a number of children from the wrapped model.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <param name="start">The start of the range.</param>
   /// <param name="count">The size of the range.</param>
   /// <returns>An <see cref="CoreUI.DataTypes.Future" />  that resolves to an
   /// <see cref="CoreUI.DataTypes.Array&lt;T&gt;" /> of children models.</returns>
   public CoreUI.DataTypes.Future GetChildrenSlice(uint start,   uint count)
   {
       return model.GetChildrenSlice(start, count);
   }

   /// <summary>Adds a new object to the wrapper model.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <param name="o">The object to get the properties from.</param>
   public void Add(T o)
   {
      CoreUI.IModel child = (CoreUI.IModel)this.AddChild();
      ModelHelper.SetProperties(o, child);
   }

   /// <summary>Adds a new child to the model and returns it.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <returns>The object to be wrapped.</returns>
   public CoreUI.Object AddChild()
   {
       return model.AddChild();
   }

   /// <summary>Deletes the given <c>child</c> from the wrapped model.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <param name="child">The child to be deleted.</param>
   public void DelChild( CoreUI.Object child)
   {
       model.DelChild(child);
   }

   /// <summary>Gets the element at the specified <c>index</c>.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <param name="index">The position of the element.</param>
   /// <returns>Token to notify the async operation of external request to cancel.</returns>
   async public System.Threading.Tasks.Task<T> GetAtAsync(uint index)
   {
       using (CoreUI.DataTypes.Value v = await GetChildrenSliceAsync(index, 1).ConfigureAwait(false))
       {
           if (v.GetValueType().IsContainer())
           {
               var child = (CoreUI.IModel)v[0];
               T obj = (T)Activator.CreateInstance(typeof(T), Array.Empty<object>());
               ModelHelper.GetProperties(obj, child);
               return obj;
           }
           else
           {
               throw new System.InvalidOperationException("GetChildrenSlice must have returned a container");
           }
       }
   }

   /// <summary>Async wrapper around <see cref="SetProperty(System.String, CoreUI.DataTypes.Value)" />.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <param name="property">The property to be added.</param>
   /// <param name="value">The value of the property.</param>
   /// <param name="token">The token for the task's cancellation.</param>
   /// <returns>Task that resolves when the property has been set or could not
   /// be set.</returns>
   public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> SetPropertyAsync(System.String property,  CoreUI.DataTypes.Value value, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
       return model.SetPropertyAsync(property, value, token);
   }

   /// <summary>Async wrapper around <see cref="GetPropertyReady(System.String)" />.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <param name="property">The property of the model.</param>
   /// <param name="token">The token for the task's cancellation.</param>
   /// <returns>Task that resolves when the given property is ready to be
   /// read.</returns>
   public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> GetPropertyReadyAsync(System.String property, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
       return model.GetPropertyReadyAsync(property, token);
   }

   /// <summary>Async wrapper around <see cref="GetChildrenSlice(uint, uint)" />.</summary>
   /// <since_tizen> 6 </since_tizen>
   /// <param name="start">The start of the range.</param>
   /// <param name="count">The size of the range.</param>
   /// <param name="token">Token to notify the async operation of external request to cancel.</param>
   /// <returns>Task that resolves when the desired <see cref="CoreUI.DataTypes.Array&lt;T&gt;" /> of
   /// children models is ready.</returns>
   public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> GetChildrenSliceAsync(uint start,  uint count, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
       return model.GetChildrenSliceAsync(start, count, token);
   }

   /// <summary>Event triggered when properties on the wrapped model changes.</summary>
   /// <since_tizen> 6 </since_tizen>
   public event EventHandler<CoreUI.ModelPropertiesChangedEventArgs> PropertiesChanged
   {
      add {
          model.PropertiesChanged += value;
      }
      remove {
          model.PropertiesChanged -= value;
      }
   }

   /// <summary>Event triggered when a child is added from the wrapped model.</summary>
   /// <since_tizen> 6 </since_tizen>
   public event EventHandler<CoreUI.ModelChildAddedEventArgs> ChildAdded
   {
      add {
          model.ChildAdded += value;
      }
      remove {
          model.ChildAdded -= value;
      }
   }

   /// <summary>Event triggered when a child is removed from the wrapped model.</summary>
   /// <since_tizen> 6 </since_tizen>
   public event EventHandler<CoreUI.ModelChildRemovedEventArgs> ChildRemoved
   {
      add {
          model.ChildRemoved += value;
      }
      remove {
          model.ChildRemoved -= value;
      }
   }

   /// <summary>Event triggered when the number of children changes.</summary>
   /// <since_tizen> 6 </since_tizen>
   public event EventHandler ChildrenCountChanged
   {
      add {
          model.ChildrenCountChanged += value;
      }
      remove {
          model.ChildrenCountChanged -= value;
      }
   }
}

}
