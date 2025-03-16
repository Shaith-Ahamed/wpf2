using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
   
  public class UsersDbContext: DbContext
    {
        public DbSet<User> Users{ get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\shait\OneDrive\Desktop\user_data_base\user_data.db");

        }

    }
}
