
namespace Tizen.NUI.Binding
{
	public interface IConfigElement<out T> where T : Element
	{
		T Element { get; }
	}
}
