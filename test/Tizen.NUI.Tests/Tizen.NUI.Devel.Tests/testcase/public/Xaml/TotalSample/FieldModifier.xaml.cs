﻿using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    public partial class FieldModifier : View
	{
        public FieldModifier()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(FieldModifier));

            privateLabel = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "privateLabel");
            internalLabel = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "internalLabel");
            publicLabel = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "publicLabel");
        }
	}

	[TestFixture]
	public class FieldModifierTests
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
		public void TestFieldModifier()
		{
			var layout = new FieldModifier();
			Assert.That(layout.privateLabel, Is.Not.Null);
			Assert.That(layout.internalLabel, Is.Not.Null);
			Assert.That(layout.publicLabel, Is.Not.Null);

			var fields = typeof(FieldModifier).GetTypeInfo().DeclaredFields;

			Assert.That(fields.First(fi => fi.Name == "privateLabel").IsPrivate, Is.False);
		}
	}
}
