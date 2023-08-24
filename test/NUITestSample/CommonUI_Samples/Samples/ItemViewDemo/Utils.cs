using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuiCommonUiSamples
{
    public enum AllImagesLayouts
    {
        SPIRAL_LAYOUT = 0,
        DEPTH_LAYOUT,
        GRID_LAYOUT,

        NUMBER_OF_LAYOUTS
    };

    public enum Mode
    {
        MODE_NORMAL,
        MODE_REMOVE,
        MODE_REMOVE_MANY,
        MODE_INSERT,
        MODE_INSERT_MANY,
        MODE_REPLACE,
        MODE_REPLACE_MANY,
        MODE_LAST
    };
}
