using log4net;

namespace SeleniumDemo.Framework
{
    public class TestLoggerClass
    {
        public void TestMethod1()
        {

            ILog logger = LoggerHelper.GetLogger(typeof(TestLoggerClass));


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

        public void TestMethod2()
        {

            ILog logger = LoggerHelper.GetLogger(typeof(TestLoggerClass));


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
