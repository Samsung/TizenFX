#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
///<summary>Event argument wrapper for event <see cref="Efl.ModelCompositeSelection.SelectedEvt"/>.</summary>
public class ModelCompositeSelectionSelectedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Object arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.ModelCompositeSelection.UnselectedEvt"/>.</summary>
public class ModelCompositeSelectionUnselectedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Object arg { get; set; }
}
/// <summary>Efl model composite selection class</summary>
[ModelCompositeSelectionNativeInherit]
public class ModelCompositeSelection : Efl.ModelCompositeBoolean, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.ModelCompositeSelectionNativeInherit nativeInherit = new Efl.ModelCompositeSelectionNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ModelCompositeSelection))
            return Efl.ModelCompositeSelectionNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(ModelCompositeSelection obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_model_composite_selection_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public ModelCompositeSelection(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("ModelCompositeSelection", efl_model_composite_selection_class_get(), typeof(ModelCompositeSelection), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected ModelCompositeSelection(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ModelCompositeSelection(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ModelCompositeSelection static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ModelCompositeSelection(obj.NativeHandle);
   }
   ///<summary>Verifies if the given object is equal to this one.</summary>
   public override bool Equals(object obj)
   {
      var other = obj as Efl.Object;
      if (other == null)
         return false;
      return this.NativeHandle == other.NativeHandle;
   }
   ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
   public override int GetHashCode()
   {
      return this.NativeHandle.ToInt32();
   }
   ///<summary>Turns the native pointer into a string representation.</summary>
   public override String ToString()
   {
      return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
   }
private static object SelectedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler<Efl.ModelCompositeSelectionSelectedEvt_Args> SelectedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_MODEL_COMPOSITE_SELECTION_EVENT_SELECTED";
            if (add_cpp_event_handler(key, this.evt_SelectedEvt_delegate)) {
               eventHandlers.AddHandler(SelectedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_MODEL_COMPOSITE_SELECTION_EVENT_SELECTED";
            if (remove_cpp_event_handler(key, this.evt_SelectedEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectedEvt.</summary>
   public void On_SelectedEvt(Efl.ModelCompositeSelectionSelectedEvt_Args e)
   {
      EventHandler<Efl.ModelCompositeSelectionSelectedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ModelCompositeSelectionSelectedEvt_Args>)eventHandlers[SelectedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectedEvt_delegate;
   private void on_SelectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ModelCompositeSelectionSelectedEvt_Args args = new Efl.ModelCompositeSelectionSelectedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_SelectedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object UnselectedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler<Efl.ModelCompositeSelectionUnselectedEvt_Args> UnselectedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_MODEL_COMPOSITE_SELECTION_EVENT_UNSELECTED";
            if (add_cpp_event_handler(key, this.evt_UnselectedEvt_delegate)) {
               eventHandlers.AddHandler(UnselectedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_MODEL_COMPOSITE_SELECTION_EVENT_UNSELECTED";
            if (remove_cpp_event_handler(key, this.evt_UnselectedEvt_delegate)) { 
               eventHandlers.RemoveHandler(UnselectedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event UnselectedEvt.</summary>
   public void On_UnselectedEvt(Efl.ModelCompositeSelectionUnselectedEvt_Args e)
   {
      EventHandler<Efl.ModelCompositeSelectionUnselectedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ModelCompositeSelectionUnselectedEvt_Args>)eventHandlers[UnselectedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_UnselectedEvt_delegate;
   private void on_UnselectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ModelCompositeSelectionUnselectedEvt_Args args = new Efl.ModelCompositeSelectionUnselectedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_UnselectedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_SelectedEvt_delegate = new Efl.EventCb(on_SelectedEvt_NativeCallback);
      evt_UnselectedEvt_delegate = new Efl.EventCb(on_UnselectedEvt_NativeCallback);
   }
}
public class ModelCompositeSelectionNativeInherit : Efl.ModelCompositeBooleanNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.ModelCompositeSelection.efl_model_composite_selection_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.ModelCompositeSelection.efl_model_composite_selection_class_get();
   }
}
} 
