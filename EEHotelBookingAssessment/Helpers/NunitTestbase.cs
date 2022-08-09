﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using EEHotelBookingAssessment.TestLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEHotelBookingAssessment.Static;

namespace EEHotelBookingAssessment.Helpers
{
    public class NunitTestbase : WebdriverManager
    {
        public static ExtentTest test;
        public static ExtentReports extent;
        public static APITestHelpers response = new();

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(ConfigData.ReportDirectory + DateTime.Now.ToString("_MMddyyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
        }

        [OneTimeTearDown]
        public void ExtentCLose()
        {
            extent.Flush();
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                CloseAllDrivers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
