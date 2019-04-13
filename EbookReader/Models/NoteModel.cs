using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EbookReader.Models
{
    public class NoteModel
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        public BookModel Book { get; set; }

        public string Location { get; set; }
        // the content in the book
        public string Content { get; set; }
        // the note created from the user
        public string Note { get; set; }

        public string CreateByUserId { get; set; }
        public IdentityUser CreateByUser { get; set; }
    }
}
