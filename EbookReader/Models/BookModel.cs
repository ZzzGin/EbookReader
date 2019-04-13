using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EbookReader.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public string BookCoverImagePath { get; set; }
        public string Path { get; set; }
        public DateTime UploadedDateTime { get; set; }

        public string UploadedByUserId { get; set; }
        public IdentityUser UploadedByUser { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<NoteModel> Notes { get; set; }
        public ICollection<JoinBookShelfBook> JoinBookShelfBooks { get; set; }
    }
}
