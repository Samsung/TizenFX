/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.UI.PositionManager {
/// <param name="range">The range of items to fill into @.memory. The length of memory must be bigger or equal to the requested items</param>
/// <param name="memory">The slice to fill the information in, the full slice will be filled if there are enough items.</param>
/// <returns>The returned stats of this function call.</returns>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public delegate CoreUI.UI.PositionManager.ObjectBatchResult ObjectBatchCallback(CoreUI.UI.PositionManager.RequestRange range,  CoreUI.DataTypes.RwSlice memory);
internal delegate CoreUI.UI.PositionManager.ObjectBatchResult ObjectBatchCallbackInternal(IntPtr data,  CoreUI.UI.PositionManager.RequestRange range,   CoreUI.DataTypes.RwSlice memory);
internal class ObjectBatchCallbackWrapper
{

    private ObjectBatchCallbackInternal _cb;
    private IntPtr _cb_data;
    private CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb;

    internal ObjectBatchCallbackWrapper (ObjectBatchCallbackInternal _cb, IntPtr _cb_data, CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~ObjectBatchCallbackWrapper()
    {
        if (this._cb_free_cb != null)
        {
            CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
        }
    }

    internal CoreUI.UI.PositionManager.ObjectBatchResult ManagedCb(CoreUI.UI.PositionManager.RequestRange range,  CoreUI.DataTypes.RwSlice memory)
    {
CoreUI.UI.PositionManager.RequestRange _in_range = range;
var _ret_var = _cb(_cb_data, _in_range, memory);
CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
    }

        internal static CoreUI.UI.PositionManager.ObjectBatchResult Cb(IntPtr cb_data,  CoreUI.UI.PositionManager.RequestRange range,   CoreUI.DataTypes.RwSlice memory)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        ObjectBatchCallback cb = (ObjectBatchCallback)handle.Target;
CoreUI.UI.PositionManager.RequestRange _in_range = range;
CoreUI.UI.PositionManager.ObjectBatchResult _ret_var = default(CoreUI.UI.PositionManager.ObjectBatchResult);        try {
            _ret_var = cb(_in_range, memory);
        } catch (Exception e) {
            CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
            CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
        }
        return _ret_var;    }
}
}

namespace CoreUI.UI.PositionManager {
/// <param name="conf">The configuration for this call.</param>
/// <param name="memory">The slice to fill the information in, the full slice will be filled if there are enough items.</param>
/// <returns>The returned stats of this function call</returns>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public delegate CoreUI.UI.PositionManager.SizeBatchResult SizeBatchCallback(CoreUI.UI.PositionManager.SizeCallConfig conf,  CoreUI.DataTypes.RwSlice memory);
internal delegate CoreUI.UI.PositionManager.SizeBatchResult SizeBatchCallbackInternal(IntPtr data,  CoreUI.UI.PositionManager.SizeCallConfig conf,   CoreUI.DataTypes.RwSlice memory);
internal class SizeBatchCallbackWrapper
{

    private SizeBatchCallbackInternal _cb;
    private IntPtr _cb_data;
    private CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb;

    internal SizeBatchCallbackWrapper (SizeBatchCallbackInternal _cb, IntPtr _cb_data, CoreUI.DataTypes.Callbacks.EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~SizeBatchCallbackWrapper()
    {
        if (this._cb_free_cb != null)
        {
            CoreUI.Wrapper.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
        }
    }

    internal CoreUI.UI.PositionManager.SizeBatchResult ManagedCb(CoreUI.UI.PositionManager.SizeCallConfig conf,  CoreUI.DataTypes.RwSlice memory)
    {
CoreUI.UI.PositionManager.SizeCallConfig _in_conf = conf;
var _ret_var = _cb(_cb_data, _in_conf, memory);
CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
    }

        internal static CoreUI.UI.PositionManager.SizeBatchResult Cb(IntPtr cb_data,  CoreUI.UI.PositionManager.SizeCallConfig conf,   CoreUI.DataTypes.RwSlice memory)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        SizeBatchCallback cb = (SizeBatchCallback)handle.Target;
CoreUI.UI.PositionManager.SizeCallConfig _in_conf = conf;
CoreUI.UI.PositionManager.SizeBatchResult _ret_var = default(CoreUI.UI.PositionManager.SizeBatchResult);        try {
            _ret_var = cb(_in_conf, memory);
        } catch (Exception e) {
            CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
            CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
        }
        return _ret_var;    }
}
}

namespace CoreUI.UI.PositionManager {
    /// <summary>Interface for abstracting the data access of the position managers.
    /// 
    /// The idea here is that a data-provider calls <see cref="CoreUI.UI.PositionManager.IDataAccessV1.SetDataAccess"/> on the position manager object and passes the functions that are defined here. Later, the position manager can call these function callbacks to get sizes or objects. A data-provider should always fill all requested items. If an item is not available <c>null</c> should be inserted. If a size is not available, an as-close-as-possible approximation should be inserted. The Size callback is equipped with a parameter to specify caching requests. This flag can be used to differentiate between two use cases: When the size is being requested to build up a cache over all items, and when the size is being requested to apply it to the object. Since the data-provider might need to do expensive operations to find the exact size, the as-close-as-possible approximation is usually enough when building caches. If real object placement is happening, then real sizes must be requested. If a size changes after it was returned due to batching, this change still should be announced with the <see cref="CoreUI.UI.PositionManager.IEntity.ItemSizeChanged"/> function.
    /// 
    /// The depth of the items is used to express a hierarchical structure on the items themselves. Any given depth might or might not have a <c>depth_leader</c>. A group is ended when there is either a lower depth, or another <c>depth_leader</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.PositionManager.IDataAccessV1NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IDataAccessV1 : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
        /// 
        /// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
        /// 
        /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="CoreUI.UI.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
        /// 
        /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
        /// <param name="canvas">Will use this object to freeze/thaw canvas events.</param>
        /// <param name="obj_access">Function callback for canvas objects, even if the start_id is valid, the returned objects may be <c>NULL</c>.</param>
        /// <param name="size_access">Function callback for the size, returned values are always valid, but might be changed later on.</param>
        /// <param name="size">valid size for start_id, 0 &lt;= i &lt; size</param>
        /// <since_tizen> 6 </since_tizen>
        void SetDataAccess(CoreUI.UI.Win canvas, CoreUI.UI.PositionManager.ObjectBatchCallback obj_access, CoreUI.UI.PositionManager.SizeBatchCallback size_access, int size);

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IDataAccessV1NativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_position_manager_data_access_v1_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_position_manager_data_access_v1_data_access_set_static_delegate == null)
            {
                efl_ui_position_manager_data_access_v1_data_access_set_static_delegate = new efl_ui_position_manager_data_access_v1_data_access_set_delegate(data_access_set);
            }

            if (methods.Contains("SetDataAccess"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_data_access_v1_data_access_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_data_access_v1_data_access_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_ui_position_manager_data_access_v1_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_position_manager_data_access_v1_data_access_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Win canvas,  IntPtr obj_access_data, CoreUI.UI.PositionManager.ObjectBatchCallbackInternal obj_access, CoreUI.DataTypes.Callbacks.EinaFreeCb obj_access_free_cb,  IntPtr size_access_data, CoreUI.UI.PositionManager.SizeBatchCallbackInternal size_access, CoreUI.DataTypes.Callbacks.EinaFreeCb size_access_free_cb,  int size);

        
        internal delegate void efl_ui_position_manager_data_access_v1_data_access_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Win canvas,  IntPtr obj_access_data, CoreUI.UI.PositionManager.ObjectBatchCallbackInternal obj_access, CoreUI.DataTypes.Callbacks.EinaFreeCb obj_access_free_cb,  IntPtr size_access_data, CoreUI.UI.PositionManager.SizeBatchCallbackInternal size_access, CoreUI.DataTypes.Callbacks.EinaFreeCb size_access_free_cb,  int size);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_data_access_v1_data_access_set_api_delegate> efl_ui_position_manager_data_access_v1_data_access_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_data_access_v1_data_access_set_api_delegate>(Module, "efl_ui_position_manager_data_access_v1_data_access_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void data_access_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Win canvas, IntPtr obj_access_data, CoreUI.UI.PositionManager.ObjectBatchCallbackInternal obj_access, CoreUI.DataTypes.Callbacks.EinaFreeCb obj_access_free_cb, IntPtr size_access_data, CoreUI.UI.PositionManager.SizeBatchCallbackInternal size_access, CoreUI.DataTypes.Callbacks.EinaFreeCb size_access_free_cb, int size)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_position_manager_data_access_v1_data_access_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                    CoreUI.UI.PositionManager.ObjectBatchCallbackWrapper obj_access_wrapper = new CoreUI.UI.PositionManager.ObjectBatchCallbackWrapper(obj_access, obj_access_data, obj_access_free_cb);
    CoreUI.UI.PositionManager.SizeBatchCallbackWrapper size_access_wrapper = new CoreUI.UI.PositionManager.SizeBatchCallbackWrapper(size_access, size_access_data, size_access_free_cb);

                try
                {
                    ((IDataAccessV1)ws.Target).SetDataAccess(canvas, obj_access_wrapper.ManagedCb, size_access_wrapper.ManagedCb, size);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_position_manager_data_access_v1_data_access_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), canvas, obj_access_data, obj_access, obj_access_free_cb, size_access_data, size_access, size_access_free_cb, size);
            }
        }

        private static efl_ui_position_manager_data_access_v1_data_access_set_delegate efl_ui_position_manager_data_access_v1_data_access_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI.PositionManager {
    /// <summary>Representing the range of a request.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct RequestRange : IEquatable<RequestRange>
    {
        
        private uint startId;
        
        private uint endId;

        /// <summary>The first item that must be filled into the passed slice.</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint StartId { get => startId; }
        /// <summary>The last item that must be filled into the passed slice.</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint EndId { get => endId; }
        /// <summary>Constructor for RequestRange.
        /// </summary>
        /// <param name="startId">The first item that must be filled into the passed slice.</param>
        /// <param name="endId">The last item that must be filled into the passed slice.</param>
        /// <since_tizen> 6 </since_tizen>
        public RequestRange(
            uint startId = default(uint),
            uint endId = default(uint))
        {
            this.startId = startId;
            this.endId = endId;
        }

        /// <summary>Packs tuple into RequestRange object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator RequestRange((uint startId, uint endId) tuple)
            => new RequestRange(tuple.startId, tuple.endId);

        /// <summary>Unpacks RequestRange into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out uint startId,
            out uint endId
        )
        {
            startId = this.StartId;
            endId = this.EndId;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + StartId.GetHashCode();
            hash = hash * 23 + EndId.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(RequestRange other)
        {
            return StartId == other.StartId && EndId == other.EndId;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is RequestRange) ? Equals((RequestRange)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(RequestRange lhs, RequestRange rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(RequestRange lhs, RequestRange rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator RequestRange(IntPtr ptr)
        {
            return (RequestRange)Marshal.PtrToStructure(ptr, typeof(RequestRange));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static RequestRange FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.UI.PositionManager {
    /// <summary>Struct that is getting filled by the object function callback.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct ObjectBatchEntity : IEquatable<ObjectBatchEntity>
    {
        /// <summary>Internal wrapper for field entity</summary>
        private System.IntPtr entity;
        
        private byte elementDepth;
        /// <summary>Internal wrapper for field depthLeader</summary>
        private System.Byte depthLeader;

        /// <summary>The canvas object.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Entity { get => (CoreUI.Gfx.IEntity) CoreUI.Wrapper.Globals.CreateWrapperFor(entity); }
        /// <summary>The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</summary>
        /// <since_tizen> 6 </since_tizen>
        public byte ElementDepth { get => elementDepth; }
        /// <summary><c>true</c> if this is the leader of a group</summary>
        /// <since_tizen> 6 </since_tizen>
        public bool DepthLeader { get => depthLeader != 0; }
        /// <summary>Constructor for ObjectBatchEntity.
        /// </summary>
        /// <param name="entity">The canvas object.</param>
        /// <param name="elementDepth">The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</param>
        /// <param name="depthLeader"><c>true</c> if this is the leader of a group</param>
        /// <since_tizen> 6 </since_tizen>
        public ObjectBatchEntity(
            CoreUI.Gfx.IEntity entity = default(CoreUI.Gfx.IEntity),
            byte elementDepth = default(byte),
            bool depthLeader = default(bool))
        {
            this.entity = entity?.NativeHandle ?? System.IntPtr.Zero;
            this.elementDepth = elementDepth;
            this.depthLeader = depthLeader ? (byte)1 : (byte)0;
        }

        /// <summary>Packs tuple into ObjectBatchEntity object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator ObjectBatchEntity((CoreUI.Gfx.IEntity entity, byte elementDepth, bool depthLeader) tuple)
            => new ObjectBatchEntity(tuple.entity, tuple.elementDepth, tuple.depthLeader);

        /// <summary>Unpacks ObjectBatchEntity into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out CoreUI.Gfx.IEntity entity,
            out byte elementDepth,
            out bool depthLeader
        )
        {
            entity = this.Entity;
            elementDepth = this.ElementDepth;
            depthLeader = this.DepthLeader;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Entity.GetHashCode();
            hash = hash * 23 + ElementDepth.GetHashCode();
            hash = hash * 23 + DepthLeader.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(ObjectBatchEntity other)
        {
            return Entity == other.Entity && ElementDepth == other.ElementDepth && DepthLeader == other.DepthLeader;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is ObjectBatchEntity) ? Equals((ObjectBatchEntity)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(ObjectBatchEntity lhs, ObjectBatchEntity rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(ObjectBatchEntity lhs, ObjectBatchEntity rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator ObjectBatchEntity(IntPtr ptr)
        {
            return (ObjectBatchEntity)Marshal.PtrToStructure(ptr, typeof(ObjectBatchEntity));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static ObjectBatchEntity FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.UI.PositionManager {
    /// <summary>Struct that is getting filled by the size function callback.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct SizeBatchEntity : IEquatable<SizeBatchEntity>
    {
        
        private CoreUI.DataTypes.Size2D size;
        
        private byte elementDepth;
        /// <summary>Internal wrapper for field depthLeader</summary>
        private System.Byte depthLeader;

        /// <summary>The size of the element.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>A 2D size in pixels.</value>
        public CoreUI.DataTypes.Size2D Size { get => size; }
        /// <summary>The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</summary>
        /// <since_tizen> 6 </since_tizen>
        public byte ElementDepth { get => elementDepth; }
        /// <summary><c>true</c> if this is the leader of a group</summary>
        /// <since_tizen> 6 </since_tizen>
        public bool DepthLeader { get => depthLeader != 0; }
        /// <summary>Constructor for SizeBatchEntity.
        /// </summary>
        /// <param name="size">The size of the element.</param>
        /// <param name="elementDepth">The depth change in this returned entity. Every Element has a depth, if the parent is <c>null</c> the depth is 0. Every step deeper into the hierarchy is exactly one depth deeper. If this depth has been different to the previous item, then this element can be seen as the group leader. The following elements with the same depth are in the same group.</param>
        /// <param name="depthLeader"><c>true</c> if this is the leader of a group</param>
        /// <since_tizen> 6 </since_tizen>
        public SizeBatchEntity(
            CoreUI.DataTypes.Size2D size = default(CoreUI.DataTypes.Size2D),
            byte elementDepth = default(byte),
            bool depthLeader = default(bool))
        {
            this.size = size;
            this.elementDepth = elementDepth;
            this.depthLeader = depthLeader ? (byte)1 : (byte)0;
        }

        /// <summary>Packs tuple into SizeBatchEntity object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator SizeBatchEntity((CoreUI.DataTypes.Size2D size, byte elementDepth, bool depthLeader) tuple)
            => new SizeBatchEntity(tuple.size, tuple.elementDepth, tuple.depthLeader);

        /// <summary>Unpacks SizeBatchEntity into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out CoreUI.DataTypes.Size2D size,
            out byte elementDepth,
            out bool depthLeader
        )
        {
            size = this.Size;
            elementDepth = this.ElementDepth;
            depthLeader = this.DepthLeader;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Size.GetHashCode();
            hash = hash * 23 + ElementDepth.GetHashCode();
            hash = hash * 23 + DepthLeader.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(SizeBatchEntity other)
        {
            return Size == other.Size && ElementDepth == other.ElementDepth && DepthLeader == other.DepthLeader;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is SizeBatchEntity) ? Equals((SizeBatchEntity)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(SizeBatchEntity lhs, SizeBatchEntity rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(SizeBatchEntity lhs, SizeBatchEntity rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator SizeBatchEntity(IntPtr ptr)
        {
            return (SizeBatchEntity)Marshal.PtrToStructure(ptr, typeof(SizeBatchEntity));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static SizeBatchEntity FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.UI.PositionManager {
    /// <summary>Struct returned by the size access callback.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct SizeBatchResult : IEquatable<SizeBatchResult>
    {
        
        private CoreUI.DataTypes.Size2D parentSize;
        
        private byte parentDepth;
        
        private uint filledItems;

        /// <summary>The group size of the group where the first item is part of.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>A 2D size in pixels.</value>
        public CoreUI.DataTypes.Size2D ParentSize { get => parentSize; }
        /// <summary>The depth of the parent</summary>
        /// <since_tizen> 6 </since_tizen>
        public byte ParentDepth { get => parentDepth; }
        /// <summary>The number of items that are filled into the slice.</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint FilledItems { get => filledItems; }
        /// <summary>Constructor for SizeBatchResult.
        /// </summary>
        /// <param name="parentSize">The group size of the group where the first item is part of.</param>
        /// <param name="parentDepth">The depth of the parent</param>
        /// <param name="filledItems">The number of items that are filled into the slice.</param>
        /// <since_tizen> 6 </since_tizen>
        public SizeBatchResult(
            CoreUI.DataTypes.Size2D parentSize = default(CoreUI.DataTypes.Size2D),
            byte parentDepth = default(byte),
            uint filledItems = default(uint))
        {
            this.parentSize = parentSize;
            this.parentDepth = parentDepth;
            this.filledItems = filledItems;
        }

        /// <summary>Packs tuple into SizeBatchResult object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator SizeBatchResult((CoreUI.DataTypes.Size2D parentSize, byte parentDepth, uint filledItems) tuple)
            => new SizeBatchResult(tuple.parentSize, tuple.parentDepth, tuple.filledItems);

        /// <summary>Unpacks SizeBatchResult into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out CoreUI.DataTypes.Size2D parentSize,
            out byte parentDepth,
            out uint filledItems
        )
        {
            parentSize = this.ParentSize;
            parentDepth = this.ParentDepth;
            filledItems = this.FilledItems;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + ParentSize.GetHashCode();
            hash = hash * 23 + ParentDepth.GetHashCode();
            hash = hash * 23 + FilledItems.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(SizeBatchResult other)
        {
            return ParentSize == other.ParentSize && ParentDepth == other.ParentDepth && FilledItems == other.FilledItems;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is SizeBatchResult) ? Equals((SizeBatchResult)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(SizeBatchResult lhs, SizeBatchResult rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(SizeBatchResult lhs, SizeBatchResult rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator SizeBatchResult(IntPtr ptr)
        {
            return (SizeBatchResult)Marshal.PtrToStructure(ptr, typeof(SizeBatchResult));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static SizeBatchResult FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.UI.PositionManager {
    /// <summary>Struct that is returned by the function callbacks.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct SizeCallConfig : IEquatable<SizeCallConfig>
    {
        
        private CoreUI.UI.PositionManager.RequestRange range;
        /// <summary>Internal wrapper for field cacheRequest</summary>
        private System.Byte cacheRequest;

        /// <summary>The range of items to fill into @.memory. The length of memory must be bigger or equal to the requested items</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Representing the range of a request.</value>
        public CoreUI.UI.PositionManager.RequestRange Range { get => range; }
        /// <summary>Indicate if this request is made for caching or displaying. If it&apos;s for caching, the data-provider will fill in approximations, instead of doing heavy lifting from some back-end. If this is not a caching call, the exact size should be requested and delivered at some later point.</summary>
        /// <since_tizen> 6 </since_tizen>
        public bool CacheRequest { get => cacheRequest != 0; }
        /// <summary>Constructor for SizeCallConfig.
        /// </summary>
        /// <param name="range">The range of items to fill into @.memory. The length of memory must be bigger or equal to the requested items</param>
        /// <param name="cacheRequest">Indicate if this request is made for caching or displaying. If it&apos;s for caching, the data-provider will fill in approximations, instead of doing heavy lifting from some back-end. If this is not a caching call, the exact size should be requested and delivered at some later point.</param>
        /// <since_tizen> 6 </since_tizen>
        public SizeCallConfig(
            CoreUI.UI.PositionManager.RequestRange range = default(CoreUI.UI.PositionManager.RequestRange),
            bool cacheRequest = default(bool))
        {
            this.range = range;
            this.cacheRequest = cacheRequest ? (byte)1 : (byte)0;
        }

        /// <summary>Packs tuple into SizeCallConfig object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator SizeCallConfig((CoreUI.UI.PositionManager.RequestRange range, bool cacheRequest) tuple)
            => new SizeCallConfig(tuple.range, tuple.cacheRequest);

        /// <summary>Unpacks SizeCallConfig into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out CoreUI.UI.PositionManager.RequestRange range,
            out bool cacheRequest
        )
        {
            range = this.Range;
            cacheRequest = this.CacheRequest;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Range.GetHashCode();
            hash = hash * 23 + CacheRequest.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(SizeCallConfig other)
        {
            return Range == other.Range && CacheRequest == other.CacheRequest;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is SizeCallConfig) ? Equals((SizeCallConfig)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(SizeCallConfig lhs, SizeCallConfig rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(SizeCallConfig lhs, SizeCallConfig rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator SizeCallConfig(IntPtr ptr)
        {
            return (SizeCallConfig)Marshal.PtrToStructure(ptr, typeof(SizeCallConfig));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static SizeCallConfig FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI.UI.PositionManager {
    /// <summary>Struct returned by the object access callback.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct ObjectBatchResult : IEquatable<ObjectBatchResult>
    {
        /// <summary>Internal wrapper for field group</summary>
        private System.IntPtr group;
        
        private byte parentDepth;
        
        private uint filledItems;

        /// <summary>The group where the first item is part of</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.Item Group { get => (CoreUI.UI.Item) CoreUI.Wrapper.Globals.CreateWrapperFor(group); }
        /// <summary>The depth of the parent</summary>
        /// <since_tizen> 6 </since_tizen>
        public byte ParentDepth { get => parentDepth; }
        /// <summary>The number of items that are filled into the slice</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint FilledItems { get => filledItems; }
        /// <summary>Constructor for ObjectBatchResult.
        /// </summary>
        /// <param name="group">The group where the first item is part of</param>
        /// <param name="parentDepth">The depth of the parent</param>
        /// <param name="filledItems">The number of items that are filled into the slice</param>
        /// <since_tizen> 6 </since_tizen>
        public ObjectBatchResult(
            CoreUI.UI.Item group = default(CoreUI.UI.Item),
            byte parentDepth = default(byte),
            uint filledItems = default(uint))
        {
            this.group = group?.NativeHandle ?? System.IntPtr.Zero;
            this.parentDepth = parentDepth;
            this.filledItems = filledItems;
        }

        /// <summary>Packs tuple into ObjectBatchResult object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator ObjectBatchResult((CoreUI.UI.Item group, byte parentDepth, uint filledItems) tuple)
            => new ObjectBatchResult(tuple.group, tuple.parentDepth, tuple.filledItems);

        /// <summary>Unpacks ObjectBatchResult into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out CoreUI.UI.Item group,
            out byte parentDepth,
            out uint filledItems
        )
        {
            group = this.Group;
            parentDepth = this.ParentDepth;
            filledItems = this.FilledItems;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Group.GetHashCode();
            hash = hash * 23 + ParentDepth.GetHashCode();
            hash = hash * 23 + FilledItems.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(ObjectBatchResult other)
        {
            return Group == other.Group && ParentDepth == other.ParentDepth && FilledItems == other.FilledItems;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is ObjectBatchResult) ? Equals((ObjectBatchResult)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(ObjectBatchResult lhs, ObjectBatchResult rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(ObjectBatchResult lhs, ObjectBatchResult rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator ObjectBatchResult(IntPtr ptr)
        {
            return (ObjectBatchResult)Marshal.PtrToStructure(ptr, typeof(ObjectBatchResult));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static ObjectBatchResult FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

