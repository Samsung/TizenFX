
namespace Tizen.NUI.Binding
{
	public interface IPlatformElementConfiguration<out TPlatform, out TElement> : IConfigElement<TElement>
			where TPlatform : IConfigPlatform
	 		where TElement : Element
	{
	}
}
