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
        Repository<Note> noteRepo = new Repository<Note>();

        public BLResult<Comment> AddComment(string text, int noteid, BlogUser user)
        {
            BLResult<Comment> result = new BLResult<Comment>();

            Note not = noteRepo.Get(x => x.Id == noteid);
            Note note = not;

            int check = commentRepo.Insert(new Comment{
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = AppHelper.Common.GetUsername(),
                User = user,
                Text = text,
                Note = note 
            });

            if (check > 0)
            {

                result.Entity = commentRepo.Get(x => x.Text == text);
               
            }

            return result;
        } 

        public List<Comment> GetCommentList(Note note)
        {

            return commentRepo.FindList(x => x.Note == note);

        }

        public Comment Update(Comment data)
        {     
            Comment comment = commentRepo.Get(x => x.Id == data.Id);
            BLResult<Comment> result = new BLResult<Comment>();

            if (comment != null && data.Id != comment.Id)
            {
                result.Errors.Add("yorum güncellenmesinde Comment Manager'da hata");
                return null;
            }

            comment.Text = data.Text;

            int check = commentRepo.Insert(comment);

            if (check > 0)
            {
                return comment;
            }
            else
            {
                return null;
            }

        }

        public Comment Delete(Comment data)
        {
            Comment comment = commentRepo.Get(x => x.Id == data.Id);
            BLResult<Comment> result = new BLResult<Comment>();

            if (comment != null && data.Id != comment.Id)
            {
                result.Errors.Add("yorum silme işleminde Comment Manager'da hata");
                return null;
            }

            int check = commentRepo.Remove(comment);

            if (check > 0)
            {
                return comment;
            }
            else
            {
                return null;
            }

        }

        public Comment Find(int id)
        {

            Comment comment = commentRepo.Get(x => x.Id == id);

            return comment;

        }

        


    }
}
