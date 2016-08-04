using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sele_5258_CanhTran.Common;
using Sele_5258_CanhTran.PageObjects;

namespace Sele_5258_CanhTran.TestCases
{
    [TestClass]
    public class TC_14_Cancel_Ticket
    {
        [TestMethod]
        public void TC14_User_can_cancel_a_ticket()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Login with a valid account
            LoginPage loginPage = homePage.GotoLoginPage();
            loginPage.Login(Constant.ValidUsername, Constant.ValidPassword);

            //3. Book a ticket
            BookTicketPage bookTicketPage = homePage.GotoBookTicketPage();
            bookTicketPage.BookTicket(Constant.DepartDate, Constant.DepartStation, Constant.ArriveStation, Constant.SeatType, Constant.TicketAmount);

            //4. Click on "My ticket" tab
            MyTicketPage myTicketPage = bookTicketPage.GotoMyTicketPage();


            //5. Click on "Cancel" button of ticket which user want to cancel.
            //6. Click on "OK" button
            myTicketPage.CancelOneTicket(Constant.DepartStation, Constant.ArriveStation, Constant.DepartDate);

            //VP. Confirmation message "Are you sure?" appears.
            CommonFunctions.CheckTextDisplays(Constant.ConfirmCancelTicketMessage, myTicketPage.confirmCancelTicketMessage);

            //VP. The canceled ticket is disappeared.
            myTicketPage.CheckCancelTicket();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            GeneralTest.TestInitializeBookTicketTestcases();
        }

        [TestCleanup]
        public void Cleanup()
        {
            new HomePage().LogOut();
        }

    }
}
