using OpenQA.Selenium;
using Sele_5258_CanhTran.Common;

namespace Sele_5258_CanhTran.PageObjects
{
    public class TicketPricePage
    {
        public void BookTicketFromTicketPrice(string departStation, string arriveStation, string seatType)
        {
            // Find CheckPrice Link then Click
            IWebElement linkCheckPrice = Constant.Webdriver.FindElement(By.XPath("//td[.='" + departStation + " to " + arriveStation + "']/../td/a[@class='BoxLink']"));
            linkCheckPrice.Click();

            //Find BookTicket Link then Click
            IWebElement linkBookTicket = Constant.Webdriver.FindElement(By.XPath("//td[.='" + seatType + "']/../td/a[@class='BoxLink']"));
            linkBookTicket.Click();
        }
    }
}
