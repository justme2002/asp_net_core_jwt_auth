using App.Model;
using App.Interface;
using Microsoft.AspNetCore.Identity;
using App.Service;

namespace App.Service;

public class AuthenticationService : IAccountRepository
{
  public SignInManager<ApplicationUser>? SignInManager;
  public UserManager<ApplicationUser>? UserManager;
  public IConfiguration? Configuration;

  public AuthenticationService(UserManager<ApplicationUser> UserManager, SignInManager<ApplicationUser> SignInManager, IConfiguration Configuation) {
    this.UserManager = UserManager;
    this.Configuration = Configuation;
    this.SignInManager = SignInManager; 
  }

  public async Task<string> SignIn(SignInModel signInModel)
  {
    SignInResult result = await SignInManager!.PasswordSignInAsync(
      signInModel.Email!,
      signInModel.Password!,
      false,
      false
    );

    String token = new TokenService(Configuration!).generateToken(signInModel);
    return token;
  }

  public async Task<IdentityResult> SignUp(SignUpModel signUpModel)
  {
    ApplicationUser applicationUser = new ApplicationUser {
      FirstName = signUpModel.FirstName,
      LastName = signUpModel.LastName,
      UserName = signUpModel.UserName,
      Email = signUpModel.Gmail
    };

    IdentityResult result = await UserManager!.CreateAsync(applicationUser, password: signUpModel.Password!);
    return result;
  }
}