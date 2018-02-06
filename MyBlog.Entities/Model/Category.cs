using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        //public int NoteId { get; set; }

        //[ForeignKey("NoteId")]
        public virtual List<Note> Notes { get; set; }
    }
}
