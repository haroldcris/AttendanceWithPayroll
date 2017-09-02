using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using AiTech.LiteOrm.Database.Search;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Dll.Payroll
{
    public class DeductionDataReader
    {
        public Deduction GetItem(string deductionCode)
        {
            const string query = "Select * from [Payroll_Deduction] where Code = @Code";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<Deduction>(query, new { Code = deductionCode }).FirstOrDefault();

                if (result == null) return null;

                result.RowStatus = RecordStatus.NoChanges;
                result.StartTrackingChanges();

                return result;
            }
        }



        public IEnumerable<Deduction> SearchItem(string searchItem, SearchStyleEnum searchStyle)
        {
            const string query = @"SELECT * from Payroll_Deduction where Description like @Criteria";

            var results = Search.SearchData<Dll.Payroll.Deduction>(searchItem, query, searchStyle);

            var deductions = results as IList<Deduction> ?? results.ToList();
            foreach (var item in deductions)
            {
                item.StartTrackingChanges();
            }

            return deductions;
        }



    }
}
