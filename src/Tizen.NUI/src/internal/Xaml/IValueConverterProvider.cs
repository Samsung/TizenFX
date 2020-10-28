using System;
using System.Reflection;

namespace Tizen.NUI.Xaml
{
    internal interface IValueConverterProvider
    {
        object Convert(object value, Type toType, Func<MemberInfo> minfoRetriever, IServiceProvider serviceProvider);
    }
}