namespace Tizen.NUI.Binding
{
    /// <summary>
    /// Marker interface for returning platform-specific configuration elements.
    /// </summary>
    /// <typeparam name="TPlatform">The platform type.</typeparam>
    /// <typeparam name="TElement">The element type.</typeparam>
    internal interface IPlatformElementConfiguration<out TPlatform, out TElement> : IConfigElement<TElement>
            where TPlatform : IConfigPlatform
             where TElement : Element
    {
    }
}
