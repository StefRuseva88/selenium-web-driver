using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace WebTables
{
    public class WebTablesTests
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
        public void WebTableTest()
        {
            IWebElement webTable = driver.FindElement(By.XPath("//div[@class='contentText']//table"));

            ReadOnlyCollection<IWebElement> tableRows = webTable.FindElements(By.XPath("//tbody//tr"));

            string path = System.IO.Directory.GetCurrentDirectory() + "/productsInfo.csv";

            if (File.Exists(path)) 
            {
                File.Delete(path);
            }

            foreach (IWebElement row in tableRows)
            {
                ReadOnlyCollection<IWebElement> tableCols = row.FindElements(By.XPath(".//td"));
                foreach (var tcol in tableCols)
                {
                    String data = tcol.Text;
                    String[] productInfo = data.Split("\n");
                    String printProductInfo = productInfo[0].Trim() + "," + productInfo[1].Trim() + "\n";

                    File.AppendAllText(path, printProductInfo);
                }
            }

            Assert.That(File.Exists(path), Is.True, "CSV file was not created");
            Assert.That(new FileInfo(path).Length > 0, Is.True, "CSV file is empty");
        }
    }
}