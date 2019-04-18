using Autofac;
using BCL.ToolLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLib.Modules
{
    public interface ICacheModule
    {
        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        object Get(string key);
        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        T Get<T>(string key);
        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        void Remove(string key);
        /// <summary>
        /// 清空所有缓存对象
        /// </summary>
        //void Clear();
        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        void Insert(string key, object data);
        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        void Insert<T>(string key, T data);
        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间(秒钟)</param>
        void Insert(string key, object data, int cacheTime);

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间(秒钟)</param>
        void Insert<T>(string key, T data, int cacheTime);
        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        void Insert(string key, object data, DateTime cacheTime);
        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        void Insert<T>(string key, T data, DateTime cacheTime);
        /// <summary>
        /// 判断key是否存在
        /// </summary>
        bool Exists(string key);
    }
    /// <summary>
    /// 缓存
    /// </summary>
    public static class CacheModule
    {
        private static object cacheLocker = new object();//缓存锁对象
        private static ICacheModule cache = null;//缓存接口

        static CacheModule()
        {
            Load();
        }

        /// <summary>
        /// 加载缓存
        /// </summary>
        /// <exception cref=""></exception>
        private static void Load()
        {
            try
            {
                cache = new RedisModule();
            }
            catch (Exception ex)
            {
                LogModule.Error(ex.Message);
            }
        }

        public static ICacheModule GetCache()
        {
            return cache;
        }
        

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public static object GetString(this string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return null;
            return cache.Get(key);
        }

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public static T Get<T>(this string key) => cache.Get<T>(key);

        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        public static void Insert(this string key, object data)
        {
            if (string.IsNullOrWhiteSpace(key) || data == null)
                return;
            //lock (cacheLocker)
            {
                cache.Insert(key, data);
            }
        }
        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        public static void Insert<T>(this string key, T data)
        {
            if (string.IsNullOrWhiteSpace(key) || data == null)
                return;
            //lock (cacheLocker)
            {
                cache.Insert<T>(key, data);
            }
        }
        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间(分钟)</param>
        public static void Insert(this string key, object data, int cacheTime)
        {
            if (!string.IsNullOrWhiteSpace(key) && data != null)
            {
                //lock (cacheLocker)
                {
                    cache.Insert(key, data, cacheTime);
                }
            }
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间(分钟)</param>
        public static void Insert<T>(this string key, T data, int cacheTime)
        {
            if (!string.IsNullOrWhiteSpace(key) && data != null)
            {
                //lock (cacheLocker)
                {
                    cache.Insert<T>(key, data, cacheTime);
                }
            }
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        public static void Insert(this string key, object data, DateTime cacheTime)
        {
            if (!string.IsNullOrWhiteSpace(key) && data != null)
            {
                //lock (cacheLocker)
                {
                    cache.Insert(key, data, cacheTime);
                }
            }
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        public static void Insert<T>(this string key, T data, DateTime cacheTime)
        {
            if (!string.IsNullOrWhiteSpace(key) && data != null)
            {
                //lock (cacheLocker)
                {
                    cache.Insert<T>(key, data, cacheTime);
                }
            }
        }

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        public static void Remove(this string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            lock (cacheLocker)
            {
                cache.Remove(key);
            }
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        public static bool Exists(this string key)
        {
            return cache.Exists(key);
        }

    }

    public class CacheContainer
    {
        /// <summary>
        /// 
        /// </summary>
        public ICacheModule _Cache { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CacheContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(Type.GetType("BCL.ToolLib.Modules." + "CacheKind".ConfigValue("RedisModule")))
                   .As<ICacheModule>();
            _Cache = builder.Build()
                               .Resolve<ICacheModule>();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            GC.Collect();
        }
    }
}
