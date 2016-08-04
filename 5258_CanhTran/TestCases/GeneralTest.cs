using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sele_5258_CanhTran.Common;
using Sele_5258_CanhTran.PageObjects;

namespace Sele_5258_CanhTran.TestCases
{
    [TestClass]
    public class GeneralTest : GeneralPage
    {
        [AssemblyInitialize]
        public static void ClassInitializeMethod(TestContext testContext)
        {
            CommonFunctions.OpenBrowser();
        }

        [AssemblyCleanup]
        public static void ClassCleanupMethod()
        {
            CommonFunctions.CloseBrowser();
        }

        public static void TestInitializeTc06()
        {
            // Create a account for TC06_User_cannot_login_with_account_hasnot_been_activated
            HomePage homePage = new HomePage();
            homePage.Open();

            RegisterPage registerPage = homePage.GotoRegisterPage();

            registerPage.Register(Constant.RandomEmail, Constant.ValidPassword, Constant.ValidPassword, Constant.ValidPid);

        }

        public static void TestInitializeBookTicketTestcases()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Login with a valid account
            LoginPage loginPage = homePage.GotoLoginPage();
            loginPage.Login(Constant.ValidUsername, Constant.ValidPassword);

            MyTicketPage myTicketPage = homePage.GotoMyTicketPage();

            if (CommonFunctions.IsElementPresent(myTicketPage._tblMyTicket) == true)
            {
                // On build 1.0.0, User can not delete ticket if number of row of ticket table less than 6. 
                if (myTicketPage.CountTicketTableRow() < 7)
                {
                    for (int i = 1; i < 7 - myTicketPage.CountTicketTableRow(); i++)
                    {
                        BookTicketPage bookTicketPage = myTicketPage.GotoBookTicketPage();
                        bookTicketPage.BookTicket(Constant.DepartDate, Constant.DepartStation, Constant.ArriveStation, Constant.SeatType, Constant.TicketAmount);
                    }
                }
            }

            myTicketPage.GotoMyTicketPage();
            myTicketPage.CancelAllTickets();
            myTicketPage.LogOut();
        }

        public static void TestCleanupTC07()
        {
            // Change to default Valid Password for other Testcase

            HomePage homePage = new HomePage();
            homePage.Open();

            ChangePasswordPage changePasswordPage = homePage.GotoChangePasswordPage();
            changePasswordPage.ChangePassword(Constant.NewPassword, Constant.ValidPassword, Constant.ValidPassword);
        }


        //public void chodoi()
        //{
        //    WebDriverWait wait = new WebDriverWait(Constant.Webdriver, TimeSpan.FromSeconds(30));
        //    wait.Until(ExpectedConditions.ElementToBeClickable([IWebElement]));
        //    wait.Until(ExpectedConditions.ElementExists())
        //}
    }
}

