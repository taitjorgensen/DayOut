using System;
using System.Collections.Generic;
using System.Text;
using DayOut.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DayOut.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
