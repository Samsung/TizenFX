using NUnit.Framework;
using System;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/ReflectionExtensions")]
    public class InternalReflectionExtensionsTest
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

        internal class TypeImpl : Type
        {
            public override global::System.Reflection.Assembly Assembly => global::System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "WeGanttGmTask.dll");
            public override string AssemblyQualifiedName => null;
            public override Type BaseType => null;
            public override string FullName => null;
            public override Guid GUID => new Guid("ebc600a9-4fa4-4bc4-88a9-0dd8d57f0076");
            public override global::System.Reflection.Module Module => this.GetType().Module;
            public override string Namespace => "http://www.w3school.com.cn/children/";
            public override Type UnderlyingSystemType => null;
            public override string Name => null;
            public override global::System.Reflection.ConstructorInfo[] GetConstructors(global::System.Reflection.BindingFlags bindingAttr) { return null; }
            public override object[] GetCustomAttributes(bool inherit) { return null; }
            public override object[] GetCustomAttributes(Type attributeType, bool inherit) { return null; }
            public override Type GetElementType() { return null; }
            public override global::System.Reflection.EventInfo GetEvent(string name, global::System.Reflection.BindingFlags bindingAttr) { return null; }
            public override global::System.Reflection.EventInfo[] GetEvents(global::System.Reflection.BindingFlags bindingAttr) { return null; }
            public override global::System.Reflection.FieldInfo GetField(string name, global::System.Reflection.BindingFlags bindingAttr) { return null; }
            public override global::System.Reflection.FieldInfo[] GetFields(global::System.Reflection.BindingFlags bindingAttr) { return null; }
            public override Type GetInterface(string name, bool ignoreCase) { return null; }
            public override Type[] GetInterfaces() { return null; }
            public override global::System.Reflection.MemberInfo[] GetMembers(global::System.Reflection.BindingFlags bindingAttr) { return null; }
            public override global::System.Reflection.MethodInfo[] GetMethods(global::System.Reflection.BindingFlags bindingAttr) { return null; }
            public override Type GetNestedType(string name, global::System.Reflection.BindingFlags bindingAttr) { return null; }
            public override Type[] GetNestedTypes(global::System.Reflection.BindingFlags bindingAttr) { return null; }
            public override global::System.Reflection.PropertyInfo[] GetProperties(global::System.Reflection.BindingFlags bindingAttr) { return null; }
            public override object InvokeMember(string name, global::System.Reflection.BindingFlags invokeAttr, global::System.Reflection.Binder binder, object target, object[] args, global::System.Reflection.ParameterModifier[] modifiers, global::System.Globalization.CultureInfo culture, string[] namedParameters) { return null; }
            public override bool IsDefined(Type attributeType, bool inherit) { return true; }
            protected override global::System.Reflection.TypeAttributes GetAttributeFlagsImpl() { return global::System.Reflection.TypeAttributes.Public; }
            protected override global::System.Reflection.ConstructorInfo GetConstructorImpl(global::System.Reflection.BindingFlags bindingAttr, global::System.Reflection.Binder binder, global::System.Reflection.CallingConventions callConvention, Type[] types, global::System.Reflection.ParameterModifier[] modifiers) { return null; }
            protected override global::System.Reflection.MethodInfo GetMethodImpl(string name, global::System.Reflection.BindingFlags bindingAttr, global::System.Reflection.Binder binder, global::System.Reflection.CallingConventions callConvention, Type[] types, global::System.Reflection.ParameterModifier[] modifiers) { return null; }
            protected override global::System.Reflection.PropertyInfo GetPropertyImpl(string name, global::System.Reflection.BindingFlags bindingAttr, global::System.Reflection.Binder binder, Type returnType, Type[] types, global::System.Reflection.ParameterModifier[] modifiers) { return null; }
            protected override bool HasElementTypeImpl() { return true; }
            protected override bool IsArrayImpl() { return true; }
            protected override bool IsByRefImpl() { return true; }
            protected override bool IsCOMObjectImpl() { return true; }
            protected override bool IsPointerImpl() { return true; }
            protected override bool IsPrimitiveImpl() { return true; }
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
                ReflectionExtensions.GetFields(new TypeImpl());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ReflectionExtensionsGetFields END");
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
                ReflectionExtensions.GetProperties(new TypeImpl());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ReflectionExtensionsGetProperties END");
        }
    }
}