using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System;
using System.Collections.Generic;

namespace Dll.Payroll
{
    public class PositionSalaryGradeCollection : EntityCollection<PositionSalaryGrade>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly SalarySchedule _salarySchedule = null;


        /// <summary>
        /// Blank Constructor for AiTech.Entity
        /// </summary>
        public PositionSalaryGradeCollection()
        {

        }



        public PositionSalaryGradeCollection(SalarySchedule parentSalarySched)
        {
            _salarySchedule = parentSalarySched;
        }



        /// <summary>
        /// Get all items from the Latest Effectivity Date of Salary Schedule
        /// </summary>
        /// <returns></returns>
        public bool LoadLatestSchedule()
        {
            const string query = @"Select IsNull(psg.Id,0) Id, p.Id PositionId, p.Code, p.Description, isnull(SG,0) SG, SalaryScheduleId from Payroll_Position p 
                            left join Payroll_PositionSG psg on p.Id = psg.PositionId
                            left join Payroll_SalarySchedule ss on ss.Id = psg.SalaryScheduleId
                            where ss.Id = (select top 1 id from Payroll_SalarySchedule order by Effectivity desc)";


            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                dynamic items = db.Query<dynamic>(query);

                LoadItemsToCollection(items);
            }

            //HasReadFromDb = true;
            return true;

        }




        public bool LoadItemsFromDb()
        {
            const string query = @"Select IsNull(psg.Id,0) Id, p.Id PositionId, p.Code, p.Description, isnull(SG,0) SG, IsNull(SalaryScheduleId, @SchedId) SalaryScheduleId from
                            Payroll_Position p left join  
                            (SELECT * FROM [Payroll_PositionSG] where SalaryScheduleId = @SchedId ) psg
                            on p.Id = psg.PositionId";


            ItemCollection.Clear();

            if (_salarySchedule == null) throw new Exception("Parent Salary Schedule NOT set");

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                dynamic items = db.Query<dynamic>(query, new { SchedId = _salarySchedule.Id });

                LoadItemsToCollection(items);
            }

            return true;
        }



        private void LoadItemsToCollection(IEnumerable<dynamic> items)
        {
            foreach (var row in items)
            {
                var item = new PositionSalaryGrade();


                item.Id = row.Id;

                item.PositionId = row.PositionId;
                item.PositionClass.Id = row.PositionId;
                item.PositionClass.Code = row.Code;
                item.PositionClass.Description = row.Description;

                item.SG = row.SG;

                item.SalaryScheduleId = row.SalaryScheduleId == null ? 0 : row.SalaryScheduleId;

                item.SalaryScheduleClass = _salarySchedule;

                item.RowStatus = row.Id == 0 ? RecordStatus.NewRecord : RecordStatus.NoChanges;

                item.StartTrackingChanges();

                ItemCollection.Add(item);
            }
        }
    }

}
