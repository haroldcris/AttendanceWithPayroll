using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Dll.Payroll
{

    public interface IPeriodEmployee
    {
        int PeriodId { get; set; }
        int PersonId { get; set; }
        int EmpId { get; set; }
        int EmpNum { get; set; }
        string Lastname { get; set; }
        string Firstname { get; set; }
        string Middlename { get; set; }
        string MI { get; set; }
        string NameExtension { get; set; }
        string Gender { get; set; }
        DateTime BirthDate { get; set; }
        DateTime DateHired { get; set; }
        string CurrentPosition { get; set; }
        int SG { get; set; }
        int Step { get; set; }
        string PagIbig { get; set; }
        string PhilHealth { get; set; }
        string SSS { get; set; }
        string TIN { get; set; }
        int TaxId { get; set; }
        string TaxShortDesc { get; set; }
        string TaxDescription { get; set; }
        Decimal TaxExemption { get; set; }
        Decimal GrossBasicSalary { get; set; }
        string PaymentCode { get; set; }
        string PaymentType { get; set; }
        Decimal BasicSalary { get; set; }
        DateTime pFrom { get; set; }
        DateTime pTo { get; set; }
        string Department { get; set; }
        string CameraCounter { get; set; }
        long SalarySchedID { get; set; }

    }



    [Table("Payroll_PeriodEmployee")]
    public class PeriodEmployee : Entity, IPeriodEmployee
    {

        #region Default Properties
        public int PeriodId { get; set; }
        public int PersonId { get; set; }
        public int EmpId { get; set; }
        public int EmpNum { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string MI { get; set; }
        public string NameExtension { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateHired { get; set; }
        public string CurrentPosition { get; set; }
        public int SG { get; set; }
        public int Step { get; set; }
        public string PagIbig { get; set; }
        public string PhilHealth { get; set; }
        public string SSS { get; set; }
        public string TIN { get; set; }
        public int TaxId { get; set; }
        public string TaxShortDesc { get; set; }
        public string TaxDescription { get; set; }
        public Decimal TaxExemption { get; set; }
        public Decimal GrossBasicSalary { get; set; }
        public string PaymentCode { get; set; }
        public string PaymentType { get; set; }
        public Decimal BasicSalary { get; set; }
        public DateTime pFrom { get; set; }
        public DateTime pTo { get; set; }
        public string Department { get; set; }
        public string CameraCounter { get; set; }
        public long SalarySchedID { get; set; }

        #endregion

        public PeriodEmployeeDeductionCollection Deductions { get; set; }


        public PeriodEmployee()
        {
            Deductions = new PeriodEmployeeDeductionCollection(this);
        }
        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"PeriodId", PeriodId},
                {"PersonId", PersonId},
                {"EmpId", EmpId},
                {"EmpNum", EmpNum},
                {"Lastname", Lastname},
                {"Firstname", Firstname},
                {"Middlename", Middlename},
                {"MI", MI},
                {"NameExtension", NameExtension},
                {"Gender", Gender},
                {"BirthDate", BirthDate},
                {"DateHired", DateHired},
                {"CurrentPosition", CurrentPosition},
                {"SG", SG},
                {"Step", Step},
                {"PagIbig", PagIbig},
                {"PhilHealth", PhilHealth},
                {"SSS", SSS},
                {"TIN", TIN},
                {"TaxId", TaxId},
                {"TaxShortDesc", TaxShortDesc},
                {"TaxDescription", TaxDescription},
                {"TaxExemption", TaxExemption},
                {"GrossBasicSalary", GrossBasicSalary},
                {"PaymentCode", PaymentCode},
                {"PaymentType", PaymentType},
                {"BasicSalary", BasicSalary},
                {"pFrom", pFrom},
                {"pTo", pTo},
                {"Department", Department},
                {"CameraCounter", CameraCounter},
                {"SalarySchedID", SalarySchedID}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(PeriodId, OriginalValues["PeriodId"])) changes.Add("PeriodId", PeriodId);
            if (!Equals(PersonId, OriginalValues["PersonId"])) changes.Add("PersonId", PersonId);
            if (!Equals(EmpId, OriginalValues["EmpId"])) changes.Add("EmpId", EmpId);
            if (!Equals(EmpNum, OriginalValues["EmpNum"])) changes.Add("EmpNum", EmpNum);
            if (!Equals(Lastname, OriginalValues["Lastname"])) changes.Add("Lastname", Lastname);
            if (!Equals(Firstname, OriginalValues["Firstname"])) changes.Add("Firstname", Firstname);
            if (!Equals(Middlename, OriginalValues["Middlename"])) changes.Add("Middlename", Middlename);
            if (!Equals(MI, OriginalValues["MI"])) changes.Add("MI", MI);
            if (!Equals(NameExtension, OriginalValues["NameExtension"])) changes.Add("NameExtension", NameExtension);
            if (!Equals(Gender, OriginalValues["Gender"])) changes.Add("Gender", Gender);
            if (!Equals(BirthDate, OriginalValues["BirthDate"])) changes.Add("BirthDate", BirthDate);
            if (!Equals(DateHired, OriginalValues["DateHired"])) changes.Add("DateHired", DateHired);
            if (!Equals(CurrentPosition, OriginalValues["CurrentPosition"])) changes.Add("CurrentPosition", CurrentPosition);
            if (!Equals(SG, OriginalValues["SG"])) changes.Add("SG", SG);
            if (!Equals(Step, OriginalValues["Step"])) changes.Add("Step", Step);
            if (!Equals(PagIbig, OriginalValues["PagIbig"])) changes.Add("PagIbig", PagIbig);
            if (!Equals(PhilHealth, OriginalValues["PhilHealth"])) changes.Add("PhilHealth", PhilHealth);
            if (!Equals(SSS, OriginalValues["SSS"])) changes.Add("SSS", SSS);
            if (!Equals(TIN, OriginalValues["TIN"])) changes.Add("TIN", TIN);
            if (!Equals(TaxId, OriginalValues["TaxId"])) changes.Add("TaxId", TaxId);
            if (!Equals(TaxShortDesc, OriginalValues["TaxShortDesc"])) changes.Add("TaxShortDesc", TaxShortDesc);
            if (!Equals(TaxDescription, OriginalValues["TaxDescription"])) changes.Add("TaxDescription", TaxDescription);
            if (!Equals(TaxExemption, OriginalValues["TaxExemption"])) changes.Add("TaxExemption", TaxExemption);
            if (!Equals(GrossBasicSalary, OriginalValues["GrossBasicSalary"])) changes.Add("GrossBasicSalary", GrossBasicSalary);
            if (!Equals(PaymentCode, OriginalValues["PaymentCode"])) changes.Add("PaymentCode", PaymentCode);
            if (!Equals(PaymentType, OriginalValues["PaymentType"])) changes.Add("PaymentType", PaymentType);
            if (!Equals(BasicSalary, OriginalValues["BasicSalary"])) changes.Add("BasicSalary", BasicSalary);
            if (!Equals(pFrom, OriginalValues["pFrom"])) changes.Add("pFrom", pFrom);

            if (!Equals(pTo, OriginalValues["pTo"])) changes.Add("pTo", pTo);
            if (!Equals(Department, OriginalValues["Department"])) changes.Add("Department", Department);
            if (!Equals(CameraCounter, OriginalValues["CameraCounter"])) changes.Add("CameraCounter", CameraCounter);
            if (!Equals(SalarySchedID, OriginalValues["SalarySchedID"])) changes.Add("SalarySchedID", SalarySchedID);


            return changes;
        }


    }

}
