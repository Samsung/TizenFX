using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                        if (originalMembers[i].GetCustomAttribute<System.ComponentModel.EditorBrowsableAttribute>()?.State
                            != targetMembers[j].GetCustomAttribute<System.ComponentModel.EditorBrowsableAttribute>()?.State)
                        {

                            continue;
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
            var differentMemberList = new List<MemberInfo>();

            var removedClasses = basePublicTypes.Where(b => !targetPublicTypes.Any(t => {
                return (t.FullName == b.FullName)
                && (t.GetCustomAttribute<EditorBrowsableAttribute>()?.State == b.GetCustomAttribute<EditorBrowsableAttribute>()?.State);
                }));
            foreach (var type in removedClasses)
            {
                Console.WriteLine($"  !! Missing Class: {type.FullName}");
                foreach (var member in type.GetMembers(PublicOnlyFlags))
                {
                    Console.WriteLine($"    !! Missing API: {member.ToString()}");
                    differentMemberList.Add(member);
                }
            }

            var addedClasses = targetPublicTypes.Where(t => !basePublicTypes.Any(b => {
                return (b.FullName == t.FullName)
                && (b.GetCustomAttribute<EditorBrowsableAttribute>()?.State == t.GetCustomAttribute<EditorBrowsableAttribute>()?.State);
                }));
            foreach (var type in addedClasses)
            {
                Console.WriteLine($"  !! Added Class: {type.FullName}");
                foreach(var member in type.GetMembers(PublicOnlyFlags))
                {
                    Console.WriteLine($"    !! Added API: {member.ToString()}");
                    differentMemberList.Add(member);
                }
            }

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
                                differentMemberList.Add(member);
                            }
                        }
                    }
                }
            }
            return differentMemberList;
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
