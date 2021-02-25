using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ItemFactory
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ItemFactory")]
            public static extern void DeleteItemFactory(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemFactory_GetNumberOfItems")]
            public static extern uint GetNumberOfItems(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemFactory_NewItem")]
            public static extern global::System.IntPtr NewItem(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemFactory_ItemReleased")]
            public static extern void ItemReleased(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemFactory_ItemReleasedSwigExplicitItemFactory")]
            public static extern void ItemReleasedSwigExplicitItemFactory(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ItemFactory")]
            public static extern global::System.IntPtr NewItemFactory();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ItemFactory_director_connect")]
            public static extern void DirectorConnect(global::System.Runtime.InteropServices.HandleRef jarg1, Tizen.NUI.ItemFactory.SwigDelegateItemFactory_0 delegate0,
                Tizen.NUI.ItemFactory.SwigDelegateItemFactory_1 delegate1, Tizen.NUI.ItemFactory.SwigDelegateItemFactory_2 delegate2);
        }
    }
}
