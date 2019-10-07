#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

/// <summary>Common interface for objects (containers) that can have multiple contents (sub-objects).
/// APIs in this interface deal with containers of multiple sub-objects, not with individual parts.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.ContainerConcrete.NativeMethods]
[UIKit.Wrapper.BindingEntity]
public interface IContainer : 
    UIKit.Wrapper.IWrapper, IDisposable
{
    /// <summary>Begin iterating over this object&apos;s contents.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Iterator on object&apos;s content.</returns>
    UIKit.DataTypes.Iterator<UIKit.Gfx.IEntity> IterateContent();

    /// <summary>Returns the number of contained sub-objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Number of sub-objects.</returns>
    int ContentCount();

    /// <summary>Sent after a new sub-object was added.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.ContainerContentAddedEventArgs"/></value>
    event EventHandler<UIKit.ContainerContentAddedEventArgs> ContentAddedEvent;
    /// <summary>Sent after a sub-object was removed, before unref.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.ContainerContentRemovedEventArgs"/></value>
    event EventHandler<UIKit.ContainerContentRemovedEventArgs> ContentRemovedEvent;
}

/// <summary>Event argument wrapper for event <see cref="UIKit.IContainer.ContentAddedEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class ContainerContentAddedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Sent after a new sub-object was added.</value>
    public UIKit.Gfx.IEntity arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.IContainer.ContentRemovedEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class ContainerContentRemovedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Sent after a sub-object was removed, before unref.</value>
    public UIKit.Gfx.IEntity arg { get; set; }
}

/// <summary>Common interface for objects (containers) that can have multiple contents (sub-objects).
/// APIs in this interface deal with containers of multiple sub-objects, not with individual parts.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ContainerConcrete :
    UIKit.Wrapper.ObjectWrapper
    , IContainer
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ContainerConcrete))
            {
                return GetUIKitClassStatic();
            }
            else
            {
                return UIKit.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private ContainerConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_container_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IContainer"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ContainerConcrete(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Sent after a new sub-object was added.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.ContainerContentAddedEventArgs"/></value>
    public event EventHandler<UIKit.ContainerContentAddedEventArgs> ContentAddedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.ContainerContentAddedEventArgs args = new UIKit.ContainerContentAddedEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Gfx.EntityConcrete);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            AddNativeEventHandler(UIKit.Libs.UIKit, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            RemoveNativeEventHandler(UIKit.Libs.UIKit, key, value);
        }
    }

    /// <summary>Method to raise event ContentAddedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentAddedEvent(UIKit.ContainerContentAddedEventArgs e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.UIKit, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Sent after a sub-object was removed, before unref.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.ContainerContentRemovedEventArgs"/></value>
    public event EventHandler<UIKit.ContainerContentRemovedEventArgs> ContentRemovedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.ContainerContentRemovedEventArgs args = new UIKit.ContainerContentRemovedEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Gfx.EntityConcrete);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            AddNativeEventHandler(UIKit.Libs.UIKit, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            RemoveNativeEventHandler(UIKit.Libs.UIKit, key, value);
        }
    }

    /// <summary>Method to raise event ContentRemovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentRemovedEvent(UIKit.ContainerContentRemovedEventArgs e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.UIKit, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }


#pragma warning disable CS0628
    /// <summary>Begin iterating over this object&apos;s contents.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Iterator on object&apos;s content.</returns>
    public UIKit.DataTypes.Iterator<UIKit.Gfx.IEntity> IterateContent() {
        var _ret_var = UIKit.ContainerConcrete.NativeMethods.efl_content_iterate_ptr.Value.Delegate(this.NativeHandle);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return new UIKit.DataTypes.Iterator<UIKit.Gfx.IEntity>(_ret_var, true);

    }

    /// <summary>Returns the number of contained sub-objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Number of sub-objects.</returns>
    public int ContentCount() {
        var _ret_var = UIKit.ContainerConcrete.NativeMethods.efl_content_count_ptr.Value.Delegate(this.NativeHandle);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

#pragma warning restore CS0628
    private static IntPtr GetUIKitClassStatic()
    {
        return UIKit.ContainerConcrete.efl_container_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : UIKit.Wrapper.ObjectWrapper.NativeMethods
    {
        private static UIKit.Wrapper.NativeModule Module = new UIKit.Wrapper.NativeModule(UIKit.Libs.UIKit);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<UIKit_Op_Description>();
            var methods = UIKit.Wrapper.Globals.GetUserMethods(type);

            if (efl_content_iterate_static_delegate == null)
            {
                efl_content_iterate_static_delegate = new efl_content_iterate_delegate(content_iterate);
            }

            if (methods.FirstOrDefault(m => m.Name == "IterateContent") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_content_iterate_static_delegate) });
            }

            if (efl_content_count_static_delegate == null)
            {
                efl_content_count_static_delegate = new efl_content_count_delegate(content_count);
            }

            if (methods.FirstOrDefault(m => m.Name == "ContentCount") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_count"), func = Marshal.GetFunctionPointerForDelegate(efl_content_count_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((UIKit.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is UIKit.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetUIKitClass()
        {
            return UIKit.ContainerConcrete.efl_container_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate System.IntPtr efl_content_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_content_iterate_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_content_iterate_api_delegate> efl_content_iterate_ptr = new UIKit.Wrapper.FunctionWrapper<efl_content_iterate_api_delegate>(Module, "efl_content_iterate");

        private static System.IntPtr content_iterate(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_content_iterate was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Iterator<UIKit.Gfx.IEntity> _ret_var = default(UIKit.DataTypes.Iterator<UIKit.Gfx.IEntity>);
                try
                {
                    _ret_var = ((IContainer)ws.Target).IterateContent();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                _ret_var.Own = false; return _ret_var.Handle;
            }
            else
            {
                return efl_content_iterate_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_content_iterate_delegate efl_content_iterate_static_delegate;

        
        private delegate int efl_content_count_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_content_count_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_content_count_api_delegate> efl_content_count_ptr = new UIKit.Wrapper.FunctionWrapper<efl_content_count_api_delegate>(Module, "efl_content_count");

        private static int content_count(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_content_count was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IContainer)ws.Target).ContentCount();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_content_count_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_content_count_delegate efl_content_count_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class UIKitContainerConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
