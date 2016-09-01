using System;
using ElmSharp;

namespace ElmSharp.Test
{
    public abstract class TestCaseBase
    {
        public abstract string TestName { get; }
        public abstract string TestDescription { get; }
        public abstract void Run(Window window);
    }
}
