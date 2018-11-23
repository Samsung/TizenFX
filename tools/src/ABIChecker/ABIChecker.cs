using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
                var result = CheckFile(new FileInfo(_basePath).FullName, new FileInfo(_targetPath).FullName);
                Console.WriteLine($"File check result: {((result & ABITestResult.ACRRequired) == ABITestResult.ACRRequired ? "FAIL" : "PASS")}");
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

            ABITestResult directoryResult = ABITestResult.None;
            directoryResult |= CheckChangedModule(baseDllFiles, targetDllFiles);
            Console.WriteLine($"Module Check : {directoryResult.ToString()}");
            Console.WriteLine("---------------------------------");

            int count = 1;
            foreach (var baseFile in baseDllFiles)
            {
                foreach (var targetFile in targetDllFiles)
                {
                    if (baseFile.Name == targetFile.Name)
                    {
                        var fileResult = CheckFile(baseFile.FullName, targetFile.FullName);
                        Console.WriteLine($"{count++}. {baseFile.ToString()} : {((fileResult & ABITestResult.ACRRequired) == ABITestResult.ACRRequired ? "FAIL" : "PASS")}");
                        directoryResult |= fileResult;
                    }
                }
            }
            return directoryResult;
        }

        ABITestResult CheckChangedModule(FileInfo[] baseDllFiles, FileInfo[] targetDllFiles)
        {
            var result = ABITestResult.None;

            var removedDllFiles = baseDllFiles.Where(b => !targetDllFiles.Any(t => t.Name == b.Name));
            foreach (var file in removedDllFiles)
            {
                Console.WriteLine($"!! Missing DLL: {file.Name}");
                result |= CheckFile(file.FullName);
            }

            var addedDllFiles = targetDllFiles.Where(t => !baseDllFiles.Any(b => b.Name == t.Name));
            foreach (var file in addedDllFiles)
            {
                Console.WriteLine($"!! Added DLL : {file.Name}");
                result |= CheckFile(file.FullName);
            }

            return result;
        }

        ABITestResult CheckFile(string file)
        {
            return CheckFile(file, string.Empty);
        }

        ABITestResult CheckFile(string baseFile, string targetFile)
        {
            ABITestResult result = ABITestResult.None;
            IList<MemberInfo> changedAPIList;
            try
            {
                if (targetFile == string.Empty)
                {
                    changedAPIList = _checker.CheckAssemblyFile(Assembly.LoadFrom(baseFile));
                }
                else
                {
                    changedAPIList = _checker.CheckAssemblyFile(Assembly.LoadFrom(baseFile), Assembly.LoadFile(targetFile));
                }
                var internalAPIList = new List<MemberInfo>();
                for (int i = changedAPIList.Count - 1; i >= 0; i--)
                {
                    if (changedAPIList[i].GetCustomAttribute<EditorBrowsableAttribute>()?.State == EditorBrowsableState.Never
                        || changedAPIList[i].DeclaringType.GetCustomAttribute<EditorBrowsableAttribute>()?.State == EditorBrowsableState.Never)
                    {
                        Console.WriteLine($"  Internal API changed: {changedAPIList[i].DeclaringType}::{changedAPIList[i].ToString()}");
                        internalAPIList.Add(changedAPIList[i]);
                        changedAPIList.Remove(changedAPIList[i]);
                    }
                }

                if (changedAPIList.Count > 0)
                {
                    result |= ABITestResult.ACRRequired;
                }
                if (internalAPIList.Count > 0)
                {
                    result |= ABITestResult.InternalAPIChanged;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }
    }
}
