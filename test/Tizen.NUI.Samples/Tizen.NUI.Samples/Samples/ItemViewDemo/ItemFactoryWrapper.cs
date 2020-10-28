using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public delegate uint GetNumberOfItems();
    public delegate View NewItem(uint itemId);

    public class ItemFactoryWrapper : ItemFactory
    {
        public GetNumberOfItems GetNumberDelegate { get; set; }

        public NewItem NewItemDelegate { get; set; }

        public ItemFactoryWrapper()
        {
            GetNumberDelegate = null;
            NewItemDelegate = null;
        }
        public override uint GetNumberOfItems()
        {
            if (GetNumberDelegate != null)
            {
                return GetNumberDelegate();
            }
            else
            {
                return 0;
            }
        }

        public override View NewItem(uint itemId)
        {
            if (NewItemDelegate != null)
            {
                return NewItemDelegate(itemId);
            }
            else
            {
                return null;
            }
        }
    }
}
