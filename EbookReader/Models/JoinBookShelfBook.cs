using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbookReader.Models
{
    public class JoinBookShelfBook
    {
        public Guid BookShelfId { get; set; }
        public BookShelfModel BookShelf { get; set; }

        public Guid BookId { get; set; }
        public BookModel Book { get; set; }
    }
}
