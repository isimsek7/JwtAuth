using System;
using JwtAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth.Data
{
	public class ApplicationDbContext:IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(DbContextOptions dbContextOptions)
			:base(dbContextOptions)
		{

		}
		public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			List<IdentityRole> roles = new List<IdentityRole>
			{
				new IdentityRole
				{
					Name="User",NormalizedName="USER"

				}
			};
			builder.Entity<IdentityRole>().HasData(roles);
			

        }
    }
}

