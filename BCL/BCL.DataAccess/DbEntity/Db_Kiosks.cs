using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
/*
 * Create By:Hui.Liu
 * Create Date:2017-11-14
 * Des:
 * 自助机相关配置项目
 */
namespace BCL.DataAccess
{
   public class Db_Kiosks
    {
       /// <summary>
       /// 主键Id
       /// </summary>
       public int Id { get; set; }
        /// <summary>
        /// 医院ID
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 自助机ID
        /// </summary>
        public string KioskId { get; set; }
        /// <summary>
        /// 操作员ID
        /// </summary>
        public string OperCode { get; set; }
        /// <summary>
        /// 壳调用的Url
        /// </summary>
        public string WebUrl { get; set; }
        /// <summary>
        /// 自助类型：1.门诊自助机，2.住院自助机,3.报到机 4.呼叫大屏 大致分类,具体详见公用码
        /// </summary>
        public string WebType { get; set; }
        /// <summary>
        /// 语音库配置TTS
        /// </summary>
        public string Speechlib { get; set; }
        /// <summary>
        /// 语音音量 最大值100
        /// </summary>
        public int Volume { get; set; }
        /// <summary>
        /// 语音库语速：0 正常语速,0<快速, 慢速<0
        /// </summary>
        public int Rate { get; set; }
        /// <summary>
        /// 监测服务器Ip
        /// </summary>
        public string ServerIp { get; set; }
        /// <summary>
        /// 监测服务器端口
        /// </summary>
        public string ServerPort { get; set; }
        /// <summary>
        /// 监测过期时间
        /// </summary>
        public string TimeOut { get; set; }
        /// <summary>
        /// 身份证阅读器类型
        /// </summary>
        public string IdCardDevType { get; set; }
        /// <summary>
        /// 身份证阅读器的端口
        /// </summary>
        public string IdCardDevPort { get; set; }
        /// <summary>
        /// 打印机类别
        /// </summary>
        public string ReceiptPrintDevType { get; set; }
        /// <summary>
        /// 打印机名称--针对串口
        /// </summary>
        public string PrinterName { get; set; }
        /// <summary>
        /// 打印机端口
        /// </summary>
        public string ReceiptPrintDevPort { get; set; }
        /// <summary>
        /// 守护程序名称
        /// </summary>
        public string ProcName { get; set; }
        /// <summary>
       /// 电动读卡器类别
       /// </summary>
        public string BCardReaderDevType { get; set;}
        /// <summary>
       /// 电动读卡机端口
       /// </summary>
        public string BCardReaderDevPort { get; set; }

        //关机时间
        public string ShutdownTime { get; set; }

    }

   public class Db_KiosksMapper : EntityTypeConfiguration<Db_Kiosks>
   {
       public Db_KiosksMapper()
       {
           ToTable("ct_kiosks");
           HasKey(w => w.Id);

       }
   }
}
