using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LogReportTool
{
    internal class UserIdTotal
    {
        //public HashSet<string> uniqueUserIds = new HashSet<string>();
        //public List<LogEntry>? logs { get; private set; }
        //public UserIdTotal(List<LogEntry> logPath)
        //{
        //LogReader LR = new LogReader();
        //logs = LR.LogRead(logPath);
        //if (uniqueIds != null) return;
        //foreach (var it in logPath)  //ログをハッシュに詰めることでユニークなもののみ残る
        //{
        //    //if (uniqueIds.Any(x => x != it.UserId))
        //    //{
        //    uniqueUserIds.Add(it.UserId);
        //    //}
        //}

        //}
        //ユーザーIDとその数をdictionary型で返すメソッド
        public Dictionary<string, int> UserIdCount(List<LogEntry> logPath, int columNum)
        {
            Dictionary<string, int> countNum = new();    //dictionaryのキーは常にユニークになるので、ハッシュは没
            if (columNum == 1)
            {
                foreach (var it in logPath)
                {
                    if (!countNum.ContainsKey(it.Date)) countNum[it.Date] = 0;    //キーが存在しない場合追加する
                    countNum[it.Date]++;   //キーと一致する要素のカウントを増やす
                }

            }
            else if (columNum == 2)
            {
                foreach (var it in logPath)
                {
                    if (!countNum.ContainsKey(it.UserId)) countNum[it.UserId] = 0;    //キーが存在しない場合追加する
                    countNum[it.UserId]++;   //キーと一致する要素のカウントを増やす
                }
            }

            else
            { 
                //if (uniqueUserIds == null) return countNum;

                //foreach(var it in uniqueUserIds)
                //{
                //    countNum.Add(it, 0);
                //}

                //foreach (var it in logPath)
                //{
                //    string userId = it.UserId;
                //    if (countNum.ContainsKey(userId))
                //    {
                //        countNum[userId]++;
                //    }
                //    else
                //    {
                //        countNum[userId] = 1;
                //    }
                //}
                foreach (var it in logPath)
                {
                    if (!countNum.ContainsKey(it.Operation)) countNum[it.Operation] = 0;    //キーが存在しない場合追加する
                    countNum[it.Operation]++;   //キーと一致する要素のカウントを増やす
                }
            }

            return countNum;
        }
    }
}
