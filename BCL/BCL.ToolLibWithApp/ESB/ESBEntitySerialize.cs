using BCL.ToolLib;

namespace BCL.ToolLibWithApp.ESB
{
    public static class ESBEntitySerialize
    {
        #region 基础业务
        /*Req*/
        public static Entity.Basic.ExternalReqDepts SerializeReqDepts(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Basic.ExternalReqDepts>(obj);
        }

        public static Entity.Basic.ExternalReqDoctors SerializeReqDoctors(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Basic.ExternalReqDoctors>(obj);
        }

        public static Entity.Basic.ExternalReqDrugs SerializeReqDrugs(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Basic.ExternalReqDrugs>(obj);
        }

        public static Entity.Basic.ExternalReqMedicals SerializeReqMedicals(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Basic.ExternalReqMedicals>(obj);
        }
        /*Res*/
        public static Entity.Basic.ExternalResDepts SerializeResDepts(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Basic.ExternalResDepts>(obj);
        }

        public static Entity.Basic.ExternalResDoctors SerializeResDoctors(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Basic.ExternalResDoctors>(obj);
        }

        public static Entity.Basic.ExternalResDrugs SerializeResDrugs(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Basic.ExternalResDrugs>(obj);
        }

        public static Entity.Basic.ExternalResMedicals SerializeResMedicals(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Basic.ExternalResMedicals>(obj);
        }
        #endregion 

        #region 患者业务
        /*req*/
        public static Entity.Patient.ExternalReqPatientInformation SerializeReqPatientInformation(string obj)
        {
            return obj.ToEntity<Entity.Patient.ExternalReqPatientInformation>();
        }

        public static Entity.Patient.ExternalReqPatientInformationAdd SerializeReqPatientInformationAdd(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Patient.ExternalReqPatientInformationAdd>(obj);
        }

        public static Entity.Patient.ExternalReqPatientInformationDel SerializeReqPatientInformationDel(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Patient.ExternalReqPatientInformationDel>(obj);
        }

        public static Entity.Patient.ExternalReqPatientInformationMod SerializeReqPatientInformationMod(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Patient.ExternalReqPatientInformationMod>(obj);
        }

        public static Entity.Patient.ExternalReqAddOrDeleteDetailFee SerializeReqAddOrDeleteDetailFee(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Patient.ExternalReqAddOrDeleteDetailFee>(obj);
        }
        /*res*/
        public static Entity.Patient.ExternalResPatientInformation SerializeResPatientInformation(string obj)
        {
            return obj.ToEntity<Entity.Patient.ExternalResPatientInformation>();
        }

        public static Entity.Patient.ExternalResPatientInformationAdd SerializeResPatientInformationAdd(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Patient.ExternalResPatientInformationAdd>(obj);
        }

        public static Entity.Patient.ExternalResPatientInformationDel SerializeResPatientInformationDel(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Patient.ExternalResPatientInformationDel>(obj);
        }

        public static Entity.Patient.ExternalResPatientInformationMod SerializeResPatientInformationMod(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Patient.ExternalResPatientInformationMod>(obj);
        }

        public static Entity.Patient.ExternalResAddOrDeleteDetailFee SerializeResAddOrDeleteDetailFee(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Patient.ExternalResAddOrDeleteDetailFee>(obj);
        }
        #endregion

        #region 挂号业务
        /*req*/
        public static Entity.Reg.ExternalReqSchedulings SerializeReqSchedulings(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalReqSchedulings>(obj);
        }

        public static Entity.Reg.ExternalReqNumberSources SerializeReqNumberSources(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalReqNumberSources>(obj);
        }

        public static Entity.Reg.ExternalReqQueueQuery SerializeReqQueueQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalReqQueueQuery>(obj);
        }

        public static Entity.Reg.ExternalReqRegPatientQuery SerializeReqRegPatientQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalReqRegPatientQuery>(obj);
        }

        public static Entity.Reg.ExternalReqRegCancel SerializeReqRegCancel(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalReqRegCancel>(obj);
        }

        public static Entity.Reg.ExternalReqRegister SerializeReqRegister(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalReqRegister>(obj);
        }

        public static Entity.Reg.ExternalReqRegLockNo SerializeReqRegLockNo(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalReqRegLockNo>(obj);
        }

        public static Entity.Reg.ExternalReqRegPay SerializeReqRegPay(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalReqRegPay>(obj);
        }

        public static Entity.Reg.ExternalReqRegPrePay SerializeReqRegPrePay(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalReqRegPrePay>(obj);
        }

        public static Entity.Reg.ExternalReqRegQuery SerializeReqRegQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalReqRegQuery>(obj);
        }

        public static Entity.Reg.ExternalReqRegUnLockNo SerializeReqRegUnLockNo(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalReqRegUnLockNo>(obj);
        }

        public static Entity.Res.ExternalReqResCancel SerializeReqResCancel(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalReqResCancel>(obj);
        }

        public static Entity.Res.ExternalReqReserve SerializeReqReserve(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalReqReserve>(obj);
        }

        public static Entity.Res.ExternalReqReserveCancel SerializeReqReserveCancel(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalReqReserveCancel>(obj);
        }

        public static Entity.Res.ExternalReqResPay SerializeReqResPay(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalReqResPay>(obj);
        }

        public static Entity.Res.ExternalReqResQuery SerializeReqResQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalReqResQuery>(obj);
        }

        public static Entity.Res.ExternalReqResTake SerializeReqResTake(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalReqResTake>(obj);
        }
        /*res*/
        public static Entity.Reg.ExternalResSchedulings SerializeResSchedulings(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalResSchedulings>(obj);
        }

        public static Entity.Reg.ExternalResNumberSources SerializeResNumberSources(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalResNumberSources>(obj);
        }

        public static Entity.Reg.ExternalResQueueQuery SerializeResQueueQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalResQueueQuery>(obj);
        }

        public static Entity.Reg.ExternalResRegPatientQuery SerializeResRegPatientQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalResRegPatientQuery>(obj);
        }

        public static Entity.Reg.ExternalResRegCancel SerializeResRegCancel(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalResRegCancel>(obj);
        }

        public static Entity.Reg.ExternalResRegister SerializeResRegister(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalResRegister>(obj);
        }

        public static Entity.Reg.ExternalResRegLockNo SerializeResRegLockNo(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalResRegLockNo>(obj);
        }

        public static Entity.Reg.ExternalResRegPay SerializeResRegPay(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalResRegPay>(obj);
        }

        public static Entity.Reg.ExternalResRegPrePay SerializeResRegPrePay(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalResRegPrePay>(obj);
        }

        public static Entity.Reg.ExternalResRegQuery SerializeResRegQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalResRegQuery>(obj);
        }

        public static Entity.Reg.ExternalResRegUnLockNo SerializeResRegUnLockNo(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Reg.ExternalResRegUnLockNo>(obj);
        }

        public static Entity.Res.ExternalResResCancel SerializeResResCancel(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalResResCancel>(obj);
        }

        public static Entity.Res.ExternalResReserve SerializeResReserve(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalResReserve>(obj);
        }

        public static Entity.Res.ExternalResReserveCancel SerializeResReserveCancel(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalResReserveCancel>(obj);
        }

        public static Entity.Res.ExternalResResPay SerializeResResPay(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalResResPay>(obj);
        }

        public static Entity.Res.ExternalResResQuery SerializeResResQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalResResQuery>(obj);
        }

        public static Entity.Res.ExternalResResTake SerializeResResTake(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Res.ExternalResResTake>(obj);
        }
        #endregion

        #region 检查业务
        public static Entity.Examination.ExternalReqExamResultQuery SerializeReqExamResultQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Examination.ExternalReqExamResultQuery>(obj);
        }

        public static Entity.Examination.ExternalResExamResultQuery SerializeResExamResultQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Examination.ExternalResExamResultQuery>(obj);
        }
        #endregion

        #region 检验业务
        public static Entity.Inspection.ExternalReqInspectionResultQuery SerializeReqInspectionResultQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Inspection.ExternalReqInspectionResultQuery>(obj);
        }

        public static Entity.Inspection.ExternalResInspectionResultQuery SerializeResInspectionResultQuery(string obj)
        {
            return ToolsContainer.ToEntity<Entity.Inspection.ExternalResInspectionResultQuery>(obj);
        }
        #endregion

        #region 门诊业务
        /*req*/
        public static Entity.OutPatient.ExternalReqOutPatientBillRecords SerializeReqOutPatientBillRecords(string biz)
        {
            return ToolsContainer.ToEntity<Entity.OutPatient.ExternalReqOutPatientBillRecords>(biz);
        }

        public static Entity.OutPatient.ExternalReqOutPatientChargeDetails SerializeReqOutPatientChargeDetails(string biz)
        {
            return ToolsContainer.ToEntity<Entity.OutPatient.ExternalReqOutPatientChargeDetails>(biz);
        }

        public static Entity.OutPatient.ExternalReqOutPatientChargePay SerializeReqOutPatientChargePay(string biz)
        {
            return ToolsContainer.ToEntity<Entity.OutPatient.ExternalReqOutPatientChargePay>(biz);
        }

        public static Entity.OutPatient.ExternalReqOutPatientChargePay SerializeReqOutPatientChargePrePay(string biz)
        {
            return ToolsContainer.ToEntity<Entity.OutPatient.ExternalReqOutPatientChargePay>(biz);
        }
        /*res*/
        public static Entity.OutPatient.ExternalResOutPatientBillRecords SerializeResOutPatientBillRecords(string biz)
        {
            return ToolsContainer.ToEntity<Entity.OutPatient.ExternalResOutPatientBillRecords>(biz);
        }

        public static Entity.OutPatient.ExternalResOutPatientChargeDetails SerializeResOutPatientChargeDetails(string biz)
        {
            return ToolsContainer.ToEntity<Entity.OutPatient.ExternalResOutPatientChargeDetails>(biz);
        }

        public static Entity.OutPatient.ExternalResOutPatientChargePay SerializeResOutPatientChargePay(string biz)
        {
            return ToolsContainer.ToEntity<Entity.OutPatient.ExternalResOutPatientChargePay>(biz);
        }

        public static Entity.OutPatient.ExternalResOutPatientChargePay SerializeResOutPatientChargePrePay(string biz)
        {
            return ToolsContainer.ToEntity<Entity.OutPatient.ExternalResOutPatientChargePay>(biz);
        }
        #endregion

        #region 诊间业务
        public static Entity.Medical.ExternalReqTreatmentInfoQuery SerializeReqTreatmentInfoQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Medical.ExternalReqTreatmentInfoQuery>(biz);
        }

        public static Entity.Medical.ExternalResTreatmentInfoQuery SerializeResTreatmentInfoQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Medical.ExternalResTreatmentInfoQuery>(biz);
        }
        #endregion

        #region 住院业务
        /*req*/
        public static Entity.InHospital.ExternalReqInHospitalDeposit SerializeReqInHospitalDeposit(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalReqInHospitalDeposit>(biz);
        }

        public static Entity.InHospital.ExternalReqInHospitalDepositQuery SerializeReqInHospitalDepositQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalReqInHospitalDepositQuery>(biz);
        }

        public static Entity.InHospital.ExternalReqInHospitalFeesQuery SerializeReqInHospitalFeesQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalReqInHospitalFeesQuery>(biz);
        }

        public static Entity.InHospital.ExternalReqInHospitalRegisterQuery SerializeReqInHospitalRegisterQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalReqInHospitalRegisterQuery>(biz);
        }

        public static Entity.InHospital.ExternalReqInHospitalRegistration SerializeReqInHospitalRegistration(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalReqInHospitalRegistration>(biz);
        }

        public static Entity.InHospital.ExternalReqInHospitalBill SerializeReqInHospitalBill(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalReqInHospitalBill>(biz);
        }

        public static Entity.InHospital.ExternalReqInHospitalPreBill SerializeReqInHospitalPreBill(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalReqInHospitalPreBill>(biz);
        }

        public static Entity.InHospital.ExternalReqInHospitalDepositConfirm SerializeReqInHospitalDepositConfirm(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalReqInHospitalDepositConfirm>(biz);
        }

        public static Entity.InHospital.ExternalReqInHospitalBedQuery SerializeReqInHospitalBedQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalReqInHospitalBedQuery>(biz);
        }

        /*res*/
        public static Entity.InHospital.ExternalResInHospitalDeposit SerializeResInHospitalDeposit(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalResInHospitalDeposit>(biz);
        }

        public static Entity.InHospital.ExternalResInHospitalDepositQuery SerializeResInHospitalDepositQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalResInHospitalDepositQuery>(biz);
        }

        public static Entity.InHospital.ExternalResInHospitalFeesQuery SerializeResInHospitalFeesQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalResInHospitalFeesQuery>(biz);
        }

        public static Entity.InHospital.ExternalResInHospitalRegisterQuery SerializeResInHospitalRegisterQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalResInHospitalRegisterQuery>(biz);
        }

        public static Entity.InHospital.ExternalResInHospitalRegistration SerializeResInHospitalRegistration(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalResInHospitalRegistration>(biz);
        }

        public static Entity.InHospital.ExternalResInHospitalBill SerializeResInHospitalBill(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalResInHospitalBill>(biz);
        }

        public static Entity.InHospital.ExternalResInHospitalPreBill SerializeResInHospitalPreBill(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalResInHospitalPreBill>(biz);
        }

        public static Entity.InHospital.ExternalResInHospitalDepositConfirm SerializeResInHospitalDepositConfirm(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalResInHospitalDepositConfirm>(biz);
        }

        public static Entity.InHospital.ExternalResInHospitalBedQuery SerializeResInHospitalBedQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.InHospital.ExternalResInHospitalBedQuery>(biz);
        }
        #endregion

        #region 门诊分诊业务
        /*req*/
        public static Entity.Assignation.ExternalReqAutoRoomScheduling SerializeReqAutoRoomScheduling(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqAutoRoomScheduling>(biz);
        }

        public static Entity.Assignation.ExternalReqCallAgain SerializeReqCallAgain(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqCallAgain>(biz);
        }

        public static Entity.Assignation.ExternalReqCallNext SerializeReqCallNext(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqCallNext>(biz);
        }

        public static Entity.Assignation.ExternalReqCheckedPatientList SerializeReqCheckedPatientList(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqCheckedPatientList>(biz);
        }

        public static Entity.Assignation.ExternalReqCheckSet SerializeReqCheckSet(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqCheckSet>(biz);
        }

        public static Entity.Assignation.ExternalReqChooseCall SerializeReqChooseCall(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqChooseCall>(biz);
        }

        public static Entity.Assignation.ExternalReqDoctorLoginDept SerializeReqDoctorLoginDept(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqDoctorLoginDept>(biz);
        }

        public static Entity.Assignation.ExternalReqDoctorPause SerializeReqDoctorPause(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqDoctorPause>(biz);
        }

        public static Entity.Assignation.ExternalReqDoctorState SerializeReqDoctorState(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqDoctorState>(biz);
        }

        public static Entity.Assignation.ExternalReqExamCallAgain SerializeReqExamCallAgain(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqExamCallAgain>(biz);
        }

        public static Entity.Assignation.ExternalReqExamCallNext SerializeReqExamCallNext(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqExamCallNext>(biz);
        }

        public static Entity.Assignation.ExternalReqExamCheckedPatientList SerializeReqExamCheckedPatientList(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqExamCheckedPatientList>(biz);
        }

        public static Entity.Assignation.ExternalReqExamLogin SerializeReqExamLogin(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqExamLogin>(biz);
        }

        public static Entity.Assignation.ExternalReqExamLoginDept SerializeReqExamLoginDept(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqExamLoginDept>(biz);
        }

        public static Entity.Assignation.ExternalReqExamTake SerializeReqExamTake(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqExamTake>(biz);
        }

        public static Entity.Assignation.ExternalReqGetVar SerializeReqGetVar(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqGetVar>(biz);
        }

        public static Entity.Assignation.ExternalReqPatientCanCheckQuery SerializeReqPatientCanCheckQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqPatientCanCheckQuery>(biz);
        }

        public static Entity.Assignation.ExternalReqPatientCheck SerializeReqPatientCheck(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqPatientCheck>(biz);
        }

        public static Entity.Assignation.ExternalReqPatientCheckedQuery SerializeReqPatientCheckedQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqPatientCheckedQuery>(biz);
        }

        public static Entity.Assignation.ExternalReqPatientReferralCheck SerializeReqPatientReferralCheck(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqPatientReferralCheck>(biz);
        }

        public static Entity.Assignation.ExternalReqPatientUniCheck SerializeReqPatientUniCheck(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqPatientUniCheck>(biz);
        }

        public static Entity.Assignation.ExternalReqQueueAdjust SerializeReqQueueAdjust(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqQueueAdjust>(biz);
        }

        public static Entity.Assignation.ExternalReqRescueBug SerializeReqRescueBug(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqRescueBug>(biz);
        }

        public static Entity.Assignation.ExternalReqRoomLogin SerializeReqRoomLogin(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqRoomLogin>(biz);
        }

        public static Entity.Assignation.ExternalReqRoomLogout SerializeReqRoomLogout(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqRoomLogout>(biz);
        }

        /**/
        public static Entity.Assignation.ExternalResAutoRoomScheduling SerializeResAutoRoomScheduling(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResAutoRoomScheduling>(biz);
        }

        public static Entity.Assignation.ExternalResCallAgain SerializeResCallAgain(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResCallAgain>(biz);
        }

        public static Entity.Assignation.ExternalResCallNext SerializeResCallNext(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResCallNext>(biz);
        }

        public static Entity.Assignation.ExternalResCheckedPatientList SerializeResCheckedPatientList(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResCheckedPatientList>(biz);
        }

        public static Entity.Assignation.ExternalResCheckSet SerializeResCheckSet(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResCheckSet>(biz);
        }

        public static Entity.Assignation.ExternalResChooseCall SerializeResChooseCall(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResChooseCall>(biz);
        }

        public static Entity.Assignation.ExternalResDoctorLoginDept SerializeResDoctorLoginDept(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResDoctorLoginDept>(biz);
        }

        public static Entity.Assignation.ExternalResDoctorPause SerializeResDoctorPause(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResDoctorPause>(biz);
        }

        public static Entity.Assignation.ExternalResDoctorState SerializeResDoctorState(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResDoctorState>(biz);
        }

        public static Entity.Assignation.ExternalResExamCallAgain SerializeResExamCallAgain(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResExamCallAgain>(biz);
        }

        public static Entity.Assignation.ExternalResExamCallNext SerializeResExamCallNext(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResExamCallNext>(biz);
        }

        public static Entity.Assignation.ExternalResExamCheckedPatientList SerializeResExamCheckedPatientList(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResExamCheckedPatientList>(biz);
        }

        public static Entity.Assignation.ExternalResExamLogin SerializeResExamLogin(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResExamLogin>(biz);
        }

        public static Entity.Assignation.ExternalResExamLoginDept SerializeResExamLoginDept(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResExamLoginDept>(biz);
        }

        public static Entity.Assignation.ExternalResExamTake SerializeResExamTake(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResExamTake>(biz);
        }

        public static Entity.Assignation.ExternalResGetVar SerializeResGetVar(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResGetVar>(biz);
        }

        public static Entity.Assignation.ExternalResPatientCanCheckQuery SerializeResPatientCanCheckQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResPatientCanCheckQuery>(biz);
        }

        public static Entity.Assignation.ExternalResPatientCheck SerializeResPatientCheck(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResPatientCheck>(biz);
        }

        public static Entity.Assignation.ExternalResPatientCheckedQuery SerializeResPatientCheckedQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResPatientCheckedQuery>(biz);
        }

        public static Entity.Assignation.ExternalResPatientReferralCheck SerializeResPatientReferralCheck(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResPatientReferralCheck>(biz);
        }

        public static Entity.Assignation.ExternalResPatientUniCheck SerializeResPatientUniCheck(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResPatientUniCheck>(biz);
        }

        public static Entity.Assignation.ExternalResQueueAdjust SerializeResQueueAdjust(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResQueueAdjust>(biz);
        }

        public static Entity.Assignation.ExternalResRescueBug SerializeResRescueBug(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResRescueBug>(biz);
        }

        public static Entity.Assignation.ExternalResRoomLogin SerializeResRoomLogin(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResRoomLogin>(biz);
        }

        public static Entity.Assignation.ExternalResRoomLogout SerializeResRoomLogout(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResRoomLogout>(biz);
        }
        #endregion

        #region 医技分诊

        #endregion

        #region 发票
        /*req*/
        public static Entity.Invoice.ExternalReqInvoiceCurrNoMod SerializeReqInvoiceCurrNoMod(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Invoice.ExternalReqInvoiceCurrNoMod>(biz);
        }

        public static Entity.Invoice.ExternalReqInvoiceCurrNoQuery SerializeReqInvoiceCurrNoQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Invoice.ExternalReqInvoiceCurrNoQuery>(biz);
        }

        public static Entity.Invoice.ExternalReqInvoiceEnabled SerializeReqInvoiceEnabled(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Invoice.ExternalReqInvoiceEnabled>(biz);
        }

        public static Entity.Invoice.ExternalReqInvoiceQuery SerializeReqInvoiceQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Invoice.ExternalReqInvoiceQuery>(biz);
        }
        /*res*/
        public static Entity.Invoice.ExternalResInvoiceCurrNoMod SerializeResInvoiceCurrNoMod(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Invoice.ExternalResInvoiceCurrNoMod>(biz);
        }

        public static Entity.Invoice.ExternalResInvoiceCurrNoQuery SerializeResInvoiceCurrNoQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Invoice.ExternalResInvoiceCurrNoQuery>(biz);
        }

        public static Entity.Invoice.ExternalResInvoiceEnabled SerializeResInvoiceEnabled(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Invoice.ExternalResInvoiceEnabled>(biz);
        }

        public static Entity.Invoice.ExternalResInvoiceQuery SerializeResInvoiceQuery(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Invoice.ExternalResInvoiceQuery>(biz);
        }
        #endregion

        public static Entity.Refund.ExternalReqRefund SerializeReqRefund(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Refund.ExternalReqRefund>(biz);
        }

        public static Entity.Refund.ExternalResRefund SerializeResRefund(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Refund.ExternalResRefund>(biz);
        }

        public static Entity.RollingAcc.ExternalReqRollAcc SerializeReqRollAcc(string biz)
        {
            return ToolsContainer.ToEntity<Entity.RollingAcc.ExternalReqRollAcc>(biz);
        }

        public static Entity.RollingAcc.ExternalResRollAcc SerializeResRollAcc(string biz)
        {
            return ToolsContainer.ToEntity<Entity.RollingAcc.ExternalResRollAcc>(biz);
        }

        public static Entity.Operation.ExternalReqOperationInfo SerializeReqOperationInfo(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Operation.ExternalReqOperationInfo>(biz);
        }

        public static Entity.Operation.ExternalResOperationInfo SerializeResOperationInfo(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Operation.ExternalResOperationInfo>(biz);
        }

        public static Entity.Assignation.ExternalReqCheckFeasibility SerializeReqCheckFeasibility(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalReqCheckFeasibility>(biz);
        }

        public static Entity.Assignation.ExternalResCheckFeasibility SerializeResCheckFeasibility(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Assignation.ExternalResCheckFeasibility>(biz);
        }

        public static Entity.Basic.ExternalReqPathologicalReportPrint SerializeReqPathologicalReportPrint(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Basic.ExternalReqPathologicalReportPrint>(biz);
        }

        public static Entity.Basic.ExternalResPathologicalReportPrint SerializeResPathologicalReportPrint(string biz)
        {
            return ToolsContainer.ToEntity<Entity.Basic.ExternalResPathologicalReportPrint>(biz);
        }
    }

    public static class ESBEntityDeSerializeReq
    {
    }
}
