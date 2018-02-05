using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities
{
    [Table("BlogUsers")]
    public class BlogUser : BaseEntity
    {
        [Required, StringLength(100), Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Required, StringLength(100), Column(TypeName = "varchar")]
        public string Surname { get; set; }
        [Required, StringLength(200), Column(TypeName = "varchar")]
        public string Username { get; set; }
        [Required, StringLength(100), Column(TypeName = "varchar")]
        public string Email { get; set; }
        [Required, StringLength(100), Column(TypeName = "varchar")]
        public string Password { get; set; }

        public bool IsActive { get; set; }
        [Required]
        public Guid ActivateGuid { get; set; }
        [Required]
        public bool IsAdmin { get; set; }

        public int NoteId { get; set; }

        public int CommentId { get; set; }

        public int LikeId { get; set; }

        [ForeignKey("NoteId")]
        public virtual List<Note> Notes { get; set; }

        [ForeignKey("CommentId")]
        public virtual List<Comment> Comments { get; set; }

        [ForeignKey("LikeId")]
        public virtual List<Liked> Likes { get; set; }

    }
}
