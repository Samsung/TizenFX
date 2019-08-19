#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

namespace Spotlight {

///<summary>Event argument wrapper for event <see cref="Efl.Ui.Spotlight.Manager.PosUpdateEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ManagerPosUpdateEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public double arg { get; set; }
}
/// <summary>Manager object used by <see cref="Efl.Ui.Spotlight.Container"/> to handle rendering and animation of its sub-widgets, and user interaction.
/// For instance, changes to the current sub-widget in the spotlight (<see cref="Efl.Ui.Spotlight.Container.ActiveIndex"/>) can be animated with a transition. This object can also handle user interaction. For example, dragging the sub-widget to one side to get to a different sub-widget (like an smartphone home screen). Such user interactions should end up setting a new <see cref="Efl.Ui.Spotlight.Container.ActiveIndex"/>. During a transition, the evolution of the current position should be exposed by emitting <c>pos_update</c> events.</summary>
[Efl.Ui.Spotlight.Manager.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class Manager : Efl.Object
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Manager))
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
        efl_ui_spotlight_manager_class_get();
    /// <summary>Initializes a new instance of the <see cref="Manager"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Manager(Efl.Object parent= null
            ) : base(efl_ui_spotlight_manager_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Manager(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Manager"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Manager(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class ManagerRealized : Manager
    {
        private ManagerRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Manager"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Manager(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Index of the sub-widget currently being displayed. Fractional values indicate a position in-between sub-widgets. For instance, when transitioning from sub-widget 2 to sub-widget 3, this event should be emitted with monotonically increasing values ranging from 2.0 to 3.0. Animations can perform any movement they want, but the reported <c>pos_update</c> must move in the same direction.</summary>
    public event EventHandler<Efl.Ui.Spotlight.ManagerPosUpdateEvt_Args> PosUpdateEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.Spotlight.ManagerPosUpdateEvt_Args args = new Efl.Ui.Spotlight.ManagerPosUpdateEvt_Args();
                        args.arg = Eina.PrimitiveConversion.PointerToManaged<double>(evt.Info);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_SPOTLIGHT_MANAGER_EVENT_POS_UPDATE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SPOTLIGHT_MANAGER_EVENT_POS_UPDATE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PosUpdateEvt.</summary>
    public void OnPosUpdateEvt(Efl.Ui.Spotlight.ManagerPosUpdateEvt_Args e)
    {
        var key = "_EFL_UI_SPOTLIGHT_MANAGER_EVENT_POS_UPDATE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Will be called whenever the <see cref="Efl.Ui.Spotlight.Container.SpotlightSize"/> changes so the <see cref="Efl.Ui.Spotlight.Manager"/> can update itself.</summary>
    /// <param name="size">The new size of the sub-widgets.</param>
    virtual public void SetSize(Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Ui.Spotlight.Manager.NativeMethods.efl_ui_spotlight_manager_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This flag can be used to disable animations.</summary>
    /// <returns><c>true</c> if you want animations to happen, <c>false</c> otherwise.</returns>
    virtual public bool GetAnimationEnabled() {
         var _ret_var = Efl.Ui.Spotlight.Manager.NativeMethods.efl_ui_spotlight_manager_animation_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This flag can be used to disable animations.</summary>
    /// <param name="enable"><c>true</c> if you want animations to happen, <c>false</c> otherwise.</param>
    virtual public void SetAnimationEnabled(bool enable) {
                                 Efl.Ui.Spotlight.Manager.NativeMethods.efl_ui_spotlight_manager_animation_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This method is called the first time an <see cref="Efl.Ui.Spotlight.Manager"/> is assigned to an <see cref="Efl.Ui.Spotlight.Container"/>, binding them together. The manager can read the current content of the container, subscribe to events, or do any initialization it requires.</summary>
    /// <param name="spotlight">The container to bind the manager to.</param>
    /// <param name="group">The graphical group where the views should be added with <see cref="Efl.Canvas.Group.AddGroupMember"/> and removed with <see cref="Efl.Canvas.Group.GroupMemberRemove"/>.</param>
    virtual public void Bind(Efl.Ui.Spotlight.Container spotlight, Efl.Canvas.Group group) {
                                                         Efl.Ui.Spotlight.Manager.NativeMethods.efl_ui_spotlight_manager_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),spotlight, group);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>A <c>subobj</c> has been added at position <c>index</c> in the bound container.
    /// The manager should check the container&apos;s <see cref="Efl.Ui.Spotlight.Container.ActiveIndex"/> since indices might have shifted due to the insertion of the new object.</summary>
    /// <param name="subobj">The new object that has been added to the container.</param>
    /// <param name="index">The index of the new object in the container&apos;s list.</param>
    virtual public void AddContent(Efl.Gfx.IEntity subobj, int index) {
                                                         Efl.Ui.Spotlight.Manager.NativeMethods.efl_ui_spotlight_manager_content_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, index);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The <c>subobj</c> at position <c>index</c> in the bound container has been removed.
    /// The manager should check the container&apos;s <see cref="Efl.Ui.Spotlight.Container.ActiveIndex"/> since indices might have shifted due to the removal of the object.</summary>
    /// <param name="subobj">The object being removed from the container.</param>
    /// <param name="index">The index this object had in the container&apos;s list.</param>
    virtual public void DelContent(Efl.Gfx.IEntity subobj, int index) {
                                                         Efl.Ui.Spotlight.Manager.NativeMethods.efl_ui_spotlight_manager_content_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, index);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Switch from one sub-widget to another. If there was no previous sub-widget, <c>from</c> might be -1. This function should display an animation if the <see cref="Efl.Ui.Spotlight.Manager"/> supports them.</summary>
    /// <param name="from">Index of the starting sub-widget in the container&apos;s list. Might be -1 if unknown.</param>
    /// <param name="to">Index of the target sub-widget in the container&apos;s list.</param>
    virtual public void SwitchTo(int from, int to) {
                                                         Efl.Ui.Spotlight.Manager.NativeMethods.efl_ui_spotlight_manager_switch_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),from, to);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Will be called whenever the <see cref="Efl.Ui.Spotlight.Container.SpotlightSize"/> changes so the <see cref="Efl.Ui.Spotlight.Manager"/> can update itself.</summary>
    /// <value>The new size of the sub-widgets.</value>
    public Eina.Size2D Size {
        set { SetSize(value); }
    }
    /// <summary>This flag can be used to disable animations.</summary>
    /// <value><c>true</c> if you want animations to happen, <c>false</c> otherwise.</value>
    public bool AnimationEnabled {
        get { return GetAnimationEnabled(); }
        set { SetAnimationEnabled(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Spotlight.Manager.efl_ui_spotlight_manager_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_spotlight_manager_size_set_static_delegate == null)
            {
                efl_ui_spotlight_manager_size_set_static_delegate = new efl_ui_spotlight_manager_size_set_delegate(size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_manager_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_manager_size_set_static_delegate) });
            }

            if (efl_ui_spotlight_manager_animation_enabled_get_static_delegate == null)
            {
                efl_ui_spotlight_manager_animation_enabled_get_static_delegate = new efl_ui_spotlight_manager_animation_enabled_get_delegate(animation_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAnimationEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_manager_animation_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_manager_animation_enabled_get_static_delegate) });
            }

            if (efl_ui_spotlight_manager_animation_enabled_set_static_delegate == null)
            {
                efl_ui_spotlight_manager_animation_enabled_set_static_delegate = new efl_ui_spotlight_manager_animation_enabled_set_delegate(animation_enabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAnimationEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_manager_animation_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_manager_animation_enabled_set_static_delegate) });
            }

            if (efl_ui_spotlight_manager_bind_static_delegate == null)
            {
                efl_ui_spotlight_manager_bind_static_delegate = new efl_ui_spotlight_manager_bind_delegate(bind);
            }

            if (methods.FirstOrDefault(m => m.Name == "Bind") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_manager_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_manager_bind_static_delegate) });
            }

            if (efl_ui_spotlight_manager_content_add_static_delegate == null)
            {
                efl_ui_spotlight_manager_content_add_static_delegate = new efl_ui_spotlight_manager_content_add_delegate(content_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_manager_content_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_manager_content_add_static_delegate) });
            }

            if (efl_ui_spotlight_manager_content_del_static_delegate == null)
            {
                efl_ui_spotlight_manager_content_del_static_delegate = new efl_ui_spotlight_manager_content_del_delegate(content_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_manager_content_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_manager_content_del_static_delegate) });
            }

            if (efl_ui_spotlight_manager_switch_to_static_delegate == null)
            {
                efl_ui_spotlight_manager_switch_to_static_delegate = new efl_ui_spotlight_manager_switch_to_delegate(switch_to);
            }

            if (methods.FirstOrDefault(m => m.Name == "SwitchTo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spotlight_manager_switch_to"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spotlight_manager_switch_to_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Spotlight.Manager.efl_ui_spotlight_manager_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_spotlight_manager_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size);

        
        public delegate void efl_ui_spotlight_manager_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct size);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_size_set_api_delegate> efl_ui_spotlight_manager_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_size_set_api_delegate>(Module, "efl_ui_spotlight_manager_size_set");

        private static void size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct size)
        {
            Eina.Log.Debug("function efl_ui_spotlight_manager_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_size = size;
                            
                try
                {
                    ((Manager)ws.Target).SetSize(_in_size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_spotlight_manager_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_ui_spotlight_manager_size_set_delegate efl_ui_spotlight_manager_size_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_spotlight_manager_animation_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_spotlight_manager_animation_enabled_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_animation_enabled_get_api_delegate> efl_ui_spotlight_manager_animation_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_animation_enabled_get_api_delegate>(Module, "efl_ui_spotlight_manager_animation_enabled_get");

        private static bool animation_enabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_spotlight_manager_animation_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Manager)ws.Target).GetAnimationEnabled();
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
                return efl_ui_spotlight_manager_animation_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_spotlight_manager_animation_enabled_get_delegate efl_ui_spotlight_manager_animation_enabled_get_static_delegate;

        
        private delegate void efl_ui_spotlight_manager_animation_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        public delegate void efl_ui_spotlight_manager_animation_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_animation_enabled_set_api_delegate> efl_ui_spotlight_manager_animation_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_animation_enabled_set_api_delegate>(Module, "efl_ui_spotlight_manager_animation_enabled_set");

        private static void animation_enabled_set(System.IntPtr obj, System.IntPtr pd, bool enable)
        {
            Eina.Log.Debug("function efl_ui_spotlight_manager_animation_enabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Manager)ws.Target).SetAnimationEnabled(enable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_spotlight_manager_animation_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enable);
            }
        }

        private static efl_ui_spotlight_manager_animation_enabled_set_delegate efl_ui_spotlight_manager_animation_enabled_set_static_delegate;

        
        private delegate void efl_ui_spotlight_manager_bind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Spotlight.Container spotlight, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Group group);

        
        public delegate void efl_ui_spotlight_manager_bind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Spotlight.Container spotlight, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Group group);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_bind_api_delegate> efl_ui_spotlight_manager_bind_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_bind_api_delegate>(Module, "efl_ui_spotlight_manager_bind");

        private static void bind(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Spotlight.Container spotlight, Efl.Canvas.Group group)
        {
            Eina.Log.Debug("function efl_ui_spotlight_manager_bind was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Manager)ws.Target).Bind(spotlight, group);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_spotlight_manager_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), spotlight, group);
            }
        }

        private static efl_ui_spotlight_manager_bind_delegate efl_ui_spotlight_manager_bind_static_delegate;

        
        private delegate void efl_ui_spotlight_manager_content_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int index);

        
        public delegate void efl_ui_spotlight_manager_content_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_content_add_api_delegate> efl_ui_spotlight_manager_content_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_content_add_api_delegate>(Module, "efl_ui_spotlight_manager_content_add");

        private static void content_add(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, int index)
        {
            Eina.Log.Debug("function efl_ui_spotlight_manager_content_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Manager)ws.Target).AddContent(subobj, index);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_spotlight_manager_content_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, index);
            }
        }

        private static efl_ui_spotlight_manager_content_add_delegate efl_ui_spotlight_manager_content_add_static_delegate;

        
        private delegate void efl_ui_spotlight_manager_content_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int index);

        
        public delegate void efl_ui_spotlight_manager_content_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_content_del_api_delegate> efl_ui_spotlight_manager_content_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_content_del_api_delegate>(Module, "efl_ui_spotlight_manager_content_del");

        private static void content_del(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, int index)
        {
            Eina.Log.Debug("function efl_ui_spotlight_manager_content_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Manager)ws.Target).DelContent(subobj, index);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_spotlight_manager_content_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, index);
            }
        }

        private static efl_ui_spotlight_manager_content_del_delegate efl_ui_spotlight_manager_content_del_static_delegate;

        
        private delegate void efl_ui_spotlight_manager_switch_to_delegate(System.IntPtr obj, System.IntPtr pd,  int from,  int to);

        
        public delegate void efl_ui_spotlight_manager_switch_to_api_delegate(System.IntPtr obj,  int from,  int to);

        public static Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_switch_to_api_delegate> efl_ui_spotlight_manager_switch_to_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spotlight_manager_switch_to_api_delegate>(Module, "efl_ui_spotlight_manager_switch_to");

        private static void switch_to(System.IntPtr obj, System.IntPtr pd, int from, int to)
        {
            Eina.Log.Debug("function efl_ui_spotlight_manager_switch_to was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Manager)ws.Target).SwitchTo(from, to);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_spotlight_manager_switch_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), from, to);
            }
        }

        private static efl_ui_spotlight_manager_switch_to_delegate efl_ui_spotlight_manager_switch_to_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

