using MyBlog.Business.ResultsValidation;
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
    public class NoteManager
    {

        Repository<Note> noteRepo = new Repository<Note>();

        public BLResult<Note> AddNote(NoteViewModel note)
        {

            BLResult<Note> result = new BLResult<Note>();

            //TODO 
            //eper not aynı başlıkla açılırsa izin verip vermemeye karar verilsin..
            //aynı başlık kullanılmıcaksa result.error eklensin..

            //TODO 
            //Categoryid geldiği için ekranda öncelikle category seçtirmemiz lazım
            int check = noteRepo.Insert(new Note
            {
                Title = note.Title,
                Content = note.Content,
                CategoryId = note.CategoryId

            });

            if (check>0)
            {
                result.Entity = noteRepo.Get(x => x.Title == note.Title);
            }

            return result;

        }

        public List<Note> GetAllNotesList()
        {

            return noteRepo.GetList();

        }

        public List<Note> GetMostPopularNotes()
        {


            return noteRepo.FindList(x => x.likeCount > 5);
        }

        public Note GetNotebyId(int id)
        {

           return noteRepo.Get(x => x.Id == id);

        }

    }
}
