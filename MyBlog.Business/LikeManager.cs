using MyBlog.DataAccess.EntityFramework;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business
{
    public class LikeManager
    {

        Repository<Liked> likeRepo = new Repository<Liked>();


        public int GetLike(int likeid)
        {

            Liked like = likeRepo.Get(x => x.Id == likeid);

            int value = like.Id;

            return value;
        }

        public List<int> GetLikes(int userId, int[] likeIds)
        {

            List<int> likes = likeRepo.FindList(x => x.User.Id == userId && likeIds.Contains(x.Note.Id)).Select(x => x.Note.Id).ToList();


            return likes;
        }

        public int GetLikeCount(Liked like)
        {
            int count = likeRepo.Update(like);

            return count;
        }




    }
}
