using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

namespace ClassLibrary
{
    public  class TitleDeleter
    {
        private  By _delete = By.Id("btnDelete");
        private  IWebDriver _driver;
        private  RecordFinder _finder;
        private  By _ok = By.Id("dialogDeleteBtn");

        public TitleDeleter(IWebDriver webDriver)
        {
            _driver = webDriver;
            _finder = new RecordFinder(webDriver);
        }

        public IWebDriver Driver => _driver;

        public void RemoveRecord(string titleName)
        {
            var gradeElement = _finder.Find(titleName);

            gradeElement.Click();
            Thread.Sleep(1000);
            var currentUrl = _driver.Url;

            var regex = @"\d";
            var matches = Regex.Matches(currentUrl, regex);
            var id = "";
            foreach (Match match in matches)
            {
                id += match.Value;
            }
            _driver.NavigateToJobTitles();
            IWebElement checkBox = _driver.FindElement(By.Id("ohrmList_chkSelectRecord_" + id));
            checkBox.Click();
            _driver.FindElement(_delete).Click();
            Thread.Sleep(2000);
            _driver.FindElement(_ok).Click();
        }
    }
}