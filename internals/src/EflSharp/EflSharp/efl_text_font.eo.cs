#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Font settings of the text
/// 1.20</summary>
[TextFontNativeInherit]
public interface TextFont : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Retrieve the font family and size in use on a given text object.
/// This function allows the font name and size of a text object to be queried. Remember that the font name string is still owned by Evas and should not have free() called on it by the caller of the function.
/// 
/// See also <see cref="Efl.TextFont.GetFont"/>.
/// 1.20</summary>
/// <param name="font">The font family name or filename.
/// 1.20</param>
/// <param name="size">The font size, in points.
/// 1.20</param>
/// <returns></returns>
 void GetFont( out  System.String font,  out Efl.Font.Size size);
   /// <summary>Set the font family, filename and size for a given text object.
/// This function allows the font name and size of a text object to be set. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by Evas (see the fc-list command&apos;s output, on your system, to get an idea). Alternatively, youe can use the full path to a font file.
/// 
/// See also <see cref="Efl.TextFont.GetFont"/>, <see cref="Efl.TextFont.GetFontSource"/>.
/// 1.20</summary>
/// <param name="font">The font family name or filename.
/// 1.20</param>
/// <param name="size">The font size, in points.
/// 1.20</param>
/// <returns></returns>
 void SetFont(  System.String font,  Efl.Font.Size size);
   /// <summary>Get the font file&apos;s path which is being used on a given text object.
/// See <see cref="Efl.TextFont.GetFont"/> for more details.
/// 1.20</summary>
/// <returns>The font file&apos;s path.
/// 1.20</returns>
 System.String GetFontSource();
   /// <summary>Set the font (source) file to be used on a given text object.
/// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
/// 
/// See also <see cref="Efl.TextFont.GetFont"/>.
/// 1.20</summary>
/// <param name="font_source">The font file&apos;s path.
/// 1.20</param>
/// <returns></returns>
 void SetFontSource(  System.String font_source);
   /// <summary>Comma-separated list of font fallbacks
/// Will be used in case the primary font isn&apos;t available.
/// 1.20</summary>
/// <returns>Font name fallbacks
/// 1.20</returns>
 System.String GetFontFallbacks();
   /// <summary>Comma-separated list of font fallbacks
/// Will be used in case the primary font isn&apos;t available.
/// 1.20</summary>
/// <param name="font_fallbacks">Font name fallbacks
/// 1.20</param>
/// <returns></returns>
 void SetFontFallbacks(  System.String font_fallbacks);
   /// <summary>Type of weight of the displayed font
/// Default is <see cref="Efl.TextFontWeight.Normal"/>.
/// 1.20</summary>
/// <returns>Font weight
/// 1.20</returns>
Efl.TextFontWeight GetFontWeight();
   /// <summary>Type of weight of the displayed font
/// Default is <see cref="Efl.TextFontWeight.Normal"/>.
/// 1.20</summary>
/// <param name="font_weight">Font weight
/// 1.20</param>
/// <returns></returns>
 void SetFontWeight( Efl.TextFontWeight font_weight);
   /// <summary>Type of slant of the displayed font
/// Default is <see cref="Efl.TextFontSlant.Normal"/>.
/// 1.20</summary>
/// <returns>Font slant
/// 1.20</returns>
Efl.TextFontSlant GetFontSlant();
   /// <summary>Type of slant of the displayed font
/// Default is <see cref="Efl.TextFontSlant.Normal"/>.
/// 1.20</summary>
/// <param name="style">Font slant
/// 1.20</param>
/// <returns></returns>
 void SetFontSlant( Efl.TextFontSlant style);
   /// <summary>Type of width of the displayed font
/// Default is <see cref="Efl.TextFontWidth.Normal"/>.
/// 1.20</summary>
/// <returns>Font width
/// 1.20</returns>
Efl.TextFontWidth GetFontWidth();
   /// <summary>Type of width of the displayed font
/// Default is <see cref="Efl.TextFontWidth.Normal"/>.
/// 1.20</summary>
/// <param name="width">Font width
/// 1.20</param>
/// <returns></returns>
 void SetFontWidth( Efl.TextFontWidth width);
   /// <summary>Specific language of the displayed font
/// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
/// 1.20</summary>
/// <returns>Language
/// 1.20</returns>
 System.String GetFontLang();
   /// <summary>Specific language of the displayed font
/// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
/// 1.20</summary>
/// <param name="lang">Language
/// 1.20</param>
/// <returns></returns>
 void SetFontLang(  System.String lang);
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
/// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
/// 1.20</summary>
/// <returns>Scalable
/// 1.20</returns>
Efl.TextFontBitmapScalable GetFontBitmapScalable();
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
/// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
/// 1.20</summary>
/// <param name="scalable">Scalable
/// 1.20</param>
/// <returns></returns>
 void SetFontBitmapScalable( Efl.TextFontBitmapScalable scalable);
                                                   /// <summary>Get the font file&apos;s path which is being used on a given text object.
/// See <see cref="Efl.TextFont.GetFont"/> for more details.
/// 1.20</summary>
/// <value>The font file&apos;s path.
/// 1.20</value>
    System.String FontSource {
      get ;
      set ;
   }
   /// <summary>Comma-separated list of font fallbacks
/// Will be used in case the primary font isn&apos;t available.
/// 1.20</summary>
/// <value>Font name fallbacks
/// 1.20</value>
    System.String FontFallbacks {
      get ;
      set ;
   }
   /// <summary>Type of weight of the displayed font
/// Default is <see cref="Efl.TextFontWeight.Normal"/>.
/// 1.20</summary>
/// <value>Font weight
/// 1.20</value>
   Efl.TextFontWeight FontWeight {
      get ;
      set ;
   }
   /// <summary>Type of slant of the displayed font
/// Default is <see cref="Efl.TextFontSlant.Normal"/>.
/// 1.20</summary>
/// <value>Font slant
/// 1.20</value>
   Efl.TextFontSlant FontSlant {
      get ;
      set ;
   }
   /// <summary>Type of width of the displayed font
/// Default is <see cref="Efl.TextFontWidth.Normal"/>.
/// 1.20</summary>
/// <value>Font width
/// 1.20</value>
   Efl.TextFontWidth FontWidth {
      get ;
      set ;
   }
   /// <summary>Specific language of the displayed font
/// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
/// 1.20</summary>
/// <value>Language
/// 1.20</value>
    System.String FontLang {
      get ;
      set ;
   }
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
/// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
/// 1.20</summary>
/// <value>Scalable
/// 1.20</value>
   Efl.TextFontBitmapScalable FontBitmapScalable {
      get ;
      set ;
   }
}
/// <summary>Font settings of the text
/// 1.20</summary>
sealed public class TextFontConcrete : 

TextFont
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TextFontConcrete))
            return Efl.TextFontNativeInherit.GetEflClassStatic();
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
      efl_text_font_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public TextFontConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~TextFontConcrete()
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
   ///<summary>Casts obj into an instance of this type.</summary>
   public static TextFontConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TextFontConcrete(obj.NativeHandle);
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
   /// <summary>Retrieve the font family and size in use on a given text object.
   /// This function allows the font name and size of a text object to be queried. Remember that the font name string is still owned by Evas and should not have free() called on it by the caller of the function.
   /// 
   /// See also <see cref="Efl.TextFont.GetFont"/>.
   /// 1.20</summary>
   /// <param name="font">The font family name or filename.
   /// 1.20</param>
   /// <param name="size">The font size, in points.
   /// 1.20</param>
   /// <returns></returns>
   public  void GetFont( out  System.String font,  out Efl.Font.Size size) {
                                           Efl.TextFontNativeInherit.efl_text_font_get_ptr.Value.Delegate(this.NativeHandle, out font,  out size);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Set the font family, filename and size for a given text object.
   /// This function allows the font name and size of a text object to be set. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by Evas (see the fc-list command&apos;s output, on your system, to get an idea). Alternatively, youe can use the full path to a font file.
   /// 
   /// See also <see cref="Efl.TextFont.GetFont"/>, <see cref="Efl.TextFont.GetFontSource"/>.
   /// 1.20</summary>
   /// <param name="font">The font family name or filename.
   /// 1.20</param>
   /// <param name="size">The font size, in points.
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFont(  System.String font,  Efl.Font.Size size) {
                                           Efl.TextFontNativeInherit.efl_text_font_set_ptr.Value.Delegate(this.NativeHandle, font,  size);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Get the font file&apos;s path which is being used on a given text object.
   /// See <see cref="Efl.TextFont.GetFont"/> for more details.
   /// 1.20</summary>
   /// <returns>The font file&apos;s path.
   /// 1.20</returns>
   public  System.String GetFontSource() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_source_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the font (source) file to be used on a given text object.
   /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
   /// 
   /// See also <see cref="Efl.TextFont.GetFont"/>.
   /// 1.20</summary>
   /// <param name="font_source">The font file&apos;s path.
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontSource(  System.String font_source) {
                         Efl.TextFontNativeInherit.efl_text_font_source_set_ptr.Value.Delegate(this.NativeHandle, font_source);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Comma-separated list of font fallbacks
   /// Will be used in case the primary font isn&apos;t available.
   /// 1.20</summary>
   /// <returns>Font name fallbacks
   /// 1.20</returns>
   public  System.String GetFontFallbacks() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_fallbacks_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Comma-separated list of font fallbacks
   /// Will be used in case the primary font isn&apos;t available.
   /// 1.20</summary>
   /// <param name="font_fallbacks">Font name fallbacks
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontFallbacks(  System.String font_fallbacks) {
                         Efl.TextFontNativeInherit.efl_text_font_fallbacks_set_ptr.Value.Delegate(this.NativeHandle, font_fallbacks);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Type of weight of the displayed font
   /// Default is <see cref="Efl.TextFontWeight.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font weight
   /// 1.20</returns>
   public Efl.TextFontWeight GetFontWeight() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_weight_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of weight of the displayed font
   /// Default is <see cref="Efl.TextFontWeight.Normal"/>.
   /// 1.20</summary>
   /// <param name="font_weight">Font weight
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontWeight( Efl.TextFontWeight font_weight) {
                         Efl.TextFontNativeInherit.efl_text_font_weight_set_ptr.Value.Delegate(this.NativeHandle, font_weight);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Type of slant of the displayed font
   /// Default is <see cref="Efl.TextFontSlant.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font slant
   /// 1.20</returns>
   public Efl.TextFontSlant GetFontSlant() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_slant_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of slant of the displayed font
   /// Default is <see cref="Efl.TextFontSlant.Normal"/>.
   /// 1.20</summary>
   /// <param name="style">Font slant
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontSlant( Efl.TextFontSlant style) {
                         Efl.TextFontNativeInherit.efl_text_font_slant_set_ptr.Value.Delegate(this.NativeHandle, style);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Type of width of the displayed font
   /// Default is <see cref="Efl.TextFontWidth.Normal"/>.
   /// 1.20</summary>
   /// <returns>Font width
   /// 1.20</returns>
   public Efl.TextFontWidth GetFontWidth() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_width_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Type of width of the displayed font
   /// Default is <see cref="Efl.TextFontWidth.Normal"/>.
   /// 1.20</summary>
   /// <param name="width">Font width
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontWidth( Efl.TextFontWidth width) {
                         Efl.TextFontNativeInherit.efl_text_font_width_set_ptr.Value.Delegate(this.NativeHandle, width);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Specific language of the displayed font
   /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
   /// 1.20</summary>
   /// <returns>Language
   /// 1.20</returns>
   public  System.String GetFontLang() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_lang_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Specific language of the displayed font
   /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
   /// 1.20</summary>
   /// <param name="lang">Language
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontLang(  System.String lang) {
                         Efl.TextFontNativeInherit.efl_text_font_lang_set_ptr.Value.Delegate(this.NativeHandle, lang);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
   /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
   /// 1.20</summary>
   /// <returns>Scalable
   /// 1.20</returns>
   public Efl.TextFontBitmapScalable GetFontBitmapScalable() {
       var _ret_var = Efl.TextFontNativeInherit.efl_text_font_bitmap_scalable_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
   /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
   /// 1.20</summary>
   /// <param name="scalable">Scalable
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFontBitmapScalable( Efl.TextFontBitmapScalable scalable) {
                         Efl.TextFontNativeInherit.efl_text_font_bitmap_scalable_set_ptr.Value.Delegate(this.NativeHandle, scalable);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the font file&apos;s path which is being used on a given text object.
/// See <see cref="Efl.TextFont.GetFont"/> for more details.
/// 1.20</summary>
/// <value>The font file&apos;s path.
/// 1.20</value>
   public  System.String FontSource {
      get { return GetFontSource(); }
      set { SetFontSource( value); }
   }
   /// <summary>Comma-separated list of font fallbacks
/// Will be used in case the primary font isn&apos;t available.
/// 1.20</summary>
/// <value>Font name fallbacks
/// 1.20</value>
   public  System.String FontFallbacks {
      get { return GetFontFallbacks(); }
      set { SetFontFallbacks( value); }
   }
   /// <summary>Type of weight of the displayed font
/// Default is <see cref="Efl.TextFontWeight.Normal"/>.
/// 1.20</summary>
/// <value>Font weight
/// 1.20</value>
   public Efl.TextFontWeight FontWeight {
      get { return GetFontWeight(); }
      set { SetFontWeight( value); }
   }
   /// <summary>Type of slant of the displayed font
/// Default is <see cref="Efl.TextFontSlant.Normal"/>.
/// 1.20</summary>
/// <value>Font slant
/// 1.20</value>
   public Efl.TextFontSlant FontSlant {
      get { return GetFontSlant(); }
      set { SetFontSlant( value); }
   }
   /// <summary>Type of width of the displayed font
/// Default is <see cref="Efl.TextFontWidth.Normal"/>.
/// 1.20</summary>
/// <value>Font width
/// 1.20</value>
   public Efl.TextFontWidth FontWidth {
      get { return GetFontWidth(); }
      set { SetFontWidth( value); }
   }
   /// <summary>Specific language of the displayed font
/// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.
/// 1.20</summary>
/// <value>Language
/// 1.20</value>
   public  System.String FontLang {
      get { return GetFontLang(); }
      set { SetFontLang( value); }
   }
   /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
/// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.
/// 1.20</summary>
/// <value>Scalable
/// 1.20</value>
   public Efl.TextFontBitmapScalable FontBitmapScalable {
      get { return GetFontBitmapScalable(); }
      set { SetFontBitmapScalable( value); }
   }
}
public class TextFontNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_text_font_get_static_delegate == null)
      efl_text_font_get_static_delegate = new efl_text_font_get_delegate(font_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_get_static_delegate)});
      if (efl_text_font_set_static_delegate == null)
      efl_text_font_set_static_delegate = new efl_text_font_set_delegate(font_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_set_static_delegate)});
      if (efl_text_font_source_get_static_delegate == null)
      efl_text_font_source_get_static_delegate = new efl_text_font_source_get_delegate(font_source_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_get_static_delegate)});
      if (efl_text_font_source_set_static_delegate == null)
      efl_text_font_source_set_static_delegate = new efl_text_font_source_set_delegate(font_source_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_set_static_delegate)});
      if (efl_text_font_fallbacks_get_static_delegate == null)
      efl_text_font_fallbacks_get_static_delegate = new efl_text_font_fallbacks_get_delegate(font_fallbacks_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_fallbacks_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_get_static_delegate)});
      if (efl_text_font_fallbacks_set_static_delegate == null)
      efl_text_font_fallbacks_set_static_delegate = new efl_text_font_fallbacks_set_delegate(font_fallbacks_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_fallbacks_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_set_static_delegate)});
      if (efl_text_font_weight_get_static_delegate == null)
      efl_text_font_weight_get_static_delegate = new efl_text_font_weight_get_delegate(font_weight_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_get_static_delegate)});
      if (efl_text_font_weight_set_static_delegate == null)
      efl_text_font_weight_set_static_delegate = new efl_text_font_weight_set_delegate(font_weight_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_set_static_delegate)});
      if (efl_text_font_slant_get_static_delegate == null)
      efl_text_font_slant_get_static_delegate = new efl_text_font_slant_get_delegate(font_slant_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_slant_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_get_static_delegate)});
      if (efl_text_font_slant_set_static_delegate == null)
      efl_text_font_slant_set_static_delegate = new efl_text_font_slant_set_delegate(font_slant_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_slant_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_set_static_delegate)});
      if (efl_text_font_width_get_static_delegate == null)
      efl_text_font_width_get_static_delegate = new efl_text_font_width_get_delegate(font_width_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_get_static_delegate)});
      if (efl_text_font_width_set_static_delegate == null)
      efl_text_font_width_set_static_delegate = new efl_text_font_width_set_delegate(font_width_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_set_static_delegate)});
      if (efl_text_font_lang_get_static_delegate == null)
      efl_text_font_lang_get_static_delegate = new efl_text_font_lang_get_delegate(font_lang_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_lang_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_get_static_delegate)});
      if (efl_text_font_lang_set_static_delegate == null)
      efl_text_font_lang_set_static_delegate = new efl_text_font_lang_set_delegate(font_lang_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_lang_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_set_static_delegate)});
      if (efl_text_font_bitmap_scalable_get_static_delegate == null)
      efl_text_font_bitmap_scalable_get_static_delegate = new efl_text_font_bitmap_scalable_get_delegate(font_bitmap_scalable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_bitmap_scalable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_get_static_delegate)});
      if (efl_text_font_bitmap_scalable_set_static_delegate == null)
      efl_text_font_bitmap_scalable_set_static_delegate = new efl_text_font_bitmap_scalable_set_delegate(font_bitmap_scalable_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_font_bitmap_scalable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.TextFontConcrete.efl_text_font_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.TextFontConcrete.efl_text_font_interface_get();
   }


    private delegate  void efl_text_font_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String font,   out Efl.Font.Size size);


    public delegate  void efl_text_font_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String font,   out Efl.Font.Size size);
    public static Efl.Eo.FunctionWrapper<efl_text_font_get_api_delegate> efl_text_font_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_get_api_delegate>(_Module, "efl_text_font_get");
    private static  void font_get(System.IntPtr obj, System.IntPtr pd,  out  System.String font,  out Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_text_font_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                            System.String _out_font = default( System.String);
      size = default(Efl.Font.Size);                     
         try {
            ((TextFont)wrapper).GetFont( out _out_font,  out size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      font = _out_font;
                              } else {
         efl_text_font_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out font,  out size);
      }
   }
   private static efl_text_font_get_delegate efl_text_font_get_static_delegate;


    private delegate  void efl_text_font_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);


    public delegate  void efl_text_font_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font,   Efl.Font.Size size);
    public static Efl.Eo.FunctionWrapper<efl_text_font_set_api_delegate> efl_text_font_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_set_api_delegate>(_Module, "efl_text_font_set");
    private static  void font_set(System.IntPtr obj, System.IntPtr pd,   System.String font,  Efl.Font.Size size)
   {
      Eina.Log.Debug("function efl_text_font_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((TextFont)wrapper).SetFont( font,  size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_text_font_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font,  size);
      }
   }
   private static efl_text_font_set_delegate efl_text_font_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_font_source_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_font_source_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_source_get_api_delegate> efl_text_font_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_source_get_api_delegate>(_Module, "efl_text_font_source_get");
    private static  System.String font_source_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_source_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextFont)wrapper).GetFontSource();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_source_get_delegate efl_text_font_source_get_static_delegate;


    private delegate  void efl_text_font_source_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_source);


    public delegate  void efl_text_font_source_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_source);
    public static Efl.Eo.FunctionWrapper<efl_text_font_source_set_api_delegate> efl_text_font_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_source_set_api_delegate>(_Module, "efl_text_font_source_set");
    private static  void font_source_set(System.IntPtr obj, System.IntPtr pd,   System.String font_source)
   {
      Eina.Log.Debug("function efl_text_font_source_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFont)wrapper).SetFontSource( font_source);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_source);
      }
   }
   private static efl_text_font_source_set_delegate efl_text_font_source_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_font_fallbacks_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_font_fallbacks_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate> efl_text_font_fallbacks_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate>(_Module, "efl_text_font_fallbacks_get");
    private static  System.String font_fallbacks_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_fallbacks_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextFont)wrapper).GetFontFallbacks();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_fallbacks_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_fallbacks_get_delegate efl_text_font_fallbacks_get_static_delegate;


    private delegate  void efl_text_font_fallbacks_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_fallbacks);


    public delegate  void efl_text_font_fallbacks_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String font_fallbacks);
    public static Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate> efl_text_font_fallbacks_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate>(_Module, "efl_text_font_fallbacks_set");
    private static  void font_fallbacks_set(System.IntPtr obj, System.IntPtr pd,   System.String font_fallbacks)
   {
      Eina.Log.Debug("function efl_text_font_fallbacks_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFont)wrapper).SetFontFallbacks( font_fallbacks);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_fallbacks_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_fallbacks);
      }
   }
   private static efl_text_font_fallbacks_set_delegate efl_text_font_fallbacks_set_static_delegate;


    private delegate Efl.TextFontWeight efl_text_font_weight_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontWeight efl_text_font_weight_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_weight_get_api_delegate> efl_text_font_weight_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_weight_get_api_delegate>(_Module, "efl_text_font_weight_get");
    private static Efl.TextFontWeight font_weight_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_weight_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontWeight _ret_var = default(Efl.TextFontWeight);
         try {
            _ret_var = ((TextFont)wrapper).GetFontWeight();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_weight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_weight_get_delegate efl_text_font_weight_get_static_delegate;


    private delegate  void efl_text_font_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontWeight font_weight);


    public delegate  void efl_text_font_weight_set_api_delegate(System.IntPtr obj,   Efl.TextFontWeight font_weight);
    public static Efl.Eo.FunctionWrapper<efl_text_font_weight_set_api_delegate> efl_text_font_weight_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_weight_set_api_delegate>(_Module, "efl_text_font_weight_set");
    private static  void font_weight_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWeight font_weight)
   {
      Eina.Log.Debug("function efl_text_font_weight_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFont)wrapper).SetFontWeight( font_weight);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_weight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  font_weight);
      }
   }
   private static efl_text_font_weight_set_delegate efl_text_font_weight_set_static_delegate;


    private delegate Efl.TextFontSlant efl_text_font_slant_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontSlant efl_text_font_slant_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_slant_get_api_delegate> efl_text_font_slant_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_slant_get_api_delegate>(_Module, "efl_text_font_slant_get");
    private static Efl.TextFontSlant font_slant_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_slant_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontSlant _ret_var = default(Efl.TextFontSlant);
         try {
            _ret_var = ((TextFont)wrapper).GetFontSlant();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_slant_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_slant_get_delegate efl_text_font_slant_get_static_delegate;


    private delegate  void efl_text_font_slant_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontSlant style);


    public delegate  void efl_text_font_slant_set_api_delegate(System.IntPtr obj,   Efl.TextFontSlant style);
    public static Efl.Eo.FunctionWrapper<efl_text_font_slant_set_api_delegate> efl_text_font_slant_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_slant_set_api_delegate>(_Module, "efl_text_font_slant_set");
    private static  void font_slant_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontSlant style)
   {
      Eina.Log.Debug("function efl_text_font_slant_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFont)wrapper).SetFontSlant( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_slant_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private static efl_text_font_slant_set_delegate efl_text_font_slant_set_static_delegate;


    private delegate Efl.TextFontWidth efl_text_font_width_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontWidth efl_text_font_width_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_width_get_api_delegate> efl_text_font_width_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_width_get_api_delegate>(_Module, "efl_text_font_width_get");
    private static Efl.TextFontWidth font_width_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_width_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontWidth _ret_var = default(Efl.TextFontWidth);
         try {
            _ret_var = ((TextFont)wrapper).GetFontWidth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_width_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_width_get_delegate efl_text_font_width_get_static_delegate;


    private delegate  void efl_text_font_width_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontWidth width);


    public delegate  void efl_text_font_width_set_api_delegate(System.IntPtr obj,   Efl.TextFontWidth width);
    public static Efl.Eo.FunctionWrapper<efl_text_font_width_set_api_delegate> efl_text_font_width_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_width_set_api_delegate>(_Module, "efl_text_font_width_set");
    private static  void font_width_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWidth width)
   {
      Eina.Log.Debug("function efl_text_font_width_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFont)wrapper).SetFontWidth( width);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_width_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  width);
      }
   }
   private static efl_text_font_width_set_delegate efl_text_font_width_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_text_font_lang_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_text_font_lang_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_lang_get_api_delegate> efl_text_font_lang_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_lang_get_api_delegate>(_Module, "efl_text_font_lang_get");
    private static  System.String font_lang_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_lang_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextFont)wrapper).GetFontLang();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_lang_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_lang_get_delegate efl_text_font_lang_get_static_delegate;


    private delegate  void efl_text_font_lang_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String lang);


    public delegate  void efl_text_font_lang_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String lang);
    public static Efl.Eo.FunctionWrapper<efl_text_font_lang_set_api_delegate> efl_text_font_lang_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_lang_set_api_delegate>(_Module, "efl_text_font_lang_set");
    private static  void font_lang_set(System.IntPtr obj, System.IntPtr pd,   System.String lang)
   {
      Eina.Log.Debug("function efl_text_font_lang_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFont)wrapper).SetFontLang( lang);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_lang_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  lang);
      }
   }
   private static efl_text_font_lang_set_delegate efl_text_font_lang_set_static_delegate;


    private delegate Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate> efl_text_font_bitmap_scalable_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate>(_Module, "efl_text_font_bitmap_scalable_get");
    private static Efl.TextFontBitmapScalable font_bitmap_scalable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_font_bitmap_scalable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFontBitmapScalable _ret_var = default(Efl.TextFontBitmapScalable);
         try {
            _ret_var = ((TextFont)wrapper).GetFontBitmapScalable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_font_bitmap_scalable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_text_font_bitmap_scalable_get_delegate efl_text_font_bitmap_scalable_get_static_delegate;


    private delegate  void efl_text_font_bitmap_scalable_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFontBitmapScalable scalable);


    public delegate  void efl_text_font_bitmap_scalable_set_api_delegate(System.IntPtr obj,   Efl.TextFontBitmapScalable scalable);
    public static Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate> efl_text_font_bitmap_scalable_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate>(_Module, "efl_text_font_bitmap_scalable_set");
    private static  void font_bitmap_scalable_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontBitmapScalable scalable)
   {
      Eina.Log.Debug("function efl_text_font_bitmap_scalable_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFont)wrapper).SetFontBitmapScalable( scalable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_font_bitmap_scalable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scalable);
      }
   }
   private static efl_text_font_bitmap_scalable_set_delegate efl_text_font_bitmap_scalable_set_static_delegate;
}
} 
namespace Efl { 
/// <summary>Type of font weight</summary>
public enum TextFontWeight
{
/// <summary>Normal font weight</summary>
Normal = 0,
/// <summary>Thin font weight</summary>
Thin = 1,
/// <summary>Ultralight font weight</summary>
Ultralight = 2,
/// <summary>Extralight font weight</summary>
Extralight = 3,
/// <summary>Light font weight</summary>
Light = 4,
/// <summary>Book font weight</summary>
Book = 5,
/// <summary>Medium font weight</summary>
Medium = 6,
/// <summary>Semibold font weight</summary>
Semibold = 7,
/// <summary>Bold font weight</summary>
Bold = 8,
/// <summary>Ultrabold font weight</summary>
Ultrabold = 9,
/// <summary>Extrabold font weight</summary>
Extrabold = 10,
/// <summary>Black font weight</summary>
Black = 11,
/// <summary>Extrablack font weight</summary>
Extrablack = 12,
}
} 
namespace Efl { 
/// <summary>Type of font width</summary>
public enum TextFontWidth
{
/// <summary>Normal font width</summary>
Normal = 0,
/// <summary>Ultracondensed font width</summary>
Ultracondensed = 1,
/// <summary>Extracondensed font width</summary>
Extracondensed = 2,
/// <summary>Condensed font width</summary>
Condensed = 3,
/// <summary>Semicondensed font width</summary>
Semicondensed = 4,
/// <summary>Semiexpanded font width</summary>
Semiexpanded = 5,
/// <summary>Expanded font width</summary>
Expanded = 6,
/// <summary>Extraexpanded font width</summary>
Extraexpanded = 7,
/// <summary>Ultraexpanded font width</summary>
Ultraexpanded = 8,
}
} 
namespace Efl { 
/// <summary>Type of font slant</summary>
public enum TextFontSlant
{
/// <summary>Normal font slant</summary>
Normal = 0,
/// <summary>Oblique font slant</summary>
Oblique = 1,
/// <summary>Italic font slant</summary>
Italic = 2,
}
} 
namespace Efl { 
/// <summary>Scalable of bitmap fonts
/// 1.21</summary>
public enum TextFontBitmapScalable
{
/// <summary>Disable scalable feature for bitmap fonts.</summary>
None = 0,
/// <summary>Enable scalable feature for color bitmap fonts.</summary>
Color = 1,
}
} 
