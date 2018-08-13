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