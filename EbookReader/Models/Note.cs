using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EbookReader.Models
{
    public class Note
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public string Location { get; set; }
        // the content in the book
        public string BookContent { get; set; }
        // the note created from the user
        public string NoteContent { get; set; }

        public string CreateByUserId { get; set; }
        public IdentityUser CreateByUser { get; set; }
    }
}
