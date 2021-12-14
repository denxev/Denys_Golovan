using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class RecordEditor
    {
        private IWebDriver _driver;
        private By _edit = By.ClassName("editButton");
        private By _description = By.Id("jobTitle_jobDescription");
        private By _save = By.Id("btnSave");

        public RecordEditor(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebDriver Driver => _driver;

        public void Edit(string recordName)
        {
            var finder = new RecordFinder(_driver);
            var record = finder.Find(recordName);
            record.Click();
            _driver.FindElement(_edit).Click();
            _driver.FindElement(_description).SendKeys("New Description");
            _driver.FindElement(_save).Click();
        }
    }
}
