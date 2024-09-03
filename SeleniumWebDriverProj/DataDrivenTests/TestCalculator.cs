using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DataDrivenTests
{
    public class TestCalculator
    {
        WebDriver driver;
        IWebElement firstNumberField;
        IWebElement secondNumberField;
        IWebElement dropdownOperations;
        IWebElement calculateButton;
        IWebElement resetButton;
        IWebElement resultField;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddArguments("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/");
        }

        [SetUp]
        public void Setup()
        {
            firstNumberField = driver.FindElement(By.XPath("//input[@name='number1']"));
            secondNumberField = driver.FindElement(By.XPath("//input[@name='number2']"));
            dropdownOperations = driver.FindElement(By.XPath("//select[@name='operation']"));
            calculateButton = driver.FindElement(By.Id("calcButton"));
            resetButton = driver.FindElement(By.Id("resetButton"));
            resultField = driver.FindElement(By.XPath("//div[@id='result']"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public void Calculate(string firstNumber, string secondNumber, string operation, string expectedResults)
        {
            resetButton.Click();

            if (!string.IsNullOrEmpty(firstNumber)) 
            {
                firstNumberField.SendKeys(firstNumber);
            }

            if (!string.IsNullOrEmpty(secondNumber))
            {
                secondNumberField.SendKeys(secondNumber);
            }

            if (!string.IsNullOrEmpty(operation))
            {
                new SelectElement(dropdownOperations).SelectByText(operation);
            }

            calculateButton.Click();

            Assert.That(resultField.Text, Is.EqualTo(expectedResults));
        }

        [Test]
        [TestCase("5", "5", "+ (sum)", "Result: 10")]
        [TestCase("5", "10", "+ (sum)", "Result: 15")]
        [TestCase("5", "15", "+ (sum)", "Result: 20")]
        [TestCase("3.5", "1.2", "- (subtract)", "Result: 2.3")]
        [TestCase("2e2", "1.5", "* (multiply)", "Result: 300")]
        [TestCase("5", "0", "/ (divide)", "Result: Infinity")]
        [TestCase("invalid", "10", "+ (sum)", "Result: invalid input")]
        public void Test(string firstNumber, string secondNumber, string operation, string expectedResults)
        {
            Calculate(firstNumber, secondNumber, operation, expectedResults);
        }
    }
}