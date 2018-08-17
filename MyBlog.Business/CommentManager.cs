using MyBlog.Business.ResultsValidation;
using MyBlog.Common;
using MyBlog.DataAccess.EntityFramework;
using MyBlog.Entities;
using MyBlog.Entities.UIViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business
{
    public class CommentManager
    {
        Repository<Comment> commentRepo = new Repository<Comment>();

        public BLResult<Comment> AddComment(CommentViewModel comment)
        {
            BLResult<Comment> result = new BLResult<Comment>();

            int check = commentRepo.Insert(new Comment{
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = AppHelper.Common.GetUsername(),
                Text = comment.Text
            });

            if (check > 0)
            {

                result.Entity = commentRepo.Get(x => x.Text == comment.Text);
               
            }

            return result;
        } 

        public List<Comment> GetCommentList(Note note)
        {

            return commentRepo.FindList(x => x.Note == note);

        }




    }
}
