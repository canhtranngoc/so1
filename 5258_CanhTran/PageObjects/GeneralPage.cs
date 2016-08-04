using OpenQA.Selenium;
using Sele_5258_CanhTran.Common;

namespace Sele_5258_CanhTran.PageObjects
{
    public class GeneralPage
    {
        #region Locators
        private readonly By _tabLogin = By.XPath("//div[@id='menu']//span[.='Login']");
        private readonly By _tabLogOut = By.XPath("//div[@id='menu']//span[.='Log out']");
        private readonly By _tabRegister = By.XPath("//div[@id='menu']//span[.='Register']");
        private readonly By _tabChangePassword = By.XPath("//div[@id='menu']//span[.='Change password']");
        private readonly By _tabBookTicket = By.XPath("//div[@id='menu']//span[.='Book ticket']");
        private readonly By _tabTimeTable = By.XPath("//div[@id='menu']//span[.='Timetable']");
        private readonly By _tabTicketPrice = By.XPath("//div[@id='menu']//span[.='Ticket price']");
        private readonly By _tabMyTicket = By.XPath("//div[@id='menu']//span[.='My ticket']");
        private readonly By _lblWelcomeUserMessage = By.XPath("//div[@id='header']/div[@class='account']");
        #endregion

        #region Elements

        public IWebElement TabLogin
        {
            get { return Constant.Webdriver.FindElement(_tabLogin); }
        }

        public IWebElement TabLogout
        {
            get { return Constant.Webdriver.FindElement(_tabLogOut); }
        }

        public IWebElement TabRegister
        {
            get { return Constant.Webdriver.FindElement(_tabRegister); }
        }

        public IWebElement TabChangePassword
        {
            get { return Constant.Webdriver.FindElement(_tabChangePassword); }
        }

        public IWebElement TabBookTicket
        {
            get { return Constant.Webdriver.FindElement(_tabBookTicket); }
        }

        public IWebElement TabTimeTable
        {
            get { return Constant.Webdriver.FindElement(_tabTimeTable); }
        }

        public IWebElement TabTicketPrice
        {
            get { return Constant.Webdriver.FindElement(_tabTicketPrice); }
        }

        public IWebElement TabMyTicket
        {
            get { return Constant.Webdriver.FindElement(_tabMyTicket); }
        }

        public IWebElement LblWelcomeUserMessage
        {
            get { return Constant.Webdriver.FindElement(_lblWelcomeUserMessage); }
        }

        #endregion

        #region Method
        public string GetWelcomeUserMessage()
        {
            return CommonFunctions.GetText(LblWelcomeUserMessage);
        }

        public LoginPage GotoLoginPage()
        {
            TabLogin.Click();
            return new LoginPage();
        }

        public RegisterPage GotoRegisterPage()
        {
            TabRegister.Click();
            return new RegisterPage();
        }

        public ChangePasswordPage GotoChangePasswordPage()
        {
            TabChangePassword.Click();
            return new ChangePasswordPage();
        }

        public BookTicketPage GotoBookTicketPage()
        {
            TabBookTicket.Click();
            return new BookTicketPage();
        }

        public TimeTablePage GotoTimeTablePage()
        {
            TabTimeTable.Click();
            return new TimeTablePage();
        }

        public TicketPricePage GotoTicketPricePage()
        {
            TabTicketPrice.Click();
            return new TicketPricePage();
        }

        public MyTicketPage GotoMyTicketPage()
        {
            TabMyTicket.Click();
            return new MyTicketPage();
        }

        public void LogOut()
        {

            if (CommonFunctions.IsElementPresent(_tabLogOut) == true)
            {
                TabLogout.Click();
            }
        }
        #endregion
    }
}
