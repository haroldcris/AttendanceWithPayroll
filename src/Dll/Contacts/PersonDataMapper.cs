using AiTech.LiteOrm;

namespace Dll.Contacts
{
    public class PersonDataMapper : EntityMapper<Person>
    {
        public PersonDataMapper(Person entityOwner) : base(entityOwner)
        {

        }


        //public void Map(Expression<Func<Person, dynamic>> outExpr, object input)
        //{
        //    if (input == null) return;


        //    MemberExpression expr;

        //    var body = outExpr.Body as MemberExpression;
        //    if (body != null)
        //    {
        //        expr = body;
        //    }
        //    else
        //    {
        //        var op = ((UnaryExpression)outExpr.Body).Operand;
        //        expr = ((MemberExpression)op);
        //    }
        //    //outExpr.Compile();
        //    //var expr = (MemberExpression)outExpr.Body;

        //    var prop = (PropertyInfo)expr.Member;
        //    prop.SetValue(ItemData, input, null);

        //}



        public Person Item()
        {
            return ItemData;

        }


        public void Map(dynamic readerItemSource)
        {

            if (readerItemSource.Id != null) ItemData.Id = readerItemSource.Id;
            if (readerItemSource.Lastname != null) ItemData.Name.Lastname = readerItemSource.Lastname;
            if (readerItemSource.Firstname != null) ItemData.Name.Firstname = readerItemSource.Firstname;
            if (readerItemSource.Middlename != null) ItemData.Name.Middlename = readerItemSource.Middlename;
            if (readerItemSource.Mi != null) ItemData.Name.MiddleInitial = readerItemSource.Mi;
            if (readerItemSource.NameExtension != null) ItemData.Name.NameExtension = readerItemSource.NameExtension;
            if (readerItemSource.MaidenMiddlename != null) ItemData.Name.MaidenMiddlename = readerItemSource.MaidenMiddlename;
            if (readerItemSource.Gender != null) ItemData.Gender = readerItemSource.Gender == "Male" ? GenderType.Male : GenderType.Female;
            if (readerItemSource.BirthDate != null) ItemData.BirthDate = readerItemSource.BirthDate;


            ItemData.BirthCountry = readerItemSource.BirthCountry;
            ItemData.BirthProvince = readerItemSource.BirthProvince;
            ItemData.BirthTown = readerItemSource.BirthTown;

            ItemData.CameraCounter = readerItemSource.CameraCounter;

            if (readerItemSource.Created != null) ItemData.Created = readerItemSource.Created;
            if (readerItemSource.Modified != null) ItemData.Modified = readerItemSource.Modified;
            if (readerItemSource.CreatedBy != null) ItemData.CreatedBy = readerItemSource.CreatedBy;
            if (readerItemSource.ModifiedBy != null) ItemData.ModifiedBy = readerItemSource.ModifiedBy;

            //return ItemData;
        }


        public void CopyFrom(Person itemSource)
        {
            ItemData.Id = itemSource.Id;
            ItemData.Name.Lastname = itemSource.Name.Lastname;
            ItemData.Name.Firstname = itemSource.Name.Firstname;
            ItemData.Name.Middlename = itemSource.Name.Middlename;
            ItemData.Name.MiddleInitial = itemSource.Name.MiddleInitial;
            ItemData.Name.NameExtension = itemSource.Name.NameExtension;
            ItemData.Gender = itemSource.Gender;
            ItemData.BirthDate = itemSource.BirthDate;

            ItemData.Created = itemSource.Created;
            ItemData.Modified = itemSource.Modified;
            ItemData.CreatedBy = itemSource.CreatedBy;
            ItemData.ModifiedBy = itemSource.ModifiedBy;
        }
    }
}
