using App.Model;
using Microsoft.AspNetCore.Identity;

namespace App.Interface;

public interface IAccountRepository
{
  public Task<IdentityResult> SignUp(SignUpModel signUpModel);
  public Task<string> SignIn(SignInModel signInModel);
}