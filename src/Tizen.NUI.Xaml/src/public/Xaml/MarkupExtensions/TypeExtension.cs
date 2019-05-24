using System;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The class TemplateBindingExtension.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [ContentProperty(nameof(TypeName))]
    [ProvideCompiled("Tizen.NUI.Xaml.Build.Tasks.TypeExtension")]
    public class TypeExtension : IMarkupExtension<Type>
    {
        /// <summary>
        /// Attribute TypeName
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string TypeName { get; set; }

        /// <summary>
        /// Provide value tye service provideer.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public Type ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(TypeName))
                throw new InvalidOperationException("TypeName isn't set.");
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            var typeResolver = serviceProvider.GetService(typeof (IXamlTypeResolver)) as IXamlTypeResolver;
            if (typeResolver == null)
                throw new ArgumentException("No IXamlTypeResolver in IServiceProvider");

            return typeResolver.Resolve(TypeName, serviceProvider);
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<Type>).ProvideValue(serviceProvider);
        }
    }
}