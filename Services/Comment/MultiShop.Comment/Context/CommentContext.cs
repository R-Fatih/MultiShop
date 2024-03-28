﻿using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1443;initial catalog=MultiShopCommentDb;User=sa;Password=12345aA-;TrustServerCertificate=True;");

        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
