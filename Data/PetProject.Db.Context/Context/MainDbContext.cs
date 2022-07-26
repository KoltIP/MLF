﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetProject.Db.Entities;
using PetProject.Db.Entities.User;

namespace PetProject.Db.Context.Context
{
    public class MainDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Color> Colors { get; set; }
        public DbSet<PetType> PetTypies { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(x => x.NickName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.NickName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(x => x.Surname).HasMaxLength(50);
            modelBuilder.Entity<User>().HasIndex(x => x.NickName).IsUnique();
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("user_roles");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");            

            //Advertisment
            modelBuilder.Entity<Advertisement>().ToTable("advertisment");
            modelBuilder.Entity<Advertisement>().Property(x => x.Price).IsRequired();

            //PetType
            modelBuilder.Entity<PetType>().ToTable("typies");
            modelBuilder.Entity<PetType>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<PetType>().Property(x => x.Description).HasMaxLength(500);

            //Color
            modelBuilder.Entity<Color>().ToTable("colors");
            modelBuilder.Entity<Color>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Color>().Property(x => x.Description).HasMaxLength(500);

            //Breed
            modelBuilder.Entity<Breed>().ToTable("breeds");
            modelBuilder.Entity<Breed>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Breed>().Property(x => x.Description).HasMaxLength(500);

            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(x => x.Content).IsRequired();

            ////Advertisement - User
            modelBuilder.Entity<Advertisement>().HasOne(x => x.User).WithMany(x => x.Advertisements).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            //Pet - Color
            modelBuilder.Entity<Advertisement>().HasOne(x => x.Color).WithMany(x => x.Advertisements).HasForeignKey(x => x.PetColorId).OnDelete(DeleteBehavior.Restrict);
            //Pet - PetType
            modelBuilder.Entity<Advertisement>().HasOne(x => x.Type).WithMany(x => x.Advertisements).HasForeignKey(x => x.PetTypeId).OnDelete(DeleteBehavior.Restrict);
            //PetType - Breed
            modelBuilder.Entity<Advertisement>().HasOne(x => x.Breed).WithMany(x => x.Advertisements).HasForeignKey(x => x.PetBreedId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>().HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Comment>().HasOne(x => x.Advertisement).WithMany(x => x.Comments).HasForeignKey(x => x.AdvertisementId).OnDelete(DeleteBehavior.Restrict);
            //???
            modelBuilder.Entity<Subscription>().HasOne(x => x.User).WithMany(x => x.Subscriptions).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Subscription>().HasOne(x => x.Advertisement).WithMany(x => x.Subscriptions).HasForeignKey(x => x.AdvertisementId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
