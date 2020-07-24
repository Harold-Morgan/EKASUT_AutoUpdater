using AutoUpdater.Helpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoUpdater.Logic
{
    public static class BuildLogic
    {
        public static async Task<object> BuildEkasut()
        {
            Log.Information($"EKASUT Build started");

            int result = await ShellHelper.ExecuteShellScript(ConfigHelper.Instance.EkasutFilePath);

            if (result == 0)
                Log.Information($"EKASUT update process exited with code = {result}");
            else
                Log.Error($"EKASUT update process returned an error with code = {result}");

            return result;
        }

        public static async Task<object> BuildDbsync()
        {
            Log.Information($"DBsync Build started");

            int result = await ShellHelper.ExecuteShellScript(ConfigHelper.Instance.DbsyncFilePath);

            if (result == 0)
                Log.Information($"DBsync update process exited with code = {result}");
            else
                Log.Error($"Dbsync update process returned an error with code = {result}");

            return result;
        }
    }
}
