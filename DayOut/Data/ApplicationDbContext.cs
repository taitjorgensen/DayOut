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
        DbSet<Customer> Customers { get; set; }
        DbSet<State> States { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public ApplicationDbContext()
    : base()
        {

        }
    }
}
