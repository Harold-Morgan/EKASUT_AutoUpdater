using Serilog;
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
        public static Task<int> ExecuteShellScript(string filePath)
        {
            var tcs = new TaskCompletionSource<int>();

            if (filePath == null)
                filePath = "/home/user/src/update_ekasut.sh";

            FileInfo fileInfo = new FileInfo(filePath);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = true;
            startInfo.FileName = "/bin/bash";
            startInfo.Arguments = $"\"{fileInfo.FullName}\"";

            var process = new Process
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };

            process.Exited += (sender, args) =>
            {
                tcs.SetResult(process.ExitCode);
                process.Dispose();
            };

            Log.Information($"Process started");

            process.Start();

            return tcs.Task;
        }
    }
}
