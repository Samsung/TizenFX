using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            /// <summary>
            /// The MoreOptioniItem is an item used by more option widget.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class MoreOptionItem
            {
                const string MainTextPartName = "selector,main_text";
                const string SubTextPartName = "selector,sub_text";
                const string IconPartName = "item,icon";

                string _mainText;
                string _subText;
                Image _icon;
                Image _preIcon;

                public IntPtr _handle;
                public IntPtr NativeHandle
                {
                    set
                    {
                        if (_handle == value) return;
                        _handle = value;

                        if (_handle == null) return;

                        if (_mainText != null)
                            Interop.Eext.eext_more_option_item_part_text_set(NativeHandle, MainTextPartName, _mainText);
                        if (_subText != null)
                            Interop.Eext.eext_more_option_item_part_text_set(NativeHandle, SubTextPartName, _subText);
                        if (_icon != null)
                            Interop.Eext.eext_more_option_item_part_content_set(NativeHandle, IconPartName, _icon.NativeHandle);
                    }
                    get
                    {
                        return _handle;
                    }
                }

                /// <summary>
                /// Sets or gets the main text.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public string MainText
                {
                    set
                    {
                        if (_mainText == value) return;
                        _mainText = value;
                        if (NativeHandle != IntPtr.Zero)
                        {
                            Interop.Eext.eext_more_option_item_part_text_set(NativeHandle, MainTextPartName, _mainText);
                        }
                    }

                    get
                    {
                        return _mainText;
                    }
                }

                /// <summary>
                /// Sets or gets the sub text.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public string SubText
                {
                    set
                    {
                        if (_subText == value) return;
                        _subText = value;
                        if (NativeHandle != IntPtr.Zero)
                        {
                            Interop.Eext.eext_more_option_item_part_text_set(NativeHandle, SubTextPartName, _subText);
                        }
                    }

                    get
                    {
                        return _subText;
                    }
                }

                /// <summary>
                /// Sets or gets the icon image.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public Image Icon
                {
                    set
                    {
                        if (_icon != null) _preIcon = _icon;
                        if (_icon == value) return;
                        _icon = value;

                        if (NativeHandle != IntPtr.Zero)
                        {
                            if (_preIcon != null)
                                _preIcon.SetVisible(false);
                            Interop.Eext.eext_more_option_item_part_content_set(NativeHandle, IconPartName, _icon.NativeHandle);
                        }
                    }
                    get
                    {
                        return _icon;
                    }
                }
            }
        }
    }
}
