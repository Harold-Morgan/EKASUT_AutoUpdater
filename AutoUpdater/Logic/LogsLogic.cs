using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdater.Logic
{
    public class LogsLogic
    {
        public class InMemorySink : ILogEventSink
        {
            readonly ITextFormatter _textFormatter = new MessageTemplateTextFormatter("{Timestamp} [{Level}] {Message}{Exception}");

            public ConcurrentQueue<string> Events { get; } = new ConcurrentQueue<string>();

            public void Emit(LogEvent logEvent)
            {
                if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
                var renderSpace = new StringWriter();
                _textFormatter.Format(logEvent, renderSpace);
                Events.Enqueue(renderSpace.ToString());
            }
        }

        public static string[] GetErrorLogs()
        {
            byte[] byteresult = null;

            var  path = Path.Combine("auto_updater.log");

            //File.ReadAllBytes не работает потому, что Серилог вешает лок на запись на файл и он висит в ридонли-режиме
            using (FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var memoryStream = new MemoryStream())
                {
                    fStream.CopyTo(memoryStream);
                    byteresult = memoryStream.ToArray();
                }
            }

            string[] result = Encoding.UTF8.GetString(byteresult).Split('\n', StringSplitOptions.RemoveEmptyEntries);

            return result;
        }
    }
}
