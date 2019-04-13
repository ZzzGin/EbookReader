using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EbookReader.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public byte RecommendationStars { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreateDateTime { get; set; }

        public string CreateByUserId { get; set; }
        public IdentityUser CreateByUser { get; set; }

        public Guid BookId { set; get; }
        public BookModel Book { set; get; }
    }
}
