using System;
using System.Reflection;

namespace Tizen.NUI.Xaml
{
    internal interface IValueConverterProvider
    {
        object Convert(object value, System.Type toType, Func<MemberInfo> minfoRetriever, IServiceProvider serviceProvider);
    }
}