﻿using Microsoft.AspNetCore.Components;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;
using System;
using System.Collections.Concurrent;
using System.IO;

namespace AutoUpdater.Logic
{
    public class InMemorySink : ILogEventSink
    {
        readonly ITextFormatter _textFormatter = new MessageTemplateTextFormatter("{Timestamp} [{Level}] {Message}{Exception}");

        [Inject]
        public ConcurrentQueue<string> Events { get; } = new ConcurrentQueue<string>();

        public void Emit(LogEvent logEvent)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
            var renderSpace = new StringWriter();
            _textFormatter.Format(logEvent, renderSpace);
            Events.Enqueue(renderSpace.ToString());
        }

        public void Clear()
        {
            Events.Clear();
        }
    }
}
