using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities
{
    [Table("Comments")]
    public class Comment : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        public int NoteId { get; set; }

        [ForeignKey("NoteId")]
        public virtual Note Note { get; set; }
    }

}
