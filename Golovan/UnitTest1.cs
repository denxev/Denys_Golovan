using NUnit.Framework;
using ClassLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Golovan
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _driver;
        private Authorizer authorizer;
        private TitleAdder titleAdder;
        private RecordEditor editor;
        private TitleDeleter titleDeleter;
        private string url = "https://opensource-demo.orangehrmlive.com/";
        private string username = "Admin";
        private string password = "admin123";


        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            authorizer = new Authorizer(_driver);
            titleAdder = new TitleAdder(_driver);
            editor = new RecordEditor(_driver);
            titleDeleter = new TitleDeleter(_driver);
        }

        [OneTimeTearDown]
        public void Close()
        {
            _driver.Close();
        }

        [Test]
        public void Test1()
        {
            var finder = new RecordFinder(_driver);
            var name = "GolDen";
            _driver.Navigate().GoToUrl(url);
            authorizer.LogIn(username, password);
            _driver.NavigateToJobTitles();
            titleAdder.AddNewRecord(name);
            try
            {
                editor.Edit(name);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Record was not created");
            }
            _driver.NavigateToJobTitles();
            titleDeleter.RemoveRecord(name);
            try
            {
                var el = finder.Find(name);
            }
            catch(NoSuchElementException)
            {
                Assert.Pass();
            }
            Assert.Fail("Element cannot be deleted");
        }
    }
}