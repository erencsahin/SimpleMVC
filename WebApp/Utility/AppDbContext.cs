﻿using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Utility
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Genre> Genres { get; set; }

    }
}