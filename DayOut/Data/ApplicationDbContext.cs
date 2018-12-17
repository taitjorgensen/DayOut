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
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<SelectedCategory> SelectedCategories { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<TestLoop> TestLoops { get; set; }
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
