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

/// <param name="str">Output formatted string. Its contents will be overwritten by this method.</param>
/// <param name="value">The <see cref="Eina.Value"/> to convert to text.</param>
[Efl.Eo.BindingEntity]
public delegate bool FormatFunc(Eina.Strbuf str, Eina.Value value);
[return: MarshalAs(UnmanagedType.U1)]public delegate bool FormatFuncInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))] Eina.Strbuf str,  Eina.ValueNative value);
internal class FormatFuncWrapper : IDisposable
{

    private FormatFuncInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal FormatFuncWrapper (FormatFuncInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~FormatFuncWrapper()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._cb_free_cb != null)
        {
            if (disposing)
            {
                this._cb_free_cb(this._cb_data);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
            }
            this._cb_free_cb = null;
            this._cb_data = IntPtr.Zero;
            this._cb = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    internal bool ManagedCb(Eina.Strbuf str,Eina.Value value)
    {
                                                        var _ret_var = _cb(_cb_data, str, value);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
    }

    [return: MarshalAs(UnmanagedType.U1)]    internal static bool Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))] Eina.Strbuf str,  Eina.ValueNative value)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        FormatFunc cb = (FormatFunc)handle.Target;
                                                            bool _ret_var = default(bool);
        try {
            _ret_var = cb(str, value);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                                        return _ret_var;
    }
}
}

}

namespace Efl {

namespace Ui {

/// <summary>Helper mixin that simplifies converting numerical values to text.
/// A number of widgets represent a numerical value but display a text representation. For example, an <see cref="Efl.Ui.Progressbar"/> can hold the number 0.75 but display the string &quot;75%&quot;, or an <see cref="Efl.Ui.Spin"/> can hold numbers 1 to 7, but display the strings &quot;Monday&quot; thru &quot;Sunday&quot;.
/// 
/// This conversion can be controlled through the <see cref="Efl.Ui.IFormat.FormatFunc"/>, <see cref="Efl.Ui.IFormat.FormatValues"/> and <see cref="Efl.Ui.IFormat.GetFormatString"/> properties. Only one of them needs to be set. When more than one is set <see cref="Efl.Ui.IFormat.FormatValues"/> has the highest priority, followed by <see cref="Efl.Ui.IFormat.FormatFunc"/> and then <see cref="Efl.Ui.IFormat.GetFormatString"/>. If one mechanism fails to produce a valid string the others will be tried (if provided) in descending order of priority. If no user-provided mechanism works, a fallback is used that just displays the value.
/// 
/// Widgets including this mixin offer their users different properties to control how <see cref="Eina.Value"/>&apos;s are converted to text.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.IFormatConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IFormat : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
/// <returns>User-provided formatting function.</returns>
Efl.Ui.FormatFunc GetFormatFunc();
    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
/// <param name="func">User-provided formatting function.</param>
void SetFormatFunc(Efl.Ui.FormatFunc func);
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
/// <returns>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</returns>
Eina.Accessor<Efl.Ui.FormatValue> GetFormatValues();
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
/// <param name="values">Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</param>
void SetFormatValues(Eina.Accessor<Efl.Ui.FormatValue> values);
    /// <summary>A user-provided, string used to format the numerical value.
/// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
/// 
/// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
/// 
/// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="Efl.Ui.FormatStringType.Simple"/> for simple numerical values and <see cref="Efl.Ui.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
/// 
/// Pass <c>NULL</c> to disable this mechanism.</summary>
/// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
/// <param name="type">Type of formatting string, which controls how the different format specifiers are to be traslated.</param>
void GetFormatString(out System.String kw_string, out Efl.Ui.FormatStringType type);
    /// <summary>A user-provided, string used to format the numerical value.
/// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
/// 
/// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
/// 
/// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="Efl.Ui.FormatStringType.Simple"/> for simple numerical values and <see cref="Efl.Ui.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
/// 
/// Pass <c>NULL</c> to disable this mechanism.</summary>
/// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
/// <param name="type">Type of formatting string, which controls how the different format specifiers are to be traslated.</param>
void SetFormatString(System.String kw_string, Efl.Ui.FormatStringType type);
    /// <summary>Internal method to be used by widgets including this mixin to perform the conversion from the internal numerical value into the text representation (Users of these widgets do not need to call this method).
/// <see cref="Efl.Ui.IFormat.GetFormattedValue"/> uses any user-provided mechanism to perform the conversion, according to their priorities, and implements a simple fallback if all mechanisms fail.</summary>
/// <param name="str">Output formatted string. Its contents will be overwritten by this method.</param>
/// <param name="value">The <see cref="Eina.Value"/> to convert to text.</param>
void GetFormattedValue(Eina.Strbuf str, Eina.Value value);
    /// <summary>Internal method to be used by widgets including this mixin. It can only be used when a <see cref="Efl.Ui.IFormat.GetFormatString"/> has been supplied, and it returns the number of decimal places that the format string will produce for floating point values.
/// For example, &quot;%.2f&quot; returns 2, and &quot;%d&quot; returns 0;</summary>
/// <returns>Number of decimal places, or 0 for non-floating point types.</returns>
int GetDecimalPlaces();
    /// <summary>Internal method to be implemented by widgets including this mixin.
/// The mixin will call this method to signal the widget that the formatting has changed and therefore the current value should be converted and rendered again. Widgets must typically call <see cref="Efl.Ui.IFormat.GetFormattedValue"/> and display the returned string. This is something they are already doing (whenever the value changes, for example) so there should be no extra code written to implement this method.</summary>
void ApplyFormattedValue();
                                        /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <value>User-provided formatting function.</value>
    Efl.Ui.FormatFunc FormatFunc {
        get;
        set;
    }
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <value>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</value>
    Eina.Accessor<Efl.Ui.FormatValue> FormatValues {
        get;
        set;
    }
    /// <summary>A user-provided, string used to format the numerical value.
    /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
    /// 
    /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
    /// 
    /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="Efl.Ui.FormatStringType.Simple"/> for simple numerical values and <see cref="Efl.Ui.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
    /// 
    /// Pass <c>NULL</c> to disable this mechanism.</summary>
    /// <value>Formatting string containing regular characters and format specifiers.</value>
    (System.String, Efl.Ui.FormatStringType) FormatString {
        get;
        set;
    }
}
/// <summary>Helper mixin that simplifies converting numerical values to text.
/// A number of widgets represent a numerical value but display a text representation. For example, an <see cref="Efl.Ui.Progressbar"/> can hold the number 0.75 but display the string &quot;75%&quot;, or an <see cref="Efl.Ui.Spin"/> can hold numbers 1 to 7, but display the strings &quot;Monday&quot; thru &quot;Sunday&quot;.
/// 
/// This conversion can be controlled through the <see cref="Efl.Ui.IFormat.FormatFunc"/>, <see cref="Efl.Ui.IFormat.FormatValues"/> and <see cref="Efl.Ui.IFormat.GetFormatString"/> properties. Only one of them needs to be set. When more than one is set <see cref="Efl.Ui.IFormat.FormatValues"/> has the highest priority, followed by <see cref="Efl.Ui.IFormat.FormatFunc"/> and then <see cref="Efl.Ui.IFormat.GetFormatString"/>. If one mechanism fails to produce a valid string the others will be tried (if provided) in descending order of priority. If no user-provided mechanism works, a fallback is used that just displays the value.
/// 
/// Widgets including this mixin offer their users different properties to control how <see cref="Eina.Value"/>&apos;s are converted to text.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class IFormatConcrete :
    Efl.Eo.EoWrapper
    , IFormat
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IFormatConcrete))
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
    private IFormatConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_format_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IFormat"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IFormatConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <returns>User-provided formatting function.</returns>
    public Efl.Ui.FormatFunc GetFormatFunc() {
         var _ret_var = Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_func_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <param name="func">User-provided formatting function.</param>
    public void SetFormatFunc(Efl.Ui.FormatFunc func) {
                         GCHandle func_handle = GCHandle.Alloc(func);
        Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_func_set_ptr.Value.Delegate(this.NativeHandle,GCHandle.ToIntPtr(func_handle), Efl.Ui.FormatFuncWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <returns>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</returns>
    public Eina.Accessor<Efl.Ui.FormatValue> GetFormatValues() {
         var _ret_var = Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_values_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Accessor<Efl.Ui.FormatValue>(_ret_var, false);
 }
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <param name="values">Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</param>
    public void SetFormatValues(Eina.Accessor<Efl.Ui.FormatValue> values) {
         var _in_values = values.Handle;
                        Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_values_set_ptr.Value.Delegate(this.NativeHandle,_in_values);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A user-provided, string used to format the numerical value.
    /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
    /// 
    /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
    /// 
    /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="Efl.Ui.FormatStringType.Simple"/> for simple numerical values and <see cref="Efl.Ui.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
    /// 
    /// Pass <c>NULL</c> to disable this mechanism.</summary>
    /// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
    /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be traslated.</param>
    public void GetFormatString(out System.String kw_string, out Efl.Ui.FormatStringType type) {
                                                         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_string_get_ptr.Value.Delegate(this.NativeHandle,out kw_string, out type);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>A user-provided, string used to format the numerical value.
    /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
    /// 
    /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
    /// 
    /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="Efl.Ui.FormatStringType.Simple"/> for simple numerical values and <see cref="Efl.Ui.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
    /// 
    /// Pass <c>NULL</c> to disable this mechanism.</summary>
    /// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
    /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be traslated.</param>
    public void SetFormatString(System.String kw_string, Efl.Ui.FormatStringType type) {
                                                         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_string_set_ptr.Value.Delegate(this.NativeHandle,kw_string, type);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Internal method to be used by widgets including this mixin to perform the conversion from the internal numerical value into the text representation (Users of these widgets do not need to call this method).
    /// <see cref="Efl.Ui.IFormat.GetFormattedValue"/> uses any user-provided mechanism to perform the conversion, according to their priorities, and implements a simple fallback if all mechanisms fail.</summary>
    /// <param name="str">Output formatted string. Its contents will be overwritten by this method.</param>
    /// <param name="value">The <see cref="Eina.Value"/> to convert to text.</param>
    public void GetFormattedValue(Eina.Strbuf str, Eina.Value value) {
                                                         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_formatted_value_get_ptr.Value.Delegate(this.NativeHandle,str, value);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Internal method to be used by widgets including this mixin. It can only be used when a <see cref="Efl.Ui.IFormat.GetFormatString"/> has been supplied, and it returns the number of decimal places that the format string will produce for floating point values.
    /// For example, &quot;%.2f&quot; returns 2, and &quot;%d&quot; returns 0;</summary>
    /// <returns>Number of decimal places, or 0 for non-floating point types.</returns>
    public int GetDecimalPlaces() {
         var _ret_var = Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_decimal_places_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Internal method to be implemented by widgets including this mixin.
    /// The mixin will call this method to signal the widget that the formatting has changed and therefore the current value should be converted and rendered again. Widgets must typically call <see cref="Efl.Ui.IFormat.GetFormattedValue"/> and display the returned string. This is something they are already doing (whenever the value changes, for example) so there should be no extra code written to implement this method.</summary>
    public void ApplyFormattedValue() {
         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_apply_formatted_value_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <value>User-provided formatting function.</value>
    public Efl.Ui.FormatFunc FormatFunc {
        get { return GetFormatFunc(); }
        set { SetFormatFunc(value); }
    }
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <value>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</value>
    public Eina.Accessor<Efl.Ui.FormatValue> FormatValues {
        get { return GetFormatValues(); }
        set { SetFormatValues(value); }
    }
    /// <summary>A user-provided, string used to format the numerical value.
    /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
    /// 
    /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
    /// 
    /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="Efl.Ui.FormatStringType.Simple"/> for simple numerical values and <see cref="Efl.Ui.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
    /// 
    /// Pass <c>NULL</c> to disable this mechanism.</summary>
    /// <value>Formatting string containing regular characters and format specifiers.</value>
    public (System.String, Efl.Ui.FormatStringType) FormatString {
        get {
            System.String _out_kw_string = default(System.String);
            Efl.Ui.FormatStringType _out_type = default(Efl.Ui.FormatStringType);
            GetFormatString(out _out_kw_string,out _out_type);
            return (_out_kw_string,_out_type);
        }
        set { SetFormatString( value.Item1,  value.Item2); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IFormatConcrete.efl_ui_format_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_format_func_get_static_delegate == null)
            {
                efl_ui_format_func_get_static_delegate = new efl_ui_format_func_get_delegate(format_func_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormatFunc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_func_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_func_get_static_delegate) });
            }

            if (efl_ui_format_func_set_static_delegate == null)
            {
                efl_ui_format_func_set_static_delegate = new efl_ui_format_func_set_delegate(format_func_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFormatFunc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_func_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_func_set_static_delegate) });
            }

            if (efl_ui_format_values_get_static_delegate == null)
            {
                efl_ui_format_values_get_static_delegate = new efl_ui_format_values_get_delegate(format_values_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormatValues") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_values_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_values_get_static_delegate) });
            }

            if (efl_ui_format_values_set_static_delegate == null)
            {
                efl_ui_format_values_set_static_delegate = new efl_ui_format_values_set_delegate(format_values_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFormatValues") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_values_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_values_set_static_delegate) });
            }

            if (efl_ui_format_string_get_static_delegate == null)
            {
                efl_ui_format_string_get_static_delegate = new efl_ui_format_string_get_delegate(format_string_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormatString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_get_static_delegate) });
            }

            if (efl_ui_format_string_set_static_delegate == null)
            {
                efl_ui_format_string_set_static_delegate = new efl_ui_format_string_set_delegate(format_string_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFormatString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_set_static_delegate) });
            }

            if (efl_ui_format_formatted_value_get_static_delegate == null)
            {
                efl_ui_format_formatted_value_get_static_delegate = new efl_ui_format_formatted_value_get_delegate(formatted_value_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormattedValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_formatted_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_formatted_value_get_static_delegate) });
            }

            if (efl_ui_format_decimal_places_get_static_delegate == null)
            {
                efl_ui_format_decimal_places_get_static_delegate = new efl_ui_format_decimal_places_get_delegate(decimal_places_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDecimalPlaces") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_decimal_places_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_decimal_places_get_static_delegate) });
            }

            if (efl_ui_format_apply_formatted_value_static_delegate == null)
            {
                efl_ui_format_apply_formatted_value_static_delegate = new efl_ui_format_apply_formatted_value_delegate(apply_formatted_value);
            }

            if (methods.FirstOrDefault(m => m.Name == "ApplyFormattedValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_apply_formatted_value"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_apply_formatted_value_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IFormatConcrete.efl_ui_format_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Ui.FormatFunc efl_ui_format_func_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.FormatFunc efl_ui_format_func_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_func_get_api_delegate> efl_ui_format_func_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_func_get_api_delegate>(Module, "efl_ui_format_func_get");

        private static Efl.Ui.FormatFunc format_func_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_func_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.FormatFunc _ret_var = default(Efl.Ui.FormatFunc);
                try
                {
                    _ret_var = ((IFormat)ws.Target).GetFormatFunc();
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
                return efl_ui_format_func_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_func_get_delegate efl_ui_format_func_get_static_delegate;

        
        private delegate void efl_ui_format_func_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, Efl.Ui.FormatFuncInternal func, EinaFreeCb func_free_cb);

        
        public delegate void efl_ui_format_func_set_api_delegate(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_func_set_api_delegate> efl_ui_format_func_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_func_set_api_delegate>(Module, "efl_ui_format_func_set");

        private static void format_func_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, Efl.Ui.FormatFuncInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_ui_format_func_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                            Efl.Ui.FormatFuncWrapper func_wrapper = new Efl.Ui.FormatFuncWrapper(func, func_data, func_free_cb);
            
                try
                {
                    ((IFormat)ws.Target).SetFormatFunc(func_wrapper.ManagedCb);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_format_func_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
            }
        }

        private static efl_ui_format_func_set_delegate efl_ui_format_func_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_format_values_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_format_values_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_values_get_api_delegate> efl_ui_format_values_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_values_get_api_delegate>(Module, "efl_ui_format_values_get");

        private static System.IntPtr format_values_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_values_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Accessor<Efl.Ui.FormatValue> _ret_var = default(Eina.Accessor<Efl.Ui.FormatValue>);
                try
                {
                    _ret_var = ((IFormat)ws.Target).GetFormatValues();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var.Handle;

            }
            else
            {
                return efl_ui_format_values_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_values_get_delegate efl_ui_format_values_get_static_delegate;

        
        private delegate void efl_ui_format_values_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr values);

        
        public delegate void efl_ui_format_values_set_api_delegate(System.IntPtr obj,  System.IntPtr values);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_values_set_api_delegate> efl_ui_format_values_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_values_set_api_delegate>(Module, "efl_ui_format_values_set");

        private static void format_values_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr values)
        {
            Eina.Log.Debug("function efl_ui_format_values_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_values = new Eina.Accessor<Efl.Ui.FormatValue>(values, false);
                            
                try
                {
                    ((IFormat)ws.Target).SetFormatValues(_in_values);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_format_values_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), values);
            }
        }

        private static efl_ui_format_values_set_delegate efl_ui_format_values_set_static_delegate;

        
        private delegate void efl_ui_format_string_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String kw_string,  out Efl.Ui.FormatStringType type);

        
        public delegate void efl_ui_format_string_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String kw_string,  out Efl.Ui.FormatStringType type);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate> efl_ui_format_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate>(Module, "efl_ui_format_string_get");

        private static void format_string_get(System.IntPtr obj, System.IntPtr pd, out System.String kw_string, out Efl.Ui.FormatStringType type)
        {
            Eina.Log.Debug("function efl_ui_format_string_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        System.String _out_kw_string = default(System.String);
        type = default(Efl.Ui.FormatStringType);                            
                try
                {
                    ((IFormat)ws.Target).GetFormatString(out _out_kw_string, out type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        kw_string = _out_kw_string;
                                
            }
            else
            {
                efl_ui_format_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out kw_string, out type);
            }
        }

        private static efl_ui_format_string_get_delegate efl_ui_format_string_get_static_delegate;

        
        private delegate void efl_ui_format_string_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  Efl.Ui.FormatStringType type);

        
        public delegate void efl_ui_format_string_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  Efl.Ui.FormatStringType type);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate> efl_ui_format_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate>(Module, "efl_ui_format_string_set");

        private static void format_string_set(System.IntPtr obj, System.IntPtr pd, System.String kw_string, Efl.Ui.FormatStringType type)
        {
            Eina.Log.Debug("function efl_ui_format_string_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IFormat)ws.Target).SetFormatString(kw_string, type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_format_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_string, type);
            }
        }

        private static efl_ui_format_string_set_delegate efl_ui_format_string_set_static_delegate;

        
        private delegate void efl_ui_format_formatted_value_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))] Eina.Strbuf str,  Eina.ValueNative value);

        
        public delegate void efl_ui_format_formatted_value_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))] Eina.Strbuf str,  Eina.ValueNative value);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_formatted_value_get_api_delegate> efl_ui_format_formatted_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_formatted_value_get_api_delegate>(Module, "efl_ui_format_formatted_value_get");

        private static void formatted_value_get(System.IntPtr obj, System.IntPtr pd, Eina.Strbuf str, Eina.ValueNative value)
        {
            Eina.Log.Debug("function efl_ui_format_formatted_value_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IFormat)ws.Target).GetFormattedValue(str, value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_format_formatted_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), str, value);
            }
        }

        private static efl_ui_format_formatted_value_get_delegate efl_ui_format_formatted_value_get_static_delegate;

        
        private delegate int efl_ui_format_decimal_places_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_format_decimal_places_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_decimal_places_get_api_delegate> efl_ui_format_decimal_places_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_decimal_places_get_api_delegate>(Module, "efl_ui_format_decimal_places_get");

        private static int decimal_places_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_decimal_places_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IFormat)ws.Target).GetDecimalPlaces();
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
                return efl_ui_format_decimal_places_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_decimal_places_get_delegate efl_ui_format_decimal_places_get_static_delegate;

        
        private delegate void efl_ui_format_apply_formatted_value_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_format_apply_formatted_value_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_apply_formatted_value_api_delegate> efl_ui_format_apply_formatted_value_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_apply_formatted_value_api_delegate>(Module, "efl_ui_format_apply_formatted_value");

        private static void apply_formatted_value(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_apply_formatted_value was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((IFormat)ws.Target).ApplyFormattedValue();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_format_apply_formatted_value_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_apply_formatted_value_delegate efl_ui_format_apply_formatted_value_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiIFormatConcrete_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Ui.FormatFunc> FormatFunc<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IFormat, T>magic = null) where T : Efl.Ui.IFormat {
        return new Efl.BindableProperty<Efl.Ui.FormatFunc>("format_func", fac);
    }

    public static Efl.BindableProperty<Eina.Accessor<Efl.Ui.FormatValue>> FormatValues<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IFormat, T>magic = null) where T : Efl.Ui.IFormat {
        return new Efl.BindableProperty<Eina.Accessor<Efl.Ui.FormatValue>>("format_values", fac);
    }

    
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>Type of formatting string.</summary>
[Efl.Eo.BindingEntity]
public enum FormatStringType
{
/// <summary>This is the simplest formatting mechanism, working pretty much like <c>printf</c>. Accepted formats are <c>s</c>, <c>f</c>, <c>F</c>, <c>d</c>, <c>u</c>, <c>i</c>, <c>o</c>, <c>x</c> and <c>X</c>. For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.</summary>
Simple = 0,
/// <summary>A strftime-style string used to format date and time values. For example, &quot;%A&quot; for the full name of the day or &quot;%y&quot; for the year as a decimal number without a century (range 00 to 99). Note that these are not the <c>printf</c> formats. See the man page for the <c>strftime</c> function for the complete list.</summary>
Time = 1,
}

}

}

namespace Efl {

namespace Ui {

/// <summary>A value which should always be displayed as a specific text string. See <see cref="Efl.Ui.IFormat.FormatValues"/>.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct FormatValue
{
    /// <summary>Input value.</summary>
    public int Value;
    /// <summary>Text string to replace it.</summary>
    public System.String Text;
    /// <summary>Constructor for FormatValue.</summary>
    /// <param name="Value">Input value.</param>;
    /// <param name="Text">Text string to replace it.</param>;
    public FormatValue(
        int Value = default(int),
        System.String Text = default(System.String)    )
    {
        this.Value = Value;
        this.Text = Text;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator FormatValue(IntPtr ptr)
    {
        var tmp = (FormatValue.NativeStruct)Marshal.PtrToStructure(ptr, typeof(FormatValue.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct FormatValue.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int Value;
        /// <summary>Internal wrapper for field Text</summary>
        public System.IntPtr Text;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator FormatValue.NativeStruct(FormatValue _external_struct)
        {
            var _internal_struct = new FormatValue.NativeStruct();
            _internal_struct.Value = _external_struct.Value;
            _internal_struct.Text = Eina.MemoryNative.StrDup(_external_struct.Text);
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator FormatValue(FormatValue.NativeStruct _internal_struct)
        {
            var _external_struct = new FormatValue();
            _external_struct.Value = _internal_struct.Value;
            _external_struct.Text = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Text);
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

