using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LogReportTool
{
    internal class Menu
    {
        public void Start()
        {
            Console.WriteLine("ログチェックツールが起動しました。");
            while (true)
            {
                int num;
                string? logPath;
                Console.Write("チェックしたいログの絶対パスを入力してください(終了する場合はnを入力してください)：");
                logPath = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(logPath))  //入力がnullや空白なら再入力
                {
                    Console.Write("空白以外の1文字以上で絶対パスを入力してください：");
                    logPath = Console.ReadLine();
                }
                if (logPath == "n") return; //nが入力されたらアプリ終了
                logPath = logPath.Trim().Trim('"'); //空白とダブルクォーテーションをパスから排除

                var LR = new LogReader();
                var logs = LR.Read($"{logPath}");
                var UIT = new UserIdTotal();

                while (true)
                {
                    Console.Write($"\r\n次の操作を該当する数字で入力してください(1.{LR.colum?.Date}のカウント /2.{LR.colum?.UserId}のカウント 3.{LR.colum?.Operation}のカウント　/4.別のファイルパス読み込み /5.アプリの終了  )：");
                    
                    while (!int.TryParse(Console.ReadLine(), out num))  //数字以外が入力されるまでループ
                    {
                        Console.WriteLine("数字で入力してください\r\n");
                        Console.Write($"\r\n次の操作を該当する数字で入力してください(1.{LR.colum?.Date}のカウント /2.{LR.colum?.UserId}のカウント 3.{LR.colum?.Operation}のカウント　/4.別のファイルパス読み込み /5.アプリの終了  )：");
                    }

                    switch (num)
                    {
                        case 1:
                        case 2:
                        case 3:
                            var result = UIT.UserIdCount(logs, num);    //番号に応じた列をカウント

                            foreach (var kv in result)  //コンソールに書き出す
                            {
                                Console.WriteLine($"{kv.Key} : {kv.Value}件");
                            }
                            continue;

                        case 4:
                            Console.WriteLine("");  //見やすいように改行
                            break;

                        case 5:
                            Console.WriteLine("アプリを終了します。");
                            return;
                    }
                    break;
                }

            }
        }
    }
}
