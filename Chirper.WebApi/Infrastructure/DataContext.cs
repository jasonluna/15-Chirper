using Chirper.WebApi.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chirper.WebApi.Infrastructure
{
    public class DataContext : IdentityDbContext<ChirperUser>
    {

    public DataContext() : base("Chirper")
            {
            }

            public IDbSet<Chirp> Chirps { get; set; }
            public IDbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //configure 1:many relationship - chirp to comment
            modelBuilder.Entity<Chirp>()
                .HasMany(c => c.Comments)
                .WithRequired(c => c.Chirp)
                .HasForeignKey(c => c.ChirpId);

            //configure 1:many user to chirp
            modelBuilder.Entity<ChirperUser>()
                .HasMany(u => u.Chirps)
                .WithRequired(c => c.User)
                .HasForeignKey(c => c.UserId);

            //configure 1:many user to comment
            modelBuilder.Entity<ChirperUser>()
                 .HasMany(u => u.Comments)
                 .WithRequired(c => c.User)
                 .HasForeignKey(c => c.UserId)
                 .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

       // public System.Data.Entity.DbSet<Chirper.WebApi.Models.ChirperUser> ChirperUsers { get; set; }
    }
}