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
namespace CoreUI.UI {
    /// <summary>Interface for factory-pattern object creation.
    /// 
    /// This object represents a Factory in the factory pattern. Objects should be created via the method <span class="text-muted">CoreUI.UI.ViewFactory.CreateWithEvent (object still in beta stage)</span>, which will in turn call the necessary APIs from this interface. Objects created this way should be removed using <see cref="CoreUI.UI.IFactory.Release"/>.
    /// 
    /// It is recommended to not create your own <see cref="CoreUI.UI.IFactory"/> and use event handler as much as possible.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.IFactoryNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IFactory : 
    CoreUI.UI.IFactoryBind,
    CoreUI.UI.IPropertyBind,
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Release a UI object and disconnect from models.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="ui_views">Object to remove.</param>
        void Release(IEnumerable<CoreUI.Gfx.IEntity> ui_views);

        /// <summary>Event emitted when an item is under construction (between the CoreUI.Object.constructor and <see cref="CoreUI.Object.FinalizeAdd"/> call on the item). Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this won&apos;t be called when objects are pulled from the cache.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.FactoryItemConstructingEventArgs"/></value>
        event EventHandler<CoreUI.UI.FactoryItemConstructingEventArgs> ItemConstructing;
        /// <summary>Event emitted when an item has processed <see cref="CoreUI.Object.FinalizeAdd"/>, but before all the factory are done building it. Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this will be called when objects are pulled from the cache.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.FactoryItemBuildingEventArgs"/></value>
        event EventHandler<CoreUI.UI.FactoryItemBuildingEventArgs> ItemBuilding;
        /// <summary>Event emitted when an item has been successfully created by the factory and is about to be used by an <see cref="CoreUI.UI.IView"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.FactoryItemCreatedEventArgs"/></value>
        event EventHandler<CoreUI.UI.FactoryItemCreatedEventArgs> ItemCreated;
        /// <summary>Event emitted when an item is being released by the <see cref="CoreUI.UI.IFactory"/>. It must be assumed that after this call, the object can be recycles to another <see cref="CoreUI.UI.IView"/> and there can be more than one call for the same item.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.FactoryItemReleasingEventArgs"/></value>
        event EventHandler<CoreUI.UI.FactoryItemReleasingEventArgs> ItemReleasing;
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IFactory.ItemConstructing"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class FactoryItemConstructingEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Event emitted when an item is under construction (between the CoreUI.Object.constructor and <see cref="CoreUI.Object.FinalizeAdd"/> call on the item). Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this won&apos;t be called when objects are pulled from the cache.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IFactory.ItemBuilding"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class FactoryItemBuildingEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Event emitted when an item has processed <see cref="CoreUI.Object.FinalizeAdd"/>, but before all the factory are done building it. Note: If the <see cref="CoreUI.UI.IFactory"/> keeps a cache of objects, this will be called when objects are pulled from the cache.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IFactory.ItemCreated"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class FactoryItemCreatedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Event emitted when an item has been successfully created by the factory and is about to be used by an <see cref="CoreUI.UI.IView"/>.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IFactory.ItemReleasing"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class FactoryItemReleasingEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Event emitted when an item is being released by the <see cref="CoreUI.UI.IFactory"/>. It must be assumed that after this call, the object can be recycles to another <see cref="CoreUI.UI.IView"/> and there can be more than one call for the same item.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IFactoryNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_ui_factory_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_factory_release_static_delegate == null)
            {
                efl_ui_factory_release_static_delegate = new efl_ui_factory_release_delegate(release);
            }

            if (methods.Contains("Release"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_factory_release"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_release_static_delegate) });
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
            return efl_ui_factory_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        private delegate  CoreUI.DataTypes.Future efl_ui_factory_create_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr models);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
        internal delegate  CoreUI.DataTypes.Future efl_ui_factory_create_api_delegate(System.IntPtr obj,  System.IntPtr models);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_create_api_delegate> efl_ui_factory_create_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_create_api_delegate>(Module, "efl_ui_factory_create");

        
        private delegate void efl_ui_factory_release_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr ui_views);

        
        internal delegate void efl_ui_factory_release_api_delegate(System.IntPtr obj,  System.IntPtr ui_views);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_release_api_delegate> efl_ui_factory_release_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_factory_release_api_delegate>(Module, "efl_ui_factory_release");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void release(System.IntPtr obj, System.IntPtr pd, System.IntPtr ui_views)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_factory_release was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_ui_views = CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.IEntity>(ui_views);

                try
                {
                    ((IFactory)ws.Target).Release(_in_ui_views);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_factory_release_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), ui_views);
            }
        }

        private static efl_ui_factory_release_delegate efl_ui_factory_release_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
    /// <summary>EFL UI Factory event structure provided when an item was just created.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct FactoryItemCreatedEvent : IEquatable<FactoryItemCreatedEvent>
    {
        /// <summary>Internal wrapper for field model</summary>
        private System.IntPtr model;
        /// <summary>Internal wrapper for field item</summary>
        private System.IntPtr item;

        /// <summary>The model already set on the new item.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.IModel Model { get => (CoreUI.IModel) CoreUI.Wrapper.Globals.CreateWrapperFor(model); }
        /// <summary>The item that was just created.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Item { get => (CoreUI.Gfx.IEntity) CoreUI.Wrapper.Globals.CreateWrapperFor(item); }
        /// <summary>Constructor for FactoryItemCreatedEvent.
        /// </summary>
        /// <param name="model">The model already set on the new item.</param>
        /// <param name="item">The item that was just created.</param>
        /// <since_tizen> 6 </since_tizen>
        public FactoryItemCreatedEvent(
            CoreUI.IModel model = default(CoreUI.IModel),
            CoreUI.Gfx.IEntity item = default(CoreUI.Gfx.IEntity))
        {
            this.model = model?.NativeHandle ?? System.IntPtr.Zero;
            this.item = item?.NativeHandle ?? System.IntPtr.Zero;
        }

        /// <summary>Packs tuple into FactoryItemCreatedEvent object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator FactoryItemCreatedEvent((CoreUI.IModel model, CoreUI.Gfx.IEntity item) tuple)
            => new FactoryItemCreatedEvent(tuple.model, tuple.item);

        /// <summary>Unpacks FactoryItemCreatedEvent into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out CoreUI.IModel model,
            out CoreUI.Gfx.IEntity item
        )
        {
            model = this.Model;
            item = this.Item;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Model.GetHashCode();
            hash = hash * 23 + Item.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(FactoryItemCreatedEvent other)
        {
            return Model == other.Model && Item == other.Item;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is FactoryItemCreatedEvent) ? Equals((FactoryItemCreatedEvent)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(FactoryItemCreatedEvent lhs, FactoryItemCreatedEvent rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(FactoryItemCreatedEvent lhs, FactoryItemCreatedEvent rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator FactoryItemCreatedEvent(IntPtr ptr)
        {
            return (FactoryItemCreatedEvent)Marshal.PtrToStructure(ptr, typeof(FactoryItemCreatedEvent));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static FactoryItemCreatedEvent FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

