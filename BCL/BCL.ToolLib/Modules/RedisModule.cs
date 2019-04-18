using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BCL.ToolLib.Modules
{
    public class RedisModule : ICacheModule, IDisposable
    {
        string address;
        JsonSerializerSettings jsonConfig = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, NullValueHandling = NullValueHandling.Ignore };
        ConnectionMultiplexer connectionMultiplexer;
        IDatabase database;

        class CacheObject<T>
        {
            public int? ExpireTime { get; set; }
            public bool ForceOutofDate { get; set; }
            public T Value { get; set; }
        }

        public RedisModule()
        {
            address = "RedisUrl".ConfigValue();
            if (address == null || string.IsNullOrWhiteSpace(address.ToString()))
                throw new ApplicationException("配置文件中未找到RedisServer的有效配置");
            address += ",password=Conlin360";
            connectionMultiplexer = ConnectionMultiplexer.Connect(ConfigurationOptions.Parse(address));
            database = connectionMultiplexer.GetDatabase();
        }

        public object Get(string key)
        {
            return Get<object>(key);
        }

        public T Get<T>(string key)
        {

            DateTime begin = DateTime.Now;
            var cacheValue = database.StringGet(key);
            DateTime endCache = DateTime.Now;
            var value = default(T);
            if (!cacheValue.IsNull)
            {
                var cacheObject = JsonConvert.DeserializeObject<CacheObject<T>>(cacheValue, jsonConfig);
                //if (!cacheObject.ForceOutofDate)
                //    database.KeyExpire(key, new TimeSpan(0, 0, cacheObject.ExpireTime));
                value = cacheObject.Value;
            }
            DateTime endJson = DateTime.Now;
            return value;

        }

        public void Insert(string key, object data)
        {
            var jsonData = GetJsonData(data, null, false);
            database.StringSet(key, jsonData);
        }

        public void Insert(string key, object data, int cacheTime)
        {
            var timeSpan = TimeSpan.FromSeconds(cacheTime);
            var jsonData = GetJsonData(data, timeSpan.Seconds, true);
            database.StringSet(key, jsonData, timeSpan);
        }

        public void Insert(string key, object data, DateTime cacheTime)
        {
            var timeSpan = cacheTime - DateTime.Now;
            var jsonData = GetJsonData(data, timeSpan.Seconds, true);
            database.StringSet(key, jsonData, timeSpan);
        }

        public void Insert<T>(string key, T data)
        {
            var jsonData = GetJsonData<T>(data, null, false);
            database.StringSet(key, jsonData);
        }

        public void Insert<T>(string key, T data, int cacheTime)
        {
            var timeSpan = TimeSpan.FromSeconds(cacheTime);
            var jsonData = GetJsonData<T>(data, timeSpan.Seconds, true);
            database.StringSet(key, jsonData, timeSpan);
        }

        public void Insert<T>(string key, T data, DateTime cacheTime)
        {
            var timeSpan = cacheTime - DateTime.Now;
            var jsonData = GetJsonData<T>(data, timeSpan.Seconds, true);
            database.StringSet(key, jsonData, timeSpan);
        }

        #region Hash(哈希/散列/字典)键值对操作 

        /// <summary>
        /// 删除指定的哈希字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool HashDelete(string key, string field)
        {
            return database.HashDelete(key, field);
        }

        /// <summary>
        /// 判断是否存在散列字段
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public bool HashHasKey(string key, string field)
        {
            return database.HashExists(key, field);
        }

        /// <summary>
        /// 获取存储在指定键的哈希字段的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public object HashGet(string key, string field)
        {
            return database.HashGet(key, field);
        }

        /// <summary>
        /// 获取存储在指定键的哈希中的所有字段和值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Dictionary<string, object> HashGetAll(string key)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            var collection = database.HashGetAll(key);
            foreach (var item in collection)
            {
                dic.Add(item.Name, item.Value);
            }
            return dic;
        }

        /// <summary>
        /// 将哈希字段的浮点值按给定数值增加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value">给定的数值</param>
        /// <returns></returns>
        public double HashIncrement(string key, string field, double value)
        {
            return database.HashIncrement(key, field, value);
        }

        /// <summary>
        /// 获取哈希中的所有字段
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string[] HashKeys(string key)
        {
            return database.HashKeys(key).ToStringArray();
        }

        /// <summary>
        /// 获取散列中的字段数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long HashSize(string key)
        {
            return database.HashLength(key);
        }

        /// <summary>
        /// 获取所有给定哈希字段的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashKeys"></param>
        /// <returns></returns>
        public List<object> HashMultiGet(string key, List<string> hashKeys)
        {
            List<object> result = new List<object>();
            foreach (string field in hashKeys)
            {
                result.Add(database.HashGet(key, field));
            }
            return result;
        }

        /// <summary>
        /// 为多个哈希字段分别设置它们的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public void HashPutAll(string key, Dictionary<string, string> dic)
        {
            List<HashEntry> list = new List<HashEntry>();
            for (int i = 0; i < dic.Count; i++)
            {
                KeyValuePair<string, string> param = dic.ElementAt(i);
                list.Add(new HashEntry(param.Key, param.Value));
            }
            database.HashSet(key, list.ToArray());
        }

        /// <summary>
        /// 设置散列字段的字符串值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void HashPut(string key, string field, string value)
        {
            database.HashSet(key, new HashEntry[] { new HashEntry(field, value) });
        }

        /// <summary>
        /// 仅当字段不存在时，才设置散列字段的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fiels"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void HashPutIfAbsent(string key, string field, string value)
        {
            if (!HashHasKey(key, field))
            {
                database.HashSet(key, new HashEntry[] { new HashEntry(field, value) });
            }
        }

        /// <summary>
        /// 获取哈希中的所有值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string[] HashValues(string key)
        {
            return database.HashValues(key).ToStringArray();
        }

        /// <summary>
        /// redis中获取指定键的值并返回对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetHashValue<T>(string key)
        {
            HashEntry[] array = database.HashGetAll(key);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            for (int i = 0; i < array.Length; i++)
            {
                dic.Add(array[i].Name, array[i].Value);
            }
            string strJson = JsonConvert.SerializeObject(dic);
            return JsonConvert.DeserializeObject<T>(strJson);
        }

        /// <summary>
        /// 把指定对象存储在键值为key的redis中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="key"></param>
        public void SetHashValue<T>(T t, string key)
        {
            string strJson = JsonConvert.SerializeObject(t);
            Dictionary<string, string> param = JsonConvert.DeserializeObject<Dictionary<string, string>>(strJson);
            HashPutAll(key, param);
        }

        #endregion

        private string GetJsonData(object data, int? cacheTime, bool forceOutOfDate)
        {
            var cacheObject = new CacheObject<object>() { Value = data, ExpireTime = cacheTime, ForceOutofDate = forceOutOfDate };
            return JsonConvert.SerializeObject(cacheObject, jsonConfig);//序列化对象
        }

        private string GetJsonData<T>(T data, int? cacheTime, bool forceOutOfDate)
        {
            var cacheObject = new CacheObject<T>() { Value = data, ExpireTime = cacheTime, ForceOutofDate = forceOutOfDate };
            return JsonConvert.SerializeObject(cacheObject, jsonConfig);//序列化对象
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            database.KeyDelete(key, CommandFlags.HighPriority);
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        public bool Exists(string key)
        {
            return database.KeyExists(key);
        }
        public void Dispose()
        {
            GC.Collect();
        }

    }
}
