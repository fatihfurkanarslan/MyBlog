using MyBlog.Business;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MyBlog_WepApp
{
    public class CacheHelper 
    {

        public static List<Category> GetFromCategoriesCache()
        {
            
            CategoryManager catManager = new CategoryManager();

            var result = WebCache.Get("cache-categories");

            if (result == null)
            {
                result = catManager.CategoryList();

                WebCache.Set("cache-categories", result, 20, true);
            }

            return result;
        }
   

        public static List<Note> GetFromNotesCache()
        {
            var result = WebCache.Get("cache-notes");

            if (result == null)
            {

                NoteManager noteManager = new NoteManager();
                result = noteManager.GetAllNotesList();

                WebCache.Set("cache-notes", result, 20, true);
            }

            return result;
        }

        public static List<Comment> GetFromCommentsCache(Note note)
        {
            var result = WebCache.Get("cache-comments");
            CommentManager commentManager = new CommentManager();

            if (result == null)
            {
                result = commentManager.GetCommentList(note);

                WebCache.Set("cache-comment", result, 20, true);


            }

            return result;
        }

        //here will be added yorum cache mechanizm

        public static void Remove(string key)
        {

            WebCache.Remove(key);

        }

    }
}