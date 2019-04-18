using BCL.ToolLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.ESBProvider
{
    [ServiceContract]
    public partial interface IHisApplay
    {
        [OperationContract]
        string RunService(string TradeType, string TradeMsg);
    }
    public class HisProviderH00034 : HisProvider
    {
        internal IHisApplay _HISClient { get; set; }
        internal static WebServiceAgent WS = new WebServiceAgent("HisUrl".ConfigValue());
        public HisProviderH00034()
        {
            if (_HISClient == null)
                _HISClient = new RequestWsProvider<IHisApplay>("H" + _HOSPITALID).ReqClient;
        }
        public override string Business(params object[] args)
        {
            return OnBusiness(o =>
            {
                if (args.Contains("PD")) //门诊排队
                {
                    var _Client = new RequestWsProvider<QueueServiceInterface>("H" + _HOSPITALID + "_QS").ReqClient;
                    var res = _Client.GetQueueList(new GetQueueListRequest()
                    {
                        GetQueueList = new GetQueueList()
                        {
                            inparm = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.GetQueueListResponse != null)
                            return res.GetQueueListResponse.outparm;
                    }
                    return null;
                }
                else if (args.Contains("PDM")) //门诊排队明细
                {
                    var _Client = new RequestWsProvider<QueueServiceInterface>("H" + _HOSPITALID + "_QS").ReqClient;
                    var res = _Client.GetQueueListDetail(new GetQueueListDetailRequest()
                    {
                        GetQueueListDetail = new GetQueueListDetail()
                        {
                            inparm = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.GetQueueListDetailResponse != null)
                            return res.GetQueueListDetailResponse.outparm;
                    }
                    return null;
                }
                else if (args.Contains("JC")) //病理检查报告
                {
                    var _Client = new RequestWsProvider<InspectionReportServiceInterface>("H" + _HOSPITALID + "_IRS").ReqClient;
                    var res = _Client.GetCytologyReport(new GetCytologyReportRequest()
                    {
                        GetCytologyReport = new GetCytologyReport()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.GetCytologyReportResponse != null)
                            return res.GetCytologyReportResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("JY")) //检验
                {
                    var _Client = new RequestWsProvider<InspectionReportServiceInterface>("H" + _HOSPITALID + "_IRS").ReqClient;
                    var res = _Client.GetLisReport(new GetLisReportRequest()
                    {
                        GetLisReport = new GetLisReport()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.GetLisReportResponse != null)
                            return res.GetLisReportResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("JYMX")) //检验明细
                {
                    var _Client = new RequestWsProvider<InspectionReportServiceInterface>("H" + _HOSPITALID + "_IRS").ReqClient;
                    var res = _Client.GetLisResult(new GetLisResultRequest()
                    {
                        GetLisResult = new GetLisResult()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.GetLisResultResponse != null)
                            return res.GetLisResultResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("CS")) //彩色超声检查
                {
                    var _Client = new RequestWsProvider<InspectionReportServiceInterface>("H" + _HOSPITALID + "_IRS").ReqClient;
                    var res = _Client.GetBcReport(new GetBcReportRequest()
                    {
                        GetBcReport = new GetBcReport()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.GetBcReportResponse != null)
                            return res.GetBcReportResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("FS")) //放射科影像检查
                {
                    var _Client = new RequestWsProvider<InspectionReportServiceInterface>("H" + _HOSPITALID + "_IRS").ReqClient;
                    var res = _Client.GetRisReport(new GetRisReportRequest()
                    {
                        GetRisReport = new GetRisReport()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.GetRisReportResponse != null)
                            return res.GetRisReportResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("XQ")) //血清学产前筛查结果
                {
                    var _Client = new RequestWsProvider<InspectionReportServiceInterface>("H" + _HOSPITALID + "_IRS").ReqClient;
                    var res = _Client.GetCqscReport(new GetCqscReportRequest()
                    {
                        GetCqscReport = new GetCqscReport()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.GetCqscReportResponse != null)
                            return res.GetCqscReportResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("SFYZ")) //身份验证
                {
                    var _Client = new RequestWsProvider<HealthCardService>("H" + _HOSPITALID + "_HCS").ReqClient;
                    var getAuthKey = args[0] as getAuthKey;
                    var res = _Client.getAuthKey(getAuthKey);
                    if (res != null)
                    {
                        if (res.@return != null)
                            return res.ToJson();
                    }
                    return null;
                }
                else if (args.Contains("JD")) //建档
                {
                    var _Client = new RequestWsProvider<HealthCardService>("H" + _HOSPITALID + "_HCS").ReqClient;
                    var syncCardInfo = args[0] as syncCardInfo;
                    var res = _Client.syncCardInfo(syncCardInfo);
                    if (res != null)
                    {
                        if (res.@return != null)
                            return res.ToJson();
                    }
                    return null;
                }
                else if (args.Contains("RWMCX")) //二维码查询
                {
                    var _Client = new RequestWsProvider<HealthCardService>("H" + _HOSPITALID + "_HCS").ReqClient;
                    var virIdCardVerify = args[0] as virIdCardVerify;
                    var res = _Client.virIdCardVerify(virIdCardVerify);
                    if (res != null)
                    {
                        if (res.@return != null)
                            return res.ToJson();
                    }
                    return null;
                }
                else if (args.Contains("OS"))
                {
                    var _Client = new RequestWsProvider<OperationServiceInterface>("H" + _HOSPITALID + "_OS").ReqClient;
                    var res = _Client.GetOperationStatus(new GetOperationStatusRequest()
                    {
                        GetOperationStatus = new GetOperationStatus()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.GetOperationStatusResponse != null)
                            return res.GetOperationStatusResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("TJLB"))
                {
                    var _Client = new RequestWsProvider<TiJianServicesInterface>("H" + _HOSPITALID + "_TJS").ReqClient;
                    var res = _Client.tijianlb(new tijianlbRequest()
                    {
                        tijianlb = new tijianlb()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.tijianlbResponse != null)
                            return res.tijianlbResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("TJHP"))
                {
                    var _Client = new RequestWsProvider<TiJianServicesInterface>("H" + _HOSPITALID + "_TJS").ReqClient;
                    var res = _Client.tijianbgfm(new tijianbgfmRequest()
                    {
                        tijianbgfm = new tijianbgfm()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.tijianbgfmResponse != null)
                            return res.tijianbgfmResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("TJTC"))
                {
                    var _Client = new RequestWsProvider<TiJianServicesInterface>("H" + _HOSPITALID + "_TJS").ReqClient;
                    var res = _Client.tijianbcfsxmjg(new tijianbcfsxmjgRequest()
                    {
                        tijianbcfsxmjg = new tijianbcfsxmjg()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.tijianbcfsxmjgResponse != null)
                            return res.tijianbcfsxmjgResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("TJJY"))
                {
                    var _Client = new RequestWsProvider<TiJianServicesInterface>("H" + _HOSPITALID + "_TJS").ReqClient;
                    var res = _Client.tijianjyxmjg(new tijianjyxmjgRequest()
                    {
                        tijianjyxmjg = new tijianjyxmjg()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.tijianjyxmjgResponse != null)
                            return res.tijianjyxmjgResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("TJJC"))
                {
                    var _Client = new RequestWsProvider<TiJianServicesInterface>("H" + _HOSPITALID + "_TJS").ReqClient;
                    var res = _Client.tijianxmjg(new tijianxmjgRequest()
                    {
                        tijianxmjg = new tijianxmjg()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.tijianxmjgResponse != null)
                            return res.tijianxmjgResponse.output;
                    }
                    return null;
                }
                else if (args.Contains("TJZD"))
                {
                    var _Client = new RequestWsProvider<TiJianServicesInterface>("H" + _HOSPITALID + "_TJS").ReqClient;
                    var res = _Client.tijianzd(new tijianzdRequest()
                    {
                        tijianzd = new tijianzd()
                        {
                            input = args[0].ToString()
                        }
                    });
                    if (res != null)
                    {
                        if (res.tijianzdResponse != null)
                            return res.tijianzdResponse.output;
                    }
                    return null;
                }
                else
                {
                    var x = _HISClient.RunService(o[0].ToString(), o[1].ToString());
                    return x;
                }
            }, args);
        }
    }


    #region QueueClient
    //------------------------------------------------------------------------------
    // <auto-generated>
    //     此代码由工具生成。
    //     运行时版本:4.0.30319.36415
    //
    //     对此文件的更改可能会导致不正确的行为，并且如果
    //     重新生成代码，这些更改将会丢失。
    // </auto-generated>
    //------------------------------------------------------------------------------
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [ServiceContract(Namespace = "http://www.apusic.com/esb/QueueService")]
    public interface QueueServiceInterface
    {

        // CODEGEN: 操作 GetQueueList 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/QueueService/GetQueueList", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        GetQueueListResponse1 GetQueueList(GetQueueListRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/QueueService/GetQueueList", ReplyAction = "*")]
        System.Threading.Tasks.Task<GetQueueListResponse1> GetQueueListAsync(GetQueueListRequest request);

        // CODEGEN: 操作 GetQueueListDetail 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/QueueService/GetQueueListDetail", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        GetQueueListDetailResponse1 GetQueueListDetail(GetQueueListDetailRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/QueueService/GetQueueListDetail", ReplyAction = "*")]
        System.Threading.Tasks.Task<GetQueueListDetailResponse1> GetQueueListDetailAsync(GetQueueListDetailRequest request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/QueueService")]
    public partial class GetQueueList : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inparmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string inparm
        {
            get
            {
                return this.inparmField;
            }
            set
            {
                this.inparmField = value;
                this.RaisePropertyChanged("inparm");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/QueueService")]
    public partial class GetQueueListDetailResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outparmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string outparm
        {
            get
            {
                return this.outparmField;
            }
            set
            {
                this.outparmField = value;
                this.RaisePropertyChanged("outparm");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/QueueService")]
    public partial class GetQueueListDetail : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inparmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string inparm
        {
            get
            {
                return this.inparmField;
            }
            set
            {
                this.inparmField = value;
                this.RaisePropertyChanged("inparm");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/QueueService")]
    public partial class GetQueueListResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outparmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string outparm
        {
            get
            {
                return this.outparmField;
            }
            set
            {
                this.outparmField = value;
                this.RaisePropertyChanged("outparm");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetQueueListRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/QueueService", Order = 0)]
        public GetQueueList GetQueueList;

        public GetQueueListRequest()
        {
        }

        public GetQueueListRequest(GetQueueList GetQueueList)
        {
            this.GetQueueList = GetQueueList;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetQueueListResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/QueueService", Order = 0)]
        public GetQueueListResponse GetQueueListResponse;

        public GetQueueListResponse1()
        {
        }

        public GetQueueListResponse1(GetQueueListResponse GetQueueListResponse)
        {
            this.GetQueueListResponse = GetQueueListResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetQueueListDetailRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/QueueService", Order = 0)]
        public GetQueueListDetail GetQueueListDetail;

        public GetQueueListDetailRequest()
        {
        }

        public GetQueueListDetailRequest(GetQueueListDetail GetQueueListDetail)
        {
            this.GetQueueListDetail = GetQueueListDetail;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetQueueListDetailResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/QueueService", Order = 0)]
        public GetQueueListDetailResponse GetQueueListDetailResponse;

        public GetQueueListDetailResponse1()
        {
        }

        public GetQueueListDetailResponse1(GetQueueListDetailResponse GetQueueListDetailResponse)
        {
            this.GetQueueListDetailResponse = GetQueueListDetailResponse;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface QueueServiceInterfaceChannel : QueueServiceInterface, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class QueueServiceInterfaceClient : System.ServiceModel.ClientBase<QueueServiceInterface>, QueueServiceInterface
    {

        public QueueServiceInterfaceClient()
        {
        }

        public QueueServiceInterfaceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public QueueServiceInterfaceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public QueueServiceInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public QueueServiceInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GetQueueListResponse1 QueueServiceInterface.GetQueueList(GetQueueListRequest request)
        {
            return base.Channel.GetQueueList(request);
        }

        public GetQueueListResponse GetQueueList(GetQueueList GetQueueList1)
        {
            GetQueueListRequest inValue = new GetQueueListRequest();
            inValue.GetQueueList = GetQueueList1;
            GetQueueListResponse1 retVal = ((QueueServiceInterface)(this)).GetQueueList(inValue);
            return retVal.GetQueueListResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GetQueueListResponse1> QueueServiceInterface.GetQueueListAsync(GetQueueListRequest request)
        {
            return base.Channel.GetQueueListAsync(request);
        }

        public System.Threading.Tasks.Task<GetQueueListResponse1> GetQueueListAsync(GetQueueList GetQueueList)
        {
            GetQueueListRequest inValue = new GetQueueListRequest();
            inValue.GetQueueList = GetQueueList;
            return ((QueueServiceInterface)(this)).GetQueueListAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GetQueueListDetailResponse1 QueueServiceInterface.GetQueueListDetail(GetQueueListDetailRequest request)
        {
            return base.Channel.GetQueueListDetail(request);
        }

        public GetQueueListDetailResponse GetQueueListDetail(GetQueueListDetail GetQueueListDetail1)
        {
            GetQueueListDetailRequest inValue = new GetQueueListDetailRequest();
            inValue.GetQueueListDetail = GetQueueListDetail1;
            GetQueueListDetailResponse1 retVal = ((QueueServiceInterface)(this)).GetQueueListDetail(inValue);
            return retVal.GetQueueListDetailResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GetQueueListDetailResponse1> QueueServiceInterface.GetQueueListDetailAsync(GetQueueListDetailRequest request)
        {
            return base.Channel.GetQueueListDetailAsync(request);
        }

        public System.Threading.Tasks.Task<GetQueueListDetailResponse1> GetQueueListDetailAsync(GetQueueListDetail GetQueueListDetail)
        {
            GetQueueListDetailRequest inValue = new GetQueueListDetailRequest();
            inValue.GetQueueListDetail = GetQueueListDetail;
            return ((QueueServiceInterface)(this)).GetQueueListDetailAsync(inValue);
        }
    }

    #endregion

    #region 检查 InspectionReportService
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public interface InspectionReportServiceInterface
    {

        // CODEGEN: 操作 GetCytologyReport 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetCytologyReport", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        GetCytologyReportResponse1 GetCytologyReport(GetCytologyReportRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetCytologyReport", ReplyAction = "*")]
        System.Threading.Tasks.Task<GetCytologyReportResponse1> GetCytologyReportAsync(GetCytologyReportRequest request);

        // CODEGEN: 操作 GetRisReport 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetRisReport", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        GetRisReportResponse1 GetRisReport(GetRisReportRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetRisReport", ReplyAction = "*")]
        System.Threading.Tasks.Task<GetRisReportResponse1> GetRisReportAsync(GetRisReportRequest request);

        // CODEGEN: 操作 GetBcReport 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetBcReport", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        GetBcReportResponse1 GetBcReport(GetBcReportRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetBcReport", ReplyAction = "*")]
        System.Threading.Tasks.Task<GetBcReportResponse1> GetBcReportAsync(GetBcReportRequest request);

        // CODEGEN: 操作 GetCqscReport 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetCqscReport", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        GetCqscReportResponse1 GetCqscReport(GetCqscReportRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetCqscReport", ReplyAction = "*")]
        System.Threading.Tasks.Task<GetCqscReportResponse1> GetCqscReportAsync(GetCqscReportRequest request);

        // CODEGEN: 操作 GetLisReport 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetLisReport", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        GetLisReportResponse1 GetLisReport(GetLisReportRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetLisReport", ReplyAction = "*")]
        System.Threading.Tasks.Task<GetLisReportResponse1> GetLisReportAsync(GetLisReportRequest request);

        // CODEGEN: 操作 GetLisResult 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetLisResult", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        GetLisResultResponse1 GetLisResult(GetLisResultRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/InspectionReportService/GetLisResult", ReplyAction = "*")]
        System.Threading.Tasks.Task<GetLisResultResponse1> GetLisResultAsync(GetLisResultRequest request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetCytologyReport : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetLisResultResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetLisResult : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetLisReportResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetLisReport : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetCqscReportResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetCqscReport : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetBcReportResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetBcReport : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetRisReportResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetRisReport : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService")]
    public partial class GetCytologyReportResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetCytologyReportRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetCytologyReport GetCytologyReport;

        public GetCytologyReportRequest()
        {
        }

        public GetCytologyReportRequest(GetCytologyReport GetCytologyReport)
        {
            this.GetCytologyReport = GetCytologyReport;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetCytologyReportResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetCytologyReportResponse GetCytologyReportResponse;

        public GetCytologyReportResponse1()
        {
        }

        public GetCytologyReportResponse1(GetCytologyReportResponse GetCytologyReportResponse)
        {
            this.GetCytologyReportResponse = GetCytologyReportResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetRisReportRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetRisReport GetRisReport;

        public GetRisReportRequest()
        {
        }

        public GetRisReportRequest(GetRisReport GetRisReport)
        {
            this.GetRisReport = GetRisReport;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetRisReportResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetRisReportResponse GetRisReportResponse;

        public GetRisReportResponse1()
        {
        }

        public GetRisReportResponse1(GetRisReportResponse GetRisReportResponse)
        {
            this.GetRisReportResponse = GetRisReportResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetBcReportRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetBcReport GetBcReport;

        public GetBcReportRequest()
        {
        }

        public GetBcReportRequest(GetBcReport GetBcReport)
        {
            this.GetBcReport = GetBcReport;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetBcReportResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetBcReportResponse GetBcReportResponse;

        public GetBcReportResponse1()
        {
        }

        public GetBcReportResponse1(GetBcReportResponse GetBcReportResponse)
        {
            this.GetBcReportResponse = GetBcReportResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetCqscReportRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetCqscReport GetCqscReport;

        public GetCqscReportRequest()
        {
        }

        public GetCqscReportRequest(GetCqscReport GetCqscReport)
        {
            this.GetCqscReport = GetCqscReport;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetCqscReportResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetCqscReportResponse GetCqscReportResponse;

        public GetCqscReportResponse1()
        {
        }

        public GetCqscReportResponse1(GetCqscReportResponse GetCqscReportResponse)
        {
            this.GetCqscReportResponse = GetCqscReportResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetLisReportRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetLisReport GetLisReport;

        public GetLisReportRequest()
        {
        }

        public GetLisReportRequest(GetLisReport GetLisReport)
        {
            this.GetLisReport = GetLisReport;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetLisReportResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetLisReportResponse GetLisReportResponse;

        public GetLisReportResponse1()
        {
        }

        public GetLisReportResponse1(GetLisReportResponse GetLisReportResponse)
        {
            this.GetLisReportResponse = GetLisReportResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetLisResultRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetLisResult GetLisResult;

        public GetLisResultRequest()
        {
        }

        public GetLisResultRequest(GetLisResult GetLisResult)
        {
            this.GetLisResult = GetLisResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetLisResultResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/InspectionReportService", Order = 0)]
        public GetLisResultResponse GetLisResultResponse;

        public GetLisResultResponse1()
        {
        }

        public GetLisResultResponse1(GetLisResultResponse GetLisResultResponse)
        {
            this.GetLisResultResponse = GetLisResultResponse;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface InspectionReportServiceInterfaceChannel : InspectionReportServiceInterface, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InspectionReportServiceInterfaceClient : System.ServiceModel.ClientBase<InspectionReportServiceInterface>, InspectionReportServiceInterface
    {

        public InspectionReportServiceInterfaceClient()
        {
        }

        public InspectionReportServiceInterfaceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public InspectionReportServiceInterfaceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public InspectionReportServiceInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public InspectionReportServiceInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GetCytologyReportResponse1 InspectionReportServiceInterface.GetCytologyReport(GetCytologyReportRequest request)
        {
            return base.Channel.GetCytologyReport(request);
        }

        public GetCytologyReportResponse GetCytologyReport(GetCytologyReport GetCytologyReport1)
        {
            GetCytologyReportRequest inValue = new GetCytologyReportRequest();
            inValue.GetCytologyReport = GetCytologyReport1;
            GetCytologyReportResponse1 retVal = ((InspectionReportServiceInterface)(this)).GetCytologyReport(inValue);
            return retVal.GetCytologyReportResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GetCytologyReportResponse1> InspectionReportServiceInterface.GetCytologyReportAsync(GetCytologyReportRequest request)
        {
            return base.Channel.GetCytologyReportAsync(request);
        }

        public System.Threading.Tasks.Task<GetCytologyReportResponse1> GetCytologyReportAsync(GetCytologyReport GetCytologyReport)
        {
            GetCytologyReportRequest inValue = new GetCytologyReportRequest();
            inValue.GetCytologyReport = GetCytologyReport;
            return ((InspectionReportServiceInterface)(this)).GetCytologyReportAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GetRisReportResponse1 InspectionReportServiceInterface.GetRisReport(GetRisReportRequest request)
        {
            return base.Channel.GetRisReport(request);
        }

        public GetRisReportResponse GetRisReport(GetRisReport GetRisReport1)
        {
            GetRisReportRequest inValue = new GetRisReportRequest();
            inValue.GetRisReport = GetRisReport1;
            GetRisReportResponse1 retVal = ((InspectionReportServiceInterface)(this)).GetRisReport(inValue);
            return retVal.GetRisReportResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GetRisReportResponse1> InspectionReportServiceInterface.GetRisReportAsync(GetRisReportRequest request)
        {
            return base.Channel.GetRisReportAsync(request);
        }

        public System.Threading.Tasks.Task<GetRisReportResponse1> GetRisReportAsync(GetRisReport GetRisReport)
        {
            GetRisReportRequest inValue = new GetRisReportRequest();
            inValue.GetRisReport = GetRisReport;
            return ((InspectionReportServiceInterface)(this)).GetRisReportAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GetBcReportResponse1 InspectionReportServiceInterface.GetBcReport(GetBcReportRequest request)
        {
            return base.Channel.GetBcReport(request);
        }

        public GetBcReportResponse GetBcReport(GetBcReport GetBcReport1)
        {
            GetBcReportRequest inValue = new GetBcReportRequest();
            inValue.GetBcReport = GetBcReport1;
            GetBcReportResponse1 retVal = ((InspectionReportServiceInterface)(this)).GetBcReport(inValue);
            return retVal.GetBcReportResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GetBcReportResponse1> InspectionReportServiceInterface.GetBcReportAsync(GetBcReportRequest request)
        {
            return base.Channel.GetBcReportAsync(request);
        }

        public System.Threading.Tasks.Task<GetBcReportResponse1> GetBcReportAsync(GetBcReport GetBcReport)
        {
            GetBcReportRequest inValue = new GetBcReportRequest();
            inValue.GetBcReport = GetBcReport;
            return ((InspectionReportServiceInterface)(this)).GetBcReportAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GetCqscReportResponse1 InspectionReportServiceInterface.GetCqscReport(GetCqscReportRequest request)
        {
            return base.Channel.GetCqscReport(request);
        }

        public GetCqscReportResponse GetCqscReport(GetCqscReport GetCqscReport1)
        {
            GetCqscReportRequest inValue = new GetCqscReportRequest();
            inValue.GetCqscReport = GetCqscReport1;
            GetCqscReportResponse1 retVal = ((InspectionReportServiceInterface)(this)).GetCqscReport(inValue);
            return retVal.GetCqscReportResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GetCqscReportResponse1> InspectionReportServiceInterface.GetCqscReportAsync(GetCqscReportRequest request)
        {
            return base.Channel.GetCqscReportAsync(request);
        }

        public System.Threading.Tasks.Task<GetCqscReportResponse1> GetCqscReportAsync(GetCqscReport GetCqscReport)
        {
            GetCqscReportRequest inValue = new GetCqscReportRequest();
            inValue.GetCqscReport = GetCqscReport;
            return ((InspectionReportServiceInterface)(this)).GetCqscReportAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GetLisReportResponse1 InspectionReportServiceInterface.GetLisReport(GetLisReportRequest request)
        {
            return base.Channel.GetLisReport(request);
        }

        public GetLisReportResponse GetLisReport(GetLisReport GetLisReport1)
        {
            GetLisReportRequest inValue = new GetLisReportRequest();
            inValue.GetLisReport = GetLisReport1;
            GetLisReportResponse1 retVal = ((InspectionReportServiceInterface)(this)).GetLisReport(inValue);
            return retVal.GetLisReportResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GetLisReportResponse1> InspectionReportServiceInterface.GetLisReportAsync(GetLisReportRequest request)
        {
            return base.Channel.GetLisReportAsync(request);
        }

        public System.Threading.Tasks.Task<GetLisReportResponse1> GetLisReportAsync(GetLisReport GetLisReport)
        {
            GetLisReportRequest inValue = new GetLisReportRequest();
            inValue.GetLisReport = GetLisReport;
            return ((InspectionReportServiceInterface)(this)).GetLisReportAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GetLisResultResponse1 InspectionReportServiceInterface.GetLisResult(GetLisResultRequest request)
        {
            return base.Channel.GetLisResult(request);
        }

        public GetLisResultResponse GetLisResult(GetLisResult GetLisResult1)
        {
            GetLisResultRequest inValue = new GetLisResultRequest();
            inValue.GetLisResult = GetLisResult1;
            GetLisResultResponse1 retVal = ((InspectionReportServiceInterface)(this)).GetLisResult(inValue);
            return retVal.GetLisResultResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GetLisResultResponse1> InspectionReportServiceInterface.GetLisResultAsync(GetLisResultRequest request)
        {
            return base.Channel.GetLisResultAsync(request);
        }

        public System.Threading.Tasks.Task<GetLisResultResponse1> GetLisResultAsync(GetLisResult GetLisResult)
        {
            GetLisResultRequest inValue = new GetLisResultRequest();
            inValue.GetLisResult = GetLisResult;
            return ((InspectionReportServiceInterface)(this)).GetLisResultAsync(inValue);
        }
    }
    #endregion

    #region 电子健康卡

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public interface HealthCardService
    {

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        getInfoYwResponse getInfoYw(getInfoYw request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<getInfoYwResponse> getInfoYwAsync(getInfoYw request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        blackSamVerifyResponse blackSamVerify(blackSamVerify request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<blackSamVerifyResponse> blackSamVerifyAsync(blackSamVerify request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        getYhkhStatusResponse getYhkhStatus(getYhkhStatus request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<getYhkhStatusResponse> getYhkhStatusAsync(getYhkhStatus request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        modifyCardInfoResponse modifyCardInfo(modifyCardInfo request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<modifyCardInfoResponse> modifyCardInfoAsync(modifyCardInfo request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        downQrResponse downQr(downQr request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<downQrResponse> downQrAsync(downQr request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        publishPoorPeopleResponse publishPoorPeople(publishPoorPeople request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<publishPoorPeopleResponse> publishPoorPeopleAsync(publishPoorPeople request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        repairChangCardResponse repairChangCard(repairChangCard request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<repairChangCardResponse> repairChangCardAsync(repairChangCard request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        cardVerifyResponse cardVerify(cardVerify request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<cardVerifyResponse> cardVerifyAsync(cardVerify request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        sfzhmVerifyResponse sfzhmVerify(sfzhmVerify request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<sfzhmVerifyResponse> sfzhmVerifyAsync(sfzhmVerify request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        getXnhkhResponse getXnhkh(getXnhkh request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<getXnhkhResponse> getXnhkhAsync(getXnhkh request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        getCardInfoResponse getCardInfo(getCardInfo request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<getCardInfoResponse> getCardInfoAsync(getCardInfo request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        virIdCardVerifyResponse virIdCardVerify(virIdCardVerify request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<virIdCardVerifyResponse> virIdCardVerifyAsync(virIdCardVerify request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        poorPeopleVerifyResponse poorPeopleVerify(poorPeopleVerify request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<poorPeopleVerifyResponse> poorPeopleVerifyAsync(poorPeopleVerify request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        operatorLogResponse operatorLog(operatorLog request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<operatorLogResponse> operatorLogAsync(operatorLog request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        syncCardInfoResponse syncCardInfo(syncCardInfo request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<syncCardInfoResponse> syncCardInfoAsync(syncCardInfo request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        modifyPeopleInfoResponse modifyPeopleInfo(modifyPeopleInfo request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<modifyPeopleInfoResponse> modifyPeopleInfoAsync(modifyPeopleInfo request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        getInfoResponse getInfo(getInfo request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<getInfoResponse> getInfoAsync(getInfo request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        getXpxlhYhkhResponse getXpxlhYhkh(getXpxlhYhkh request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<getXpxlhYhkhResponse> getXpxlhYhkhAsync(getXpxlhYhkh request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        syncCardStatusResponse syncCardStatus(syncCardStatus request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<syncCardStatusResponse> syncCardStatusAsync(syncCardStatus request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        publishBlackCardResponse publishBlackCard(publishBlackCard request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<publishBlackCardResponse> publishBlackCardAsync(publishBlackCard request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        getAuthKeyResponse getAuthKey(getAuthKey request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<getAuthKeyResponse> getAuthKeyAsync(getAuthKey request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        publishBlackSamResponse publishBlackSam(publishBlackSam request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<publishBlackSamResponse> publishBlackSamAsync(publishBlackSam request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        identifyPersonResponse identifyPerson(identifyPerson request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<identifyPersonResponse> identifyPersonAsync(identifyPerson request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        updateCardTypeResponse updateCardType(updateCardType request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<updateCardTypeResponse> updateCardTypeAsync(updateCardType request);

        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(allergyInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(linkmanInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(vaccineInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(expenseTypeVo[]))]
        [return: System.ServiceModel.MessageParameterAttribute(Name = "return")]
        updateCardInfoResponse updateCardInfo(updateCardInfo request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<updateCardInfoResponse> updateCardInfoAsync(updateCardInfo request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class cardInfoResult : WSResult
    {

        private pCard[] cardInfoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("cardInfo", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public pCard[] cardInfo
        {
            get
            {
                return this.cardInfoField;
            }
            set
            {
                this.cardInfoField = value;
                this.RaisePropertyChanged("cardInfo");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class pCard : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string khField;

        private people peopleInfoField;

        private string aqmField;

        private string fksjField;

        private string klxField;

        private string orgCodeField;

        private string gfbbField;

        private string fkxlhField;

        private string yycsdmField;

        private string xpxlhField;

        private string yhkhField;

        private string jkkztField;

        private string issuingModeField;

        private string bankCodeField;

        private string isRealNameField;

        private string terminalTypeField;

        private string qrTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string kh
        {
            get
            {
                return this.khField;
            }
            set
            {
                this.khField = value;
                this.RaisePropertyChanged("kh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public people peopleInfo
        {
            get
            {
                return this.peopleInfoField;
            }
            set
            {
                this.peopleInfoField = value;
                this.RaisePropertyChanged("peopleInfo");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string aqm
        {
            get
            {
                return this.aqmField;
            }
            set
            {
                this.aqmField = value;
                this.RaisePropertyChanged("aqm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string fksj
        {
            get
            {
                return this.fksjField;
            }
            set
            {
                this.fksjField = value;
                this.RaisePropertyChanged("fksj");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string klx
        {
            get
            {
                return this.klxField;
            }
            set
            {
                this.klxField = value;
                this.RaisePropertyChanged("klx");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        public string orgCode
        {
            get
            {
                return this.orgCodeField;
            }
            set
            {
                this.orgCodeField = value;
                this.RaisePropertyChanged("orgCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 6)]
        public string gfbb
        {
            get
            {
                return this.gfbbField;
            }
            set
            {
                this.gfbbField = value;
                this.RaisePropertyChanged("gfbb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 7)]
        public string fkxlh
        {
            get
            {
                return this.fkxlhField;
            }
            set
            {
                this.fkxlhField = value;
                this.RaisePropertyChanged("fkxlh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 8)]
        public string yycsdm
        {
            get
            {
                return this.yycsdmField;
            }
            set
            {
                this.yycsdmField = value;
                this.RaisePropertyChanged("yycsdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 9)]
        public string xpxlh
        {
            get
            {
                return this.xpxlhField;
            }
            set
            {
                this.xpxlhField = value;
                this.RaisePropertyChanged("xpxlh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 10)]
        public string yhkh
        {
            get
            {
                return this.yhkhField;
            }
            set
            {
                this.yhkhField = value;
                this.RaisePropertyChanged("yhkh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 11)]
        public string jkkzt
        {
            get
            {
                return this.jkkztField;
            }
            set
            {
                this.jkkztField = value;
                this.RaisePropertyChanged("jkkzt");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 12)]
        public string issuingMode
        {
            get
            {
                return this.issuingModeField;
            }
            set
            {
                this.issuingModeField = value;
                this.RaisePropertyChanged("issuingMode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 13)]
        public string bankCode
        {
            get
            {
                return this.bankCodeField;
            }
            set
            {
                this.bankCodeField = value;
                this.RaisePropertyChanged("bankCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 14)]
        public string isRealName
        {
            get
            {
                return this.isRealNameField;
            }
            set
            {
                this.isRealNameField = value;
                this.RaisePropertyChanged("isRealName");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 15)]
        public string terminalType
        {
            get
            {
                return this.terminalTypeField;
            }
            set
            {
                this.terminalTypeField = value;
                this.RaisePropertyChanged("terminalType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 16)]
        public string qrType
        {
            get
            {
                return this.qrTypeField;
            }
            set
            {
                this.qrTypeField = value;
                this.RaisePropertyChanged("qrType");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class people : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string zjlxField;

        private string zjhmField;

        private string jkdahField;

        private string xnhkhField;

        private string jzkkhField;

        private string sfzhmField;

        private string ylfyzffsField;

        private string xmField;

        private string csrqField;

        private string xbField;

        private string mzdmField;

        private string fyzhdmField;

        private string xldmField;

        private string zydmField;

        private string dzlbField;

        private string dzsfField;

        private string dzsField;

        private string dzqxField;

        private string dzxzField;

        private string dzcField;

        private string brdhField;

        private healthDataInfo healthDataInfoField;

        private allergyInfo[] allergyInfoListField;

        private linkmanInfo[] linkmanInfoListField;

        private vaccineInfo[] vaccineInfoListField;

        private expenseTypeVo[] expenseTypeField;

        private string citizenshipField;

        private string birthPlaceField;

        private string domicileField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string zjlx
        {
            get
            {
                return this.zjlxField;
            }
            set
            {
                this.zjlxField = value;
                this.RaisePropertyChanged("zjlx");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string zjhm
        {
            get
            {
                return this.zjhmField;
            }
            set
            {
                this.zjhmField = value;
                this.RaisePropertyChanged("zjhm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string jkdah
        {
            get
            {
                return this.jkdahField;
            }
            set
            {
                this.jkdahField = value;
                this.RaisePropertyChanged("jkdah");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string xnhkh
        {
            get
            {
                return this.xnhkhField;
            }
            set
            {
                this.xnhkhField = value;
                this.RaisePropertyChanged("xnhkh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string jzkkh
        {
            get
            {
                return this.jzkkhField;
            }
            set
            {
                this.jzkkhField = value;
                this.RaisePropertyChanged("jzkkh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        public string sfzhm
        {
            get
            {
                return this.sfzhmField;
            }
            set
            {
                this.sfzhmField = value;
                this.RaisePropertyChanged("sfzhm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 6)]
        public string ylfyzffs
        {
            get
            {
                return this.ylfyzffsField;
            }
            set
            {
                this.ylfyzffsField = value;
                this.RaisePropertyChanged("ylfyzffs");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 7)]
        public string xm
        {
            get
            {
                return this.xmField;
            }
            set
            {
                this.xmField = value;
                this.RaisePropertyChanged("xm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 8)]
        public string csrq
        {
            get
            {
                return this.csrqField;
            }
            set
            {
                this.csrqField = value;
                this.RaisePropertyChanged("csrq");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 9)]
        public string xb
        {
            get
            {
                return this.xbField;
            }
            set
            {
                this.xbField = value;
                this.RaisePropertyChanged("xb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 10)]
        public string mzdm
        {
            get
            {
                return this.mzdmField;
            }
            set
            {
                this.mzdmField = value;
                this.RaisePropertyChanged("mzdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 11)]
        public string fyzhdm
        {
            get
            {
                return this.fyzhdmField;
            }
            set
            {
                this.fyzhdmField = value;
                this.RaisePropertyChanged("fyzhdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 12)]
        public string xldm
        {
            get
            {
                return this.xldmField;
            }
            set
            {
                this.xldmField = value;
                this.RaisePropertyChanged("xldm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 13)]
        public string zydm
        {
            get
            {
                return this.zydmField;
            }
            set
            {
                this.zydmField = value;
                this.RaisePropertyChanged("zydm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 14)]
        public string dzlb
        {
            get
            {
                return this.dzlbField;
            }
            set
            {
                this.dzlbField = value;
                this.RaisePropertyChanged("dzlb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 15)]
        public string dzsf
        {
            get
            {
                return this.dzsfField;
            }
            set
            {
                this.dzsfField = value;
                this.RaisePropertyChanged("dzsf");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 16)]
        public string dzs
        {
            get
            {
                return this.dzsField;
            }
            set
            {
                this.dzsField = value;
                this.RaisePropertyChanged("dzs");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 17)]
        public string dzqx
        {
            get
            {
                return this.dzqxField;
            }
            set
            {
                this.dzqxField = value;
                this.RaisePropertyChanged("dzqx");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 18)]
        public string dzxz
        {
            get
            {
                return this.dzxzField;
            }
            set
            {
                this.dzxzField = value;
                this.RaisePropertyChanged("dzxz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 19)]
        public string dzc
        {
            get
            {
                return this.dzcField;
            }
            set
            {
                this.dzcField = value;
                this.RaisePropertyChanged("dzc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 20)]
        public string brdh
        {
            get
            {
                return this.brdhField;
            }
            set
            {
                this.brdhField = value;
                this.RaisePropertyChanged("brdh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 21)]
        public healthDataInfo healthDataInfo
        {
            get
            {
                return this.healthDataInfoField;
            }
            set
            {
                this.healthDataInfoField = value;
                this.RaisePropertyChanged("healthDataInfo");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 22)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public allergyInfo[] allergyInfoList
        {
            get
            {
                return this.allergyInfoListField;
            }
            set
            {
                this.allergyInfoListField = value;
                this.RaisePropertyChanged("allergyInfoList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 23)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public linkmanInfo[] linkmanInfoList
        {
            get
            {
                return this.linkmanInfoListField;
            }
            set
            {
                this.linkmanInfoListField = value;
                this.RaisePropertyChanged("linkmanInfoList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 24)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public vaccineInfo[] vaccineInfoList
        {
            get
            {
                return this.vaccineInfoListField;
            }
            set
            {
                this.vaccineInfoListField = value;
                this.RaisePropertyChanged("vaccineInfoList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 25)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public expenseTypeVo[] expenseType
        {
            get
            {
                return this.expenseTypeField;
            }
            set
            {
                this.expenseTypeField = value;
                this.RaisePropertyChanged("expenseType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 26)]
        public string citizenship
        {
            get
            {
                return this.citizenshipField;
            }
            set
            {
                this.citizenshipField = value;
                this.RaisePropertyChanged("citizenship");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 27)]
        public string birthPlace
        {
            get
            {
                return this.birthPlaceField;
            }
            set
            {
                this.birthPlaceField = value;
                this.RaisePropertyChanged("birthPlace");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 28)]
        public string domicile
        {
            get
            {
                return this.domicileField;
            }
            set
            {
                this.domicileField = value;
                this.RaisePropertyChanged("domicile");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class healthDataInfo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string abodmField;

        private string rhdmField;

        private string xcbzField;

        private string xzbbzField;

        private string xnxgbbzField;

        private string dxbbzField;

        private string jsbbzField;

        private string nxwlbzField;

        private string tnbbzField;

        private string qcybzField;

        private string txbzField;

        private string qgyzbzField;

        private string qgqsbzField;

        private string kzxdyzbzField;

        private string xzqbqbzField;

        private string qtyxjsmcField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string abodm
        {
            get
            {
                return this.abodmField;
            }
            set
            {
                this.abodmField = value;
                this.RaisePropertyChanged("abodm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string rhdm
        {
            get
            {
                return this.rhdmField;
            }
            set
            {
                this.rhdmField = value;
                this.RaisePropertyChanged("rhdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string xcbz
        {
            get
            {
                return this.xcbzField;
            }
            set
            {
                this.xcbzField = value;
                this.RaisePropertyChanged("xcbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string xzbbz
        {
            get
            {
                return this.xzbbzField;
            }
            set
            {
                this.xzbbzField = value;
                this.RaisePropertyChanged("xzbbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string xnxgbbz
        {
            get
            {
                return this.xnxgbbzField;
            }
            set
            {
                this.xnxgbbzField = value;
                this.RaisePropertyChanged("xnxgbbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        public string dxbbz
        {
            get
            {
                return this.dxbbzField;
            }
            set
            {
                this.dxbbzField = value;
                this.RaisePropertyChanged("dxbbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 6)]
        public string jsbbz
        {
            get
            {
                return this.jsbbzField;
            }
            set
            {
                this.jsbbzField = value;
                this.RaisePropertyChanged("jsbbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 7)]
        public string nxwlbz
        {
            get
            {
                return this.nxwlbzField;
            }
            set
            {
                this.nxwlbzField = value;
                this.RaisePropertyChanged("nxwlbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 8)]
        public string tnbbz
        {
            get
            {
                return this.tnbbzField;
            }
            set
            {
                this.tnbbzField = value;
                this.RaisePropertyChanged("tnbbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 9)]
        public string qcybz
        {
            get
            {
                return this.qcybzField;
            }
            set
            {
                this.qcybzField = value;
                this.RaisePropertyChanged("qcybz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 10)]
        public string txbz
        {
            get
            {
                return this.txbzField;
            }
            set
            {
                this.txbzField = value;
                this.RaisePropertyChanged("txbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 11)]
        public string qgyzbz
        {
            get
            {
                return this.qgyzbzField;
            }
            set
            {
                this.qgyzbzField = value;
                this.RaisePropertyChanged("qgyzbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 12)]
        public string qgqsbz
        {
            get
            {
                return this.qgqsbzField;
            }
            set
            {
                this.qgqsbzField = value;
                this.RaisePropertyChanged("qgqsbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 13)]
        public string kzxdyzbz
        {
            get
            {
                return this.kzxdyzbzField;
            }
            set
            {
                this.kzxdyzbzField = value;
                this.RaisePropertyChanged("kzxdyzbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 14)]
        public string xzqbqbz
        {
            get
            {
                return this.xzqbqbzField;
            }
            set
            {
                this.xzqbqbzField = value;
                this.RaisePropertyChanged("xzqbqbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 15)]
        public string qtyxjsmc
        {
            get
            {
                return this.qtyxjsmcField;
            }
            set
            {
                this.qtyxjsmcField = value;
                this.RaisePropertyChanged("qtyxjsmc");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class operatorLogInfo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string amountField;

        private string bankCodeField;

        private string khField;

        private string ksdmField;

        private string kslxField;

        private string ksmcField;

        private string machineCodeField;

        private string medicalTypeField;

        private string operCodeField;

        private string operTimeField;

        private string orgcodeField;

        private string payModeField;

        private string samCodeField;

        private string terminalTypeField;

        private string useCityCodeField;

        private string useOrgCodeField;

        private string useOrgNameField;

        private string xmField;

        private string xpxlhField;

        private string yycsdmField;

        private string medStepcodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
                this.RaisePropertyChanged("amount");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string bankCode
        {
            get
            {
                return this.bankCodeField;
            }
            set
            {
                this.bankCodeField = value;
                this.RaisePropertyChanged("bankCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string kh
        {
            get
            {
                return this.khField;
            }
            set
            {
                this.khField = value;
                this.RaisePropertyChanged("kh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string ksdm
        {
            get
            {
                return this.ksdmField;
            }
            set
            {
                this.ksdmField = value;
                this.RaisePropertyChanged("ksdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string kslx
        {
            get
            {
                return this.kslxField;
            }
            set
            {
                this.kslxField = value;
                this.RaisePropertyChanged("kslx");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        public string ksmc
        {
            get
            {
                return this.ksmcField;
            }
            set
            {
                this.ksmcField = value;
                this.RaisePropertyChanged("ksmc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 6)]
        public string machineCode
        {
            get
            {
                return this.machineCodeField;
            }
            set
            {
                this.machineCodeField = value;
                this.RaisePropertyChanged("machineCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 7)]
        public string medicalType
        {
            get
            {
                return this.medicalTypeField;
            }
            set
            {
                this.medicalTypeField = value;
                this.RaisePropertyChanged("medicalType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 8)]
        public string operCode
        {
            get
            {
                return this.operCodeField;
            }
            set
            {
                this.operCodeField = value;
                this.RaisePropertyChanged("operCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 9)]
        public string operTime
        {
            get
            {
                return this.operTimeField;
            }
            set
            {
                this.operTimeField = value;
                this.RaisePropertyChanged("operTime");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 10)]
        public string orgcode
        {
            get
            {
                return this.orgcodeField;
            }
            set
            {
                this.orgcodeField = value;
                this.RaisePropertyChanged("orgcode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 11)]
        public string payMode
        {
            get
            {
                return this.payModeField;
            }
            set
            {
                this.payModeField = value;
                this.RaisePropertyChanged("payMode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 12)]
        public string samCode
        {
            get
            {
                return this.samCodeField;
            }
            set
            {
                this.samCodeField = value;
                this.RaisePropertyChanged("samCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 13)]
        public string terminalType
        {
            get
            {
                return this.terminalTypeField;
            }
            set
            {
                this.terminalTypeField = value;
                this.RaisePropertyChanged("terminalType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 14)]
        public string useCityCode
        {
            get
            {
                return this.useCityCodeField;
            }
            set
            {
                this.useCityCodeField = value;
                this.RaisePropertyChanged("useCityCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 15)]
        public string useOrgCode
        {
            get
            {
                return this.useOrgCodeField;
            }
            set
            {
                this.useOrgCodeField = value;
                this.RaisePropertyChanged("useOrgCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 16)]
        public string useOrgName
        {
            get
            {
                return this.useOrgNameField;
            }
            set
            {
                this.useOrgNameField = value;
                this.RaisePropertyChanged("useOrgName");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 17)]
        public string xm
        {
            get
            {
                return this.xmField;
            }
            set
            {
                this.xmField = value;
                this.RaisePropertyChanged("xm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 18)]
        public string xpxlh
        {
            get
            {
                return this.xpxlhField;
            }
            set
            {
                this.xpxlhField = value;
                this.RaisePropertyChanged("xpxlh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 19)]
        public string yycsdm
        {
            get
            {
                return this.yycsdmField;
            }
            set
            {
                this.yycsdmField = value;
                this.RaisePropertyChanged("yycsdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 20)]
        public string medStepcode
        {
            get
            {
                return this.medStepcodeField;
            }
            set
            {
                this.medStepcodeField = value;
                this.RaisePropertyChanged("medStepcode");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class useCardInfo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string depCodeField;

        private string depTypeField;

        private string issuingModeField;

        private string machineCodeField;

        private string medStepcodeField;

        private string medTypeField;

        private string terminalTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string depCode
        {
            get
            {
                return this.depCodeField;
            }
            set
            {
                this.depCodeField = value;
                this.RaisePropertyChanged("depCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string depType
        {
            get
            {
                return this.depTypeField;
            }
            set
            {
                this.depTypeField = value;
                this.RaisePropertyChanged("depType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string issuingMode
        {
            get
            {
                return this.issuingModeField;
            }
            set
            {
                this.issuingModeField = value;
                this.RaisePropertyChanged("issuingMode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string machineCode
        {
            get
            {
                return this.machineCodeField;
            }
            set
            {
                this.machineCodeField = value;
                this.RaisePropertyChanged("machineCode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string medStepcode
        {
            get
            {
                return this.medStepcodeField;
            }
            set
            {
                this.medStepcodeField = value;
                this.RaisePropertyChanged("medStepcode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        public string medType
        {
            get
            {
                return this.medTypeField;
            }
            set
            {
                this.medTypeField = value;
                this.RaisePropertyChanged("medType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 6)]
        public string terminalType
        {
            get
            {
                return this.terminalTypeField;
            }
            set
            {
                this.terminalTypeField = value;
                this.RaisePropertyChanged("terminalType");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class samBlackListVo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string bhField;

        private string samTypeField;

        private string skgjgdmField;

        private string jgdmField;

        private string jgmcField;

        private string hmdbzField;

        private string operCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string bh
        {
            get
            {
                return this.bhField;
            }
            set
            {
                this.bhField = value;
                this.RaisePropertyChanged("bh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string samType
        {
            get
            {
                return this.samTypeField;
            }
            set
            {
                this.samTypeField = value;
                this.RaisePropertyChanged("samType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string skgjgdm
        {
            get
            {
                return this.skgjgdmField;
            }
            set
            {
                this.skgjgdmField = value;
                this.RaisePropertyChanged("skgjgdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string jgdm
        {
            get
            {
                return this.jgdmField;
            }
            set
            {
                this.jgdmField = value;
                this.RaisePropertyChanged("jgdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string jgmc
        {
            get
            {
                return this.jgmcField;
            }
            set
            {
                this.jgmcField = value;
                this.RaisePropertyChanged("jgmc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        public string hmdbz
        {
            get
            {
                return this.hmdbzField;
            }
            set
            {
                this.hmdbzField = value;
                this.RaisePropertyChanged("hmdbz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 6)]
        public string operCode
        {
            get
            {
                return this.operCodeField;
            }
            set
            {
                this.operCodeField = value;
                this.RaisePropertyChanged("operCode");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class cardBlackListVo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string sfzhmField;

        private string fkxlhField;

        private string xpxlhField;

        private string yycsdmField;

        private string hmdbzField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string sfzhm
        {
            get
            {
                return this.sfzhmField;
            }
            set
            {
                this.sfzhmField = value;
                this.RaisePropertyChanged("sfzhm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string fkxlh
        {
            get
            {
                return this.fkxlhField;
            }
            set
            {
                this.fkxlhField = value;
                this.RaisePropertyChanged("fkxlh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string xpxlh
        {
            get
            {
                return this.xpxlhField;
            }
            set
            {
                this.xpxlhField = value;
                this.RaisePropertyChanged("xpxlh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string yycsdm
        {
            get
            {
                return this.yycsdmField;
            }
            set
            {
                this.yycsdmField = value;
                this.RaisePropertyChanged("yycsdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string hmdbz
        {
            get
            {
                return this.hmdbzField;
            }
            set
            {
                this.hmdbzField = value;
                this.RaisePropertyChanged("hmdbz");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class cardIndexInfo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string xpxlhField;

        private string yhkhField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string xpxlh
        {
            get
            {
                return this.xpxlhField;
            }
            set
            {
                this.xpxlhField = value;
                this.RaisePropertyChanged("xpxlh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string yhkh
        {
            get
            {
                return this.yhkhField;
            }
            set
            {
                this.yhkhField = value;
                this.RaisePropertyChanged("yhkh");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class validateVircardResult : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string birthPlaceField;

        private string brdhField;

        private string citizenshipField;

        private string csrqField;

        private string domicileField;

        private string dzcField;

        private string dzlbField;

        private string dzqxField;

        private string dzsField;

        private string dzsfField;

        private string dzxzField;

        private string fyzhdmField;

        private string jkdahField;

        private string mzdmField;

        private string sfzhmField;

        private string userSignField;

        private string xbField;

        private string xldmField;

        private string xmField;

        private string xnhkhField;

        private string ylfyzffsField;

        private string zjhmField;

        private string zjlxField;

        private string zydmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string birthPlace
        {
            get
            {
                return this.birthPlaceField;
            }
            set
            {
                this.birthPlaceField = value;
                this.RaisePropertyChanged("birthPlace");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string brdh
        {
            get
            {
                return this.brdhField;
            }
            set
            {
                this.brdhField = value;
                this.RaisePropertyChanged("brdh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string citizenship
        {
            get
            {
                return this.citizenshipField;
            }
            set
            {
                this.citizenshipField = value;
                this.RaisePropertyChanged("citizenship");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string csrq
        {
            get
            {
                return this.csrqField;
            }
            set
            {
                this.csrqField = value;
                this.RaisePropertyChanged("csrq");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string domicile
        {
            get
            {
                return this.domicileField;
            }
            set
            {
                this.domicileField = value;
                this.RaisePropertyChanged("domicile");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        public string dzc
        {
            get
            {
                return this.dzcField;
            }
            set
            {
                this.dzcField = value;
                this.RaisePropertyChanged("dzc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 6)]
        public string dzlb
        {
            get
            {
                return this.dzlbField;
            }
            set
            {
                this.dzlbField = value;
                this.RaisePropertyChanged("dzlb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 7)]
        public string dzqx
        {
            get
            {
                return this.dzqxField;
            }
            set
            {
                this.dzqxField = value;
                this.RaisePropertyChanged("dzqx");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 8)]
        public string dzs
        {
            get
            {
                return this.dzsField;
            }
            set
            {
                this.dzsField = value;
                this.RaisePropertyChanged("dzs");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 9)]
        public string dzsf
        {
            get
            {
                return this.dzsfField;
            }
            set
            {
                this.dzsfField = value;
                this.RaisePropertyChanged("dzsf");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 10)]
        public string dzxz
        {
            get
            {
                return this.dzxzField;
            }
            set
            {
                this.dzxzField = value;
                this.RaisePropertyChanged("dzxz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 11)]
        public string fyzhdm
        {
            get
            {
                return this.fyzhdmField;
            }
            set
            {
                this.fyzhdmField = value;
                this.RaisePropertyChanged("fyzhdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 12)]
        public string jkdah
        {
            get
            {
                return this.jkdahField;
            }
            set
            {
                this.jkdahField = value;
                this.RaisePropertyChanged("jkdah");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 13)]
        public string mzdm
        {
            get
            {
                return this.mzdmField;
            }
            set
            {
                this.mzdmField = value;
                this.RaisePropertyChanged("mzdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 14)]
        public string sfzhm
        {
            get
            {
                return this.sfzhmField;
            }
            set
            {
                this.sfzhmField = value;
                this.RaisePropertyChanged("sfzhm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 15)]
        public string userSign
        {
            get
            {
                return this.userSignField;
            }
            set
            {
                this.userSignField = value;
                this.RaisePropertyChanged("userSign");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 16)]
        public string xb
        {
            get
            {
                return this.xbField;
            }
            set
            {
                this.xbField = value;
                this.RaisePropertyChanged("xb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 17)]
        public string xldm
        {
            get
            {
                return this.xldmField;
            }
            set
            {
                this.xldmField = value;
                this.RaisePropertyChanged("xldm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 18)]
        public string xm
        {
            get
            {
                return this.xmField;
            }
            set
            {
                this.xmField = value;
                this.RaisePropertyChanged("xm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 19)]
        public string xnhkh
        {
            get
            {
                return this.xnhkhField;
            }
            set
            {
                this.xnhkhField = value;
                this.RaisePropertyChanged("xnhkh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 20)]
        public string ylfyzffs
        {
            get
            {
                return this.ylfyzffsField;
            }
            set
            {
                this.ylfyzffsField = value;
                this.RaisePropertyChanged("ylfyzffs");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 21)]
        public string zjhm
        {
            get
            {
                return this.zjhmField;
            }
            set
            {
                this.zjhmField = value;
                this.RaisePropertyChanged("zjhm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 22)]
        public string zjlx
        {
            get
            {
                return this.zjlxField;
            }
            set
            {
                this.zjlxField = value;
                this.RaisePropertyChanged("zjlx");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 23)]
        public string zydm
        {
            get
            {
                return this.zydmField;
            }
            set
            {
                this.zydmField = value;
                this.RaisePropertyChanged("zydm");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class peopleIndexVo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string sfzhmField;

        private string xbField;

        private string xmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string sfzhm
        {
            get
            {
                return this.sfzhmField;
            }
            set
            {
                this.sfzhmField = value;
                this.RaisePropertyChanged("sfzhm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string xb
        {
            get
            {
                return this.xbField;
            }
            set
            {
                this.xbField = value;
                this.RaisePropertyChanged("xb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string xm
        {
            get
            {
                return this.xmField;
            }
            set
            {
                this.xmField = value;
                this.RaisePropertyChanged("xm");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class poorPeopleListVo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string xmField;

        private string sfzhmField;

        private string tpsxField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string xm
        {
            get
            {
                return this.xmField;
            }
            set
            {
                this.xmField = value;
                this.RaisePropertyChanged("xm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string sfzhm
        {
            get
            {
                return this.sfzhmField;
            }
            set
            {
                this.sfzhmField = value;
                this.RaisePropertyChanged("sfzhm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string tpsx
        {
            get
            {
                return this.tpsxField;
            }
            set
            {
                this.tpsxField = value;
                this.RaisePropertyChanged("tpsx");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class expenseTypeVo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string bzField;

        private string ddyyField;

        private string fbdlField;

        private string lbdmField;

        private string zjhmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string bz
        {
            get
            {
                return this.bzField;
            }
            set
            {
                this.bzField = value;
                this.RaisePropertyChanged("bz");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string ddyy
        {
            get
            {
                return this.ddyyField;
            }
            set
            {
                this.ddyyField = value;
                this.RaisePropertyChanged("ddyy");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string fbdl
        {
            get
            {
                return this.fbdlField;
            }
            set
            {
                this.fbdlField = value;
                this.RaisePropertyChanged("fbdl");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string lbdm
        {
            get
            {
                return this.lbdmField;
            }
            set
            {
                this.lbdmField = value;
                this.RaisePropertyChanged("lbdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string zjhm
        {
            get
            {
                return this.zjhmField;
            }
            set
            {
                this.zjhmField = value;
                this.RaisePropertyChanged("zjhm");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class vaccineInfo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string myjzymmcField;

        private string ymjzrqField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string myjzymmc
        {
            get
            {
                return this.myjzymmcField;
            }
            set
            {
                this.myjzymmcField = value;
                this.RaisePropertyChanged("myjzymmc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string ymjzrq
        {
            get
            {
                return this.ymjzrqField;
            }
            set
            {
                this.ymjzrqField = value;
                this.RaisePropertyChanged("ymjzrq");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class linkmanInfo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string lxrxmField;

        private string lxrgxField;

        private string lxrdhField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string lxrxm
        {
            get
            {
                return this.lxrxmField;
            }
            set
            {
                this.lxrxmField = value;
                this.RaisePropertyChanged("lxrxm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string lxrgx
        {
            get
            {
                return this.lxrgxField;
            }
            set
            {
                this.lxrgxField = value;
                this.RaisePropertyChanged("lxrgx");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string lxrdh
        {
            get
            {
                return this.lxrdhField;
            }
            set
            {
                this.lxrdhField = value;
                this.RaisePropertyChanged("lxrdh");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class allergyInfo : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string gmwzmcField;

        private string gmfyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string gmwzmc
        {
            get
            {
                return this.gmwzmcField;
            }
            set
            {
                this.gmwzmcField = value;
                this.RaisePropertyChanged("gmwzmc");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string gmfy
        {
            get
            {
                return this.gmfyField;
            }
            set
            {
                this.gmfyField = value;
                this.RaisePropertyChanged("gmfy");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(resUpdateVirCard))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BlackSamResult))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AuthKey))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BlackCardResult))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(cardIndexResult))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(virCard))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(xnhkhResult))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CardVerifyResult))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PoorPeopleResult))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(resDownloadQrCode))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(cardInfoResult))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class WSResult : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string messageField;

        private int resultCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public int resultCode
        {
            get
            {
                return this.resultCodeField;
            }
            set
            {
                this.resultCodeField = value;
                this.RaisePropertyChanged("resultCode");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class resUpdateVirCard : WSResult
    {

        private string empiField;

        private string erhcEnddateField;

        private string jzkkhField;

        private string sbkhField;

        private string vuidField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string empi
        {
            get
            {
                return this.empiField;
            }
            set
            {
                this.empiField = value;
                this.RaisePropertyChanged("empi");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string erhcEnddate
        {
            get
            {
                return this.erhcEnddateField;
            }
            set
            {
                this.erhcEnddateField = value;
                this.RaisePropertyChanged("erhcEnddate");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string jzkkh
        {
            get
            {
                return this.jzkkhField;
            }
            set
            {
                this.jzkkhField = value;
                this.RaisePropertyChanged("jzkkh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string sbkh
        {
            get
            {
                return this.sbkhField;
            }
            set
            {
                this.sbkhField = value;
                this.RaisePropertyChanged("sbkh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string vuid
        {
            get
            {
                return this.vuidField;
            }
            set
            {
                this.vuidField = value;
                this.RaisePropertyChanged("vuid");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class BlackSamResult : WSResult
    {

        private samBlackListVo[] samBlackListField;

        private string responseInfoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("samBlackList", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public samBlackListVo[] samBlackList
        {
            get
            {
                return this.samBlackListField;
            }
            set
            {
                this.samBlackListField = value;
                this.RaisePropertyChanged("samBlackList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string responseInfo
        {
            get
            {
                return this.responseInfoField;
            }
            set
            {
                this.responseInfoField = value;
                this.RaisePropertyChanged("responseInfo");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class AuthKey : WSResult
    {

        private string authKeyField;

        private string expiryTimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string authKey
        {
            get
            {
                return this.authKeyField;
            }
            set
            {
                this.authKeyField = value;
                this.RaisePropertyChanged("authKey");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string expiryTime
        {
            get
            {
                return this.expiryTimeField;
            }
            set
            {
                this.expiryTimeField = value;
                this.RaisePropertyChanged("expiryTime");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class BlackCardResult : WSResult
    {

        private cardBlackListVo[] cardBlackListField;

        private string responseInfoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("cardBlackList", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public cardBlackListVo[] cardBlackList
        {
            get
            {
                return this.cardBlackListField;
            }
            set
            {
                this.cardBlackListField = value;
                this.RaisePropertyChanged("cardBlackList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string responseInfo
        {
            get
            {
                return this.responseInfoField;
            }
            set
            {
                this.responseInfoField = value;
                this.RaisePropertyChanged("responseInfo");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class cardIndexResult : WSResult
    {

        private cardIndexInfo[] cardIndexInfoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("cardIndexInfo", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true, Order = 0)]
        public cardIndexInfo[] cardIndexInfo
        {
            get
            {
                return this.cardIndexInfoField;
            }
            set
            {
                this.cardIndexInfoField = value;
                this.RaisePropertyChanged("cardIndexInfo");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class virCard : WSResult
    {

        private string empiField;

        private string erhcEnddateField;

        private string jzkkhField;

        private string orgcodeField;

        private string orgnameField;

        private string sbkhField;

        private string virtualCardNumField;

        private string vuidField;

        private validateVircardResult vvcrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string empi
        {
            get
            {
                return this.empiField;
            }
            set
            {
                this.empiField = value;
                this.RaisePropertyChanged("empi");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string erhcEnddate
        {
            get
            {
                return this.erhcEnddateField;
            }
            set
            {
                this.erhcEnddateField = value;
                this.RaisePropertyChanged("erhcEnddate");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string jzkkh
        {
            get
            {
                return this.jzkkhField;
            }
            set
            {
                this.jzkkhField = value;
                this.RaisePropertyChanged("jzkkh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string orgcode
        {
            get
            {
                return this.orgcodeField;
            }
            set
            {
                this.orgcodeField = value;
                this.RaisePropertyChanged("orgcode");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string orgname
        {
            get
            {
                return this.orgnameField;
            }
            set
            {
                this.orgnameField = value;
                this.RaisePropertyChanged("orgname");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        public string sbkh
        {
            get
            {
                return this.sbkhField;
            }
            set
            {
                this.sbkhField = value;
                this.RaisePropertyChanged("sbkh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 6)]
        public string virtualCardNum
        {
            get
            {
                return this.virtualCardNumField;
            }
            set
            {
                this.virtualCardNumField = value;
                this.RaisePropertyChanged("virtualCardNum");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 7)]
        public string vuid
        {
            get
            {
                return this.vuidField;
            }
            set
            {
                this.vuidField = value;
                this.RaisePropertyChanged("vuid");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 8)]
        public validateVircardResult vvcr
        {
            get
            {
                return this.vvcrField;
            }
            set
            {
                this.vvcrField = value;
                this.RaisePropertyChanged("vvcr");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class xnhkhResult : WSResult
    {

        private string brdhField;

        private string fyzhdmField;

        private string jkdahField;

        private string xnhkhField;

        private string ylfyzffsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string brdh
        {
            get
            {
                return this.brdhField;
            }
            set
            {
                this.brdhField = value;
                this.RaisePropertyChanged("brdh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string fyzhdm
        {
            get
            {
                return this.fyzhdmField;
            }
            set
            {
                this.fyzhdmField = value;
                this.RaisePropertyChanged("fyzhdm");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string jkdah
        {
            get
            {
                return this.jkdahField;
            }
            set
            {
                this.jkdahField = value;
                this.RaisePropertyChanged("jkdah");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public string xnhkh
        {
            get
            {
                return this.xnhkhField;
            }
            set
            {
                this.xnhkhField = value;
                this.RaisePropertyChanged("xnhkh");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public string ylfyzffs
        {
            get
            {
                return this.ylfyzffsField;
            }
            set
            {
                this.ylfyzffsField = value;
                this.RaisePropertyChanged("ylfyzffs");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class CardVerifyResult : WSResult
    {

        private peopleIndexVo peopleInfoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public peopleIndexVo peopleInfo
        {
            get
            {
                return this.peopleInfoField;
            }
            set
            {
                this.peopleInfoField = value;
                this.RaisePropertyChanged("peopleInfo");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class PoorPeopleResult : WSResult
    {

        private poorPeopleListVo[] poorPeopleListField;

        private string responseInfoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("poorPeopleList", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public poorPeopleListVo[] poorPeopleList
        {
            get
            {
                return this.poorPeopleListField;
            }
            set
            {
                this.poorPeopleListField = value;
                this.RaisePropertyChanged("poorPeopleList");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string responseInfo
        {
            get
            {
                return this.responseInfoField;
            }
            set
            {
                this.responseInfoField = value;
                this.RaisePropertyChanged("responseInfo");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2558.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.hbws.gov.cn/card")]
    public partial class resDownloadQrCode : WSResult
    {

        private string empiField;

        private string imgField;

        private string vuidField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string empi
        {
            get
            {
                return this.empiField;
            }
            set
            {
                this.empiField = value;
                this.RaisePropertyChanged("empi");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string img
        {
            get
            {
                return this.imgField;
            }
            set
            {
                this.imgField = value;
                this.RaisePropertyChanged("img");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public string vuid
        {
            get
            {
                return this.vuidField;
            }
            set
            {
                this.vuidField = value;
                this.RaisePropertyChanged("vuid");
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getInfoYw", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getInfoYw
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string typeYw;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string numStr;

        public getInfoYw()
        {
        }

        public getInfoYw(string orgCode, string authKey, string typeYw, string numStr)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.typeYw = typeYw;
            this.numStr = numStr;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getInfoYwResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getInfoYwResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public cardInfoResult @return;

        public getInfoYwResponse()
        {
        }

        public getInfoYwResponse(cardInfoResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "blackSamVerify", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class blackSamVerify
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cardNumber;

        public blackSamVerify()
        {
        }

        public blackSamVerify(string orgCode, string authKey, string cardNumber)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.cardNumber = cardNumber;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "blackSamVerifyResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class blackSamVerifyResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public blackSamVerifyResponse()
        {
        }

        public blackSamVerifyResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getYhkhStatus", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getYhkhStatus
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string useOrgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sfzhm;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string xpxlh;

        public getYhkhStatus()
        {
        }

        public getYhkhStatus(string authKey, string useOrgCode, string orgCode, string sfzhm, string xpxlh)
        {
            this.authKey = authKey;
            this.useOrgCode = useOrgCode;
            this.orgCode = orgCode;
            this.sfzhm = sfzhm;
            this.xpxlh = xpxlh;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getYhkhStatusResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getYhkhStatusResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public getYhkhStatusResponse()
        {
        }

        public getYhkhStatusResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "modifyCardInfo", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class modifyCardInfo
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public pCard cardInfo;

        public modifyCardInfo()
        {
        }

        public modifyCardInfo(string orgCode, string authKey, pCard cardInfo)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.cardInfo = cardInfo;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "modifyCardInfoResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class modifyCardInfoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public modifyCardInfoResponse()
        {
        }

        public modifyCardInfoResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "downQr", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class downQr
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string zjlx;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string zjhm;

        public downQr()
        {
        }

        public downQr(string orgCode, string authKey, string name, string zjlx, string zjhm)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.name = name;
            this.zjlx = zjlx;
            this.zjhm = zjhm;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "downQrResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class downQrResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public resDownloadQrCode @return;

        public downQrResponse()
        {
        }

        public downQrResponse(resDownloadQrCode @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "publishPoorPeople", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class publishPoorPeople
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string startDate;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string endDate;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string requestInfo;

        public publishPoorPeople()
        {
        }

        public publishPoorPeople(string orgCode, string authKey, string startDate, string endDate, string requestInfo)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.startDate = startDate;
            this.endDate = endDate;
            this.requestInfo = requestInfo;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "publishPoorPeopleResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class publishPoorPeopleResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PoorPeopleResult @return;

        public publishPoorPeopleResponse()
        {
        }

        public publishPoorPeopleResponse(PoorPeopleResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "repairChangCard", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class repairChangCard
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string operCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sfzhm;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string oldYycsdm;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 5)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string oldFkxlh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 6)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string oldYhkh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 7)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string oldXpxlh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 8)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string oldKh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 9)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public pCard newCardInfo;

        public repairChangCard()
        {
        }

        public repairChangCard(string orgCode, string authKey, string operCode, string sfzhm, string oldYycsdm, string oldFkxlh, string oldYhkh, string oldXpxlh, string oldKh, pCard newCardInfo)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.operCode = operCode;
            this.sfzhm = sfzhm;
            this.oldYycsdm = oldYycsdm;
            this.oldFkxlh = oldFkxlh;
            this.oldYhkh = oldYhkh;
            this.oldXpxlh = oldXpxlh;
            this.oldKh = oldKh;
            this.newCardInfo = newCardInfo;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "repairChangCardResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class repairChangCardResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public repairChangCardResponse()
        {
        }

        public repairChangCardResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "cardVerify", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class cardVerify
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string xpxlh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cardNumber;

        public cardVerify()
        {
        }

        public cardVerify(string orgCode, string authKey, string xpxlh, string cardNumber)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.xpxlh = xpxlh;
            this.cardNumber = cardNumber;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "cardVerifyResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class cardVerifyResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CardVerifyResult @return;

        public cardVerifyResponse()
        {
        }

        public cardVerifyResponse(CardVerifyResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "sfzhmVerify", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class sfzhmVerify
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sfzhm;

        public sfzhmVerify()
        {
        }

        public sfzhmVerify(string orgCode, string authKey, string sfzhm)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.sfzhm = sfzhm;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "sfzhmVerifyResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class sfzhmVerifyResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public sfzhmVerifyResponse()
        {
        }

        public sfzhmVerifyResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getXnhkh", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getXnhkh
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sfzhm;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string xm;

        public getXnhkh()
        {
        }

        public getXnhkh(string orgCode, string authKey, string sfzhm, string xm)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.sfzhm = sfzhm;
            this.xm = xm;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getXnhkhResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getXnhkhResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public xnhkhResult @return;

        public getXnhkhResponse()
        {
        }

        public getXnhkhResponse(xnhkhResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getCardInfo", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getCardInfo
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string type;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string numStr;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public useCardInfo useCardInfo;

        public getCardInfo()
        {
        }

        public getCardInfo(string orgCode, string authKey, string type, string numStr, useCardInfo useCardInfo)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.type = type;
            this.numStr = numStr;
            this.useCardInfo = useCardInfo;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getCardInfoResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getCardInfoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public cardInfoResult @return;

        public getCardInfoResponse()
        {
        }

        public getCardInfoResponse(cardInfoResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "virIdCardVerify", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class virIdCardVerify
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string qrCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public useCardInfo useCardInfo;

        public virIdCardVerify()
        {
        }

        public virIdCardVerify(string orgCode, string authKey, string qrCode, useCardInfo useCardInfo)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.qrCode = qrCode;
            this.useCardInfo = useCardInfo;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "virIdCardVerifyResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class virIdCardVerifyResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virCard @return;

        public virIdCardVerifyResponse()
        {
        }

        public virIdCardVerifyResponse(virCard @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "poorPeopleVerify", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class poorPeopleVerify
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sfzhm;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string xm;

        public poorPeopleVerify()
        {
        }

        public poorPeopleVerify(string orgCode, string authKey, string sfzhm, string xm)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.sfzhm = sfzhm;
            this.xm = xm;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "poorPeopleVerifyResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class poorPeopleVerifyResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public poorPeopleVerifyResponse()
        {
        }

        public poorPeopleVerifyResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "operatorLog", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class operatorLog
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public operatorLogInfo operatorLogInfo;

        public operatorLog()
        {
        }

        public operatorLog(string orgCode, string authKey, operatorLogInfo operatorLogInfo)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.operatorLogInfo = operatorLogInfo;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "operatorLogResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class operatorLogResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public operatorLogResponse()
        {
        }

        public operatorLogResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "syncCardInfo", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class syncCardInfo
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public pCard cardInfo;

        public syncCardInfo()
        {
        }

        public syncCardInfo(string orgCode, string authKey, pCard cardInfo)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.cardInfo = cardInfo;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "syncCardInfoResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class syncCardInfoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public syncCardInfoResponse()
        {
        }

        public syncCardInfoResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "modifyPeopleInfo", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class modifyPeopleInfo
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string kh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string yycsdm;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fkxlh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 5)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string yhkh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 6)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string xpxlh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 7)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public people peopleInfo;

        public modifyPeopleInfo()
        {
        }

        public modifyPeopleInfo(string orgCode, string authKey, string kh, string yycsdm, string fkxlh, string yhkh, string xpxlh, people peopleInfo)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.kh = kh;
            this.yycsdm = yycsdm;
            this.fkxlh = fkxlh;
            this.yhkh = yhkh;
            this.xpxlh = xpxlh;
            this.peopleInfo = peopleInfo;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "modifyPeopleInfoResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class modifyPeopleInfoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public modifyPeopleInfoResponse()
        {
        }

        public modifyPeopleInfoResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getInfo", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getInfo
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string type;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string numStr;

        public getInfo()
        {
        }

        public getInfo(string orgCode, string authKey, string type, string numStr)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.type = type;
            this.numStr = numStr;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getInfoResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getInfoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public cardInfoResult @return;

        public getInfoResponse()
        {
        }

        public getInfoResponse(cardInfoResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getXpxlhYhkh", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getXpxlhYhkh
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sfzhm;

        public getXpxlhYhkh()
        {
        }

        public getXpxlhYhkh(string orgCode, string authKey, string sfzhm)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.sfzhm = sfzhm;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getXpxlhYhkhResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getXpxlhYhkhResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public cardIndexResult @return;

        public getXpxlhYhkhResponse()
        {
        }

        public getXpxlhYhkhResponse(cardIndexResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "syncCardStatus", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class syncCardStatus
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string operCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string kh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string yycsdm;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 5)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fkxlh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 6)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string yhkh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 7)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string xpxlh;

        public syncCardStatus()
        {
        }

        public syncCardStatus(string orgCode, string authKey, string operCode, string kh, string yycsdm, string fkxlh, string yhkh, string xpxlh)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.operCode = operCode;
            this.kh = kh;
            this.yycsdm = yycsdm;
            this.fkxlh = fkxlh;
            this.yhkh = yhkh;
            this.xpxlh = xpxlh;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "syncCardStatusResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class syncCardStatusResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public syncCardStatusResponse()
        {
        }

        public syncCardStatusResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "publishBlackCard", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class publishBlackCard
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string startDate;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string endDate;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string requestInfo;

        public publishBlackCard()
        {
        }

        public publishBlackCard(string orgCode, string authKey, string startDate, string endDate, string requestInfo)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.startDate = startDate;
            this.endDate = endDate;
            this.requestInfo = requestInfo;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "publishBlackCardResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class publishBlackCardResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public BlackCardResult @return;

        public publishBlackCardResponse()
        {
        }

        public publishBlackCardResponse(BlackCardResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getAuthKey", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getAuthKey
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string userName;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string passWord;

        public getAuthKey()
        {
        }

        public getAuthKey(string orgCode, string userName, string passWord)
        {
            this.orgCode = orgCode;
            this.userName = userName;
            this.passWord = passWord;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "getAuthKeyResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class getAuthKeyResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AuthKey @return;

        public getAuthKeyResponse()
        {
        }

        public getAuthKeyResponse(AuthKey @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "publishBlackSam", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class publishBlackSam
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string startDate;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string endDate;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string requestInfo;

        public publishBlackSam()
        {
        }

        public publishBlackSam(string orgCode, string authKey, string startDate, string endDate, string requestInfo)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.startDate = startDate;
            this.endDate = endDate;
            this.requestInfo = requestInfo;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "publishBlackSamResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class publishBlackSamResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public BlackSamResult @return;

        public publishBlackSamResponse()
        {
        }

        public publishBlackSamResponse(BlackSamResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "identifyPerson", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class identifyPerson
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string xm;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string zjhm;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string zjlx;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 5)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string mode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 6)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string img1;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 7)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string img2;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 8)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string img3;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 9)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string brdh;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 10)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string facevideo;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 11)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string action_type;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 12)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string virtualCardNum;

        public identifyPerson()
        {
        }

        public identifyPerson(string orgCode, string authKey, string xm, string zjhm, string zjlx, string mode, string img1, string img2, string img3, string brdh, string facevideo, string action_type, string virtualCardNum)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.xm = xm;
            this.zjhm = zjhm;
            this.zjlx = zjlx;
            this.mode = mode;
            this.img1 = img1;
            this.img2 = img2;
            this.img3 = img3;
            this.brdh = brdh;
            this.facevideo = facevideo;
            this.action_type = action_type;
            this.virtualCardNum = virtualCardNum;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "identifyPersonResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class identifyPersonResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public identifyPersonResponse()
        {
        }

        public identifyPersonResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "updateCardType", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class updateCardType
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string zjlx;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string zjhm;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 5)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tel;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 6)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string issuingMode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 7)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string terminalType;

        public updateCardType()
        {
        }

        public updateCardType(string orgCode, string authKey, string name, string zjlx, string zjhm, string tel, string issuingMode, string terminalType)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.name = name;
            this.zjlx = zjlx;
            this.zjhm = zjhm;
            this.tel = tel;
            this.issuingMode = issuingMode;
            this.terminalType = terminalType;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "updateCardTypeResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class updateCardTypeResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSResult @return;

        public updateCardTypeResponse()
        {
        }

        public updateCardTypeResponse(WSResult @return)
        {
            this.@return = @return;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "updateCardInfo", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class updateCardInfo
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string orgCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string authKey;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string qrCode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string issuingMode;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string terminalType;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 5)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public people People;

        public updateCardInfo()
        {
        }

        public updateCardInfo(string orgCode, string authKey, string qrCode, string issuingMode, string terminalType, people People)
        {
            this.orgCode = orgCode;
            this.authKey = authKey;
            this.qrCode = qrCode;
            this.issuingMode = issuingMode;
            this.terminalType = terminalType;
            this.People = People;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "updateCardInfoResponse", WrapperNamespace = "http://www.hbws.gov.cn/card", IsWrapped = true)]
    public partial class updateCardInfoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.hbws.gov.cn/card", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public resUpdateVirCard @return;

        public updateCardInfoResponse()
        {
        }

        public updateCardInfoResponse(resUpdateVirCard @return)
        {
            this.@return = @return;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface HealthCardServiceChannel : HealthCardService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HealthCardServiceClient : System.ServiceModel.ClientBase<HealthCardService>, HealthCardService
    {

        public HealthCardServiceClient()
        {
        }

        public HealthCardServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public HealthCardServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public HealthCardServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public HealthCardServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        getInfoYwResponse HealthCardService.getInfoYw(getInfoYw request)
        {
            return base.Channel.getInfoYw(request);
        }

        public cardInfoResult getInfoYw(string orgCode, string authKey, string typeYw, string numStr)
        {
            getInfoYw inValue = new getInfoYw();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.typeYw = typeYw;
            inValue.numStr = numStr;
            getInfoYwResponse retVal = ((HealthCardService)(this)).getInfoYw(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<getInfoYwResponse> HealthCardService.getInfoYwAsync(getInfoYw request)
        {
            return base.Channel.getInfoYwAsync(request);
        }

        public System.Threading.Tasks.Task<getInfoYwResponse> getInfoYwAsync(string orgCode, string authKey, string typeYw, string numStr)
        {
            getInfoYw inValue = new getInfoYw();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.typeYw = typeYw;
            inValue.numStr = numStr;
            return ((HealthCardService)(this)).getInfoYwAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        blackSamVerifyResponse HealthCardService.blackSamVerify(blackSamVerify request)
        {
            return base.Channel.blackSamVerify(request);
        }

        public WSResult blackSamVerify(string orgCode, string authKey, string cardNumber)
        {
            blackSamVerify inValue = new blackSamVerify();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.cardNumber = cardNumber;
            blackSamVerifyResponse retVal = ((HealthCardService)(this)).blackSamVerify(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<blackSamVerifyResponse> HealthCardService.blackSamVerifyAsync(blackSamVerify request)
        {
            return base.Channel.blackSamVerifyAsync(request);
        }

        public System.Threading.Tasks.Task<blackSamVerifyResponse> blackSamVerifyAsync(string orgCode, string authKey, string cardNumber)
        {
            blackSamVerify inValue = new blackSamVerify();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.cardNumber = cardNumber;
            return ((HealthCardService)(this)).blackSamVerifyAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        getYhkhStatusResponse HealthCardService.getYhkhStatus(getYhkhStatus request)
        {
            return base.Channel.getYhkhStatus(request);
        }

        public WSResult getYhkhStatus(string authKey, string useOrgCode, string orgCode, string sfzhm, string xpxlh)
        {
            getYhkhStatus inValue = new getYhkhStatus();
            inValue.authKey = authKey;
            inValue.useOrgCode = useOrgCode;
            inValue.orgCode = orgCode;
            inValue.sfzhm = sfzhm;
            inValue.xpxlh = xpxlh;
            getYhkhStatusResponse retVal = ((HealthCardService)(this)).getYhkhStatus(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<getYhkhStatusResponse> HealthCardService.getYhkhStatusAsync(getYhkhStatus request)
        {
            return base.Channel.getYhkhStatusAsync(request);
        }

        public System.Threading.Tasks.Task<getYhkhStatusResponse> getYhkhStatusAsync(string authKey, string useOrgCode, string orgCode, string sfzhm, string xpxlh)
        {
            getYhkhStatus inValue = new getYhkhStatus();
            inValue.authKey = authKey;
            inValue.useOrgCode = useOrgCode;
            inValue.orgCode = orgCode;
            inValue.sfzhm = sfzhm;
            inValue.xpxlh = xpxlh;
            return ((HealthCardService)(this)).getYhkhStatusAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        modifyCardInfoResponse HealthCardService.modifyCardInfo(modifyCardInfo request)
        {
            return base.Channel.modifyCardInfo(request);
        }

        public WSResult modifyCardInfo(string orgCode, string authKey, pCard cardInfo)
        {
            modifyCardInfo inValue = new modifyCardInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.cardInfo = cardInfo;
            modifyCardInfoResponse retVal = ((HealthCardService)(this)).modifyCardInfo(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<modifyCardInfoResponse> HealthCardService.modifyCardInfoAsync(modifyCardInfo request)
        {
            return base.Channel.modifyCardInfoAsync(request);
        }

        public System.Threading.Tasks.Task<modifyCardInfoResponse> modifyCardInfoAsync(string orgCode, string authKey, pCard cardInfo)
        {
            modifyCardInfo inValue = new modifyCardInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.cardInfo = cardInfo;
            return ((HealthCardService)(this)).modifyCardInfoAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        downQrResponse HealthCardService.downQr(downQr request)
        {
            return base.Channel.downQr(request);
        }

        public resDownloadQrCode downQr(string orgCode, string authKey, string name, string zjlx, string zjhm)
        {
            downQr inValue = new downQr();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.name = name;
            inValue.zjlx = zjlx;
            inValue.zjhm = zjhm;
            downQrResponse retVal = ((HealthCardService)(this)).downQr(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<downQrResponse> HealthCardService.downQrAsync(downQr request)
        {
            return base.Channel.downQrAsync(request);
        }

        public System.Threading.Tasks.Task<downQrResponse> downQrAsync(string orgCode, string authKey, string name, string zjlx, string zjhm)
        {
            downQr inValue = new downQr();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.name = name;
            inValue.zjlx = zjlx;
            inValue.zjhm = zjhm;
            return ((HealthCardService)(this)).downQrAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        publishPoorPeopleResponse HealthCardService.publishPoorPeople(publishPoorPeople request)
        {
            return base.Channel.publishPoorPeople(request);
        }

        public PoorPeopleResult publishPoorPeople(string orgCode, string authKey, string startDate, string endDate, string requestInfo)
        {
            publishPoorPeople inValue = new publishPoorPeople();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.startDate = startDate;
            inValue.endDate = endDate;
            inValue.requestInfo = requestInfo;
            publishPoorPeopleResponse retVal = ((HealthCardService)(this)).publishPoorPeople(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<publishPoorPeopleResponse> HealthCardService.publishPoorPeopleAsync(publishPoorPeople request)
        {
            return base.Channel.publishPoorPeopleAsync(request);
        }

        public System.Threading.Tasks.Task<publishPoorPeopleResponse> publishPoorPeopleAsync(string orgCode, string authKey, string startDate, string endDate, string requestInfo)
        {
            publishPoorPeople inValue = new publishPoorPeople();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.startDate = startDate;
            inValue.endDate = endDate;
            inValue.requestInfo = requestInfo;
            return ((HealthCardService)(this)).publishPoorPeopleAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        repairChangCardResponse HealthCardService.repairChangCard(repairChangCard request)
        {
            return base.Channel.repairChangCard(request);
        }

        public WSResult repairChangCard(string orgCode, string authKey, string operCode, string sfzhm, string oldYycsdm, string oldFkxlh, string oldYhkh, string oldXpxlh, string oldKh, pCard newCardInfo)
        {
            repairChangCard inValue = new repairChangCard();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.operCode = operCode;
            inValue.sfzhm = sfzhm;
            inValue.oldYycsdm = oldYycsdm;
            inValue.oldFkxlh = oldFkxlh;
            inValue.oldYhkh = oldYhkh;
            inValue.oldXpxlh = oldXpxlh;
            inValue.oldKh = oldKh;
            inValue.newCardInfo = newCardInfo;
            repairChangCardResponse retVal = ((HealthCardService)(this)).repairChangCard(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<repairChangCardResponse> HealthCardService.repairChangCardAsync(repairChangCard request)
        {
            return base.Channel.repairChangCardAsync(request);
        }

        public System.Threading.Tasks.Task<repairChangCardResponse> repairChangCardAsync(string orgCode, string authKey, string operCode, string sfzhm, string oldYycsdm, string oldFkxlh, string oldYhkh, string oldXpxlh, string oldKh, pCard newCardInfo)
        {
            repairChangCard inValue = new repairChangCard();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.operCode = operCode;
            inValue.sfzhm = sfzhm;
            inValue.oldYycsdm = oldYycsdm;
            inValue.oldFkxlh = oldFkxlh;
            inValue.oldYhkh = oldYhkh;
            inValue.oldXpxlh = oldXpxlh;
            inValue.oldKh = oldKh;
            inValue.newCardInfo = newCardInfo;
            return ((HealthCardService)(this)).repairChangCardAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        cardVerifyResponse HealthCardService.cardVerify(cardVerify request)
        {
            return base.Channel.cardVerify(request);
        }

        public CardVerifyResult cardVerify(string orgCode, string authKey, string xpxlh, string cardNumber)
        {
            cardVerify inValue = new cardVerify();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.xpxlh = xpxlh;
            inValue.cardNumber = cardNumber;
            cardVerifyResponse retVal = ((HealthCardService)(this)).cardVerify(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<cardVerifyResponse> HealthCardService.cardVerifyAsync(cardVerify request)
        {
            return base.Channel.cardVerifyAsync(request);
        }

        public System.Threading.Tasks.Task<cardVerifyResponse> cardVerifyAsync(string orgCode, string authKey, string xpxlh, string cardNumber)
        {
            cardVerify inValue = new cardVerify();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.xpxlh = xpxlh;
            inValue.cardNumber = cardNumber;
            return ((HealthCardService)(this)).cardVerifyAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        sfzhmVerifyResponse HealthCardService.sfzhmVerify(sfzhmVerify request)
        {
            return base.Channel.sfzhmVerify(request);
        }

        public WSResult sfzhmVerify(string orgCode, string authKey, string sfzhm)
        {
            sfzhmVerify inValue = new sfzhmVerify();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.sfzhm = sfzhm;
            sfzhmVerifyResponse retVal = ((HealthCardService)(this)).sfzhmVerify(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<sfzhmVerifyResponse> HealthCardService.sfzhmVerifyAsync(sfzhmVerify request)
        {
            return base.Channel.sfzhmVerifyAsync(request);
        }

        public System.Threading.Tasks.Task<sfzhmVerifyResponse> sfzhmVerifyAsync(string orgCode, string authKey, string sfzhm)
        {
            sfzhmVerify inValue = new sfzhmVerify();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.sfzhm = sfzhm;
            return ((HealthCardService)(this)).sfzhmVerifyAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        getXnhkhResponse HealthCardService.getXnhkh(getXnhkh request)
        {
            return base.Channel.getXnhkh(request);
        }

        public xnhkhResult getXnhkh(string orgCode, string authKey, string sfzhm, string xm)
        {
            getXnhkh inValue = new getXnhkh();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.sfzhm = sfzhm;
            inValue.xm = xm;
            getXnhkhResponse retVal = ((HealthCardService)(this)).getXnhkh(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<getXnhkhResponse> HealthCardService.getXnhkhAsync(getXnhkh request)
        {
            return base.Channel.getXnhkhAsync(request);
        }

        public System.Threading.Tasks.Task<getXnhkhResponse> getXnhkhAsync(string orgCode, string authKey, string sfzhm, string xm)
        {
            getXnhkh inValue = new getXnhkh();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.sfzhm = sfzhm;
            inValue.xm = xm;
            return ((HealthCardService)(this)).getXnhkhAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        getCardInfoResponse HealthCardService.getCardInfo(getCardInfo request)
        {
            return base.Channel.getCardInfo(request);
        }

        public cardInfoResult getCardInfo(string orgCode, string authKey, string type, string numStr, useCardInfo useCardInfo)
        {
            getCardInfo inValue = new getCardInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.type = type;
            inValue.numStr = numStr;
            inValue.useCardInfo = useCardInfo;
            getCardInfoResponse retVal = ((HealthCardService)(this)).getCardInfo(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<getCardInfoResponse> HealthCardService.getCardInfoAsync(getCardInfo request)
        {
            return base.Channel.getCardInfoAsync(request);
        }

        public System.Threading.Tasks.Task<getCardInfoResponse> getCardInfoAsync(string orgCode, string authKey, string type, string numStr, useCardInfo useCardInfo)
        {
            getCardInfo inValue = new getCardInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.type = type;
            inValue.numStr = numStr;
            inValue.useCardInfo = useCardInfo;
            return ((HealthCardService)(this)).getCardInfoAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        virIdCardVerifyResponse HealthCardService.virIdCardVerify(virIdCardVerify request)
        {
            return base.Channel.virIdCardVerify(request);
        }

        public virCard virIdCardVerify(string orgCode, string authKey, string qrCode, useCardInfo useCardInfo)
        {
            virIdCardVerify inValue = new virIdCardVerify();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.qrCode = qrCode;
            inValue.useCardInfo = useCardInfo;
            virIdCardVerifyResponse retVal = ((HealthCardService)(this)).virIdCardVerify(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<virIdCardVerifyResponse> HealthCardService.virIdCardVerifyAsync(virIdCardVerify request)
        {
            return base.Channel.virIdCardVerifyAsync(request);
        }

        public System.Threading.Tasks.Task<virIdCardVerifyResponse> virIdCardVerifyAsync(string orgCode, string authKey, string qrCode, useCardInfo useCardInfo)
        {
            virIdCardVerify inValue = new virIdCardVerify();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.qrCode = qrCode;
            inValue.useCardInfo = useCardInfo;
            return ((HealthCardService)(this)).virIdCardVerifyAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        poorPeopleVerifyResponse HealthCardService.poorPeopleVerify(poorPeopleVerify request)
        {
            return base.Channel.poorPeopleVerify(request);
        }

        public WSResult poorPeopleVerify(string orgCode, string authKey, string sfzhm, string xm)
        {
            poorPeopleVerify inValue = new poorPeopleVerify();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.sfzhm = sfzhm;
            inValue.xm = xm;
            poorPeopleVerifyResponse retVal = ((HealthCardService)(this)).poorPeopleVerify(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<poorPeopleVerifyResponse> HealthCardService.poorPeopleVerifyAsync(poorPeopleVerify request)
        {
            return base.Channel.poorPeopleVerifyAsync(request);
        }

        public System.Threading.Tasks.Task<poorPeopleVerifyResponse> poorPeopleVerifyAsync(string orgCode, string authKey, string sfzhm, string xm)
        {
            poorPeopleVerify inValue = new poorPeopleVerify();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.sfzhm = sfzhm;
            inValue.xm = xm;
            return ((HealthCardService)(this)).poorPeopleVerifyAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        operatorLogResponse HealthCardService.operatorLog(operatorLog request)
        {
            return base.Channel.operatorLog(request);
        }

        public WSResult operatorLog(string orgCode, string authKey, operatorLogInfo operatorLogInfo)
        {
            operatorLog inValue = new operatorLog();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.operatorLogInfo = operatorLogInfo;
            operatorLogResponse retVal = ((HealthCardService)(this)).operatorLog(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<operatorLogResponse> HealthCardService.operatorLogAsync(operatorLog request)
        {
            return base.Channel.operatorLogAsync(request);
        }

        public System.Threading.Tasks.Task<operatorLogResponse> operatorLogAsync(string orgCode, string authKey, operatorLogInfo operatorLogInfo)
        {
            operatorLog inValue = new operatorLog();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.operatorLogInfo = operatorLogInfo;
            return ((HealthCardService)(this)).operatorLogAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        syncCardInfoResponse HealthCardService.syncCardInfo(syncCardInfo request)
        {
            return base.Channel.syncCardInfo(request);
        }

        public WSResult syncCardInfo(string orgCode, string authKey, pCard cardInfo)
        {
            syncCardInfo inValue = new syncCardInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.cardInfo = cardInfo;
            syncCardInfoResponse retVal = ((HealthCardService)(this)).syncCardInfo(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<syncCardInfoResponse> HealthCardService.syncCardInfoAsync(syncCardInfo request)
        {
            return base.Channel.syncCardInfoAsync(request);
        }

        public System.Threading.Tasks.Task<syncCardInfoResponse> syncCardInfoAsync(string orgCode, string authKey, pCard cardInfo)
        {
            syncCardInfo inValue = new syncCardInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.cardInfo = cardInfo;
            return ((HealthCardService)(this)).syncCardInfoAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        modifyPeopleInfoResponse HealthCardService.modifyPeopleInfo(modifyPeopleInfo request)
        {
            return base.Channel.modifyPeopleInfo(request);
        }

        public WSResult modifyPeopleInfo(string orgCode, string authKey, string kh, string yycsdm, string fkxlh, string yhkh, string xpxlh, people peopleInfo)
        {
            modifyPeopleInfo inValue = new modifyPeopleInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.kh = kh;
            inValue.yycsdm = yycsdm;
            inValue.fkxlh = fkxlh;
            inValue.yhkh = yhkh;
            inValue.xpxlh = xpxlh;
            inValue.peopleInfo = peopleInfo;
            modifyPeopleInfoResponse retVal = ((HealthCardService)(this)).modifyPeopleInfo(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<modifyPeopleInfoResponse> HealthCardService.modifyPeopleInfoAsync(modifyPeopleInfo request)
        {
            return base.Channel.modifyPeopleInfoAsync(request);
        }

        public System.Threading.Tasks.Task<modifyPeopleInfoResponse> modifyPeopleInfoAsync(string orgCode, string authKey, string kh, string yycsdm, string fkxlh, string yhkh, string xpxlh, people peopleInfo)
        {
            modifyPeopleInfo inValue = new modifyPeopleInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.kh = kh;
            inValue.yycsdm = yycsdm;
            inValue.fkxlh = fkxlh;
            inValue.yhkh = yhkh;
            inValue.xpxlh = xpxlh;
            inValue.peopleInfo = peopleInfo;
            return ((HealthCardService)(this)).modifyPeopleInfoAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        getInfoResponse HealthCardService.getInfo(getInfo request)
        {
            return base.Channel.getInfo(request);
        }

        public cardInfoResult getInfo(string orgCode, string authKey, string type, string numStr)
        {
            getInfo inValue = new getInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.type = type;
            inValue.numStr = numStr;
            getInfoResponse retVal = ((HealthCardService)(this)).getInfo(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<getInfoResponse> HealthCardService.getInfoAsync(getInfo request)
        {
            return base.Channel.getInfoAsync(request);
        }

        public System.Threading.Tasks.Task<getInfoResponse> getInfoAsync(string orgCode, string authKey, string type, string numStr)
        {
            getInfo inValue = new getInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.type = type;
            inValue.numStr = numStr;
            return ((HealthCardService)(this)).getInfoAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        getXpxlhYhkhResponse HealthCardService.getXpxlhYhkh(getXpxlhYhkh request)
        {
            return base.Channel.getXpxlhYhkh(request);
        }

        public cardIndexResult getXpxlhYhkh(string orgCode, string authKey, string sfzhm)
        {
            getXpxlhYhkh inValue = new getXpxlhYhkh();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.sfzhm = sfzhm;
            getXpxlhYhkhResponse retVal = ((HealthCardService)(this)).getXpxlhYhkh(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<getXpxlhYhkhResponse> HealthCardService.getXpxlhYhkhAsync(getXpxlhYhkh request)
        {
            return base.Channel.getXpxlhYhkhAsync(request);
        }

        public System.Threading.Tasks.Task<getXpxlhYhkhResponse> getXpxlhYhkhAsync(string orgCode, string authKey, string sfzhm)
        {
            getXpxlhYhkh inValue = new getXpxlhYhkh();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.sfzhm = sfzhm;
            return ((HealthCardService)(this)).getXpxlhYhkhAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        syncCardStatusResponse HealthCardService.syncCardStatus(syncCardStatus request)
        {
            return base.Channel.syncCardStatus(request);
        }

        public WSResult syncCardStatus(string orgCode, string authKey, string operCode, string kh, string yycsdm, string fkxlh, string yhkh, string xpxlh)
        {
            syncCardStatus inValue = new syncCardStatus();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.operCode = operCode;
            inValue.kh = kh;
            inValue.yycsdm = yycsdm;
            inValue.fkxlh = fkxlh;
            inValue.yhkh = yhkh;
            inValue.xpxlh = xpxlh;
            syncCardStatusResponse retVal = ((HealthCardService)(this)).syncCardStatus(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<syncCardStatusResponse> HealthCardService.syncCardStatusAsync(syncCardStatus request)
        {
            return base.Channel.syncCardStatusAsync(request);
        }

        public System.Threading.Tasks.Task<syncCardStatusResponse> syncCardStatusAsync(string orgCode, string authKey, string operCode, string kh, string yycsdm, string fkxlh, string yhkh, string xpxlh)
        {
            syncCardStatus inValue = new syncCardStatus();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.operCode = operCode;
            inValue.kh = kh;
            inValue.yycsdm = yycsdm;
            inValue.fkxlh = fkxlh;
            inValue.yhkh = yhkh;
            inValue.xpxlh = xpxlh;
            return ((HealthCardService)(this)).syncCardStatusAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        publishBlackCardResponse HealthCardService.publishBlackCard(publishBlackCard request)
        {
            return base.Channel.publishBlackCard(request);
        }

        public BlackCardResult publishBlackCard(string orgCode, string authKey, string startDate, string endDate, string requestInfo)
        {
            publishBlackCard inValue = new publishBlackCard();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.startDate = startDate;
            inValue.endDate = endDate;
            inValue.requestInfo = requestInfo;
            publishBlackCardResponse retVal = ((HealthCardService)(this)).publishBlackCard(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<publishBlackCardResponse> HealthCardService.publishBlackCardAsync(publishBlackCard request)
        {
            return base.Channel.publishBlackCardAsync(request);
        }

        public System.Threading.Tasks.Task<publishBlackCardResponse> publishBlackCardAsync(string orgCode, string authKey, string startDate, string endDate, string requestInfo)
        {
            publishBlackCard inValue = new publishBlackCard();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.startDate = startDate;
            inValue.endDate = endDate;
            inValue.requestInfo = requestInfo;
            return ((HealthCardService)(this)).publishBlackCardAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        getAuthKeyResponse HealthCardService.getAuthKey(getAuthKey request)
        {
            return base.Channel.getAuthKey(request);
        }

        public AuthKey getAuthKey(string orgCode, string userName, string passWord)
        {
            getAuthKey inValue = new getAuthKey();
            inValue.orgCode = orgCode;
            inValue.userName = userName;
            inValue.passWord = passWord;
            getAuthKeyResponse retVal = ((HealthCardService)(this)).getAuthKey(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<getAuthKeyResponse> HealthCardService.getAuthKeyAsync(getAuthKey request)
        {
            return base.Channel.getAuthKeyAsync(request);
        }

        public System.Threading.Tasks.Task<getAuthKeyResponse> getAuthKeyAsync(string orgCode, string userName, string passWord)
        {
            getAuthKey inValue = new getAuthKey();
            inValue.orgCode = orgCode;
            inValue.userName = userName;
            inValue.passWord = passWord;
            return ((HealthCardService)(this)).getAuthKeyAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        publishBlackSamResponse HealthCardService.publishBlackSam(publishBlackSam request)
        {
            return base.Channel.publishBlackSam(request);
        }

        public BlackSamResult publishBlackSam(string orgCode, string authKey, string startDate, string endDate, string requestInfo)
        {
            publishBlackSam inValue = new publishBlackSam();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.startDate = startDate;
            inValue.endDate = endDate;
            inValue.requestInfo = requestInfo;
            publishBlackSamResponse retVal = ((HealthCardService)(this)).publishBlackSam(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<publishBlackSamResponse> HealthCardService.publishBlackSamAsync(publishBlackSam request)
        {
            return base.Channel.publishBlackSamAsync(request);
        }

        public System.Threading.Tasks.Task<publishBlackSamResponse> publishBlackSamAsync(string orgCode, string authKey, string startDate, string endDate, string requestInfo)
        {
            publishBlackSam inValue = new publishBlackSam();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.startDate = startDate;
            inValue.endDate = endDate;
            inValue.requestInfo = requestInfo;
            return ((HealthCardService)(this)).publishBlackSamAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        identifyPersonResponse HealthCardService.identifyPerson(identifyPerson request)
        {
            return base.Channel.identifyPerson(request);
        }

        public WSResult identifyPerson(string orgCode, string authKey, string xm, string zjhm, string zjlx, string mode, string img1, string img2, string img3, string brdh, string facevideo, string action_type, string virtualCardNum)
        {
            identifyPerson inValue = new identifyPerson();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.xm = xm;
            inValue.zjhm = zjhm;
            inValue.zjlx = zjlx;
            inValue.mode = mode;
            inValue.img1 = img1;
            inValue.img2 = img2;
            inValue.img3 = img3;
            inValue.brdh = brdh;
            inValue.facevideo = facevideo;
            inValue.action_type = action_type;
            inValue.virtualCardNum = virtualCardNum;
            identifyPersonResponse retVal = ((HealthCardService)(this)).identifyPerson(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<identifyPersonResponse> HealthCardService.identifyPersonAsync(identifyPerson request)
        {
            return base.Channel.identifyPersonAsync(request);
        }

        public System.Threading.Tasks.Task<identifyPersonResponse> identifyPersonAsync(string orgCode, string authKey, string xm, string zjhm, string zjlx, string mode, string img1, string img2, string img3, string brdh, string facevideo, string action_type, string virtualCardNum)
        {
            identifyPerson inValue = new identifyPerson();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.xm = xm;
            inValue.zjhm = zjhm;
            inValue.zjlx = zjlx;
            inValue.mode = mode;
            inValue.img1 = img1;
            inValue.img2 = img2;
            inValue.img3 = img3;
            inValue.brdh = brdh;
            inValue.facevideo = facevideo;
            inValue.action_type = action_type;
            inValue.virtualCardNum = virtualCardNum;
            return ((HealthCardService)(this)).identifyPersonAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        updateCardTypeResponse HealthCardService.updateCardType(updateCardType request)
        {
            return base.Channel.updateCardType(request);
        }

        public WSResult updateCardType(string orgCode, string authKey, string name, string zjlx, string zjhm, string tel, string issuingMode, string terminalType)
        {
            updateCardType inValue = new updateCardType();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.name = name;
            inValue.zjlx = zjlx;
            inValue.zjhm = zjhm;
            inValue.tel = tel;
            inValue.issuingMode = issuingMode;
            inValue.terminalType = terminalType;
            updateCardTypeResponse retVal = ((HealthCardService)(this)).updateCardType(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<updateCardTypeResponse> HealthCardService.updateCardTypeAsync(updateCardType request)
        {
            return base.Channel.updateCardTypeAsync(request);
        }

        public System.Threading.Tasks.Task<updateCardTypeResponse> updateCardTypeAsync(string orgCode, string authKey, string name, string zjlx, string zjhm, string tel, string issuingMode, string terminalType)
        {
            updateCardType inValue = new updateCardType();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.name = name;
            inValue.zjlx = zjlx;
            inValue.zjhm = zjhm;
            inValue.tel = tel;
            inValue.issuingMode = issuingMode;
            inValue.terminalType = terminalType;
            return ((HealthCardService)(this)).updateCardTypeAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        updateCardInfoResponse HealthCardService.updateCardInfo(updateCardInfo request)
        {
            return base.Channel.updateCardInfo(request);
        }

        public resUpdateVirCard updateCardInfo(string orgCode, string authKey, string qrCode, string issuingMode, string terminalType, people People)
        {
            updateCardInfo inValue = new updateCardInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.qrCode = qrCode;
            inValue.issuingMode = issuingMode;
            inValue.terminalType = terminalType;
            inValue.People = People;
            updateCardInfoResponse retVal = ((HealthCardService)(this)).updateCardInfo(inValue);
            return retVal.@return;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<updateCardInfoResponse> HealthCardService.updateCardInfoAsync(updateCardInfo request)
        {
            return base.Channel.updateCardInfoAsync(request);
        }

        public System.Threading.Tasks.Task<updateCardInfoResponse> updateCardInfoAsync(string orgCode, string authKey, string qrCode, string issuingMode, string terminalType, people People)
        {
            updateCardInfo inValue = new updateCardInfo();
            inValue.orgCode = orgCode;
            inValue.authKey = authKey;
            inValue.qrCode = qrCode;
            inValue.issuingMode = issuingMode;
            inValue.terminalType = terminalType;
            inValue.People = People;
            return ((HealthCardService)(this)).updateCardInfoAsync(inValue);
        }
    }
    #endregion

    #region 手术信息
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.apusic.com/esb/OperationService")]
    public interface OperationServiceInterface
    {

        // CODEGEN: 操作 GetOperationStatus 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/OperationService/GetOperationStatus", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        GetOperationStatusResponse1 GetOperationStatus(GetOperationStatusRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/OperationService/GetOperationStatus", ReplyAction = "*")]
        System.Threading.Tasks.Task<GetOperationStatusResponse1> GetOperationStatusAsync(GetOperationStatusRequest request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/OperationService")]
    public partial class GetOperationStatus : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/OperationService")]
    public partial class GetOperationStatusResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetOperationStatusRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/OperationService", Order = 0)]
        public GetOperationStatus GetOperationStatus;

        public GetOperationStatusRequest()
        {
        }

        public GetOperationStatusRequest(GetOperationStatus GetOperationStatus)
        {
            this.GetOperationStatus = GetOperationStatus;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetOperationStatusResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/OperationService", Order = 0)]
        public GetOperationStatusResponse GetOperationStatusResponse;

        public GetOperationStatusResponse1()
        {
        }

        public GetOperationStatusResponse1(GetOperationStatusResponse GetOperationStatusResponse)
        {
            this.GetOperationStatusResponse = GetOperationStatusResponse;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OperationServiceInterfaceChannel : OperationServiceInterface, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OperationServiceInterfaceClient : System.ServiceModel.ClientBase<OperationServiceInterface>, OperationServiceInterface
    {

        public OperationServiceInterfaceClient()
        {
        }

        public OperationServiceInterfaceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public OperationServiceInterfaceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public OperationServiceInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public OperationServiceInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GetOperationStatusResponse1 OperationServiceInterface.GetOperationStatus(GetOperationStatusRequest request)
        {
            return base.Channel.GetOperationStatus(request);
        }

        public GetOperationStatusResponse GetOperationStatus(GetOperationStatus GetOperationStatus1)
        {
            GetOperationStatusRequest inValue = new GetOperationStatusRequest();
            inValue.GetOperationStatus = GetOperationStatus1;
            GetOperationStatusResponse1 retVal = ((OperationServiceInterface)(this)).GetOperationStatus(inValue);
            return retVal.GetOperationStatusResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GetOperationStatusResponse1> OperationServiceInterface.GetOperationStatusAsync(GetOperationStatusRequest request)
        {
            return base.Channel.GetOperationStatusAsync(request);
        }

        public System.Threading.Tasks.Task<GetOperationStatusResponse1> GetOperationStatusAsync(GetOperationStatus GetOperationStatus)
        {
            GetOperationStatusRequest inValue = new GetOperationStatusRequest();
            inValue.GetOperationStatus = GetOperationStatus;
            return ((OperationServiceInterface)(this)).GetOperationStatusAsync(inValue);
        }
    }
    #endregion

    #region 体检报告
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public interface TiJianServicesInterface
    {

        // CODEGEN: 操作 tijianlb 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianlb", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        tijianlbResponse1 tijianlb(tijianlbRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianlb", ReplyAction = "*")]
        System.Threading.Tasks.Task<tijianlbResponse1> tijianlbAsync(tijianlbRequest request);

        // CODEGEN: 操作 tijianbgfm 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianbgfm", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        tijianbgfmResponse1 tijianbgfm(tijianbgfmRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianbgfm", ReplyAction = "*")]
        System.Threading.Tasks.Task<tijianbgfmResponse1> tijianbgfmAsync(tijianbgfmRequest request);

        // CODEGEN: 操作 tijianbcfsxmjg 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianbcfsxmjg", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        tijianbcfsxmjgResponse1 tijianbcfsxmjg(tijianbcfsxmjgRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianbcfsxmjg", ReplyAction = "*")]
        System.Threading.Tasks.Task<tijianbcfsxmjgResponse1> tijianbcfsxmjgAsync(tijianbcfsxmjgRequest request);

        // CODEGEN: 操作 tijianjyxmjg 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianjyxmjg", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        tijianjyxmjgResponse1 tijianjyxmjg(tijianjyxmjgRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianjyxmjg", ReplyAction = "*")]
        System.Threading.Tasks.Task<tijianjyxmjgResponse1> tijianjyxmjgAsync(tijianjyxmjgRequest request);

        // CODEGEN: 操作 tijianxmjg 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianxmjg", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        tijianxmjgResponse1 tijianxmjg(tijianxmjgRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianxmjg", ReplyAction = "*")]
        System.Threading.Tasks.Task<tijianxmjgResponse1> tijianxmjgAsync(tijianxmjgRequest request);

        // CODEGEN: 操作 tijianzd 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianzd", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        tijianzdResponse1 tijianzd(tijianzdRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.apusic.com/esb/tijianservices/tijianzd", ReplyAction = "*")]
        System.Threading.Tasks.Task<tijianzdResponse1> tijianzdAsync(tijianzdRequest request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianlb : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianzdResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianzd : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianxmjgResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianxmjg : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianjyxmjgResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianjyxmjg : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianbcfsxmjgResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianbcfsxmjg : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianbgfmResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianbgfm : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string inputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string input
        {
            get
            {
                return this.inputField;
            }
            set
            {
                this.inputField = value;
                this.RaisePropertyChanged("input");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.36415")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.apusic.com/esb/tijianservices")]
    public partial class tijianlbResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
                this.RaisePropertyChanged("output");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianlbRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianlb tijianlb;

        public tijianlbRequest()
        {
        }

        public tijianlbRequest(tijianlb tijianlb)
        {
            this.tijianlb = tijianlb;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianlbResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianlbResponse tijianlbResponse;

        public tijianlbResponse1()
        {
        }

        public tijianlbResponse1(tijianlbResponse tijianlbResponse)
        {
            this.tijianlbResponse = tijianlbResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianbgfmRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianbgfm tijianbgfm;

        public tijianbgfmRequest()
        {
        }

        public tijianbgfmRequest(tijianbgfm tijianbgfm)
        {
            this.tijianbgfm = tijianbgfm;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianbgfmResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianbgfmResponse tijianbgfmResponse;

        public tijianbgfmResponse1()
        {
        }

        public tijianbgfmResponse1(tijianbgfmResponse tijianbgfmResponse)
        {
            this.tijianbgfmResponse = tijianbgfmResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianbcfsxmjgRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianbcfsxmjg tijianbcfsxmjg;

        public tijianbcfsxmjgRequest()
        {
        }

        public tijianbcfsxmjgRequest(tijianbcfsxmjg tijianbcfsxmjg)
        {
            this.tijianbcfsxmjg = tijianbcfsxmjg;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianbcfsxmjgResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianbcfsxmjgResponse tijianbcfsxmjgResponse;

        public tijianbcfsxmjgResponse1()
        {
        }

        public tijianbcfsxmjgResponse1(tijianbcfsxmjgResponse tijianbcfsxmjgResponse)
        {
            this.tijianbcfsxmjgResponse = tijianbcfsxmjgResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianjyxmjgRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianjyxmjg tijianjyxmjg;

        public tijianjyxmjgRequest()
        {
        }

        public tijianjyxmjgRequest(tijianjyxmjg tijianjyxmjg)
        {
            this.tijianjyxmjg = tijianjyxmjg;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianjyxmjgResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianjyxmjgResponse tijianjyxmjgResponse;

        public tijianjyxmjgResponse1()
        {
        }

        public tijianjyxmjgResponse1(tijianjyxmjgResponse tijianjyxmjgResponse)
        {
            this.tijianjyxmjgResponse = tijianjyxmjgResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianxmjgRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianxmjg tijianxmjg;

        public tijianxmjgRequest()
        {
        }

        public tijianxmjgRequest(tijianxmjg tijianxmjg)
        {
            this.tijianxmjg = tijianxmjg;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianxmjgResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianxmjgResponse tijianxmjgResponse;

        public tijianxmjgResponse1()
        {
        }

        public tijianxmjgResponse1(tijianxmjgResponse tijianxmjgResponse)
        {
            this.tijianxmjgResponse = tijianxmjgResponse;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianzdRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianzd tijianzd;

        public tijianzdRequest()
        {
        }

        public tijianzdRequest(tijianzd tijianzd)
        {
            this.tijianzd = tijianzd;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class tijianzdResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.apusic.com/esb/tijianservices", Order = 0)]
        public tijianzdResponse tijianzdResponse;

        public tijianzdResponse1()
        {
        }

        public tijianzdResponse1(tijianzdResponse tijianzdResponse)
        {
            this.tijianzdResponse = tijianzdResponse;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface tijianservicesInterfaceChannel : TiJianServicesInterface, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class tijianservicesInterfaceClient : System.ServiceModel.ClientBase<TiJianServicesInterface>, TiJianServicesInterface
    {

        public tijianservicesInterfaceClient()
        {
        }

        public tijianservicesInterfaceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public tijianservicesInterfaceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public tijianservicesInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public tijianservicesInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        tijianlbResponse1 TiJianServicesInterface.tijianlb(tijianlbRequest request)
        {
            return base.Channel.tijianlb(request);
        }

        public tijianlbResponse tijianlb(tijianlb tijianlb1)
        {
            tijianlbRequest inValue = new tijianlbRequest();
            inValue.tijianlb = tijianlb1;
            tijianlbResponse1 retVal = ((TiJianServicesInterface)(this)).tijianlb(inValue);
            return retVal.tijianlbResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<tijianlbResponse1> TiJianServicesInterface.tijianlbAsync(tijianlbRequest request)
        {
            return base.Channel.tijianlbAsync(request);
        }

        public System.Threading.Tasks.Task<tijianlbResponse1> tijianlbAsync(tijianlb tijianlb)
        {
            tijianlbRequest inValue = new tijianlbRequest();
            inValue.tijianlb = tijianlb;
            return ((TiJianServicesInterface)(this)).tijianlbAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        tijianbgfmResponse1 TiJianServicesInterface.tijianbgfm(tijianbgfmRequest request)
        {
            return base.Channel.tijianbgfm(request);
        }

        public tijianbgfmResponse tijianbgfm(tijianbgfm tijianbgfm1)
        {
            tijianbgfmRequest inValue = new tijianbgfmRequest();
            inValue.tijianbgfm = tijianbgfm1;
            tijianbgfmResponse1 retVal = ((TiJianServicesInterface)(this)).tijianbgfm(inValue);
            return retVal.tijianbgfmResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<tijianbgfmResponse1> TiJianServicesInterface.tijianbgfmAsync(tijianbgfmRequest request)
        {
            return base.Channel.tijianbgfmAsync(request);
        }

        public System.Threading.Tasks.Task<tijianbgfmResponse1> tijianbgfmAsync(tijianbgfm tijianbgfm)
        {
            tijianbgfmRequest inValue = new tijianbgfmRequest();
            inValue.tijianbgfm = tijianbgfm;
            return ((TiJianServicesInterface)(this)).tijianbgfmAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        tijianbcfsxmjgResponse1 TiJianServicesInterface.tijianbcfsxmjg(tijianbcfsxmjgRequest request)
        {
            return base.Channel.tijianbcfsxmjg(request);
        }

        public tijianbcfsxmjgResponse tijianbcfsxmjg(tijianbcfsxmjg tijianbcfsxmjg1)
        {
            tijianbcfsxmjgRequest inValue = new tijianbcfsxmjgRequest();
            inValue.tijianbcfsxmjg = tijianbcfsxmjg1;
            tijianbcfsxmjgResponse1 retVal = ((TiJianServicesInterface)(this)).tijianbcfsxmjg(inValue);
            return retVal.tijianbcfsxmjgResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<tijianbcfsxmjgResponse1> TiJianServicesInterface.tijianbcfsxmjgAsync(tijianbcfsxmjgRequest request)
        {
            return base.Channel.tijianbcfsxmjgAsync(request);
        }

        public System.Threading.Tasks.Task<tijianbcfsxmjgResponse1> tijianbcfsxmjgAsync(tijianbcfsxmjg tijianbcfsxmjg)
        {
            tijianbcfsxmjgRequest inValue = new tijianbcfsxmjgRequest();
            inValue.tijianbcfsxmjg = tijianbcfsxmjg;
            return ((TiJianServicesInterface)(this)).tijianbcfsxmjgAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        tijianjyxmjgResponse1 TiJianServicesInterface.tijianjyxmjg(tijianjyxmjgRequest request)
        {
            return base.Channel.tijianjyxmjg(request);
        }

        public tijianjyxmjgResponse tijianjyxmjg(tijianjyxmjg tijianjyxmjg1)
        {
            tijianjyxmjgRequest inValue = new tijianjyxmjgRequest();
            inValue.tijianjyxmjg = tijianjyxmjg1;
            tijianjyxmjgResponse1 retVal = ((TiJianServicesInterface)(this)).tijianjyxmjg(inValue);
            return retVal.tijianjyxmjgResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<tijianjyxmjgResponse1> TiJianServicesInterface.tijianjyxmjgAsync(tijianjyxmjgRequest request)
        {
            return base.Channel.tijianjyxmjgAsync(request);
        }

        public System.Threading.Tasks.Task<tijianjyxmjgResponse1> tijianjyxmjgAsync(tijianjyxmjg tijianjyxmjg)
        {
            tijianjyxmjgRequest inValue = new tijianjyxmjgRequest();
            inValue.tijianjyxmjg = tijianjyxmjg;
            return ((TiJianServicesInterface)(this)).tijianjyxmjgAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        tijianxmjgResponse1 TiJianServicesInterface.tijianxmjg(tijianxmjgRequest request)
        {
            return base.Channel.tijianxmjg(request);
        }

        public tijianxmjgResponse tijianxmjg(tijianxmjg tijianxmjg1)
        {
            tijianxmjgRequest inValue = new tijianxmjgRequest();
            inValue.tijianxmjg = tijianxmjg1;
            tijianxmjgResponse1 retVal = ((TiJianServicesInterface)(this)).tijianxmjg(inValue);
            return retVal.tijianxmjgResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<tijianxmjgResponse1> TiJianServicesInterface.tijianxmjgAsync(tijianxmjgRequest request)
        {
            return base.Channel.tijianxmjgAsync(request);
        }

        public System.Threading.Tasks.Task<tijianxmjgResponse1> tijianxmjgAsync(tijianxmjg tijianxmjg)
        {
            tijianxmjgRequest inValue = new tijianxmjgRequest();
            inValue.tijianxmjg = tijianxmjg;
            return ((TiJianServicesInterface)(this)).tijianxmjgAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        tijianzdResponse1 TiJianServicesInterface.tijianzd(tijianzdRequest request)
        {
            return base.Channel.tijianzd(request);
        }

        public tijianzdResponse tijianzd(tijianzd tijianzd1)
        {
            tijianzdRequest inValue = new tijianzdRequest();
            inValue.tijianzd = tijianzd1;
            tijianzdResponse1 retVal = ((TiJianServicesInterface)(this)).tijianzd(inValue);
            return retVal.tijianzdResponse;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<tijianzdResponse1> TiJianServicesInterface.tijianzdAsync(tijianzdRequest request)
        {
            return base.Channel.tijianzdAsync(request);
        }

        public System.Threading.Tasks.Task<tijianzdResponse1> tijianzdAsync(tijianzd tijianzd)
        {
            tijianzdRequest inValue = new tijianzdRequest();
            inValue.tijianzd = tijianzd;
            return ((TiJianServicesInterface)(this)).tijianzdAsync(inValue);
        }
    }

    #endregion
}
