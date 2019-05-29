using System;
using Tizen.NUI.XamlBinding.Internals;
using Tizen.NUI.Xaml.Internals;
using Tizen.NUI.XamlBinding;
using System.ComponentModel;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The class ReferenceExtension.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Name")]
    public class ReferenceExtension : IMarkupExtension
    {
        /// <summary>
        /// Attribute Name
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; set; }

        /// <summary>
        /// Provide value tye service provideer.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            var valueProvider = serviceProvider.GetService(typeof (IProvideValueTarget)) as IProvideParentValues;
            if (valueProvider == null)
                throw new ArgumentException("serviceProvider does not provide an IProvideValueTarget");
            var namescopeprovider = serviceProvider.GetService(typeof (INameScopeProvider)) as INameScopeProvider;
            if (namescopeprovider != null && namescopeprovider.NameScope != null)
            {
                var value = namescopeprovider.NameScope.FindByName(Name);
                if (value != null)
                    return value;
            }

            foreach (var target in valueProvider.ParentObjects)
            {
                var ns = target as INameScope;
                if (ns == null)
                    continue;
                var value = ns.FindByName(Name);
                if (value != null)
                    return value;
            }

            var lineInfo = (serviceProvider?.GetService(typeof(IXmlLineInfoProvider)) as IXmlLineInfoProvider)?.XmlLineInfo ?? new XmlLineInfo();
            throw new XamlParseException($"Can not find the object referenced by `{Name}`", lineInfo);
        }
    }
}