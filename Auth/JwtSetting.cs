namespace LeThiThuyNgan_2122110016.Auth
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = "THIS_IS_A_SUPER_SECRET_KEY_1234567890_32";
        public string Issuer { get; set; } = "LeThiThuyNgan_2122110016App";
        public string Audience { get; set; } = "LeThiThuyNgan_2122110016Users";
        public int ExpirationMinutes { get; set; } = 60;
    }
}
