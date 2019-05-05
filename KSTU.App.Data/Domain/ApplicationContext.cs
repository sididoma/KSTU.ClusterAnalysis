using KSTU.App.BLL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.App.Data.Domain
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInterests> UserInterests { get; set; }
    }
}
