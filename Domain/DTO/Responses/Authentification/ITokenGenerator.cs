namespace TaskList.Domain.DTO.Responses.Authentification
{
    public interface ITokenGenerator
    {
        public string GenerateJWTToken((string userId, string userName, IList<string> roles) userDetails);
    }
}
