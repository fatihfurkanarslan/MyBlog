using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.UIViewModel
{
    public class NoteViewModel
    {
      
        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }
    }
}
