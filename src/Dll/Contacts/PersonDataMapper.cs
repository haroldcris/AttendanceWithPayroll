namespace Dll.Contacts
{
    public class PersonDataMapper
    {
        Person ItemData;

        public PersonDataMapper(Person person)
        {
            ItemData = person;
        }

        internal void Map(dynamic readerItemSource)
        {
            ItemData.Id = readerItemSource.Id;
            ItemData.Name.Lastname = readerItemSource.Lastname;
            ItemData.Name.Firstname = readerItemSource.Firstname;
            ItemData.Name.Middlename = readerItemSource.MiddleName;
            ItemData.Name.MiddleInitial = readerItemSource.Mi;
            ItemData.Name.NameExtension = readerItemSource.NameExtension;
            ItemData.Name.SpouseLastname = readerItemSource.SpouseLastname;
            ItemData.Gender = readerItemSource.Gender == "Male" ? GenderType.Male : GenderType.Female;
            ItemData.BirthDate = readerItemSource.BirthDate;


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
