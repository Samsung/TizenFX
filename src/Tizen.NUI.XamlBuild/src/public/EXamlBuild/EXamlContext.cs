/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;

using Tizen.NUI.Xaml;

namespace Tizen.NUI.EXaml.Build.Tasks
{
    internal class EXamlContext
    {
        public EXamlContext(TypeDefinition type, ModuleDefinition module, FieldDefinition parentContextValues = null)
        {
            Values = new Dictionary<INode, object>();
            Variables = new Dictionary<IElementNode, VariableDefinition>();
            Scopes = new Dictionary<INode, Tuple<VariableDefinition, IList<string>>>();
            TypeExtensions = new Dictionary<INode, TypeReference>();
            ParentContextValues = parentContextValues;
            Type = type;
            Module = module;
        }

        public Dictionary<INode, object> Values { get; private set; }

        public Dictionary<IElementNode, VariableDefinition> Variables { get; private set; }

        public Dictionary<INode, Tuple<VariableDefinition, IList<string>>> Scopes { get; private set; }

        public Dictionary<INode, TypeReference> TypeExtensions { get; }

        public FieldDefinition ParentContextValues { get; private set; }

        public object Root { get; set; } //FieldDefinition or VariableDefinition

        public INode RootNode { get; set; }

        public TypeDefinition Type { get; set; }

        public ModuleDefinition Module { get; private set; }

        public List<EXamlOperation> eXamlOperations = new List<EXamlOperation>();

        private string GetAssemblyName(AssemblyDefinition assembly)
        {
            string assemblyName = "";
            if (assembly.FullName.StartsWith("Tizen.NUI.XamlBuild"))
            {
                assemblyName = "Tizen.NUI";
            }
            else
            {
                assemblyName = assembly.FullName;

                if (assemblyName.EndsWith(".dll"))
                {
                    assemblyName = assemblyName.Substring(0, assemblyName.Length - ".dll".Length);
                }
                else if (assemblyName.EndsWith(".exe"))
                {
                    assemblyName = assemblyName.Substring(0, assemblyName.Length - ".exe".Length);
                }
                else
                {
                    int firstIndex = assemblyName.IndexOf(',');
                    assemblyName = assemblyName.Substring(0, firstIndex);
                }

                if ("Tizen.NUI.Xaml" == assemblyName)
                {
                    assemblyName = "Tizen.NUI";
                }
            }

            return assemblyName + ", ";
        }

        private string GetAssemblyName(Assembly assembly)
        {
            string assemblyName = "";
            if (assembly.FullName == typeof(EXamlOperation).Assembly.FullName)
            {
                assemblyName = "Tizen.NUI";
            }
            else
            {
                assemblyName = assembly.FullName;

                if (assemblyName.Substring(assemblyName.Length - ".dll".Length) == ".dll")
                {
                    assemblyName = assemblyName.Substring(0, assemblyName.Length - ".dll".Length);
                }
                else if (assemblyName.Substring(assemblyName.Length - ".exe".Length) == ".exe")
                {
                    assemblyName = assemblyName.Substring(0, assemblyName.Length - ".exe".Length);
                }

                if ("Tizen.NUI.Xaml" == assemblyName)
                {
                    assemblyName = "Tizen.NUI";
                }
            }

            return assemblyName + ", ";
        }

        private List<string> definedAssemblies
        {
            get;
        } = new List<string>();

        private List<TypeData> definedTypes
        {
            get;
        } = new List<TypeData>();

        internal EXamlDefinitionList<PropertyDefinition> definedProperties
        {
            get;
        } = new EXamlDefinitionList<PropertyDefinition>();

        internal EXamlDefinitionList<EventDefinition> definedEvents
        {
            get;
        } = new EXamlDefinitionList<EventDefinition>();

        internal List<IMemberDefinition> definedBindableProperties
        {
            get;
        } = new List<IMemberDefinition>();

        internal EXamlDefinitionList<MethodDefinition> definedMethods
        {
            get;
        } = new EXamlDefinitionList<MethodDefinition>();

        #region Data of CreateObject
        internal List<EXamlCreateObject> eXamlCreateObjects
        {
            get;
        } = new List<EXamlCreateObject>();

        internal Dictionary<(TypeReference, MemberReference), EXamlCreateObject> StaticInstances
        {
            get;
        } = new Dictionary<(TypeReference, MemberReference), EXamlCreateObject>();
        #endregion

        #region Data of AddObject
        internal List<EXamlAddObject> eXamlAddObjectList
        {
            get;
        } = new List<EXamlAddObject>();
        #endregion

        #region ConvertValue
        internal Dictionary<TypeDefinition, EXamlCreateObject> typeToInstance
        {
            get;
        } = new Dictionary<TypeDefinition, EXamlCreateObject>();
        #endregion

        #region Data of AddEvent
        internal List<EXamlAddEvent> eXamlAddEventList
        {
            get;
        } = new List<EXamlAddEvent>();
        #endregion

        #region Data of Register XName
        internal Dictionary<string, object> xNameToInstance
        {
            get;
        } = new Dictionary<string, object>();

        internal object GetObjectByXName(string xName)
        {
            object ret = null;
            xNameToInstance.TryGetValue(xName, out ret);
            return ret;
        }
        #endregion

        #region Data of Add Resource to Dictionary
        internal Dictionary<string, object> resourceDictionary
        {
            get;
        } = new Dictionary<string, object>();
        #endregion

        #region Data of Get object by property
        internal List<EXamlGetObjectByProperty> objectsAccordingToProperty = new List<EXamlGetObjectByProperty>();

        private int GetIndex(EXamlGetObjectByProperty eXamlObjectFromProperty)
        {
            return objectsAccordingToProperty.IndexOf(eXamlObjectFromProperty);
        }
        #endregion

        public string GenerateEXamlString()
        {
            string ret = "";

            int objectIndex = 0;

            foreach (var examlOp in eXamlCreateObjects)
            {
                if (examlOp.IsValid)
                {
                    examlOp.Index = objectIndex++;
                }
            }

            foreach (var examlOp in eXamlCreateObjects)
            {
                if (examlOp.IsValid)
                {
                    GatherType(examlOp.Type);

                    foreach (var property in examlOp.PropertyList)
                    {
                        GatherType(property.Item1);

                        definedProperties.Add(property.Item1, property.Item2);

                        if (true == property.Item1.Resolve()?.IsEnum)
                        {
                            GatherType(property.Item1.Resolve());
                        }
                    }

                    foreach (var eventDef in examlOp.EventList)
                    {
                        GatherType(eventDef.Item1);

                        definedEvents.Add(eventDef.Item1, eventDef.Item2);
                    }

                    foreach (var property in examlOp.BindableProperties)
                    {
                        if (!definedBindableProperties.Contains(property))
                        {
                            definedBindableProperties.Add(property);
                        }

                        var typeDef = property.DeclaringType;
                        if (-1 == GetTypeIndex(typeDef))
                        {
                            GatherType(property.DeclaringType);
                        }
                    }

                    foreach (var param in examlOp.paramsList)
                    {
                        if (null != param && param.GetType().IsEnum)
                        {
                            GatherType(param.GetType());
                        }
                    }

                    if (null != examlOp.XFactoryMethod)
                    {
                        GatherMethod((examlOp.XFactoryMethod.DeclaringType, examlOp.XFactoryMethod));
                    }
                }
            }

            foreach (var op in eXamlAddObjectList)
            {
                if (op.Parent.IsValid && (!(op.Child is EXamlCreateObject eXamlCreateObject) || eXamlCreateObject.IsValid))
                {
                    GatherMethod((op.Method.DeclaringType, op.Method));
                }
            }

            foreach (var op in eXamlAddEventList)
            {
                if (op.Instance.IsValid)
                {
                    GatherMethod((op.Value.DeclaringType, op.Value));
                }
            }

            foreach (var ass in definedAssemblies)
            {
                ret += String.Format("({0} ({1}))\n",
                                GetValueString((int)EXamlOperationType.GatherAssembly),
                                GetValueString(ass));
            }

            foreach (var type in definedTypes)
            {
                ret += String.Format("({0} {1})\n",
                                GetValueString((int)EXamlOperationType.GatherType),
                                type.ConvertToString(definedAssemblies, definedTypes));
            }

            foreach (var property in definedProperties)
            {
                var typeDef = property.Item1;
                int typeIndex = GetTypeIndex(typeDef);
                ret += String.Format("({0} ({1} {2}))\n",
                                GetValueString((int)EXamlOperationType.GatherProperty),
                                GetValueString(typeIndex),
                                GetValueString(property.Item2.Name));
            }

            foreach (var eventDef in definedEvents)
            {
                var typeDef = eventDef.Item1;
                int typeIndex = GetTypeIndex(typeDef);
                ret += String.Format("({0} ({1} {2}))\n",
                                GetValueString((int)EXamlOperationType.GatherEvent),
                                GetValueString(typeIndex),
                                GetValueString(eventDef.Item2.Name));
            }

            foreach (var method in definedMethods)
            {
                var typeDef = method.Item1;
                int typeIndex = GetTypeIndex(typeDef);

                string strForParam = "(";
                foreach (var param in method.Item2.Parameters)
                {
                    int paramTypeIndex = GetTypeIndex(param.ParameterType);

                    if (-1 == paramTypeIndex)
                    {
                        throw new Exception($"Can't find index of param type {param.ParameterType.FullName}");
                    }

                    strForParam += GetValueString(paramTypeIndex) + " ";
                }
                strForParam += ")";

                ret += String.Format("({0} ({1} {2} {3}))\n",
                                GetValueString((int)EXamlOperationType.GatherMethod),
                                GetValueString(typeIndex),
                                GetValueString(method.Item2.Name),
                                strForParam);
            }

            foreach (var property in definedBindableProperties)
            {
                var typeDef = property.DeclaringType;
                int typeIndex = GetTypeIndex(typeDef);
                ret += String.Format("({0} ({1} {2}))\n",
                                GetValueString((int)EXamlOperationType.GatherBindableProperty),
                                GetValueString(typeIndex),
                                GetValueString(property.Name));
            }

            foreach (var op in eXamlOperations)
            {
                ret += op.Write();
            }

            if (0 < longStrings.Length)
            {
                ret += String.Format("({0} ({1}))\n",
                                GetValueString((int)EXamlOperationType.GetLongString),
                                GetValueString(longStrings));
            }

            return ret;
        }

        private void GatherType(TypeReference typeRef)
        {
            if (-1 == GetTypeIndex(typeRef))
            {
                var assemblyName = GetAssemblyName(typeRef.Resolve().Module.Assembly);
                if (!definedAssemblies.Contains(assemblyName))
                {
                    definedAssemblies.Add(assemblyName);
                }

                var typeData = new TypeData(typeRef, GetAssemblyName(typeRef.Resolve().Module.Assembly));

                if (typeRef is GenericInstanceType genericType)
                {
                    foreach (var type in genericType.GenericArguments)
                    {
                        GatherType(type);
                    }
                }
                definedTypes.Add(typeData);
            }
        }

        private void GatherType(Type type)
        {
            var assemblyName = GetAssemblyName(type.Assembly);
            if (!definedAssemblies.Contains(assemblyName))
            {
                definedAssemblies.Add(assemblyName);
            }

            if (-1 == GetTypeIndex(type))
            {
                definedTypes.Add(new TypeData(type, GetAssemblyName(type.Assembly)));
            }
        }

        private void GatherMethod((TypeReference, MethodDefinition) methodInfo)
        {
            GatherType(methodInfo.Item1);

            foreach (var param in methodInfo.Item2.Parameters)
            {
                GatherType(param.ParameterType);
            }

            definedMethods.Add(methodInfo.Item1, methodInfo.Item2);
        }

        private int GetTypeIndex(TypeData typeData)
        {
            if (null != typeData.TypeReference)
            {
                return GetTypeIndex(typeData.TypeReference);
            }

            if (null != typeData.Type)
            {
                return GetTypeIndex(typeData.Type);
            }

            return -1;
        }

        internal int GetTypeIndex(TypeReference typeReference)
        {
            for (int i = 0; i < definedTypes.Count; i++)
            {
                if (EXamlUtility.IsSameTypeReference(typeReference, definedTypes[i].TypeReference))
                {
                    return i;
                }
            }

            int ret = -1;
            switch (typeReference.FullName)
            {
                case "System.SByte":
                    ret = -2;
                    break;
                case "System.Int16":
                    ret = -3;
                    break;
                case "System.Int32":
                    ret = -4;
                    break;
                case "System.Int64":
                    ret = -5;
                    break;
                case "System.Byte":
                    ret = -6;
                    break;
                case "System.UInt16":
                    ret = -7;
                    break;
                case "System.UInt32":
                    ret = -8;
                    break;
                case "System.UInt64":
                    ret = -9;
                    break;
                case "System.Boolean":
                    ret = -10;
                    break;
                case "System.String":
                    ret = -11;
                    break;
                case "System.Object":
                    ret = -12;
                    break;
                case "System.Char":
                    ret = -13;
                    break;
                case "System.Decimal":
                    ret = -14;
                    break;
                case "System.Single":
                    ret = -15;
                    break;
                case "System.Double":
                    ret = -16;
                    break;
                case "System.TimeSpan":
                    ret = -17;
                    break;
                case "System.Uri":
                    ret = -18;
                    break;
            }

            return ret;
        }

        internal static int GetTypeIndex(TypeData type, List<TypeData> definedTypes)
        {
            for (int i = 0; i < definedTypes.Count; i++)
            {
                if (EXamlUtility.IsSameTypeReference(type.TypeReference, definedTypes[i].TypeReference))
                {
                    return i;
                }
            }

            int ret = -1;
            switch (type.TypeReference.FullName)
            {
                case "System.SByte":
                    ret = -2;
                    break;
                case "System.Int16":
                    ret = -3;
                    break;
                case "System.Int32":
                    ret = -4;
                    break;
                case "System.Int64":
                    ret = -5;
                    break;
                case "System.Byte":
                    ret = -6;
                    break;
                case "System.UInt16":
                    ret = -7;
                    break;
                case "System.UInt32":
                    ret = -8;
                    break;
                case "System.UInt64":
                    ret = -9;
                    break;
                case "System.Boolean":
                    ret = -10;
                    break;
                case "System.String":
                    ret = -11;
                    break;
                case "System.Object":
                    ret = -12;
                    break;
                case "System.Char":
                    ret = -13;
                    break;
                case "System.Decimal":
                    ret = -14;
                    break;
                case "System.Single":
                    ret = -15;
                    break;
                case "System.Double":
                    ret = -16;
                    break;
                case "System.TimeSpan":
                    ret = -17;
                    break;
                case "System.Uri":
                    ret = -18;
                    break;
            }

            return ret;
        }

        private int GetTypeIndex(Type type)
        {
            for (int i = 0; i < definedTypes.Count; i++)
            {
                if (type == definedTypes[i].Type)
                {
                    return i;
                }
            }

            return -1;
        }

        internal (int, int) GetLongStringIndexs(string longString)
        {
            if (longStringToIndexPair.ContainsKey(longString))
            {
                return longStringToIndexPair[longString];
            }
            else
            {
                var indexPair = (longStrings.Length, 0);
                longStrings += longString;
                indexPair.Item2 = longStrings.Length - 1;

                longStringToIndexPair.Add(longString, indexPair);
                return indexPair;
            }
        }

        private string longStrings = "";
        private Dictionary<string, (int, int)> longStringToIndexPair = new Dictionary<string, (int, int)>();

        internal string GetValueString(object valueObject)
        {
            //Fang: How to deal the Enum
            string ret = "";

            if (null == valueObject)
            {
                ret += "zz ";
            }
            else if (valueObject is List<object> listObjects)
            {
                ret += "(";

                foreach (var obj in listObjects)
                {
                    ret += GetValueString(obj);
                    ret += " ";
                }

                ret += ")";
            }
            else
            {
                //Fang
                var paramType = valueObject.GetType();

                string signBegin = "a", signEnd = "a";
                string value = "";

                if (valueObject is EXamlCreateObject)
                {
                    signBegin = signEnd = "a";
                    value = (valueObject as EXamlCreateObject).Index.ToString();
                }
                else if (valueObject is EXamlGetObjectByProperty)
                {
                    return GetValueString(GetIndex(valueObject as EXamlGetObjectByProperty));
                }
                else if (paramType == typeof(string) || paramType == typeof(Uri))
                {
                    signBegin = signEnd = "\"";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(char))
                {
                    signBegin = signEnd = "\'";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(SByte))
                {
                    signBegin = signEnd = "b";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(Int16))
                {
                    signBegin = signEnd = "c";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(Int32))
                {
                    signBegin = signEnd = "d";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(Int64))
                {
                    signBegin = signEnd = "e";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(Byte))
                {
                    signBegin = signEnd = "f";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(UInt16))
                {
                    signBegin = signEnd = "g";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(UInt32))
                {
                    signBegin = signEnd = "h";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(UInt64))
                {
                    signBegin = signEnd = "i";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(Single))
                {
                    signBegin = signEnd = "j";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(Double))
                {
                    signBegin = signEnd = "k";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(TimeSpan))
                {
                    signBegin = signEnd = "l";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(Boolean))
                {
                    signBegin = signEnd = "m";
                    value = valueObject.ToString();
                }
                else if (paramType == typeof(decimal))
                {
                    signBegin = signEnd = "n";
                    value = valueObject.ToString();
                }
                else if (paramType.IsEnum)
                {
                    signBegin = "o(";
                    int typeIndex = GetTypeIndex(paramType);
                    value = String.Format("d{0}d \"{1}\"", typeIndex, valueObject.ToString());
                    signEnd = ")o";
                }
                else if (valueObject is EXamlValueConverterFromString)
                {
                    signBegin = "q(";
                    signEnd = ")q";
                    value = (valueObject as EXamlValueConverterFromString).GetString();
                }

                ret += String.Format("{0}{1}{2} ", signBegin, value, signEnd);
            }

            return ret;
        }
    }

    internal class TypeData
    {
        internal TypeData(Type type, string assemblyName)
        {
            Type = type;
            AssemblyName = assemblyName;

            if (type.IsNested)
            {
                FullName = type.FullName.Replace('/', '+');
            }
            else
            {
                FullName = type.FullName;
            }
        }

        internal TypeData(TypeReference typeReference, string assemblyName)
        {
            TypeReference = typeReference;

            AssemblyName = assemblyName;

            if (typeReference is GenericInstanceType genericType)
            {
                GenericArgumentTypes = new List<TypeData>();
                foreach (var type in genericType.GenericArguments)
                {
                    GenericArgumentTypes.Add(new TypeData(type, AssemblyName));
                }
                FullName = typeReference.Resolve().FullName;
            }
            else
            {
                FullName = typeReference.FullName;
            }

            if (typeReference.IsNested)
            {
                FullName = FullName.Replace('/', '+');
            }
        }

        public string ConvertToString(List<string> definedAssemblies, List<TypeData> typeDatas)
        {
            string ret = "";
            int assemblyIndex = definedAssemblies.IndexOf(AssemblyName);

            if (null == GenericArgumentTypes)
            {
                ret += String.Format("(d{0}d \"{1}\")", assemblyIndex, FullName);
            }
            else
            {
                string strForGenericTypes = "(";

                foreach (var type in GenericArgumentTypes)
                {
                    strForGenericTypes += "d" + EXamlContext.GetTypeIndex(type, typeDatas) + "d ";
                }

                strForGenericTypes += ")";

                ret += String.Format("(d{0}d \"{1}\" {2})", assemblyIndex, FullName, strForGenericTypes);
            }

            return ret;
        }

        internal TypeReference TypeReference
        {
            get;
        }

        internal Type Type
        {
            get;
        }

        internal string AssemblyName
        {
            get;
        }

        internal string FullName
        {
            get;
        }

        internal List<TypeData> GenericArgumentTypes
        {
            get;
        }
    }
}