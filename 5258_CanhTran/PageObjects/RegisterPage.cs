using OpenQA.Selenium;
using Sele_5258_CanhTran.Common;

namespace Sele_5258_CanhTran.PageObjects
{
    public class RegisterPage : GeneralPage
    {
        #region Locator
        private readonly By _txtEmail = By.Id("email");
        private readonly By _txtPassWord = By.Id("password");
        private readonly By _txtConfirmPassWord = By.Id("confirmPassword");
        private readonly By _txtPidPassortNumber = By.Id("pid");
        private readonly By _btnRegister = By.XPath("//input[@value='Register']");
        private readonly By _lblThanksTegisteringMessage = By.XPath("//div[@id='content']/h1");
        private readonly By _lblErrorConfirmPasswordMessage = By.XPath("//label[@class='validation-error' and @for='confirmPassword']");
        #endregion

        #region Elements
        public IWebElement TxtEmail
        {
            get { return Constant.Webdriver.FindElement(_txtEmail); }
        }

        public IWebElement TxtPassword
        {
            get { return Constant.Webdriver.FindElement(_txtPassWord); }
        }

        public IWebElement TxtConfirmPassword
        {
            get { return Constant.Webdriver.FindElement(_txtConfirmPassWord); }
        }

        public IWebElement TxtPidPassportNumber
        {
            get { return Constant.Webdriver.FindElement(_txtPidPassortNumber); }
        }

        public IWebElement BtnRegister
        {
            get { return Constant.Webdriver.FindElement(_btnRegister); }
        }

        public IWebElement LblThanksRegistingMessage
        {
            get { return Constant.Webdriver.FindElement(_lblThanksTegisteringMessage); }
        }

        public IWebElement LblErrorConfirmPasswordMessage
        {
            get { return Constant.Webdriver.FindElement(_lblErrorConfirmPasswordMessage); }
        }
        #endregion

        #region Method

        public void Register(string email, string password, string confirmpassword, string pid)
        {
            TxtEmail.Clear();
            TxtEmail.SendKeys(email);

            TxtPassword.Clear();
            TxtPassword.SendKeys(password);

            TxtConfirmPassword.Clear();
            TxtConfirmPassword.SendKeys(confirmpassword);

            TxtPidPassportNumber.Clear();
            TxtPidPassportNumber.SendKeys(pid);

            BtnRegister.Click();
        }

        public string GetThanksRegisteringMessage()
        {
            return CommonFunctions.GetText(LblThanksRegistingMessage);
        }

        public string GetErrorConfirmPasswordMessage()
        {
            return CommonFunctions.GetText(LblErrorConfirmPasswordMessage);
        }
        #endregion
    }
}
