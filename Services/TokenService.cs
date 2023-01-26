using App.Interface;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using App.Model;

namespace App.Service;

public class TokenService : ITokenRepository
{
  public IConfiguration Configuration;
  public TokenService(IConfiguration Configuration)
  {
    this.Configuration = Configuration;
  }

  public string generateToken(SignInModel signInModel)
  {
    SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
      Configuration["JWT:Key"]!
    ));
    SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);
    List<Claim> claims = new List<Claim> {
      new Claim(ClaimTypes.Email, signInModel.Email!),
    };

    JwtSecurityToken token = new JwtSecurityToken(
      Configuration["JWT:Issuer"],
      Configuration["JWT:Audience"],
      claims,
      expires: DateTime.Now.AddMinutes(15),
      signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
