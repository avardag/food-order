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
    private readonly ILogger<TokenService> _logger;

    public TokenService(ILogger<TokenService> logger)
    {
        _logger = logger;
    }

    public string CreateToken(AppUser user)
    {
        var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);
        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            expiration
        );
        var tokenHandler = new JwtSecurityTokenHandler();
        
        _logger.LogInformation("JWT Token created");
        
        return tokenHandler.WriteToken(token);
    }

    private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
        DateTime expiration) =>
        new(
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidIssuer"],
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidAudience"],
            claims,
            expires: expiration,
            signingCredentials: credentials
        );

    private List<Claim> CreateClaims(AppUser user)
    {
        var jwtSub = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["JwtRegisteredClaimNamesSub"];
        
        try
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwtSub),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            
            return claims;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private SigningCredentials CreateSigningCredentials()
    {
        var symmetricSecurityKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["SymmetricSecurityKey"];
        
        return new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(symmetricSecurityKey)
            ),
            SecurityAlgorithms.HmacSha256
        );
    }
}

// public class TokenService
// {
//     private const int ExpirationMinutes = 120;
//     private readonly JwtSettings? _settings;
//     private readonly byte[] _key;
//
//     public TokenService(IOptions<JwtSettings> jwtSettings)
//     {
//         _settings = jwtSettings.Value;
//         ArgumentNullException.ThrowIfNull(_settings);
//         ArgumentNullException.ThrowIfNull(_settings.SigninKey);
//         ArgumentNullException.ThrowIfNull(_settings.Audiences);
//         ArgumentNullException.ThrowIfNull(_settings.Audiences[0]);
//         ArgumentNullException.ThrowIfNull(_settings.Issuer);
//         _key = Encoding.ASCII.GetBytes(_settings.SigninKey!);
//     }
//     
//     // private static JwtSecurityTokenHandler TokenHandler { get; } = new();
//     private static JwtSecurityTokenHandler TokenHandler => new();//this help to generate token
//
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
//     
//     private SecurityTokenDescriptor GetTokenDescriptor(ClaimsIdentity identity)//describes our token
//     {
//         return new SecurityTokenDescriptor
//         {
//             Subject = identity,
//             Issuer = _settings!.Issuer,
//             Audience = _settings.Audiences[0],
//             //used to sign our token and to validate the token
//             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature),
//             Expires = DateTime.UtcNow.AddMinutes(ExpirationMinutes)
//         };
//     }
// }