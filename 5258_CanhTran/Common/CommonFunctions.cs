using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Sele_5258_CanhTran.PageObjects;

namespace Sele_5258_CanhTran.Common
{
    public class CommonFunctions : GeneralPage
    {
        public static void OpenBrowser()
        {
            Constant.Webdriver = new FirefoxDriver();
            Constant.Webdriver.Manage().Window.Maximize();
        }
        public static void CloseBrowser()
        {
            Constant.Webdriver.Quit();
        }
        public static void CheckTextDisplays(string expectedText, string actualText)
        {
            Assert.AreEqual(expectedText, actualText);
        }

        public static string GetText(IWebElement element)
        {
            return element.Text;
        }

        public static bool IsElementPresent(By xpath)
        {
            try
            {
                Constant.Webdriver.FindElement(xpath);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsColumnValueMatch(IWebElement tableName, string columnName, string expectedValue)
        {
            ReadOnlyCollection<IWebElement> header = tableName.FindElements(By.TagName("th"));
            ReadOnlyCollection<IWebElement> cells = tableName.FindElements(By.TagName("td"));
            int columnNameIndex = 0;
            int valueIndex = 0;
            //Get the number of column based on the Column Name
            for (int i = 0; i < header.Count; i++)
            {
                columnNameIndex = columnNameIndex + 1;
                if (columnName.Equals(header[i].Text))
                    break;
            }
            //Check if the Data on the column match the expected data
            for (int k = 0; k < cells.Count; k++)
            {
                valueIndex = valueIndex + 1;
                if (valueIndex == columnNameIndex)
                {
                    if (expectedValue.Equals(cells[k].Text))
                        return true;
                }
            }
            return false;
        }
    }
}
