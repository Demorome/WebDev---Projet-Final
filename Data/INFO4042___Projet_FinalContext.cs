using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using INFO4042___Projet_Final.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace INFO4042___Projet_Final.Data
{
    public class INFO4042___Projet_FinalContext : IdentityDbContext
    {
        public INFO4042___Projet_FinalContext (DbContextOptions<INFO4042___Projet_FinalContext> options)
            : base(options)
        {
        }

        public DbSet<INFO4042___Projet_Final.Models.Category> Category { get; set; }

        public DbSet<INFO4042___Projet_Final.Models.Contact> Contact { get; set; }
    }
}
