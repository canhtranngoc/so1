using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sele_5258_CanhTran.Common;
using Sele_5258_CanhTran.PageObjects;

namespace Sele_5258_CanhTran.TestCases
{
    [TestClass]
    public class TC_10_12_13_Book_Ticket
    {
        private string departStation1 = "Đà Nẵng";
        private string arriveStation1 = "Sài Gòn";

        private string departStation2 = "Sài Gòn";
        private string arriveStation2 = "Đà Nẵng";
        private string seatType2 = "Soft bed with air conditioner";

        [TestMethod]
        public void TC10_User_can_book_1_ticket_at_a_time()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Login with a valid account 
            LoginPage loginPage = homePage.GotoLoginPage();
            loginPage.Login(Constant.ValidUsername, Constant.ValidPassword);

            //3. Click on "Book ticket" tab
            BookTicketPage bookTicketPage = homePage.GotoBookTicketPage();

            //4. Select a "Depart date" from the list
            //5. Select "Sài Gòn" for "Depart from" and "Đà Nẵng" for "Arrive at".
            //6. Select "Soft bed with air conditioner" for "Seat type"
            //7. Select "1" for "Ticket amount"
            //8. Click on "Book ticket" button
            bookTicketPage.BookTicket(Constant.DepartDate, Constant.DepartStation, Constant.ArriveStation, Constant.SeatType, Constant.TicketAmount);

            //VP. Message "Ticket booked successfully!" displays
            CommonFunctions.CheckTextDisplays(Constant.TicketBookedSuccessfullyMessage, bookTicketPage.GetTicketBookedSuccessfullyMessage());

            //VP. Ticket information display correctly.
            bookTicketPage.CheckBookTicketValue(Constant.DepartDate, Constant.DepartStation, Constant.ArriveStation, Constant.SeatType, Constant.TicketAmount);
        }

        [TestMethod]
        public void TC12_User_can_open_book_ticket_page_by_clicking_on_book_ticket_link_in_train_timetable()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Login with a valid account 
            LoginPage loginPage = homePage.GotoLoginPage();
            loginPage.Login(Constant.ValidUsername, Constant.ValidPassword);

            //3. Click on "Timetable" tab
            TimeTablePage timeTablePage = homePage.GotoTimeTablePage();

            //4. Click on "Book ticket" link of the route from "Đà Nẵng" to "Sài Gòn"
            timeTablePage.BookTicketFromTimetable(departStation1, arriveStation1);

            //VP. "Book ticket" page is loaded with correct for  "Depart from" and "Arrive at" values.
            BookTicketPage bookTicketPage = new BookTicketPage();
            bookTicketPage.CheckSelectTicketInformation(departStation1,arriveStation1,"");
        }

        [TestMethod]
        public void TC13_User_can_open_book_ticket_page_by_click_on_book_ticket_link_in_ticket_price()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Login with a valid account 
            LoginPage loginPage = homePage.GotoLoginPage();
            loginPage.Login(Constant.ValidUsername, Constant.ValidPassword);

            //3. Click on "Ticket price" tab
            TicketPricePage ticketPricePage = homePage.GotoTicketPricePage();

            //4. Click on "Check price" link of ticket from "Sài Gòn" to "Đà Nẵng"
            //5. Click on "Book ticket" button of "Soft bed with air conditioner"
            ticketPricePage.BookTicketFromTicketPrice(departStation2, arriveStation2, seatType2);

            //VP. '"Book ticket" page is loaded with correct for "Depart from", "Arrive at", and "Seat type".
            BookTicketPage bookTicketPage = new BookTicketPage();
            bookTicketPage.CheckSelectTicketInformation(departStation2,arriveStation2,seatType2);
        }

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            switch (TestContext.TestName)
            {
                case "TC10_User_can_book_1_ticket_at_a_time":
                    GeneralTest.TestInitializeBookTicketTestcases();
                    break;
                default:
                    break;
            }
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            new HomePage().LogOut();
        }


    }
}
