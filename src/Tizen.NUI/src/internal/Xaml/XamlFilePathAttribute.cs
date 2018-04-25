using System;
using System.Runtime.CompilerServices;

namespace Tizen.NUI.Xaml
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	internal sealed class XamlFilePathAttribute : Attribute
	{
		public XamlFilePathAttribute([CallerFilePath] string filePath = "")
		{
		}
	}
}