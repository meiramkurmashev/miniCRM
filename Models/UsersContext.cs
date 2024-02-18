using Microsoft.Office.Interop.Excel;
using miniCRM.Models;
using System.Collections.Generic;


using Microsoft.EntityFrameworkCore;
 
namespace miniCRM.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
