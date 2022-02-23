using System.Collections.Generic;
using Mono.Cecil.Cil;

using Tizen.NUI.Xaml;

using static System.String;
using Tizen.NUI.Xaml.Build.Tasks;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class BindingTypeConverter : ICompiledTypeConverter
    {
        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            if (IsNullOrEmpty(value))
                throw new XamlParseException($"Cannot convert \"{value}\" into {typeof(Tizen.NUI.Binding.Binding)}", node);

            yield return Instruction.Create(OpCodes.Ldstr, value);
            yield return Instruction.Create(OpCodes.Ldc_I4, (int)BindingMode.Default);
            yield return Instruction.Create(OpCodes.Ldnull);
            yield return Instruction.Create(OpCodes.Ldnull);
            yield return Instruction.Create(OpCodes.Ldnull);
            yield return Instruction.Create(OpCodes.Ldnull);
            yield return Instruction.Create(OpCodes.Newobj, module.ImportCtorReference((XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "Binding"), parameterTypes: new[] {
                ("mscorlib", "System", "String"),
                (XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "BindingMode"),
                (XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "IValueConverter"),
                ("mscorlib", "System", "Object"),
                ("mscorlib", "System", "String"),
                ("mscorlib", "System", "Object")}));
        }
    }
}