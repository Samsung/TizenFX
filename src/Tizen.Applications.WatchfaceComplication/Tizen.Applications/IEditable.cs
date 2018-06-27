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
        Geometry Geometry { get; set; }
        int CurrentDataIndex { get; set; }
        Bundle GetCurrentData();
        void OnUpdate(int selectedIdx, State state);
    }
}