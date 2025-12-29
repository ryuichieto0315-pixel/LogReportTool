using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace LogReportTool
{
    internal class LogReader
    {
        public LogEntry? colum { get; private set; }

        public List<LogEntry> Read(string logPath)
        {
            var logs = new List<LogEntry>();
            //LogEntry colum;
            // 読み込みたいCSVファイルのパスを指定して開く
            using var sr = new StreamReader(logPath);

            // 末尾まで繰り返す
            int i = 0;
            while (!sr.EndOfStream)
            {
                // CSVファイルの一行を読み込む
                var line = sr.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;   //nullなら次のループへ

                var values = line.Split(',');// 読み込んだ一行をカンマ毎に分けて配列に格納する
                if (i == 0)
                {
                    colum = new(values[0], values[1], values[2]);
                    i++;
                    continue;
                }

                if (values.Length != 3) continue;
                // LogEntryリストに格納する
                logs.Add(new LogEntry(values[0], values[1], values[2]));
            }
            return logs;
        }

    }
}