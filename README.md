# Selenium-web-driver

[![NUnit](https://img.shields.io/badge/tested%20with-NUnit-22B2B0.svg)](https://nunit.org/)
[![Selenium](https://img.shields.io/badge/tested%20with-Selenium-43B02A.svg)](https://www.selenium.dev/)

### This is a test project for Front-End Test Automation July 2024 Course @ SoftUni

## About
Setup Selenium + NUnit. Writing Selenium Tests. Interaction with Page Elements

## Table of Contents

1. [Working with HTML Elements](#working-with-html-elements)
   - [Handling Form Input](#handling-form-input)
   - [Working with Web Tables](#working-with-web-tables)
   - [Drop-down Practice](#drop-down-practice)
2. [Data-Driven Tests](#data-driven-tests)

## Working with HTML Elements

### 1.1 Handling Form Input

Use Selenium to automate the process of filling out a form, locate and interact with different types of HTML elements. The steps involve:
- Launching a web application.
- Navigating to a form.
- Filling out various input fields such as text boxes, radio buttons, and date pickers.
- Submitting the form.

**Steps to Follow:**

1. Open the application using the URL.
2. Click on the **My Account** link.
3. In the **New Customer** section, click on the **Continue** button.
4. Fill in all mandatory information on the **Account Creation** page:
   - Select Gender
   - Enter First Name, Last Name, Date of Birth
   - Generate a unique email address for registration
   - Enter other required details like Company Name, Address, City, etc.
5. Use the `SelectElement` class from the `OpenQA.Selenium.Support.UI` namespace to interact with dropdown elements.
6. Submit the form and assert that the account has been created.
7. Log off and print a success message to the console.

### 1.2 Working with Web Tables

A web table is an HTML element represented by the `<table>` tag and is used to display data in a structured format.

**Scenario:**

- Open the application using the URL.
- Identify the web table on the home page and use XPath to locate it.
- Traverse the table to extract product information.
- Save the extracted data to a CSV file.
- Use assertions to verify that the CSV file is created and not empty.

### 1.3 Drop-down Practice

Automating interactions with dropdown elements using Selenium.

**Steps to Follow:**

1. Open the application using the URL.
2. Identify the dropdown element using its `name` property.
3. Use the `SelectElement` class to retrieve and interact with the dropdown options.
4. Save the dropdown information to a text file.
5. Check the file in the `bin -> Debug -> net{version}` directory.

## Data-Driven Tests

**Steps to Follow:**

1. Set up your project and install the necessary Selenium packages via NuGet.
2. Initialize the `ChromeDriver` and navigate to the "Number Calculator" web application.
3. Locate the necessary web elements on the page.
4. Define a method that accepts input values for the first number, operator, second number, and expected result.
5. Use the `[TestCase]` attribute to write various test cases with different inputs.
6. Implement a `TearDown` method to close the browser session after each test.

**Key Takeaways:**

- Data-driven testing separates test data from test logic, ensuring consistent application of logic across different scenarios.
- Each test case runs independently with its own data set, enhancing the reliability of your tests.

## Contributing

Feel free to submit pull requests and report any issues you find. Contributions are welcome!

## License

This project is licensed under the MIT License.

## Contact

For questions and feedback, you can reach out to the project maintainers.

---

Happy Testing! 🚀

