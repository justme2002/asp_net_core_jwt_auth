using Microsoft.AspNetCore.Mvc;
using App.Service;
using App.Interface;
using App.Model;
using Microsoft.AspNetCore.Identity;

[ApiController]
[Route("[controller]")]
public class AccountController
{

  public IAccountRepository AccountService;

  public AccountController(IAccountRepository AccountService) 
  { 
    this.AccountService = AccountService;
  }

  [HttpPost("sign_up")]
  public async Task<ActionResult<ResponseModel>> signUp([FromBody] SignUpModel signUpModel)
  {
    try
    {
      IdentityResult result = await AccountService.SignUp(signUpModel);
      System.Console.WriteLine(result);
      return new ResponseModel
      {
        Success = true,
        Message = "Create account successfully"
      };
    }
    catch (System.Exception e)
    {
      System.Console.WriteLine(e);
      throw e;
    }
  }

  [HttpPost("sign_in")]
  public async Task<ActionResult<ResponseModel>> signIn([FromBody] SignInModel signInModel)
  {
    try
    {
      String token = await AccountService.SignIn(signInModel: signInModel);
      return new ResponseModel
      {
        Success = true,
        Message = "welcome back",
        Token = token
      };
    }
    catch (System.Exception e)
    {
      System.Console.WriteLine(e);
      return new ResponseModel
      {
        Success = false,
        Message = "Invalid Credential"
      };     
    }
  }
}