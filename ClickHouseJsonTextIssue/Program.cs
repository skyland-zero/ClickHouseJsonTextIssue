// See https://aka.ms/new-console-template for more information

using ClickHouseJsonTextIssue;


Console.WriteLine("Hello, World!");

var connStr = @"Compress=False;BufferSize=32768;SocketTimeout=10000;CheckCompressedHash=False;Encrypt=False;Compressor=lz4;Host=192.168.10.45;Port=8123;Database=test;Username=default;Password=071500";

var fsql = new FreeSql.FreeSqlBuilder()
              .UseConnectionString(FreeSql.DataType.ClickHouse, connStr)
              .UseAutoSyncStructure(true)
              .UseExitAutoDisposePool(false)
              .Build();

//var json = "123123";
var json = "[{\"date\":\"2021-12-19T02:47:53.4365075 08:00\",\"temperatureC\":6,\"temperatureF\":42,\"summary\":\"Balmy\"},{\"date\":\"2021-12-20T02:47:53.4366893 08:00\",\"temperatureC\":36,\"temperatureF\":96,\"summary\":\"Bracing\"},{\"date\":\"2021-12-21T02:47:53.4366903 08:00\",\"temperatureC\":-15,\"temperatureF\":6,\"summary\":\"Bracing\"},{\"date\":\"2021-12-22T02:47:53.4366904 08:00\",\"temperatureC\":14,\"temperatureF\":57,\"summary\":\"Cool\"},{\"date\":\"2021-12-23T02:47:53.4366905 08:00\",\"temperatureC\":29,\"temperatureF\":84,\"summary\":\"Mild\"}]";
var data = new Entity { Id = Guid.NewGuid().ToString(), Content = json };

fsql.Insert(data).NoneParameter().ExecuteAffrows();