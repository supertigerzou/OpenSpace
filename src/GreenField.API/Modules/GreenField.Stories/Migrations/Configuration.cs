using GreenField.Books.Data;
using GreenField.Books.Data.DomainModels;
using GreenField.Framework.Data.DomainModels;
using GreenField.Framework.Helpers;
using System.Data.Entity.Migrations;
using System.IO;

namespace GreenField.Books.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<StoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  Use the DbSet<T>.AddOrUpdate() helper extension method to avoid creating duplicate seed data.
            var loginUserSummer = new ApplicationUser
                {
                    UserName = "summer.xia",
                    PasswordHash = "ADWj64qPNVxOr988AtL7WKaHKkOYSP9LFWUQniZIRxnXFaNJHELTF4kp+FtTnrYe6Q=="
                };
            var loginUserElsa = new ApplicationUser
                {
                    UserName = "elsa.xia",
                    PasswordHash = "ADWj64qPNVxOr988AtL7WKaHKkOYSP9LFWUQniZIRxnXFaNJHELTF4kp+FtTnrYe6Q=="
                };

            context.Users.AddOrUpdate(
                p => p.UserName,
                loginUserSummer,
                loginUserElsa
                );
            context.SaveChanges();

            var tellerSummer = new Teller
            {
                FirstName = "Summer",
                LastName = "Xia",
                LoginUser = loginUserSummer
            };
            var tellerElsa = new Teller
                {
                    FirstName = "Elsa",
                    LastName = "Xia",
                    LoginUser = loginUserElsa
                };

            context.Tellers.AddOrUpdate(
                p => p.Id,
                tellerSummer,
                tellerElsa
                );
            context.SaveChanges();


            #region init author pictures
            const string sampleImagePathBase = "~/Migrations/Images/";
            var pictureSummer1 = new EntityPicture
            {
                LargePhotoFileName = "SummerXia_1_large.jpg",
                LargePhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "SummerXia_1_large.jpg")),
                ThumbnailPhotoFileName = "SummerXia_1_small.jpg",
                ThumbNailPhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "SummerXia_1_small.jpg"))
            };
            var pictureSummer2 = new EntityPicture
            {
                LargePhotoFileName = "SummerXia_2_large.jpg",
                LargePhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "SummerXia_2_large.jpg")),
                ThumbnailPhotoFileName = "SummerXia_2_small.jpg",
                ThumbNailPhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "SummerXia_2_small.jpg"))
            };
            #endregion

            context.EntityPictures.AddOrUpdate(
                bp => bp.Id,
                pictureSummer1,
                pictureSummer2
                );
            
        }
    }
}
