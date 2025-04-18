using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeThiThuyNgan_2122110016.Data;
using LeThiThuyNgan_2122110016.Model;
using LeThiThuyNgan_2122110016.Auth;


namespace LeThiThuyNgan_2122110016.Controllers
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Auth").WithTags("Authentication");

            group.MapPost("/login", async ([FromBody] LoginRequest loginUser, AppDbContext db, TokenService tokenService) =>
            {
                // Tìm user trùng username và password (sau này nhớ mã hoá mật khẩu nhé)
                var user = await db.Users.FirstOrDefaultAsync(u =>
                    u.Username == loginUser.Username && u.Password == loginUser.Password);

                if (user == null)
                {
                    return Results.Unauthorized();
                }

                var token = tokenService.GenerateToken(user);

                return Results.Ok(new
                {
                    token,
                    user = new
                    {
                        user.Id,
                        user.Username,
                        user.FullName,
                        user.Email
                    }
                });
            });
        }
    }
}
