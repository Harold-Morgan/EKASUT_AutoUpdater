using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoUpdater
{
    public static class ShellHelper
    {
        public static int ExecuteShellScript(string filePath)
        {
            if (filePath == null)
                filePath = "/home/user/src/update_ekasut.sh";

            FileInfo fileInfo = new FileInfo(filePath);
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = true;
            startInfo.FileName = "/bin/bash";
            startInfo.Arguments = $"\"{fileInfo.FullName}\"";
            Process process = Process.Start(startInfo);

            return process.ExitCode;
        }
    }
}
