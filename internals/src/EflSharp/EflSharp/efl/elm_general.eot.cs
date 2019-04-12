#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Elm { 
/// <summary>Policy identifiers.</summary>
public enum Policy
{
/// <summary>under which circumstances the application should quit automatically. See also <see cref="Elm.Policy.Quit"/>.</summary>
Quit = 0,
/// <summary>defines elm_exit() behaviour. See also <see cref="Elm.Policy.Exit"/>.
/// (Since EFL 1.8)</summary>
Exit = 1,
/// <summary>defines how throttling should work. See also <see cref="Elm.Policy.Throttle"/>
/// (Since EFL 1.8)</summary>
Throttle = 2,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
Last = 3,
}
} 
namespace Elm { 
/// <summary>Possible values for the <see cref="Elm.Policy.Quit"/> policy</summary>
public enum PolicyQuit
{
/// <summary>never quit the application automatically</summary>
None = 0,
/// <summary>quit when the application&apos;s last window is closed</summary>
LastWindowClosed = 1,
/// <summary>quit when the application&apos;s last window is hidden
/// (Since EFL 1.14)</summary>
LastWindowHidden = 2,
}
} 
namespace Elm { 
/// <summary>Possible values for the <see cref="Elm.Policy.Exit"/> policy.
/// (Since EFL 1.8)</summary>
public enum PolicyExit
{
/// <summary>just quit the main loop on elm_exit()</summary>
None = 0,
/// <summary>delete all the windows after quitting the main loop</summary>
WindowsDel = 1,
}
} 
namespace Elm { 
/// <summary>Possible values for the <see cref="Elm.Policy.Throttle"/> policy.
/// (Since EFL 1.8)</summary>
public enum PolicyThrottle
{
/// <summary>do whatever elementary config is configured to do</summary>
Config = 0,
/// <summary>always throttle when all windows are no longer visible</summary>
HiddenAlways = 1,
/// <summary>never throttle when windows are all hidden, regardless of config settings</summary>
Never = 2,
}
} 
namespace Elm { namespace Object { 
/// <summary>Possible values for the #ELM_OBJECT_SELECT_MODE policy.
/// (Since EFL 1.7)</summary>
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
} } 
namespace Elm { namespace Object { 
/// <summary>Possible values for the #ELM_OBJECT_MULTI_SELECT_MODE policy.
/// (Since EFL 1.8)</summary>
public enum MultiSelectMode
{
/// <summary>default multiple select mode</summary>
Default = 0,
/// <summary>disallow mutiple selection when clicked without control key pressed</summary>
WithControl = 1,
/// <summary>canary value: any value greater or equal to ELM_OBJECT_MULTI_SELECT_MODE_MAX is forbidden.</summary>
Max = 2,
}
} } 
namespace Elm { namespace Wrap { 
/// <summary>Line wrapping types. Type of word or character wrapping to use.
/// See also @ref elm_entry_line_wrap_set, @ref elm_popup_content_text_wrap_type_set, @ref elm_label_line_wrap_set.</summary>
public enum Type
{
/// <summary>No wrap - value is zero.</summary>
None = 0,
/// <summary>Char wrap - wrap between characters.</summary>
Char = 1,
/// <summary>Word wrap - wrap in allowed wrapping points (as defined in the unicode standard).</summary>
Word = 2,
/// <summary>Mixed wrap - Word wrap, and if that fails, char wrap.</summary>
Mixed = 3,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
Last = 4,
}
} } 
namespace Elm { namespace Icon { 
/// <summary>Elementary icon types</summary>
public enum Type
{
/// <summary>Icon has no type set</summary>
None = 0,
/// <summary>Icon is of type file</summary>
File = 1,
/// <summary>Icon is of type standard</summary>
Standard = 2,
}
} } 
namespace Elm { 
/// <summary>Text Format types.</summary>
public enum TextFormat
{
/// <summary>Plain UTF8 type</summary>
PlainUtf8 = 0,
/// <summary>Markup UTF8 type</summary>
MarkupUtf8 = 1,
}
} 
namespace Elm { namespace Input { namespace Panel { 
/// <summary>Input panel (virtual keyboard) layout types. Type of input panel (virtual keyboard) to use - this is a hint and may not provide exactly what is desired.</summary>
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
} } } 
namespace Elm { namespace Input { namespace Panel { 
/// <summary>Input panel (virtual keyboard) language modes.</summary>
public enum Lang
{
/// <summary>Automatic</summary>
Automatic = 0,
/// <summary>Alphabet</summary>
Alphabet = 1,
}
} } } 
namespace Elm { namespace Autocapital { 
/// <summary>Autocapitalization Types. Choose method of auto-capitalization.</summary>
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
} } 
namespace Elm { namespace Input { namespace Panel { namespace ReturnKey { 
/// <summary>&quot;Return&quot; Key types on the input panel (virtual keyboard).</summary>
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
} } } } 
namespace Elm { namespace Input { 
/// <summary>Enumeration that defines the types of Input Hints.
/// (Since EFL 1.12)</summary>
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
} } 
namespace Elm { 
/// <summary>Enum of entry&apos;s copy &amp; paste policy.</summary>
public enum CnpMode
{
/// <summary>copy &amp; paste text with markup tag</summary>
Markup = 0,
/// <summary>copy &amp; paste text without item(image) tag</summary>
NoImage = 1,
/// <summary>copy &amp; paste text without markup tag</summary>
Plaintext = 2,
}
} 
namespace Elm { namespace Genlist { namespace Item { 
/// <summary>Defines if the item is of any special type (has subitems or it&apos;s the index of a group), or is just a simple item.</summary>
public enum Type
{
/// <summary>Simple item.</summary>
None = 0,
/// <summary>This may be expanded and have child items.</summary>
Tree = 1,
/// <summary>An index item of a group of items. this item can have child items.</summary>
Group = 2,
/// <summary>Sentinel value to indicate last enum field during iteration</summary>
Max = 4,
}
} } } 
namespace Elm { namespace Genlist { namespace Item { 
/// <summary>Defines the type of the item part Used while updating item&apos;s parts It can be used at updating multi fields.</summary>
public enum FieldType
{
/// <summary>Type all</summary>
All = 0,
/// <summary>Type text</summary>
Text = 1,
/// <summary>Type content</summary>
Content = 2,
/// <summary>Type state</summary>
State = 4,
}
} } } 
namespace Elm { namespace Genlist { namespace Item { 
/// <summary>Defines where to position the item in the genlist.</summary>
public enum ScrolltoType
{
/// <summary>Nothing will happen, Don&apos;t use this value.</summary>
None = 0,
/// <summary>To the nearest viewport.</summary>
In = 1,
/// <summary>To the top of viewport.</summary>
Top = 2,
/// <summary>To the middle of viewport.</summary>
Middle = 4,
/// <summary>To the bottom of viewport.</summary>
Bottom = 8,
}
} } } 
namespace Elm { namespace Gengrid { namespace Item { 
/// <summary>Defines where to position the item in the genlist.</summary>
public enum ScrolltoType
{
/// <summary>No scrollto.</summary>
None = 0,
/// <summary>To the nearest viewport.</summary>
In = 1,
/// <summary>To the top of viewport.</summary>
Top = 2,
/// <summary>To the middle of viewport.</summary>
Middle = 4,
/// <summary>To the bottom of viewport.</summary>
Bottom = 8,
}
} } } 
namespace Elm { namespace Gengrid { namespace Item { 
/// <summary>Defines the type of the item part Used while updating item&apos;s parts. It can be used at updating multi fields.</summary>
public enum FieldType
{
/// <summary>Type all</summary>
All = 0,
/// <summary>Type text</summary>
Text = 1,
/// <summary>Type content</summary>
Content = 2,
/// <summary>Type state</summary>
State = 4,
}
} } } 
namespace Elm { namespace List { 
/// <summary>Set list&apos;s resizing behavior, transverse axis scrolling and items cropping. See each mode&apos;s description for more details.
/// Note: Default value is <see cref="Elm.List.Mode.Scroll"/>.
/// 
/// Values here don&apos;t work as bitmasks -- only one can be chosen at a time.</summary>
public enum Mode
{
/// <summary>The list won&apos;t set any of its size hints to inform how a possible container should resize it. Then, if it&apos;s not created as a &quot;resize object&quot;, it might end with zeroed dimensions. The list will respect the container&apos;s geometry and, if any of its items won&apos;t fit into its transverse axis, one won&apos;t be able to scroll it in that direction.</summary>
Compress = 0,
/// <summary>Default value. This is the same as #ELM_LIST_COMPRESS, with the exception that if any of its items won&apos;t fit into its transverse axis, one will be able to scroll it in that direction.</summary>
Scroll = 1,
/// <summary>Sets a minimum size hint on the list object, so that containers may respect it (and resize itself to fit the child properly). More specifically, a minimum size hint will be set for its transverse axis, so that the largest item in that direction fits well. This is naturally bound by the list object&apos;s maximum size hints, set externally.</summary>
Limit = 2,
/// <summary>Besides setting a minimum size on the transverse axis, just like on <see cref="Elm.List.Mode.Limit"/>, the list will set a minimum size on the longitudinal axis, trying to reserve space to all its children to be visible at a time. . This is naturally bound by the list object&apos;s maximum size hints, set externally.</summary>
Expand = 3,
/// <summary>Indicates error if returned by elm_list_mode_get().</summary>
Last = 4,
}
} } 
namespace Elm { namespace Event { 
/// <summary>Data on the event when an Elementary policy has changed</summary>
[StructLayout(LayoutKind.Sequential)]
public struct PolicyChanged
{
    /// <summary>the policy identifier</summary>
    public uint Policy;
    /// <summary>value the policy had before the change</summary>
    public int New_value;
    /// <summary>new value the policy got</summary>
    public int Old_value;
    ///<summary>Constructor for PolicyChanged.</summary>
    public PolicyChanged(
        uint Policy=default(uint),
        int New_value=default(int),
        int Old_value=default(int)    )
    {
        this.Policy = Policy;
        this.New_value = New_value;
        this.Old_value = Old_value;
    }

    public static implicit operator PolicyChanged(IntPtr ptr)
    {
        var tmp = (PolicyChanged.NativeStruct)Marshal.PtrToStructure(ptr, typeof(PolicyChanged.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct PolicyChanged.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public uint Policy;
        
        public int New_value;
        
        public int Old_value;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator PolicyChanged.NativeStruct(PolicyChanged _external_struct)
        {
            var _internal_struct = new PolicyChanged.NativeStruct();
            _internal_struct.Policy = _external_struct.Policy;
            _internal_struct.New_value = _external_struct.New_value;
            _internal_struct.Old_value = _external_struct.Old_value;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator PolicyChanged(PolicyChanged.NativeStruct _internal_struct)
        {
            var _external_struct = new PolicyChanged();
            _external_struct.Policy = _internal_struct.Policy;
            _external_struct.New_value = _internal_struct.New_value;
            _external_struct.Old_value = _internal_struct.Old_value;
            return _external_struct;
        }

    }

}

} } 

/// <summary>Elementary gen item</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ElmGenItem
{
    ///<summary>Placeholder field</summary>
    public IntPtr field;
    public static implicit operator ElmGenItem(IntPtr ptr)
    {
        var tmp = (ElmGenItem.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ElmGenItem.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct ElmGenItem.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ElmGenItem.NativeStruct(ElmGenItem _external_struct)
        {
            var _internal_struct = new ElmGenItem.NativeStruct();
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ElmGenItem(ElmGenItem.NativeStruct _internal_struct)
        {
            var _external_struct = new ElmGenItem();
            return _external_struct;
        }

    }

}



/// <summary>Efl access action data</summary>
[StructLayout(LayoutKind.Sequential)]
public struct EflAccessActionData
{
    ///<summary>Placeholder field</summary>
    public IntPtr field;
    public static implicit operator EflAccessActionData(IntPtr ptr)
    {
        var tmp = (EflAccessActionData.NativeStruct)Marshal.PtrToStructure(ptr, typeof(EflAccessActionData.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct EflAccessActionData.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator EflAccessActionData.NativeStruct(EflAccessActionData _external_struct)
        {
            var _internal_struct = new EflAccessActionData.NativeStruct();
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator EflAccessActionData(EflAccessActionData.NativeStruct _internal_struct)
        {
            var _external_struct = new EflAccessActionData();
            return _external_struct;
        }

    }

}


namespace Elm { 
/// <summary>Data for the elm_validator_regexp_helper()</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ValidateContent
{
    ///<summary>Placeholder field</summary>
    public IntPtr field;
    public static implicit operator ValidateContent(IntPtr ptr)
    {
        var tmp = (ValidateContent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ValidateContent.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct ValidateContent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ValidateContent.NativeStruct(ValidateContent _external_struct)
        {
            var _internal_struct = new ValidateContent.NativeStruct();
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ValidateContent(ValidateContent.NativeStruct _internal_struct)
        {
            var _external_struct = new ValidateContent();
            return _external_struct;
        }

    }

}

} 
namespace Elm { 
/// <summary>The info sent in the callback for the &quot;anchor,clicked&quot; signals emitted by entries.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct EntryAnchorInfo
{
    ///<summary>Placeholder field</summary>
    public IntPtr field;
    public static implicit operator EntryAnchorInfo(IntPtr ptr)
    {
        var tmp = (EntryAnchorInfo.NativeStruct)Marshal.PtrToStructure(ptr, typeof(EntryAnchorInfo.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct EntryAnchorInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator EntryAnchorInfo.NativeStruct(EntryAnchorInfo _external_struct)
        {
            var _internal_struct = new EntryAnchorInfo.NativeStruct();
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator EntryAnchorInfo(EntryAnchorInfo.NativeStruct _internal_struct)
        {
            var _external_struct = new EntryAnchorInfo();
            return _external_struct;
        }

    }

}

} 
namespace Elm { 
/// <summary>The info sent in the callback for &quot;anchor,hover&quot; signals emitted by the Anchor_Hover widget</summary>
[StructLayout(LayoutKind.Sequential)]
public struct EntryAnchorHoverInfo
{
    ///<summary>Placeholder field</summary>
    public IntPtr field;
    public static implicit operator EntryAnchorHoverInfo(IntPtr ptr)
    {
        var tmp = (EntryAnchorHoverInfo.NativeStruct)Marshal.PtrToStructure(ptr, typeof(EntryAnchorHoverInfo.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct EntryAnchorHoverInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator EntryAnchorHoverInfo.NativeStruct(EntryAnchorHoverInfo _external_struct)
        {
            var _internal_struct = new EntryAnchorHoverInfo.NativeStruct();
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator EntryAnchorHoverInfo(EntryAnchorHoverInfo.NativeStruct _internal_struct)
        {
            var _external_struct = new EntryAnchorHoverInfo();
            return _external_struct;
        }

    }

}

} 
namespace Elm { 
/// <summary>This corresponds to Edje_Entry_Change_Info. Includes information about a change in the entry</summary>
[StructLayout(LayoutKind.Sequential)]
public struct EntryChangeInfo
{
    ///<summary>Placeholder field</summary>
    public IntPtr field;
    public static implicit operator EntryChangeInfo(IntPtr ptr)
    {
        var tmp = (EntryChangeInfo.NativeStruct)Marshal.PtrToStructure(ptr, typeof(EntryChangeInfo.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct EntryChangeInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator EntryChangeInfo.NativeStruct(EntryChangeInfo _external_struct)
        {
            var _internal_struct = new EntryChangeInfo.NativeStruct();
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator EntryChangeInfo(EntryChangeInfo.NativeStruct _internal_struct)
        {
            var _external_struct = new EntryChangeInfo();
            return _external_struct;
        }

    }

}

} 
