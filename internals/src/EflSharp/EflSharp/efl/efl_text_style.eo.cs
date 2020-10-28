#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Style to apply to the text
/// A style can be coloring, effects, underline, strikethrough etc.</summary>
[ITextStyleNativeInherit]
public interface ITextStyle : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Color of text, excluding style</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void GetNormalColor( out byte r,  out byte g,  out byte b,  out byte a);
    /// <summary>Color of text, excluding style</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void SetNormalColor( byte r,  byte g,  byte b,  byte a);
    /// <summary>Enable or disable backing type</summary>
/// <returns>Backing type</returns>
Efl.TextStyleBackingType GetBackingType();
    /// <summary>Enable or disable backing type</summary>
/// <param name="type">Backing type</param>
/// <returns></returns>
void SetBackingType( Efl.TextStyleBackingType type);
    /// <summary>Backing color</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void GetBackingColor( out byte r,  out byte g,  out byte b,  out byte a);
    /// <summary>Backing color</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void SetBackingColor( byte r,  byte g,  byte b,  byte a);
    /// <summary>Sets an underline style on the text</summary>
/// <returns>Underline type</returns>
Efl.TextStyleUnderlineType GetUnderlineType();
    /// <summary>Sets an underline style on the text</summary>
/// <param name="type">Underline type</param>
/// <returns></returns>
void SetUnderlineType( Efl.TextStyleUnderlineType type);
    /// <summary>Color of normal underline style</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void GetUnderlineColor( out byte r,  out byte g,  out byte b,  out byte a);
    /// <summary>Color of normal underline style</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void SetUnderlineColor( byte r,  byte g,  byte b,  byte a);
    /// <summary>Height of underline style</summary>
/// <returns>Height</returns>
double GetUnderlineHeight();
    /// <summary>Height of underline style</summary>
/// <param name="height">Height</param>
/// <returns></returns>
void SetUnderlineHeight( double height);
    /// <summary>Color of dashed underline style</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void GetUnderlineDashedColor( out byte r,  out byte g,  out byte b,  out byte a);
    /// <summary>Color of dashed underline style</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void SetUnderlineDashedColor( byte r,  byte g,  byte b,  byte a);
    /// <summary>Width of dashed underline style</summary>
/// <returns>Width</returns>
int GetUnderlineDashedWidth();
    /// <summary>Width of dashed underline style</summary>
/// <param name="width">Width</param>
/// <returns></returns>
void SetUnderlineDashedWidth( int width);
    /// <summary>Gap of dashed underline style</summary>
/// <returns>Gap</returns>
int GetUnderlineDashedGap();
    /// <summary>Gap of dashed underline style</summary>
/// <param name="gap">Gap</param>
/// <returns></returns>
void SetUnderlineDashedGap( int gap);
    /// <summary>Color of underline2 style</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void GetUnderline2Color( out byte r,  out byte g,  out byte b,  out byte a);
    /// <summary>Color of underline2 style</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void SetUnderline2Color( byte r,  byte g,  byte b,  byte a);
    /// <summary>Type of strikethrough style</summary>
/// <returns>Strikethrough type</returns>
Efl.TextStyleStrikethroughType GetStrikethroughType();
    /// <summary>Type of strikethrough style</summary>
/// <param name="type">Strikethrough type</param>
/// <returns></returns>
void SetStrikethroughType( Efl.TextStyleStrikethroughType type);
    /// <summary>Color of strikethrough_style</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void GetStrikethroughColor( out byte r,  out byte g,  out byte b,  out byte a);
    /// <summary>Color of strikethrough_style</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void SetStrikethroughColor( byte r,  byte g,  byte b,  byte a);
    /// <summary>Type of effect used for the displayed text</summary>
/// <returns>Effect type</returns>
Efl.TextStyleEffectType GetEffectType();
    /// <summary>Type of effect used for the displayed text</summary>
/// <param name="type">Effect type</param>
/// <returns></returns>
void SetEffectType( Efl.TextStyleEffectType type);
    /// <summary>Color of outline effect</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void GetOutlineColor( out byte r,  out byte g,  out byte b,  out byte a);
    /// <summary>Color of outline effect</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void SetOutlineColor( byte r,  byte g,  byte b,  byte a);
    /// <summary>Direction of shadow effect</summary>
/// <returns>Shadow direction</returns>
Efl.TextStyleShadowDirection GetShadowDirection();
    /// <summary>Direction of shadow effect</summary>
/// <param name="type">Shadow direction</param>
/// <returns></returns>
void SetShadowDirection( Efl.TextStyleShadowDirection type);
    /// <summary>Color of shadow effect</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void GetShadowColor( out byte r,  out byte g,  out byte b,  out byte a);
    /// <summary>Color of shadow effect</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void SetShadowColor( byte r,  byte g,  byte b,  byte a);
    /// <summary>Color of glow effect</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void GetGlowColor( out byte r,  out byte g,  out byte b,  out byte a);
    /// <summary>Color of glow effect</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void SetGlowColor( byte r,  byte g,  byte b,  byte a);
    /// <summary>Second color of the glow effect</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void GetGlow2Color( out byte r,  out byte g,  out byte b,  out byte a);
    /// <summary>Second color of the glow effect</summary>
/// <param name="r">Red component</param>
/// <param name="g">Green component</param>
/// <param name="b">Blue component</param>
/// <param name="a">Alpha component</param>
/// <returns></returns>
void SetGlow2Color( byte r,  byte g,  byte b,  byte a);
    /// <summary>Program that applies a special filter
/// See <see cref="Efl.Gfx.IFilter"/>.</summary>
/// <returns>Filter code</returns>
System.String GetGfxFilter();
    /// <summary>Program that applies a special filter
/// See <see cref="Efl.Gfx.IFilter"/>.</summary>
/// <param name="code">Filter code</param>
/// <returns></returns>
void SetGfxFilter( System.String code);
                                                                                                                                                            /// <summary>Enable or disable backing type</summary>
/// <value>Backing type</value>
    Efl.TextStyleBackingType BackingType {
        get ;
        set ;
    }
    /// <summary>Sets an underline style on the text</summary>
/// <value>Underline type</value>
    Efl.TextStyleUnderlineType UnderlineType {
        get ;
        set ;
    }
    /// <summary>Height of underline style</summary>
/// <value>Height</value>
    double UnderlineHeight {
        get ;
        set ;
    }
    /// <summary>Width of dashed underline style</summary>
/// <value>Width</value>
    int UnderlineDashedWidth {
        get ;
        set ;
    }
    /// <summary>Gap of dashed underline style</summary>
/// <value>Gap</value>
    int UnderlineDashedGap {
        get ;
        set ;
    }
    /// <summary>Type of strikethrough style</summary>
/// <value>Strikethrough type</value>
    Efl.TextStyleStrikethroughType StrikethroughType {
        get ;
        set ;
    }
    /// <summary>Type of effect used for the displayed text</summary>
/// <value>Effect type</value>
    Efl.TextStyleEffectType EffectType {
        get ;
        set ;
    }
    /// <summary>Direction of shadow effect</summary>
/// <value>Shadow direction</value>
    Efl.TextStyleShadowDirection ShadowDirection {
        get ;
        set ;
    }
    /// <summary>Program that applies a special filter
/// See <see cref="Efl.Gfx.IFilter"/>.</summary>
/// <value>Filter code</value>
    System.String GfxFilter {
        get ;
        set ;
    }
}
/// <summary>Style to apply to the text
/// A style can be coloring, effects, underline, strikethrough etc.</summary>
sealed public class ITextStyleConcrete : 

ITextStyle
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (ITextStyleConcrete))
                return Efl.ITextStyleNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_text_style_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private ITextStyleConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~ITextStyleConcrete()
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
        Dispose(true);
        GC.SuppressFinalize(this);
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
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
    }
    /// <summary>Color of text, excluding style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void GetNormalColor( out byte r,  out byte g,  out byte b,  out byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_normal_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of text, excluding style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void SetNormalColor( byte r,  byte g,  byte b,  byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_normal_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Enable or disable backing type</summary>
    /// <returns>Backing type</returns>
    public Efl.TextStyleBackingType GetBackingType() {
         var _ret_var = Efl.ITextStyleNativeInherit.efl_text_backing_type_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable or disable backing type</summary>
    /// <param name="type">Backing type</param>
    /// <returns></returns>
    public void SetBackingType( Efl.TextStyleBackingType type) {
                                 Efl.ITextStyleNativeInherit.efl_text_backing_type_set_ptr.Value.Delegate(this.NativeHandle, type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Backing color</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void GetBackingColor( out byte r,  out byte g,  out byte b,  out byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_backing_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Backing color</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void SetBackingColor( byte r,  byte g,  byte b,  byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_backing_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Sets an underline style on the text</summary>
    /// <returns>Underline type</returns>
    public Efl.TextStyleUnderlineType GetUnderlineType() {
         var _ret_var = Efl.ITextStyleNativeInherit.efl_text_underline_type_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets an underline style on the text</summary>
    /// <param name="type">Underline type</param>
    /// <returns></returns>
    public void SetUnderlineType( Efl.TextStyleUnderlineType type) {
                                 Efl.ITextStyleNativeInherit.efl_text_underline_type_set_ptr.Value.Delegate(this.NativeHandle, type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of normal underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void GetUnderlineColor( out byte r,  out byte g,  out byte b,  out byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_underline_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of normal underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void SetUnderlineColor( byte r,  byte g,  byte b,  byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_underline_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Height of underline style</summary>
    /// <returns>Height</returns>
    public double GetUnderlineHeight() {
         var _ret_var = Efl.ITextStyleNativeInherit.efl_text_underline_height_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Height of underline style</summary>
    /// <param name="height">Height</param>
    /// <returns></returns>
    public void SetUnderlineHeight( double height) {
                                 Efl.ITextStyleNativeInherit.efl_text_underline_height_set_ptr.Value.Delegate(this.NativeHandle, height);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of dashed underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void GetUnderlineDashedColor( out byte r,  out byte g,  out byte b,  out byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_underline_dashed_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of dashed underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void SetUnderlineDashedColor( byte r,  byte g,  byte b,  byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_underline_dashed_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Width of dashed underline style</summary>
    /// <returns>Width</returns>
    public int GetUnderlineDashedWidth() {
         var _ret_var = Efl.ITextStyleNativeInherit.efl_text_underline_dashed_width_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Width of dashed underline style</summary>
    /// <param name="width">Width</param>
    /// <returns></returns>
    public void SetUnderlineDashedWidth( int width) {
                                 Efl.ITextStyleNativeInherit.efl_text_underline_dashed_width_set_ptr.Value.Delegate(this.NativeHandle, width);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gap of dashed underline style</summary>
    /// <returns>Gap</returns>
    public int GetUnderlineDashedGap() {
         var _ret_var = Efl.ITextStyleNativeInherit.efl_text_underline_dashed_gap_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gap of dashed underline style</summary>
    /// <param name="gap">Gap</param>
    /// <returns></returns>
    public void SetUnderlineDashedGap( int gap) {
                                 Efl.ITextStyleNativeInherit.efl_text_underline_dashed_gap_set_ptr.Value.Delegate(this.NativeHandle, gap);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of underline2 style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void GetUnderline2Color( out byte r,  out byte g,  out byte b,  out byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_underline2_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of underline2 style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void SetUnderline2Color( byte r,  byte g,  byte b,  byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_underline2_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Type of strikethrough style</summary>
    /// <returns>Strikethrough type</returns>
    public Efl.TextStyleStrikethroughType GetStrikethroughType() {
         var _ret_var = Efl.ITextStyleNativeInherit.efl_text_strikethrough_type_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of strikethrough style</summary>
    /// <param name="type">Strikethrough type</param>
    /// <returns></returns>
    public void SetStrikethroughType( Efl.TextStyleStrikethroughType type) {
                                 Efl.ITextStyleNativeInherit.efl_text_strikethrough_type_set_ptr.Value.Delegate(this.NativeHandle, type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of strikethrough_style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void GetStrikethroughColor( out byte r,  out byte g,  out byte b,  out byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_strikethrough_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of strikethrough_style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void SetStrikethroughColor( byte r,  byte g,  byte b,  byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_strikethrough_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <returns>Effect type</returns>
    public Efl.TextStyleEffectType GetEffectType() {
         var _ret_var = Efl.ITextStyleNativeInherit.efl_text_effect_type_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <param name="type">Effect type</param>
    /// <returns></returns>
    public void SetEffectType( Efl.TextStyleEffectType type) {
                                 Efl.ITextStyleNativeInherit.efl_text_effect_type_set_ptr.Value.Delegate(this.NativeHandle, type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of outline effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void GetOutlineColor( out byte r,  out byte g,  out byte b,  out byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_outline_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of outline effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void SetOutlineColor( byte r,  byte g,  byte b,  byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_outline_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Direction of shadow effect</summary>
    /// <returns>Shadow direction</returns>
    public Efl.TextStyleShadowDirection GetShadowDirection() {
         var _ret_var = Efl.ITextStyleNativeInherit.efl_text_shadow_direction_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Direction of shadow effect</summary>
    /// <param name="type">Shadow direction</param>
    /// <returns></returns>
    public void SetShadowDirection( Efl.TextStyleShadowDirection type) {
                                 Efl.ITextStyleNativeInherit.efl_text_shadow_direction_set_ptr.Value.Delegate(this.NativeHandle, type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of shadow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void GetShadowColor( out byte r,  out byte g,  out byte b,  out byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_shadow_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of shadow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void SetShadowColor( byte r,  byte g,  byte b,  byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_shadow_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void GetGlowColor( out byte r,  out byte g,  out byte b,  out byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_glow_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void SetGlowColor( byte r,  byte g,  byte b,  byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_glow_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Second color of the glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void GetGlow2Color( out byte r,  out byte g,  out byte b,  out byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_glow2_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Second color of the glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    /// <returns></returns>
    public void SetGlow2Color( byte r,  byte g,  byte b,  byte a) {
                                                                                                         Efl.ITextStyleNativeInherit.efl_text_glow2_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <returns>Filter code</returns>
    public System.String GetGfxFilter() {
         var _ret_var = Efl.ITextStyleNativeInherit.efl_text_gfx_filter_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <param name="code">Filter code</param>
    /// <returns></returns>
    public void SetGfxFilter( System.String code) {
                                 Efl.ITextStyleNativeInherit.efl_text_gfx_filter_set_ptr.Value.Delegate(this.NativeHandle, code);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Enable or disable backing type</summary>
/// <value>Backing type</value>
    public Efl.TextStyleBackingType BackingType {
        get { return GetBackingType(); }
        set { SetBackingType( value); }
    }
    /// <summary>Sets an underline style on the text</summary>
/// <value>Underline type</value>
    public Efl.TextStyleUnderlineType UnderlineType {
        get { return GetUnderlineType(); }
        set { SetUnderlineType( value); }
    }
    /// <summary>Height of underline style</summary>
/// <value>Height</value>
    public double UnderlineHeight {
        get { return GetUnderlineHeight(); }
        set { SetUnderlineHeight( value); }
    }
    /// <summary>Width of dashed underline style</summary>
/// <value>Width</value>
    public int UnderlineDashedWidth {
        get { return GetUnderlineDashedWidth(); }
        set { SetUnderlineDashedWidth( value); }
    }
    /// <summary>Gap of dashed underline style</summary>
/// <value>Gap</value>
    public int UnderlineDashedGap {
        get { return GetUnderlineDashedGap(); }
        set { SetUnderlineDashedGap( value); }
    }
    /// <summary>Type of strikethrough style</summary>
/// <value>Strikethrough type</value>
    public Efl.TextStyleStrikethroughType StrikethroughType {
        get { return GetStrikethroughType(); }
        set { SetStrikethroughType( value); }
    }
    /// <summary>Type of effect used for the displayed text</summary>
/// <value>Effect type</value>
    public Efl.TextStyleEffectType EffectType {
        get { return GetEffectType(); }
        set { SetEffectType( value); }
    }
    /// <summary>Direction of shadow effect</summary>
/// <value>Shadow direction</value>
    public Efl.TextStyleShadowDirection ShadowDirection {
        get { return GetShadowDirection(); }
        set { SetShadowDirection( value); }
    }
    /// <summary>Program that applies a special filter
/// See <see cref="Efl.Gfx.IFilter"/>.</summary>
/// <value>Filter code</value>
    public System.String GfxFilter {
        get { return GetGfxFilter(); }
        set { SetGfxFilter( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.ITextStyleConcrete.efl_text_style_interface_get();
    }
}
public class ITextStyleNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_text_normal_color_get_static_delegate == null)
            efl_text_normal_color_get_static_delegate = new efl_text_normal_color_get_delegate(normal_color_get);
        if (methods.FirstOrDefault(m => m.Name == "GetNormalColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_normal_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_get_static_delegate)});
        if (efl_text_normal_color_set_static_delegate == null)
            efl_text_normal_color_set_static_delegate = new efl_text_normal_color_set_delegate(normal_color_set);
        if (methods.FirstOrDefault(m => m.Name == "SetNormalColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_normal_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_set_static_delegate)});
        if (efl_text_backing_type_get_static_delegate == null)
            efl_text_backing_type_get_static_delegate = new efl_text_backing_type_get_delegate(backing_type_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBackingType") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_get_static_delegate)});
        if (efl_text_backing_type_set_static_delegate == null)
            efl_text_backing_type_set_static_delegate = new efl_text_backing_type_set_delegate(backing_type_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBackingType") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_set_static_delegate)});
        if (efl_text_backing_color_get_static_delegate == null)
            efl_text_backing_color_get_static_delegate = new efl_text_backing_color_get_delegate(backing_color_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBackingColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_get_static_delegate)});
        if (efl_text_backing_color_set_static_delegate == null)
            efl_text_backing_color_set_static_delegate = new efl_text_backing_color_set_delegate(backing_color_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBackingColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_backing_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_set_static_delegate)});
        if (efl_text_underline_type_get_static_delegate == null)
            efl_text_underline_type_get_static_delegate = new efl_text_underline_type_get_delegate(underline_type_get);
        if (methods.FirstOrDefault(m => m.Name == "GetUnderlineType") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_get_static_delegate)});
        if (efl_text_underline_type_set_static_delegate == null)
            efl_text_underline_type_set_static_delegate = new efl_text_underline_type_set_delegate(underline_type_set);
        if (methods.FirstOrDefault(m => m.Name == "SetUnderlineType") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_set_static_delegate)});
        if (efl_text_underline_color_get_static_delegate == null)
            efl_text_underline_color_get_static_delegate = new efl_text_underline_color_get_delegate(underline_color_get);
        if (methods.FirstOrDefault(m => m.Name == "GetUnderlineColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_get_static_delegate)});
        if (efl_text_underline_color_set_static_delegate == null)
            efl_text_underline_color_set_static_delegate = new efl_text_underline_color_set_delegate(underline_color_set);
        if (methods.FirstOrDefault(m => m.Name == "SetUnderlineColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_set_static_delegate)});
        if (efl_text_underline_height_get_static_delegate == null)
            efl_text_underline_height_get_static_delegate = new efl_text_underline_height_get_delegate(underline_height_get);
        if (methods.FirstOrDefault(m => m.Name == "GetUnderlineHeight") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_height_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_get_static_delegate)});
        if (efl_text_underline_height_set_static_delegate == null)
            efl_text_underline_height_set_static_delegate = new efl_text_underline_height_set_delegate(underline_height_set);
        if (methods.FirstOrDefault(m => m.Name == "SetUnderlineHeight") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_height_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_set_static_delegate)});
        if (efl_text_underline_dashed_color_get_static_delegate == null)
            efl_text_underline_dashed_color_get_static_delegate = new efl_text_underline_dashed_color_get_delegate(underline_dashed_color_get);
        if (methods.FirstOrDefault(m => m.Name == "GetUnderlineDashedColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_get_static_delegate)});
        if (efl_text_underline_dashed_color_set_static_delegate == null)
            efl_text_underline_dashed_color_set_static_delegate = new efl_text_underline_dashed_color_set_delegate(underline_dashed_color_set);
        if (methods.FirstOrDefault(m => m.Name == "SetUnderlineDashedColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_set_static_delegate)});
        if (efl_text_underline_dashed_width_get_static_delegate == null)
            efl_text_underline_dashed_width_get_static_delegate = new efl_text_underline_dashed_width_get_delegate(underline_dashed_width_get);
        if (methods.FirstOrDefault(m => m.Name == "GetUnderlineDashedWidth") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_get_static_delegate)});
        if (efl_text_underline_dashed_width_set_static_delegate == null)
            efl_text_underline_dashed_width_set_static_delegate = new efl_text_underline_dashed_width_set_delegate(underline_dashed_width_set);
        if (methods.FirstOrDefault(m => m.Name == "SetUnderlineDashedWidth") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_set_static_delegate)});
        if (efl_text_underline_dashed_gap_get_static_delegate == null)
            efl_text_underline_dashed_gap_get_static_delegate = new efl_text_underline_dashed_gap_get_delegate(underline_dashed_gap_get);
        if (methods.FirstOrDefault(m => m.Name == "GetUnderlineDashedGap") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_gap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_get_static_delegate)});
        if (efl_text_underline_dashed_gap_set_static_delegate == null)
            efl_text_underline_dashed_gap_set_static_delegate = new efl_text_underline_dashed_gap_set_delegate(underline_dashed_gap_set);
        if (methods.FirstOrDefault(m => m.Name == "SetUnderlineDashedGap") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline_dashed_gap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_set_static_delegate)});
        if (efl_text_underline2_color_get_static_delegate == null)
            efl_text_underline2_color_get_static_delegate = new efl_text_underline2_color_get_delegate(underline2_color_get);
        if (methods.FirstOrDefault(m => m.Name == "GetUnderline2Color") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_get_static_delegate)});
        if (efl_text_underline2_color_set_static_delegate == null)
            efl_text_underline2_color_set_static_delegate = new efl_text_underline2_color_set_delegate(underline2_color_set);
        if (methods.FirstOrDefault(m => m.Name == "SetUnderline2Color") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_underline2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_set_static_delegate)});
        if (efl_text_strikethrough_type_get_static_delegate == null)
            efl_text_strikethrough_type_get_static_delegate = new efl_text_strikethrough_type_get_delegate(strikethrough_type_get);
        if (methods.FirstOrDefault(m => m.Name == "GetStrikethroughType") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_get_static_delegate)});
        if (efl_text_strikethrough_type_set_static_delegate == null)
            efl_text_strikethrough_type_set_static_delegate = new efl_text_strikethrough_type_set_delegate(strikethrough_type_set);
        if (methods.FirstOrDefault(m => m.Name == "SetStrikethroughType") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_set_static_delegate)});
        if (efl_text_strikethrough_color_get_static_delegate == null)
            efl_text_strikethrough_color_get_static_delegate = new efl_text_strikethrough_color_get_delegate(strikethrough_color_get);
        if (methods.FirstOrDefault(m => m.Name == "GetStrikethroughColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_get_static_delegate)});
        if (efl_text_strikethrough_color_set_static_delegate == null)
            efl_text_strikethrough_color_set_static_delegate = new efl_text_strikethrough_color_set_delegate(strikethrough_color_set);
        if (methods.FirstOrDefault(m => m.Name == "SetStrikethroughColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_strikethrough_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_set_static_delegate)});
        if (efl_text_effect_type_get_static_delegate == null)
            efl_text_effect_type_get_static_delegate = new efl_text_effect_type_get_delegate(effect_type_get);
        if (methods.FirstOrDefault(m => m.Name == "GetEffectType") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_effect_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_get_static_delegate)});
        if (efl_text_effect_type_set_static_delegate == null)
            efl_text_effect_type_set_static_delegate = new efl_text_effect_type_set_delegate(effect_type_set);
        if (methods.FirstOrDefault(m => m.Name == "SetEffectType") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_effect_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_set_static_delegate)});
        if (efl_text_outline_color_get_static_delegate == null)
            efl_text_outline_color_get_static_delegate = new efl_text_outline_color_get_delegate(outline_color_get);
        if (methods.FirstOrDefault(m => m.Name == "GetOutlineColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_outline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_get_static_delegate)});
        if (efl_text_outline_color_set_static_delegate == null)
            efl_text_outline_color_set_static_delegate = new efl_text_outline_color_set_delegate(outline_color_set);
        if (methods.FirstOrDefault(m => m.Name == "SetOutlineColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_outline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_set_static_delegate)});
        if (efl_text_shadow_direction_get_static_delegate == null)
            efl_text_shadow_direction_get_static_delegate = new efl_text_shadow_direction_get_delegate(shadow_direction_get);
        if (methods.FirstOrDefault(m => m.Name == "GetShadowDirection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_get_static_delegate)});
        if (efl_text_shadow_direction_set_static_delegate == null)
            efl_text_shadow_direction_set_static_delegate = new efl_text_shadow_direction_set_delegate(shadow_direction_set);
        if (methods.FirstOrDefault(m => m.Name == "SetShadowDirection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_set_static_delegate)});
        if (efl_text_shadow_color_get_static_delegate == null)
            efl_text_shadow_color_get_static_delegate = new efl_text_shadow_color_get_delegate(shadow_color_get);
        if (methods.FirstOrDefault(m => m.Name == "GetShadowColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_get_static_delegate)});
        if (efl_text_shadow_color_set_static_delegate == null)
            efl_text_shadow_color_set_static_delegate = new efl_text_shadow_color_set_delegate(shadow_color_set);
        if (methods.FirstOrDefault(m => m.Name == "SetShadowColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_shadow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_set_static_delegate)});
        if (efl_text_glow_color_get_static_delegate == null)
            efl_text_glow_color_get_static_delegate = new efl_text_glow_color_get_delegate(glow_color_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGlowColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_get_static_delegate)});
        if (efl_text_glow_color_set_static_delegate == null)
            efl_text_glow_color_set_static_delegate = new efl_text_glow_color_set_delegate(glow_color_set);
        if (methods.FirstOrDefault(m => m.Name == "SetGlowColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_set_static_delegate)});
        if (efl_text_glow2_color_get_static_delegate == null)
            efl_text_glow2_color_get_static_delegate = new efl_text_glow2_color_get_delegate(glow2_color_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGlow2Color") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_get_static_delegate)});
        if (efl_text_glow2_color_set_static_delegate == null)
            efl_text_glow2_color_set_static_delegate = new efl_text_glow2_color_set_delegate(glow2_color_set);
        if (methods.FirstOrDefault(m => m.Name == "SetGlow2Color") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_glow2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_set_static_delegate)});
        if (efl_text_gfx_filter_get_static_delegate == null)
            efl_text_gfx_filter_get_static_delegate = new efl_text_gfx_filter_get_delegate(gfx_filter_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGfxFilter") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_gfx_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_get_static_delegate)});
        if (efl_text_gfx_filter_set_static_delegate == null)
            efl_text_gfx_filter_set_static_delegate = new efl_text_gfx_filter_set_delegate(gfx_filter_set);
        if (methods.FirstOrDefault(m => m.Name == "SetGfxFilter") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_gfx_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_set_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.ITextStyleConcrete.efl_text_style_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.ITextStyleConcrete.efl_text_style_interface_get();
    }


     private delegate void efl_text_normal_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out byte r,   out byte g,   out byte b,   out byte a);


     public delegate void efl_text_normal_color_get_api_delegate(System.IntPtr obj,   out byte r,   out byte g,   out byte b,   out byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_normal_color_get_api_delegate> efl_text_normal_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_normal_color_get_api_delegate>(_Module, "efl_text_normal_color_get");
     private static void normal_color_get(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a)
    {
        Eina.Log.Debug("function efl_text_normal_color_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
            try {
                ((ITextStyle)wrapper).GetNormalColor( out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_normal_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
        }
    }
    private static efl_text_normal_color_get_delegate efl_text_normal_color_get_static_delegate;


     private delegate void efl_text_normal_color_set_delegate(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a);


     public delegate void efl_text_normal_color_set_api_delegate(System.IntPtr obj,   byte r,   byte g,   byte b,   byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_normal_color_set_api_delegate> efl_text_normal_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_normal_color_set_api_delegate>(_Module, "efl_text_normal_color_set");
     private static void normal_color_set(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a)
    {
        Eina.Log.Debug("function efl_text_normal_color_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((ITextStyle)wrapper).SetNormalColor( r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_normal_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
        }
    }
    private static efl_text_normal_color_set_delegate efl_text_normal_color_set_static_delegate;


     private delegate Efl.TextStyleBackingType efl_text_backing_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.TextStyleBackingType efl_text_backing_type_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_text_backing_type_get_api_delegate> efl_text_backing_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_type_get_api_delegate>(_Module, "efl_text_backing_type_get");
     private static Efl.TextStyleBackingType backing_type_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_text_backing_type_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.TextStyleBackingType _ret_var = default(Efl.TextStyleBackingType);
            try {
                _ret_var = ((ITextStyle)wrapper).GetBackingType();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_text_backing_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_text_backing_type_get_delegate efl_text_backing_type_get_static_delegate;


     private delegate void efl_text_backing_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleBackingType type);


     public delegate void efl_text_backing_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleBackingType type);
     public static Efl.Eo.FunctionWrapper<efl_text_backing_type_set_api_delegate> efl_text_backing_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_type_set_api_delegate>(_Module, "efl_text_backing_type_set");
     private static void backing_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleBackingType type)
    {
        Eina.Log.Debug("function efl_text_backing_type_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextStyle)wrapper).SetBackingType( type);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_backing_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
        }
    }
    private static efl_text_backing_type_set_delegate efl_text_backing_type_set_static_delegate;


     private delegate void efl_text_backing_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out byte r,   out byte g,   out byte b,   out byte a);


     public delegate void efl_text_backing_color_get_api_delegate(System.IntPtr obj,   out byte r,   out byte g,   out byte b,   out byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_backing_color_get_api_delegate> efl_text_backing_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_color_get_api_delegate>(_Module, "efl_text_backing_color_get");
     private static void backing_color_get(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a)
    {
        Eina.Log.Debug("function efl_text_backing_color_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
            try {
                ((ITextStyle)wrapper).GetBackingColor( out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_backing_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
        }
    }
    private static efl_text_backing_color_get_delegate efl_text_backing_color_get_static_delegate;


     private delegate void efl_text_backing_color_set_delegate(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a);


     public delegate void efl_text_backing_color_set_api_delegate(System.IntPtr obj,   byte r,   byte g,   byte b,   byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_backing_color_set_api_delegate> efl_text_backing_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_color_set_api_delegate>(_Module, "efl_text_backing_color_set");
     private static void backing_color_set(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a)
    {
        Eina.Log.Debug("function efl_text_backing_color_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((ITextStyle)wrapper).SetBackingColor( r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_backing_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
        }
    }
    private static efl_text_backing_color_set_delegate efl_text_backing_color_set_static_delegate;


     private delegate Efl.TextStyleUnderlineType efl_text_underline_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.TextStyleUnderlineType efl_text_underline_type_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_type_get_api_delegate> efl_text_underline_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_type_get_api_delegate>(_Module, "efl_text_underline_type_get");
     private static Efl.TextStyleUnderlineType underline_type_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_text_underline_type_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.TextStyleUnderlineType _ret_var = default(Efl.TextStyleUnderlineType);
            try {
                _ret_var = ((ITextStyle)wrapper).GetUnderlineType();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_text_underline_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_text_underline_type_get_delegate efl_text_underline_type_get_static_delegate;


     private delegate void efl_text_underline_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleUnderlineType type);


     public delegate void efl_text_underline_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleUnderlineType type);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_type_set_api_delegate> efl_text_underline_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_type_set_api_delegate>(_Module, "efl_text_underline_type_set");
     private static void underline_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleUnderlineType type)
    {
        Eina.Log.Debug("function efl_text_underline_type_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextStyle)wrapper).SetUnderlineType( type);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_underline_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
        }
    }
    private static efl_text_underline_type_set_delegate efl_text_underline_type_set_static_delegate;


     private delegate void efl_text_underline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out byte r,   out byte g,   out byte b,   out byte a);


     public delegate void efl_text_underline_color_get_api_delegate(System.IntPtr obj,   out byte r,   out byte g,   out byte b,   out byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_color_get_api_delegate> efl_text_underline_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_color_get_api_delegate>(_Module, "efl_text_underline_color_get");
     private static void underline_color_get(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a)
    {
        Eina.Log.Debug("function efl_text_underline_color_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
            try {
                ((ITextStyle)wrapper).GetUnderlineColor( out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_underline_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
        }
    }
    private static efl_text_underline_color_get_delegate efl_text_underline_color_get_static_delegate;


     private delegate void efl_text_underline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a);


     public delegate void efl_text_underline_color_set_api_delegate(System.IntPtr obj,   byte r,   byte g,   byte b,   byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_color_set_api_delegate> efl_text_underline_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_color_set_api_delegate>(_Module, "efl_text_underline_color_set");
     private static void underline_color_set(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a)
    {
        Eina.Log.Debug("function efl_text_underline_color_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((ITextStyle)wrapper).SetUnderlineColor( r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_underline_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
        }
    }
    private static efl_text_underline_color_set_delegate efl_text_underline_color_set_static_delegate;


     private delegate double efl_text_underline_height_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_text_underline_height_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_height_get_api_delegate> efl_text_underline_height_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_height_get_api_delegate>(_Module, "efl_text_underline_height_get");
     private static double underline_height_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_text_underline_height_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((ITextStyle)wrapper).GetUnderlineHeight();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_text_underline_height_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_text_underline_height_get_delegate efl_text_underline_height_get_static_delegate;


     private delegate void efl_text_underline_height_set_delegate(System.IntPtr obj, System.IntPtr pd,   double height);


     public delegate void efl_text_underline_height_set_api_delegate(System.IntPtr obj,   double height);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_height_set_api_delegate> efl_text_underline_height_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_height_set_api_delegate>(_Module, "efl_text_underline_height_set");
     private static void underline_height_set(System.IntPtr obj, System.IntPtr pd,  double height)
    {
        Eina.Log.Debug("function efl_text_underline_height_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextStyle)wrapper).SetUnderlineHeight( height);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_underline_height_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  height);
        }
    }
    private static efl_text_underline_height_set_delegate efl_text_underline_height_set_static_delegate;


     private delegate void efl_text_underline_dashed_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out byte r,   out byte g,   out byte b,   out byte a);


     public delegate void efl_text_underline_dashed_color_get_api_delegate(System.IntPtr obj,   out byte r,   out byte g,   out byte b,   out byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate> efl_text_underline_dashed_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate>(_Module, "efl_text_underline_dashed_color_get");
     private static void underline_dashed_color_get(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a)
    {
        Eina.Log.Debug("function efl_text_underline_dashed_color_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
            try {
                ((ITextStyle)wrapper).GetUnderlineDashedColor( out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_underline_dashed_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
        }
    }
    private static efl_text_underline_dashed_color_get_delegate efl_text_underline_dashed_color_get_static_delegate;


     private delegate void efl_text_underline_dashed_color_set_delegate(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a);


     public delegate void efl_text_underline_dashed_color_set_api_delegate(System.IntPtr obj,   byte r,   byte g,   byte b,   byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate> efl_text_underline_dashed_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate>(_Module, "efl_text_underline_dashed_color_set");
     private static void underline_dashed_color_set(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a)
    {
        Eina.Log.Debug("function efl_text_underline_dashed_color_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((ITextStyle)wrapper).SetUnderlineDashedColor( r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_underline_dashed_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
        }
    }
    private static efl_text_underline_dashed_color_set_delegate efl_text_underline_dashed_color_set_static_delegate;


     private delegate int efl_text_underline_dashed_width_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_text_underline_dashed_width_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate> efl_text_underline_dashed_width_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate>(_Module, "efl_text_underline_dashed_width_get");
     private static int underline_dashed_width_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_text_underline_dashed_width_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((ITextStyle)wrapper).GetUnderlineDashedWidth();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_text_underline_dashed_width_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_text_underline_dashed_width_get_delegate efl_text_underline_dashed_width_get_static_delegate;


     private delegate void efl_text_underline_dashed_width_set_delegate(System.IntPtr obj, System.IntPtr pd,   int width);


     public delegate void efl_text_underline_dashed_width_set_api_delegate(System.IntPtr obj,   int width);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate> efl_text_underline_dashed_width_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate>(_Module, "efl_text_underline_dashed_width_set");
     private static void underline_dashed_width_set(System.IntPtr obj, System.IntPtr pd,  int width)
    {
        Eina.Log.Debug("function efl_text_underline_dashed_width_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextStyle)wrapper).SetUnderlineDashedWidth( width);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_underline_dashed_width_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  width);
        }
    }
    private static efl_text_underline_dashed_width_set_delegate efl_text_underline_dashed_width_set_static_delegate;


     private delegate int efl_text_underline_dashed_gap_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_text_underline_dashed_gap_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate> efl_text_underline_dashed_gap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate>(_Module, "efl_text_underline_dashed_gap_get");
     private static int underline_dashed_gap_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_text_underline_dashed_gap_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((ITextStyle)wrapper).GetUnderlineDashedGap();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_text_underline_dashed_gap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_text_underline_dashed_gap_get_delegate efl_text_underline_dashed_gap_get_static_delegate;


     private delegate void efl_text_underline_dashed_gap_set_delegate(System.IntPtr obj, System.IntPtr pd,   int gap);


     public delegate void efl_text_underline_dashed_gap_set_api_delegate(System.IntPtr obj,   int gap);
     public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate> efl_text_underline_dashed_gap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate>(_Module, "efl_text_underline_dashed_gap_set");
     private static void underline_dashed_gap_set(System.IntPtr obj, System.IntPtr pd,  int gap)
    {
        Eina.Log.Debug("function efl_text_underline_dashed_gap_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextStyle)wrapper).SetUnderlineDashedGap( gap);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_underline_dashed_gap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  gap);
        }
    }
    private static efl_text_underline_dashed_gap_set_delegate efl_text_underline_dashed_gap_set_static_delegate;


     private delegate void efl_text_underline2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out byte r,   out byte g,   out byte b,   out byte a);


     public delegate void efl_text_underline2_color_get_api_delegate(System.IntPtr obj,   out byte r,   out byte g,   out byte b,   out byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_underline2_color_get_api_delegate> efl_text_underline2_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline2_color_get_api_delegate>(_Module, "efl_text_underline2_color_get");
     private static void underline2_color_get(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a)
    {
        Eina.Log.Debug("function efl_text_underline2_color_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
            try {
                ((ITextStyle)wrapper).GetUnderline2Color( out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_underline2_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
        }
    }
    private static efl_text_underline2_color_get_delegate efl_text_underline2_color_get_static_delegate;


     private delegate void efl_text_underline2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a);


     public delegate void efl_text_underline2_color_set_api_delegate(System.IntPtr obj,   byte r,   byte g,   byte b,   byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_underline2_color_set_api_delegate> efl_text_underline2_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline2_color_set_api_delegate>(_Module, "efl_text_underline2_color_set");
     private static void underline2_color_set(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a)
    {
        Eina.Log.Debug("function efl_text_underline2_color_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((ITextStyle)wrapper).SetUnderline2Color( r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_underline2_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
        }
    }
    private static efl_text_underline2_color_set_delegate efl_text_underline2_color_set_static_delegate;


     private delegate Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate> efl_text_strikethrough_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate>(_Module, "efl_text_strikethrough_type_get");
     private static Efl.TextStyleStrikethroughType strikethrough_type_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_text_strikethrough_type_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.TextStyleStrikethroughType _ret_var = default(Efl.TextStyleStrikethroughType);
            try {
                _ret_var = ((ITextStyle)wrapper).GetStrikethroughType();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_text_strikethrough_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_text_strikethrough_type_get_delegate efl_text_strikethrough_type_get_static_delegate;


     private delegate void efl_text_strikethrough_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleStrikethroughType type);


     public delegate void efl_text_strikethrough_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleStrikethroughType type);
     public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate> efl_text_strikethrough_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate>(_Module, "efl_text_strikethrough_type_set");
     private static void strikethrough_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleStrikethroughType type)
    {
        Eina.Log.Debug("function efl_text_strikethrough_type_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextStyle)wrapper).SetStrikethroughType( type);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_strikethrough_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
        }
    }
    private static efl_text_strikethrough_type_set_delegate efl_text_strikethrough_type_set_static_delegate;


     private delegate void efl_text_strikethrough_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out byte r,   out byte g,   out byte b,   out byte a);


     public delegate void efl_text_strikethrough_color_get_api_delegate(System.IntPtr obj,   out byte r,   out byte g,   out byte b,   out byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate> efl_text_strikethrough_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate>(_Module, "efl_text_strikethrough_color_get");
     private static void strikethrough_color_get(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a)
    {
        Eina.Log.Debug("function efl_text_strikethrough_color_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
            try {
                ((ITextStyle)wrapper).GetStrikethroughColor( out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_strikethrough_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
        }
    }
    private static efl_text_strikethrough_color_get_delegate efl_text_strikethrough_color_get_static_delegate;


     private delegate void efl_text_strikethrough_color_set_delegate(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a);


     public delegate void efl_text_strikethrough_color_set_api_delegate(System.IntPtr obj,   byte r,   byte g,   byte b,   byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate> efl_text_strikethrough_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate>(_Module, "efl_text_strikethrough_color_set");
     private static void strikethrough_color_set(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a)
    {
        Eina.Log.Debug("function efl_text_strikethrough_color_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((ITextStyle)wrapper).SetStrikethroughColor( r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_strikethrough_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
        }
    }
    private static efl_text_strikethrough_color_set_delegate efl_text_strikethrough_color_set_static_delegate;


     private delegate Efl.TextStyleEffectType efl_text_effect_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.TextStyleEffectType efl_text_effect_type_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_text_effect_type_get_api_delegate> efl_text_effect_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_effect_type_get_api_delegate>(_Module, "efl_text_effect_type_get");
     private static Efl.TextStyleEffectType effect_type_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_text_effect_type_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.TextStyleEffectType _ret_var = default(Efl.TextStyleEffectType);
            try {
                _ret_var = ((ITextStyle)wrapper).GetEffectType();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_text_effect_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_text_effect_type_get_delegate efl_text_effect_type_get_static_delegate;


     private delegate void efl_text_effect_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleEffectType type);


     public delegate void efl_text_effect_type_set_api_delegate(System.IntPtr obj,   Efl.TextStyleEffectType type);
     public static Efl.Eo.FunctionWrapper<efl_text_effect_type_set_api_delegate> efl_text_effect_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_effect_type_set_api_delegate>(_Module, "efl_text_effect_type_set");
     private static void effect_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleEffectType type)
    {
        Eina.Log.Debug("function efl_text_effect_type_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextStyle)wrapper).SetEffectType( type);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_effect_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
        }
    }
    private static efl_text_effect_type_set_delegate efl_text_effect_type_set_static_delegate;


     private delegate void efl_text_outline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out byte r,   out byte g,   out byte b,   out byte a);


     public delegate void efl_text_outline_color_get_api_delegate(System.IntPtr obj,   out byte r,   out byte g,   out byte b,   out byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_outline_color_get_api_delegate> efl_text_outline_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_outline_color_get_api_delegate>(_Module, "efl_text_outline_color_get");
     private static void outline_color_get(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a)
    {
        Eina.Log.Debug("function efl_text_outline_color_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
            try {
                ((ITextStyle)wrapper).GetOutlineColor( out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_outline_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
        }
    }
    private static efl_text_outline_color_get_delegate efl_text_outline_color_get_static_delegate;


     private delegate void efl_text_outline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a);


     public delegate void efl_text_outline_color_set_api_delegate(System.IntPtr obj,   byte r,   byte g,   byte b,   byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_outline_color_set_api_delegate> efl_text_outline_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_outline_color_set_api_delegate>(_Module, "efl_text_outline_color_set");
     private static void outline_color_set(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a)
    {
        Eina.Log.Debug("function efl_text_outline_color_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((ITextStyle)wrapper).SetOutlineColor( r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_outline_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
        }
    }
    private static efl_text_outline_color_set_delegate efl_text_outline_color_set_static_delegate;


     private delegate Efl.TextStyleShadowDirection efl_text_shadow_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.TextStyleShadowDirection efl_text_shadow_direction_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_text_shadow_direction_get_api_delegate> efl_text_shadow_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_direction_get_api_delegate>(_Module, "efl_text_shadow_direction_get");
     private static Efl.TextStyleShadowDirection shadow_direction_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_text_shadow_direction_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.TextStyleShadowDirection _ret_var = default(Efl.TextStyleShadowDirection);
            try {
                _ret_var = ((ITextStyle)wrapper).GetShadowDirection();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_text_shadow_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_text_shadow_direction_get_delegate efl_text_shadow_direction_get_static_delegate;


     private delegate void efl_text_shadow_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextStyleShadowDirection type);


     public delegate void efl_text_shadow_direction_set_api_delegate(System.IntPtr obj,   Efl.TextStyleShadowDirection type);
     public static Efl.Eo.FunctionWrapper<efl_text_shadow_direction_set_api_delegate> efl_text_shadow_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_direction_set_api_delegate>(_Module, "efl_text_shadow_direction_set");
     private static void shadow_direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleShadowDirection type)
    {
        Eina.Log.Debug("function efl_text_shadow_direction_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextStyle)wrapper).SetShadowDirection( type);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_shadow_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type);
        }
    }
    private static efl_text_shadow_direction_set_delegate efl_text_shadow_direction_set_static_delegate;


     private delegate void efl_text_shadow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out byte r,   out byte g,   out byte b,   out byte a);


     public delegate void efl_text_shadow_color_get_api_delegate(System.IntPtr obj,   out byte r,   out byte g,   out byte b,   out byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_shadow_color_get_api_delegate> efl_text_shadow_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_color_get_api_delegate>(_Module, "efl_text_shadow_color_get");
     private static void shadow_color_get(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a)
    {
        Eina.Log.Debug("function efl_text_shadow_color_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
            try {
                ((ITextStyle)wrapper).GetShadowColor( out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_shadow_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
        }
    }
    private static efl_text_shadow_color_get_delegate efl_text_shadow_color_get_static_delegate;


     private delegate void efl_text_shadow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a);


     public delegate void efl_text_shadow_color_set_api_delegate(System.IntPtr obj,   byte r,   byte g,   byte b,   byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_shadow_color_set_api_delegate> efl_text_shadow_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_color_set_api_delegate>(_Module, "efl_text_shadow_color_set");
     private static void shadow_color_set(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a)
    {
        Eina.Log.Debug("function efl_text_shadow_color_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((ITextStyle)wrapper).SetShadowColor( r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_shadow_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
        }
    }
    private static efl_text_shadow_color_set_delegate efl_text_shadow_color_set_static_delegate;


     private delegate void efl_text_glow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out byte r,   out byte g,   out byte b,   out byte a);


     public delegate void efl_text_glow_color_get_api_delegate(System.IntPtr obj,   out byte r,   out byte g,   out byte b,   out byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_glow_color_get_api_delegate> efl_text_glow_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow_color_get_api_delegate>(_Module, "efl_text_glow_color_get");
     private static void glow_color_get(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a)
    {
        Eina.Log.Debug("function efl_text_glow_color_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
            try {
                ((ITextStyle)wrapper).GetGlowColor( out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_glow_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
        }
    }
    private static efl_text_glow_color_get_delegate efl_text_glow_color_get_static_delegate;


     private delegate void efl_text_glow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a);


     public delegate void efl_text_glow_color_set_api_delegate(System.IntPtr obj,   byte r,   byte g,   byte b,   byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_glow_color_set_api_delegate> efl_text_glow_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow_color_set_api_delegate>(_Module, "efl_text_glow_color_set");
     private static void glow_color_set(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a)
    {
        Eina.Log.Debug("function efl_text_glow_color_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((ITextStyle)wrapper).SetGlowColor( r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_glow_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
        }
    }
    private static efl_text_glow_color_set_delegate efl_text_glow_color_set_static_delegate;


     private delegate void efl_text_glow2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out byte r,   out byte g,   out byte b,   out byte a);


     public delegate void efl_text_glow2_color_get_api_delegate(System.IntPtr obj,   out byte r,   out byte g,   out byte b,   out byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_glow2_color_get_api_delegate> efl_text_glow2_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow2_color_get_api_delegate>(_Module, "efl_text_glow2_color_get");
     private static void glow2_color_get(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a)
    {
        Eina.Log.Debug("function efl_text_glow2_color_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
            try {
                ((ITextStyle)wrapper).GetGlow2Color( out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_glow2_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
        }
    }
    private static efl_text_glow2_color_get_delegate efl_text_glow2_color_get_static_delegate;


     private delegate void efl_text_glow2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,   byte r,   byte g,   byte b,   byte a);


     public delegate void efl_text_glow2_color_set_api_delegate(System.IntPtr obj,   byte r,   byte g,   byte b,   byte a);
     public static Efl.Eo.FunctionWrapper<efl_text_glow2_color_set_api_delegate> efl_text_glow2_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow2_color_set_api_delegate>(_Module, "efl_text_glow2_color_set");
     private static void glow2_color_set(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a)
    {
        Eina.Log.Debug("function efl_text_glow2_color_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((ITextStyle)wrapper).SetGlow2Color( r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_text_glow2_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
        }
    }
    private static efl_text_glow2_color_set_delegate efl_text_glow2_color_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_text_gfx_filter_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_text_gfx_filter_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_text_gfx_filter_get_api_delegate> efl_text_gfx_filter_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_gfx_filter_get_api_delegate>(_Module, "efl_text_gfx_filter_get");
     private static System.String gfx_filter_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_text_gfx_filter_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((ITextStyle)wrapper).GetGfxFilter();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_text_gfx_filter_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_text_gfx_filter_get_delegate efl_text_gfx_filter_get_static_delegate;


     private delegate void efl_text_gfx_filter_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String code);


     public delegate void efl_text_gfx_filter_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String code);
     public static Efl.Eo.FunctionWrapper<efl_text_gfx_filter_set_api_delegate> efl_text_gfx_filter_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_gfx_filter_set_api_delegate>(_Module, "efl_text_gfx_filter_set");
     private static void gfx_filter_set(System.IntPtr obj, System.IntPtr pd,  System.String code)
    {
        Eina.Log.Debug("function efl_text_gfx_filter_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ITextStyle)wrapper).SetGfxFilter( code);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_gfx_filter_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  code);
        }
    }
    private static efl_text_gfx_filter_set_delegate efl_text_gfx_filter_set_static_delegate;
}
} 
namespace Efl { 
/// <summary>Whether to apply backing style to the displayed text or not</summary>
public enum TextStyleBackingType
{
/// <summary>Do not use backing</summary>
Disabled = 0,
/// <summary>Use backing style</summary>
Enabled = 1,
}
} 
namespace Efl { 
/// <summary>Whether to apply strikethrough style to the displayed text or not</summary>
public enum TextStyleStrikethroughType
{
/// <summary>Do not use strikethrough</summary>
Disabled = 0,
/// <summary>Use strikethrough style</summary>
Enabled = 1,
}
} 
namespace Efl { 
/// <summary>Effect to apply to the displayed text</summary>
public enum TextStyleEffectType
{
/// <summary>No effect</summary>
None = 0,
/// <summary>Shadow effect</summary>
Shadow = 1,
/// <summary>Far shadow effect</summary>
FarShadow = 2,
/// <summary>Soft shadow effect</summary>
SoftShadow = 3,
/// <summary>Far and soft shadow effect</summary>
FarSoftShadow = 4,
/// <summary>Glow effect</summary>
Glow = 5,
/// <summary>Outline effect</summary>
Outline = 6,
/// <summary>Soft outline effect</summary>
SoftOutline = 7,
/// <summary>Outline shadow effect</summary>
OutlineShadow = 8,
/// <summary>Outline soft shadow effect</summary>
OutlineSoftShadow = 9,
}
} 
namespace Efl { 
/// <summary>Direction of the shadow style, if used</summary>
public enum TextStyleShadowDirection
{
/// <summary>Shadow towards bottom right</summary>
BottomRight = 0,
/// <summary>Shadow towards botom</summary>
Bottom = 1,
/// <summary>Shadow towards bottom left</summary>
BottomLeft = 2,
/// <summary>Shadow towards left</summary>
Left = 3,
/// <summary>Shadow towards top left</summary>
TopLeft = 4,
/// <summary>Shadow towards top</summary>
Top = 5,
/// <summary>Shadow towards top right</summary>
TopRight = 6,
/// <summary>Shadow towards right</summary>
Right = 7,
}
} 
namespace Efl { 
/// <summary>Underline type of the displayed text</summary>
public enum TextStyleUnderlineType
{
/// <summary>Text without underline</summary>
Off = 0,
/// <summary>Underline enabled</summary>
On = 1,
/// <summary>Underlined with a signle line</summary>
Single = 2,
/// <summary>Underlined with a double line</summary>
Double = 3,
/// <summary>Underlined with a dashed line</summary>
Dashed = 4,
}
} 
