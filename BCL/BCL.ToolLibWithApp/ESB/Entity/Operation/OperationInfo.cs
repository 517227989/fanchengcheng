using System.Collections.Generic;

namespace BCL.ToolLibWithApp.ESB.Entity.Operation
{
    public class ExternalReqOperationInfo : ExternalReqBase
    {
        /// <summary>
        /// 住院号
        /// </summary>
        public string InHospitalId { get; set; }
        /// <summary>
        /// 病人号
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 手术室类型0：不限/1：手术室/2：分娩室
        /// </summary>
        public string OperationRoomType { get; set; }
    }

    public class ExternalResOperationInfo : ExternalResBase
    {
        /// <summary>
        /// 住院信息
        /// </summary>
        public List<OperationInfo> OperationInfos { get; set; }
    }

    public class OperationInfo
    {
        /// <summary>
        /// 手术状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 手术室编号
        /// </summary>
        public string RoomNo { get; set; }
        /// <summary>
        /// 住院Id
        /// </summary>
        public string InHospitalId { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 床位号
        /// </summary>
        public string BedNo { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 患者性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 手术室类型0：不限/1：手术室/2：分娩室
        /// </summary>
        public string OperationRoomType { get; set; }
    }
}
