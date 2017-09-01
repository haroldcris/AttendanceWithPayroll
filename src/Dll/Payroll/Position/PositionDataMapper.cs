using AiTech.LiteOrm;

namespace Dll.Payroll
{
    public class PositionDataMapper : EntityMapper<Position>
    {
        public PositionDataMapper(Position entityOwner) : base(entityOwner)
        {
        }

        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) ItemData.Id = recordSource.Id;
            if (recordSource.Code != null) ItemData.Code = recordSource.Code;
            if (recordSource.Description != null) ItemData.Description = recordSource.Description;

        }


    }
}
