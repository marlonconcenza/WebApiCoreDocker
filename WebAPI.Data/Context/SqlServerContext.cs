using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Mapping;
using WebAPI.Domain.Entities;

namespace WebAPI.Data.Context
{
	public class SqlServerContext : DbContext
	{
		public string _connString { get; set; }
		public DbSet<User> User { get; set; }

		public SqlServerContext()
		{
			this._connString = Environment.GetEnvironmentVariable("CONNSTRING_SQLSERVER");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseSqlServer(this._connString);
				//optionsBuilder.UseSqlServer(this.settings.Value.DataBaseConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>(new UserMap().Configure);
		}
	}
}
