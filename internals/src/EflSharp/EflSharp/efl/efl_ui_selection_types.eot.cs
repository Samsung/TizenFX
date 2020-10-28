#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
/// <param name="obj">Object which requested for the selection</param>
/// <param name="seldata">Selection data</param>
/// <returns></returns>
public delegate void SelectionDataReady( Efl.Object obj,  ref Efl.Ui.SelectionData seldata);
public delegate void SelectionDataReadyInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object obj,   ref Efl.Ui.SelectionData.NativeStruct seldata);
internal class SelectionDataReadyWrapper
{

    private SelectionDataReadyInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal SelectionDataReadyWrapper (SelectionDataReadyInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~SelectionDataReadyWrapper()
    {
        if (this._cb_free_cb != null)
            this._cb_free_cb(this._cb_data);
    }

    internal void ManagedCb( Efl.Object obj, ref Efl.Ui.SelectionData seldata)
    {
                Efl.Ui.SelectionData.NativeStruct _in_seldata = seldata;
                                        _cb(_cb_data,  obj,  ref _in_seldata);
        Eina.Error.RaiseIfUnhandledException();
                                seldata = _in_seldata;
            }

        internal static void Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object obj,   ref Efl.Ui.SelectionData.NativeStruct seldata)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        SelectionDataReady cb = (SelectionDataReady)handle.Target;
                Efl.Ui.SelectionData _in_seldata = seldata;
                                            
        try {
            cb( obj,  ref _in_seldata);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                                seldata = _in_seldata;
            }
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Selection type</summary>
public enum SelectionType
{
/// <summary>Primary text selection (highlighted or selected text)</summary>
Primary = 0,
/// <summary>Used when primary selection is in use</summary>
Secondary = 1,
/// <summary>Drag and Drop</summary>
Dnd = 2,
/// <summary>Clipboard selection (ctrl+C)</summary>
Clipboard = 3,
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Selection format</summary>
public enum SelectionFormat
{
/// <summary>For matching every possible atom</summary>
Targets = -1,
/// <summary>Content is from outside of Elementary</summary>
None = 0,
/// <summary>Plain unformatted text: Used for things that don&apos;t want rich markup</summary>
Text = 1,
/// <summary>Edje textblock markup, including inline images</summary>
Markup = 2,
/// <summary>Images</summary>
Image = 4,
/// <summary>Vcards</summary>
Vcard = 8,
/// <summary>Raw HTML-like data (eg. webkit)</summary>
Html = 16,
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Defines the kind of action associated with the drop data</summary>
public enum SelectionAction
{
/// <summary>Action type is unknown</summary>
Unknown = 0,
/// <summary>Copy the data</summary>
Copy = 1,
/// <summary>Move the data</summary>
Move = 2,
/// <summary>Private action type</summary>
Private = 3,
/// <summary>Ask the user what to do</summary>
Ask = 4,
/// <summary>List the data</summary>
List = 5,
/// <summary>Link the data</summary>
Link = 6,
/// <summary>Describe the data</summary>
Description = 7,
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Structure holding the info about selected data</summary>
[StructLayout(LayoutKind.Sequential)]
public struct SelectionData
{
    /// <summary>Coordinates of the drop (DND operations only)</summary>
    public Eina.Position2D Pos;
    /// <summary>Format of the selection</summary>
    public Efl.Ui.SelectionFormat Format;
    /// <summary>Selection data</summary>
    public Eina.Slice Content;
    /// <summary>Action to perform with the data</summary>
    public Efl.Ui.SelectionAction Action;
    /// <summary>Item under the drag position. It is only available for container</summary>
    public Efl.Object Item;
    ///<summary>Constructor for SelectionData.</summary>
    public SelectionData(
        Eina.Position2D Pos=default(Eina.Position2D),
        Efl.Ui.SelectionFormat Format=default(Efl.Ui.SelectionFormat),
        Eina.Slice Content=default(Eina.Slice),
        Efl.Ui.SelectionAction Action=default(Efl.Ui.SelectionAction),
        Efl.Object Item=default(Efl.Object)    )
    {
        this.Pos = Pos;
        this.Format = Format;
        this.Content = Content;
        this.Action = Action;
        this.Item = Item;
    }

    public static implicit operator SelectionData(IntPtr ptr)
    {
        var tmp = (SelectionData.NativeStruct)Marshal.PtrToStructure(ptr, typeof(SelectionData.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct SelectionData.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Eina.Position2D.NativeStruct Pos;
        
        public Efl.Ui.SelectionFormat Format;
        
        public Eina.Slice Content;
        
        public Efl.Ui.SelectionAction Action;
        ///<summary>Internal wrapper for field Item</summary>
        public System.IntPtr Item;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator SelectionData.NativeStruct(SelectionData _external_struct)
        {
            var _internal_struct = new SelectionData.NativeStruct();
            _internal_struct.Pos = _external_struct.Pos;
            _internal_struct.Format = _external_struct.Format;

            _internal_struct.Content.Len = _external_struct.Content.Len;
            _internal_struct.Content.Mem = _external_struct.Content.Mem;
            _internal_struct.Action = _external_struct.Action;
            _internal_struct.Item = _external_struct.Item?.NativeHandle ?? System.IntPtr.Zero;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator SelectionData(SelectionData.NativeStruct _internal_struct)
        {
            var _external_struct = new SelectionData();
            _external_struct.Pos = _internal_struct.Pos;
            _external_struct.Format = _internal_struct.Format;

            _external_struct.Content.Len = _internal_struct.Content.Len;
            _external_struct.Content.Mem = _internal_struct.Content.Mem;
            _external_struct.Action = _internal_struct.Action;

            _external_struct.Item = (Efl.Object) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Item);
            return _external_struct;
        }

    }

}

} } 
namespace Efl { namespace Ui { 
/// <summary></summary>
[StructLayout(LayoutKind.Sequential)]
public struct SelectionChanged
{
    /// <summary>Selection type</summary>
    public Efl.Ui.SelectionType Type;
    /// <summary>The seat on which the selection changed, or NULL for &quot;default&quot;</summary>
    public int Seat;
    /// <summary>The display connection object, NULL under X11</summary>
    public System.IntPtr Display;
    /// <summary>EINA_TRUE if the selection has an owner</summary>
    public bool Exist;
    ///<summary>Constructor for SelectionChanged.</summary>
    public SelectionChanged(
        Efl.Ui.SelectionType Type=default(Efl.Ui.SelectionType),
        int Seat=default(int),
        System.IntPtr Display=default(System.IntPtr),
        bool Exist=default(bool)    )
    {
        this.Type = Type;
        this.Seat = Seat;
        this.Display = Display;
        this.Exist = Exist;
    }

    public static implicit operator SelectionChanged(IntPtr ptr)
    {
        var tmp = (SelectionChanged.NativeStruct)Marshal.PtrToStructure(ptr, typeof(SelectionChanged.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct SelectionChanged.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Efl.Ui.SelectionType Type;
        
        public int Seat;
        
        public System.IntPtr Display;
        ///<summary>Internal wrapper for field Exist</summary>
        public System.Byte Exist;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator SelectionChanged.NativeStruct(SelectionChanged _external_struct)
        {
            var _internal_struct = new SelectionChanged.NativeStruct();
            _internal_struct.Type = _external_struct.Type;
            _internal_struct.Seat = _external_struct.Seat;
            _internal_struct.Display = _external_struct.Display;
            _internal_struct.Exist = _external_struct.Exist ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator SelectionChanged(SelectionChanged.NativeStruct _internal_struct)
        {
            var _external_struct = new SelectionChanged();
            _external_struct.Type = _internal_struct.Type;
            _external_struct.Seat = _internal_struct.Seat;
            _external_struct.Display = _internal_struct.Display;
            _external_struct.Exist = _internal_struct.Exist != 0;
            return _external_struct;
        }

    }

}

} } 
