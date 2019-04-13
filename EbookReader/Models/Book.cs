using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EbookReader.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public string BookCoverImagePath { get; set; }
        public string Path { get; set; }
        public DateTime UploadedDateTime { get; set; }

        public string UploadedByUserId { get; set; }
        public IdentityUser UploadedByUser { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<JoinBookShelfBook> JoinBookShelfBooks { get; set; }
    }
}
