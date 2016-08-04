using OpenQA.Selenium;
using Sele_5258_CanhTran.Common;

namespace Sele_5258_CanhTran.PageObjects
{
    public class TimeTablePage
    {
        
        public void BookTicketFromTimetable(string departStation, string arriveStation)
        {
            IWebElement linkBookTicket = Constant.Webdriver.FindElement(By.XPath("//tr/td[2][.='" + departStation + "']/../td[3][.='" + arriveStation + "']/../td[.='book ticket']"));
            
            linkBookTicket.Click();
        }
    }
}
