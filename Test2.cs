using NUnit.Framework;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using FlaUI.Core;


namespace TestProject1
{
    [TestFixture]
    class ShowPassword
    { 
        [Test]
        public void VerifyUserCanShowPassword ()
        {
            var application = FlaUI.Core.Application.Launch(AppInfo.path);
            var automation = new UIA3Automation();
            var mainWindow = application.GetMainWindow(automation);
            ConditionFactory conditionFactory = new ConditionFactory(new UIA3PropertyLibrary());
            string expectedPassword = "Tester@1";

            mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("pswdTxt")).AsTextBox().Enter(expectedPassword);
            mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("checkBox1")).AsCheckBox().Click();
            string actualdPassword = mainWindow.FindFirstDescendant(conditionFactory.ByAutomationId("pswdTxt")).AsTextBox().Text;
            Assert.AreEqual(expectedPassword,actualdPassword,"Unexpected value");
            application.Close();
        }
    }
}
