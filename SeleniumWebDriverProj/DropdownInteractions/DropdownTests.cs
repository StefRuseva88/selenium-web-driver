using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
namespace DropdownInteractions
{
    public class DropdownTests
    {
        WebDriver driver;
        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddArguments("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void ExtractInfo_BasedOnDropDown_Option()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "/manufacturers.csv";

            SelectElement dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));

            IList<IWebElement> options = dropdown.Options;

            List<string> optionsAsString = new List<string>();

            foreach (IWebElement option in options)
            {
                optionsAsString.Add(option.Text);
            }

            optionsAsString.RemoveAt(0);

            foreach (var option in optionsAsString)
            {
                dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));

                dropdown.SelectByText(option);
                if (driver.PageSource.Contains("There are no products available in this category."))
                {
                    File.AppendAllText(path, $"The manufacturer {option} has no produts in this category");
                }
                else
                {
                    IWebElement productsTable = driver.FindElement(By.ClassName("productListingData"));

                    File.AppendAllText(path, $"Products for manufacturer {option}: ");
                    ReadOnlyCollection<IWebElement> tableRows = productsTable.FindElements(By.XPath("//tbody//tr"));

                    foreach (var row in tableRows)
                    {
                        File.AppendAllText(path, row.Text);
                    }
                }
            }
        }
    }
}