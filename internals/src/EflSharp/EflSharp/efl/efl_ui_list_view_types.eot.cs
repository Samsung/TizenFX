#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ListViewLayoutItem
{
    public Efl.Ui.Layout Layout;
    public  Eina.Future Layout_request;
    public Efl.IModel Children;
    public int Index_offset;
    public System.IntPtr Tree_node;
    /// <value>A 2D size in pixels.</value>
    public Eina.Size2D Min;
    /// <value>A 2D size in pixels.</value>
    public Eina.Size2D Size;
    /// <value>A 2D location in pixels.</value>
    public Eina.Position2D Pos;
    /// <summary>Constructor for ListViewLayoutItem.</summary>
    /// <param name="Layout"></param>
    /// <param name="Layout_request"></param>
    /// <param name="Children"></param>
    /// <param name="Index_offset"></param>
    /// <param name="Tree_node"></param>
    /// <param name="Min"></param>
    /// <param name="Size"></param>
    /// <param name="Pos"></param>
    public ListViewLayoutItem(
        Efl.Ui.Layout Layout = default(Efl.Ui.Layout),
         Eina.Future Layout_request = default( Eina.Future),
        Efl.IModel Children = default(Efl.IModel),
        int Index_offset = default(int),
        System.IntPtr Tree_node = default(System.IntPtr),
        Eina.Size2D Min = default(Eina.Size2D),
        Eina.Size2D Size = default(Eina.Size2D),
        Eina.Position2D Pos = default(Eina.Position2D)    )
    {
        this.Layout = Layout;
        this.Layout_request = Layout_request;
        this.Children = Children;
        this.Index_offset = Index_offset;
        this.Tree_node = Tree_node;
        this.Min = Min;
        this.Size = Size;
        this.Pos = Pos;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ListViewLayoutItem(IntPtr ptr)
    {
        var tmp = (ListViewLayoutItem.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ListViewLayoutItem.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ListViewLayoutItem.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Layout</summary>
        public System.IntPtr Layout;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public  Eina.Future Layout_request;
        /// <summary>Internal wrapper for field Children</summary>
        public System.IntPtr Children;
        
        public int Index_offset;
        
        public System.IntPtr Tree_node;
        
        public Eina.Size2D.NativeStruct Min;
        
        public Eina.Size2D.NativeStruct Size;
        
        public Eina.Position2D.NativeStruct Pos;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ListViewLayoutItem.NativeStruct(ListViewLayoutItem _external_struct)
        {
            var _internal_struct = new ListViewLayoutItem.NativeStruct();
            _internal_struct.Layout = _external_struct.Layout?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Layout_request = _external_struct.Layout_request;
            _internal_struct.Children = _external_struct.Children?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Index_offset = _external_struct.Index_offset;
            _internal_struct.Tree_node = _external_struct.Tree_node;
            _internal_struct.Min = _external_struct.Min;
            _internal_struct.Size = _external_struct.Size;
            _internal_struct.Pos = _external_struct.Pos;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ListViewLayoutItem(ListViewLayoutItem.NativeStruct _internal_struct)
        {
            var _external_struct = new ListViewLayoutItem();

            _external_struct.Layout = (Efl.Ui.Layout) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Layout);
            _external_struct.Layout_request = _internal_struct.Layout_request;

            _external_struct.Children = (Efl.ModelConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Children);
            _external_struct.Index_offset = _internal_struct.Index_offset;
            _external_struct.Tree_node = _internal_struct.Tree_node;
            _external_struct.Min = _internal_struct.Min;
            _external_struct.Size = _internal_struct.Size;
            _external_struct.Pos = _internal_struct.Pos;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

/// <summary>TBD</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct EflUiListViewSegArray
{
    /// <summary>Placeholder field</summary>
    public IntPtr field;
    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator EflUiListViewSegArray(IntPtr ptr)
    {
        var tmp = (EflUiListViewSegArray.NativeStruct)Marshal.PtrToStructure(ptr, typeof(EflUiListViewSegArray.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct EflUiListViewSegArray.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator EflUiListViewSegArray.NativeStruct(EflUiListViewSegArray _external_struct)
        {
            var _internal_struct = new EflUiListViewSegArray.NativeStruct();
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator EflUiListViewSegArray(EflUiListViewSegArray.NativeStruct _internal_struct)
        {
            var _external_struct = new EflUiListViewSegArray();
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}



