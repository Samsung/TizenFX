using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Checker_ABI
{
    internal class AssemblyChecker
    {
        private const BindingFlags PublicOnlyFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static;

        public IList<MemberInfo> CompareClassTypes(Type originalType, Type targetType)
        {
            if (originalType.ToString() != targetType.ToString())
            {
                throw new ArgumentException("The full name of type is different. ABI check is only possible if name is the same.");
            }

            var originalMembers = originalType.GetMembers(PublicOnlyFlags).ToList();
            var targetMembers = targetType.GetMembers(PublicOnlyFlags).ToList();

            for (int i = originalMembers.Count-1; i >= 0; i--)
            {
                for (int j = targetMembers.Count-1; j >= 0; j--)
                {
                    if (originalMembers[i].ToString() == targetMembers[j].ToString())
                    {
                        if (originalMembers[i] is MethodInfo originalMember && targetMembers[j] is MethodInfo targetMamber)
                        {
                            if (originalMember.GetBaseDefinition().DeclaringType.ToString() != targetMamber.GetBaseDefinition().DeclaringType.ToString())
                            {
                                continue;
                            }
                        }
                        originalMembers.RemoveAt(i);
                        targetMembers.RemoveAt(j);
                        break;
                    }
                }
            }

            IList<MemberInfo> diffrentMemberList = new List<MemberInfo>();
            foreach (var item in originalMembers)
            {
                Console.WriteLine($"  !! Missing API: {item.DeclaringType}::{item.ToString()}");
                diffrentMemberList.Add(item);
            }

            foreach (var item in targetMembers)
            {
                Console.WriteLine($"  !! Added API: {item.DeclaringType}::{item.ToString()}");
                diffrentMemberList.Add(item);
            }

            return diffrentMemberList;
        }

        public IList<MemberInfo> CheckAssemblyFile(Assembly baseAssembly, Assembly targetAssembly)
        {
            var basePublicTypes = baseAssembly.GetTypes().Where(b => b.IsPublic).ToList();
            var targetPublicTypes = targetAssembly.GetTypes().Where(b => b.IsPublic).ToList();
            var diffrentMemberList = new List<MemberInfo>();

            for (int i = 0; i < basePublicTypes.Count; i++)
            {
                for (int j = 0; j < targetPublicTypes.Count; j++)
                {
                    if (basePublicTypes[i].ToString() == targetPublicTypes[j].ToString())
                    {
                        var differentMembers = CompareClassTypes(basePublicTypes[i], targetPublicTypes[j]);

                        if (differentMembers?.Count > 0)
                        {
                            Console.WriteLine($"  ==> {basePublicTypes[i]}, Diffrent Member Count : {differentMembers.Count}");
                            foreach (var member in differentMembers)
                            {
                                diffrentMemberList.Add(member);
                            }
                        }
                    }
                }
            }
            return diffrentMemberList;
        }

        public IList<MemberInfo> CheckAssemblyFile(Assembly assembly)
        {
            var publicTypes = assembly.GetTypes().Where(b => b.IsPublic).ToList();
            var diffrentMemberList = new List<MemberInfo>();

            foreach (var type in publicTypes)
            {
                diffrentMemberList = diffrentMemberList.Concat(type.GetMembers(PublicOnlyFlags)).ToList();
            }

            return diffrentMemberList;
        }
    }
}
