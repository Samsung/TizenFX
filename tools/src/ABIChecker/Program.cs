using CommandLine;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Checker_ABI
{
    class AssemblyOptions
    {
        [Option('f', "isFile", Default = false, HelpText = "Is it File?")]
        public bool IsFile { get; set; }

        [Option('b', "base", Required = true, HelpText = "Input Base Assembly path")]
        public string BasePath { get; set; }

        [Option('p', "pr", Required = true, HelpText = "Input latest Assembly path")]
        public string PrPath { get; set; }
    }

    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static int Main(string[] args)
        {
            Console.WriteLine("=========ABI CHECK START=========");

            AssemblyOptions options = null;
            CommandLine.Parser.Default.ParseArguments<AssemblyOptions>(args).WithParsed(b => options = b);

            if (options == null)
            {
                Console.WriteLine($"invalid Arguments");
                return 0;
            }

            var abiChecker = new ABIChecker(options.BasePath, options.PrPath, options.IsFile);
            var result = abiChecker.CheckABI();
            Console.WriteLine("=====================");
            Console.WriteLine($"ABI CHECK : {((result & ABIChecker.ABITestResult.ACRRequired) == ABIChecker.ABITestResult.ACRRequired ? "Fail" : "Pass")}");
            Console.WriteLine("=====================");

            Console.WriteLine("=========ABI CHECK END=========");
            Console.WriteLine("Return : " + (int)result);

            return (int)result;
        }

        public static void LabelingTest()
        {
            WebRequest request = WebRequest.Create("https://api.github.com/repos/darkleem/google-diff-match-patch/issues/111/labels");
            request.Method = "POST";
            request.Headers.Add(HttpRequestHeader.UserAgent, "google-diff-match-patch");
            request.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            request.Headers.Add(HttpRequestHeader.Authorization, "token 3a37a027156bca0e561ae7a317d29fd249502899");


            var postData = @"[""bug""]";
            var data = Encoding.ASCII.GetBytes(postData);

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Console.WriteLine(responseString);
        }
    }
}
