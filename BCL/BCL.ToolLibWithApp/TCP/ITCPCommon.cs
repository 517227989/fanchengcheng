using Autofac;
using BCL.DataAccess;
using BCL.DataAccess.DbEntity.ESB;
using BCL.ToolLib;
using BCL.ToolLib.Modules;
using BCL.ToolLibWithApp.TCP.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.TCP
{
    public interface ITCPCommon
    {
        CheckMode GetCheckMode(string deptCode);
        List<Db_RegPatientList> GetPatientList(string deptCode, string docCode, string typeCode);
    }

    public class TCPCommon : ITCPCommon
    {
        public virtual CheckMode GetCheckMode(string deptCode)
        {
            try
            {
                if (deptCode.IsNullOrEmptyOfVar())
                    throw new Exception("TCPCommon.参数deptCode为空");

                using (var cDbContext = new DbContextContainer(DbKind.MySql, DbName.HCDb)._DataAccess)
                {
                    var deptInfo = cDbContext.Set<Db_Dept>().Where(w => w.DeptCode == deptCode).FirstOrDefault();
                    if (deptInfo == null)
                        throw new Exception("TCPCommon.未找到科室信息");

                    return (CheckMode)Enum.ToObject(typeof(CheckMode), deptInfo.CheckMode);
                }
            }
            catch (Exception e)
            {
                LogModule.Error("TCPCommon.GetCheckMode()异常，异常信息：" + e.Message);
                throw e;
            }
        }

        /// <summary>
        /// 获取病人列表
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="whereQueueStateStr">类似" queuestate in(0,1,2)"</param>
        /// <param name="isFrontCount">是否统计当前报到模式前面排队人数</param>
        /// <param name="roomId"></param>
        /// <param name="patientId"></param>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public virtual List<Db_RegPatientList> GetPatientList(string deptCode, string docCode, string typeCode)
        {
            try
            {
                docCode.IsNullOrEmptyOfVar("docCode");
                deptCode.IsNullOrEmptyOfVar("deptCode");
                typeCode.IsNullOrEmptyOfVar("typeCode");
                using (var dbContext = new DbContextContainer(DbName.HPDb)._DataAccess)
                {
                    var docLoginInfo = dbContext.Set<Db_DoctorLoginInfo>().Where(w => w.DoctorCode == docCode && w.LoginState == "1" && w.DeptCode == deptCode && w.TypeCode == typeCode).FirstOrDefault();
                    if (docLoginInfo == null)
                        throw new Exception("未查询到医生登录信息");
                    CheckMode cm = GetCheckMode(docLoginInfo.DeptCode);
                    var sql = "";
                    if (cm == CheckMode.首诊报到到医生)
                    {
                        return dbContext.Set<Db_RegPatientList>().Where(w => w.RoomId == docLoginInfo.RoomId && w.CheckDoctorCode == docLoginInfo.DoctorCode && w.IsCancel == 0).AsNoTracking().ToList();
                    }
                    if (cm == CheckMode.首诊不报到直接呼叫)
                    {
                        if (docLoginInfo.TypeCode == "1")
                        {
                            sql = string.Format(@"select * from at_regpatientlist 
                                          where RegDeptCode='{0}' and CheckDoctorCode is null and RegTypeCode='1' 
                                          AND IsCancel='0'
                                          UNION ALL
                                          SELECT * from at_regpatientlist where
                                          checkdoctorcode='{1}' and roomid='{2}' and IsCancel=0 ", docLoginInfo, deptCode, docLoginInfo.DoctorCode, docLoginInfo.RoomId);
                        }
                        else
                        {
                            sql = string.Format(@"SELECT * from at_regpatientlist 
                                          WHERE checkdoctorcode='{0}'
                                          AND roomid='{1}'
                                          and iscancel=0", docLoginInfo.DoctorCode, docLoginInfo.RoomId);
                        }
                    }

                    if (cm == CheckMode.首诊报到到科室)
                    {
                        if (docLoginInfo.TypeCode == "1")
                        {
                            sql = string.Format(@" select * from at_regpatientlist
                                                 WHERE CheckDeptCode='{0}'
                                                 and (CheckDoctorCode is null or CheckDoctorCode ='')
                                                 and RegTypeCode = '1'
                                                 and IsCancel = 0
                                                 UNION ALL
                                                 select * from at_regpatientlist
                                                 WHERE CheckDoctorCode='{1}'
                                                 AND RoomId='{2}'
                                                 AND IsCancel=0", docLoginInfo.DeptCode, docLoginInfo.DoctorCode, docLoginInfo.RoomId);
                        }
                        else
                        {
                            sql = string.Format(@"select * from at_regpatientlist 
                                                        where CheckDoctorCode='{0}'
                                                        AND roomid='{1}'
                                                        and IsCancel=0", docLoginInfo.DoctorCode, docLoginInfo.RoomId);
                        }
                    }

                    return dbContext.Database.SqlQuery<Db_RegPatientList>(sql).ToList();
                }
            }
            catch (Exception e)
            {
                LogModule.Error("TCPCommon.GetPatientList()异常，异常信息：" + e.Message);
                throw e;
            }
        }
    }

    public class TCPCommonFactory
    {
        public ITCPCommon TCPCommon { get; set; }
        public TCPCommonFactory(string hospitalCode = null)
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType(Type.GetType("BCL.ToolLibWithApp.TCP.TCPProvider.TCPCommonH" + (hospitalCode ?? "HospitalId".ConfigValue())))
                       .As<ITCPCommon>();
                TCPCommon = builder.Build()
                                   .Resolve<ITCPCommon>();
            }
            catch (Exception e)
            {
                LogModule.Error(e);
                throw new Exception("创建TCPProvider对象失败:" + e.Message);
            }
        }
    }
}
