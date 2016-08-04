using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sele_5258_CanhTran.Common;
using Sele_5258_CanhTran.PageObjects;

namespace Sele_5258_CanhTran.TestCases
{
    [TestClass]
    public class TC_15_16_17_Filter_Ticket
    {
        private string departDate = Constant.DepartDate;
        private string departStation = "Nha Trang";
        private string status = "Paid";
        private int numberOfTicket = 7;

        [TestMethod]
        public void TC15_User_can_filter_manager_ticket_table_with_depart_station()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Login with a valid account
            LoginPage loginPage = homePage.GotoLoginPage();
            loginPage.Login(Constant.ValidUsername, Constant.ValidPassword);

            //3. Book more than 6 tickets with different Depart Stations
            BookTicketPage bookTicketPage = homePage.GotoBookTicketPage();
            bookTicketPage.BookSixTicketsWithDifferenceDepartStation();

            //4. Click on "My ticket" tab
            MyTicketPage myTicketPage = bookTicketPage.GotoMyTicketPage();

            //5. Input one of booked Depart Station in "Depart Station" textbox
            //6. Click "Apply fiter" button
            myTicketPage.FilterTictketWithDepartStation(departStation);

            //VP. "Manage ticket" table shows correct tickets
            myTicketPage.CheckTicketWithDepartStation(departStation);

        }

        [TestMethod]
        public void TC16_User_can_filter_manager_ticket_table_with_depart_dates()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Login with a valid account
            LoginPage loginPage = homePage.GotoLoginPage();
            loginPage.Login(Constant.ValidUsername, Constant.ValidPassword);

            //3. Go to Book ticket page then Book more than 6 tickets with different Depart Dates
            BookTicketPage bookTicketPage = homePage.GotoBookTicketPage();
            bookTicketPage.BookManyTicketWithDifferenceDepartDate(numberOfTicket);

            //4. Click on "My ticket" tab
            MyTicketPage myTicketPage = bookTicketPage.GotoMyTicketPage();

            //5. Input one of booked Depart Date in "Depart Date" textbox
            //6. Click "Apply fiter" button
            myTicketPage.FilterTictketWithDepartDate(departDate);

            //VP. "Manage ticket" table shows correct tickets
            myTicketPage.CheckTicketWithDepartDate(departDate);
        }

        [TestMethod]
        public void
            TC17_User_cannot_filter_manage_ticket_table_when_choosing_value_of_status_doesnot_exits_in_manage_ticket_table()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Login with a valid account
            LoginPage loginPage = homePage.GotoLoginPage();
            loginPage.Login(Constant.ValidUsername, Constant.ValidPassword);

            //3. Go to Book ticket page then Book more than 6 tickets with different Depart Dates
            BookTicketPage bookTicketPage = homePage.GotoBookTicketPage();
            bookTicketPage.BookManyTicketWithDifferenceDepartDate(numberOfTicket);

            //4. Click on "My ticket" tab
            MyTicketPage myTicketPage = bookTicketPage.GotoMyTicketPage();

            //5. Select "Paid" for "Status"
            //6. Click "Apply filter" button
            myTicketPage.FilterTicketWithStatus(status);

            //VP. "Manage ticket" table shows message "Sorry, can't find any results that match your filters. Please change the filters and try again."
            CommonFunctions.CheckTextDisplays(Constant.ErrorFilterMessage, myTicketPage.GetErrorFilterMessage());
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
