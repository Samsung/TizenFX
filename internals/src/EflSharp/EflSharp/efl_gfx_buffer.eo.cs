#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Common APIs for all objects representing images and 2D pixel buffers.</summary>
[BufferConcreteNativeInherit]
public interface Buffer : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
/// <returns>Size of the buffer in pixels.</returns>
Eina.Size2D GetBufferSize();
   /// <summary>Potentially not implemented, <see cref="Efl.Gfx.Buffer.BufferSize"/> may be read-only.</summary>
/// <param name="sz">Size of the buffer in pixels.</param>
/// <returns></returns>
 void SetBufferSize( Eina.Size2D sz);
   /// <summary>Returns the current encoding of this buffer&apos;s pixels.
/// See <see cref="Efl.Gfx.Colorspace"/> for more information on the supported formats.</summary>
/// <returns>Colorspace</returns>
Efl.Gfx.Colorspace GetColorspace();
   /// <summary>Retrieve whether alpha channel data is used on this object.</summary>
/// <returns>Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</returns>
bool GetAlpha();
   /// <summary>Change alpha channel usage for this object.
/// This function sets a flag on an image object indicating whether or not to use alpha channel data. A value of <c>true</c> makes it use alpha channel data, and <c>false</c> makes it ignore that data. Note that this has nothing to do with an object&apos;s color as manipulated by <see cref="Efl.Gfx.Color.GetColor"/>.</summary>
/// <param name="alpha">Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</param>
/// <returns></returns>
 void SetAlpha( bool alpha);
   /// <summary>Length in bytes of one row of pixels in memory.
/// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
/// 
/// When applicable, this will include the <see cref="Efl.Gfx.Buffer.GetBufferBorders"/> as well as potential extra padding.</summary>
/// <returns>Stride</returns>
 int GetStride();
   /// <summary>Duplicated pixel borders inside this buffer.
/// Internally, EFL may require an image to have its border pixels duplicated, in particular for GL textures. This property exposes the internal duplicated borders to allow calling <see cref="Efl.Gfx.Buffer.BufferMap"/> with the entire pixel data, including those edge pixels.</summary>
/// <param name="l">Left border pixels, usually 0 or 1</param>
/// <param name="r">Right border pixels, usually 0 or 1</param>
/// <param name="t">Top border pixels, usually 0 or 1</param>
/// <param name="b">Bottom border pixels, usually 0 or 1</param>
/// <returns></returns>
 void GetBufferBorders( out  uint l,  out  uint r,  out  uint t,  out  uint b);
   /// <summary>Mark a sub-region of the given image object to be redrawn.
/// This function schedules a particular rectangular region of an image object to be updated (redrawn) at the next rendering cycle.</summary>
/// <param name="region">The updated region.</param>
/// <returns></returns>
 void AddBufferUpdate( ref Eina.Rect region);
   /// <summary>Map a region of this buffer for read or write access by the CPU.
/// Fetches data from the GPU if needed. This operation may be slow if cpu_readable_fast or cpu_writeable_fast are not true, or if the required colorspace is different from the internal one.
/// 
/// Note that if the buffer has <see cref="Efl.Gfx.Buffer.GetBufferBorders"/>, then <c>x</c> and <c>y</c> may be negative.</summary>
/// <param name="mode">Specifies whether to map for read-only, write-only or read-write access (OR combination of flags).</param>
/// <param name="region">The region to map.</param>
/// <param name="cspace">Requested colorspace. If different from the internal cspace, map should try to convert the data into a new buffer. argb8888 by default.</param>
/// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
/// <param name="stride">Returns the length in bytes of a mapped line</param>
/// <returns>The data slice. In case of failure, the memory pointer will be <c>null</c>.</returns>
Eina.RwSlice BufferMap( Efl.Gfx.BufferAccessMode mode,  ref Eina.Rect region,  Efl.Gfx.Colorspace cspace,   int plane,  out  int stride);
   /// <summary>Unmap a region of this buffer, and update the internal data if needed.
/// EFL will update the internal image if the map had write access.
/// 
/// Note: The <c>slice</c> struct does not need to be the one returned by <see cref="Efl.Gfx.Buffer.BufferMap"/>, only its contents (<c>mem</c> and <c>len</c>) must match. But after a call to <see cref="Efl.Gfx.Buffer.BufferUnmap"/> the original <c>slice</c> structure is not valid anymore.</summary>
/// <param name="slice">Data slice returned by a previous call to map.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool BufferUnmap( Eina.RwSlice slice);
   /// <summary>Set the pixels for this buffer by copying them, or allocate a new memory region.
/// This will allocate a new buffer in memory and copy the input <c>pixels</c> to it. The internal colorspace is not guaranteed to be preserved, and colorspace conversion may happen internally.
/// 
/// If <c>pixels</c> is <c>null</c>, then a new empty buffer will be allocated. If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.Buffer.SetBufferManaged"/>.
/// 
/// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
/// 
/// <c>slice</c> should not be the return value of <see cref="Efl.Gfx.Buffer.GetBufferManaged"/>.</summary>
/// <param name="slice">If <c>null</c>, allocates an empty buffer</param>
/// <param name="size">The size in pixels.</param>
/// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
/// <param name="cspace">argb8888 by default.</param>
/// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool SetBufferCopy( Eina.Slice slice,  Eina.Size2D size,   int stride,  Efl.Gfx.Colorspace cspace,   int plane);
   /// <summary>Set the pixels for this buffer, managed externally by the client.
/// EFL will use the pixel data directly, and update the GPU-side texture if required. This will mark the image as dirty. If <c>slice</c> is <c>null</c>, this will detach the pixel data.
/// 
/// If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.Buffer.SetBufferCopy"/>.
/// 
/// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
/// 
/// See also <see cref="Efl.Gfx.Buffer.SetBufferCopy"/> if you want EFL to copy the input buffer internally.</summary>
/// <param name="slice">If <c>null</c>, detaches the previous buffer.</param>
/// <param name="size">The size in pixels.</param>
/// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
/// <param name="cspace">argb8888 by default.</param>
/// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool SetBufferManaged( Eina.Slice slice,  Eina.Size2D size,   int stride,  Efl.Gfx.Colorspace cspace,   int plane);
   /// <summary>Get a direct pointer to the internal pixel data, if available.
/// This will return <c>null</c> unless <see cref="Efl.Gfx.Buffer.SetBufferManaged"/> was used to pass in an external data pointer.</summary>
/// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
/// <returns>The data slice. The memory pointer will be <c>null</c> in case of failure.</returns>
Eina.Slice GetBufferManaged(  int plane);
                                          /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
   Eina.Size2D BufferSize {
      get ;
      set ;
   }
   /// <summary>The colorspace defines how pixels are encoded in the image in memory.
/// By default, images are encoded in 32-bit BGRA, ie. each pixel takes 4 bytes in memory, with each channel B,G,R,A encoding the color with values from 0 to 255.
/// 
/// All images used in EFL use alpha-premultipied BGRA values, which means that for each pixel, B &lt;= A, G &lt;= A and R &lt;= A.</summary>
   Efl.Gfx.Colorspace Colorspace {
      get ;
   }
   /// <summary>Indicates whether the alpha channel should be used.
/// This does not indicate whether the image source file contains an alpha channel, only whether to respect it or discard it.</summary>
   bool Alpha {
      get ;
      set ;
   }
   /// <summary>Length in bytes of one row of pixels in memory.
/// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
/// 
/// When applicable, this will include the <see cref="Efl.Gfx.Buffer.GetBufferBorders"/> as well as potential extra padding.</summary>
    int Stride {
      get ;
   }
}
/// <summary>Common APIs for all objects representing images and 2D pixel buffers.</summary>
sealed public class BufferConcrete : 

Buffer
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (BufferConcrete))
            return Efl.Gfx.BufferConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_gfx_buffer_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public BufferConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~BufferConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static BufferConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new BufferConcrete(obj.NativeHandle);
   }
   ///<summary>Verifies if the given object is equal to this one.</summary>
   public override bool Equals(object obj)
   {
      var other = obj as Efl.Object;
      if (other == null)
         return false;
      return this.NativeHandle == other.NativeHandle;
   }
   ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
   public override int GetHashCode()
   {
      return this.NativeHandle.ToInt32();
   }
   ///<summary>Turns the native pointer into a string representation.</summary>
   public override String ToString()
   {
      return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
   }
    void register_event_proxies()
   {
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Size2D_StructInternal efl_gfx_buffer_size_get(System.IntPtr obj);
   /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
   /// <returns>Size of the buffer in pixels.</returns>
   public Eina.Size2D GetBufferSize() {
       var _ret_var = efl_gfx_buffer_size_get(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_buffer_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
   /// <summary>Potentially not implemented, <see cref="Efl.Gfx.Buffer.BufferSize"/> may be read-only.</summary>
   /// <param name="sz">Size of the buffer in pixels.</param>
   /// <returns></returns>
   public  void SetBufferSize( Eina.Size2D sz) {
       var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                  efl_gfx_buffer_size_set(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get(),  _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get(System.IntPtr obj);
   /// <summary>Returns the current encoding of this buffer&apos;s pixels.
   /// See <see cref="Efl.Gfx.Colorspace"/> for more information on the supported formats.</summary>
   /// <returns>Colorspace</returns>
   public Efl.Gfx.Colorspace GetColorspace() {
       var _ret_var = efl_gfx_buffer_colorspace_get(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_alpha_get(System.IntPtr obj);
   /// <summary>Retrieve whether alpha channel data is used on this object.</summary>
   /// <returns>Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</returns>
   public bool GetAlpha() {
       var _ret_var = efl_gfx_buffer_alpha_get(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_buffer_alpha_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
   /// <summary>Change alpha channel usage for this object.
   /// This function sets a flag on an image object indicating whether or not to use alpha channel data. A value of <c>true</c> makes it use alpha channel data, and <c>false</c> makes it ignore that data. Note that this has nothing to do with an object&apos;s color as manipulated by <see cref="Efl.Gfx.Color.GetColor"/>.</summary>
   /// <param name="alpha">Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</param>
   /// <returns></returns>
   public  void SetAlpha( bool alpha) {
                         efl_gfx_buffer_alpha_set(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get(),  alpha);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  int efl_gfx_buffer_stride_get(System.IntPtr obj);
   /// <summary>Length in bytes of one row of pixels in memory.
   /// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
   /// 
   /// When applicable, this will include the <see cref="Efl.Gfx.Buffer.GetBufferBorders"/> as well as potential extra padding.</summary>
   /// <returns>Stride</returns>
   public  int GetStride() {
       var _ret_var = efl_gfx_buffer_stride_get(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_buffer_borders_get(System.IntPtr obj,   out  uint l,   out  uint r,   out  uint t,   out  uint b);
   /// <summary>Duplicated pixel borders inside this buffer.
   /// Internally, EFL may require an image to have its border pixels duplicated, in particular for GL textures. This property exposes the internal duplicated borders to allow calling <see cref="Efl.Gfx.Buffer.BufferMap"/> with the entire pixel data, including those edge pixels.</summary>
   /// <param name="l">Left border pixels, usually 0 or 1</param>
   /// <param name="r">Right border pixels, usually 0 or 1</param>
   /// <param name="t">Top border pixels, usually 0 or 1</param>
   /// <param name="b">Bottom border pixels, usually 0 or 1</param>
   /// <returns></returns>
   public  void GetBufferBorders( out  uint l,  out  uint r,  out  uint t,  out  uint b) {
                                                                               efl_gfx_buffer_borders_get(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get(),  out l,  out r,  out t,  out b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_buffer_update_add(System.IntPtr obj,   ref Eina.Rect_StructInternal region);
   /// <summary>Mark a sub-region of the given image object to be redrawn.
   /// This function schedules a particular rectangular region of an image object to be updated (redrawn) at the next rendering cycle.</summary>
   /// <param name="region">The updated region.</param>
   /// <returns></returns>
   public  void AddBufferUpdate( ref Eina.Rect region) {
       var _in_region = Eina.Rect_StructConversion.ToInternal(region);
                  efl_gfx_buffer_update_add(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get(),  ref _in_region);
      Eina.Error.RaiseIfUnhandledException();
            region = Eina.Rect_StructConversion.ToManaged(_in_region);
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.RwSlice efl_gfx_buffer_map(System.IntPtr obj,   Efl.Gfx.BufferAccessMode mode,   ref Eina.Rect_StructInternal region,   Efl.Gfx.Colorspace cspace,    int plane,   out  int stride);
   /// <summary>Map a region of this buffer for read or write access by the CPU.
   /// Fetches data from the GPU if needed. This operation may be slow if cpu_readable_fast or cpu_writeable_fast are not true, or if the required colorspace is different from the internal one.
   /// 
   /// Note that if the buffer has <see cref="Efl.Gfx.Buffer.GetBufferBorders"/>, then <c>x</c> and <c>y</c> may be negative.</summary>
   /// <param name="mode">Specifies whether to map for read-only, write-only or read-write access (OR combination of flags).</param>
   /// <param name="region">The region to map.</param>
   /// <param name="cspace">Requested colorspace. If different from the internal cspace, map should try to convert the data into a new buffer. argb8888 by default.</param>
   /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
   /// <param name="stride">Returns the length in bytes of a mapped line</param>
   /// <returns>The data slice. In case of failure, the memory pointer will be <c>null</c>.</returns>
   public Eina.RwSlice BufferMap( Efl.Gfx.BufferAccessMode mode,  ref Eina.Rect region,  Efl.Gfx.Colorspace cspace,   int plane,  out  int stride) {
             var _in_region = Eina.Rect_StructConversion.ToInternal(region);
                                                                                    var _ret_var = efl_gfx_buffer_map(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get(),  mode,  ref _in_region,  cspace,  plane,  out stride);
      Eina.Error.RaiseIfUnhandledException();
                                          region = Eina.Rect_StructConversion.ToManaged(_in_region);
                        return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_unmap(System.IntPtr obj,   Eina.RwSlice slice);
   /// <summary>Unmap a region of this buffer, and update the internal data if needed.
   /// EFL will update the internal image if the map had write access.
   /// 
   /// Note: The <c>slice</c> struct does not need to be the one returned by <see cref="Efl.Gfx.Buffer.BufferMap"/>, only its contents (<c>mem</c> and <c>len</c>) must match. But after a call to <see cref="Efl.Gfx.Buffer.BufferUnmap"/> the original <c>slice</c> structure is not valid anymore.</summary>
   /// <param name="slice">Data slice returned by a previous call to map.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool BufferUnmap( Eina.RwSlice slice) {
                         var _ret_var = efl_gfx_buffer_unmap(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get(),  slice);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_copy_set(System.IntPtr obj,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
   /// <summary>Set the pixels for this buffer by copying them, or allocate a new memory region.
   /// This will allocate a new buffer in memory and copy the input <c>pixels</c> to it. The internal colorspace is not guaranteed to be preserved, and colorspace conversion may happen internally.
   /// 
   /// If <c>pixels</c> is <c>null</c>, then a new empty buffer will be allocated. If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.Buffer.SetBufferManaged"/>.
   /// 
   /// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
   /// 
   /// <c>slice</c> should not be the return value of <see cref="Efl.Gfx.Buffer.GetBufferManaged"/>.</summary>
   /// <param name="slice">If <c>null</c>, allocates an empty buffer</param>
   /// <param name="size">The size in pixels.</param>
   /// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
   /// <param name="cspace">argb8888 by default.</param>
   /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool SetBufferCopy( Eina.Slice slice,  Eina.Size2D size,   int stride,  Efl.Gfx.Colorspace cspace,   int plane) {
       var _in_slice = Eina.PrimitiveConversion.ManagedToPointerAlloc(slice);
      var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                                                                                    var _ret_var = efl_gfx_buffer_copy_set(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get(),  _in_slice,  _in_size,  stride,  cspace,  plane);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_managed_set(System.IntPtr obj,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
   /// <summary>Set the pixels for this buffer, managed externally by the client.
   /// EFL will use the pixel data directly, and update the GPU-side texture if required. This will mark the image as dirty. If <c>slice</c> is <c>null</c>, this will detach the pixel data.
   /// 
   /// If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.Buffer.SetBufferCopy"/>.
   /// 
   /// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
   /// 
   /// See also <see cref="Efl.Gfx.Buffer.SetBufferCopy"/> if you want EFL to copy the input buffer internally.</summary>
   /// <param name="slice">If <c>null</c>, detaches the previous buffer.</param>
   /// <param name="size">The size in pixels.</param>
   /// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
   /// <param name="cspace">argb8888 by default.</param>
   /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool SetBufferManaged( Eina.Slice slice,  Eina.Size2D size,   int stride,  Efl.Gfx.Colorspace cspace,   int plane) {
       var _in_slice = Eina.PrimitiveConversion.ManagedToPointerAlloc(slice);
      var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                                                                                    var _ret_var = efl_gfx_buffer_managed_set(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get(),  _in_slice,  _in_size,  stride,  cspace,  plane);
      Eina.Error.RaiseIfUnhandledException();
                                                                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Slice efl_gfx_buffer_managed_get(System.IntPtr obj,    int plane);
   /// <summary>Get a direct pointer to the internal pixel data, if available.
   /// This will return <c>null</c> unless <see cref="Efl.Gfx.Buffer.SetBufferManaged"/> was used to pass in an external data pointer.</summary>
   /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
   /// <returns>The data slice. The memory pointer will be <c>null</c> in case of failure.</returns>
   public Eina.Slice GetBufferManaged(  int plane) {
                         var _ret_var = efl_gfx_buffer_managed_get(Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get(),  plane);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
   public Eina.Size2D BufferSize {
      get { return GetBufferSize(); }
      set { SetBufferSize( value); }
   }
   /// <summary>The colorspace defines how pixels are encoded in the image in memory.
/// By default, images are encoded in 32-bit BGRA, ie. each pixel takes 4 bytes in memory, with each channel B,G,R,A encoding the color with values from 0 to 255.
/// 
/// All images used in EFL use alpha-premultipied BGRA values, which means that for each pixel, B &lt;= A, G &lt;= A and R &lt;= A.</summary>
   public Efl.Gfx.Colorspace Colorspace {
      get { return GetColorspace(); }
   }
   /// <summary>Indicates whether the alpha channel should be used.
/// This does not indicate whether the image source file contains an alpha channel, only whether to respect it or discard it.</summary>
   public bool Alpha {
      get { return GetAlpha(); }
      set { SetAlpha( value); }
   }
   /// <summary>Length in bytes of one row of pixels in memory.
/// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
/// 
/// When applicable, this will include the <see cref="Efl.Gfx.Buffer.GetBufferBorders"/> as well as potential extra padding.</summary>
   public  int Stride {
      get { return GetStride(); }
   }
}
public class BufferConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_buffer_size_get_static_delegate = new efl_gfx_buffer_size_get_delegate(buffer_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_size_get_static_delegate)});
      efl_gfx_buffer_size_set_static_delegate = new efl_gfx_buffer_size_set_delegate(buffer_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_size_set_static_delegate)});
      efl_gfx_buffer_colorspace_get_static_delegate = new efl_gfx_buffer_colorspace_get_delegate(colorspace_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_colorspace_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_colorspace_get_static_delegate)});
      efl_gfx_buffer_alpha_get_static_delegate = new efl_gfx_buffer_alpha_get_delegate(alpha_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_alpha_get_static_delegate)});
      efl_gfx_buffer_alpha_set_static_delegate = new efl_gfx_buffer_alpha_set_delegate(alpha_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_alpha_set_static_delegate)});
      efl_gfx_buffer_stride_get_static_delegate = new efl_gfx_buffer_stride_get_delegate(stride_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_stride_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_stride_get_static_delegate)});
      efl_gfx_buffer_borders_get_static_delegate = new efl_gfx_buffer_borders_get_delegate(buffer_borders_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_borders_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_borders_get_static_delegate)});
      efl_gfx_buffer_update_add_static_delegate = new efl_gfx_buffer_update_add_delegate(buffer_update_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_update_add"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_update_add_static_delegate)});
      efl_gfx_buffer_map_static_delegate = new efl_gfx_buffer_map_delegate(buffer_map);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_map"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_map_static_delegate)});
      efl_gfx_buffer_unmap_static_delegate = new efl_gfx_buffer_unmap_delegate(buffer_unmap);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_unmap"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_unmap_static_delegate)});
      efl_gfx_buffer_copy_set_static_delegate = new efl_gfx_buffer_copy_set_delegate(buffer_copy_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_copy_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_copy_set_static_delegate)});
      efl_gfx_buffer_managed_set_static_delegate = new efl_gfx_buffer_managed_set_delegate(buffer_managed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_managed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_managed_set_static_delegate)});
      efl_gfx_buffer_managed_get_static_delegate = new efl_gfx_buffer_managed_get_delegate(buffer_managed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_buffer_managed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_managed_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get();
   }


    private delegate Eina.Size2D_StructInternal efl_gfx_buffer_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_buffer_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal buffer_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_buffer_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Buffer)wrapper).GetBufferSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_buffer_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_buffer_size_get_delegate efl_gfx_buffer_size_get_static_delegate;


    private delegate  void efl_gfx_buffer_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_buffer_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
    private static  void buffer_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_buffer_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                     
         try {
            ((Buffer)wrapper).SetBufferSize( _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_buffer_size_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
      }
   }
   private efl_gfx_buffer_size_set_delegate efl_gfx_buffer_size_set_static_delegate;


    private delegate Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get(System.IntPtr obj);
    private static Efl.Gfx.Colorspace colorspace_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_buffer_colorspace_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Colorspace _ret_var = default(Efl.Gfx.Colorspace);
         try {
            _ret_var = ((Buffer)wrapper).GetColorspace();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_buffer_colorspace_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_buffer_colorspace_get_delegate efl_gfx_buffer_colorspace_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_alpha_get(System.IntPtr obj);
    private static bool alpha_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_buffer_alpha_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Buffer)wrapper).GetAlpha();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_buffer_alpha_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_buffer_alpha_get_delegate efl_gfx_buffer_alpha_get_static_delegate;


    private delegate  void efl_gfx_buffer_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_buffer_alpha_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
    private static  void alpha_set(System.IntPtr obj, System.IntPtr pd,  bool alpha)
   {
      Eina.Log.Debug("function efl_gfx_buffer_alpha_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Buffer)wrapper).SetAlpha( alpha);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_buffer_alpha_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  alpha);
      }
   }
   private efl_gfx_buffer_alpha_set_delegate efl_gfx_buffer_alpha_set_static_delegate;


    private delegate  int efl_gfx_buffer_stride_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_gfx_buffer_stride_get(System.IntPtr obj);
    private static  int stride_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_buffer_stride_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Buffer)wrapper).GetStride();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_buffer_stride_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_buffer_stride_get_delegate efl_gfx_buffer_stride_get_static_delegate;


    private delegate  void efl_gfx_buffer_borders_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  uint l,   out  uint r,   out  uint t,   out  uint b);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_buffer_borders_get(System.IntPtr obj,   out  uint l,   out  uint r,   out  uint t,   out  uint b);
    private static  void buffer_borders_get(System.IntPtr obj, System.IntPtr pd,  out  uint l,  out  uint r,  out  uint t,  out  uint b)
   {
      Eina.Log.Debug("function efl_gfx_buffer_borders_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       l = default( uint);      r = default( uint);      t = default( uint);      b = default( uint);                                 
         try {
            ((Buffer)wrapper).GetBufferBorders( out l,  out r,  out t,  out b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_buffer_borders_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
      }
   }
   private efl_gfx_buffer_borders_get_delegate efl_gfx_buffer_borders_get_static_delegate;


    private delegate  void efl_gfx_buffer_update_add_delegate(System.IntPtr obj, System.IntPtr pd,   ref Eina.Rect_StructInternal region);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_buffer_update_add(System.IntPtr obj,   ref Eina.Rect_StructInternal region);
    private static  void buffer_update_add(System.IntPtr obj, System.IntPtr pd,  ref Eina.Rect_StructInternal region)
   {
      Eina.Log.Debug("function efl_gfx_buffer_update_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_region = Eina.Rect_StructConversion.ToManaged(region);
                     
         try {
            ((Buffer)wrapper).AddBufferUpdate( ref _in_region);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            region = Eina.Rect_StructConversion.ToInternal(_in_region);
            } else {
         efl_gfx_buffer_update_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref region);
      }
   }
   private efl_gfx_buffer_update_add_delegate efl_gfx_buffer_update_add_static_delegate;


    private delegate Eina.RwSlice efl_gfx_buffer_map_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.BufferAccessMode mode,   ref Eina.Rect_StructInternal region,   Efl.Gfx.Colorspace cspace,    int plane,   out  int stride);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.RwSlice efl_gfx_buffer_map(System.IntPtr obj,   Efl.Gfx.BufferAccessMode mode,   ref Eina.Rect_StructInternal region,   Efl.Gfx.Colorspace cspace,    int plane,   out  int stride);
    private static Eina.RwSlice buffer_map(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.BufferAccessMode mode,  ref Eina.Rect_StructInternal region,  Efl.Gfx.Colorspace cspace,   int plane,  out  int stride)
   {
      Eina.Log.Debug("function efl_gfx_buffer_map was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_region = Eina.Rect_StructConversion.ToManaged(region);
                                                stride = default( int);                                       Eina.RwSlice _ret_var = default(Eina.RwSlice);
         try {
            _ret_var = ((Buffer)wrapper).BufferMap( mode,  ref _in_region,  cspace,  plane,  out stride);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          region = Eina.Rect_StructConversion.ToInternal(_in_region);
                        return _ret_var;
      } else {
         return efl_gfx_buffer_map(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode,  ref region,  cspace,  plane,  out stride);
      }
   }
   private efl_gfx_buffer_map_delegate efl_gfx_buffer_map_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_unmap_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.RwSlice slice);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_unmap(System.IntPtr obj,   Eina.RwSlice slice);
    private static bool buffer_unmap(System.IntPtr obj, System.IntPtr pd,  Eina.RwSlice slice)
   {
      Eina.Log.Debug("function efl_gfx_buffer_unmap was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Buffer)wrapper).BufferUnmap( slice);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_buffer_unmap(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  slice);
      }
   }
   private efl_gfx_buffer_unmap_delegate efl_gfx_buffer_unmap_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_copy_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_copy_set(System.IntPtr obj,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
    private static bool buffer_copy_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr slice,  Eina.Size2D_StructInternal size,   int stride,  Efl.Gfx.Colorspace cspace,   int plane)
   {
      Eina.Log.Debug("function efl_gfx_buffer_copy_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_slice = Eina.PrimitiveConversion.PointerToManaged<Eina.Slice>(slice);
      var _in_size = Eina.Size2D_StructConversion.ToManaged(size);
                                                                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((Buffer)wrapper).SetBufferCopy( _in_slice,  _in_size,  stride,  cspace,  plane);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_gfx_buffer_copy_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  slice,  size,  stride,  cspace,  plane);
      }
   }
   private efl_gfx_buffer_copy_set_delegate efl_gfx_buffer_copy_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_managed_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_buffer_managed_set(System.IntPtr obj,    System.IntPtr slice,   Eina.Size2D_StructInternal size,    int stride,   Efl.Gfx.Colorspace cspace,    int plane);
    private static bool buffer_managed_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr slice,  Eina.Size2D_StructInternal size,   int stride,  Efl.Gfx.Colorspace cspace,   int plane)
   {
      Eina.Log.Debug("function efl_gfx_buffer_managed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_slice = Eina.PrimitiveConversion.PointerToManaged<Eina.Slice>(slice);
      var _in_size = Eina.Size2D_StructConversion.ToManaged(size);
                                                                                       bool _ret_var = default(bool);
         try {
            _ret_var = ((Buffer)wrapper).SetBufferManaged( _in_slice,  _in_size,  stride,  cspace,  plane);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                  return _ret_var;
      } else {
         return efl_gfx_buffer_managed_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  slice,  size,  stride,  cspace,  plane);
      }
   }
   private efl_gfx_buffer_managed_set_delegate efl_gfx_buffer_managed_set_static_delegate;


    private delegate Eina.Slice efl_gfx_buffer_managed_get_delegate(System.IntPtr obj, System.IntPtr pd,    int plane);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Slice efl_gfx_buffer_managed_get(System.IntPtr obj,    int plane);
    private static Eina.Slice buffer_managed_get(System.IntPtr obj, System.IntPtr pd,   int plane)
   {
      Eina.Log.Debug("function efl_gfx_buffer_managed_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Eina.Slice _ret_var = default(Eina.Slice);
         try {
            _ret_var = ((Buffer)wrapper).GetBufferManaged( plane);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_buffer_managed_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  plane);
      }
   }
   private efl_gfx_buffer_managed_get_delegate efl_gfx_buffer_managed_get_static_delegate;
}
} } 
namespace Efl { namespace Gfx { 
/// <summary>Graphics buffer access mode</summary>
public enum BufferAccessMode
{
/// <summary>No buffer access</summary>
None = 0,
/// <summary>Read access to buffer</summary>
Read = 1,
/// <summary>Write aces to buffer</summary>
Write = 2,
/// <summary>Forces copy-on-write if already mapped as read-only. Requires write.</summary>
Cow = 4,
}
} } 
