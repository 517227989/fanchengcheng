using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmitMapper;
using EmitMapper.MappingConfiguration;

namespace BCL.ToolLib.Modules
{
    public class MapperModule : IDisposable
    {
        private DefaultMapConfig OwnDefaultMapConfigs { get; set; }
        public ObjectMapperManager OMM { get; set; }
        public MapperModule()
        {
            OwnDefaultMapConfigs = OwnDefaultMapConfig();
            OMM = new ObjectMapperManager();
        }
        public void SetConvertUsing<From, To>(Func<From, To> converter)
        {
            OwnDefaultMapConfigs.ConvertUsing(converter);
        }
        public DefaultMapConfig OwnDefaultMapConfig()
        {
            return new DefaultMapConfig().MatchMembers((x, y) =>
            {
                return x == y;
            });
        }
        public List<T> I2E<F, T>(List<F> Entity)
        {
            return MapperList<F, T>(Entity);
        }
        public List<T> E2I<F, T>(List<F> Entity)
        {
            return MapperList<F, T>(Entity);
        }
        public T I2E<F, T>(F Entity)
        {
            return Mapper<F, T>(Entity);
        }
        public T E2I<F, T>(F Entity)
        {
            return Mapper<F, T>(Entity);
        }
        /// <summary>
        /// List实体映射
        /// </summary>
        /// <typeparam name="F">来源</typeparam>
        /// <typeparam name="T">目标</typeparam>
        /// <param name="Entity">来源数据</param>
        /// <returns></returns>
        public List<T> MapperList<F, T>(List<F> Entity)
        {
            return Entity.Select(s => Mapper<F, T>(s)).ToList();
        }
        /// <summary>
        /// 实体映射
        /// </summary>
        /// <typeparam name="F">来源</typeparam>
        /// <typeparam name="T">目标</typeparam>
        /// <param name="Entity">来源数据</param>
        /// <returns></returns>
        public T Mapper<F, T>(F Entity)
        {
            try
            {
                return OMM.GetMapper<F, T>(OwnDefaultMapConfigs).Map(Entity);
            }
            catch (Exception ex)
            {
                LogModule.Error("EmitMapper映射异常:" + ex);
                return default(T);
            }
        }
        public void Dispose()
        {
            GC.Collect();
        }
    }
}
