using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class TitleAdder
    {
        private  By _addTitle = By.Name("btnAdd");
        private  By _titleName = By.Id("jobTitle_jobTitle");
        private By _description = By.Id("jobTitle_jobDescription"); //Lorem ipsum dolor 
        private  By _note = By.Id("jobTitle_note"); // sit amet
        private By _save = By.Id("btnSave");
        private  IWebDriver _driver;

        public TitleAdder(IWebDriver webDriver) => _driver = webDriver;

        public IWebDriver Driver => _driver;

        public void AddNewRecord(string name)
        {
            _driver.FindElement(_addTitle).Click();
            _driver.FindElement(_titleName).SendKeys(name);
            _driver.FindElement(_description).SendKeys("Lorem ipsum dolor");
            _driver.FindElement(_note).SendKeys("sit amet");
            _driver.FindElement(_save).Click();
        }
    }
}
