using AiTech.LiteOrm.Database;
using AiTech.LiteOrm.Database.Search;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Dll.Biometric
{
    public class BiometricUserDataReader
    {
        public bool HasExistingBiometricId(int biometricId)
        {
            const string query = "SELECT 1 from Biometric_User where BiometricId = @BiometricId";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<int>(query, new { BiometricId = biometricId });

                return result.Any();
            }


        }


        public bool HasExistingPersonId(int personId)
        {
            const string query = "SELECT 1 from Biometric_User where PersonId = @PersonId";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<int>(query, new { PersonId = personId });

                return result.Any();
            }
        }



        public string GetPhoneNumberOf(int biometricId)
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<string>("Select PhoneNumber from Biometric_User b  inner join Person p on p.id = b.PersonId " +
                                              " where BiometricId = @BiometricId", new { biometricId = biometricId }).FirstOrDefault();
                return result;
            }
        }



        public BiometricUser GetBasicInfoForSmsOf(int biometricId)
        {
            var query = @"Select b.BiometricId, b.Category, b.PhoneNumber
                            , Lastname, Firstname, Middlename, MiddleInitial, NameExtension, MaidenMiddlename
                            , gender, CameraCounter
                            from Biometric_User b  inner join Person p on p.id = b.PersonId
                            where BiometricId = @BiometricId";


            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var result = db.Query(query, new { BiometricId = biometricId }).FirstOrDefault();

                if (result == null) return null;

                var item = new BiometricUser();

                item.Map(result);
                item.PersonClass.DataMapper.Map(result);

                item.StartTrackingChanges();
                return item;
            }
        }



        public IEnumerable<BiometricUser> SearchItem(string searchItem, SearchStyleEnum searchStyle)
        {
            const string query = @"SELECT b.Id, b.BiometricId
                                , p.Id PersonId, [Lastname], [Firstname], [Middlename], [MiddleInitial], [NameExtension], [MaidenMiddlename], [Gender]
                                from person p inner join Biometric_User b on p.Id = b.PersonId 
                                where Replace(DBO.FULLNAME(LASTNAME, FIRSTNAME, MIDDLENAME, MiddleInitial, 0, NAMEEXTENSION),' ','') like @Criteria";

            var results = Search.SearchData<dynamic>(searchItem, query, searchStyle);

            var itemCollection = new List<BiometricUser>();

            foreach (var result in results)
            {
                var item = new BiometricUser();
                item.Map(result);


                item.PersonClass.DataMapper.Map(result);
                item.PersonClass.Id = result.PersonId;


                item.StartTrackingChanges();

                itemCollection.Add(item);
            }

            return itemCollection;
        }



        //public int GetIdOf(int biometricId)
        //{
        //    const string query = "select Id from Biometric_User where biometricId = @BiometricId";
        //    using (var db = Connection.CreateConnection())
        //    {
        //        db.Open();
        //        var result = db.Query<int>(query, new { BiometricId = biometricId }).FirstOrDefault();
        //        return result;
        //    }

        //}
    }
}
