using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSEntities;
using System.Data.Entity;

namespace BSDAL
{
    public class BSDBInitializer : CreateDatabaseIfNotExists<BSContext>
    {
        protected override void Seed(BSContext context)
        {
            Random rd = new Random();

            context.BSUser.Add(new BSUser()
            {
                Account = "admin",
                Password = Tools.ToMD5Encrypt("admin"),
                Name = FakeData.NameData.GetFirstName(),
                Surname = FakeData.NameData.GetSurname(),
                Mail = FakeData.NetworkData.GetEmail(),
                Role = BSUserRole.Admin
            });

            context.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                context.BSUser.Add(new BSUser()
                {
                    Account = FakeData.TextData.GetAlphabetical(5),
                    Password = Tools.ToMD5Encrypt(FakeData.TextData.GetAlphaNumeric(5)),
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Mail = FakeData.NetworkData.GetEmail(),
                    Role = (BSUserRole)(rd.Next(1,2))
                });
            }
            context.SaveChanges();

            foreach (BSUser usr in context.BSUser.Where(x=> x.Role == BSUserRole.User).ToList())
            {
                for (int i = 0; i < 10; i++)
                {
                    context.BSPost.Add(new BSPost()
                    {
                        Title = FakeData.TextData.GetSentence(),
                        Content = FakeData.TextData.GetSentences(30),
                        Date = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        User = usr
                    });
                } 
            }
            context.SaveChanges();
            
            foreach (BSPost post in context.BSPost.ToList())
            {
                for (int i = 0; i < 10; i++)
                {
                    context.BSComment.Add(new BSComment()
                    {
                        CommenterName = FakeData.NameData.GetFullName(),
                        Content = FakeData.TextData.GetSentences(2),
                        Date = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        Post = post
                    });
                } 
            }
            context.SaveChanges();

        }

    }
}
