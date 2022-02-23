using System;
using System.Collections.Generic;
using System.Linq;

using Mono.Cecil;
using Mono.Cecil.Cil;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class LayoutOptionsConverter : ICompiledTypeConverter
    {
        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            do {
                if (string.IsNullOrEmpty(value))
                    break;

                value = value.Trim();

                var parts = value.Split('.');
                if (parts.Length == 1 || (parts.Length == 2 && parts [0] == "LayoutOptions")) {
                    var options = parts [parts.Length - 1];

                    var fieldReference = module.ImportFieldReference((XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "LayoutOptions"),
                                                                     fieldName: options,
                                                                     isStatic: true);
                    if (fieldReference != null) {
                        yield return Instruction.Create(OpCodes.Ldsfld, fieldReference);
                        yield break;
                    }
                }
            } while (false);

            throw new XamlParseException(String.Format("Cannot convert \"{0}\" into LayoutOptions", value), node);
        }
    }
}