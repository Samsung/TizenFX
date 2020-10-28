#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Elm {

namespace Object {

/// <summary>Possible values for the #ELM_OBJECT_SELECT_MODE policy.
/// (Since EFL 1.7)</summary>
[Efl.Eo.BindingEntity]
public enum SelectMode
{
/// <summary>default select mode. Once an item is selected, it would stay highlighted and not going to call selected callback again even it was clicked. Items can get focus.</summary>
Default = 0,
/// <summary>always select mode. Item selected callbacks will be called every time for click events, even after the item was already selected. Items can get focus.</summary>
Always = 1,
/// <summary>no select mode. Items will never be highlighted and selected but the size will be adjusted by the finger size configuration. Items can&apos;t get focus.</summary>
None = 2,
/// <summary>no select mode with no finger size rule. Items will never be highlighted and selected and ignore the finger size. So the item size can be reduced below than the finger size configuration. Items can&apos;t get focus.</summary>
DisplayOnly = 3,
/// <summary>canary value: any value greater or equal to ELM_OBJECT_SELECT_MODE_MAX is forbidden.</summary>
Max = 4,
}

}

}

namespace Elm {

namespace Icon {

/// <summary>Elementary icon types</summary>
[Efl.Eo.BindingEntity]
public enum Type
{
/// <summary>Icon has no type set</summary>
None = 0,
/// <summary>Icon is of type file</summary>
File = 1,
/// <summary>Icon is of type standard</summary>
Standard = 2,
}

}

}

namespace Elm {

namespace Input {

namespace Panel {

/// <summary>Input panel (virtual keyboard) layout types. Type of input panel (virtual keyboard) to use - this is a hint and may not provide exactly what is desired.</summary>
[Efl.Eo.BindingEntity]
public enum Layout
{
/// <summary>Default layout.</summary>
Normal = 0,
/// <summary>Number layout.</summary>
Number = 1,
/// <summary>Email layout.</summary>
Email = 2,
/// <summary>URL layout.</summary>
Url = 3,
/// <summary>Phone Number layout.</summary>
Phonenumber = 4,
/// <summary>IP layout.</summary>
Ip = 5,
/// <summary>Month layout.</summary>
Month = 6,
/// <summary>Number Only layout.</summary>
Numberonly = 7,
/// <summary>Never use this.</summary>
Invalid = 8,
/// <summary>Hexadecimal layout.</summary>
Hex = 9,
/// <summary>Command-line terminal layout including esc, alt, ctrl key, so on (no auto-correct, no auto-capitalization).</summary>
Terminal = 10,
/// <summary>Like normal, but no auto-correct, no auto-capitalization etc.</summary>
Password = 11,
/// <summary>Date and time layout
/// (Since EFL 1.8)</summary>
Datetime = 12,
/// <summary>Emoticon layout
/// (Since EFL 1.10)</summary>
Emoticon = 13,
/// <summary>Voice layout, but if the IME does not support voice layout, then normal layout will be shown.
/// (Since EFL 1.19)</summary>
Voice = 14,
}

}

}

}

namespace Elm {

namespace Input {

namespace Panel {

/// <summary>Input panel (virtual keyboard) language modes.</summary>
[Efl.Eo.BindingEntity]
public enum Lang
{
/// <summary>Automatic</summary>
Automatic = 0,
/// <summary>Alphabet</summary>
Alphabet = 1,
}

}

}

}

namespace Elm {

namespace Autocapital {

/// <summary>Autocapitalization Types. Choose method of auto-capitalization.</summary>
[Efl.Eo.BindingEntity]
public enum Type
{
/// <summary>No auto-capitalization when typing.</summary>
None = 0,
/// <summary>Autocapitalize each word typed.</summary>
Word = 1,
/// <summary>Autocapitalize the start of each sentence.</summary>
Sentence = 2,
/// <summary>Autocapitalize all letters.</summary>
Allcharacter = 3,
}

}

}

namespace Elm {

namespace Input {

namespace Panel {

namespace ReturnKey {

/// <summary>&quot;Return&quot; Key types on the input panel (virtual keyboard).</summary>
[Efl.Eo.BindingEntity]
public enum Type
{
/// <summary>Default.</summary>
Default = 0,
/// <summary>Done.</summary>
Done = 1,
/// <summary>Go.</summary>
Go = 2,
/// <summary>Join.</summary>
Join = 3,
/// <summary>Login.</summary>
Login = 4,
/// <summary>Next.</summary>
Next = 5,
/// <summary>Search string or magnifier icon.</summary>
Search = 6,
/// <summary>Send.</summary>
Send = 7,
/// <summary>Sign-in
/// (Since EFL 1.8)</summary>
Signin = 8,
}

}

}

}

}

namespace Elm {

namespace Input {

/// <summary>Enumeration that defines the types of Input Hints.
/// (Since EFL 1.12)</summary>
[Efl.Eo.BindingEntity]
public enum Hints
{
/// <summary>No active hints
/// (Since EFL 1.12)</summary>
None = 0,
/// <summary>Suggest word auto completion
/// (Since EFL 1.12)</summary>
AutoComplete = 1,
/// <summary>Typed text should not be stored.
/// (Since EFL 1.12)</summary>
SensitiveData = 2,
/// <summary>Autofill hint for a credit card expiration date
/// (Since EFL 1.21)</summary>
AutofillCreditCardExpirationDate = 256,
/// <summary>Autofill hint for a credit card expiration day
/// (Since EFL 1.21)</summary>
AutofillCreditCardExpirationDay = 512,
/// <summary>Autofill hint for a credit card expiration month
/// (Since EFL 1.21)</summary>
AutofillCreditCardExpirationMonth = 768,
/// <summary>Autofill hint for a credit card expiration year
/// (Since EFL 1.21)</summary>
AutofillCreditCardExpirationYear = 1024,
/// <summary>Autofill hint for a credit card number
/// (Since EFL 1.21)</summary>
AutofillCreditCardNumber = 1280,
/// <summary>Autofill hint for an email address
/// (Since EFL 1.21)</summary>
AutofillEmailAddress = 1536,
/// <summary>Autofill hint for a user&apos;s real name
/// (Since EFL 1.21)</summary>
AutofillName = 1792,
/// <summary>Autofill hint for a phone number
/// (Since EFL 1.21)</summary>
AutofillPhone = 2048,
/// <summary>Autofill hint for a postal address
/// (Since EFL 1.21)</summary>
AutofillPostalAddress = 2304,
/// <summary>Autofill hint for a postal code
/// (Since EFL 1.21)</summary>
AutofillPostalCode = 2560,
/// <summary>Autofill hint for a user&apos;s ID
/// (Since EFL 1.21)</summary>
AutofillId = 2816,
}

}

}

namespace Elm {

/// <summary>Data for the elm_validator_regexp_helper()</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ValidateContent
{
    /// <summary>Placeholder field</summary>
    public IntPtr field;
    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ValidateContent(IntPtr ptr)
    {
        var tmp = (ValidateContent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ValidateContent.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ValidateContent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ValidateContent.NativeStruct(ValidateContent _external_struct)
        {
            var _internal_struct = new ValidateContent.NativeStruct();
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ValidateContent(ValidateContent.NativeStruct _internal_struct)
        {
            var _external_struct = new ValidateContent();
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

namespace Elm {

/// <summary>The info sent in the callback for the &quot;anchor,clicked&quot; signals emitted by entries.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct EntryAnchorInfo
{
    /// <summary>Placeholder field</summary>
    public IntPtr field;
    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator EntryAnchorInfo(IntPtr ptr)
    {
        var tmp = (EntryAnchorInfo.NativeStruct)Marshal.PtrToStructure(ptr, typeof(EntryAnchorInfo.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct EntryAnchorInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator EntryAnchorInfo.NativeStruct(EntryAnchorInfo _external_struct)
        {
            var _internal_struct = new EntryAnchorInfo.NativeStruct();
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator EntryAnchorInfo(EntryAnchorInfo.NativeStruct _internal_struct)
        {
            var _external_struct = new EntryAnchorInfo();
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

namespace Elm {

/// <summary>The info sent in the callback for &quot;anchor,hover&quot; signals emitted by the Anchor_Hover widget</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct EntryAnchorHoverInfo
{
    /// <summary>Placeholder field</summary>
    public IntPtr field;
    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator EntryAnchorHoverInfo(IntPtr ptr)
    {
        var tmp = (EntryAnchorHoverInfo.NativeStruct)Marshal.PtrToStructure(ptr, typeof(EntryAnchorHoverInfo.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct EntryAnchorHoverInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator EntryAnchorHoverInfo.NativeStruct(EntryAnchorHoverInfo _external_struct)
        {
            var _internal_struct = new EntryAnchorHoverInfo.NativeStruct();
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator EntryAnchorHoverInfo(EntryAnchorHoverInfo.NativeStruct _internal_struct)
        {
            var _external_struct = new EntryAnchorHoverInfo();
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

