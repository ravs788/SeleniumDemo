using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SeleniumDemo.Framework
{
    public class CoreMethods
    {
        private static ILog logger = LoggerHelper.GetLogger(typeof(CoreMethods));

        public void KillProcess(string strProcessName)
        {
            var process = Process.GetProcesses().Where(pr => pr.ProcessName == strProcessName);
            foreach(var pr in process)
            {
                pr.Kill();
            }
        }

        public static void AssertTrue(bool returnValue, string message)
        {
            try
            {
                Assert.IsTrue(returnValue, message);
                logger.Debug("Assertion " + message + " passed");
            }
            catch(Exception e)
            {
                logger.Error("Assertion " + message + " failed with exception -"+e.Message);
            }

        }

    }
}
