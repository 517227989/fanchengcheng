﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLibWithApp.ESB.Entity.Reg
{
    /*
     * 挂号解锁
     */

    public class ExternalReqRegUnLockNo : ExternalReqBase
    {
        /// <summary>
        /// 挂号序号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 日排班Id
        /// </summary>
        public string DayId { get; set; }
    }

    public class ExternalResRegUnLockNo : ExternalResBase
    {

    }
}
