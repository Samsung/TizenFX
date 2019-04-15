using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Eext
    {
        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_more_option_add(IntPtr parent);

        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_more_option_item_append(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_more_option_item_prepend(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_more_option_item_insert_after(IntPtr obj, IntPtr after);

        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_more_option_item_insert_before(IntPtr obj, IntPtr before);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_more_option_items_clear(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_more_option_items_get(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_more_option_direction_set(IntPtr obj, int direction);

        [DllImport(efl.Libs.Eext)]
        internal static extern int eext_more_option_direction_get(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern bool eext_more_option_opened_get(IntPtr obj);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_more_option_opened_set(IntPtr obj, bool opened);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_more_option_item_del(IntPtr item);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_more_option_item_domain_translatable_part_text_set(IntPtr item, string part_name, string domain, string text);

        [DllImport(efl.Libs.Eext)]
        internal static extern IntPtr eext_more_option_item_part_content_get(IntPtr item, string part_name);

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_more_option_item_part_content_set(IntPtr item, string part_name, IntPtr content);

        [DllImport(efl.Libs.Eext, EntryPoint = "eext_more_option_item_part_text_get")]
        static extern IntPtr _eext_more_option_item_part_text_get(IntPtr item, string part_name);

        internal static string eext_more_option_item_part_text_get(IntPtr item, string part_name)
        {
            var ptr = _eext_more_option_item_part_text_get(item, part_name);
            return Marshal.PtrToStringAnsi(ptr);
        }

        [DllImport(efl.Libs.Eext)]
        internal static extern void eext_more_option_item_part_text_set(IntPtr item, string part_name, string text);
    }
}