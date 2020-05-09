using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.NUI.Samples
{
    public class ContactData
    {
        public const int itemSize = 15;
        public static readonly string floder = CommonResource.GetDaliResourcePath() + "ContactCard/";
        public class Item
        {
            public string name;
            public string address;
            public string imagePath;

            public Item(string _name, string _address, string _imagePath)
            {
                name = _name;
                address = _address;
                imagePath = _imagePath;
            }
        }

        public static Item[] itmes = new Item[itemSize]
        {
            new Item("Shelia Ramos",     "19 Wormley Ct\nWinters Way\nWaltham Abbey\nEN9 3HW",       floder +"gallery-small-19.jpg"),
            new Item("Walter Jensen",    "32 Upper Fant Rd\nMaidstone\nME16 8DN",                    floder + "gallery-small-2.jpg"),
            new Item("Randal Parks",     "8 Rymill St\nLondon\nE16 2JF",                             floder + "gallery-small-3.jpg"),
            new Item("Tasha Cooper",     "2 Kyles View\nColintraive\nPA22 3AS",                      floder + "gallery-small-4.jpg"),
            new Item("Domingo Lynch",    "Red Lion Farm\nWatlington\nOX49 5LG",                      floder + "gallery-small-5.jpg"),
            new Item("Dan Haynes",       "239 Whitefield Dr\nLiverpool\nL32 0RD",                    floder + "gallery-small-6.jpg"),
            new Item("Leslie Wong",      "1 Tullyvar Rd\nAughnacloy\nBT69 6BQ",                      floder + "gallery-small-7.jpg"),
            new Item("Mable Hodges",     "5 Mortimer Rd\nGrazeley\nReading\nRG7 1LA",                floder + "gallery-small-8.jpg"),
            new Item("Kristi Riley",     "10 Jura Dr\nOld Kilpatrick\nGlasgow\nG60 5EH",             floder + "gallery-small-17.jpg"),
            new Item("Terry Clark",      "142 Raeberry St\nGlasgow\nG20 6EA",                        floder + "gallery-small-18.jpg"),
            new Item("Horace Bailey",    "11 Assembly St\nNormanton\nWF6 2DB",                       floder + "gallery-small-11.jpg"),
            new Item("Suzanne Delgado",  "6 Grange Rd\nDownpatrick\nBT30 7DB",                       floder + "gallery-small-12.jpg"),
            new Item("Jamie Bennett",    "117 Potter St\nNorthwood\nHA6 1QF",                        floder + "gallery-small-13.jpg"),
            new Item("Emmett Yates",     "18 Renfrew Way\nBletchley\nMilton Keynes\nMK3 7NY",        floder + "gallery-small-14.jpg"),
            new Item("Glen Vaughn",      "5 Hasman Terrace\nCove Bay\nAberdeen\nAB12 3GD",           floder + "gallery-small-15.jpg")
        };

    }


}
