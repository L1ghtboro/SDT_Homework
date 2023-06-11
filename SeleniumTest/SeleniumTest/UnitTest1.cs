using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Xml.Linq;

namespace SeleniumTest{
    [Binding]
    public class Tests{
        private IWebDriver driver;

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage(){
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[type='submit']")));
        }

        [When(@"I enter the username and password")]
        public void WhenIEnterTheUsernameAndPassword(){
            driver.FindElement(By.Name("username")).SendKeys("Admin");
            driver.FindElement(By.Name("password")).SendKeys("admin123");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn(){
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(awaiting => awaiting.FindElement(By.ClassName("oxd-topbar-header-breadcrumb-module"))); 
            if (element.Displayed) { Assert.IsTrue(element.Text.Contains("Dashboard") || element.Text.Contains("儀表板")); }// 儀表板
            else { Assert.Fail("No matching element found"); }
        }

        [When(@"I press admin panel")]
        public void WhenIAddANewJobTitle(){
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(awaiting => awaiting.FindElement(By.CssSelector("ul.oxd-main-menu li.oxd-main-menu-item-wrapper a[href='/web/index.php/admin/viewAdminModule']")));
            if (element.Displayed){ element.Click(); }
            else { Assert.IsNotNull(element); }
        }

        [Then(@"Admin panel should pop up")]
        public void ThenAdminPanelPopUp(){
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(awaiting => awaiting.FindElement(By.ClassName("oxd-topbar-header-breadcrumb-module")));
            if (element.Displayed) { Assert.IsTrue(element.Text.Contains("Admin") || element.Text.Contains("系統管理員"));  } //系統管理員
            else { Assert.Fail("No matching element found"); }
        }

        [When(@"I search for accordion")]
        public void WhenISearchForAccordion(){
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var elements = wait.Until(awaiting => awaiting.FindElements(By.CssSelector("li.oxd-topbar-body-nav-tab")));

            foreach (var element in elements){ 
                var span = element.FindElement(By.CssSelector("span.oxd-topbar-body-nav-tab-item"));
                if ((span.Text.Contains("Job") || span.Text.Contains("工作")) && element.Displayed){ //工作 
                    element.Click();
                    break;
                }
            }
        }

        [Then(@"I open Job titles")]
        public void ThenIOpenJobTitles(){
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("ul.oxd-dropdown-menu a.oxd-topbar-body-nav-tab-link")));
            if (element.Text.Contains("Job Titles") || element.Text.Contains("職稱")) { element.Click();; } //職稱
            else { Assert.Fail("No matching element found"); }
        }

        [When(@"I enter job title page")]
        public void WhenIEnterJobPage(){
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(awaiting => awaiting.FindElement(By.ClassName("oxd-topbar-header-breadcrumb-level")));
            if (element.Displayed) { Assert.IsTrue(element.Text.Contains("Job") || element.Text.Contains("工作")); }
            else { Assert.Fail("No matching element found"); }
        }

        [Then(@"I should see add Job")]
        public void ThenIShouldSeeAdd(){
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.oxd-button")));
            if (element.Text.Contains("Add") || element.Text.Contains("添加")) { element.Click(); return; } // 添加 
            else { Assert.Fail("No matching element found"); }
        }

        //このフロントエンドくそやろです

        [When(@"I click add I can add job")]
        public void WhenIClickAddICanAdd(){
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(awaiting => awaiting.FindElement(By.CssSelector("input.oxd-input.oxd-input--active:not([placeholder*='Search']):not([placeholder*='搜索'])"))); //搜索
            if (element.Displayed) { element.SendKeys("Intern"); }
            else { Assert.Fail("No matching element found"); }
        }

        [Then(@"I would like to add the job")]
        public void ThenIWillAddJob(){
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(awaiting => awaiting.FindElement(By.CssSelector("button[type='submit']")));
            if (element.Displayed) { element.Click(); }
            else { Assert.Fail("No matching element found"); }
        }

        [When(@"I add Job I have to delete it")]
        public void WhenIAddIDelete(){
            string jobName = "Intern";

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@class='orangehrm-container']")));

            IWebElement deleteButton = driver.FindElement(By.XPath($"//div[contains(text(),'{jobName}')]/ancestor::div[@class='oxd-table-card']"));

            deleteButton.Click();

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//p[text()='Are you sure?']")));
            IWebElement confirmDeleteButton = driver.FindElement(By.XPath("//button[text()='Yes, Delete']"));
            confirmDeleteButton.Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath($"//div[contains(text(),'{jobName}')]")));
            Assert.IsFalse(driver.FindElements(By.XPath($"//div[contains(text(),'{jobName}')]/ancestor::div[@class='oxd-table-card']"))
                            .Any(e => e.Displayed));
        }


        [AfterScenario]
        public void AfterScenario(){
            driver.Quit();
        }
    }
}