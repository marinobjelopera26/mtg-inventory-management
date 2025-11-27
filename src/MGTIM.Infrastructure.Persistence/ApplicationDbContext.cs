using MGTIM.Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MGTIM.Infrastructure.Persistence;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{

}
