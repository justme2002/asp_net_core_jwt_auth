using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Model;

public class Context : IdentityDbContext<ApplicationUser>
{
  public Context(DbContextOptions<Context> options) : base(options)
  {

  }


}