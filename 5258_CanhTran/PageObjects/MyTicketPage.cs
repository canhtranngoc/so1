using OpenQA.Selenium;
using Sele_5258_CanhTran.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sele_5258_CanhTran.PageObjects
{
    public class MyTicketPage : GeneralPage
    {
        #region Locator
        private readonly By _btnCancel = By.XPath("//table[@class='MyTable']//input[@value='Cancel']");
        public readonly By _tblMyTicket = By.XPath(".//div[@id='content']//div[@class='DivTable']");
        private readonly By _cboDepartStation = By.Name("FilterDpStation");
        private readonly By _txtDepartDate = By.Name("FilterDpDate");
        private readonly By _cboStatus = By.Name("FilterStatus");
        private readonly By _btnApplyFilter = By.XPath("//input[@type='submit' and @value='Apply filter']");
        private readonly By _lblErrorFilterMessage = By.XPath("//div[@id='content']//div[@class='error message']");
        public string confirmCancelTicketMessage;
        #endregion

        #region Elements
        public IWebElement BtnCancel
        {
            get { return Constant.Webdriver.FindElement(_btnCancel); }
        }

        public IWebElement TblMyTicket
        {
            get { return Constant.Webdriver.FindElement(_tblMyTicket); }
        }

        public IWebElement CboDepartStation
        {
            get { return Constant.Webdriver.FindElement(_cboDepartStation); }
        }

        public IWebElement TxtDepartDate
        {
            get { return Constant.Webdriver.FindElement(_txtDepartDate); }
        }

        public IWebElement CboStatus
        {
            get { return Constant.Webdriver.FindElement(_cboStatus); }
        }

        public IWebElement BtnApplyFilter
        {
            get { return Constant.Webdriver.FindElement(_btnApplyFilter); }
        }

        public IWebElement LblErrorFilterMessage
        {
            get { return Constant.Webdriver.FindElement(_lblErrorFilterMessage); }
        }

        #endregion

        #region Method
        public void CancelOneTicket(string departStation, string arriveStation, string departDate)
        {
            IWebElement btnCancelTicket = Constant.Webdriver.FindElement(By.XPath("//tr/td[.='" + departStation + "']/../td[.='" + arriveStation + "']/../td[.='" + departDate + "']/../td/input[@value='Cancel']"));
            btnCancelTicket.Click();
            IAlert alert = Constant.Webdriver.SwitchTo().Alert();
            confirmCancelTicketMessage = alert.Text;
            alert.Accept();
        }

        public bool CheckCancelTicket()
        {
            Assert.IsFalse(CommonFunctions.IsElementPresent(_btnCancel));
            return false;
        }
        public void CancelAllTickets()
        {
            while (CountTicketTableRow() > 1)
            {
                IWebElement btnCancelTicket = Constant.Webdriver.FindElement(By.XPath("//table[@class='MyTable']//input[@value='Delete' or @value='Cancel']"));
                btnCancelTicket.Click();
                IAlert alert = Constant.Webdriver.SwitchTo().Alert();
                alert.Accept();
            }
        }
        public int CountTicketTableRow()
        {
            int countTicketTableRow = Constant.Webdriver.FindElements(By.XPath("//table[@class='MyTable']/tbody/tr")).Count;
            return countTicketTableRow;
        }

        public void FilterTictketWithDepartStation(string departStation)
        {
            CboDepartStation.SendKeys(departStation);
            BtnApplyFilter.Click();
        }

        public void FilterTictketWithDepartDate(string departDate)
        {
            TxtDepartDate.Clear();
            TxtDepartDate.SendKeys(departDate);
            BtnApplyFilter.Click();
        }

        public void FilterTicketWithStatus(string status)
        {
            CboStatus.SendKeys(status);
            BtnApplyFilter.Click();
        }

        public void CheckTicketWithDepartDate(string departDate)
        {
            if (CommonFunctions.IsColumnValueMatch(TblMyTicket, "Depart Date", departDate) == true)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        public void CheckTicketWithDepartStation(string departStation)
        {
            if (CommonFunctions.IsColumnValueMatch(TblMyTicket, "Depart Station", departStation) == true)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        public string GetErrorFilterMessage()
        {
            return CommonFunctions.GetText(LblErrorFilterMessage);
        }
        #endregion
    }
}
