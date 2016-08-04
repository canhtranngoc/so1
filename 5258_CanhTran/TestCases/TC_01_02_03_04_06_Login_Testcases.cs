using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sele_5258_CanhTran.Common;
using Sele_5258_CanhTran.PageObjects;
using Sele_5258_CanhTran.TestCases;


namespace Sele_5258_CanhTran
{
    [TestClass]
    public class TC_01_02_03_04_06_Login_Testcases
    {
        [TestMethod]
        public void TC01_User_can_log_into_Railway_with_valid_username_and_password()
        {
            // 1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            // 2. Click on "Login" tab
            LoginPage loginPage = homePage.GotoLoginPage();

            // 3. Enter valid Email and Password
            // 4. Click on "Login" button
            loginPage.Login(Constant.ValidUsername, Constant.ValidPassword);

            // VP. User is logged into Railway, Welcome user message is displayed
            CommonFunctions.CheckTextDisplays(Constant.WelcomeMessage, loginPage.GetWelcomeUserMessage());
        }

        [TestMethod]
        public void TC02_User_cannot_login_with_blank_username_textbox()
        {
            // 1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            // 2. Click on "Login" tab
            LoginPage loginPage = homePage.GotoLoginPage();

            // 3. User doesn't type any words into "Username" textbox but enter valid information into "Password" textbox
            // 4. Click on "Login" button
            loginPage.Login(Constant.BlankUsername, Constant.ValidPassword);

            // VP. User can't login and message "There was a problem with your login and/or errors exits in your forms." appears.
            CommonFunctions.CheckTextDisplays(Constant.ErrorLoginMsgBlankUsername, loginPage.GetErrorLoginMessage());
        }

        [TestMethod]
        public void TC03_User_cannot_log_into_Railway_with_invalid_password()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            // 2. Click on "Login" tab
            LoginPage loginPage = homePage.GotoLoginPage();

            // 3. Enter valid Email and invalid Password
            // 4. Click on "Login" button
            loginPage.Login(Constant.ValidUsername, Constant.InvalidPassword);

            // VP. Error message "There was a problem with your login and/or errors exits in your form." is displayed
            CommonFunctions.CheckTextDisplays(Constant.ErrorLoginMsgInvalidPassword, loginPage.GetErrorLoginMessage());
        }

        [TestMethod]
        public void TC04_System_show_message_when_user_enter_wrong_password_several_time()
        {
            // 1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            // 2. Click on "Login" tab
            LoginPage loginPage = homePage.GotoLoginPage();

            // 3. Login ServeralTime with ValidUsername and InvalidPassword
            loginPage.LoginInvalidServeralTime(Constant.ValidUsername, Constant.InvalidPassword, Constant.ServeralTimeLogin);

            // VP. User can't login and message "You have used 4 out of 5 login attempts. After all 5 have been used, you will be unable to login for 15 minutes." appears
            CommonFunctions.CheckTextDisplays(Constant.ErrorLoginMsgForServerTime, loginPage.GetErrorLoginMessage());
        }

        [TestMethod]
        public void TC06_User_cannot_login_with_account_hasnot_been_activated()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Click on "Login" tab
            LoginPage loginPage = homePage.GotoLoginPage();

            //3. Enter username and password of account hasn't been activated.
            //4. Click on "Login" button
            loginPage.Login(Constant.RandomEmail, Constant.ValidPassword);

            //VP. User can't login and message "Invalid username or password. Please try again." appears.
            CommonFunctions.CheckTextDisplays(Constant.ErrorLoginMsgInactiveAccount, loginPage.GetErrorLoginMessage());
        }

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            switch (TestContext.TestName)
            {
                case "TC06_User_cannot_login_with_account_hasnot_been_activated":
                    GeneralTest.TestInitializeTc06();
                    break;
                default:
                    break;
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            switch (TestContext.TestName)
            {
                case "TC01_User_can_log_into_Railway_with_valid_username_and_password":
                    new HomePage().LogOut();
                    break;
                default:
                    new HomePage().LogOut();
                    break;
            }
        }
    }
}
