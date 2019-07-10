#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

[Efl.Ui.IDndContainerConcrete.NativeMethods]
public interface IDndContainer : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The time since mouse down happens to drag starts.</summary>
/// <returns>The drag delay time</returns>
double GetDragDelayTime();
    /// <summary>The time since mouse down happens to drag starts.</summary>
/// <param name="time">The drag delay time</param>
void SetDragDelayTime(double time);
    /// <summary>This registers a drag for items in a container. Many items can be dragged at a time. During dragging, there are three events emitted: EFL_DND_EVENT_DRAG_POS, EFL_DND_EVENT_DRAG_ACCEPT, EFL_DND_EVENT_DRAG_DONE.</summary>
/// <param name="data_func">Data and its format</param>
/// <param name="item_func">Item to determine drag start</param>
/// <param name="icon_func">Icon used during drag</param>
/// <param name="icon_list_func">Icons used for animations CHECKING</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
void AddDragItem(Efl.Dnd.DragDataGet data_func, Efl.Dnd.ItemGet item_func, Efl.Dnd.DragIconCreate icon_func, Efl.Dnd.DragIconListCreate icon_list_func, uint seat);
    /// <summary>Remove drag function of items in the container object.</summary>
/// <param name="seat">Specified seat for multiple seats case.</param>
void DelDragItem(uint seat);
    /// <param name="format">Accepted data formats</param>
/// <param name="item_func">Get item at specific position</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
void AddDropItem(Efl.Ui.SelectionFormat format, Efl.Dnd.ItemGet item_func, uint seat);
    /// <param name="seat">Specified seat for multiple seats case.</param>
void DelDropItem(uint seat);
                            /// <summary>The time since mouse down happens to drag starts.</summary>
    /// <value>The drag delay time</value>
    double DragDelayTime {
        get ;
        set ;
    }
}
sealed public class IDndContainerConcrete :
    Efl.Eo.EoWrapper
    , IDndContainer
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IDndContainerConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_dnd_container_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IDndContainer"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IDndContainerConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>The time since mouse down happens to drag starts.</summary>
    /// <returns>The drag delay time</returns>
    public double GetDragDelayTime() {
         var _ret_var = Efl.Ui.IDndContainerConcrete.NativeMethods.efl_ui_dnd_container_drag_delay_time_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The time since mouse down happens to drag starts.</summary>
    /// <param name="time">The drag delay time</param>
    public void SetDragDelayTime(double time) {
                                 Efl.Ui.IDndContainerConcrete.NativeMethods.efl_ui_dnd_container_drag_delay_time_set_ptr.Value.Delegate(this.NativeHandle,time);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This registers a drag for items in a container. Many items can be dragged at a time. During dragging, there are three events emitted: EFL_DND_EVENT_DRAG_POS, EFL_DND_EVENT_DRAG_ACCEPT, EFL_DND_EVENT_DRAG_DONE.</summary>
    /// <param name="data_func">Data and its format</param>
    /// <param name="item_func">Item to determine drag start</param>
    /// <param name="icon_func">Icon used during drag</param>
    /// <param name="icon_list_func">Icons used for animations CHECKING</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void AddDragItem(Efl.Dnd.DragDataGet data_func, Efl.Dnd.ItemGet item_func, Efl.Dnd.DragIconCreate icon_func, Efl.Dnd.DragIconListCreate icon_list_func, uint seat) {
                                                                                         GCHandle data_func_handle = GCHandle.Alloc(data_func);
        GCHandle item_func_handle = GCHandle.Alloc(item_func);
        GCHandle icon_func_handle = GCHandle.Alloc(icon_func);
        GCHandle icon_list_func_handle = GCHandle.Alloc(icon_list_func);
                Efl.Ui.IDndContainerConcrete.NativeMethods.efl_ui_dnd_container_drag_item_add_ptr.Value.Delegate(this.NativeHandle,GCHandle.ToIntPtr(data_func_handle), Efl.Dnd.DragDataGetWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(item_func_handle), Efl.Dnd.ItemGetWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(icon_func_handle), Efl.Dnd.DragIconCreateWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(icon_list_func_handle), Efl.Dnd.DragIconListCreateWrapper.Cb, Efl.Eo.Globals.free_gchandle, seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Remove drag function of items in the container object.</summary>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void DelDragItem(uint seat) {
                                 Efl.Ui.IDndContainerConcrete.NativeMethods.efl_ui_dnd_container_drag_item_del_ptr.Value.Delegate(this.NativeHandle,seat);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <param name="format">Accepted data formats</param>
    /// <param name="item_func">Get item at specific position</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void AddDropItem(Efl.Ui.SelectionFormat format, Efl.Dnd.ItemGet item_func, uint seat) {
                                                                 GCHandle item_func_handle = GCHandle.Alloc(item_func);
                Efl.Ui.IDndContainerConcrete.NativeMethods.efl_ui_dnd_container_drop_item_add_ptr.Value.Delegate(this.NativeHandle,format, GCHandle.ToIntPtr(item_func_handle), Efl.Dnd.ItemGetWrapper.Cb, Efl.Eo.Globals.free_gchandle, seat);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void DelDropItem(uint seat) {
                                 Efl.Ui.IDndContainerConcrete.NativeMethods.efl_ui_dnd_container_drop_item_del_ptr.Value.Delegate(this.NativeHandle,seat);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The time since mouse down happens to drag starts.</summary>
    /// <value>The drag delay time</value>
    public double DragDelayTime {
        get { return GetDragDelayTime(); }
        set { SetDragDelayTime(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IDndContainerConcrete.efl_ui_dnd_container_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_dnd_container_drag_delay_time_get_static_delegate == null)
            {
                efl_ui_dnd_container_drag_delay_time_get_static_delegate = new efl_ui_dnd_container_drag_delay_time_get_delegate(drag_delay_time_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDragDelayTime") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_container_drag_delay_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drag_delay_time_get_static_delegate) });
            }

            if (efl_ui_dnd_container_drag_delay_time_set_static_delegate == null)
            {
                efl_ui_dnd_container_drag_delay_time_set_static_delegate = new efl_ui_dnd_container_drag_delay_time_set_delegate(drag_delay_time_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDragDelayTime") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_container_drag_delay_time_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drag_delay_time_set_static_delegate) });
            }

            if (efl_ui_dnd_container_drag_item_add_static_delegate == null)
            {
                efl_ui_dnd_container_drag_item_add_static_delegate = new efl_ui_dnd_container_drag_item_add_delegate(drag_item_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddDragItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_container_drag_item_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drag_item_add_static_delegate) });
            }

            if (efl_ui_dnd_container_drag_item_del_static_delegate == null)
            {
                efl_ui_dnd_container_drag_item_del_static_delegate = new efl_ui_dnd_container_drag_item_del_delegate(drag_item_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelDragItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_container_drag_item_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drag_item_del_static_delegate) });
            }

            if (efl_ui_dnd_container_drop_item_add_static_delegate == null)
            {
                efl_ui_dnd_container_drop_item_add_static_delegate = new efl_ui_dnd_container_drop_item_add_delegate(drop_item_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddDropItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_container_drop_item_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drop_item_add_static_delegate) });
            }

            if (efl_ui_dnd_container_drop_item_del_static_delegate == null)
            {
                efl_ui_dnd_container_drop_item_del_static_delegate = new efl_ui_dnd_container_drop_item_del_delegate(drop_item_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelDropItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_container_drop_item_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_container_drop_item_del_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IDndContainerConcrete.efl_ui_dnd_container_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_ui_dnd_container_drag_delay_time_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_dnd_container_drag_delay_time_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drag_delay_time_get_api_delegate> efl_ui_dnd_container_drag_delay_time_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drag_delay_time_get_api_delegate>(Module, "efl_ui_dnd_container_drag_delay_time_get");

        private static double drag_delay_time_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_dnd_container_drag_delay_time_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((IDndContainer)ws.Target).GetDragDelayTime();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_ui_dnd_container_drag_delay_time_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_dnd_container_drag_delay_time_get_delegate efl_ui_dnd_container_drag_delay_time_get_static_delegate;

        
        private delegate void efl_ui_dnd_container_drag_delay_time_set_delegate(System.IntPtr obj, System.IntPtr pd,  double time);

        
        public delegate void efl_ui_dnd_container_drag_delay_time_set_api_delegate(System.IntPtr obj,  double time);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drag_delay_time_set_api_delegate> efl_ui_dnd_container_drag_delay_time_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drag_delay_time_set_api_delegate>(Module, "efl_ui_dnd_container_drag_delay_time_set");

        private static void drag_delay_time_set(System.IntPtr obj, System.IntPtr pd, double time)
        {
            Eina.Log.Debug("function efl_ui_dnd_container_drag_delay_time_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IDndContainer)ws.Target).SetDragDelayTime(time);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_dnd_container_drag_delay_time_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), time);
            }
        }

        private static efl_ui_dnd_container_drag_delay_time_set_delegate efl_ui_dnd_container_drag_delay_time_set_static_delegate;

        
        private delegate void efl_ui_dnd_container_drag_item_add_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr data_func_data, Efl.Dnd.DragDataGetInternal data_func, EinaFreeCb data_func_free_cb,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  IntPtr icon_list_func_data, Efl.Dnd.DragIconListCreateInternal icon_list_func, EinaFreeCb icon_list_func_free_cb,  uint seat);

        
        public delegate void efl_ui_dnd_container_drag_item_add_api_delegate(System.IntPtr obj,  IntPtr data_func_data, Efl.Dnd.DragDataGetInternal data_func, EinaFreeCb data_func_free_cb,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  IntPtr icon_list_func_data, Efl.Dnd.DragIconListCreateInternal icon_list_func, EinaFreeCb icon_list_func_free_cb,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drag_item_add_api_delegate> efl_ui_dnd_container_drag_item_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drag_item_add_api_delegate>(Module, "efl_ui_dnd_container_drag_item_add");

        private static void drag_item_add(System.IntPtr obj, System.IntPtr pd, IntPtr data_func_data, Efl.Dnd.DragDataGetInternal data_func, EinaFreeCb data_func_free_cb, IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb, IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb, IntPtr icon_list_func_data, Efl.Dnd.DragIconListCreateInternal icon_list_func, EinaFreeCb icon_list_func_free_cb, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_container_drag_item_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                            Efl.Dnd.DragDataGetWrapper data_func_wrapper = new Efl.Dnd.DragDataGetWrapper(data_func, data_func_data, data_func_free_cb);
            Efl.Dnd.ItemGetWrapper item_func_wrapper = new Efl.Dnd.ItemGetWrapper(item_func, item_func_data, item_func_free_cb);
            Efl.Dnd.DragIconCreateWrapper icon_func_wrapper = new Efl.Dnd.DragIconCreateWrapper(icon_func, icon_func_data, icon_func_free_cb);
            Efl.Dnd.DragIconListCreateWrapper icon_list_func_wrapper = new Efl.Dnd.DragIconListCreateWrapper(icon_list_func, icon_list_func_data, icon_list_func_free_cb);
                    
                try
                {
                    ((IDndContainer)ws.Target).AddDragItem(data_func_wrapper.ManagedCb, item_func_wrapper.ManagedCb, icon_func_wrapper.ManagedCb, icon_list_func_wrapper.ManagedCb, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_ui_dnd_container_drag_item_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), data_func_data, data_func, data_func_free_cb, item_func_data, item_func, item_func_free_cb, icon_func_data, icon_func, icon_func_free_cb, icon_list_func_data, icon_list_func, icon_list_func_free_cb, seat);
            }
        }

        private static efl_ui_dnd_container_drag_item_add_delegate efl_ui_dnd_container_drag_item_add_static_delegate;

        
        private delegate void efl_ui_dnd_container_drag_item_del_delegate(System.IntPtr obj, System.IntPtr pd,  uint seat);

        
        public delegate void efl_ui_dnd_container_drag_item_del_api_delegate(System.IntPtr obj,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drag_item_del_api_delegate> efl_ui_dnd_container_drag_item_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drag_item_del_api_delegate>(Module, "efl_ui_dnd_container_drag_item_del");

        private static void drag_item_del(System.IntPtr obj, System.IntPtr pd, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_container_drag_item_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IDndContainer)ws.Target).DelDragItem(seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_dnd_container_drag_item_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat);
            }
        }

        private static efl_ui_dnd_container_drag_item_del_delegate efl_ui_dnd_container_drag_item_del_static_delegate;

        
        private delegate void efl_ui_dnd_container_drop_item_add_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,  uint seat);

        
        public delegate void efl_ui_dnd_container_drop_item_add_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionFormat format,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drop_item_add_api_delegate> efl_ui_dnd_container_drop_item_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drop_item_add_api_delegate>(Module, "efl_ui_dnd_container_drop_item_add");

        private static void drop_item_add(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionFormat format, IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_container_drop_item_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                    Efl.Dnd.ItemGetWrapper item_func_wrapper = new Efl.Dnd.ItemGetWrapper(item_func, item_func_data, item_func_free_cb);
                    
                try
                {
                    ((IDndContainer)ws.Target).AddDropItem(format, item_func_wrapper.ManagedCb, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_dnd_container_drop_item_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), format, item_func_data, item_func, item_func_free_cb, seat);
            }
        }

        private static efl_ui_dnd_container_drop_item_add_delegate efl_ui_dnd_container_drop_item_add_static_delegate;

        
        private delegate void efl_ui_dnd_container_drop_item_del_delegate(System.IntPtr obj, System.IntPtr pd,  uint seat);

        
        public delegate void efl_ui_dnd_container_drop_item_del_api_delegate(System.IntPtr obj,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drop_item_del_api_delegate> efl_ui_dnd_container_drop_item_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_container_drop_item_del_api_delegate>(Module, "efl_ui_dnd_container_drop_item_del");

        private static void drop_item_del(System.IntPtr obj, System.IntPtr pd, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_container_drop_item_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IDndContainer)ws.Target).DelDropItem(seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_dnd_container_drop_item_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat);
            }
        }

        private static efl_ui_dnd_container_drop_item_del_delegate efl_ui_dnd_container_drop_item_del_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

