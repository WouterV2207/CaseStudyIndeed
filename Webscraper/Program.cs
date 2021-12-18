using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    class Program
    {

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://be.indeed.com/advanced_search");
            Thread.Sleep(2000);

            var element = driver.FindElement(By.XPath("/html/body/div[2]/form/fieldset[1]/div[1]/div[2]/input"));

            Thread.Sleep(2000);

            element.SendKeys("ict stage");
            Thread.Sleep(2000);
            var datebutton = driver.FindElement(By.XPath("/html/body/div[2]/form/fieldset[2]/div[2]/div[2]/select/option[4]"));
            datebutton.Click();
            Thread.Sleep(2000);
            var displaybutton = driver.FindElement(By.XPath("/html/body/div[2]/form/fieldset[2]/div[3]/div/div[2]/select/option[4]"));
            displaybutton.Click();
            var submitbutton = driver.FindElement(By.XPath("/html/body/div[2]/form/button"));
            submitbutton.Click();
            Thread.Sleep(2000);
   

            By job_card = By.ClassName("job_seen_beacon");
            ReadOnlyCollection<IWebElement> jobs = driver.FindElements(job_card);
            foreach (IWebElement job in jobs)
            {
                string str_title, str_company, str_location;
                IWebElement elem_job_title = job.FindElement(By.ClassName("jobTitle"));
                str_title = elem_job_title.Text;

                IWebElement elem_company = job.FindElement(By.ClassName("companyName"));
                str_company = elem_company.Text;

                IWebElement elem_location = job.FindElement(By.ClassName("companyLocation"));
                str_location = elem_location.Text;


                Console.WriteLine("Job Title: " + str_title);
                Console.WriteLine("Company: " + str_company);
                Console.WriteLine("Location: " + str_location);
                Console.WriteLine("\n");

                StringBuilder csvcontent = new StringBuilder();
                csvcontent.AppendLine("Job title: " + str_title + "\n " + "Job company: "+ str_company + "\n " + "Job location: "+ str_location + "\n");
                string csvpath = "D:\\School\\AI\\indeed\\Webscraper\\indeed.csv";
                File.AppendAllText(csvpath, csvcontent.ToString());
            }



        }
    }
}
