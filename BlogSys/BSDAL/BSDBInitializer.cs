using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSEntities;
using System.Data.Entity;
using System.Security.Cryptography;

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
                Password = MD5Encrypt("admin"),
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
                    Password = MD5Encrypt(FakeData.TextData.GetAlphaNumeric(5)),
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Mail = FakeData.NetworkData.GetEmail(),
                    Role = FakeData.EnumData.GetElement<BSUserRole>()
                });
            }
            context.SaveChanges();

            List<BSUser> usrList = context.BSUser.ToList();
            for (int i = 0; i < 10; i++)
            {
                context.BSPost.Add(new BSPost()
                {
                    Title = FakeData.TextData.GetSentence(),
                    Content = FakeData.TextData.GetSentences(30),
                    Date = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    User = usrList[rd.Next(0, usrList.Count - 1)]
                });
            }
            context.SaveChanges();

            List<BSPost> postList = context.BSPost.ToList();

            for (int i = 0; i < 4; i++)
            {
                context.BSComment.Add(new BSComment()
                {
                    CommenterName = FakeData.NameData.GetFullName(),
                    Content = FakeData.TextData.GetSentences(2),
                    Date = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    Post = postList[rd.Next(0, postList.Count - 1)]
                });
            }
            context.SaveChanges();

        }

        public static string MD5Encrypt(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] btr = Encoding.UTF8.GetBytes(text);
            byte[] md5btr = md5.ComputeHash(btr);
            return Convert.ToBase64String(md5btr);
        }
    }
}
