# Selenium Web Driver Tests

[![C#](https://img.shields.io/badge/Made%20with-C%23-239120.svg)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-5C2D91.svg)](https://dotnet.microsoft.com/)
[![Google Chrome](https://img.shields.io/badge/tested%20on-Google%20Chrome-4285F4.svg)](https://www.google.com/chrome/)
[![NUnit](https://img.shields.io/badge/tested%20with-NUnit-22B2B0.svg)](https://nunit.org/)
[![Selenium](https://img.shields.io/badge/tested%20with-Selenium-43B02A.svg)](https://www.selenium.dev/)

### This is a test project for Front-End Test Automation July 2024 Course @ SoftUni

## About
Setup Selenium + NUnit. Writing Selenium Tests. Interaction with Page Elements.

## Table of Contents

1. [Interacting with HTML Elements](#interacting-with-html-elements)
   - [Form Input Automation](#form-input-automation)
   - [Working with Web Tables](#working-with-web-tables)
   - [Drop-down Automation](#drop-down-automation)
2. [Data-Driven Testing](#data-driven-testing)

## Interacting with HTML Elements

### 1.1 Form Input Automation
Automate form filling using Selenium by locating and interacting with various HTML elements. The process includes:

- Launching a web application.
- Navigating to the form.
- Populating input fields such as text boxes, radio buttons, and date pickers.
- Submitting the form.

### 1.2 Working with Web Tables

Web tables are represented by the `<table>` tag and are used to display data in a structured way.

**Steps:**

- Open the application using the provided URL.
- Locate the web table on the home page using XPath.
- Track the table to extract product data.
- Save the extracted information to a CSV file.
- Verify that the CSV file is created and is not empty by using assertions.

### 1.3 Drop-down Automation

Automate the interaction with dropdown menus using Selenium.

**Steps:**

1. Open the application with the given URL.
2. Identify the dropdown element by its `name` attribute.
3. Utilize the `SelectElement` class to access and interact with dropdown options.
4. Save the dropdown information to a text file.
5. Locate the file in the `bin -> Debug -> net{version}` folder.

## Data-Driven Testing

Implement data-driven testing to reuse the same test logic across different data inputs, thereby increasing test efficiency.

**Essential Concepts:**

- Data-driven testing decouples test data from the test logic, allowing the same logic to be applied consistently across various scenarios.
- Each test executes independently with its unique data set, which boosts the reliability of the tests.

## Contributing

Feel free to submit pull requests and report any issues you find. Contributions are welcome!

## License

This project is licensed under the MIT License.

## Contact

For questions and feedback, you can reach out to the project maintainers.

---

Happy Testing! 🚀

