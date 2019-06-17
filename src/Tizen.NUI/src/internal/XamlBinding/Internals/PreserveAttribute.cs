﻿using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding.Internals
{
	[AttributeUsage(AttributeTargets.All)]
    internal class PreserveAttribute : Attribute
	{
		public bool AllMembers;
		public bool Conditional;

		public PreserveAttribute(bool allMembers, bool conditional)
		{
			AllMembers = allMembers;
			Conditional = conditional;
		}

		public PreserveAttribute()
		{
		}
	}
}