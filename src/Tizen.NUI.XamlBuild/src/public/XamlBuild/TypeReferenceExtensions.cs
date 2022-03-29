/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    class TypeRefComparer : IEqualityComparer<TypeReference>
    {
        static string GetAssembly(TypeReference typeRef)
        {
            var md = typeRef.Scope as ModuleDefinition;
            if (md != null)
                return md.Assembly.FullName;
            var anr = typeRef.Scope as AssemblyNameReference;
            if (anr != null)
                return anr.FullName;
            throw new ArgumentOutOfRangeException(nameof(typeRef));
        }

        public bool Equals(TypeReference x, TypeReference y)
        {
            if (x == null)
                return y == null;
            if (y == null)
                return x == null;

            //strip the leading `&` as byref typered fullnames have a `&`
            var xname = x.FullName.EndsWith("&", StringComparison.InvariantCulture) ? x.FullName.Substring(0, x.FullName.Length - 1) : x.FullName;
            var yname = y.FullName.EndsWith("&", StringComparison.InvariantCulture) ? y.FullName.Substring(0, y.FullName.Length - 1) : y.FullName;
            if (xname != yname)
                return false;

            if ("Tizen.NUI.Binding.BindingBase" == xname)
            {
                return true;
            }

            var xasm = GetAssembly(x);
            var yasm = GetAssembly(y);

            //standard types comes from either mscorlib. System.Runtime or netstandard. Assume they are equivalent
            if ((      xasm.StartsWith("System.Runtime", StringComparison.Ordinal)
                    || xasm.StartsWith("System", StringComparison.Ordinal)
                    || xasm.StartsWith("mscorlib", StringComparison.Ordinal)
                    || xasm.StartsWith("netstandard", StringComparison.Ordinal)
                    || xasm.StartsWith("System.Xml", StringComparison.Ordinal))
                && (   yasm.StartsWith("System.Runtime", StringComparison.Ordinal)
                    || yasm.StartsWith("System", StringComparison.Ordinal)
                    || yasm.StartsWith("mscorlib", StringComparison.Ordinal)
                    || yasm.StartsWith("netstandard", StringComparison.Ordinal)
                    || yasm.StartsWith("System.Xml", StringComparison.Ordinal)))
                return true;
            return xasm == yasm;
        }

        public int GetHashCode(TypeReference obj)
        {
            return $"{GetAssembly(obj)}//{obj.FullName}".GetHashCode();
        }

        static TypeRefComparer s_default;
        public static TypeRefComparer Default => s_default ?? (s_default = new TypeRefComparer());
    }

    static class TypeReferenceExtensions
    {
        public static PropertyDefinition GetProperty(this TypeReference typeRef, Func<PropertyDefinition, bool> predicate,
            out TypeReference declaringTypeRef)
        {
            declaringTypeRef = typeRef;
            var typeDef = typeRef.ResolveCached();
            var properties = typeDef.Properties.Where(predicate);
            if (properties.Any())
                return properties.Single();
            if (typeDef.BaseType == null || typeDef.BaseType.FullName == "System.Object")
                return null;
            return typeDef.BaseType.ResolveGenericParameters(typeRef).GetProperty(predicate, out declaringTypeRef);
        }

        public static EventDefinition GetEvent(this TypeReference typeRef, Func<EventDefinition, bool> predicate,
            out TypeReference declaringTypeRef)
        {
            declaringTypeRef = typeRef;
            var typeDef = typeRef.ResolveCached();
            var events = typeDef.Events.Where(predicate);
            if (events.Any()) {
                var ev = events.Single();
                return ev.ResolveGenericEvent(declaringTypeRef);
            }
            if (typeDef.BaseType == null || typeDef.BaseType.FullName == "System.Object")
                return null;
            return typeDef.BaseType.ResolveGenericParameters(typeRef).GetEvent(predicate, out declaringTypeRef);
        }

        //this resolves generic eventargs (https://bugzilla.xamarin.com/show_bug.cgi?id=57574)
        static EventDefinition ResolveGenericEvent(this EventDefinition eventDef, TypeReference declaringTypeRef)
        {
            if (eventDef == null)
                throw new ArgumentNullException(nameof(eventDef));
            if (declaringTypeRef == null)
                throw new ArgumentNullException(nameof(declaringTypeRef));
            if (!eventDef.EventType.IsGenericInstance)
                return eventDef;
            if (eventDef.EventType.ResolveCached().FullName != "System.EventHandler`1")
                return eventDef;

            var git = eventDef.EventType as GenericInstanceType;
            var ga = git.GenericArguments.First();
            ga = ga.ResolveGenericParameters(declaringTypeRef);
            git.GenericArguments[0] = ga;
            eventDef.EventType = git;

            return eventDef;

        }
        public static FieldDefinition GetField(this TypeReference typeRef, Func<FieldDefinition, bool> predicate,
            out TypeReference declaringTypeRef)
        {
            declaringTypeRef = typeRef;
            var typeDef = typeRef.ResolveCached();
            var bp = typeDef.Fields.Where
                (predicate);
            if (bp.Any())
                return bp.Single();
            if (typeDef.BaseType == null || typeDef.BaseType.FullName == "System.Object")
                return null;
            return typeDef.BaseType.ResolveGenericParameters(typeRef).GetField(predicate, out declaringTypeRef);
        }

        public static bool ImplementsInterface(this TypeReference typeRef, TypeReference @interface)
        {
            var typeDef = typeRef.ResolveCached();
            if (typeDef.Interfaces.Any(tr => tr.InterfaceType.FullName == @interface.FullName))
                return true;
            var baseTypeRef = typeDef.BaseType;
            if (baseTypeRef != null && baseTypeRef.FullName != "System.Object")
                return baseTypeRef.ImplementsInterface(@interface);
            return false;
        }

        public static bool ImplementsGenericInterface(this TypeReference typeRef, string @interface,
            out GenericInstanceType interfaceReference, out IList<TypeReference> genericArguments)
        {
            interfaceReference = null;
            genericArguments = null;
            var typeDef = typeRef.ResolveCached();
            InterfaceImplementation iface;
            if ((iface = typeDef.Interfaces.FirstOrDefault(tr =>
                            tr.InterfaceType.FullName.StartsWith(@interface, StringComparison.Ordinal) &&
                            tr.InterfaceType.IsGenericInstance && (tr.InterfaceType as GenericInstanceType).HasGenericArguments)) != null)
            {
                interfaceReference = iface.InterfaceType as GenericInstanceType;
                genericArguments = (iface.InterfaceType as GenericInstanceType).GenericArguments;
                return true;
            }
            var baseTypeRef = typeDef.BaseType;
            if (baseTypeRef != null && baseTypeRef.FullName != "System.Object")
                return baseTypeRef.ImplementsGenericInterface(@interface, out interfaceReference, out genericArguments);
            return false;
        }

        static readonly string[] arrayInterfaces = {
            "System.ICloneable",
            "System.Collections.IEnumerable",
            "System.Collections.IList",
            "System.Collections.ICollection",
            "System.Collections.IStructuralComparable",
            "System.Collections.IStructuralEquatable",
        };

        static readonly string[] arrayGenericInterfaces = {
            "System.Collections.Generic.IEnumerable`1",
            "System.Collections.Generic.IList`1",
            "System.Collections.Generic.ICollection`1",
            "System.Collections.Generic.IReadOnlyCollection`1",
            "System.Collections.Generic.IReadOnlyList`1",
        };

        public static bool IsInterface(this TypeReference typeRef, string interfaceTypeName)
        {
            if (null == typeRef)
            {
                return false;
            }
            else
            {
                var typeDef = typeRef.ResolveCached();

                if (null == typeDef)
                {
                    return false;
                }
                else
                {
                    foreach (var @interface in typeDef.Interfaces)
                    {
                        if (InheritsFromOrImplements(@interface.InterfaceType, interfaceTypeName)
                            ||
                            InheritsFromOrImplements(@interface.InterfaceType.Resolve(), interfaceTypeName))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }

        public static bool IsInterface(this TypeReference typeRef, Type interfaceType)
        {
            return IsInterface(typeRef, interfaceType.FullName);
        }

        public static bool InheritsFromOrImplements(this TypeReference typeRef, string typeFullName)
        {
            if (null == typeRef)
            {
                return false;
            }
            else if (typeRef.FullName == typeFullName)
            {
                return true;
            }
            else
            {
                var typeDef = typeRef.ResolveCached();

                if (null == typeDef)
                {
                    return false;
                }
                else
                {
                    return InheritsFromOrImplements(typeDef.BaseType, typeFullName);
                }
            }
        }

        public static bool InheritsFromOrImplements(this TypeReference typeRef, TypeReference baseClass)
        {
            if (TypeRefComparer.Default.Equals(typeRef, baseClass))
                return true;

            if (typeRef.IsValueType)
                return false;

            if (typeRef.IsArray) {
                var array = (ArrayType)typeRef;
                var arrayType = typeRef.ResolveCached();
                if (arrayInterfaces.Contains(baseClass.FullName))
                    return true;
                if (array.IsVector &&  //generic interfaces are not implemented on multidimensional arrays
                    arrayGenericInterfaces.Contains(baseClass.ResolveCached().FullName) &&
                    baseClass.IsGenericInstance &&
                    TypeRefComparer.Default.Equals((baseClass as GenericInstanceType).GenericArguments[0], arrayType))
                    return true;
                return baseClass.FullName == "System.Object";
            }

            if (typeRef.FullName == "System.Object")
                return false;
            var typeDef = typeRef.ResolveCached();
            if (TypeRefComparer.Default.Equals(typeDef, baseClass.ResolveCached()))
                return true;
            if (typeDef.Interfaces.Any(ir => TypeRefComparer.Default.Equals(ir.InterfaceType.ResolveGenericParameters(typeRef), baseClass)))
                return true;
            if (typeDef.BaseType == null)
                return false;

            typeRef = typeDef.BaseType.ResolveGenericParameters(typeRef);
            return typeRef.InheritsFromOrImplements(baseClass);
        }

        static CustomAttribute GetCustomAttribute(this TypeReference typeRef, TypeReference attribute)
        {
            var typeDef = typeRef.ResolveCached();
            //FIXME: avoid string comparison. make sure the attribute TypeRef is the same one
            var attr = typeDef.CustomAttributes.SingleOrDefault(ca => ca.AttributeType.FullName == attribute.FullName);
            if (attr != null)
                return attr;
            var baseTypeRef = typeDef.BaseType;
            if (baseTypeRef != null && baseTypeRef.FullName != "System.Object")
                return baseTypeRef.GetCustomAttribute(attribute);
            return null;
        }

        public static CustomAttribute GetCustomAttribute(this TypeReference typeRef, ModuleDefinition module, (string assemblyName, string clrNamespace, string typeName) attributeType)
        {
            return typeRef.GetCustomAttribute(module.ImportReference(attributeType));
        }

        [Obsolete]
        public static MethodDefinition GetMethod(this TypeReference typeRef, Func<MethodDefinition, bool> predicate)
        {
            TypeReference declaringTypeReference;
            return typeRef.GetMethod(predicate, out declaringTypeReference);
        }

        [Obsolete]
        public static MethodDefinition GetMethod(this TypeReference typeRef, Func<MethodDefinition, bool> predicate,
            out TypeReference declaringTypeRef)
        {
            declaringTypeRef = typeRef;
            var typeDef = typeRef.ResolveCached();
            var methods = typeDef.Methods.Where(predicate);
            if (methods.Any())
                return methods.Single();
            if (typeDef.BaseType != null && typeDef.BaseType.FullName == "System.Object")
                return null;
            if (typeDef.IsInterface)
            {
                foreach (var face in typeDef.Interfaces)
                {
                    var m = face.InterfaceType.GetMethod(predicate);
                    if (m != null)
                        return m;
                }
                return null;
            }
            return typeDef.BaseType.GetMethod(predicate, out declaringTypeRef);
        }

        public static IEnumerable<Tuple<MethodDefinition, TypeReference>> GetMethods(this TypeReference typeRef,
            Func<MethodDefinition, bool> predicate, ModuleDefinition module)
        {
            return typeRef.GetMethods((md, tr) => predicate(md), module);
        }

        public static IEnumerable<Tuple<MethodDefinition, TypeReference>> GetMethods(this TypeReference typeRef,
            Func<MethodDefinition, TypeReference, bool> predicate, ModuleDefinition module)
        {
            var typeDef = typeRef.ResolveCached();
            foreach (var method in typeDef.Methods.Where(md => predicate(md, typeRef)))
                yield return new Tuple<MethodDefinition, TypeReference>(method, typeRef);
            if (typeDef.IsInterface)
            {
                foreach (var face in typeDef.Interfaces)
                {
                    if (face.InterfaceType.IsGenericInstance && typeRef is GenericInstanceType)
                    {
                        int i = 0;
                        foreach (var arg in ((GenericInstanceType)typeRef).GenericArguments)
                            ((GenericInstanceType)face.InterfaceType).GenericArguments[i++] = module.ImportReference(arg);
                    }
                    foreach (var tuple in face.InterfaceType.GetMethods(predicate, module))
                        yield return tuple;
                }
                yield break;
            }
            if (typeDef.BaseType == null || typeDef.BaseType.FullName == "System.Object")
                yield break;
            var baseType = typeDef.BaseType.ResolveGenericParameters(typeRef);
            foreach (var tuple in baseType.GetMethods(predicate, module))
                yield return tuple;
        }

        public static MethodReference GetImplicitOperatorTo(this TypeReference fromType, TypeReference toType, ModuleDefinition module)
        {
            if (TypeRefComparer.Default.Equals(fromType, toType))
                return null;

            var implicitOperatorsOnFromType = fromType.GetMethods(md =>    md.IsPublic
                                                                        && md.IsStatic
                                                                        && md.IsSpecialName
                                                                        && md.Name == "op_Implicit", module);
            var implicitOperatorsOnToType = toType.GetMethods(md =>    md.IsPublic
                                                                    && md.IsStatic
                                                                    && md.IsSpecialName
                                                                    && md.Name == "op_Implicit", module);

            var implicitOperators = implicitOperatorsOnFromType.Concat(implicitOperatorsOnToType).ToList();

            if (implicitOperators.Any()) {
                foreach (var op in implicitOperators) {
                    var cast = op.Item1;
                    var opDeclTypeRef = op.Item2;
                    var castDef = module.ImportReference(cast).ResolveGenericParameters(opDeclTypeRef, module);
                    var returnType = castDef.ReturnType;
                    if (returnType.IsGenericParameter)
                        returnType = ((GenericInstanceType)opDeclTypeRef).GenericArguments [((GenericParameter)returnType).Position];
                    if (!returnType.InheritsFromOrImplements(toType))
                        continue;
                    var paramType = cast.Parameters[0].ParameterType;
                    if (!fromType.InheritsFromOrImplements(paramType))
                        continue;
                    return castDef;
                }
            }
            return null;
        }

        public static TypeReference ResolveGenericParameters(this TypeReference self, TypeReference declaringTypeReference)
        {
            var genericself = self as GenericInstanceType;
            if (genericself == null)
                return self;

            var genericdeclType = declaringTypeReference as GenericInstanceType;
            if (genericdeclType == null)
                return self;

            if (!genericself.GenericArguments.Any(arg => arg.IsGenericParameter))
                return self;

            List<TypeReference> args = new List<TypeReference>();
            for (var i = 0; i < genericself.GenericArguments.Count; i++) {
                if (!genericself.GenericArguments[i].IsGenericParameter)
                    args.Add(genericself.GenericArguments[i]);
                else
                    args.Add(genericdeclType.GenericArguments[(genericself.GenericArguments[i] as GenericParameter).Position]);
            }
            return self.GetElementType().MakeGenericInstanceType(args.ToArray());
        }

        static Dictionary<TypeReference, TypeDefinition> resolves = new Dictionary<TypeReference, TypeDefinition>();
        public static TypeDefinition ResolveCached(this TypeReference typeReference)
        {
            if (resolves.TryGetValue(typeReference, out var typeDefinition))
                return typeDefinition;
            return (resolves[typeReference] = typeReference.Resolve());
        }
    }
}
 
