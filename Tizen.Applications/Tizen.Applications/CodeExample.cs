using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    public class ViewActor : Actor
    {
        public string Type { get; set; }
        protected override void OnCreated()
        {
            Console.WriteLine();
        }

        protected override void OnStarted()
        {
        }

        private void DoSomething()
        {
        }
    }

    [AppControlFilter("http://tizen.org/appcontrol/operation/default")]
    public class DefaultActor : Actor
    {
        protected override void OnCreated()
        {
        }

        protected override void OnStarted()
        {
        }
    }

    public class Test
    {
        static void test(string[] args) // main
        {
            Application.Created += Application_Create;
            Application.Exited += Application_Terminate;
            Application.RegisterActor(typeof(DefaultActor));
            Application.RegisterActor(typeof(ViewActor), new AppControlFilter[] {
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
