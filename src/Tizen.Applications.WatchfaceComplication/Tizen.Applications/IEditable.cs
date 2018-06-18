using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tizen.Applications.WatchfaceComplication
{
	public interface IEditable
	{        
        int EditableId { get; set; }
        string Name { get;}        
        EditableGeometry Geometry { get; set; }        
        int CurrentDataIndex { get; }        
        Bundle GetNthData(int index);        
    }
}