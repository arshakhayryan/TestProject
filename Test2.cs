using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;

namespace TestProject1
{
    [TestFixture]
    [Suite(Suite.Smoke)]
    class Case2 : BaseTest
    {
        private const string EXPECTED_PASSWORD = "Tester@1";

        [Test]
        public void VerifyUserCanShowPassword()
        {
            mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("pswdTxt")).AsTextBox().Enter(EXPECTED_PASSWORD);
            mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("checkBox1")).AsCheckBox().Click();
            Wait.UntilInputIsProcessed(waitTimeout : TimeSpan.FromMilliseconds(3000));
            mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("pswdTxt")).AsButton().Click();
            Wait.UntilInputIsProcessed(waitTimeout: TimeSpan.FromMilliseconds(3000));
            string actualdPassword = mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("pswdTxt")).AsTextBox().Text;
            Assert.That(actualdPassword, Is.EqualTo(EXPECTED_PASSWORD));
        }
    }
}
