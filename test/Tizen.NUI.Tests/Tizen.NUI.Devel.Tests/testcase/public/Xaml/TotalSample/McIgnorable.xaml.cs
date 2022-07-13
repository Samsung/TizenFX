using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    public partial class McIgnorable : View
	{
		public McIgnorable ()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(McIgnorable));
        }
	}


	[TestFixture]
	public class McIgnorableTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		[Category("P1")]
		[Description("Extensions LoadFromXaml.")]
		[Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
		[Property("SPEC_URL", "-")]
		[Property("CRITERIA", "MR")]
		public void DoesNotThrow()
		{
			var layout = new McIgnorable();
		}
	}
}