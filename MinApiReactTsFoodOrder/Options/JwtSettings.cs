namespace MinApiReactTsFoodOrder.Options;

public class JwtSettings
{
    public string? SigninKey { get; set; }
    public string? Issuer { get; set; }
    public string[]? Audiences { get; set; }
}