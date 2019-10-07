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

/// <summary>Shared sets of events between <see cref="Efl.Ui.Collection"/> and <see cref="Efl.Ui.CollectionView"/>.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.ItemClickableConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IItemClickable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>A <c>pressed</c> event occurred over an item.</summary>
    /// <value><see cref="Efl.Ui.ItemClickableItemPressedEventArgs"/></value>
    event EventHandler<Efl.Ui.ItemClickableItemPressedEventArgs> ItemPressedEvent;
    /// <summary>An <c>unpressed</c> event occurred over an item.</summary>
    /// <value><see cref="Efl.Ui.ItemClickableItemUnpressedEventArgs"/></value>
    event EventHandler<Efl.Ui.ItemClickableItemUnpressedEventArgs> ItemUnpressedEvent;
    /// <summary>A <c>longpressed</c> event occurred over an item.</summary>
    /// <value><see cref="Efl.Ui.ItemClickableItemLongpressedEventArgs"/></value>
    event EventHandler<Efl.Ui.ItemClickableItemLongpressedEventArgs> ItemLongpressedEvent;
    /// <summary>A <c>clicked</c> event occurred over an item.</summary>
    /// <value><see cref="Efl.Ui.ItemClickableItemClickedEventArgs"/></value>
    event EventHandler<Efl.Ui.ItemClickableItemClickedEventArgs> ItemClickedEvent;
    /// <summary>A <c>clicked,any</c> event occurred over an item.</summary>
    /// <value><see cref="Efl.Ui.ItemClickableItemClickedAnyEventArgs"/></value>
    event EventHandler<Efl.Ui.ItemClickableItemClickedAnyEventArgs> ItemClickedAnyEvent;
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IItemClickable.ItemPressedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ItemClickableItemPressedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>A <c>pressed</c> event occurred over an item.</value>
    public Efl.Ui.ItemClickablePressed arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IItemClickable.ItemUnpressedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ItemClickableItemUnpressedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>An <c>unpressed</c> event occurred over an item.</value>
    public Efl.Ui.ItemClickablePressed arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IItemClickable.ItemLongpressedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ItemClickableItemLongpressedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>A <c>longpressed</c> event occurred over an item.</value>
    public Efl.Ui.ItemClickablePressed arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IItemClickable.ItemClickedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ItemClickableItemClickedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>A <c>clicked</c> event occurred over an item.</value>
    public Efl.Ui.ItemClickableClicked arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IItemClickable.ItemClickedAnyEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ItemClickableItemClickedAnyEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>A <c>clicked,any</c> event occurred over an item.</value>
    public Efl.Ui.ItemClickableClicked arg { get; set; }
}

/// <summary>Shared sets of events between <see cref="Efl.Ui.Collection"/> and <see cref="Efl.Ui.CollectionView"/>.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class ItemClickableConcrete :
    Efl.Eo.EoWrapper
    , IItemClickable
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ItemClickableConcrete))
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
    private ItemClickableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_item_clickable_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IItemClickable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ItemClickableConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>A <c>pressed</c> event occurred over an item.</summary>
    /// <value><see cref="Efl.Ui.ItemClickableItemPressedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ItemClickableItemPressedEventArgs> ItemPressedEvent
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
                        Efl.Ui.ItemClickableItemPressedEventArgs args = new Efl.Ui.ItemClickableItemPressedEventArgs();
                        args.arg =  evt.Info;
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

                string key = "_EFL_UI_EVENT_ITEM_PRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ITEM_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ItemPressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemPressedEvent(Efl.Ui.ItemClickableItemPressedEventArgs e)
    {
        var key = "_EFL_UI_EVENT_ITEM_PRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }

    /// <summary>An <c>unpressed</c> event occurred over an item.</summary>
    /// <value><see cref="Efl.Ui.ItemClickableItemUnpressedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ItemClickableItemUnpressedEventArgs> ItemUnpressedEvent
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
                        Efl.Ui.ItemClickableItemUnpressedEventArgs args = new Efl.Ui.ItemClickableItemUnpressedEventArgs();
                        args.arg =  evt.Info;
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

                string key = "_EFL_UI_EVENT_ITEM_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ITEM_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ItemUnpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemUnpressedEvent(Efl.Ui.ItemClickableItemUnpressedEventArgs e)
    {
        var key = "_EFL_UI_EVENT_ITEM_UNPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }

    /// <summary>A <c>longpressed</c> event occurred over an item.</summary>
    /// <value><see cref="Efl.Ui.ItemClickableItemLongpressedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ItemClickableItemLongpressedEventArgs> ItemLongpressedEvent
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
                        Efl.Ui.ItemClickableItemLongpressedEventArgs args = new Efl.Ui.ItemClickableItemLongpressedEventArgs();
                        args.arg =  evt.Info;
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

                string key = "_EFL_UI_EVENT_ITEM_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ITEM_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ItemLongpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemLongpressedEvent(Efl.Ui.ItemClickableItemLongpressedEventArgs e)
    {
        var key = "_EFL_UI_EVENT_ITEM_LONGPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }

    /// <summary>A <c>clicked</c> event occurred over an item.</summary>
    /// <value><see cref="Efl.Ui.ItemClickableItemClickedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ItemClickableItemClickedEventArgs> ItemClickedEvent
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
                        Efl.Ui.ItemClickableItemClickedEventArgs args = new Efl.Ui.ItemClickableItemClickedEventArgs();
                        args.arg =  evt.Info;
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

                string key = "_EFL_UI_EVENT_ITEM_CLICKED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ITEM_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ItemClickedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemClickedEvent(Efl.Ui.ItemClickableItemClickedEventArgs e)
    {
        var key = "_EFL_UI_EVENT_ITEM_CLICKED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }

    /// <summary>A <c>clicked,any</c> event occurred over an item.</summary>
    /// <value><see cref="Efl.Ui.ItemClickableItemClickedAnyEventArgs"/></value>
    public event EventHandler<Efl.Ui.ItemClickableItemClickedAnyEventArgs> ItemClickedAnyEvent
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
                        Efl.Ui.ItemClickableItemClickedAnyEventArgs args = new Efl.Ui.ItemClickableItemClickedAnyEventArgs();
                        args.arg =  evt.Info;
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

                string key = "_EFL_UI_EVENT_ITEM_CLICKED_ANY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ITEM_CLICKED_ANY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ItemClickedAnyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemClickedAnyEvent(Efl.Ui.ItemClickableItemClickedAnyEventArgs e)
    {
        var key = "_EFL_UI_EVENT_ITEM_CLICKED_ANY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }


#pragma warning disable CS0628
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ItemClickableConcrete.efl_ui_item_clickable_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
            return Efl.Ui.ItemClickableConcrete.efl_ui_item_clickable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiItemClickableConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>A struct that expresses a click in item of container widget.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ItemClickableClicked
{
    /// <summary>The input clicked event data.</summary>
    /// <value>A struct that expresses a click in elementary.</value>
    public Efl.Input.ClickableClicked Clicked;
    /// <summary>The clicked item.</summary>
    public Efl.Ui.Item Item;
    /// <summary>Constructor for ItemClickableClicked.</summary>
    /// <param name="Clicked">The input clicked event data.</param>
    /// <param name="Item">The clicked item.</param>
    public ItemClickableClicked(
        Efl.Input.ClickableClicked Clicked = default(Efl.Input.ClickableClicked),
        Efl.Ui.Item Item = default(Efl.Ui.Item)    )
    {
        this.Clicked = Clicked;
        this.Item = Item;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ItemClickableClicked(IntPtr ptr)
    {
        var tmp = (ItemClickableClicked.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ItemClickableClicked.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ItemClickableClicked.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Efl.Input.ClickableClicked.NativeStruct Clicked;
        /// <summary>Internal wrapper for field Item</summary>
        public System.IntPtr Item;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ItemClickableClicked.NativeStruct(ItemClickableClicked _external_struct)
        {
            var _internal_struct = new ItemClickableClicked.NativeStruct();
            _internal_struct.Clicked = _external_struct.Clicked;
            _internal_struct.Item = _external_struct.Item?.NativeHandle ?? System.IntPtr.Zero;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ItemClickableClicked(ItemClickableClicked.NativeStruct _internal_struct)
        {
            var _external_struct = new ItemClickableClicked();
            _external_struct.Clicked = _internal_struct.Clicked;

            _external_struct.Item = (Efl.Ui.Item) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Item);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}

namespace Efl {

namespace Ui {

/// <summary>A struct that expresses a press or unpress in item of container widget.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ItemClickablePressed
{
    /// <summary>The button which was pressed or unpressed.</summary>
    public int Button;
    /// <summary>The corresponding item.</summary>
    public Efl.Ui.Item Item;
    /// <summary>Constructor for ItemClickablePressed.</summary>
    /// <param name="Button">The button which was pressed or unpressed.</param>
    /// <param name="Item">The corresponding item.</param>
    public ItemClickablePressed(
        int Button = default(int),
        Efl.Ui.Item Item = default(Efl.Ui.Item)    )
    {
        this.Button = Button;
        this.Item = Item;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ItemClickablePressed(IntPtr ptr)
    {
        var tmp = (ItemClickablePressed.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ItemClickablePressed.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ItemClickablePressed.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int Button;
        /// <summary>Internal wrapper for field Item</summary>
        public System.IntPtr Item;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ItemClickablePressed.NativeStruct(ItemClickablePressed _external_struct)
        {
            var _internal_struct = new ItemClickablePressed.NativeStruct();
            _internal_struct.Button = _external_struct.Button;
            _internal_struct.Item = _external_struct.Item?.NativeHandle ?? System.IntPtr.Zero;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ItemClickablePressed(ItemClickablePressed.NativeStruct _internal_struct)
        {
            var _external_struct = new ItemClickablePressed();
            _external_struct.Button = _internal_struct.Button;

            _external_struct.Item = (Efl.Ui.Item) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Item);
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}

