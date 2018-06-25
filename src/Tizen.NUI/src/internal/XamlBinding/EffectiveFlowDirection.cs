using System;

namespace Tizen.NUI.Binding
{
	[Flags]
	internal enum EffectiveFlowDirection
	{
		RightToLeft = 1 << 0,
		Explicit = 1 << 1,
	}
}