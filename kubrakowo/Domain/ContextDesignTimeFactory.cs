using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubrakowo.WebApp.Domain
{
    internal class ContextDesignTimeFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Server=127.0.0.1,7433;Database=kubrakowo;User Id=sa; Password=Password;MultipleActiveResultSets=true");

            return new Context(optionsBuilder.Options);
        }
    }
}
