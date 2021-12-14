using OpenQA.Selenium;

namespace ClassLibrary
{
    public  class Authorizer
    {
        private  By _password = By.Name("txtPassword");
        private  By _submit = By.Name("Submit");
        private  By _userName = By.Name("txtUsername");
        private  IWebDriver _driver;

        public Authorizer(IWebDriver webDriver) => _driver = webDriver;

        public void LogIn(string username, string password)
        {
            _driver.FindElement(_userName).SendKeys(username);
            _driver.FindElement(_password).SendKeys(password);
            _driver.FindElement(_submit).Click();
        }
    }
}