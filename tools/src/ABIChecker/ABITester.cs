using System;
using System.Collections.Generic;
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
                var result = CheckFile(_basePath, _targetPath);
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
            directoryResult |= CheckChagedModule(baseDllFiles, targetDllFiles);
            Console.WriteLine($"Module Check : {directoryResult.ToString()}");
            Console.WriteLine("---------------------------------");

            int count = 1;
            foreach (var baseFile in baseDllFiles)
            {
                foreach (var targetFile in targetDllFiles)
                {
                    if (baseFile.Name == targetFile.Name)
                    {
                        try
                        {
                            var fileResult = CheckFile(baseFile.FullName, targetFile.FullName);
                            Console.WriteLine($"{count++}. {baseFile.ToString()} : {((fileResult & ABITestResult.ACRRequired) == ABITestResult.ACRRequired ? "FAIL" : "PASS")}");
                            directoryResult |= fileResult;
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

        ABITestResult CheckChagedModule(FileInfo[] baseDllFiles, FileInfo[] targetDllFiles)
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

        ABITestResult CheckFile(string baseFile, string targetFile)
        {
            var changedAPIList = _checker.CheckAssemblyFile(Assembly.LoadFile(baseFile), Assembly.LoadFile(targetFile));
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

            return result;
        }

        ABITestResult CheckFile(string file)
        {
            ABITestResult result = ABITestResult.None;
            try
            {
                var changedAPIList = _checker.CheckAssemblyFile(Assembly.LoadFile(file));
                var internalAPIList = new List<MemberInfo>();
                for (int i = changedAPIList.Count - 1; i >= 0; i--)
                {
                    if (changedAPIList[i].GetCustomAttribute<System.ComponentModel.EditorBrowsableAttribute>()?.State == System.ComponentModel.EditorBrowsableState.Never)
                    {
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
