using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class TestAttributes : PropertyAttribute
    {
        public TestAttributes(Suite suite) : base(suite.ToString()) { }
    }

    public enum Suite
    {
        Smoke
    }

}
