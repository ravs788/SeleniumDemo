using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo.Framework
{
    public class CoreMethods
    {
        public void KillProcess(string strProcessName)
        {
            var process = Process.GetProcesses().Where(pr => pr.ProcessName == strProcessName);
            foreach(var pr in process)
            {
                pr.Kill();
            }
        }
    }
}
