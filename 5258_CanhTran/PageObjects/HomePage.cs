using Sele_5258_CanhTran.Common;

namespace Sele_5258_CanhTran.PageObjects
{
   public class HomePage: GeneralPage
    {
        public HomePage Open()
        {
            Constant.Webdriver.Navigate().GoToUrl(Constant.HomePageUrl);
            return this;
        }
    }
}
