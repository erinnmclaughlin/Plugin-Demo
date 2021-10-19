namespace HomeApp.Domain.Models
{
    public class HomeAppUser
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string About { get; set; }
    }
}
