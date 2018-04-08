using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.ResultsValidation
{
    public class BLResult<T> where T : class
    {
        public List<string> Errors { get; set; }

        public T Entity { get; set; }


        public BLResult()
        {
            Errors = new List<string>();
        }
    }
}
