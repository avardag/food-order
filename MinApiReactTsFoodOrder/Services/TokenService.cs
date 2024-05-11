using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinApiReactTsFoodOrder.Entities;
using MinApiReactTsFoodOrder.Options;

namespace MinApiReactTsFoodOrder.Services;

public class TokenService
{
    // Specify how long until the token expires
    private const int ExpirationMinutes = 30;
    private readonly JwtSettings? _settings;
    // private readonly SymmetricSecurityKey _key;
    private readonly byte[] _key;

    public TokenService(IOptions<JwtSettings> jwtSettings)
    {
        _settings = jwtSettings.Value;
        ArgumentNullException.ThrowIfNull(_settings);
        ArgumentNullException.ThrowIfNull(_settings.SigningKey);
        ArgumentNullException.ThrowIfNull(_settings.Audiences);
        ArgumentNullException.ThrowIfNull(_settings.Audiences[0]);
        ArgumentNullException.ThrowIfNull(_settings.Issuer);
        _key = Encoding.ASCII.GetBytes(_settings.SigningKey!);
    }

    // private static JwtSecurityTokenHandler TokenHandler { get; } = new();
    private static JwtSecurityTokenHandler TokenHandler => new(); //this help to generate token

    public string CreateToken(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        var tokenDescriptor = GetTokenDescriptor(new ClaimsIdentity(claims));

        var token = TokenHandler.CreateToken(tokenDescriptor);

        return TokenHandler.WriteToken(token);
    }

    private SecurityTokenDescriptor GetTokenDescriptor(ClaimsIdentity identity) //describes our token
    {
        return new SecurityTokenDescriptor
        {
            Subject = identity,
            Issuer = _settings!.Issuer,
            Audience = _settings.Audiences[0],
            //used to sign our token and to validate the token
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature),
            Expires = DateTime.UtcNow.AddMinutes(ExpirationMinutes)
        };
    }
    //     public SecurityToken CreateSecurityToken(ClaimsIdentity identity)
//     {
//         var tokenDescriptor = GetTokenDescriptor(identity);
//         return TokenHandler.CreateToken(tokenDescriptor);
//     }
//     
//     public string WriteToken(SecurityToken token)
//     {
//         return TokenHandler.WriteToken(token);
//     }
}