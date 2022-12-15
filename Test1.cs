using NUnit.Framework;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using FlaUI.Core.Input;

namespace TestProject1
{
    [TestFixture]
    class ShowUsername
    {
        [Test]
        public void VerifyUserCanTypeInUsernamefield()
        {
            var application = FlaUI.Core.Application.Launch(AppInfo.path);
            var automation = new UIA3Automation();
            var mainWindow = application.GetMainWindow(automation);
            ConditionFactory conditionFactory = new ConditionFactory(new UIA3PropertyLibrary());
            string expectedValue = "Tester";

            mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("usernameTxt")).AsTextBox().Enter(expectedValue);
            string actualdValue = mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("usernameTxt")).AsTextBox().Text;
            Assert.AreEqual(expectedValue, actualdValue, "Unexpected value");
            
        }
    }
}
