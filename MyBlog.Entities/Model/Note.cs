    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities
{
    [Table("Notes")]
    public class Note : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsDraft { get; set; }

        public int likeCount { get; set; }

        public int UserId { get; set; }

        public int CommentId { get; set; }

        public int LikeId { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("UserId")]
        public virtual BlogUser User { get; set; }

        [ForeignKey("CommentId")]
        public virtual List<Comment> Comment { get; set; }

        [ForeignKey("LikeId")]
        public virtual List<Liked> Like { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
