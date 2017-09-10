using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System;

namespace Dll.Biometric
{
    public class BiometricLogCollection : EntityCollection<BiometricLog>
    {

        private BiometricUser _biometricUser;


        public BiometricLogCollection()
        {

        }

        public BiometricLogCollection(BiometricUser parentBiometricUser)
        {
            _biometricUser = parentBiometricUser;
        }



        public void LoadAllItems()
        {
            var query = "select * from biometric_devicelog where biometricId = @BiometricId";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var results = db.Query<BiometricLog>(query, new
                {
                    BiometricId = _biometricUser.BiometricId,
                });


                if (results == null) return;
                LoadItemsWith(results);
            }
        }




        public void LoadItemsFor(DateTime date)
        {
            var firstDate = new DateTime(date.Year, date.Month, 1);
            var lastDate = (new DateTime(date.Year, date.Month + 1, 1));


            var query = "select * from biometric_devicelog where biometricId = @BiometricId and TimeLog between @DateFrom and @DateTo";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var results = db.Query<BiometricLog>(query, new
                {
                    BiometricId = _biometricUser.BiometricId,
                    DateFrom = firstDate,
                    DateTo = lastDate
                });


                if (results == null) return;
                LoadItemsWith(results);

            }
        }


    }
}
