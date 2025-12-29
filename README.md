## 実行方法
1. このリポジトリを clone
2. LogReportTool.sln を Visual Studio で開く
3. ▶ 実行

## 開発環境
- Visual Studio 2026
- .NET 10

## 概要
CSV形式のログファイルを読み込み、日付、ユーザーID、操作ごとの件数を集計する C# 製のコンソールアプリです。  
入力チェックやファイル存在確認、エラー処理を組み込み、ユーザーが安全に操作できるように設計しています。

## サンプルCSV
`data` フォルダにサンプルCSVファイルが用意されています。
このファイルを読み込むことで、ツールの動作確認ができます。
CSVは以下の形式を想定しています：

Date,UserId,Operation\
2025-12-29,user1,Login\
2025-12-29,user2,Logout\
2025-12-29,user1,Upload
