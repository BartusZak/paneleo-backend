using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using paneleo.Share.Models;

namespace paneleo.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
