#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

namespace PositionManager {

/// <param name="range">The range of items to fill into @.memory. The length of memory must be bigger or equal to the requested items</param>
/// <param name="memory">The slice to fill the information in, the full slice will be filled if there are enough items.</param>
/// <returns>The returned stats of this function call.</returns>
[Efl.Eo.BindingEntity]
public delegate Efl.Ui.PositionManager.ObjectBatchResult ObjectBatchCallback(Efl.Ui.PositionManager.RequestRange range,  Eina.RwSlice memory);
public delegate Efl.Ui.PositionManager.ObjectBatchResult.NativeStruct ObjectBatchCallbackInternal(IntPtr data,  Efl.Ui.PositionManager.RequestRange.NativeStruct range,   Eina.RwSlice memory);
internal class ObjectBatchCallbackWrapper : IDisposable
{

    private ObjectBatchCallbackInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal ObjectBatchCallbackWrapper (ObjectBatchCallbackInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~ObjectBatchCallbackWrapper()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._cb_free_cb != null)
        {
            if (disposing)
            {
                this._cb_free_cb(this._cb_data);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
            }
            this._cb_free_cb = null;
            this._cb_data = IntPtr.Zero;
            this._cb = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    internal Efl.Ui.PositionManager.ObjectBatchResult ManagedCb(Efl.Ui.PositionManager.RequestRange range, Eina.RwSlice memory)
    {
        Efl.Ui.PositionManager.RequestRange.NativeStruct _in_range = range;
                                                var _ret_var = _cb(_cb_data, _in_range, memory);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
    }

        internal static Efl.Ui.PositionManager.ObjectBatchResult.NativeStruct Cb(IntPtr cb_data,  Efl.Ui.PositionManager.RequestRange.NativeStruct range,   Eina.RwSlice memory)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        ObjectBatchCallback cb = (ObjectBatchCallback)handle.Target;
        Efl.Ui.PositionManager.RequestRange _in_range = range;
                                                    Efl.Ui.PositionManager.ObjectBatchResult _ret_var = default(Efl.Ui.PositionManager.ObjectBatchResult);
        try {
            _ret_var = cb(_in_range, memory);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                                        return _ret_var;
    }
}
}

}

}

namespace Efl {

namespace Ui {

namespace PositionManager {

/// <param name="conf">The configuration for this call.</param>
/// <param name="memory">The slice to fill the information in, the full slice will be filled if there are enough items.</param>
/// <returns>The returned stats of this function call</returns>
[Efl.Eo.BindingEntity]
public delegate Efl.Ui.PositionManager.SizeBatchResult SizeBatchCallback(Efl.Ui.PositionManager.SizeCallConfig conf,  Eina.RwSlice memory);
public delegate Efl.Ui.PositionManager.SizeBatchResult.NativeStruct SizeBatchCallbackInternal(IntPtr data,  Efl.Ui.PositionManager.SizeCallConfig.NativeStruct conf,   Eina.RwSlice memory);
internal class SizeBatchCallbackWrapper : IDisposable
{

    private SizeBatchCallbackInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal SizeBatchCallbackWrapper (SizeBatchCallbackInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~SizeBatchCallbackWrapper()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._cb_free_cb != null)
        {
            if (disposing)
            {
                this._cb_free_cb(this._cb_data);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
            }
            this._cb_free_cb = null;
            this._cb_data = IntPtr.Zero;
            this._cb = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    internal Efl.Ui.PositionManager.SizeBatchResult ManagedCb(Efl.Ui.PositionManager.SizeCallConfig conf, Eina.RwSlice memory)
    {
        Efl.Ui.PositionManager.SizeCallConfig.NativeStruct _in_conf = conf;
                                                var _ret_var = _cb(_cb_data, _in_conf, memory);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
    }

        internal static Efl.Ui.PositionManager.SizeBatchResult.NativeStruct Cb(IntPtr cb_data,  Efl.Ui.PositionManager.SizeCallConfig.NativeStruct conf,   Eina.RwSlice memory)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        SizeBatchCallback cb = (SizeBatchCallback)handle.Target;
        Efl.Ui.PositionManager.SizeCallConfig _in_conf = conf;
                                                    Efl.Ui.PositionManager.SizeBatchResult _ret_var = default(Efl.Ui.PositionManager.SizeBatchResult);
        try {
            _ret_var = cb(_in_conf, memory);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                                        return _ret_var;
    }
}
}

}

}

namespace Efl {

namespace Ui {

namespace PositionManager {

/// <summary>Interface for abstracting the data access of the position managers.
/// The idea here is that a data-provider calls <see cref="Efl.Ui.PositionManager.IDataAccessV1.SetDataAccess"/> on the position manager object and passes the functions that are defined here. Later, the position manager can call these function callbacks to get sizes or objects. A data-provider should always fill all requested items. If an item is not available <c>null</c> should be inserted. If a size is not available, an as-close-as-possible approximation should be inserted. The Size callback is equipped with a parameter to specify caching requests. This flag can be used to differentiate between two use cases: When the size is being requested to build up a cache over all items, and when the size is being requested to apply it to the object. Since the data-provider might need to do expensive operations to find the exact size, the as-close-as-possible approximation is usually enough when building caches. If real object placement is happening, then real sizes must be requested. If a size changes after it was returned due to batching, this change still should be announced with the <see cref="Efl.Ui.PositionManager.IEntity.ItemSizeChanged"/> function.
/// 
/// The depth of the items is used to express a hierarchical structure on the items themselves. Any given depth might or might not have a <c>depth_leader</c>. A group is ended when there is either a lower depth, or another <c>depth_leader</c>.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.PositionManager.DataAccessV1Concrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IDataAccessV1 : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
/// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
/// 
/// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="Efl.Ui.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
/// 
/// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
/// <param name="obj_access">Function callback for canvas objects, even if the start_id is valid, the returned objects may be <c>NULL</c>.</param>
/// <param name="size_access">Function callback for the size, returned values are always valid, but might be changed later on.</param>
/// <param name="size">valid size for start_id, 0 &lt;= i &lt; size</param>
void SetDataAccess(Efl.Ui.PositionManager.ObjectBatchCallback obj_access, Efl.Ui.PositionManager.SizeBatchCallback size_access, int size);
        /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
    /// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
    /// 
    /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="Efl.Ui.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
    /// 
    /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
    /// <value>Function callback for canvas objects, even if the start_id is valid, the returned objects may be <c>NULL</c>.</value>
    (Efl.Ui.PositionManager.ObjectBatchCallback, Efl.Ui.PositionManager.SizeBatchCallback, int) DataAccess {
        set;
    }
}
/// <summary>Interface for abstracting the data access of the position managers.
/// The idea here is that a data-provider calls <see cref="Efl.Ui.PositionManager.IDataAccessV1.SetDataAccess"/> on the position manager object and passes the functions that are defined here. Later, the position manager can call these function callbacks to get sizes or objects. A data-provider should always fill all requested items. If an item is not available <c>null</c> should be inserted. If a size is not available, an as-close-as-possible approximation should be inserted. The Size callback is equipped with a parameter to specify caching requests. This flag can be used to differentiate between two use cases: When the size is being requested to build up a cache over all items, and when the size is being requested to apply it to the object. Since the data-provider might need to do expensive operations to find the exact size, the as-close-as-possible approximation is usually enough when building caches. If real object placement is happening, then real sizes must be requested. If a size changes after it was returned due to batching, this change still should be announced with the <see cref="Efl.Ui.PositionManager.IEntity.ItemSizeChanged"/> function.
/// 
/// The depth of the items is used to express a hierarchical structure on the items themselves. Any given depth might or might not have a <c>depth_leader</c>. A group is ended when there is either a lower depth, or another <c>depth_leader</c>.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class DataAccessV1Concrete :
    Efl.Eo.EoWrapper
    , IDataAccessV1
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(DataAccessV1Concrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private DataAccessV1Concrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_position_manager_data_access_v1_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IDataAccessV1"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private DataAccessV1Concrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
    /// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
    /// 
    /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="Efl.Ui.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
    /// 
    /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
    /// <param name="obj_access">Function callback for canvas objects, even if the start_id is valid, the returned objects may be <c>NULL</c>.</param>
    /// <param name="size_access">Function callback for the size, returned values are always valid, but might be changed later on.</param>
    /// <param name="size">valid size for start_id, 0 &lt;= i &lt; size</param>
    public void SetDataAccess(Efl.Ui.PositionManager.ObjectBatchCallback obj_access, Efl.Ui.PositionManager.SizeBatchCallback size_access, int size) {
                                                         GCHandle obj_access_handle = GCHandle.Alloc(obj_access);
        GCHandle size_access_handle = GCHandle.Alloc(size_access);
                Efl.Ui.PositionManager.DataAccessV1Concrete.NativeMethods.efl_ui_position_manager_data_access_v1_data_access_set_ptr.Value.Delegate(this.NativeHandle,GCHandle.ToIntPtr(obj_access_handle), Efl.Ui.PositionManager.ObjectBatchCallbackWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(size_access_handle), Efl.Ui.PositionManager.SizeBatchCallbackWrapper.Cb, Efl.Eo.Globals.free_gchandle, size);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
    /// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
    /// 
    /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="Efl.Ui.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
    /// 
    /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
    /// <value>Function callback for canvas objects, even if the start_id is valid, the returned objects may be <c>NULL</c>.</value>
    public (Efl.Ui.PositionManager.ObjectBatchCallback, Efl.Ui.PositionManager.SizeBatchCallback, int) DataAccess {
        set { SetDataAccess( value.Item1,  value.Item2,  value.Item3); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.PositionManager.DataAccessV1Concrete.efl_ui_position_manager_data_access_v1_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_position_manager_data_access_v1_data_access_set_static_delegate == null)
            {
                efl_ui_position_manager_data_access_v1_data_access_set_static_delegate = new efl_ui_position_manager_data_access_v1_data_access_set_delegate(data_access_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDataAccess") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_data_access_v1_data_access_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_data_access_v1_data_access_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.PositionManager.DataAccessV1Concrete.efl_ui_position_manager_data_access_v1_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_position_manager_data_access_v1_data_access_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr obj_access_data, Efl.Ui.PositionManager.ObjectBatchCallbackInternal obj_access, EinaFreeCb obj_access_free_cb,  IntPtr size_access_data, Efl.Ui.PositionManager.SizeBatchCallbackInternal size_access, EinaFreeCb size_access_free_cb,  int size);

        
        public delegate void efl_ui_position_manager_data_access_v1_data_access_set_api_delegate(System.IntPtr obj,  IntPtr obj_access_data, Efl.Ui.PositionManager.ObjectBatchCallbackInternal obj_access, EinaFreeCb obj_access_free_cb,  IntPtr size_access_data, Efl.Ui.PositionManager.SizeBatchCallbackInternal size_access, EinaFreeCb size_access_free_cb,  int size);

        public static Efl.Eo.FunctionWrapper<efl_ui_position_manager_data_access_v1_data_access_set_api_delegate> efl_ui_position_manager_data_access_v1_data_access_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_position_manager_data_access_v1_data_access_set_api_delegate>(Module, "efl_ui_position_manager_data_access_v1_data_access_set");

        private static void data_access_set(System.IntPtr obj, System.IntPtr pd, IntPtr obj_access_data, Efl.Ui.PositionManager.ObjectBatchCallbackInternal obj_access, EinaFreeCb obj_access_free_cb, IntPtr size_access_data, Efl.Ui.PositionManager.SizeBatchCallbackInternal size_access, EinaFreeCb size_access_free_cb, int size)
        {
            Eina.Log.Debug("function efl_ui_position_manager_data_access_v1_data_access_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Efl.Ui.PositionManager.ObjectBatchCallbackWrapper obj_access_wrapper = new Efl.Ui.PositionManager.ObjectBatchCallbackWrapper(obj_access, obj_access_data, obj_access_free_cb);
            Efl.Ui.PositionManager.SizeBatchCallbackWrapper size_access_wrapper = new Efl.Ui.PositionManager.SizeBatchCallbackWrapper(size_access, size_access_data, size_access_free_cb);
                    
                try
                {
                    ((IDataAccessV1)ws.Target).SetDataAccess(obj_access_wrapper.ManagedCb, size_access_wrapper.ManagedCb, size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_position_manager_data_access_v1_data_access_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), obj_access_data, obj_access, obj_access_free_cb, size_access_data, size_access, size_access_free_cb, size);
            }
        }

        private static efl_ui_position_manager_data_access_v1_data_access_set_delegate efl_ui_position_manager_data_access_v1_data_access_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_Position_ManagerDataAccessV1Concrete_ExtensionMethods {
    
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

namespace PositionManager {

/// <summary>Representing the range of a request.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct RequestRange
{
    /// <summary>The first item that must be filled into the passed slice.</summary>
    public uint Start_id;
    /// <summary>The last item that must be filled into the passed slice.</summary>
    public uint End_id;
    /// <summary>Constructor for RequestRange.</summary>
    /// <param name="Start_id">The first item that must be filled into the passed slice.</param>
    /// <param name="End_id">The last item that must be filled into the passed slice.</param>
    public RequestRange(
        uint Start_id = default(uint),
        uint End_id = default(uint)    )
    {
        this.Start_id = Start_id;
        this.End_id = End_id;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator RequestRange(IntPtr ptr)
    {
        var tmp = (RequestRange.NativeStruct)Marshal.PtrToStructure(ptr, typeof(RequestRange.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct RequestRange.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public uint Start_id;
        
        public uint End_id;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator RequestRange.NativeStruct(RequestRange _external_struct)
        {
            var _internal_struct = new RequestRange.NativeStruct();
            _internal_struct.Start_id = _external_struct.Start_id;
            _internal_struct.End_id = _external_struct.End_id;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator RequestRange(RequestRange.NativeStruct _internal_struct)
        {
            var _external_struct = new RequestRange();
            _external_struct.Start_id = _internal_struct.Start_id;
            _external_struct.End_id = _internal_struct.End_id;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

namespace Efl {

namespace Ui {

namespace PositionManager {

/// <summary>Struct that is getting filled by the object function callback.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ObjectBatchEntity
{
    /// <summary>The canvas object.</summary>
    public Efl.Gfx.IEntity Entity;
    /// <summary>The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</summary>
    public byte Element_depth;
    /// <summary><c>true</c> if this is the leader of a group</summary>
    public bool Depth_leader;
    /// <summary>Constructor for ObjectBatchEntity.</summary>
    /// <param name="Entity">The canvas object.</param>
    /// <param name="Element_depth">The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</param>
    /// <param name="Depth_leader"><c>true</c> if this is the leader of a group</param>
    public ObjectBatchEntity(
        Efl.Gfx.IEntity Entity = default(Efl.Gfx.IEntity),
        byte Element_depth = default(byte),
        bool Depth_leader = default(bool)    )
    {
        this.Entity = Entity;
        this.Element_depth = Element_depth;
        this.Depth_leader = Depth_leader;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ObjectBatchEntity(IntPtr ptr)
    {
        var tmp = (ObjectBatchEntity.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ObjectBatchEntity.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ObjectBatchEntity.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Entity</summary>
        public System.IntPtr Entity;
        
        public byte Element_depth;
        /// <summary>Internal wrapper for field Depth_leader</summary>
        public System.Byte Depth_leader;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ObjectBatchEntity.NativeStruct(ObjectBatchEntity _external_struct)
        {
            var _internal_struct = new ObjectBatchEntity.NativeStruct();
            _internal_struct.Entity = _external_struct.Entity?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Element_depth = _external_struct.Element_depth;
            _internal_struct.Depth_leader = _external_struct.Depth_leader ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ObjectBatchEntity(ObjectBatchEntity.NativeStruct _internal_struct)
        {
            var _external_struct = new ObjectBatchEntity();

            _external_struct.Entity = (Efl.Gfx.EntityConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Entity);
            _external_struct.Element_depth = _internal_struct.Element_depth;
            _external_struct.Depth_leader = _internal_struct.Depth_leader != 0;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

namespace Efl {

namespace Ui {

namespace PositionManager {

/// <summary>Struct that is getting filled by the size function callback.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct SizeBatchEntity
{
    /// <summary>The size of the element.</summary>
    /// <value>A 2D size in pixels.</value>
    public Eina.Size2D Size;
    /// <summary>The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</summary>
    public byte Element_depth;
    /// <summary><c>true</c> if this is the leader of a group</summary>
    public bool Depth_leader;
    /// <summary>Constructor for SizeBatchEntity.</summary>
    /// <param name="Size">The size of the element.</param>
    /// <param name="Element_depth">The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</param>
    /// <param name="Depth_leader"><c>true</c> if this is the leader of a group</param>
    public SizeBatchEntity(
        Eina.Size2D Size = default(Eina.Size2D),
        byte Element_depth = default(byte),
        bool Depth_leader = default(bool)    )
    {
        this.Size = Size;
        this.Element_depth = Element_depth;
        this.Depth_leader = Depth_leader;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator SizeBatchEntity(IntPtr ptr)
    {
        var tmp = (SizeBatchEntity.NativeStruct)Marshal.PtrToStructure(ptr, typeof(SizeBatchEntity.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct SizeBatchEntity.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Eina.Size2D.NativeStruct Size;
        
        public byte Element_depth;
        /// <summary>Internal wrapper for field Depth_leader</summary>
        public System.Byte Depth_leader;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator SizeBatchEntity.NativeStruct(SizeBatchEntity _external_struct)
        {
            var _internal_struct = new SizeBatchEntity.NativeStruct();
            _internal_struct.Size = _external_struct.Size;
            _internal_struct.Element_depth = _external_struct.Element_depth;
            _internal_struct.Depth_leader = _external_struct.Depth_leader ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator SizeBatchEntity(SizeBatchEntity.NativeStruct _internal_struct)
        {
            var _external_struct = new SizeBatchEntity();
            _external_struct.Size = _internal_struct.Size;
            _external_struct.Element_depth = _internal_struct.Element_depth;
            _external_struct.Depth_leader = _internal_struct.Depth_leader != 0;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

namespace Efl {

namespace Ui {

namespace PositionManager {

/// <summary>Struct returned by the size access callback.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct SizeBatchResult
{
    /// <summary>The group size of the group where the first item is part of.</summary>
    /// <value>A 2D size in pixels.</value>
    public Eina.Size2D Parent_size;
    /// <summary>The depth of the parent</summary>
    public byte Parent_depth;
    /// <summary>The number of items that are filled into the slice.</summary>
    public uint Filled_items;
    /// <summary>Constructor for SizeBatchResult.</summary>
    /// <param name="Parent_size">The group size of the group where the first item is part of.</param>
    /// <param name="Parent_depth">The depth of the parent</param>
    /// <param name="Filled_items">The number of items that are filled into the slice.</param>
    public SizeBatchResult(
        Eina.Size2D Parent_size = default(Eina.Size2D),
        byte Parent_depth = default(byte),
        uint Filled_items = default(uint)    )
    {
        this.Parent_size = Parent_size;
        this.Parent_depth = Parent_depth;
        this.Filled_items = Filled_items;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator SizeBatchResult(IntPtr ptr)
    {
        var tmp = (SizeBatchResult.NativeStruct)Marshal.PtrToStructure(ptr, typeof(SizeBatchResult.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct SizeBatchResult.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Eina.Size2D.NativeStruct Parent_size;
        
        public byte Parent_depth;
        
        public uint Filled_items;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator SizeBatchResult.NativeStruct(SizeBatchResult _external_struct)
        {
            var _internal_struct = new SizeBatchResult.NativeStruct();
            _internal_struct.Parent_size = _external_struct.Parent_size;
            _internal_struct.Parent_depth = _external_struct.Parent_depth;
            _internal_struct.Filled_items = _external_struct.Filled_items;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator SizeBatchResult(SizeBatchResult.NativeStruct _internal_struct)
        {
            var _external_struct = new SizeBatchResult();
            _external_struct.Parent_size = _internal_struct.Parent_size;
            _external_struct.Parent_depth = _internal_struct.Parent_depth;
            _external_struct.Filled_items = _internal_struct.Filled_items;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

namespace Efl {

namespace Ui {

namespace PositionManager {

/// <summary>Struct that is returned by the function callbacks.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct SizeCallConfig
{
    /// <summary>The range of items to fill into @.memory. The length of memory must be bigger or equal to the requested items</summary>
    /// <value>Representing the range of a request.</value>
    public Efl.Ui.PositionManager.RequestRange Range;
    /// <summary>Indicate if this request is made for caching or displaying. If it&apos;s for caching, the data-provider will fill in approximations, instead of doing heavy lifting from some back-end. If this is not a caching call, the exact size should be requested and delivered at some later point.</summary>
    public bool Cache_request;
    /// <summary>Constructor for SizeCallConfig.</summary>
    /// <param name="Range">The range of items to fill into @.memory. The length of memory must be bigger or equal to the requested items</param>
    /// <param name="Cache_request">Indicate if this request is made for caching or displaying. If it&apos;s for caching, the data-provider will fill in approximations, instead of doing heavy lifting from some back-end. If this is not a caching call, the exact size should be requested and delivered at some later point.</param>
    public SizeCallConfig(
        Efl.Ui.PositionManager.RequestRange Range = default(Efl.Ui.PositionManager.RequestRange),
        bool Cache_request = default(bool)    )
    {
        this.Range = Range;
        this.Cache_request = Cache_request;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator SizeCallConfig(IntPtr ptr)
    {
        var tmp = (SizeCallConfig.NativeStruct)Marshal.PtrToStructure(ptr, typeof(SizeCallConfig.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct SizeCallConfig.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Efl.Ui.PositionManager.RequestRange.NativeStruct Range;
        /// <summary>Internal wrapper for field Cache_request</summary>
        public System.Byte Cache_request;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator SizeCallConfig.NativeStruct(SizeCallConfig _external_struct)
        {
            var _internal_struct = new SizeCallConfig.NativeStruct();
            _internal_struct.Range = _external_struct.Range;
            _internal_struct.Cache_request = _external_struct.Cache_request ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator SizeCallConfig(SizeCallConfig.NativeStruct _internal_struct)
        {
            var _external_struct = new SizeCallConfig();
            _external_struct.Range = _internal_struct.Range;
            _external_struct.Cache_request = _internal_struct.Cache_request != 0;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

namespace Efl {

namespace Ui {

namespace PositionManager {

/// <summary>Struct returned by the object access callback</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ObjectBatchResult
{
    /// <summary>The group where the first item is part of</summary>
    public Efl.Ui.Item Group;
    /// <summary>The depth of the parent</summary>
    public byte Parent_depth;
    /// <summary>The number of items that are filled into the slice</summary>
    public uint Filled_items;
    /// <summary>Constructor for ObjectBatchResult.</summary>
    /// <param name="Group">The group where the first item is part of</param>
    /// <param name="Parent_depth">The depth of the parent</param>
    /// <param name="Filled_items">The number of items that are filled into the slice</param>
    public ObjectBatchResult(
        Efl.Ui.Item Group = default(Efl.Ui.Item),
        byte Parent_depth = default(byte),
        uint Filled_items = default(uint)    )
    {
        this.Group = Group;
        this.Parent_depth = Parent_depth;
        this.Filled_items = Filled_items;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ObjectBatchResult(IntPtr ptr)
    {
        var tmp = (ObjectBatchResult.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ObjectBatchResult.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ObjectBatchResult.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Group</summary>
        public System.IntPtr Group;
        
        public byte Parent_depth;
        
        public uint Filled_items;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ObjectBatchResult.NativeStruct(ObjectBatchResult _external_struct)
        {
            var _internal_struct = new ObjectBatchResult.NativeStruct();
            _internal_struct.Group = _external_struct.Group?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Parent_depth = _external_struct.Parent_depth;
            _internal_struct.Filled_items = _external_struct.Filled_items;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ObjectBatchResult(ObjectBatchResult.NativeStruct _internal_struct)
        {
            var _external_struct = new ObjectBatchResult();

            _external_struct.Group = (Efl.Ui.Item) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Group);
            _external_struct.Parent_depth = _internal_struct.Parent_depth;
            _external_struct.Filled_items = _internal_struct.Filled_items;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

