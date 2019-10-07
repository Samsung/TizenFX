#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gfx {

/// <summary>Common APIs for all objects representing images and 2D pixel buffers.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Gfx.BufferConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IBuffer : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
    /// <returns>Size of the buffer in pixels.</returns>
    Eina.Size2D GetBufferSize();

    /// <summary>Potentially not implemented, <see cref="Efl.Gfx.IBuffer.BufferSize"/> may be read-only.</summary>
    /// <param name="sz">Size of the buffer in pixels.</param>
    void SetBufferSize(Eina.Size2D sz);

    /// <summary>Returns the current encoding of this buffer&apos;s pixels.
    /// See <see cref="Efl.Gfx.Colorspace"/> for more information on the supported formats.</summary>
    /// <returns>Colorspace</returns>
    Efl.Gfx.Colorspace GetColorspace();

    /// <summary>Retrieve whether alpha channel data is used on this object.</summary>
    /// <returns>Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</returns>
    bool GetAlpha();

    /// <summary>Change alpha channel usage for this object.
    /// This function sets a flag on an image object indicating whether or not to use alpha channel data. A value of <c>true</c> makes it use alpha channel data, and <c>false</c> makes it ignore that data. Note that this has nothing to do with an object&apos;s color as manipulated by <see cref="Efl.Gfx.IColor.GetColor"/>.</summary>
    /// <param name="alpha">Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</param>
    void SetAlpha(bool alpha);

    /// <summary>Length in bytes of one row of pixels in memory.
    /// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
    /// 
    /// When applicable, this will include the <see cref="Efl.Gfx.IBuffer.GetBufferBorders"/> as well as potential extra padding.</summary>
    /// <returns>Stride</returns>
    int GetStride();

    /// <summary>Duplicated pixel borders inside this buffer.
    /// Internally, EFL may require an image to have its border pixels duplicated, in particular for GL textures. This property exposes the internal duplicated borders to allow calling <see cref="Efl.Gfx.IBuffer.BufferMap"/> with the entire pixel data, including those edge pixels.</summary>
    /// <param name="l">Left border pixels, usually 0 or 1<br/>The default value is <c>0U</c>.</param>
    /// <param name="r">Right border pixels, usually 0 or 1<br/>The default value is <c>0U</c>.</param>
    /// <param name="t">Top border pixels, usually 0 or 1<br/>The default value is <c>0U</c>.</param>
    /// <param name="b">Bottom border pixels, usually 0 or 1<br/>The default value is <c>0U</c>.</param>
    void GetBufferBorders(out uint l, out uint r, out uint t, out uint b);

    /// <summary>Mark a sub-region of the given image object to be redrawn.
    /// This function schedules a particular rectangular region of an image object to be updated (redrawn) at the next rendering cycle.</summary>
    /// <param name="region">The updated region.</param>
    void AddBufferUpdate(ref Eina.Rect region);

    /// <summary>Map a region of this buffer for read or write access by the CPU.
    /// Fetches data from the GPU if needed. This operation may be slow if cpu_readable_fast or cpu_writeable_fast are not true, or if the required colorspace is different from the internal one.
    /// 
    /// Note that if the buffer has <see cref="Efl.Gfx.IBuffer.GetBufferBorders"/>, then <c>x</c> and <c>y</c> may be negative.</summary>
    /// <param name="mode">Specifies whether to map for read-only, write-only or read-write access (OR combination of flags).</param>
    /// <param name="region">The region to map.</param>
    /// <param name="cspace">Requested colorspace. If different from the internal cspace, map should try to convert the data into a new buffer. argb8888 by default.</param>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <param name="stride">Returns the length in bytes of a mapped line</param>
    /// <returns>The data slice. In case of failure, the memory pointer will be <c>null</c>.</returns>
    Eina.RwSlice BufferMap(Efl.Gfx.BufferAccessMode mode, ref Eina.Rect region, Efl.Gfx.Colorspace cspace, int plane, out int stride);

    /// <summary>Unmap a region of this buffer, and update the internal data if needed.
    /// EFL will update the internal image if the map had write access.
    /// 
    /// Note: The <c>slice</c> struct does not need to be the one returned by <see cref="Efl.Gfx.IBuffer.BufferMap"/>, only its contents (<c>mem</c> and <c>len</c>) must match. But after a call to <see cref="Efl.Gfx.IBuffer.BufferUnmap"/> the original <c>slice</c> structure is not valid anymore.</summary>
    /// <param name="slice">Data slice returned by a previous call to map.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    bool BufferUnmap(Eina.RwSlice slice);

    /// <summary>Set the pixels for this buffer by copying them, or allocate a new memory region.
    /// This will allocate a new buffer in memory and copy the input <c>pixels</c> to it. The internal colorspace is not guaranteed to be preserved, and colorspace conversion may happen internally.
    /// 
    /// If <c>pixels</c> is <c>null</c>, then a new empty buffer will be allocated. If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.IBuffer.SetBufferManaged"/>.
    /// 
    /// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
    /// 
    /// <c>slice</c> should not be the return value of <see cref="Efl.Gfx.IBuffer.GetBufferManaged"/>.</summary>
    /// <param name="slice">If <c>null</c>, allocates an empty buffer</param>
    /// <param name="size">The size in pixels.</param>
    /// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
    /// <param name="cspace">argb8888 by default.</param>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    bool SetBufferCopy(Eina.Slice slice, Eina.Size2D size, int stride, Efl.Gfx.Colorspace cspace, int plane);

    /// <summary>Set the pixels for this buffer, managed externally by the client.
    /// EFL will use the pixel data directly, and update the GPU-side texture if required. This will mark the image as dirty. If <c>slice</c> is <c>null</c>, this will detach the pixel data.
    /// 
    /// If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.IBuffer.SetBufferCopy"/>.
    /// 
    /// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
    /// 
    /// See also <see cref="Efl.Gfx.IBuffer.SetBufferCopy"/> if you want EFL to copy the input buffer internally.</summary>
    /// <param name="slice">If <c>null</c>, detaches the previous buffer.</param>
    /// <param name="size">The size in pixels.</param>
    /// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
    /// <param name="cspace">argb8888 by default.</param>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    bool SetBufferManaged(Eina.Slice slice, Eina.Size2D size, int stride, Efl.Gfx.Colorspace cspace, int plane);

    /// <summary>Get a direct pointer to the internal pixel data, if available.
    /// This will return <c>null</c> unless <see cref="Efl.Gfx.IBuffer.SetBufferManaged"/> was used to pass in an external data pointer.</summary>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <returns>The data slice. The memory pointer will be <c>null</c> in case of failure.</returns>
    Eina.Slice GetBufferManaged(int plane);

    /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
    /// <value>Size of the buffer in pixels.</value>
    Eina.Size2D BufferSize {
        get;
        set;
    }

    /// <summary>The colorspace defines how pixels are encoded in the image in memory.
    /// By default, images are encoded in 32-bit BGRA, ie. each pixel takes 4 bytes in memory, with each channel B,G,R,A encoding the color with values from 0 to 255.
    /// 
    /// All images used in EFL use alpha-premultipied BGRA values, which means that for each pixel, B &lt;= A, G &lt;= A and R &lt;= A.</summary>
    /// <value>Colorspace</value>
    Efl.Gfx.Colorspace Colorspace {
        get;
    }

    /// <summary>Indicates whether the alpha channel should be used.
    /// This does not indicate whether the image source file contains an alpha channel, only whether to respect it or discard it.</summary>
    /// <value>Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</value>
    bool Alpha {
        get;
        set;
    }

    /// <summary>Length in bytes of one row of pixels in memory.
    /// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
    /// 
    /// When applicable, this will include the <see cref="Efl.Gfx.IBuffer.GetBufferBorders"/> as well as potential extra padding.</summary>
    /// <value>Stride</value>
    int Stride {
        get;
    }

    /// <summary>Duplicated pixel borders inside this buffer.
    /// Internally, EFL may require an image to have its border pixels duplicated, in particular for GL textures. This property exposes the internal duplicated borders to allow calling <see cref="Efl.Gfx.IBuffer.BufferMap"/> with the entire pixel data, including those edge pixels.</summary>
    (uint, uint, uint, uint) BufferBorders {
        get;
    }

}

/// <summary>Common APIs for all objects representing images and 2D pixel buffers.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class BufferConcrete :
    Efl.Eo.EoWrapper
    , IBuffer
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(BufferConcrete))
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
    private BufferConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_buffer_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IBuffer"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private BufferConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
    /// <returns>Size of the buffer in pixels.</returns>
    public Eina.Size2D GetBufferSize() {
        var _ret_var = Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_size_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Potentially not implemented, <see cref="Efl.Gfx.IBuffer.BufferSize"/> may be read-only.</summary>
    /// <param name="sz">Size of the buffer in pixels.</param>
    public void SetBufferSize(Eina.Size2D sz) {
        Eina.Size2D.NativeStruct _in_sz = sz;
Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_size_set_ptr.Value.Delegate(this.NativeHandle,_in_sz);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Returns the current encoding of this buffer&apos;s pixels.
    /// See <see cref="Efl.Gfx.Colorspace"/> for more information on the supported formats.</summary>
    /// <returns>Colorspace</returns>
    public Efl.Gfx.Colorspace GetColorspace() {
        var _ret_var = Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_colorspace_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Retrieve whether alpha channel data is used on this object.</summary>
    /// <returns>Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</returns>
    public bool GetAlpha() {
        var _ret_var = Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_alpha_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Change alpha channel usage for this object.
    /// This function sets a flag on an image object indicating whether or not to use alpha channel data. A value of <c>true</c> makes it use alpha channel data, and <c>false</c> makes it ignore that data. Note that this has nothing to do with an object&apos;s color as manipulated by <see cref="Efl.Gfx.IColor.GetColor"/>.</summary>
    /// <param name="alpha">Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</param>
    public void SetAlpha(bool alpha) {
        Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_alpha_set_ptr.Value.Delegate(this.NativeHandle,alpha);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Length in bytes of one row of pixels in memory.
    /// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
    /// 
    /// When applicable, this will include the <see cref="Efl.Gfx.IBuffer.GetBufferBorders"/> as well as potential extra padding.</summary>
    /// <returns>Stride</returns>
    public int GetStride() {
        var _ret_var = Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_stride_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Duplicated pixel borders inside this buffer.
    /// Internally, EFL may require an image to have its border pixels duplicated, in particular for GL textures. This property exposes the internal duplicated borders to allow calling <see cref="Efl.Gfx.IBuffer.BufferMap"/> with the entire pixel data, including those edge pixels.</summary>
    /// <param name="l">Left border pixels, usually 0 or 1<br/>The default value is <c>0U</c>.</param>
    /// <param name="r">Right border pixels, usually 0 or 1<br/>The default value is <c>0U</c>.</param>
    /// <param name="t">Top border pixels, usually 0 or 1<br/>The default value is <c>0U</c>.</param>
    /// <param name="b">Bottom border pixels, usually 0 or 1<br/>The default value is <c>0U</c>.</param>
    public void GetBufferBorders(out uint l, out uint r, out uint t, out uint b) {
        Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_borders_get_ptr.Value.Delegate(this.NativeHandle,out l, out r, out t, out b);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Mark a sub-region of the given image object to be redrawn.
    /// This function schedules a particular rectangular region of an image object to be updated (redrawn) at the next rendering cycle.</summary>
    /// <param name="region">The updated region.</param>
    public void AddBufferUpdate(ref Eina.Rect region) {
        Eina.Rect.NativeStruct _in_region = region;
Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_update_add_ptr.Value.Delegate(this.NativeHandle,ref _in_region);
        Eina.Error.RaiseIfUnhandledException();
region = _in_region;
        
    }

    /// <summary>Map a region of this buffer for read or write access by the CPU.
    /// Fetches data from the GPU if needed. This operation may be slow if cpu_readable_fast or cpu_writeable_fast are not true, or if the required colorspace is different from the internal one.
    /// 
    /// Note that if the buffer has <see cref="Efl.Gfx.IBuffer.GetBufferBorders"/>, then <c>x</c> and <c>y</c> may be negative.</summary>
    /// <param name="mode">Specifies whether to map for read-only, write-only or read-write access (OR combination of flags).</param>
    /// <param name="region">The region to map.</param>
    /// <param name="cspace">Requested colorspace. If different from the internal cspace, map should try to convert the data into a new buffer. argb8888 by default.</param>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <param name="stride">Returns the length in bytes of a mapped line</param>
    /// <returns>The data slice. In case of failure, the memory pointer will be <c>null</c>.</returns>
    public Eina.RwSlice BufferMap(Efl.Gfx.BufferAccessMode mode, ref Eina.Rect region, Efl.Gfx.Colorspace cspace, int plane, out int stride) {
        Eina.Rect.NativeStruct _in_region = region;
var _ret_var = Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_map_ptr.Value.Delegate(this.NativeHandle,mode, ref _in_region, cspace, plane, out stride);
        Eina.Error.RaiseIfUnhandledException();
region = _in_region;
        return _ret_var;
    }

    /// <summary>Unmap a region of this buffer, and update the internal data if needed.
    /// EFL will update the internal image if the map had write access.
    /// 
    /// Note: The <c>slice</c> struct does not need to be the one returned by <see cref="Efl.Gfx.IBuffer.BufferMap"/>, only its contents (<c>mem</c> and <c>len</c>) must match. But after a call to <see cref="Efl.Gfx.IBuffer.BufferUnmap"/> the original <c>slice</c> structure is not valid anymore.</summary>
    /// <param name="slice">Data slice returned by a previous call to map.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool BufferUnmap(Eina.RwSlice slice) {
        var _ret_var = Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_unmap_ptr.Value.Delegate(this.NativeHandle,slice);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Set the pixels for this buffer by copying them, or allocate a new memory region.
    /// This will allocate a new buffer in memory and copy the input <c>pixels</c> to it. The internal colorspace is not guaranteed to be preserved, and colorspace conversion may happen internally.
    /// 
    /// If <c>pixels</c> is <c>null</c>, then a new empty buffer will be allocated. If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.IBuffer.SetBufferManaged"/>.
    /// 
    /// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
    /// 
    /// <c>slice</c> should not be the return value of <see cref="Efl.Gfx.IBuffer.GetBufferManaged"/>.</summary>
    /// <param name="slice">If <c>null</c>, allocates an empty buffer</param>
    /// <param name="size">The size in pixels.</param>
    /// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
    /// <param name="cspace">argb8888 by default.</param>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool SetBufferCopy(Eina.Slice slice, Eina.Size2D size, int stride, Efl.Gfx.Colorspace cspace, int plane) {
        var _in_slice = Eina.PrimitiveConversion.ManagedToPointerAlloc(slice);
Eina.Size2D.NativeStruct _in_size = size;
var _ret_var = Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_copy_set_ptr.Value.Delegate(this.NativeHandle,_in_slice, _in_size, stride, cspace, plane);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Set the pixels for this buffer, managed externally by the client.
    /// EFL will use the pixel data directly, and update the GPU-side texture if required. This will mark the image as dirty. If <c>slice</c> is <c>null</c>, this will detach the pixel data.
    /// 
    /// If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.IBuffer.SetBufferCopy"/>.
    /// 
    /// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
    /// 
    /// See also <see cref="Efl.Gfx.IBuffer.SetBufferCopy"/> if you want EFL to copy the input buffer internally.</summary>
    /// <param name="slice">If <c>null</c>, detaches the previous buffer.</param>
    /// <param name="size">The size in pixels.</param>
    /// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
    /// <param name="cspace">argb8888 by default.</param>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool SetBufferManaged(Eina.Slice slice, Eina.Size2D size, int stride, Efl.Gfx.Colorspace cspace, int plane) {
        var _in_slice = Eina.PrimitiveConversion.ManagedToPointerAlloc(slice);
Eina.Size2D.NativeStruct _in_size = size;
var _ret_var = Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_managed_set_ptr.Value.Delegate(this.NativeHandle,_in_slice, _in_size, stride, cspace, plane);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Get a direct pointer to the internal pixel data, if available.
    /// This will return <c>null</c> unless <see cref="Efl.Gfx.IBuffer.SetBufferManaged"/> was used to pass in an external data pointer.</summary>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <returns>The data slice. The memory pointer will be <c>null</c> in case of failure.</returns>
    public Eina.Slice GetBufferManaged(int plane) {
        var _ret_var = Efl.Gfx.BufferConcrete.NativeMethods.efl_gfx_buffer_managed_get_ptr.Value.Delegate(this.NativeHandle,plane);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
    /// <value>Size of the buffer in pixels.</value>
    public Eina.Size2D BufferSize {
        get { return GetBufferSize(); }
        set { SetBufferSize(value); }
    }

    /// <summary>The colorspace defines how pixels are encoded in the image in memory.
    /// By default, images are encoded in 32-bit BGRA, ie. each pixel takes 4 bytes in memory, with each channel B,G,R,A encoding the color with values from 0 to 255.
    /// 
    /// All images used in EFL use alpha-premultipied BGRA values, which means that for each pixel, B &lt;= A, G &lt;= A and R &lt;= A.</summary>
    /// <value>Colorspace</value>
    public Efl.Gfx.Colorspace Colorspace {
        get { return GetColorspace(); }
    }

    /// <summary>Indicates whether the alpha channel should be used.
    /// This does not indicate whether the image source file contains an alpha channel, only whether to respect it or discard it.</summary>
    /// <value>Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</value>
    public bool Alpha {
        get { return GetAlpha(); }
        set { SetAlpha(value); }
    }

    /// <summary>Length in bytes of one row of pixels in memory.
    /// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
    /// 
    /// When applicable, this will include the <see cref="Efl.Gfx.IBuffer.GetBufferBorders"/> as well as potential extra padding.</summary>
    /// <value>Stride</value>
    public int Stride {
        get { return GetStride(); }
    }

    /// <summary>Duplicated pixel borders inside this buffer.
    /// Internally, EFL may require an image to have its border pixels duplicated, in particular for GL textures. This property exposes the internal duplicated borders to allow calling <see cref="Efl.Gfx.IBuffer.BufferMap"/> with the entire pixel data, including those edge pixels.</summary>
    public (uint, uint, uint, uint) BufferBorders {
        get {
            uint _out_l = default(uint);
            uint _out_r = default(uint);
            uint _out_t = default(uint);
            uint _out_b = default(uint);
            GetBufferBorders(out _out_l,out _out_r,out _out_t,out _out_b);
            return (_out_l,_out_r,_out_t,_out_b);
        }
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Efl);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_buffer_size_get_static_delegate == null)
            {
                efl_gfx_buffer_size_get_static_delegate = new efl_gfx_buffer_size_get_delegate(buffer_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBufferSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_size_get_static_delegate) });
            }

            if (efl_gfx_buffer_size_set_static_delegate == null)
            {
                efl_gfx_buffer_size_set_static_delegate = new efl_gfx_buffer_size_set_delegate(buffer_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBufferSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_size_set_static_delegate) });
            }

            if (efl_gfx_buffer_colorspace_get_static_delegate == null)
            {
                efl_gfx_buffer_colorspace_get_static_delegate = new efl_gfx_buffer_colorspace_get_delegate(colorspace_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetColorspace") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_colorspace_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_colorspace_get_static_delegate) });
            }

            if (efl_gfx_buffer_alpha_get_static_delegate == null)
            {
                efl_gfx_buffer_alpha_get_static_delegate = new efl_gfx_buffer_alpha_get_delegate(alpha_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_alpha_get_static_delegate) });
            }

            if (efl_gfx_buffer_alpha_set_static_delegate == null)
            {
                efl_gfx_buffer_alpha_set_static_delegate = new efl_gfx_buffer_alpha_set_delegate(alpha_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_alpha_set_static_delegate) });
            }

            if (efl_gfx_buffer_stride_get_static_delegate == null)
            {
                efl_gfx_buffer_stride_get_static_delegate = new efl_gfx_buffer_stride_get_delegate(stride_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStride") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_stride_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_stride_get_static_delegate) });
            }

            if (efl_gfx_buffer_borders_get_static_delegate == null)
            {
                efl_gfx_buffer_borders_get_static_delegate = new efl_gfx_buffer_borders_get_delegate(buffer_borders_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBufferBorders") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_borders_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_borders_get_static_delegate) });
            }

            if (efl_gfx_buffer_update_add_static_delegate == null)
            {
                efl_gfx_buffer_update_add_static_delegate = new efl_gfx_buffer_update_add_delegate(buffer_update_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddBufferUpdate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_update_add"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_update_add_static_delegate) });
            }

            if (efl_gfx_buffer_map_static_delegate == null)
            {
                efl_gfx_buffer_map_static_delegate = new efl_gfx_buffer_map_delegate(buffer_map);
            }

            if (methods.FirstOrDefault(m => m.Name == "BufferMap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_map"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_map_static_delegate) });
            }

            if (efl_gfx_buffer_unmap_static_delegate == null)
            {
                efl_gfx_buffer_unmap_static_delegate = new efl_gfx_buffer_unmap_delegate(buffer_unmap);
            }

            if (methods.FirstOrDefault(m => m.Name == "BufferUnmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_unmap"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_unmap_static_delegate) });
            }

            if (efl_gfx_buffer_copy_set_static_delegate == null)
            {
                efl_gfx_buffer_copy_set_static_delegate = new efl_gfx_buffer_copy_set_delegate(buffer_copy_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBufferCopy") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_copy_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_copy_set_static_delegate) });
            }

            if (efl_gfx_buffer_managed_set_static_delegate == null)
            {
                efl_gfx_buffer_managed_set_static_delegate = new efl_gfx_buffer_managed_set_delegate(buffer_managed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBufferManaged") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_managed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_managed_set_static_delegate) });
            }

            if (efl_gfx_buffer_managed_get_static_delegate == null)
            {
                efl_gfx_buffer_managed_get_static_delegate = new efl_gfx_buffer_managed_get_delegate(buffer_managed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBufferManaged") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_managed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_managed_get_static_delegate) });
            }

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
            return Efl.Gfx.BufferConcrete.efl_gfx_buffer_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_buffer_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_buffer_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_get_api_delegate> efl_gfx_buffer_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_get_api_delegate>(Module, "efl_gfx_buffer_size_get");

        private static Eina.Size2D.NativeStruct buffer_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_buffer_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IBuffer)ws.Target).GetBufferSize();
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
                return efl_gfx_buffer_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_buffer_size_get_delegate efl_gfx_buffer_size_get_static_delegate;

        
        private delegate void efl_gfx_buffer_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_buffer_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_set_api_delegate> efl_gfx_buffer_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_set_api_delegate>(Module, "efl_gfx_buffer_size_set");

        private static void buffer_size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_buffer_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Size2D _in_sz = sz;

                try
                {
                    ((IBuffer)ws.Target).SetBufferSize(_in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_buffer_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_gfx_buffer_size_set_delegate efl_gfx_buffer_size_set_static_delegate;

        
        private delegate Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_colorspace_get_api_delegate> efl_gfx_buffer_colorspace_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_colorspace_get_api_delegate>(Module, "efl_gfx_buffer_colorspace_get");

        private static Efl.Gfx.Colorspace colorspace_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_buffer_colorspace_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Gfx.Colorspace _ret_var = default(Efl.Gfx.Colorspace);
                try
                {
                    _ret_var = ((IBuffer)ws.Target).GetColorspace();
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
                return efl_gfx_buffer_colorspace_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_buffer_colorspace_get_delegate efl_gfx_buffer_colorspace_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_buffer_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_buffer_alpha_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_get_api_delegate> efl_gfx_buffer_alpha_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_get_api_delegate>(Module, "efl_gfx_buffer_alpha_get");

        private static bool alpha_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_buffer_alpha_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IBuffer)ws.Target).GetAlpha();
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
                return efl_gfx_buffer_alpha_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_buffer_alpha_get_delegate efl_gfx_buffer_alpha_get_static_delegate;

        
        private delegate void efl_gfx_buffer_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool alpha);

        
        public delegate void efl_gfx_buffer_alpha_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool alpha);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_set_api_delegate> efl_gfx_buffer_alpha_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_set_api_delegate>(Module, "efl_gfx_buffer_alpha_set");

        private static void alpha_set(System.IntPtr obj, System.IntPtr pd, bool alpha)
        {
            Eina.Log.Debug("function efl_gfx_buffer_alpha_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IBuffer)ws.Target).SetAlpha(alpha);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_buffer_alpha_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), alpha);
            }
        }

        private static efl_gfx_buffer_alpha_set_delegate efl_gfx_buffer_alpha_set_static_delegate;

        
        private delegate int efl_gfx_buffer_stride_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_buffer_stride_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_stride_get_api_delegate> efl_gfx_buffer_stride_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_stride_get_api_delegate>(Module, "efl_gfx_buffer_stride_get");

        private static int stride_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_buffer_stride_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IBuffer)ws.Target).GetStride();
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
                return efl_gfx_buffer_stride_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_buffer_stride_get_delegate efl_gfx_buffer_stride_get_static_delegate;

        
        private delegate void efl_gfx_buffer_borders_get_delegate(System.IntPtr obj, System.IntPtr pd,  out uint l,  out uint r,  out uint t,  out uint b);

        
        public delegate void efl_gfx_buffer_borders_get_api_delegate(System.IntPtr obj,  out uint l,  out uint r,  out uint t,  out uint b);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_borders_get_api_delegate> efl_gfx_buffer_borders_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_borders_get_api_delegate>(Module, "efl_gfx_buffer_borders_get");

        private static void buffer_borders_get(System.IntPtr obj, System.IntPtr pd, out uint l, out uint r, out uint t, out uint b)
        {
            Eina.Log.Debug("function efl_gfx_buffer_borders_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                l = default(uint);r = default(uint);t = default(uint);b = default(uint);
                try
                {
                    ((IBuffer)ws.Target).GetBufferBorders(out l, out r, out t, out b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_buffer_borders_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out l, out r, out t, out b);
            }
        }

        private static efl_gfx_buffer_borders_get_delegate efl_gfx_buffer_borders_get_static_delegate;

        
        private delegate void efl_gfx_buffer_update_add_delegate(System.IntPtr obj, System.IntPtr pd,  ref Eina.Rect.NativeStruct region);

        
        public delegate void efl_gfx_buffer_update_add_api_delegate(System.IntPtr obj,  ref Eina.Rect.NativeStruct region);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_update_add_api_delegate> efl_gfx_buffer_update_add_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_update_add_api_delegate>(Module, "efl_gfx_buffer_update_add");

        private static void buffer_update_add(System.IntPtr obj, System.IntPtr pd, ref Eina.Rect.NativeStruct region)
        {
            Eina.Log.Debug("function efl_gfx_buffer_update_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Rect _in_region = region;

                try
                {
                    ((IBuffer)ws.Target).AddBufferUpdate(ref _in_region);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        region = _in_region;
        
            }
            else
            {
                efl_gfx_buffer_update_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref region);
            }
        }

        private static efl_gfx_buffer_update_add_delegate efl_gfx_buffer_update_add_static_delegate;

        
        private delegate Eina.RwSlice efl_gfx_buffer_map_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.BufferAccessMode mode,  ref Eina.Rect.NativeStruct region,  Efl.Gfx.Colorspace cspace,  int plane,  out int stride);

        
        public delegate Eina.RwSlice efl_gfx_buffer_map_api_delegate(System.IntPtr obj,  Efl.Gfx.BufferAccessMode mode,  ref Eina.Rect.NativeStruct region,  Efl.Gfx.Colorspace cspace,  int plane,  out int stride);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_map_api_delegate> efl_gfx_buffer_map_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_map_api_delegate>(Module, "efl_gfx_buffer_map");

        private static Eina.RwSlice buffer_map(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.BufferAccessMode mode, ref Eina.Rect.NativeStruct region, Efl.Gfx.Colorspace cspace, int plane, out int stride)
        {
            Eina.Log.Debug("function efl_gfx_buffer_map was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Rect _in_region = region;
stride = default(int);Eina.RwSlice _ret_var = default(Eina.RwSlice);
                try
                {
                    _ret_var = ((IBuffer)ws.Target).BufferMap(mode, ref _in_region, cspace, plane, out stride);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        region = _in_region;
        return _ret_var;
            }
            else
            {
                return efl_gfx_buffer_map_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode, ref region, cspace, plane, out stride);
            }
        }

        private static efl_gfx_buffer_map_delegate efl_gfx_buffer_map_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_buffer_unmap_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.RwSlice slice);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_buffer_unmap_api_delegate(System.IntPtr obj,  Eina.RwSlice slice);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_unmap_api_delegate> efl_gfx_buffer_unmap_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_unmap_api_delegate>(Module, "efl_gfx_buffer_unmap");

        private static bool buffer_unmap(System.IntPtr obj, System.IntPtr pd, Eina.RwSlice slice)
        {
            Eina.Log.Debug("function efl_gfx_buffer_unmap was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IBuffer)ws.Target).BufferUnmap(slice);
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
                return efl_gfx_buffer_unmap_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), slice);
            }
        }

        private static efl_gfx_buffer_unmap_delegate efl_gfx_buffer_unmap_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_buffer_copy_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr slice,  Eina.Size2D.NativeStruct size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_buffer_copy_set_api_delegate(System.IntPtr obj,  System.IntPtr slice,  Eina.Size2D.NativeStruct size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_copy_set_api_delegate> efl_gfx_buffer_copy_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_copy_set_api_delegate>(Module, "efl_gfx_buffer_copy_set");

        private static bool buffer_copy_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr slice, Eina.Size2D.NativeStruct size, int stride, Efl.Gfx.Colorspace cspace, int plane)
        {
            Eina.Log.Debug("function efl_gfx_buffer_copy_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_slice = Eina.PrimitiveConversion.PointerToManaged<Eina.Slice>(slice);
Eina.Size2D _in_size = size;
bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IBuffer)ws.Target).SetBufferCopy(_in_slice, _in_size, stride, cspace, plane);
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
                return efl_gfx_buffer_copy_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), slice, size, stride, cspace, plane);
            }
        }

        private static efl_gfx_buffer_copy_set_delegate efl_gfx_buffer_copy_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_buffer_managed_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr slice,  Eina.Size2D.NativeStruct size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_buffer_managed_set_api_delegate(System.IntPtr obj,  System.IntPtr slice,  Eina.Size2D.NativeStruct size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_set_api_delegate> efl_gfx_buffer_managed_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_set_api_delegate>(Module, "efl_gfx_buffer_managed_set");

        private static bool buffer_managed_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr slice, Eina.Size2D.NativeStruct size, int stride, Efl.Gfx.Colorspace cspace, int plane)
        {
            Eina.Log.Debug("function efl_gfx_buffer_managed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_slice = Eina.PrimitiveConversion.PointerToManaged<Eina.Slice>(slice);
Eina.Size2D _in_size = size;
bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IBuffer)ws.Target).SetBufferManaged(_in_slice, _in_size, stride, cspace, plane);
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
                return efl_gfx_buffer_managed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), slice, size, stride, cspace, plane);
            }
        }

        private static efl_gfx_buffer_managed_set_delegate efl_gfx_buffer_managed_set_static_delegate;

        
        private delegate Eina.Slice efl_gfx_buffer_managed_get_delegate(System.IntPtr obj, System.IntPtr pd,  int plane);

        
        public delegate Eina.Slice efl_gfx_buffer_managed_get_api_delegate(System.IntPtr obj,  int plane);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_get_api_delegate> efl_gfx_buffer_managed_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_get_api_delegate>(Module, "efl_gfx_buffer_managed_get");

        private static Eina.Slice buffer_managed_get(System.IntPtr obj, System.IntPtr pd, int plane)
        {
            Eina.Log.Debug("function efl_gfx_buffer_managed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Slice _ret_var = default(Eina.Slice);
                try
                {
                    _ret_var = ((IBuffer)ws.Target).GetBufferManaged(plane);
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
                return efl_gfx_buffer_managed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), plane);
            }
        }

        private static efl_gfx_buffer_managed_get_delegate efl_gfx_buffer_managed_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxBufferConcrete_ExtensionMethods {
    public static Efl.BindableProperty<Eina.Size2D> BufferSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IBuffer, T>magic = null) where T : Efl.Gfx.IBuffer {
        return new Efl.BindableProperty<Eina.Size2D>("buffer_size", fac);
    }

    public static Efl.BindableProperty<bool> Alpha<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IBuffer, T>magic = null) where T : Efl.Gfx.IBuffer {
        return new Efl.BindableProperty<bool>("alpha", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Gfx {

/// <summary>Graphics buffer access mode</summary>
[Efl.Eo.BindingEntity]
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
}
}

