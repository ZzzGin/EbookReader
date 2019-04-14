using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbookReader.Models
{
    public class JoinBookShelfBook
    {
        public int Id { get; set; }

        public Guid BookShelfId { get; set; }
        public BookShelf BookShelf { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
