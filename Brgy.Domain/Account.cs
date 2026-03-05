namespace Brgy.Domain
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public bool IsOfficial { get; set; } 
    }
}