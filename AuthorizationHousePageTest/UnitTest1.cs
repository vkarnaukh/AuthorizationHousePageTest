using OpenQA.Selenium;

namespace AuthorizationHousePageTest
{
    public class Tests
    {
        private IWebDriver driver;
        private double expectedUserProfile;

        //private By _cookiesButton;
        private readonly By _cookiesButton = By.XPath("//button[text()='W porządku']");

        private readonly By _kontoButton = By.XPath("//div[@data-testid='account-info-logged-false']");
        private readonly By _loginInputField = By.XPath("//input[@id='login[username]_id']");
        private readonly By _passwordInputField = By.XPath("//input[@id='login[password]_id']");
        private readonly By _submitButton = By.XPath("//button[@data-selen='login-submit']");
        private readonly By _userProfile = By.XPath("//p[text()='Valeriia']");

        private const string _login = "valeriia.karnaukh@gmail.com";
        private const string _password = "Password1";
        private const string _expectedUserProfile = "Valeriia";


        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver("C:\\Users\\vkarnau\\source\\repos\\AuthorizationHousePageTest");
            driver.Navigate().GoToUrl("https://www.housebrand.com/pl/pl/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            //var konto = driver.FindElement(kontoButton);
            //konto.Click();
            var cookies = driver.FindElement(_cookiesButton);
            cookies.Click();
            var konto = driver.FindElement(_kontoButton);
            konto.Click();
            var login = driver.FindElement(_loginInputField);
            login.SendKeys(_login);
            var password = driver.FindElement(_passwordInputField);
            password.SendKeys(_password);
            var submitButton = driver.FindElement(_submitButton);
            submitButton.Click();
            var actualuserProfile = driver.FindElement(_userProfile).Text.ToString();
            
            Assert.That(actualuserProfile, Is.EqualTo(_expectedUserProfile), "Invalid user profile");


        }
        [TearDown]
        public void TearDown()
        {

        }
    }
}