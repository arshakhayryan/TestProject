using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;

namespace TestProject1
{
     class BaseTest
    {
        public Application application;
        public UIA3Automation automation = new UIA3Automation();
        public Window mainWindow;
        public ConditionFactory conditionFactory = new ConditionFactory(new UIA3PropertyLibrary());

        [OneTimeSetUp]
        public void RunApplication()
        {
            application = Application.Launch(AppInfo.path);
        }

        [OneTimeTearDown]
        public void CloseApplication()
        {
            application.Close();
        }
    }
}
