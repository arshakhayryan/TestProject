using NUnit.Framework;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using FlaUI.Core;
using FlaUI.Core.Input;

namespace TestProject1
{
    [TestFixture]
    
    class ShowPassword
    {
        private Application application;
        private UIA3Automation automation = new UIA3Automation();
        private Window mainWindow;
        private ConditionFactory conditionFactory = new ConditionFactory(new UIA3PropertyLibrary());
        private const string EXPECTED_PASSWORD = "Tester@1";

        [OneTimeSetUp]
        public void RunApplication()
        {
            application = Application.Launch(AppInfo.path);
            mainWindow = application.GetMainWindow(automation);
        }

        [Test]
        public void VerifyUserCanShowPassword()
        {
            mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("pswdTxt")).AsTextBox().Enter(EXPECTED_PASSWORD);
            mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("checkBox1")).AsCheckBox().Click();
            Wait.UntilInputIsProcessed(waitTimeout : TimeSpan.FromMilliseconds(3000));
            mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("pswdTxt")).AsButton().Click();
            Wait.UntilInputIsProcessed(waitTimeout: TimeSpan.FromMilliseconds(3000));
            string actualdPassword = mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("pswdTxt")).AsTextBox().Text;
            Assert.AreEqual(EXPECTED_PASSWORD, actualdPassword, "Unexpected value");
        }

        [OneTimeTearDown]
        public void CloseApplication()
        {
            application.Close();
        }
    }
}
