using System;
using System.ComponentModel;

namespace Tizen.NUI.Internals
{
	[Obsolete]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal interface IDataTemplate
	{
		Func<object> LoadTemplate { get; set; }
	}
}