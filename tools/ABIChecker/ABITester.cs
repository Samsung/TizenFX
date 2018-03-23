using System;
using System.IO;
using System.Reflection;

namespace Checker_ABI
{
    public class ABITester
    {
        AssemblyChecker _checker = new AssemblyChecker();
        string _basePath;
        string _latestPath;
        bool _isFile;

        public ABITester(string basePath, string latestPath, bool isFile)
        {
            _basePath = basePath;
            _latestPath = latestPath;
            _isFile = isFile;
        }

        public bool CheckABI()
        {
            if (!_isFile)
            {
                return InternalDirectoryCheck();
            }
            else
            {
                var result = _checker.CheckAssemblyToList(Assembly.LoadFrom(_basePath), Assembly.LoadFile(_latestPath));
                var bResult = result.Count > 0 ? false : true;
                Console.WriteLine($"{_basePath} : {(bResult ? "PASS" : "FAIL")}");
                return bResult;
            }
        }

        bool InternalDirectoryCheck()
        {
            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(_basePath);
            DirectoryInfo targetDirectoryInfo = new DirectoryInfo(_latestPath);

            if (!baseDirectoryInfo.Exists || !targetDirectoryInfo.Exists)
            {
                Console.WriteLine($"invalid directory path");
            }

            FileInfo[] baseDllFiles = baseDirectoryInfo.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
            FileInfo[] targetDllFiles = targetDirectoryInfo.GetFiles("*.dll", SearchOption.TopDirectoryOnly);

            Console.WriteLine($"File Count : {baseDllFiles.Length} == {targetDllFiles.Length}");

            int num = 1;
            int errCount = 0;

            foreach (var baseFile in baseDllFiles)
            {
                foreach (var latestFile in targetDllFiles)
                {
                    if (baseFile.Name == latestFile.Name)
                    {
                        try
                        {
                            var result = _checker.CheckAssemblyToList(Assembly.LoadFrom(baseFile.FullName), Assembly.LoadFile(latestFile.FullName));
                            bool bResult = result.Count > 0 ? false : true;
                            Console.WriteLine($"{num++}. {baseFile.ToString()} : {(bResult ? "PASS" : "FAIL")}");

                            if (!bResult) errCount++;
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            return errCount > 0 ? false : true;
        }
    }
}
