﻿using Microsoft.EntityFrameworkCore;

namespace SignalRApiForSql.DAL
{
    public class Context : DbContext
    {
        protected readonly IConfiguration Configuration;

        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }


        //public Context(DbContextOptions<Context> options) : base(options)
        //{

        //}

        public DbSet<Visitor>? Visitors { get; set; }
    }
}
