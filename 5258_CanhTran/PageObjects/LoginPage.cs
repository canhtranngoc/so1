using OpenQA.Selenium;
using Sele_5258_CanhTran.Common;

namespace Sele_5258_CanhTran.PageObjects
{
    public class LoginPage : GeneralPage
    {
        #region Locator
        private readonly By _txtUserName = By.Id("username");
        private readonly By _txtPassWord = By.Id("password");
        private readonly By _btnLogin = By.XPath("//input[@value='login']");
        private readonly By _lblErrorLoginMessage = By.XPath("//div//p[@class='message error LoginForm']");
        #endregion

        #region Elements
        public IWebElement TxtUsername
        {
            get { return Constant.Webdriver.FindElement(_txtUserName); }
        }
        public IWebElement TxtPassword
        {
            get { return Constant.Webdriver.FindElement(_txtPassWord); }
        }

        public IWebElement BtnLogin
        {
            get { return Constant.Webdriver.FindElement(_btnLogin); }
        }

        public IWebElement LblErrorLoginMessage
        {
            get { return Constant.Webdriver.FindElement(_lblErrorLoginMessage); }
        }
        #endregion

        #region Method
        public string GetErrorLoginMessage()
        {
            return CommonFunctions.GetText(LblErrorLoginMessage);
        }

        public void Login(string username, string password)
        {
            TxtUsername.Clear();
            TxtUsername.SendKeys(username);

            TxtPassword.Clear();
            TxtPassword.SendKeys(password);

            BtnLogin.Click();
        }

        public void LoginInvalidServeralTime(string username, string password, int time)
        {
            for (int i = 0; i < time; i++)
            {
                TxtUsername.Clear();
                TxtUsername.SendKeys(username);

                TxtPassword.Clear();
                TxtPassword.SendKeys(password);

                BtnLogin.Click();
            }
        }
        #endregion
    }
}
