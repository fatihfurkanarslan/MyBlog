using MyBlog.DataAccess.EntityFramework;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business
{
    public class NoteManager
    {

        Repository<Note> noteRepo = new Repository<Note>();

        public List<Note> GetAllNotesList()
        {

            return noteRepo.GetList();

        }

        public List<Note> GetMostPopularNotes()
        {


            return noteRepo.FindList(x => x.likeCount > 5);
        }

    }
}
