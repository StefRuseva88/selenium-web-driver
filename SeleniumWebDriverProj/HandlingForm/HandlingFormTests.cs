using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HandlingForm
{
    public class HandlingFormTests
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void HandlingFormInputs()
        {
            var myAccountBtn = driver.FindElement(By.XPath("//span[text()='My Account']"));
            myAccountBtn.Click();

            driver.FindElement(By.XPath("//span[text()='Continue']")).Click();
            driver.FindElement(By.XPath("//input[@type='radio'][@value='f']")).Click();
            driver.FindElement(By.XPath("//input[@name='firstname']")).SendKeys("Stef");
            driver.FindElement(By.XPath("//input[@name='lastname']")).SendKeys("Maximova");
            driver.FindElement(By.XPath("//input[@name='dob']")).SendKeys("05/21/1977");

            Random random = new Random();
            int randomNum = random.Next(1000, 9999);
            string email = "Stef" + randomNum.ToString() + "@gmail.com";
            driver.FindElement(By.XPath("//input[@name='email_address']")).SendKeys(email);

            driver.FindElement(By.XPath("//input[@name='company']")).SendKeys("Optimal Trade Ltd");
            driver.FindElement(By.XPath("//input[@name='street_address']")).SendKeys("Prajka prolet str");
            driver.FindElement(By.XPath("//input[@name='suburb']")).SendKeys("Stock Housing");
            driver.FindElement(By.XPath("//input[@name='postcode']")).SendKeys("1000");
            driver.FindElement(By.XPath("//input[@name='city']")).SendKeys("Sofia");
            driver.FindElement(By.XPath("//input[@name='state']")).SendKeys("Sofia");

            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("Bulgaria");

            driver.FindElement(By.XPath("//input[@name='telephone']")).SendKeys("0888888888");
            driver.FindElement(By.XPath("//input[@name='fax']")).SendKeys("0888888888");
            driver.FindElement(By.XPath("//input[@name='newsletter'][@value='1']")).Click();
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("123456");
            driver.FindElement(By.XPath("//input[@name='confirmation']")).SendKeys("123456");

            driver.FindElement(By.XPath("//span[text()='Continue']")).Click();

            Assert.IsTrue(driver.PageSource.Contains("Your Account Has Been Created!"), "Account creation failed.");

            driver.FindElement(By.LinkText("Log Off")).Click();

            driver.FindElement(By.LinkText("Continue")).Click();

            Console.WriteLine("User Created Succesfully!");
        }
    }
}