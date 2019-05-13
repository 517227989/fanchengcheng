using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLib.Enums
{
    public enum ReachName
    {
        已达账,
        未达账,
        部分达账
    }
    public enum SMSKind
    {
        AL,//阿里
        DX,//电信
        YD,//移动
        LT,//联通
        RC,//融创
        OR,//一信通
        JXFBY,//嘉兴妇保院
        JXSDYYY,//嘉兴市第一医院
        JXSDEYY,//嘉兴市第二医院
    }
    public enum Class
    {
        预约费用 = 10,
        挂号费用 = 11,
        处方费用 = 12,
        住院费用 = 13,
        账户费用 = 14,
        营养膳食 = 15,
        体检费用 = 16,
        停车费用 = 17,
        餐厅费用 = 18

    }
    public enum Channel
    {
        门诊窗口 = 10,
        住院窗口 = 11,
        零售窗口 = 12,
        门诊自助 = 13,
        住院自助 = 14,
        门诊诊间 = 15,
        住院病区 = 16,
        App = 17,
        公众号 = 18,
        小程序 = 19,
        生活号 = 20,
        体检窗口 = 21,
        医院停车 = 22,
        餐厅食堂 = 23,
        调度平台 = 98,
        对账平台 = 99

    }
    /// <summary>
    /// 
    /// </summary>
    public enum MethodKind
    {
        GET,
        POST,
        PUT,
        DELETE,
        OPTION
    }
    /// <summary>
    /// 银联交易种类代码
    /// </summary>
    public enum UmsOfKind
    {
        PA,//预付卡余额查询
        PB,//预付卡消费
        PC,//预付卡撤销
        PD,//预付卡充值
        PE,//预付卡退货
        PH,//预付卡交易明细查询
        PI,//预付卡提现
        PK,//预付卡账户信息查询
        PL,//预付卡快速制卡
        PM,//预付卡账户注销
        PN,//预付卡修改账户基本信息
        PQ,//预付卡账户挂失
        PR,//预付卡账户解挂
    }
    /// <summary>
    /// 途径种类
    /// </summary>
    public enum BusKind
    {
        Single = 0,//单一渠道
        Group = 1,//聚合渠道
    }
    /// <summary>
    /// 交易种类名称
    /// </summary>
    public enum KindName
    {
        订单查询 = 0,
        交易退款 = 1,
        订单关闭 = 2,
        扫码支付 = 3,
        窗口支付 = 4,
        刷卡支付 = 5,
        刷卡撤销 = 6,
        网页支付 = 7,
        刷脸支付 = 8,
    }
    /// <summary>
    /// 交易种类
    /// </summary>
    public enum Kind
    {
        Query = 0,
        Refund = 1,
        Cancel = 2,
        Order = 3,
        Charge = 4,
        Into = 5,
        Undo = 6,
        Form = 7,
        FacePay = 8,
    }
    /// <summary>
    /// 交易方式名称
    /// </summary>
    public enum ModeName
    {
        平台 = 0,
        银联 = 1,
        微信 = 2,
        支付宝 = 3,
        账户 = 4,
        工银e支付 = 5,
        翼支付 = 6,
        金银钱包 = 7,
        龙支付 = 8,
        中国银行 = 9,
        银商POS通 = 10,
        中银智慧付 = 11,
        银联商务 = 12,
        银联二维码 = 13,
        嘉一信用卡 = 92,
        兴业银行 = 93,
        健康嘉兴 = 94,
        嘉兴建行 = 95,
        市民卡 = 96,
        嘉兴农行 = 97,
        嘉兴卓健 = 98,
        嘉兴工行 = 99,
    }
    /// <summary>
    /// 交易方式
    /// </summary>
    public enum Mode
    {
        PS = 0,
        UP = 1,
        TX = 2,
        AL = 3,
        AC = 4,
        EP = 5,
        BP = 6,
        GS = 7,
        DP = 8,
        HHAP = 9,
        UPPOS = 10,
        CBOC = 11,
        UMS = 12,
        UPQRC = 13,
        CCBPOS = 95,
        ABCPOS = 97,
        ICBCPOS = 99,
    }
    /// <summary>
    /// 交易状态名称
    /// </summary>
    public enum StateName
    {
        创建订单 = 0,
        订单提交 = 1,
        等待支付 = 2,
        支付成功 = 3,
        订单关闭 = 4,
        订单退款 = 5,
        退款明细 = 6,
        交易结束 = 7,
        退款到账 = 8
    }
    /// <summary>
    /// 交易状态
    /// </summary>
    public enum State
    {
        CREATE = 0,
        SUBMIT = 1,
        WAIT = 2,
        SUCCESS = 3,
        CLOSED = 4,
        REFUND = 5,
        REFUNDDETAIL = 6,
        FINISHED = 7,
        REFUNDED = 8
    }
    /// <summary>
    /// 交易状态
    /// </summary>
    public enum StateOfAL
    {
        WAIT_BUYER_PAY = 1,
        TRADE_SUCCESS = 3,
        TRADE_CLOSED = 4,
        TRADE_FINISHED = 7
    }
    /// <summary>
    /// 交易状态
    /// </summary>
    public enum StateOfTX
    {
        NOTPAY = 1,
        SUCCESS = 3,
        CLOSED = 4,
        REFUND = 5,
        REVOKED = 8,
        USERPAYING = 9,
        PAYERROR = 10
    }
    public enum StateOfEP
    {
        WAIT = 0,
        SUCCESS = 1,
        CLOSED = 2,
    }
    /// <summary>
    /// 交易状态
    /// </summary>
    public enum StateOfUPPOS
    {
        NEW_ORDER = 1,
        WAIT_BUYER_PAY = 2,
        TRADE_SUCCESS = 3,
        TRADE_CLOSED = 4,
        TRADE_REFUND = 5,
    }
    /// <summary>
    /// 返回码
    /// </summary>
    public enum ResCode
    {
        交易成功 = 0,
        入参格式不合法 = 0001,
        未注册的交易 = 0002,
        交易异常 = 1001,
        业务错误 = 3001,
        需要用户输入密码 = 3002,
        未找到需退款记录 = 3003,
        退款已完成 = 3004,
        交易不确定请发起查询 = 3005,
        医院接口错误 = 3100,
        医院业务错误 = 3101,
        医保接口错误 = 5100,
        医保业务错误 = 5101,
        支付接口错误 = 6100,
        支付业务错误 = 6101,
        银联接口错误 = 6200,
        银联业务错误 = 6201,
        刷脸接口错误 = 7100,
        刷脸业务错误 = 7101,
    }
    /// <summary>
    /// 账单状态
    /// </summary>
    public enum IsExceptionName
    {
        补退 = -6,
        跨天 = -5,
        调账 = -4,
        隔日退款 = -3,
        当日退款 = -2,
        金额不一致 = -1,
        账平 = 0,
        单边账 = 1
    }
    /// <summary>
    /// 账单支付类型
    /// </summary>
    public enum TradeTypeName
    {
        收费 = 1,
        退费 = -1
    }
}
