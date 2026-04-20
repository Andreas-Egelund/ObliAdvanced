using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ObliAdvanced.Utilities
{
    /// <summary>
    /// Singleton logger class for framework tracing and logging
    /// </summary>
    public sealed class MyLogger
    {
        private static readonly Lazy<MyLogger> _instance = new Lazy<MyLogger>(() => new MyLogger());
        private readonly List<TraceListener> _listeners = new List<TraceListener>();

        private MyLogger() { }

        public static MyLogger Instance => _instance.Value;

        public void AddListener(TraceListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(TraceListener listener)
        {
            _listeners.Remove(listener);
        }

        public void Log(string message)
        {
            foreach (var listener in _listeners)
            {
                listener.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
            }
        }
    }
}
