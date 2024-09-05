namespace ASPProjekat.API.DTO
{
    public class AuthorizationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthorizationResponse
    {
        public string Token { get; set; }
    }
}
