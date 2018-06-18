using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    public enum ComplicationType
    {
        NoData = 0x01,
        ShortText = 0x02,
        LongText = 0x04,
        RangedValue = 0x08,
        Time = 0x10,
        Icon = 0x20,
        Image = 0x40
    }
}