using NUnit.Framework;
using System;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/ReflectionExtensions")]
    internal class PublicReflectionExtensionsTest
    {
        private const string tag = "NUITEST";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        private class TypeImplement : Type
        {
            public override global::System.Reflection.Assembly Assembly => throw new NotImplementedException();

            public override string AssemblyQualifiedName => throw new NotImplementedException();

            public override Type BaseType => throw new NotImplementedException();

            public override string FullName => throw new NotImplementedException();

            public override Guid GUID => throw new NotImplementedException();

            public override global::System.Reflection.Module Module => throw new NotImplementedException();

            public override string Namespace => throw new NotImplementedException();

            public override Type UnderlyingSystemType => throw new NotImplementedException();

            public override string Name => throw new NotImplementedException();

            public override global::System.Reflection.ConstructorInfo[] GetConstructors(global::System.Reflection.BindingFlags bindingAttr)
            {
                throw new NotImplementedException();
            }

            public override object[] GetCustomAttributes(bool inherit)
            {
                throw new NotImplementedException();
            }

            public override object[] GetCustomAttributes(Type attributeType, bool inherit)
            {
                throw new NotImplementedException();
            }

            public override Type GetElementType()
            {
                throw new NotImplementedException();
            }

            public override global::System.Reflection.EventInfo GetEvent(string name, global::System.Reflection.BindingFlags bindingAttr)
            {
                throw new NotImplementedException();
            }

            public override global::System.Reflection.EventInfo[] GetEvents(global::System.Reflection.BindingFlags bindingAttr)
            {
                throw new NotImplementedException();
            }

            public override global::System.Reflection.FieldInfo GetField(string name, global::System.Reflection.BindingFlags bindingAttr)
            {
                throw new NotImplementedException();
            }

            public override global::System.Reflection.FieldInfo[] GetFields(global::System.Reflection.BindingFlags bindingAttr)
            {
                throw new NotImplementedException();
            }

            public override Type GetInterface(string name, bool ignoreCase)
            {
                throw new NotImplementedException();
            }

            public override Type[] GetInterfaces()
            {
                throw new NotImplementedException();
            }

            public override global::System.Reflection.MemberInfo[] GetMembers(global::System.Reflection.BindingFlags bindingAttr)
            {
                throw new NotImplementedException();
            }

            public override global::System.Reflection.MethodInfo[] GetMethods(global::System.Reflection.BindingFlags bindingAttr)
            {
                throw new NotImplementedException();
            }

            public override Type GetNestedType(string name, global::System.Reflection.BindingFlags bindingAttr)
            {
                throw new NotImplementedException();
            }

            public override Type[] GetNestedTypes(global::System.Reflection.BindingFlags bindingAttr)
            {
                throw new NotImplementedException();
            }

            public override global::System.Reflection.PropertyInfo[] GetProperties(global::System.Reflection.BindingFlags bindingAttr)
            {
                throw new NotImplementedException();
            }

            public override object InvokeMember(string name, global::System.Reflection.BindingFlags invokeAttr, global::System.Reflection.Binder binder, object target, object[] args, global::System.Reflection.ParameterModifier[] modifiers, global::System.Globalization.CultureInfo culture, string[] namedParameters)
            {
                throw new NotImplementedException();
            }

            public override bool IsDefined(Type attributeType, bool inherit)
            {
                throw new NotImplementedException();
            }

            protected override global::System.Reflection.TypeAttributes GetAttributeFlagsImpl()
            {
                throw new NotImplementedException();
            }

            protected override global::System.Reflection.ConstructorInfo GetConstructorImpl(global::System.Reflection.BindingFlags bindingAttr, global::System.Reflection.Binder binder, global::System.Reflection.CallingConventions callConvention, Type[] types, global::System.Reflection.ParameterModifier[] modifiers)
            {
                throw new NotImplementedException();
            }

            protected override global::System.Reflection.MethodInfo GetMethodImpl(string name, global::System.Reflection.BindingFlags bindingAttr, global::System.Reflection.Binder binder, global::System.Reflection.CallingConventions callConvention, Type[] types, global::System.Reflection.ParameterModifier[] modifiers)
            {
                throw new NotImplementedException();
            }

            protected override global::System.Reflection.PropertyInfo GetPropertyImpl(string name, global::System.Reflection.BindingFlags bindingAttr, global::System.Reflection.Binder binder, Type returnType, Type[] types, global::System.Reflection.ParameterModifier[] modifiers)
            {
                throw new NotImplementedException();
            }

            protected override bool HasElementTypeImpl()
            {
                throw new NotImplementedException();
            }

            protected override bool IsArrayImpl()
            {
                throw new NotImplementedException();
            }

            protected override bool IsByRefImpl()
            {
                throw new NotImplementedException();
            }

            protected override bool IsCOMObjectImpl()
            {
                throw new NotImplementedException();
            }

            protected override bool IsPointerImpl()
            {
                throw new NotImplementedException();
            }

            protected override bool IsPrimitiveImpl()
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        [Category("P1")]
        [Description("ReflectionExtensions GetField")]
        [Property("SPEC", "Tizen.NUI.ReflectionExtensions.GetField M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ReflectionExtensionsGetField()
        {
            tlog.Debug(tag, $"ReflectionExtensionsGetField START");

            try
            {
                TypeImplement type = new TypeImplement();

                ReflectionExtensions.GetField(type, "myName");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ReflectionExtensionsGetField END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ReflectionExtensions GetFields")]
        [Property("SPEC", "Tizen.NUI.ReflectionExtensions.GetFields M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ReflectionExtensionsGetFields()
        {
            tlog.Debug(tag, $"ReflectionExtensionsGetFields START");

            try
            {
                TypeImplement type = new TypeImplement();

                ReflectionExtensions.GetFields(type);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ReflectionExtensionsGetFields END (OK)");
            Assert.Pass("ReflectionExtensionsGetFields");
        }

        [Test]
        [Category("P1")]
        [Description("ReflectionExtensions GetProperties")]
        [Property("SPEC", "Tizen.NUI.ReflectionExtensions.GetProperties M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ReflectionExtensionsGetProperties()
        {
            tlog.Debug(tag, $"ReflectionExtensionsGetProperties START");

            try
            {
                TypeImplement type = new TypeImplement();

                ReflectionExtensions.GetProperties(type);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ReflectionExtensionsGetProperties END (OK)");
            Assert.Pass("ReflectionExtensionsGetProperties");
        }

        [Test]
        [Category("P1")]
        [Description("ReflectionExtensions GetProperty")]
        [Property("SPEC", "Tizen.NUI.ReflectionExtensions.GetProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ReflectionExtensionsGetProperty()
        {
            tlog.Debug(tag, $"ReflectionExtensionsGetProperty START");

            try
            {
                TypeImplement type = new TypeImplement();

                ReflectionExtensions.GetProperty(type, "myName");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ReflectionExtensionsGetProperty END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ReflectionExtensions IsAssignableFrom")]
        [Property("SPEC", "Tizen.NUI.ReflectionExtensions.IsAssignableFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ReflectionExtensionsIsAssignableFrom()
        {
            tlog.Debug(tag, $"ReflectionExtensionsIsAssignableFrom START");

            try
            {
                TypeImplement type = new TypeImplement();
                TypeImplement c = new TypeImplement();

                ReflectionExtensions.IsAssignableFrom(type, c);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ReflectionExtensionsIsAssignableFrom END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ReflectionExtensions IsInstanceOfType")]
        [Property("SPEC", "Tizen.NUI.ReflectionExtensions.IsInstanceOfType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ReflectionExtensionsIsInstanceOfType()
        {
            tlog.Debug(tag, $"ReflectionExtensionsIsInstanceOfType START");

            try
            {
                TypeImplement type = new TypeImplement();
                object o1 = new object();

                ReflectionExtensions.IsInstanceOfType(type, o1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ReflectionExtensionsIsInstanceOfType END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }
    }
}