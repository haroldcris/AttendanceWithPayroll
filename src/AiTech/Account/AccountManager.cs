using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using AiTech.CrudPattern;
using Dapper;
using AiTech.Database;
using System.Data;

namespace AiTech.Accounts
{
    public class AccountManager
    {
        /// <summary>
        /// Currently Logged Username to be Written on CreatedBy/ModifiedBy
        /// </summary>
        public string CurrentUsername { get; set; }

        public IEnumerable<AccountUser> GetUsers()
        {
            try
            {
                using (var db = Connection.CreateConnection())
                {
                    db.Open();
                    var result = db.Query<AccountUser>("Select * from AccountUsers");
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public AccountManager( string currentUser)
        {
            CurrentUsername = currentUser;
        }


        public void Save(AccountUser user)
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var trn = db.BeginTransaction();

                try
                {
                    switch (user.RowStatus)
                    {
                        case RecordStatus.DeletedRecord:
                            DatabaseAction.ExecuteDeleteQuery<AccountUser>(CurrentUsername, user, db);
                            break;

                        case RecordStatus.ModifiedRecord:
                            DatabaseAction.ExecuteUpdateQuery<AccountUser>(CurrentUsername, user.Username, user, db);
                            break;

                        case RecordStatus.NewRecord:
                            //DatabaseAction.ExecuteInsertQuery<AccountUser>(CurrentUsername, user.Username, user, db);
                            InsertQuery(user, db, trn);
                            Account_AfterInsert(user, db, trn);
                            break;
                    }

                    trn.Commit();
                } catch
                {
                    trn.Rollback();
                }
            }
        }

        private static void Account_AfterInsert(AccountUser item, System.Data.SqlClient.SqlConnection db, System.Data.SqlClient.SqlTransaction trn)
        {
            //throw new NotImplementedException();
            Console.WriteLine("OK Insert");
        }


        private void InsertQuery(AccountUser item, SqlConnection db, SqlTransaction trn)
        {
            try
            {
                using (var cmd = new SqlCommand(@"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
						  INSERT INTO [AccountUsers] ([Username],[Password],[CreatedBy],[ModifiedBy]) 
							 OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
						  VALUES (@Username,@Password,@CreatedBy,@ModifiedBy)
						  SELECT * from @output", db))
                {

                    cmd.Parameters.AddRange(new[]
                    {
                        new SqlParameter( "@Username", SqlDbType.NVarChar, 40) ,
                        new SqlParameter( "@Password", SqlDbType.NVarChar, 400) ,
                        new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 40) ,
                        new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 40)
                    });


                    cmd.Parameters["@Username"].Value = item.Username;
                    cmd.Parameters["@Password"].Value = item.Password;
                    cmd.Parameters["@CreatedBy"].Value = CurrentUsername;
                    cmd.Parameters["@ModifiedBy"].Value = CurrentUsername;

                    var reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                    if (!reader.Read()) throw new Exception("Error Inserting New Item");

                    item.Id = reader.GetInt32(reader.GetOrdinal("Id"));

                    item.Created = reader.GetDateTime(reader.GetOrdinal("Created"));
                    item.CreatedBy = reader["CreatedBy"].ToString();
                    item.Modified = reader.GetDateTime(reader.GetOrdinal("Modified"));
                    item.ModifiedBy = reader["ModifiedBy"].ToString();
                }
            }
            catch
            {
                throw;
            }
        }


    }
}
