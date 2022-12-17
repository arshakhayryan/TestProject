using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using FlaUI.Core;
using FlaUI.Core.Input;

namespace TestProject1
{
    [TestFixture]
    [TestAttributes(Suite.Smoke)]
    class Case1 : BaseTest
    {
        private const string  EXPECTED_VALUE = "Tester";

        [Test]
        public void VerifyUserCanTypeInUsernamefield()
        {
            mainWindow = application.GetMainWindow(automation);
            mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("usernameTxt")).AsTextBox().Enter(EXPECTED_VALUE);
            Wait.UntilInputIsProcessed(waitTimeout: TimeSpan.FromMilliseconds(3000));
            string actualdValue = mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("usernameTxt")).AsTextBox().Text;
            Assert.AreEqual(EXPECTED_VALUE, actualdValue, "Unexpected value");
        }
    }
}
