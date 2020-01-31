using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo.Framework
{
    [TestClass]
    public class LoggerClass
    {
        [TestMethod]
        public void TestMethod1()
        {

            ILog logger = LoggerHelper.GetLogger(typeof(LoggerClass));


            for(int i=0; i<10000; i++)
            {
                logger.Info("===========================");
                logger.Info("Started Logging");
                logger.Debug("This is debug Information");
                logger.Info("This is info Information");
                logger.Warn("This is warn Information");
                logger.Error("This is error Information");
                logger.Fatal("This is fatal Information");
                logger.Info("Ending Logging");
            }
        }

        [TestMethod]
        public void TestMethod2()
        {

            ILog logger = LoggerHelper.GetLogger(typeof(LoggerClass));


            for (int i = 0; i < 10000; i++)
            {
                logger.Info("===========================");
                logger.Info("Started Logging");
                logger.Debug("This is debug Information");
                logger.Info("This is info Information");
                logger.Warn("This is warn Information");
                logger.Error("This is error Information");
                logger.Fatal("This is fatal Information");
                logger.Info("Ending Logging");
            }
        }
    }
}
