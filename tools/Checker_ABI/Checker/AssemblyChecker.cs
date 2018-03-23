using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Checker_ABI
{
    internal class AssemblyChecker
    {
        private const BindingFlags s_PublicOnlyFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static;

        public bool TypeValidate(Type originalType, Type comparedType)
        {
            var originalMembers = originalType.GetMembers(s_PublicOnlyFlags);
            var comparedMembers = comparedType.GetMembers(s_PublicOnlyFlags);

            // Compare Number of public Methods
            MethodInfo[] originalMethods = originalType.GetMethods(s_PublicOnlyFlags);
            MethodInfo[] comparedMethods = comparedType.GetMethods(s_PublicOnlyFlags);

            if (comparedMethods.Length != originalMethods.Length)
                return false;

            // Compare Number of public Properties
            PropertyInfo[] originalProperties = originalType.GetProperties(s_PublicOnlyFlags);
            PropertyInfo[] comparedProperties = comparedType.GetProperties(s_PublicOnlyFlags);

            if (comparedProperties.Length != originalProperties.Length)
                return false;

            // Compare number of public fields
            FieldInfo[] originalFields = originalType.GetFields(s_PublicOnlyFlags);
            FieldInfo[] comparedToFields = comparedType.GetFields(s_PublicOnlyFlags);

            if (comparedToFields.Length != originalFields.Length)
                return false;


            // Compare number of public events
            EventInfo[] originalEvents = originalType.GetEvents(s_PublicOnlyFlags);
            EventInfo[] comparedToEvents = comparedType.GetEvents(s_PublicOnlyFlags);

            if (originalEvents.Length != comparedToEvents.Length)
                return false;

            return true;
        }

        public IList<MemberInfo> CompareClassTypeToList(Type originalType, Type comparedType)
        {
            if (originalType.ToString() != comparedType.ToString())
            {
                throw new ArgumentException("The full name of type is different. ABI check is only possible if name is the same.");
            }

            IList<MemberInfo> diffrentMemberList = new List<MemberInfo>();
            var originalMembers = originalType.GetMembers(s_PublicOnlyFlags).ToList();
            var comparedMembers = comparedType.GetMembers(s_PublicOnlyFlags).ToList();

            for (int i = originalMembers.Count-1; i >= 0; i--)
            {
                bool bResult = false;
                for (int j = comparedMembers.Count-1; j >= 0; j--)
                {
                     if (originalMembers[i].ToString() == comparedMembers[j].ToString())
                    {
                        if (originalMembers[i] is MethodInfo first && comparedMembers[j] is MethodInfo last)
                        {
                            if (first.GetBaseDefinition().DeclaringType.ToString() != last.GetBaseDefinition().DeclaringType.ToString())
                            {
                                continue;
                            }
                        }

                        bResult = true;
                        originalMembers.RemoveAt(i);
                        comparedMembers.RemoveAt(j);
                        break;
                    }
                }

                if (!bResult)
                {
                    diffrentMemberList.Add(originalMembers[i]);
                }
            }

            if (comparedMembers.Count > 0)
            {
                foreach (var item in originalMembers)
                    diffrentMemberList.Add(item);

                foreach (var item in comparedMembers)
                    diffrentMemberList.Add(item);
            }

            return diffrentMemberList;
        }

        public IList<MemberInfo> CheckAssemblyToList(Assembly baseAssembly, Assembly latestAssembly)
        {
            var baseInfos = baseAssembly.GetTypes().Where(b => b.IsPublic).ToList();
            var lastInfos = latestAssembly.GetTypes().Where(b => b.IsPublic).ToList();
            var diffrentMemberList = new List<MemberInfo>();

            for (int i = 0; i < baseInfos.Count; i++)
            {
                for (int j = 0; j < lastInfos.Count; j++)
                {
                    if (baseInfos[i].ToString() == lastInfos[j].ToString())
                    {
                        var result = CompareClassTypeToList(baseInfos[i], lastInfos[j]);

                        if (result?.Count > 0)
                        {
                            Console.WriteLine($"ABI BREAK!! {baseInfos[i]} : Diffrent Member Count : {result.Count}");
                            foreach (var item in result)
                            {
                                diffrentMemberList.Add(item);
                                Console.WriteLine($"ABI BREAK!! {item.DeclaringType}::{item}");
                            }
                        }
                    }
                }
            }
            return diffrentMemberList;
        }
    }
}
