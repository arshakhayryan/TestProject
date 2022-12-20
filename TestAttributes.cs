

namespace TestProject1
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class SuiteAttribute : PropertyAttribute
    {
        public SuiteAttribute(Suite suite) : base(suite.ToString()) { }
    }

    public enum Suite
    {
        Smoke,
        CriticalPath
    }

}
