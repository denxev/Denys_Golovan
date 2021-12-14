using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public  class RecordFinder
    {
        private IWebDriver _driver;

        public RecordFinder(IWebDriver webDriver) => _driver = webDriver;

        public IWebDriver Driver => _driver;

        public IWebElement Find(string titleName) =>
                    _driver.FindElement(By.XPath($"//*[contains(text(), '{titleName}')]"));
    }
}
