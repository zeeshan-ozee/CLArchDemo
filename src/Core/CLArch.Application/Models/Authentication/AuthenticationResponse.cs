namespace CLArch.Application.Models.Authentication
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse()
        {

        }

        public AuthenticationResponse(Guid id, string firstName, string lastName, string email, string token)
        {
            this.Id = id;
            this.LastName = lastName;
            this.Token = token;
            FirstName = firstName;
            Email = email;

        }


        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}