using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.DataAccess.DbEntity.SSP
{
    /// <summary>
    /// 自助机机器信息
    /// </summary>
    public class Db_Machine
    {
        /// <summary>
        /// 机器号(主键之一)
        /// </summary>
        public string TermId { get; set; }
        /// <summary>
        /// 医院ID(主键之一)
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 操作员ID
        /// </summary>
        public string OperCode { get; set; }
        /// <summary>
        /// 是否每次返回主页的时候都会读取配置信息  如果设置为false每次都往壳里面输入配置信息  
        /// </summary>
        public bool IsParmCache { get; set; }
        /// <summary>
        /// 壳调用的Url
        /// </summary>
        public string WebUrl { get; set; }
        /// <summary>
        /// 自助类型：1.门诊自助机，2.住院自助机,3.报到机 4.呼叫大屏 大致分类,具体详见公用码
        /// </summary>
        public string WebType { get; set; }
        /// <summary>
        /// LOGO图片地址
        /// </summary>
        public string LogoImagePath { get; set; }
        /// <summary>
        /// 语音库配置TTS
        /// </summary>
        public string Speechlib { get; set; }
        /// <summary>
        /// 播音员  如果为空则系统分配默认的第一个播音者
        /// </summary>
        public string Voice { get; set; }
        /// <summary>
        /// 语音音量 最大值100
        /// </summary>
        public int Volume { get; set; }
        /// <summary>
        /// 语音库语速：0 正常语速,0<快速, 慢速<0
        /// </summary>
        public int Rate { get; set; }
        /// <summary>
        /// 电动读卡器类别
        /// </summary>
        public string BCardReaderDevType { get; set; }
        /// <summary>
        /// 电动读卡机端口
        /// </summary>
        public string BCardComAndPort { get; set; }
        /// <summary>
        /// 身份证阅读器类型
        /// </summary>
        public string IdCardDevType { get; set; }
        /// <summary>
        /// 身份证阅读器的端口
        /// </summary>
        public string IdCardDevPort { get; set; }

        /// <summary>
        /// 只有ZT驱动才会用得着  如果为ZT身份证阅读器为1  其它为2
        /// </summary>
        public int nType { get; set; }
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
        public int TimeOut { get; set; }

        /// <summary>
        /// 打印机类别
        /// </summary>
        public string ReceiptPrintDevType { get; set; }
        /// <summary>
        /// 打印机名称--针对串口
        /// </summary>
        public string PrinterName { get; set; }
        /// <summary>
        /// 打印机端口COM2:115200:N:8:1 ReceiptPrintDevType=ZT时需要
        /// </summary>
        public string ReceiptPrintDevPort { get; set; }
        /// <summary>
        ///是否打印凭条 True打印，False不打印
        /// </summary>
        public bool IsPrint { get; set; }
        /// <summary>
        ///是否挂壁挂
        /// </summary>
        public bool IsHangingDev { get; set; }

        /// <summary>
        ///纸张最小高度
        /// </summary>
        public int PaperHeight { get; set; }
        /// <summary>
        ///Lis打印机名字
        /// </summary>
        public string LisPrintName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MedExePath { get; set; }
        /// <summary>
        /// HIS的EXE地址
        /// </summary>
        public string HisExePath { get; set; }

        public string LisExePath { get; set; }

        /// <summary>
        /// 银行的支付  一般为MisPos(该支付只是调用了本地的一个第三方本地的动态库 启动银行操作)
        /// </summary>
        public string PosName { get; set; }
        /// <summary>
        /// 获取HIS命令的组装名字 一般为LZHis
        /// </summary>
        public string HisName { get; set; }
        /// <summary>
        /// 腕带配置 例:JX2
        /// </summary>
        public string WristletConfig { get; set; }

        public string WristletType { get; set; }

        public string PrintStatusType { get; set; }
        /// <summary>
        /// 打印字体大小
        /// </summary>
        public string PrintFontSize { get; set; }
        /// <summary>
        /// 打印机字体类型 默认宋体
        /// </summary>
        public string PrintFontName { get; set; }
    }

    public class Db_MachineMapper : EntityTypeConfiguration<Db_Machine>
    {
        public Db_MachineMapper()
        {
            ToTable("st_machine");
            HasKey(w => new { w.TermId, w.HospitalId });
        }
    }
}
