using System;
using System.Collections.Generic;
using System.Text;

namespace LogReportTool
{
    internal class LogEntry
    {
        public string Date { get; private set; } = "";
        public string UserId { get; private set; } = "";
        public string Operation { get; private set; } = "";
        public LogEntry(string date, string userId, string operation)
        {
            Date = date;
            UserId = userId;
            Operation = operation;
        }
    }
}
