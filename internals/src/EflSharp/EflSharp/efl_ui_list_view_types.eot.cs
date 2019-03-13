#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
[StructLayout(LayoutKind.Sequential)]
public struct ListViewLayoutItem
{
   /// <summary></summary>
   public Efl.Ui.Layout Layout;
   /// <summary></summary>
   public  Eina.Future Layout_request;
   /// <summary></summary>
   public Efl.Model Children;
   /// <summary></summary>
   public  int Index_offset;
   /// <summary></summary>
   public  System.IntPtr Tree_node;
   /// <summary></summary>
   public Eina.Size2D Min;
   /// <summary></summary>
   public Eina.Size2D Size;
   /// <summary></summary>
   public Eina.Position2D Pos;
   ///<summary>Constructor for ListViewLayoutItem.</summary>
   public ListViewLayoutItem(
      Efl.Ui.Layout Layout=default(Efl.Ui.Layout),
       Eina.Future Layout_request=default( Eina.Future),
      Efl.Model Children=default(Efl.Model),
       int Index_offset=default( int),
       System.IntPtr Tree_node=default( System.IntPtr),
      Eina.Size2D Min=default(Eina.Size2D),
      Eina.Size2D Size=default(Eina.Size2D),
      Eina.Position2D Pos=default(Eina.Position2D)   )
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
public static implicit operator ListViewLayoutItem(IntPtr ptr)
   {
      var tmp = (ListViewLayoutItem_StructInternal)Marshal.PtrToStructure(ptr, typeof(ListViewLayoutItem_StructInternal));
      return ListViewLayoutItem_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct ListViewLayoutItem.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ListViewLayoutItem_StructInternal
{
///<summary>Internal wrapper for field Layout</summary>
public System.IntPtr Layout;
   [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
   public  Eina.Future Layout_request;
///<summary>Internal wrapper for field Children</summary>
public System.IntPtr Children;
   
   public  int Index_offset;
   
   public  System.IntPtr Tree_node;
   
   public Eina.Size2D_StructInternal Min;
   
   public Eina.Size2D_StructInternal Size;
   
   public Eina.Position2D_StructInternal Pos;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator ListViewLayoutItem(ListViewLayoutItem_StructInternal struct_)
   {
      return ListViewLayoutItem_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator ListViewLayoutItem_StructInternal(ListViewLayoutItem struct_)
   {
      return ListViewLayoutItem_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct ListViewLayoutItem</summary>
public static class ListViewLayoutItem_StructConversion
{
   internal static ListViewLayoutItem_StructInternal ToInternal(ListViewLayoutItem _external_struct)
   {
      var _internal_struct = new ListViewLayoutItem_StructInternal();

      _internal_struct.Layout = _external_struct.Layout.NativeHandle;
      _internal_struct.Layout_request = _external_struct.Layout_request;
      _internal_struct.Children = _external_struct.Children.NativeHandle;
      _internal_struct.Index_offset = _external_struct.Index_offset;
      _internal_struct.Tree_node = _external_struct.Tree_node;
      _internal_struct.Min = Eina.Size2D_StructConversion.ToInternal(_external_struct.Min);
      _internal_struct.Size = Eina.Size2D_StructConversion.ToInternal(_external_struct.Size);
      _internal_struct.Pos = Eina.Position2D_StructConversion.ToInternal(_external_struct.Pos);

      return _internal_struct;
   }

   internal static ListViewLayoutItem ToManaged(ListViewLayoutItem_StructInternal _internal_struct)
   {
      var _external_struct = new ListViewLayoutItem();


      _external_struct.Layout = (Efl.Ui.Layout) System.Activator.CreateInstance(typeof(Efl.Ui.Layout), new System.Object[] {_internal_struct.Layout});
      Efl.Eo.Globals.efl_ref(_internal_struct.Layout);

      _external_struct.Layout_request = _internal_struct.Layout_request;

      _external_struct.Children = (Efl.ModelConcrete) System.Activator.CreateInstance(typeof(Efl.ModelConcrete), new System.Object[] {_internal_struct.Children});
      Efl.Eo.Globals.efl_ref(_internal_struct.Children);

      _external_struct.Index_offset = _internal_struct.Index_offset;
      _external_struct.Tree_node = _internal_struct.Tree_node;
      _external_struct.Min = Eina.Size2D_StructConversion.ToManaged(_internal_struct.Min);
      _external_struct.Size = Eina.Size2D_StructConversion.ToManaged(_internal_struct.Size);
      _external_struct.Pos = Eina.Position2D_StructConversion.ToManaged(_internal_struct.Pos);

      return _external_struct;
   }

}
} } 

/// <summary></summary>
[StructLayout(LayoutKind.Sequential)]
public struct EflUiListViewSegArray
{
///<summary>Placeholder field</summary>
public IntPtr field;
public static implicit operator EflUiListViewSegArray(IntPtr ptr)
   {
      var tmp = (EflUiListViewSegArray_StructInternal)Marshal.PtrToStructure(ptr, typeof(EflUiListViewSegArray_StructInternal));
      return EflUiListViewSegArray_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct EflUiListViewSegArray.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct EflUiListViewSegArray_StructInternal
{
internal IntPtr field;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator EflUiListViewSegArray(EflUiListViewSegArray_StructInternal struct_)
   {
      return EflUiListViewSegArray_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator EflUiListViewSegArray_StructInternal(EflUiListViewSegArray struct_)
   {
      return EflUiListViewSegArray_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct EflUiListViewSegArray</summary>
public static class EflUiListViewSegArray_StructConversion
{
   internal static EflUiListViewSegArray_StructInternal ToInternal(EflUiListViewSegArray _external_struct)
   {
      var _internal_struct = new EflUiListViewSegArray_StructInternal();


      return _internal_struct;
   }

   internal static EflUiListViewSegArray ToManaged(EflUiListViewSegArray_StructInternal _internal_struct)
   {
      var _external_struct = new EflUiListViewSegArray();


      return _external_struct;
   }

}

