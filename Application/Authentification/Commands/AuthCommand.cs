using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using TaskList.Domain.DTO.Responses.Authentification;
using TaskList.Domain.Entities.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Linq;
using System.Xml.Linq;

namespace TaskList.Application.Authentification.Commands
{
    public class AuthCommand : IRequest<AuthResponseDTO>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class AuthCommandHandler : IRequestHandler<AuthCommand, AuthResponseDTO>
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _expiryMinutes;
        private readonly ApplicationContext _applicationContext;
        private CancellationToken cancellationToken;
        private (ClaimsIdentity? userId, ClaimsIdentity? userName, IEnumerable<ClaimsIdentity?> roles, ClaimsIdentity? login) userDetails;

        public AuthCommandHandler(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<AuthResponseDTO> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationContext.Users.FirstAsync(u => u.Login == request.Login && u.Password == request.Password, cancellationToken);

            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var (userId, userName, roles, login) = userDetails;

                var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userId.ToString()),
                new Claim(ClaimTypes.Name, login.ToString()),
                new Claim("UserId", userId.ToString())
            };
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.ToString())));


                var token = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(_expiryMinutes)),
                    signingCredentials: signingCredentials
               );

                var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
                return new AuthResponseDTO()
            {
                    UserId = userId.ToString(),
                    Login = userName.ToString(),
                    Token = token.ToString(),
            };
                
            }
            return null;
        }
    }
}