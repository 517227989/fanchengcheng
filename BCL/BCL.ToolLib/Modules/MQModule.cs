using Autofac;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Messaging;

namespace BCL.ToolLib.Modules
{
    public enum QLKind
    {
        /// <summary>
        /// 队尾
        /// </summary>
        TeamEnd,
        /// <summary>
        /// 原位
        /// </summary>
        OriginalLocation
    }
    /// <summary>
    /// MQ kind
    /// </summary>
    public enum MQKind
    {
        TLMQ,//top layer MQ
        RBMQ,//rabbit MQ
        MSMQ,//microsoft MQ
        ZKMQ,//zookeeper MQ
        KFMQ,//kafka MQ
    }
    /// <summary>
    /// MQ container
    /// </summary>
    public class MQModuleContainer
    {
        public IMQModule _MQModule { get; set; }
        public MQModuleContainer(MQKind _MQKind, MQModuleConfig _MQConfig = null)
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType(Type.GetType("BCL.ToolLib.Modules.MQModule_" + _MQKind.ToString()))
                       .WithParameter("_Config", _MQConfig)
                       .As<IMQModule>();
                _MQModule = builder.Build()
                                   .Resolve<IMQModule>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException());
            }
        }
    }
    /// <summary>
    /// MQ interface
    /// </summary>
    public interface IMQModule
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="_QueueName"></param>
        /// <param name="_QueueMessage"></param>
        void SendMessage(string _QueueName, string _QueueMessage);
        /// <summary>
        /// 消费消息
        /// </summary>
        /// <param name="_QueueName">队列名称</param>
        /// <param name="_Func">委托方法</param>
        void RecvMessage(string _QueueName, Func<string, bool> _Func, QLKind _QLKind = QLKind.TeamEnd);
    }
    public class MQModuleConfig
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoutName { get; set; }
        public string QueuName { get; set; }
    }
    public class MessageModel
    {
        [JsonProperty("MessageType")]
        public string MessageKind { get; set; }
        [JsonProperty("MessageDetail")]
        public string MessageBody { get; set; }
    }
    /// <summary>
    /// top layer MQ
    /// </summary>
    public class MQModule_TLMQ : MQModuleConfig
    {
        public MQModule_TLMQ()
        {
        }
        public MQModule_TLMQ(MQModuleConfig _Config)
        {
            if (_Config == null)
                _Config = new MQModuleConfig();
            HostName = _Config.HostName.IsNullOrEmptyOfVar() ? "HostName".ConfigValue("localhost") : _Config.HostName;
            UserName = _Config.UserName.IsNullOrEmptyOfVar() ? "UserName".ConfigValue("HospitalId".ConfigValue()) : _Config.UserName;
            Password = _Config.Password.IsNullOrEmptyOfVar() ? "Password".ConfigValue("HospitalId".ConfigValue()) : _Config.Password;
        }
    }
    /// <summary>
    /// rabbit MQ
    /// </summary>
    public class MQModule_RBMQ : MQModule_TLMQ, IMQModule
    {
        public MQModule_RBMQ()
        {
        }
        public MQModule_RBMQ(MQModuleConfig _Config) : base(_Config)
        {
        }
        public void RecvMessage(string _QueueName, Func<string, bool> _Func, QLKind _QLKind = QLKind.TeamEnd)
        {
            try
            {
                var _Factory = new ConnectionFactory
                {
                    HostName = HostName,
                    UserName = UserName,
                    Password = Password
                };

                using (var _Conn = _Factory.CreateConnection())
                {
                    using (var _Channel = _Conn.CreateModel())
                    {
                        //保证消息的不丢失(相对的)
                        bool durable = true;
                        _Channel.QueueDeclare(_QueueName, durable, false, false, null);
                        _Channel.BasicQos(0, 1, false);

                        var _Consumer = new QueueingBasicConsumer(_Channel);
                        _Channel.BasicConsume(_QueueName, false, _Consumer);

                        while (true)
                        {
                            var _Deliver = _Consumer.Queue.Dequeue();
                            var _Message = Encoding.UTF8.GetString(_Deliver.Body);

                            LogModule.Info("MQModule_RBMQ->RecvMessage:" + _QueueName + "\r\n" + _Message);
                            //处理业务
                            if (_Func(_Message) == false)
                            {
                                if (_QLKind == QLKind.TeamEnd)
                                    SendMessage(_QueueName, _Message);
                            }
                            _Channel.BasicAck(_Deliver.DeliveryTag, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogModule.Info("MQModule_RBMQ->RecvMessage:" + ex);
            }
        }

        public void SendMessage(string _QueueName, string _QueueMessage)
        {
            try
            {
                //创建工厂
                var _Factory = new ConnectionFactory
                {
                    HostName = HostName,
                    UserName = UserName,
                    Password = Password
                };

                //建立连接
                using (var _Conn = _Factory.CreateConnection())
                {
                    using (var _Channel = _Conn.CreateModel())
                    {
                        //声明队列
                        _Channel.QueueDeclare(_QueueName, true, false, false, null);

                        //设置持久化
                        var properties = _Channel.CreateBasicProperties();
                        properties.Persistent = true;
                        properties.DeliveryMode = 2;

                        //发送到RabbitMQ Server
                        _Channel.BasicPublish("", _QueueName, properties, Encoding.UTF8.GetBytes(_QueueMessage));
                        LogModule.Info("MQModule_RBMQ->SendMessage:" + _QueueName + "\r\n" + _QueueMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                LogModule.Info("MQModule_RBMQ->SendMessage:" + ex);
            }
        }
    }
    public class MQModule_MSMQ : MQModule_TLMQ, IMQModule
    {
        private XmlMessageFormatter _FORMATTER => new XmlMessageFormatter(new Type[1] { typeof(string) });
        public void RecvMessage(string _QueueName, Func<string, bool> _Func, QLKind _QLKind = QLKind.TeamEnd)
        {
            _QueueName = @".\Private$\" + _QueueName;
            if (MessageQueue.Exists(_QueueName))
            {
                using (var mq = new MessageQueue(_QueueName))
                {
                    while (true)
                    {
                        var _QueueMessage = mq.Receive();
                        _QueueMessage.Formatter = _FORMATTER;
                        if (_Func(_QueueMessage.Body.ToString()) == false)
                            mq.Send(_QueueMessage);
                    }
                }
            }
        }

        public void SendMessage(string _QueueName, string _QueueMessage)
        {
            _QueueName = @".\Private$\" + _QueueName;
            if (!MessageQueue.Exists(_QueueName))
                MessageQueue.Create(_QueueName);
            using (var mq = new MessageQueue(_QueueName))
            {
                mq.Send(new Message() { Formatter = _FORMATTER, Body = _QueueMessage });
            }
        }
    }
}