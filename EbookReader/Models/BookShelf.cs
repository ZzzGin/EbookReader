using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EbookReader.Models
{
    public class BookShelf
    {
        public Guid Id { get; set; }
        public string BookShelfName { get; set; }
        public string Description { get; set; }

        public ICollection<JoinBookShelfBook> JoinBookShelfBooks { get; set; }

        public string CreateByUserId { get; set; }
        public IdentityUser CreateByUser { get; set; }
    }
}
