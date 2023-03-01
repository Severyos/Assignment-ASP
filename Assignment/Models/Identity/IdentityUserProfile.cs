namespace Assignment.Models.Identity
{
    public class IdentityUserProfile
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
    }
}
