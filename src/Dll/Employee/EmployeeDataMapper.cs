using AiTech.LiteOrm;
using System;

namespace Dll.Employee
{

    public class EmployeeDataMapper : EntityMapper<Employee>
    {
        public EmployeeDataMapper(Employee entityOwner) : base(entityOwner)
        {
        }


        [Obsolete("Use Employee Class Map function")]
        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) ItemData.Id = recordSource.Id;
            if (recordSource.PersonId != null) ItemData.PersonId = recordSource.PersonId;
            if (recordSource.EmpNum != null) ItemData.EmpNum = recordSource.EmpNum;
            if (recordSource.CivilStatus != null) ItemData.CivilStatus = recordSource.CivilStatus;
            if (recordSource.Height != null) ItemData.Height = recordSource.Height;
            if (recordSource.Weight != null) ItemData.Weight = recordSource.Weight;


            if (recordSource.Created != null) ItemData.Created = recordSource.Created;
            if (recordSource.Modified != null) ItemData.Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) ItemData.CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ItemData.ModifiedBy = recordSource.ModifiedBy;

        }


    }
}
