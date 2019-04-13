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
        public DbSet<Book> BookDbSet { get; set; }
        public DbSet<BookShelf> BookShelfDbSet { get; set; }
        public DbSet<Comment> CommentDbSet { get; set; }
        public DbSet<Note> NoteDbSet { get; set; }
        public DbSet<JoinBookShelfBook> JoinBookShelfBookDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JoinBookShelfBook>()
                .HasKey(t => new {t.BookId, t.BookShelfId});
            base.OnModelCreating(modelBuilder);

        }
    }
}
