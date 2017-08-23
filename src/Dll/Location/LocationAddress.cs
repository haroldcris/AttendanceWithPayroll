namespace AiTech.Location
{
    public class LocationAddress
    {
        public string Province { get; set; }

        public string Town { get; set; }

        public string Barangay { get; set; }

        public string Street { get; set; }

        public int ZipCode { get; set; }


        public LocationAddress()
        {
            Province = "";
            Town = "";
            Barangay = "";
            Street = "";
            ZipCode = 0;
        }
    }
}
