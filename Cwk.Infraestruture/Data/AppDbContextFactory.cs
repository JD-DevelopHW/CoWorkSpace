using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Infraestruture.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CWKDB;Trusted_Connection=true;MultipleActiveResultSets=true");
            return new AppDbContext(optionBuilder.Options);
        }
    }
}
