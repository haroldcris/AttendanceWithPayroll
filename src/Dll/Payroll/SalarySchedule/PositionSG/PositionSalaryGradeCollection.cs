using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System;

namespace Dll.Payroll
{
    public class PositionSalaryGradeCollection : EntityCollection<PositionSalaryGrade>
    {
        public Func<int> OnSalarySchedIdRequest;

        public bool LoadItemsFromDb()
        {
            const string query = @"Select IsNull(psg.Id,0) Id, p.Id PositionId, p.Code, p.Description, isnull(SG,0) SG from
                            Payroll_Position p left join  
                            (SELECT * FROM [Payroll_PositionSG] where SalaryScheduleId = @SchedId ) psg
                            on p.Id = psg.PositionId";


            ItemCollection.Clear();


            if (OnSalarySchedIdRequest == null) throw new Exception("OnSalarySchedIdRequest Handler NOT set");

            var salarySchedId = OnSalarySchedIdRequest();

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                dynamic items = db.Query<dynamic>(query, new { SchedId = salarySchedId });

                foreach (var row in items)
                {
                    var item = new PositionSalaryGrade
                    {
                        Id = row.Id,

                        PositionId = row.PositionId,
                        PositionCode = row.Code,
                        PositionDescription = row.Description,

                        SG = row.SG,

                        SalaryScheduleId = salarySchedId,

                        RowStatus = row.Id == 0 ? RecordStatus.NewRecord : RecordStatus.NoChanges
                    };


                    item.StartTrackingChanges();

                    ItemCollection.Add(item);
                }
            }

            //HasReadFromDb = true;
            return true;
        }


        //public void LoadDefaultItems()
        //{
        //    const string query = @"Select  p.Id PositionId, p.Code, p.Description, 0 SG from Payroll_Position p";


        //    ItemCollection.Clear();


        //    using (var db = Connection.CreateConnection())
        //    {
        //        db.Open();

        //        dynamic items = db.Query<dynamic>(query);

        //        foreach (var row in items)
        //        {
        //            var item = new PositionSalaryGrade
        //            {
        //                Id = row.Id,

        //                PositionId = row.PositionId,
        //                PositionCode = row.Code,
        //                PositionDescription = row.Description,

        //                SG = row.SG,

        //                SalaryScheduleId = salarySchedId,

        //                RowStatus = RecordStatus.NewRecord
        //            };


        //            item.StartTrackingChanges();

        //            ItemCollection.Add(item);
        //        }
        //    }
        //}

    }

}
