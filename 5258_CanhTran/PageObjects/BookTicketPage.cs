using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sele_5258_CanhTran.Common;

namespace Sele_5258_CanhTran.PageObjects
{
    public class BookTicketPage : GeneralPage
    {
        #region Locator
        private readonly By _cboDepartDate = By.XPath("//select[@name='Date']");
        private readonly By _cboDepartStation = By.XPath("//select[@name='DepartStation']");
        private readonly By _cboArriveStation = By.XPath("//select[@name='ArriveStation']");
        private readonly By _cboSeatType = By.XPath("//select[@name='SeatType']");
        private readonly By _cboTicketAmount = By.XPath("//select[@name='TicketAmount']");
        private readonly By _btnBookTicket = By.XPath("//input[@type='submit' and @value='Book ticket']");
        private readonly By _lblTicketBookedSuccessfullyMessage = By.XPath("//div[@id='content']/h1");
        private readonly By _cellBookTicketDepartStation = By.XPath("//div[@id='content']//table[@class='MyTable WideTable']//tr[@class='OddRow']/td[1]");
        private readonly By _cellBookTicketArriveStation = By.XPath("//div[@id='content']//table[@class='MyTable WideTable']//tr[@class='OddRow']/td[2]");
        private readonly By _cellBookTicketSeatType = By.XPath("//div[@id='content']//table[@class='MyTable WideTable']//tr[@class='OddRow']/td[3]");
        private readonly By _cellBookTicketDepartDate = By.XPath("//div[@id='content']//table[@class='MyTable WideTable']//tr[@class='OddRow']/td[4]");
        private readonly By _cellBookTicketAmount = By.XPath("//div[@id='content']//table[@class='MyTable WideTable']//tr[@class='OddRow']/td[7]");
        #endregion

        #region Elements
        public IWebElement CboDepartDate
        {
            get { return Constant.Webdriver.FindElement(_cboDepartDate); }
        }

        public IWebElement CboDepartStation
        {
            get { return Constant.Webdriver.FindElement(_cboDepartStation); }
        }

        public IWebElement CboArriveStation
        {
            get { return Constant.Webdriver.FindElement(_cboArriveStation); }
        }

        public IWebElement CboSeatType
        {
            get { return Constant.Webdriver.FindElement(_cboSeatType); }
        }

        public IWebElement CboTicketAmount
        {
            get { return Constant.Webdriver.FindElement(_cboTicketAmount); }
        }

        public IWebElement BtnBookTicket
        {
            get { return Constant.Webdriver.FindElement(_btnBookTicket); }
        }

        public IWebElement LblTicketBookedSuccessfullyMessage
        {
            get { return Constant.Webdriver.FindElement(_lblTicketBookedSuccessfullyMessage); }
        }
        public IWebElement CellBookTicketDepartStation
        {
            get { return Constant.Webdriver.FindElement(_cellBookTicketDepartStation); }
        }

        public IWebElement CellBookTicketArriveStation
        {
            get { return Constant.Webdriver.FindElement(_cellBookTicketArriveStation); }
        }

        public IWebElement CellBookTicketSeatType
        {
            get { return Constant.Webdriver.FindElement(_cellBookTicketSeatType); }
        }

        public IWebElement CellBookTicketDepartDate
        {
            get { return Constant.Webdriver.FindElement(_cellBookTicketDepartDate); }
        }

        public IWebElement CellBookTicketAmount
        {
            get { return Constant.Webdriver.FindElement(_cellBookTicketAmount); }
        }

        #endregion

        #region Method

        public void BookTicket(string departDate, string dapartStation, string arriveStation, string seatType, string ticketAmount)
        {
            CboDepartDate.SendKeys(departDate);

            CboDepartStation.SendKeys(dapartStation);

            CboArriveStation.SendKeys(arriveStation);

            CboSeatType.SendKeys(seatType);

            new SelectElement(CboTicketAmount).SelectByText(ticketAmount);

            BtnBookTicket.Click();
        }

        public string GetTicketBookedSuccessfullyMessage()
        {
            return CommonFunctions.GetText(LblTicketBookedSuccessfullyMessage);
        }

        public void CheckBookTicketValue(string departDate, string departStation, string arriveStation, string seatType, string ticketAmount)
        {
            CommonFunctions.CheckTextDisplays(departDate, CommonFunctions.GetText(CellBookTicketDepartDate));
            CommonFunctions.CheckTextDisplays(departStation, CommonFunctions.GetText(CellBookTicketDepartStation));
            CommonFunctions.CheckTextDisplays(arriveStation, CommonFunctions.GetText(CellBookTicketArriveStation));
            CommonFunctions.CheckTextDisplays(seatType, CommonFunctions.GetText(CellBookTicketSeatType));
            CommonFunctions.CheckTextDisplays(ticketAmount, CommonFunctions.GetText(CellBookTicketAmount));
        }

        public void CheckSelectTicketInformation(string departStation, string arriveStation, string seatType)
        {
            SelectElement selectedDepartStation = new SelectElement(CboDepartStation);
            SelectElement selectedArriveStation = new SelectElement(CboArriveStation);

            IWebElement DepartStation = selectedDepartStation.SelectedOption;
            IWebElement ArriveStation = selectedArriveStation.SelectedOption;

            CommonFunctions.CheckTextDisplays(departStation, CommonFunctions.GetText(DepartStation));
            CommonFunctions.CheckTextDisplays(arriveStation, CommonFunctions.GetText(ArriveStation));

            if (seatType != "")
            {
                SelectElement selectSeatType = new SelectElement(CboSeatType);
                IWebElement SeatType = selectSeatType.SelectedOption;
                CommonFunctions.CheckTextDisplays(seatType, CommonFunctions.GetText(SeatType));
            }
        }

        public void BookManyTicketWithDifferenceDepartDate(int numberOfTicket)
        {
            string departDate;

            for (int i = 1; i <= numberOfTicket; i++)
            {
                departDate = Constant.Webdriver.FindElement(By.XPath("//select[@name='Date']/option[@value='" + (i + 2) + "']")).Text;
                CboDepartDate.SendKeys(departDate + Keys.Enter);
                //wail for loading elements
                Thread.Sleep(2000);
                BtnBookTicket.Click();
                GotoBookTicketPage();
            }
        }

        public void BookSixTicketsWithDifferenceDepartStation()
        {
            string departStation;

            for (int i = 1; i <= 6; i++)
            {
                departStation = Constant.Webdriver.FindElement(By.XPath("//select[@name='DepartStation']/option[@value='" + i + "']")).Text;
                CboDepartStation.SendKeys(departStation + Keys.Enter);
                //wail for loading elements
                Thread.Sleep(2000);
                BtnBookTicket.Click();
                GotoBookTicketPage();
            }
        }
        #endregion
    }
}
