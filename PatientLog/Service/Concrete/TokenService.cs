using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PatientLog.Domain.Dtos.TokenDtos;
using PatientLog.Service.Abstract;
using PatientLog.Service.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PatientLog.Service.Concrete
{
    public class TokenService(IOptions<CustomTokenOptions> _options): ITokenService
    {

        public async Task<LoginResponse> CreateTokenAsync(UserDto user)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddMinutes(_options.Value.AccessTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_options.Value.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (issuer: _options.Value.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: await GetClaims(user, _options.Value.Audiences));

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            var loginResponseDto = new LoginResponse
            {
                AccessToken = token,
                Email = user.Email,
                UserType =user.UserType
            };

            return loginResponseDto;
        }

        private async Task<IEnumerable<Claim>> GetClaims(UserDto user, string audiences)
        {
            var listedAudiences = audiences.Split(",");

            var userClaimList = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Name, user.Email ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            userClaimList.AddRange(listedAudiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

     
            string role = string.Empty;
            switch (user.UserType)
            {
                case Domain.Enums.UserTypeEnum.Admin:
                    role = "admin";
                    break;
                case Domain.Enums.UserTypeEnum.Doctor:
                    role = "doctor";
                    break;
                case Domain.Enums.UserTypeEnum.Patient:
                    role = "patient";
                    break;
                default:
                    break;
            }

            userClaimList.Add(new Claim(ClaimTypes.Role, role));

            return userClaimList;
        }
    }
}

