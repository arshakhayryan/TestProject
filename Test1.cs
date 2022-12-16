using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using FlaUI.Core;

namespace TestProject1
{
    [TestFixture]
    class ShowUsername
    {
        private Application application;
        private UIA3Automation automation = new UIA3Automation();
        private Window mainWindow;
        private ConditionFactory conditionFactory = new ConditionFactory(new UIA3PropertyLibrary());
        private const string  EXPECTED_VALUE = "Tester";

        [OneTimeSetUp]
        public void RunApplication()
        {
            application = Application.Launch(AppInfo.path);
        }

        [Test]
        public void VerifyUserCanTypeInUsernamefield()
        {
            mainWindow = application.GetMainWindow(automation);
            mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("usernameTxt")).AsTextBox().Enter(EXPECTED_VALUE);
            string actualdValue = mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("usernameTxt")).AsTextBox().Text;
            Assert.AreEqual(EXPECTED_VALUE, actualdValue, "Unexpected value");
        }

        [OneTimeTearDown]
        public void CloseApplication()
        {
            application.Close();
        }
    }
}
