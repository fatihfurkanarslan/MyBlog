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
        [Required, StringLength(200), Column(TypeName = "varchar")]
        public string Title { get; set; }

        [Required, StringLength(400), Column(TypeName = "varchar")]
        public string Description { get; set; }

        //public int NoteId { get; set; }

        //[ForeignKey("NoteId")]
        public virtual List<Note> Notes { get; set; }

        //public Category()
        //{
        //    Notes = new List<Note>();
        //}
    }
}
