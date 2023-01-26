using App.Model;
using Microsoft.AspNetCore.Identity;
namespace App.Interface;

public interface ITokenRepository
{
  public string generateToken(SignInModel signInModel);
}