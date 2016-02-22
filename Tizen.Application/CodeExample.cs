using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Application
{
    public class ViewActor : Actor
    {
        public string Type { get; set; }
        protected override void OnCreate()
        {
            Console.WriteLine();
        }

        protected override void OnStart()
        {
        }

        private void DoSomething()
        {
        }
    }

    [AppControlFilter("http://tizen.org/appcontrol/operation/default")]
    public class DefaultActor : Actor
    {
        protected override void OnCreate()
        {
        }

        protected override void OnStart()
        {
        }
    }

    public class Test
    {
        static void test(string[] args) // main
        {
            Application.ApplicationInit += Application_Create;
            Application.ApplicationExit += Application_Terminate;
            Application.AddActor(typeof(DefaultActor));
            Application.AddActor(typeof(ViewActor), new AppControlFilter[] {
                new AppControlFilter("http://tizen.org/appcontrol/view", "image/*"),
                new AppControlFilter("http://tizen.org/appcontrol/view", "text/*")
            });

            Application.Run(args);
        }

        private static void Application_Create(object sender, EventArgs e)
        {
            Console.WriteLine("Hello Application!");
        }

        private static void Application_Terminate(object sender, EventArgs e)
        {
            Console.WriteLine("Goodbye Application!");
        }
    }


}
