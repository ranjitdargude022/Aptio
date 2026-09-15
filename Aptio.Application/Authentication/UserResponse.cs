namespace Aptio.Application.Authentication
{
    public class UserResponse
    {
        public long Id { get; set; }

        public long RoleId { get; set; }


        public string? FirstName { get; set; }

        public string? LastName { get; set; }


        public string? Phone { get; set; }


        public string Email { get; set; }

        public string Password { get; set; }

        public string? Address { get; set; }

        public long? CityId { get; set; }
    }
}
