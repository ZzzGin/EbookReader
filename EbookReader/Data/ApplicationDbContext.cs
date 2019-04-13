using System;
using System.Collections.Generic;
using System.Text;
using EbookReader.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EbookReader.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BookModel> BookDbSet { get; set; }
        public DbSet<BookShelfModel> BookShelfDbSet { get; set; }
        public DbSet<CommentModel> CommentDbSet { get; set; }
        public DbSet<NoteModel> NoteDbSet { get; set; }
        public DbSet<JoinBookShelfBook> JoinBookShelfBookDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JoinBookShelfBook>()
                .HasKey(t => new {t.BookId, t.BookShelfId});
            base.OnModelCreating(modelBuilder);

        }
    }
}
