using HRBCloud.CloudUtil.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRBCloud.CloudUtil.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Users> tbleUsers { get; set; }
    }
}

