namespace AiTech.Database
{
    public struct DatabaseCredential
    {
        public string ServerName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public bool IntegratedSecurity { get; set; }

        public string DatabasePath ()
        {
            return $"{ServerName}\\{DatabaseName}";
        }
    }
}
