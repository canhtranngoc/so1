using OpenQA.Selenium;
using Sele_5258_CanhTran.Common;


namespace Sele_5258_CanhTran.PageObjects
{
    public class ChangePasswordPage : GeneralPage
    {
        #region Locator
        private readonly By _txtCurrentPassword = By.Id("currentPassword");
        private readonly By _txtNewPassword = By.Id("newPassword");
        private readonly By _txtConfirmPassword = By.Id("confirmPassword");
        private readonly By _btnChangePassword = By.XPath("//input[@value='Change Password']");
        private readonly By _lblChangePasswordSuccessMessage = By.XPath("//div//p[@class='message success']");
        private readonly By _lblErrorDifferentNewAndConfirmPasswordMessage = By.XPath("//li[@class='confirm-password']/label[@class='validation-error']");
        #endregion

        #region Elements
        public IWebElement TxtCurrentPassword
        {
            get { return Constant.Webdriver.FindElement(_txtCurrentPassword); }
        }

        public IWebElement TxtNewPassword
        {
            get { return Constant.Webdriver.FindElement(_txtNewPassword); }
        }
        public IWebElement TxtConfirmPassword
        {
            get { return Constant.Webdriver.FindElement(_txtConfirmPassword); }
        }
        public IWebElement BtnChangePassword
        {
            get { return Constant.Webdriver.FindElement(_btnChangePassword); }
        }

        public IWebElement LblChangePasswordSuccessMessage
        {
            get { return Constant.Webdriver.FindElement(_lblChangePasswordSuccessMessage); }
        }

        public IWebElement LblErrorDifferentNewAndConfirmPasswordMessage
        {
            get { return Constant.Webdriver.FindElement(_lblErrorDifferentNewAndConfirmPasswordMessage); }
        }

        #endregion

        #region Method

        public void ChangePassword(string currentpassword, string newpassword, string confirmpassword)
        {
            TxtCurrentPassword.Clear();
            TxtCurrentPassword.SendKeys(currentpassword);

            TxtNewPassword.Clear();
            TxtNewPassword.SendKeys(newpassword);

            TxtConfirmPassword.Clear();
            TxtConfirmPassword.SendKeys(confirmpassword);

            BtnChangePassword.Click();
        }

        public string GetChangePasswordSuccessMessage()
        {
            return CommonFunctions.GetText(LblChangePasswordSuccessMessage);
        }

        public string GetErrorDifferentNewAndConfirmPasswordMessage()
        {
            return CommonFunctions.GetText(LblErrorDifferentNewAndConfirmPasswordMessage);
        }
        #endregion
    }
}
