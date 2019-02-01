#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>The look and layout of the text
/// The text format can affect the geometry of the text object, as well as how characters are presented.
/// 1.20</summary>
[TextFormatConcreteNativeInherit]
public interface TextFormat : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
/// 1.20</summary>
/// <returns>Ellipsis value
/// 1.20</returns>
double GetEllipsis();
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
/// 1.20</summary>
/// <param name="value">Ellipsis value
/// 1.20</param>
/// <returns></returns>
 void SetEllipsis( double value);
   /// <summary>Wrap mode for use in the text
/// 1.20</summary>
/// <returns>Wrap mode
/// 1.20</returns>
Efl.TextFormatWrap GetWrap();
   /// <summary>Wrap mode for use in the text
/// 1.20</summary>
/// <param name="wrap">Wrap mode
/// 1.20</param>
/// <returns></returns>
 void SetWrap( Efl.TextFormatWrap wrap);
   /// <summary>Multiline is enabled or not
/// 1.20</summary>
/// <returns><c>true</c> if multiline is enabled, <c>false</c> otherwise
/// 1.20</returns>
bool GetMultiline();
   /// <summary>Multiline is enabled or not
/// 1.20</summary>
/// <param name="enabled"><c>true</c> if multiline is enabled, <c>false</c> otherwise
/// 1.20</param>
/// <returns></returns>
 void SetMultiline( bool enabled);
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
/// <returns>Alignment type
/// 1.20</returns>
Efl.TextFormatHorizontalAlignmentAutoType GetHalignAutoType();
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
/// <param name="value">Alignment type
/// 1.20</param>
/// <returns></returns>
 void SetHalignAutoType( Efl.TextFormatHorizontalAlignmentAutoType value);
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
/// <returns>Horizontal alignment value
/// 1.20</returns>
double GetHalign();
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
/// <param name="value">Horizontal alignment value
/// 1.20</param>
/// <returns></returns>
 void SetHalign( double value);
   /// <summary>Vertical alignment of text
/// 1.20</summary>
/// <returns>Vertical alignment value
/// 1.20</returns>
double GetValign();
   /// <summary>Vertical alignment of text
/// 1.20</summary>
/// <param name="value">Vertical alignment value
/// 1.20</param>
/// <returns></returns>
 void SetValign( double value);
   /// <summary>Minimal line gap (top and bottom) for each line in the text
/// <c>value</c> is absolute size.
/// 1.20</summary>
/// <returns>Line gap value
/// 1.20</returns>
double GetLinegap();
   /// <summary>Minimal line gap (top and bottom) for each line in the text
/// <c>value</c> is absolute size.
/// 1.20</summary>
/// <param name="value">Line gap value
/// 1.20</param>
/// <returns></returns>
 void SetLinegap( double value);
   /// <summary>Relative line gap (top and bottom) for each line in the text
/// The original line gap value is multiplied by <c>value</c>.
/// 1.20</summary>
/// <returns>Relative line gap value
/// 1.20</returns>
double GetLinerelgap();
   /// <summary>Relative line gap (top and bottom) for each line in the text
/// The original line gap value is multiplied by <c>value</c>.
/// 1.20</summary>
/// <param name="value">Relative line gap value
/// 1.20</param>
/// <returns></returns>
 void SetLinerelgap( double value);
   /// <summary>Tabstops value
/// 1.20</summary>
/// <returns>Tapstops value
/// 1.20</returns>
 int GetTabstops();
   /// <summary>Tabstops value
/// 1.20</summary>
/// <param name="value">Tapstops value
/// 1.20</param>
/// <returns></returns>
 void SetTabstops(  int value);
   /// <summary>Whether text is a password
/// 1.20</summary>
/// <returns><c>true</c> if the text is a password, <c>false</c> otherwise
/// 1.20</returns>
bool GetPassword();
   /// <summary>Whether text is a password
/// 1.20</summary>
/// <param name="enabled"><c>true</c> if the text is a password, <c>false</c> otherwise
/// 1.20</param>
/// <returns></returns>
 void SetPassword( bool enabled);
   /// <summary>The character used to replace characters that can&apos;t be displayed
/// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
/// 1.20</summary>
/// <returns>Replacement character
/// 1.20</returns>
 System.String GetReplacementChar();
   /// <summary>The character used to replace characters that can&apos;t be displayed
/// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
/// 1.20</summary>
/// <param name="repch">Replacement character
/// 1.20</param>
/// <returns></returns>
 void SetReplacementChar(  System.String repch);
                                                                     /// <summary>Ellipsis value (number from -1.0 to 1.0)
/// 1.20</summary>
   double Ellipsis {
      get ;
      set ;
   }
   /// <summary>Wrap mode for use in the text
/// 1.20</summary>
   Efl.TextFormatWrap Wrap {
      get ;
      set ;
   }
   /// <summary>Multiline is enabled or not
/// 1.20</summary>
   bool Multiline {
      get ;
      set ;
   }
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
   Efl.TextFormatHorizontalAlignmentAutoType HalignAutoType {
      get ;
      set ;
   }
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
   double Halign {
      get ;
      set ;
   }
   /// <summary>Vertical alignment of text
/// 1.20</summary>
   double Valign {
      get ;
      set ;
   }
   /// <summary>Minimal line gap (top and bottom) for each line in the text
/// <c>value</c> is absolute size.
/// 1.20</summary>
   double Linegap {
      get ;
      set ;
   }
   /// <summary>Relative line gap (top and bottom) for each line in the text
/// The original line gap value is multiplied by <c>value</c>.
/// 1.20</summary>
   double Linerelgap {
      get ;
      set ;
   }
   /// <summary>Tabstops value
/// 1.20</summary>
    int Tabstops {
      get ;
      set ;
   }
   /// <summary>Whether text is a password
/// 1.20</summary>
   bool Password {
      get ;
      set ;
   }
   /// <summary>The character used to replace characters that can&apos;t be displayed
/// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
/// 1.20</summary>
    System.String ReplacementChar {
      get ;
      set ;
   }
}
/// <summary>The look and layout of the text
/// The text format can affect the geometry of the text object, as well as how characters are presented.
/// 1.20</summary>
sealed public class TextFormatConcrete : 

TextFormat
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TextFormatConcrete))
            return Efl.TextFormatConcreteNativeInherit.GetEflClassStatic();
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
      efl_text_format_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public TextFormatConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~TextFormatConcrete()
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
   public static TextFormatConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TextFormatConcrete(obj.NativeHandle);
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
    private static extern double efl_text_ellipsis_get(System.IntPtr obj);
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
   /// 1.20</summary>
   /// <returns>Ellipsis value
   /// 1.20</returns>
   public double GetEllipsis() {
       var _ret_var = efl_text_ellipsis_get(Efl.TextFormatConcrete.efl_text_format_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_ellipsis_set(System.IntPtr obj,   double value);
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
   /// 1.20</summary>
   /// <param name="value">Ellipsis value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetEllipsis( double value) {
                         efl_text_ellipsis_set(Efl.TextFormatConcrete.efl_text_format_interface_get(),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.TextFormatWrap efl_text_wrap_get(System.IntPtr obj);
   /// <summary>Wrap mode for use in the text
   /// 1.20</summary>
   /// <returns>Wrap mode
   /// 1.20</returns>
   public Efl.TextFormatWrap GetWrap() {
       var _ret_var = efl_text_wrap_get(Efl.TextFormatConcrete.efl_text_format_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_wrap_set(System.IntPtr obj,   Efl.TextFormatWrap wrap);
   /// <summary>Wrap mode for use in the text
   /// 1.20</summary>
   /// <param name="wrap">Wrap mode
   /// 1.20</param>
   /// <returns></returns>
   public  void SetWrap( Efl.TextFormatWrap wrap) {
                         efl_text_wrap_set(Efl.TextFormatConcrete.efl_text_format_interface_get(),  wrap);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_multiline_get(System.IntPtr obj);
   /// <summary>Multiline is enabled or not
   /// 1.20</summary>
   /// <returns><c>true</c> if multiline is enabled, <c>false</c> otherwise
   /// 1.20</returns>
   public bool GetMultiline() {
       var _ret_var = efl_text_multiline_get(Efl.TextFormatConcrete.efl_text_format_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_multiline_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   /// <summary>Multiline is enabled or not
   /// 1.20</summary>
   /// <param name="enabled"><c>true</c> if multiline is enabled, <c>false</c> otherwise
   /// 1.20</param>
   /// <returns></returns>
   public  void SetMultiline( bool enabled) {
                         efl_text_multiline_set(Efl.TextFormatConcrete.efl_text_format_interface_get(),  enabled);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get(System.IntPtr obj);
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <returns>Alignment type
   /// 1.20</returns>
   public Efl.TextFormatHorizontalAlignmentAutoType GetHalignAutoType() {
       var _ret_var = efl_text_halign_auto_type_get(Efl.TextFormatConcrete.efl_text_format_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_halign_auto_type_set(System.IntPtr obj,   Efl.TextFormatHorizontalAlignmentAutoType value);
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <param name="value">Alignment type
   /// 1.20</param>
   /// <returns></returns>
   public  void SetHalignAutoType( Efl.TextFormatHorizontalAlignmentAutoType value) {
                         efl_text_halign_auto_type_set(Efl.TextFormatConcrete.efl_text_format_interface_get(),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_text_halign_get(System.IntPtr obj);
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <returns>Horizontal alignment value
   /// 1.20</returns>
   public double GetHalign() {
       var _ret_var = efl_text_halign_get(Efl.TextFormatConcrete.efl_text_format_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_halign_set(System.IntPtr obj,   double value);
   /// <summary>Horizontal alignment of text
   /// 1.20</summary>
   /// <param name="value">Horizontal alignment value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetHalign( double value) {
                         efl_text_halign_set(Efl.TextFormatConcrete.efl_text_format_interface_get(),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_text_valign_get(System.IntPtr obj);
   /// <summary>Vertical alignment of text
   /// 1.20</summary>
   /// <returns>Vertical alignment value
   /// 1.20</returns>
   public double GetValign() {
       var _ret_var = efl_text_valign_get(Efl.TextFormatConcrete.efl_text_format_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_valign_set(System.IntPtr obj,   double value);
   /// <summary>Vertical alignment of text
   /// 1.20</summary>
   /// <param name="value">Vertical alignment value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetValign( double value) {
                         efl_text_valign_set(Efl.TextFormatConcrete.efl_text_format_interface_get(),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_text_linegap_get(System.IntPtr obj);
   /// <summary>Minimal line gap (top and bottom) for each line in the text
   /// <c>value</c> is absolute size.
   /// 1.20</summary>
   /// <returns>Line gap value
   /// 1.20</returns>
   public double GetLinegap() {
       var _ret_var = efl_text_linegap_get(Efl.TextFormatConcrete.efl_text_format_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_linegap_set(System.IntPtr obj,   double value);
   /// <summary>Minimal line gap (top and bottom) for each line in the text
   /// <c>value</c> is absolute size.
   /// 1.20</summary>
   /// <param name="value">Line gap value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetLinegap( double value) {
                         efl_text_linegap_set(Efl.TextFormatConcrete.efl_text_format_interface_get(),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_text_linerelgap_get(System.IntPtr obj);
   /// <summary>Relative line gap (top and bottom) for each line in the text
   /// The original line gap value is multiplied by <c>value</c>.
   /// 1.20</summary>
   /// <returns>Relative line gap value
   /// 1.20</returns>
   public double GetLinerelgap() {
       var _ret_var = efl_text_linerelgap_get(Efl.TextFormatConcrete.efl_text_format_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_linerelgap_set(System.IntPtr obj,   double value);
   /// <summary>Relative line gap (top and bottom) for each line in the text
   /// The original line gap value is multiplied by <c>value</c>.
   /// 1.20</summary>
   /// <param name="value">Relative line gap value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetLinerelgap( double value) {
                         efl_text_linerelgap_set(Efl.TextFormatConcrete.efl_text_format_interface_get(),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  int efl_text_tabstops_get(System.IntPtr obj);
   /// <summary>Tabstops value
   /// 1.20</summary>
   /// <returns>Tapstops value
   /// 1.20</returns>
   public  int GetTabstops() {
       var _ret_var = efl_text_tabstops_get(Efl.TextFormatConcrete.efl_text_format_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_tabstops_set(System.IntPtr obj,    int value);
   /// <summary>Tabstops value
   /// 1.20</summary>
   /// <param name="value">Tapstops value
   /// 1.20</param>
   /// <returns></returns>
   public  void SetTabstops(  int value) {
                         efl_text_tabstops_set(Efl.TextFormatConcrete.efl_text_format_interface_get(),  value);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_password_get(System.IntPtr obj);
   /// <summary>Whether text is a password
   /// 1.20</summary>
   /// <returns><c>true</c> if the text is a password, <c>false</c> otherwise
   /// 1.20</returns>
   public bool GetPassword() {
       var _ret_var = efl_text_password_get(Efl.TextFormatConcrete.efl_text_format_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_password_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   /// <summary>Whether text is a password
   /// 1.20</summary>
   /// <param name="enabled"><c>true</c> if the text is a password, <c>false</c> otherwise
   /// 1.20</param>
   /// <returns></returns>
   public  void SetPassword( bool enabled) {
                         efl_text_password_set(Efl.TextFormatConcrete.efl_text_format_interface_get(),  enabled);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private static extern  System.String efl_text_replacement_char_get(System.IntPtr obj);
   /// <summary>The character used to replace characters that can&apos;t be displayed
   /// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
   /// 1.20</summary>
   /// <returns>Replacement character
   /// 1.20</returns>
   public  System.String GetReplacementChar() {
       var _ret_var = efl_text_replacement_char_get(Efl.TextFormatConcrete.efl_text_format_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_text_replacement_char_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String repch);
   /// <summary>The character used to replace characters that can&apos;t be displayed
   /// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
   /// 1.20</summary>
   /// <param name="repch">Replacement character
   /// 1.20</param>
   /// <returns></returns>
   public  void SetReplacementChar(  System.String repch) {
                         efl_text_replacement_char_set(Efl.TextFormatConcrete.efl_text_format_interface_get(),  repch);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Ellipsis value (number from -1.0 to 1.0)
/// 1.20</summary>
   public double Ellipsis {
      get { return GetEllipsis(); }
      set { SetEllipsis( value); }
   }
   /// <summary>Wrap mode for use in the text
/// 1.20</summary>
   public Efl.TextFormatWrap Wrap {
      get { return GetWrap(); }
      set { SetWrap( value); }
   }
   /// <summary>Multiline is enabled or not
/// 1.20</summary>
   public bool Multiline {
      get { return GetMultiline(); }
      set { SetMultiline( value); }
   }
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
   public Efl.TextFormatHorizontalAlignmentAutoType HalignAutoType {
      get { return GetHalignAutoType(); }
      set { SetHalignAutoType( value); }
   }
   /// <summary>Horizontal alignment of text
/// 1.20</summary>
   public double Halign {
      get { return GetHalign(); }
      set { SetHalign( value); }
   }
   /// <summary>Vertical alignment of text
/// 1.20</summary>
   public double Valign {
      get { return GetValign(); }
      set { SetValign( value); }
   }
   /// <summary>Minimal line gap (top and bottom) for each line in the text
/// <c>value</c> is absolute size.
/// 1.20</summary>
   public double Linegap {
      get { return GetLinegap(); }
      set { SetLinegap( value); }
   }
   /// <summary>Relative line gap (top and bottom) for each line in the text
/// The original line gap value is multiplied by <c>value</c>.
/// 1.20</summary>
   public double Linerelgap {
      get { return GetLinerelgap(); }
      set { SetLinerelgap( value); }
   }
   /// <summary>Tabstops value
/// 1.20</summary>
   public  int Tabstops {
      get { return GetTabstops(); }
      set { SetTabstops( value); }
   }
   /// <summary>Whether text is a password
/// 1.20</summary>
   public bool Password {
      get { return GetPassword(); }
      set { SetPassword( value); }
   }
   /// <summary>The character used to replace characters that can&apos;t be displayed
/// Currently only used to replace characters if <see cref="Efl.TextFormat.Password"/> is enabled.
/// 1.20</summary>
   public  System.String ReplacementChar {
      get { return GetReplacementChar(); }
      set { SetReplacementChar( value); }
   }
}
public class TextFormatConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_text_ellipsis_get_static_delegate = new efl_text_ellipsis_get_delegate(ellipsis_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_ellipsis_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_get_static_delegate)});
      efl_text_ellipsis_set_static_delegate = new efl_text_ellipsis_set_delegate(ellipsis_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_ellipsis_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_set_static_delegate)});
      efl_text_wrap_get_static_delegate = new efl_text_wrap_get_delegate(wrap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_wrap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_get_static_delegate)});
      efl_text_wrap_set_static_delegate = new efl_text_wrap_set_delegate(wrap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_wrap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_set_static_delegate)});
      efl_text_multiline_get_static_delegate = new efl_text_multiline_get_delegate(multiline_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_multiline_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_get_static_delegate)});
      efl_text_multiline_set_static_delegate = new efl_text_multiline_set_delegate(multiline_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_multiline_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_set_static_delegate)});
      efl_text_halign_auto_type_get_static_delegate = new efl_text_halign_auto_type_get_delegate(halign_auto_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_halign_auto_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_get_static_delegate)});
      efl_text_halign_auto_type_set_static_delegate = new efl_text_halign_auto_type_set_delegate(halign_auto_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_halign_auto_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_set_static_delegate)});
      efl_text_halign_get_static_delegate = new efl_text_halign_get_delegate(halign_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_halign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_get_static_delegate)});
      efl_text_halign_set_static_delegate = new efl_text_halign_set_delegate(halign_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_halign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_set_static_delegate)});
      efl_text_valign_get_static_delegate = new efl_text_valign_get_delegate(valign_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_valign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_get_static_delegate)});
      efl_text_valign_set_static_delegate = new efl_text_valign_set_delegate(valign_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_valign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_set_static_delegate)});
      efl_text_linegap_get_static_delegate = new efl_text_linegap_get_delegate(linegap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_linegap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_get_static_delegate)});
      efl_text_linegap_set_static_delegate = new efl_text_linegap_set_delegate(linegap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_linegap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_set_static_delegate)});
      efl_text_linerelgap_get_static_delegate = new efl_text_linerelgap_get_delegate(linerelgap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_linerelgap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_get_static_delegate)});
      efl_text_linerelgap_set_static_delegate = new efl_text_linerelgap_set_delegate(linerelgap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_linerelgap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_set_static_delegate)});
      efl_text_tabstops_get_static_delegate = new efl_text_tabstops_get_delegate(tabstops_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_tabstops_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_get_static_delegate)});
      efl_text_tabstops_set_static_delegate = new efl_text_tabstops_set_delegate(tabstops_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_tabstops_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_set_static_delegate)});
      efl_text_password_get_static_delegate = new efl_text_password_get_delegate(password_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_password_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_get_static_delegate)});
      efl_text_password_set_static_delegate = new efl_text_password_set_delegate(password_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_password_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_set_static_delegate)});
      efl_text_replacement_char_get_static_delegate = new efl_text_replacement_char_get_delegate(replacement_char_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_replacement_char_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_get_static_delegate)});
      efl_text_replacement_char_set_static_delegate = new efl_text_replacement_char_set_delegate(replacement_char_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_replacement_char_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.TextFormatConcrete.efl_text_format_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.TextFormatConcrete.efl_text_format_interface_get();
   }


    private delegate double efl_text_ellipsis_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_text_ellipsis_get(System.IntPtr obj);
    private static double ellipsis_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_ellipsis_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((TextFormat)wrapper).GetEllipsis();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_ellipsis_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_ellipsis_get_delegate efl_text_ellipsis_get_static_delegate;


    private delegate  void efl_text_ellipsis_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_ellipsis_set(System.IntPtr obj,   double value);
    private static  void ellipsis_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_ellipsis_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFormat)wrapper).SetEllipsis( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_ellipsis_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_ellipsis_set_delegate efl_text_ellipsis_set_static_delegate;


    private delegate Efl.TextFormatWrap efl_text_wrap_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextFormatWrap efl_text_wrap_get(System.IntPtr obj);
    private static Efl.TextFormatWrap wrap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_wrap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFormatWrap _ret_var = default(Efl.TextFormatWrap);
         try {
            _ret_var = ((TextFormat)wrapper).GetWrap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_wrap_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_wrap_get_delegate efl_text_wrap_get_static_delegate;


    private delegate  void efl_text_wrap_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFormatWrap wrap);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_wrap_set(System.IntPtr obj,   Efl.TextFormatWrap wrap);
    private static  void wrap_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatWrap wrap)
   {
      Eina.Log.Debug("function efl_text_wrap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFormat)wrapper).SetWrap( wrap);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_wrap_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  wrap);
      }
   }
   private efl_text_wrap_set_delegate efl_text_wrap_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_multiline_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_multiline_get(System.IntPtr obj);
    private static bool multiline_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_multiline_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((TextFormat)wrapper).GetMultiline();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_multiline_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_multiline_get_delegate efl_text_multiline_get_static_delegate;


    private delegate  void efl_text_multiline_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_multiline_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    private static  void multiline_set(System.IntPtr obj, System.IntPtr pd,  bool enabled)
   {
      Eina.Log.Debug("function efl_text_multiline_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFormat)wrapper).SetMultiline( enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_multiline_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enabled);
      }
   }
   private efl_text_multiline_set_delegate efl_text_multiline_set_static_delegate;


    private delegate Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get(System.IntPtr obj);
    private static Efl.TextFormatHorizontalAlignmentAutoType halign_auto_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_halign_auto_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextFormatHorizontalAlignmentAutoType _ret_var = default(Efl.TextFormatHorizontalAlignmentAutoType);
         try {
            _ret_var = ((TextFormat)wrapper).GetHalignAutoType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_halign_auto_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_halign_auto_type_get_delegate efl_text_halign_auto_type_get_static_delegate;


    private delegate  void efl_text_halign_auto_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextFormatHorizontalAlignmentAutoType value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_halign_auto_type_set(System.IntPtr obj,   Efl.TextFormatHorizontalAlignmentAutoType value);
    private static  void halign_auto_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatHorizontalAlignmentAutoType value)
   {
      Eina.Log.Debug("function efl_text_halign_auto_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFormat)wrapper).SetHalignAutoType( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_halign_auto_type_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_halign_auto_type_set_delegate efl_text_halign_auto_type_set_static_delegate;


    private delegate double efl_text_halign_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_text_halign_get(System.IntPtr obj);
    private static double halign_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_halign_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((TextFormat)wrapper).GetHalign();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_halign_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_halign_get_delegate efl_text_halign_get_static_delegate;


    private delegate  void efl_text_halign_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_halign_set(System.IntPtr obj,   double value);
    private static  void halign_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_halign_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFormat)wrapper).SetHalign( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_halign_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_halign_set_delegate efl_text_halign_set_static_delegate;


    private delegate double efl_text_valign_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_text_valign_get(System.IntPtr obj);
    private static double valign_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_valign_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((TextFormat)wrapper).GetValign();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_valign_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_valign_get_delegate efl_text_valign_get_static_delegate;


    private delegate  void efl_text_valign_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_valign_set(System.IntPtr obj,   double value);
    private static  void valign_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_valign_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFormat)wrapper).SetValign( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_valign_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_valign_set_delegate efl_text_valign_set_static_delegate;


    private delegate double efl_text_linegap_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_text_linegap_get(System.IntPtr obj);
    private static double linegap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_linegap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((TextFormat)wrapper).GetLinegap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_linegap_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_linegap_get_delegate efl_text_linegap_get_static_delegate;


    private delegate  void efl_text_linegap_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_linegap_set(System.IntPtr obj,   double value);
    private static  void linegap_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_linegap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFormat)wrapper).SetLinegap( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_linegap_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_linegap_set_delegate efl_text_linegap_set_static_delegate;


    private delegate double efl_text_linerelgap_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_text_linerelgap_get(System.IntPtr obj);
    private static double linerelgap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_linerelgap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((TextFormat)wrapper).GetLinerelgap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_linerelgap_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_linerelgap_get_delegate efl_text_linerelgap_get_static_delegate;


    private delegate  void efl_text_linerelgap_set_delegate(System.IntPtr obj, System.IntPtr pd,   double value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_linerelgap_set(System.IntPtr obj,   double value);
    private static  void linerelgap_set(System.IntPtr obj, System.IntPtr pd,  double value)
   {
      Eina.Log.Debug("function efl_text_linerelgap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFormat)wrapper).SetLinerelgap( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_linerelgap_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_linerelgap_set_delegate efl_text_linerelgap_set_static_delegate;


    private delegate  int efl_text_tabstops_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_text_tabstops_get(System.IntPtr obj);
    private static  int tabstops_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_tabstops_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((TextFormat)wrapper).GetTabstops();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_tabstops_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_tabstops_get_delegate efl_text_tabstops_get_static_delegate;


    private delegate  void efl_text_tabstops_set_delegate(System.IntPtr obj, System.IntPtr pd,    int value);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_tabstops_set(System.IntPtr obj,    int value);
    private static  void tabstops_set(System.IntPtr obj, System.IntPtr pd,   int value)
   {
      Eina.Log.Debug("function efl_text_tabstops_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFormat)wrapper).SetTabstops( value);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_tabstops_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  value);
      }
   }
   private efl_text_tabstops_set_delegate efl_text_tabstops_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_text_password_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_text_password_get(System.IntPtr obj);
    private static bool password_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_password_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((TextFormat)wrapper).GetPassword();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_text_password_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_password_get_delegate efl_text_password_get_static_delegate;


    private delegate  void efl_text_password_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_password_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enabled);
    private static  void password_set(System.IntPtr obj, System.IntPtr pd,  bool enabled)
   {
      Eina.Log.Debug("function efl_text_password_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFormat)wrapper).SetPassword( enabled);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_password_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enabled);
      }
   }
   private efl_text_password_set_delegate efl_text_password_set_static_delegate;


    private delegate  System.IntPtr efl_text_replacement_char_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_replacement_char_get(System.IntPtr obj);
    private static  System.IntPtr replacement_char_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_replacement_char_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((TextFormat)wrapper).GetReplacementChar();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((TextFormatConcrete)wrapper).cached_strings, _ret_var);
      } else {
         return efl_text_replacement_char_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_replacement_char_get_delegate efl_text_replacement_char_get_static_delegate;


    private delegate  void efl_text_replacement_char_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String repch);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_replacement_char_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String repch);
    private static  void replacement_char_set(System.IntPtr obj, System.IntPtr pd,   System.String repch)
   {
      Eina.Log.Debug("function efl_text_replacement_char_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((TextFormat)wrapper).SetReplacementChar( repch);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_replacement_char_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  repch);
      }
   }
   private efl_text_replacement_char_set_delegate efl_text_replacement_char_set_static_delegate;
}
} 
namespace Efl { 
/// <summary>Wrap mode of the text (not in effect if not multiline)</summary>
public enum TextFormatWrap
{
/// <summary>No wrapping</summary>
None = 0,
/// <summary>Wrap mode character</summary>
Char = 1,
/// <summary>Wrap mode word</summary>
Word = 2,
/// <summary>Wrap mode mixed</summary>
Mixed = 3,
/// <summary>Wrap mode hyphenation</summary>
Hyphenation = 4,
}
} 
namespace Efl { 
/// <summary>Auto-horizontal alignment of the text</summary>
public enum TextFormatHorizontalAlignmentAutoType
{
/// <summary>No auto-alignment rule</summary>
None = 0,
/// <summary>Respects LTR/RTL (bidirectional) settings</summary>
Normal = 1,
/// <summary>Respects locale&apos;s langauge settings</summary>
Locale = 2,
/// <summary>Text is places at opposite side of LTR/RTL (bidirectional) settings</summary>
End = 3,
}
} 
