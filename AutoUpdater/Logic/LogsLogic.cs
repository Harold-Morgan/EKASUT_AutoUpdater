using System;
using System.IO;
using System.Text;

namespace AutoUpdater.Logic
{
    public class LogsLogic
    {
        public static string[] GetErrorLogs()
        {
            byte[] byteresult = null;

            var path = Path.Combine("auto_updater.log");

            //File.ReadAllBytes не работает потому, что Серилог вешает лок на запись на файл и он висит в ридонли-режиме
            using (FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using var memoryStream = new MemoryStream();
                fStream.CopyTo(memoryStream);
                byteresult = memoryStream.ToArray();
            }

            string[] result = Encoding.UTF8.GetString(byteresult).Split('\n', StringSplitOptions.RemoveEmptyEntries);

            return result;
        }
    }
}
