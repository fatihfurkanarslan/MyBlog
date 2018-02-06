using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities
{

    // bir user birden fazla like atabilir ve bir note 'un birden fazla like'ı olabilir. bu yüzden ara tablo yapıyoruz. 
    [Table("Likes")]
    public class Liked : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public int UserId { get; set; }

        //public int NoteId { get; set; }

        //[ForeignKey("UserId")]
        public BlogUser User { get; set; }

       // [ForeignKey("NoteId")]
        public Note Note { get; set; }



    }
}
