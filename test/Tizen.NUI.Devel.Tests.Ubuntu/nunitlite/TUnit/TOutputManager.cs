// ****************************************************************************************************
// Namespace:       NUnitLite.TUnit
// Class:           TOutputManager
// Description:     Tizen Output Manager
// Author:          Nguyen Truong Duong <duong.nt1@samsung.com>
// Notes:          
// Revision History:
// Name:           Date:        Description:
// ****************************************************************************************************
#define PORTABLE
#define TIZEN
#define NUNIT_FRAMEWORK
#define NUNITLITE
#define NET_4_5
#define PARALLEL
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Common;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.TUnit;

namespace NUnitLite.TUnit
{
    /// <summary>
    /// TOutputManager is responsible for creating output files
    /// from a test run in various formats.
    /// </summary>
    public class TOutputManager
    {
        private string _workDirectory;

        /// <summary>
        /// Construct an TOutputManager
        /// </summary>
        /// <param name="workDirectory">The directory to use for reports</param>
        public TOutputManager(string workDirectory)
        {
            _workDirectory = workDirectory;
        }

        /// <summary>
        /// Write the result of a test run according to a spec.
        /// </summary>
        /// <param name="result">The test result</param>
        /// <param name="spec">An output specification</param>
        /// <param name="runSettings">Settings</param>
        /// <param name="filter">Filter</param>
        public void WriteResultFile(ITestResult result, OutputSpecification spec, IDictionary<string, object> runSettings, TestFilter filter)
        {
            //string outputPath = Path.Combine(_workDirectory, spec.OutputPath);
            // [DuongNT][BEGIN]: Get configured file path output
            // Write results log
            ResultSummary summary = new ResultSummary(result);
            int totalTCT = summary.TestCount;
            int passedTCT = summary.PassCount;
            int failedTCT = summary.FailedCount;
            int blockTCT = totalTCT - passedTCT - failedTCT;
            TLogger.Write("");
            TLogger.Write("#####Summary#####");
            TLogger.Write("##### Total #####");
            TLogger.Write("#####   " + totalTCT + "   #####");
            TLogger.Write("##### PASS #####");
            TLogger.Write("#####   " + passedTCT + "   #####");
            TLogger.Write("##### FAIL #####");
            TLogger.Write("#####   " + failedTCT + "   #####");
            TLogger.Write("##### BLOCK #####");
            TLogger.Write("#####   " + blockTCT + "   #####");
            TLogger.Write("##### Details #####");
            TLogger.Write("");

            string outputPath = TSettings.GetInstance().GetOutputFilePathName();
            if (outputPath == "")
                outputPath = Path.Combine(_workDirectory, spec.OutputPath);
            TLogger.Write("Completed test-suite's execution!");
            TLogger.Write("Writing results to: " + outputPath + "...");
            // [DuongNT][END]: Get configured file path output

            OutputWriter outputWriter = null;

            switch (spec.Format)
            {
                case "nunit3":
                    outputWriter = new NUnit3XmlOutputWriter();
                    break;

                case "nunit2":
                    outputWriter = new NUnit2XmlOutputWriter();
                    break;

                //case "user":
                //    Uri uri = new Uri(Assembly.GetExecutingAssembly().CodeBase);
                //    string dir = Path.GetDirectoryName(uri.LocalPath);
                //    outputWriter = new XmlTransformOutputWriter(Path.Combine(dir, spec.Transform));
                //    break;

                default:
                    throw new ArgumentException(
                        string.Format("Invalid XML output format '{0}'", spec.Format),
                        "spec");
            }

            outputWriter.WriteResultFile(result, outputPath, runSettings, filter);
            TLogger.Write("Results saved to: " + outputPath);
        }

        /// <summary>
        /// Write out the result of exploring the tests
        /// </summary>
        /// <param name="test">The top-level test</param>
        /// <param name="spec">An OutputSpecification</param>
        public void WriteTestFile(ITest test, OutputSpecification spec)
        {
            string outputPath = Path.Combine(_workDirectory, spec.OutputPath);
            OutputWriter outputWriter = null;

            switch (spec.Format)
            {
                case "nunit3":
                    outputWriter = new NUnit3XmlOutputWriter();
                    break;

                case "cases":
                    outputWriter = new TestCaseOutputWriter();
                    break;

                //case "user":
                //    Uri uri = new Uri(Assembly.GetExecutingAssembly().CodeBase);
                //    string dir = Path.GetDirectoryName(uri.LocalPath);
                //    outputWriter = new XmlTransformOutputWriter(Path.Combine(dir, spec.Transform));
                //    break;

                default:
                    throw new ArgumentException(
                        string.Format("Invalid XML output format '{0}'", spec.Format),
                        "spec");
            }

            outputWriter.WriteTestFile(test, outputPath);
            Console.WriteLine("Tests ({0}) saved as {1}", spec.Format, outputPath);
        }
    }
}
