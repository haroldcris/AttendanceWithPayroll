using AiTech.LiteOrm;

namespace Dll.Employee
{

    public class EmployeeDataMapper : EntityMapper<Employee>
    {
        public EmployeeDataMapper(Employee entityOwner) : base(entityOwner)
        {
        }

        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) ItemData.Id = recordSource.Id;
            if (recordSource.PersonId != null) ItemData.PersonId = recordSource.PersonId;
            if (recordSource.EmpNum != null) ItemData.EmpNum = recordSource.EmpNum;
            if (recordSource.CivilStatus != null) ItemData.CivilStatus = recordSource.CivilStatus;
            if (recordSource.Height != null) ItemData.Height = recordSource.Height;
            if (recordSource.Weight != null) ItemData.Weight = recordSource.Weight;

        }


    }
}
