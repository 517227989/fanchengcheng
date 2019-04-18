using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace BCL.ToolLib.Modules
{
    /* Mongo 存储JSON数据，具有良好查询性能，TradeLog 的相关操作比较适应 */

    /// <summary>
    /// Mongo 数据操作
    /// </summary>
    public class MongoModule : IDisposable
    {
        private IMongoClient _Client { get; set; }
        public IMongoClient Client { get { return _Client; } set { value = _Client; } }
        public MongoUrl MongoUrl { get; set; }
        /// <summary>
        /// 是否连接
        /// </summary>
        public bool IsConnection = false;
        private static string _ConnectionString
        {
            get
            {
                var connStr = "MongoDBConnection".ConfigValue("mongodb://127.0.0.1:27017");
                if (!connStr.Contains("mongodb://"))
                    connStr = "mongodb://" + connStr;
                return connStr;
            }
        }
        /// <summary>
        /// 默认MongoUrl 方式连接
        /// </summary>
        public MongoModule()
        {
            try
            {
                if (MongoUrl == null)
                {
                    var mongoUrl = new MongoUrl(_ConnectionString);
                    MongoUrl = mongoUrl;
                }
                _Client = new MongoClient(MongoUrl);
                IsConnection = true;
            }
            catch (Exception ex)
            {
                IsConnection = false;
                LogModule.Error("MongoDB连接失败，" + _ConnectionString + ex);
            }
        }

        public MongoModule(string connectionString)
        {
            connectionString = string.IsNullOrEmpty(connectionString) ? _ConnectionString : connectionString;
            try
            {
                if (MongoUrl == null)
                {
                    var mongoUrl = new MongoUrl(_ConnectionString);
                    MongoUrl = mongoUrl;
                }
                _Client = new MongoClient(MongoUrl);
                IsConnection = true;
            }
            catch (Exception ex)
            {
                IsConnection = false;
                LogModule.Error("MongoDB连接失败，" + connectionString + ex);
            }
        }

        public MongoModule(MongoUrl mongoUrl)
        {
            try
            {
                if (MongoUrl == null)
                    MongoUrl = mongoUrl;
                _Client = new MongoClient(MongoUrl);
                IsConnection = true;
            }
            catch (Exception ex)
            {
                IsConnection = false;
                LogModule.Error("MongoDB连接失败，" + _ConnectionString + ex);
            }
        }

        /// <summary>
        /// 访问数据库集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbNme"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public IMongoCollection<T> MongoCollection<T>(string dbNme, string collectionName)
        {
            try
            {
                var db = _Client.GetDatabase(dbNme);
                var col = db.GetCollection<T>(collectionName);
                return col;
            }
            catch (Exception ex)
            {
                LogModule.Error("MongoDB 访问数据库集合" + dbNme + "->" + collectionName + "失败：" + ex);
                return null;
            }
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbNme">数据库</param>
        /// <param name="collectionName">列名(表)</param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert<T>(string dbNme, string collectionName, T t)
        {
            try
            {
                var db = _Client.GetDatabase(dbNme);
                var col = db.GetCollection<T>(collectionName);
                col.InsertOne(t);
                return 1;
            }
            catch (Exception ex)
            {
                LogModule.Error("MongoDB 添加数据库" + dbNme + "->" + collectionName + "失败：" + ex);
                return 0;
            }
        }

        /// <summary>
        /// 插入多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbNme"></param>
        /// <param name="collectionName"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert<T>(string dbNme, string collectionName, List<T> t)
        {
            try
            {
                var db = _Client.GetDatabase(dbNme);
                var col = db.GetCollection<T>(collectionName);
                col.InsertMany(t);
                return 1;
            }
            catch (Exception ex)
            {
                LogModule.Error("MongoDB 添加数据库" + dbNme + "->" + collectionName + "失败：" + ex);
                return 0;
            }
        }

        /// <summary>
        /// 修改符合全部条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbNme"></param>
        /// <param name="collectionName"></param>
        /// <param name="query"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public int Update<T>(string dbNme, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            try
            {
                var db = _Client.GetDatabase(dbNme);
                var col = db.GetCollection<T>(collectionName);
                var u = col.UpdateMany(filter, update);
                return u.MatchedCount.ToInt();
            }
            catch (Exception ex)
            {
                LogModule.Error("MongoDB 修改数据库" + dbNme + "->" + collectionName + "失败：" + ex);
                return 0;
            }
        }

        /// <summary>
        /// 修改第一条
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbNme"></param>
        /// <param name="collectionName"></param>
        /// <param name="query"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public int UpdateOne<T>(string dbNme, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            try
            {
                var db = _Client.GetDatabase(dbNme);
                var col = db.GetCollection<T>(collectionName);
                var u = col.UpdateOne(filter, update);
                return u.MatchedCount.ToInt();
            }
            catch (Exception ex)
            {
                LogModule.Error("MongoDB 修改数据库" + dbNme + "->" + collectionName + "失败：" + ex);
                return 0;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbNme"></param>
        /// <param name="collectionName"></param>
        /// <param name="bsonDocument">NULL 删除全部</param>
        /// <returns></returns>
        public int Delete<T>(string dbNme, string collectionName, BsonDocument bsonDocument = null)
        {
            try
            {
                var db = _Client.GetDatabase(dbNme);
                var col = db.GetCollection<T>(collectionName);
                bsonDocument = bsonDocument ?? new BsonDocument();
                var d = col.DeleteMany(bsonDocument);
                return d.DeletedCount.ToInt();
            }
            catch (Exception ex)
            {
                LogModule.Error("MongoDB 删除数据库" + dbNme + "->" + collectionName + "失败：" + ex);
                return 0;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbNme"></param>
        /// <param name="collectionName"></param>
        /// <param name="bsonDocument">查询条件,为NULL时查询全部</param>
        public List<T> Query<T>(string dbNme, string collectionName, BsonDocument bsonDocument = null)
        {
            try
            {
                var db = _Client.GetDatabase(dbNme);
                var col = db.GetCollection<T>(collectionName);
                bsonDocument = bsonDocument ?? new BsonDocument();
                var document = col.Find<T>(bsonDocument);
                return document.ToList();
            }
            catch (Exception ex)
            {
                LogModule.Error("MongoDB 查询数据库" + dbNme + "->" + collectionName + "失败：" + ex);
                return new List<T>();
            }
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbNme"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public List<T> Query<T>(string dbNme, string collectionName)
        {
            return Query<T>(dbNme, collectionName, null);
        }


        public void Dispose()
        {
            if (_Client != null)
            {
                _Client.Cluster.Dispose();
                _Client = null;
            }
        }
    }
}
