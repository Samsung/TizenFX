using System;

namespace ElmSharp
{
    public class GenGridItem : GenItem
    {
        internal GenGridItem(object data, GenItemClass itemClass) : base(data, itemClass)
        {
        }

        public override bool IsSelected
        {
            get
            {
                return Interop.Elementary.elm_gengrid_item_selected_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_item_selected_set(Handle, value);
            }
        }

        public override void Update()
        {
            Interop.Elementary.elm_gengrid_item_update(Handle);
        }
    }
}
