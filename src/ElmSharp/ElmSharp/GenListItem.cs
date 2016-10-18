using System;

namespace ElmSharp
{
    public enum GenListSelectionMode
    {
        Default,
        Always,
        None,
        DisplayOnly
    }

    public class GenListItem : GenItem
    {
        internal GenListItem(object data, GenItemClass itemClass)
            : base(data, itemClass)
        {
        }

        public override bool IsSelected
        {
            get
            {
                return Interop.Elementary.elm_genlist_item_selected_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_item_selected_set(Handle, value);
            }
        }

        public override void Update()
        {
            Interop.Elementary.elm_genlist_item_update(Handle);
        }

        public GenListSelectionMode SelectionMode
        {
            get
            {
                return (GenListSelectionMode)Interop.Elementary.elm_genlist_item_select_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_item_select_mode_set(Handle, (Interop.Elementary.Elm_Object_Select_Mode)value);
            }
        }

        public void UpdateItemClass(GenItemClass itemClass, object data)
        {
            Data = data;
            ItemClass = itemClass;
            Interop.Elementary.elm_genlist_item_item_class_update((IntPtr)Handle, itemClass.UnmanagedPtr);
        }
    }
}
