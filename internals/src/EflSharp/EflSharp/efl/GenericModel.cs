#define EFL_BETA
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Eina;

#if EFL_BETA

namespace Efl {

/// <summary>Generic <see cref="Efl.IModel" /> implementation for MVVM models based on <see cref="Efl.UserModel&lt;T&gt;" /></summary>
public class GenericModel<T> : Efl.Object, Efl.IModel, IDisposable
{
   private Efl.IModel model;

   /// <summary>Creates a new model wrapping <c>model</c>.</summary>
   public GenericModel (Efl.IModel model, Efl.Object parent = null) : base(parent)
   {
       this.model = model;
   }

   /// <summary>The list of properties available in the wrapped model.</summary>
   public Eina.Iterator< System.String> Properties
   {
      get { return GetProperties(); }
   }

   /// <summary>The number of children in the wrapped model.</summary>
   public  uint ChildrenCount
   {
      get { return GetChildrenCount(); }
   }

   /// <summary>The list of properties available in the wrapped model.</summary>
   public Eina.Iterator<System.String> GetProperties()
   {
       return model.GetProperties();
   }

   /// <summary>Gets the value of the given property in the wrapped model.</summary>
   public Eina.Value GetProperty(  System.String property)
   {
       return model.GetProperty(property);
   }

   /// <summary>Sets the value of the given property in the given model.</summary>
   public Eina.Future SetProperty(  System.String property,   Eina.Value value)
   {
       return model.SetProperty(property, value);
   }

   /// <summary>Returns the number of children in the wrapped model.</summary>
   public uint GetChildrenCount()
   {
       return model.GetChildrenCount();
   }

   /// <summary>Returns an <see cref="Eina.Future" /> that will resolve when the property is ready to be read.</summary>
   public Eina.Future GetPropertyReady(  System.String property)
   {
       return model.GetPropertyReady(property);
   }

   /// <summary>Gets a number of children from the wrapped model.</summary>
   public Eina.Future GetChildrenSlice(  uint start,   uint count)
   {
       return model.GetChildrenSlice(start, count);
   }

   /// <summary>Adds a new object to the wrapper model.</summary>
   public void Add(T o)
   {
      Efl.IModel child = (Efl.IModel)this.AddChild();
      ModelHelper.SetProperties(o, child);
   }

   /// <summary>Adds a new childs to the model and returns it.</summary>
   public Efl.Object AddChild()
   {
       return model.AddChild();
   }

   /// <summary>Deletes the given <c>child</c> from the wrapped model.</summary>
   public void DelChild( Efl.Object child)
   {
       model.DelChild(child);
   }

   /// <summary>Gets the element at the specified <c>index</c>.</summary>
   async public System.Threading.Tasks.Task<T> GetAtAsync(uint index)
   {
       using (Eina.Value v = await GetChildrenSliceAsync(index, 1))
       {
           if (v.GetValueType().IsContainer())
           {
               var child = (Efl.IModel)v[0];
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

   /// <summary>Async wrapper around <see cref="SetProperty(System.String, Eina.Value)" />.</summary>
   public System.Threading.Tasks.Task<Eina.Value> SetPropertyAsync(  System.String property,  Eina.Value value, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
       return model.SetPropertyAsync(property, value, token);
   }

   /// <summary>Async wrapper around <see cref="GetPropertyReady(System.String)" />.</summary>
   public System.Threading.Tasks.Task<Eina.Value> GetPropertyReadyAsync(  System.String property, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
       return model.GetPropertyReadyAsync(property, token);
   }

   /// <summary>Async wrapper around <see cref="GetChildrenSlice(uint, uint)" />.</summary>
   public System.Threading.Tasks.Task<Eina.Value> GetChildrenSliceAsync(  uint start,  uint count, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
       return model.GetChildrenSliceAsync(start, count, token);
   }

   /// <summary>Event triggered when properties on the wrapped model changes.</summary>
   public event EventHandler<Efl.ModelPropertiesChangedEventArgs> PropertiesChangedEvent
   {
      add {
          model.PropertiesChangedEvent += value;
      }
      remove {
          model.PropertiesChangedEvent -= value;
      }
   }

   /// <summary>Event triggered when a child is added from the wrapped model.</summary>
   public event EventHandler<Efl.ModelChildAddedEventArgs> ChildAddedEvent
   {
      add {
          model.ChildAddedEvent += value;
      }
      remove {
          model.ChildAddedEvent -= value;
      }
   }

   /// <summary>Event triggered when a child is removed from the wrapped model.</summary>
   public event EventHandler<Efl.ModelChildRemovedEventArgs> ChildRemovedEvent
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
