#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

namespace Gfx {

/// <summary>UIKit graphics interface</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Gfx.EntityConcrete.NativeMethods]
[UIKit.Wrapper.BindingEntity]
public interface IEntity : 
    UIKit.Wrapper.IWrapper, IDisposable
{
    /// <summary>Retrieves the position of the given canvas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A 2D coordinate in pixel units.</returns>
    UIKit.DataTypes.Position2D GetPosition();

    /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="pos">A 2D coordinate in pixel units.</param>
    void SetPosition(UIKit.DataTypes.Position2D pos);

    /// <summary>Retrieves the (rectangular) size of the given Evas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A 2D size in pixel units.</returns>
    UIKit.DataTypes.Size2D GetSize();

    /// <summary>Changes the size of the given object.
    /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="UIKit.Gfx.IHint"/> instead, when manipulating widgets.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="size">A 2D size in pixel units.</param>
    void SetSize(UIKit.DataTypes.Size2D size);

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The X,Y position and W,H size, in pixels.</returns>
    UIKit.DataTypes.Rect GetGeometry();

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
    void SetGeometry(UIKit.DataTypes.Rect rect);

    /// <summary>Retrieves whether or not the given canvas object is visible.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
    bool GetVisible();

    /// <summary>Shows or hides this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
    void SetVisible(bool v);

    /// <summary>Gets an object&apos;s scaling factor.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The scaling factor.</returns>
    double GetScale();

    /// <summary>Sets the scaling factor of an object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="scale">The scaling factor.<br/>The default value is <c>0.000000</c>.</param>
    void SetScale(double scale);

    /// <summary>Object&apos;s visibility state changed, the event value is the new state.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Gfx.EntityVisibilityChangedEventArgs"/></value>
    event EventHandler<UIKit.Gfx.EntityVisibilityChangedEventArgs> VisibilityChangedEvent;
    /// <summary>Object was moved, its position during the event is the new one.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Gfx.EntityPositionChangedEventArgs"/></value>
    event EventHandler<UIKit.Gfx.EntityPositionChangedEventArgs> PositionChangedEvent;
    /// <summary>Object was resized, its size during the event is the new one.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Gfx.EntitySizeChangedEventArgs"/></value>
    event EventHandler<UIKit.Gfx.EntitySizeChangedEventArgs> SizeChangedEvent;
    /// <summary>The 2D position of a canvas object.
    /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>A 2D coordinate in pixel units.</value>
    UIKit.DataTypes.Position2D Position {
        get;
        set;
    }

    /// <summary>The 2D size of a canvas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>A 2D size in pixel units.</value>
    UIKit.DataTypes.Size2D Size {
        get;
        set;
    }

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The X,Y position and W,H size, in pixels.</value>
    UIKit.DataTypes.Rect Geometry {
        get;
        set;
    }

    /// <summary>The visibility of a canvas object.
    /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="UIKit.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
    /// 
    /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
    bool Visible {
        get;
        set;
    }

    /// <summary>The scaling factor of an object.
    /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, then the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
    /// 
    /// Warning: In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The scaling factor.</value>
    double Scale {
        get;
        set;
    }

}

/// <summary>Event argument wrapper for event <see cref="UIKit.Gfx.IEntity.VisibilityChangedEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class EntityVisibilityChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Object&apos;s visibility state changed, the event value is the new state.</value>
    public bool arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Gfx.IEntity.PositionChangedEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class EntityPositionChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Object was moved, its position during the event is the new one.</value>
    public UIKit.DataTypes.Position2D arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Gfx.IEntity.SizeChangedEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class EntitySizeChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Object was resized, its size during the event is the new one.</value>
    public UIKit.DataTypes.Size2D arg { get; set; }
}

/// <summary>UIKit graphics interface</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class EntityConcrete :
    UIKit.Wrapper.ObjectWrapper
    , IEntity
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(EntityConcrete))
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
    private EntityConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_entity_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IEntity"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private EntityConcrete(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Object&apos;s visibility state changed, the event value is the new state.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Gfx.EntityVisibilityChangedEventArgs"/></value>
    public event EventHandler<UIKit.Gfx.EntityVisibilityChangedEventArgs> VisibilityChangedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Gfx.EntityVisibilityChangedEventArgs args = new UIKit.Gfx.EntityVisibilityChangedEventArgs();
                        args.arg = Marshal.ReadByte(evt.Info) != 0;
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

            string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
            AddNativeEventHandler(UIKit.Libs.UIKit, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
            RemoveNativeEventHandler(UIKit.Libs.UIKit, key, value);
        }
    }

    /// <summary>Method to raise event VisibilityChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnVisibilityChangedEvent(UIKit.Gfx.EntityVisibilityChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.UIKit, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = UIKit.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg ? (byte) 1 : (byte) 0);
        try
        {
            UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }

    /// <summary>Object was moved, its position during the event is the new one.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Gfx.EntityPositionChangedEventArgs"/></value>
    public event EventHandler<UIKit.Gfx.EntityPositionChangedEventArgs> PositionChangedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Gfx.EntityPositionChangedEventArgs args = new UIKit.Gfx.EntityPositionChangedEventArgs();
                        args.arg =  evt.Info;
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

            string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
            AddNativeEventHandler(UIKit.Libs.UIKit, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
            RemoveNativeEventHandler(UIKit.Libs.UIKit, key, value);
        }
    }

    /// <summary>Method to raise event PositionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPositionChangedEvent(UIKit.Gfx.EntityPositionChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.UIKit, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }

    /// <summary>Object was resized, its size during the event is the new one.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Gfx.EntitySizeChangedEventArgs"/></value>
    public event EventHandler<UIKit.Gfx.EntitySizeChangedEventArgs> SizeChangedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Gfx.EntitySizeChangedEventArgs args = new UIKit.Gfx.EntitySizeChangedEventArgs();
                        args.arg =  evt.Info;
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

            string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
            AddNativeEventHandler(UIKit.Libs.UIKit, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
            RemoveNativeEventHandler(UIKit.Libs.UIKit, key, value);
        }
    }

    /// <summary>Method to raise event SizeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSizeChangedEvent(UIKit.Gfx.EntitySizeChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.UIKit, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }


#pragma warning disable CS0628
    /// <summary>Retrieves the position of the given canvas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A 2D coordinate in pixel units.</returns>
    public UIKit.DataTypes.Position2D GetPosition() {
        var _ret_var = UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_position_get_ptr.Value.Delegate(this.NativeHandle);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="pos">A 2D coordinate in pixel units.</param>
    public void SetPosition(UIKit.DataTypes.Position2D pos) {
        UIKit.DataTypes.Position2D.NativeStruct _in_pos = pos;
UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_position_set_ptr.Value.Delegate(this.NativeHandle,_in_pos);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Retrieves the (rectangular) size of the given Evas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A 2D size in pixel units.</returns>
    public UIKit.DataTypes.Size2D GetSize() {
        var _ret_var = UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_size_get_ptr.Value.Delegate(this.NativeHandle);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Changes the size of the given object.
    /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="UIKit.Gfx.IHint"/> instead, when manipulating widgets.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="size">A 2D size in pixel units.</param>
    public void SetSize(UIKit.DataTypes.Size2D size) {
        UIKit.DataTypes.Size2D.NativeStruct _in_size = size;
UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_size_set_ptr.Value.Delegate(this.NativeHandle,_in_size);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The X,Y position and W,H size, in pixels.</returns>
    public UIKit.DataTypes.Rect GetGeometry() {
        var _ret_var = UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_geometry_get_ptr.Value.Delegate(this.NativeHandle);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
    public void SetGeometry(UIKit.DataTypes.Rect rect) {
        UIKit.DataTypes.Rect.NativeStruct _in_rect = rect;
UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_geometry_set_ptr.Value.Delegate(this.NativeHandle,_in_rect);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Retrieves whether or not the given canvas object is visible.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
    public bool GetVisible() {
        var _ret_var = UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_visible_get_ptr.Value.Delegate(this.NativeHandle);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Shows or hides this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
    public void SetVisible(bool v) {
        UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_visible_set_ptr.Value.Delegate(this.NativeHandle,v);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Gets an object&apos;s scaling factor.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The scaling factor.</returns>
    public double GetScale() {
        var _ret_var = UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_scale_get_ptr.Value.Delegate(this.NativeHandle);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sets the scaling factor of an object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="scale">The scaling factor.<br/>The default value is <c>0.000000</c>.</param>
    public void SetScale(double scale) {
        UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_scale_set_ptr.Value.Delegate(this.NativeHandle,scale);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The 2D position of a canvas object.
    /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>A 2D coordinate in pixel units.</value>
    public UIKit.DataTypes.Position2D Position {
        get { return GetPosition(); }
        set { SetPosition(value); }
    }

    /// <summary>The 2D size of a canvas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>A 2D size in pixel units.</value>
    public UIKit.DataTypes.Size2D Size {
        get { return GetSize(); }
        set { SetSize(value); }
    }

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The X,Y position and W,H size, in pixels.</value>
    public UIKit.DataTypes.Rect Geometry {
        get { return GetGeometry(); }
        set { SetGeometry(value); }
    }

    /// <summary>The visibility of a canvas object.
    /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="UIKit.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
    /// 
    /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
    public bool Visible {
        get { return GetVisible(); }
        set { SetVisible(value); }
    }

    /// <summary>The scaling factor of an object.
    /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, then the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
    /// 
    /// Warning: In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The scaling factor.</value>
    public double Scale {
        get { return GetScale(); }
        set { SetScale(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetUIKitClassStatic()
    {
        return UIKit.Gfx.EntityConcrete.efl_gfx_entity_interface_get();
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

            if (efl_gfx_entity_position_get_static_delegate == null)
            {
                efl_gfx_entity_position_get_static_delegate = new efl_gfx_entity_position_get_delegate(position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPosition") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_get_static_delegate) });
            }

            if (efl_gfx_entity_position_set_static_delegate == null)
            {
                efl_gfx_entity_position_set_static_delegate = new efl_gfx_entity_position_set_delegate(position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPosition") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_set_static_delegate) });
            }

            if (efl_gfx_entity_size_get_static_delegate == null)
            {
                efl_gfx_entity_size_get_static_delegate = new efl_gfx_entity_size_get_delegate(size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSize") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_get_static_delegate) });
            }

            if (efl_gfx_entity_size_set_static_delegate == null)
            {
                efl_gfx_entity_size_set_static_delegate = new efl_gfx_entity_size_set_delegate(size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSize") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_set_static_delegate) });
            }

            if (efl_gfx_entity_geometry_get_static_delegate == null)
            {
                efl_gfx_entity_geometry_get_static_delegate = new efl_gfx_entity_geometry_get_delegate(geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGeometry") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_get_static_delegate) });
            }

            if (efl_gfx_entity_geometry_set_static_delegate == null)
            {
                efl_gfx_entity_geometry_set_static_delegate = new efl_gfx_entity_geometry_set_delegate(geometry_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGeometry") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_geometry_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_set_static_delegate) });
            }

            if (efl_gfx_entity_visible_get_static_delegate == null)
            {
                efl_gfx_entity_visible_get_static_delegate = new efl_gfx_entity_visible_get_delegate(visible_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetVisible") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_get_static_delegate) });
            }

            if (efl_gfx_entity_visible_set_static_delegate == null)
            {
                efl_gfx_entity_visible_set_static_delegate = new efl_gfx_entity_visible_set_delegate(visible_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetVisible") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_set_static_delegate) });
            }

            if (efl_gfx_entity_scale_get_static_delegate == null)
            {
                efl_gfx_entity_scale_get_static_delegate = new efl_gfx_entity_scale_get_delegate(scale_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScale") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_get_static_delegate) });
            }

            if (efl_gfx_entity_scale_set_static_delegate == null)
            {
                efl_gfx_entity_scale_set_static_delegate = new efl_gfx_entity_scale_set_delegate(scale_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScale") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_set_static_delegate) });
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
            return UIKit.Gfx.EntityConcrete.efl_gfx_entity_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate UIKit.DataTypes.Position2D.NativeStruct efl_gfx_entity_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.DataTypes.Position2D.NativeStruct efl_gfx_entity_position_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_position_get_api_delegate> efl_gfx_entity_position_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_position_get_api_delegate>(Module, "efl_gfx_entity_position_get");

        private static UIKit.DataTypes.Position2D.NativeStruct position_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_entity_position_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Position2D _ret_var = default(UIKit.DataTypes.Position2D);
                try
                {
                    _ret_var = ((IEntity)ws.Target).GetPosition();
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
                return efl_gfx_entity_position_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_position_get_delegate efl_gfx_entity_position_get_static_delegate;

        
        private delegate void efl_gfx_entity_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.DataTypes.Position2D.NativeStruct pos);

        
        public delegate void efl_gfx_entity_position_set_api_delegate(System.IntPtr obj,  UIKit.DataTypes.Position2D.NativeStruct pos);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_position_set_api_delegate> efl_gfx_entity_position_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_position_set_api_delegate>(Module, "efl_gfx_entity_position_set");

        private static void position_set(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.Position2D.NativeStruct pos)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_entity_position_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Position2D _in_pos = pos;

                try
                {
                    ((IEntity)ws.Target).SetPosition(_in_pos);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_entity_position_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_gfx_entity_position_set_delegate efl_gfx_entity_position_set_static_delegate;

        
        private delegate UIKit.DataTypes.Size2D.NativeStruct efl_gfx_entity_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.DataTypes.Size2D.NativeStruct efl_gfx_entity_size_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_size_get_api_delegate> efl_gfx_entity_size_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_size_get_api_delegate>(Module, "efl_gfx_entity_size_get");

        private static UIKit.DataTypes.Size2D.NativeStruct size_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_entity_size_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Size2D _ret_var = default(UIKit.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IEntity)ws.Target).GetSize();
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
                return efl_gfx_entity_size_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_size_get_delegate efl_gfx_entity_size_get_static_delegate;

        
        private delegate void efl_gfx_entity_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.DataTypes.Size2D.NativeStruct size);

        
        public delegate void efl_gfx_entity_size_set_api_delegate(System.IntPtr obj,  UIKit.DataTypes.Size2D.NativeStruct size);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_size_set_api_delegate> efl_gfx_entity_size_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_size_set_api_delegate>(Module, "efl_gfx_entity_size_set");

        private static void size_set(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.Size2D.NativeStruct size)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_entity_size_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Size2D _in_size = size;

                try
                {
                    ((IEntity)ws.Target).SetSize(_in_size);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_entity_size_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_gfx_entity_size_set_delegate efl_gfx_entity_size_set_static_delegate;

        
        private delegate UIKit.DataTypes.Rect.NativeStruct efl_gfx_entity_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.DataTypes.Rect.NativeStruct efl_gfx_entity_geometry_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate> efl_gfx_entity_geometry_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate>(Module, "efl_gfx_entity_geometry_get");

        private static UIKit.DataTypes.Rect.NativeStruct geometry_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_entity_geometry_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Rect _ret_var = default(UIKit.DataTypes.Rect);
                try
                {
                    _ret_var = ((IEntity)ws.Target).GetGeometry();
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
                return efl_gfx_entity_geometry_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_geometry_get_delegate efl_gfx_entity_geometry_get_static_delegate;

        
        private delegate void efl_gfx_entity_geometry_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.DataTypes.Rect.NativeStruct rect);

        
        public delegate void efl_gfx_entity_geometry_set_api_delegate(System.IntPtr obj,  UIKit.DataTypes.Rect.NativeStruct rect);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate> efl_gfx_entity_geometry_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate>(Module, "efl_gfx_entity_geometry_set");

        private static void geometry_set(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.Rect.NativeStruct rect)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_entity_geometry_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Rect _in_rect = rect;

                try
                {
                    ((IEntity)ws.Target).SetGeometry(_in_rect);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_entity_geometry_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), rect);
            }
        }

        private static efl_gfx_entity_geometry_set_delegate efl_gfx_entity_geometry_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_entity_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_entity_visible_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate> efl_gfx_entity_visible_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate>(Module, "efl_gfx_entity_visible_get");

        private static bool visible_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_entity_visible_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IEntity)ws.Target).GetVisible();
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
                return efl_gfx_entity_visible_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_visible_get_delegate efl_gfx_entity_visible_get_static_delegate;

        
        private delegate void efl_gfx_entity_visible_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool v);

        
        public delegate void efl_gfx_entity_visible_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool v);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate> efl_gfx_entity_visible_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate>(Module, "efl_gfx_entity_visible_set");

        private static void visible_set(System.IntPtr obj, System.IntPtr pd, bool v)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_entity_visible_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IEntity)ws.Target).SetVisible(v);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_entity_visible_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), v);
            }
        }

        private static efl_gfx_entity_visible_set_delegate efl_gfx_entity_visible_set_static_delegate;

        
        private delegate double efl_gfx_entity_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gfx_entity_scale_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate> efl_gfx_entity_scale_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate>(Module, "efl_gfx_entity_scale_get");

        private static double scale_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_entity_scale_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IEntity)ws.Target).GetScale();
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
                return efl_gfx_entity_scale_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_scale_get_delegate efl_gfx_entity_scale_get_static_delegate;

        
        private delegate void efl_gfx_entity_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,  double scale);

        
        public delegate void efl_gfx_entity_scale_set_api_delegate(System.IntPtr obj,  double scale);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate> efl_gfx_entity_scale_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate>(Module, "efl_gfx_entity_scale_set");

        private static void scale_set(System.IntPtr obj, System.IntPtr pd, double scale)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_entity_scale_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IEntity)ws.Target).SetScale(scale);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_entity_scale_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), scale);
            }
        }

        private static efl_gfx_entity_scale_set_delegate efl_gfx_entity_scale_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class UIKit_GfxEntityConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
