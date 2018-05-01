using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<MyBlogDbContext>
    {
        protected override void Seed(MyBlogDbContext context)
        {
            BlogUser admin1 = new BlogUser
            {
                Name = "fatih",
                Surname = "arslan",
                Username = "fatiharslan",
                Email = "fatih@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                UserImageFileName = "StandartUser.png",
                Password = "123",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddHours(1),
                ModifiedUsername = "fatiharslan"
            };

            BlogUser normaluser1 = new BlogUser
            {
                Name = "ali",
                Surname = "veli",
                Username = "aliveli",
                Email = "aliveli@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                UserImageFileName = "StandartUser.png",
                Password = "123",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddHours(1),
                ModifiedUsername = "aliveli"
            };

            context.BlogUsers.Add(normaluser1);

            for (int i = 0; i < 10; i++)
            {
                BlogUser normaluser = new BlogUser
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Username = FakeData.NameData.GetFullName(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    UserImageFileName = "StandartUser.png",
                    Password = "123",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now.AddHours(1),
                    ModifiedUsername = $"normaluser{i}"
                };

                context.BlogUsers.Add(normaluser);
            }

            context.BlogUsers.Add(admin1);
            context.BlogUsers.Add(normaluser1);

            context.SaveChanges();

            //kategori ekle
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category
                {
                    Title = FakeData.PlaceData.GetCountry(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now.AddHours(-1),
                    ModifiedUsername = $"cat{i}"
                };

                context.Categories.Add(cat);

                //not ekleme
                for (int k = 0; k <FakeData.NumberData.GetNumber(5,9); k++)
                {
                    Note note = new Note
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 20)),
                        Content = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(5, 20)),
                        IsDraft = false,
                        likeCount = FakeData.NumberData.GetNumber(1, 10),
                        User = (k%2 ==0) ?admin1 : normaluser1,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = DateTime.Now,
                        ModifiedUsername = $"note{i}"
                    };

                    context.Notes.Add(note);

                    //yorum ekleme
                    for (int l = 0; l < 5; l++)
                    {
                        Comment comment = new Comment
                        {
                            Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(3,5)),
                            User = (k % 2 == 0) ? admin1 : normaluser1,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = DateTime.Now,
                            ModifiedUsername = $"comment{i}"
                        };

                        context.Comments.Add(comment);
                    }

                    List<BlogUser> users = context.BlogUsers.ToList();

                    for (int m = 0; m < note.likeCount; m++)
                    {
                        Liked like = new Liked
                        {
                            User = users[i]
                        };

                        context.Likes.Add(like);
                    }
                }

                context.SaveChanges();

            }


        }

    }
}
