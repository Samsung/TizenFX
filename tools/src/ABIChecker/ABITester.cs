using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Checker_ABI
{
    public class ABIChecker
    {
        AssemblyChecker _checker = new AssemblyChecker();
        string _basePath;
        string _targetPath;
        bool _isFile;

        [Flags]
        public enum ABITestResult
        {
            None = 0,
            InternalAPIChanged = 1 << 0,
            ACRRequired = 1 << 1
        }

        public ABIChecker(string basePath, string targetPath, bool isFile)
        {
            _basePath = basePath;
            _targetPath = targetPath;
            _isFile = isFile;
        }

        public ABITestResult CheckABI()
        {
            if (!_isFile)
            {
                return CheckDirectory();
            }
            else
            {
                var changedAPIList = _checker.CheckAssemblyFile(Assembly.LoadFrom(_basePath), Assembly.LoadFile(_targetPath));
                var internalAPIList = new List<MemberInfo>();
                for (int i = changedAPIList.Count - 1; i >= 0; i--)
                {
                    if (changedAPIList[i].GetCustomAttribute<System.ComponentModel.EditorBrowsableAttribute>()?.State == System.ComponentModel.EditorBrowsableState.Never)
                    {
                        Console.WriteLine($"  Internal API changed: {changedAPIList[i].DeclaringType}::{changedAPIList[i].ToString()}");
                        internalAPIList.Add(changedAPIList[i]);
                        changedAPIList.Remove(changedAPIList[i]);
                    }
                }
                ABITestResult result = ABITestResult.None;
                if (changedAPIList.Count > 0)
                {
                    result |= ABITestResult.ACRRequired;
                }
                if (internalAPIList.Count > 0)
                {
                    result |= ABITestResult.InternalAPIChanged;
                }

                Console.WriteLine($"{_basePath} : {((result & ABITestResult.ACRRequired) == ABITestResult.ACRRequired ? "FAIL" : "PASS")}");
                return result;
            }
        }

        ABITestResult CheckDirectory()
        {
            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(_basePath);
            DirectoryInfo targetDirectoryInfo = new DirectoryInfo(_targetPath);

            if (!baseDirectoryInfo.Exists || !targetDirectoryInfo.Exists)
            {
                Console.WriteLine($"invalid directory path");
            }

            FileInfo[] baseDllFiles = baseDirectoryInfo.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
            FileInfo[] targetDllFiles = targetDirectoryInfo.GetFiles("*.dll", SearchOption.TopDirectoryOnly);

            Console.WriteLine($"File Count : {baseDllFiles.Length} == {targetDllFiles.Length}");

            int num = 1;
            ABITestResult directoryResult = ABITestResult.None;

            foreach (var baseFile in baseDllFiles)
            {
                foreach (var targetFile in targetDllFiles)
                {
                    if (baseFile.Name == targetFile.Name)
                    {
                        var fileResult = ABITestResult.None;
                        try
                        {
                            var changedAPIList = _checker.CheckAssemblyFile(Assembly.LoadFrom(baseFile.FullName), Assembly.LoadFile(targetFile.FullName));
                            var internalAPIList = new List<MemberInfo>();
                            for (int i = changedAPIList.Count - 1; i >= 0; i--)
                            {
                                if (changedAPIList[i].GetCustomAttribute<System.ComponentModel.EditorBrowsableAttribute>()?.State == System.ComponentModel.EditorBrowsableState.Never)
                                {
                                    Console.WriteLine($"  Internal API changed: {changedAPIList[i].DeclaringType}::{changedAPIList[i].ToString()}");
                                    internalAPIList.Add(changedAPIList[i]);
                                    changedAPIList.Remove(changedAPIList[i]);
                                }
                            }

                            if (changedAPIList.Count > 0)
                            {
                                fileResult |= ABITestResult.ACRRequired;
                            }
                            if (internalAPIList.Count > 0)
                            {
                                fileResult |= ABITestResult.InternalAPIChanged;
                            }
                            directoryResult |= fileResult;
                            Console.WriteLine($"{num++}. {baseFile.ToString()} : {((fileResult & ABITestResult.ACRRequired) == ABITestResult.ACRRequired ? "FAIL" : "PASS")}");

                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            return directoryResult;
        }
    }
}
