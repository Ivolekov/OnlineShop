namespace OnlineStorePlatform.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineStorePlatform.Data.OnlineStorePlatformContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(OnlineStorePlatform.Data.OnlineStorePlatformContext context)
        {
            if (!context.Roles.Any(role => role.Name == "customer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("customer");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("admin");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("manager");
                manager.Create(role);
            }

            //context.Categories.AddOrUpdate(cat=>cat.Name,
            //    new Category()
            //    {
            //        Name = "Dresses",
            //        Image = "http://themes.iamabdus.com/kidz/1.1/img/category/category-img1.jpg"
            //    },
            //    new Category()
            //    {
            //        Name = "Toys",
            //        Image = "http://themes.iamabdus.com/kidz/1.1/img/category/category-img5.jpg"
            //    },
            //    new Category()
            //    {
            //        Name = "Inner Wear",
            //        Image = "http://themes.iamabdus.com/kidz/1.1/img/category/category-img3.jpg"
            //    },
            //    new Category()
            //    {
            //        Name = "Foot Wear",
            //        Image = "http://themes.iamabdus.com/kidz/1.1/img/category/category-img2.jpg"
            //    });

            int category = context.Categories.Count();
            Random rnd = new Random();
            context.Products.AddOrUpdate(products => products.Name,
                new Product()
                {
                    Name = "VTech Baby Turn and Learn Cube",
                    Description = "Turn and Learn Cube. Features 4 animal buttons and lots of manipulative features including maraca slider, drum button and cymbal slider. Motion sensor triggers fun sounds, melodies and songs. Introduces shapes, animals and their sounds. Includes 10 melodies and 5 sing-along songs. Age from 6 -36 month.",
                    Image = "http://media.very.co.uk/i/very/3YV73_SQ1_0000000099_N-A_SLf1?$266x354_standard$",
                    Price = 29.99m,
                    CategoryId = 1

                },
                new Product()
                {
                    Name = "Twirlywoos Run-along Twirlywoo Toodloo",
                    Description = "Twirlywoos is the much-loved TV series shown on CBeebies. This unique show is based on pure slapstick comedy with a focus on laugh-out-loud child centric humour to engage pre-schoolers, encouraging them to think for themselves, gain confidence in their own perceptions of the world and reinforce their understanding as they grow and develop. The adorable Run-along Fun Sounds Toodloo, Great BigHoo, Chickedy and Chick are sure to provide lots of fun and giggles as they run along, just like in the show! Press their hand and watch as they come to life. Don’t forget to listen out for their signature silly sounds as they move. Little ones will love interacting and playing with them over and over again! Made with beautiful soft-to-touch fabric, these cheeky run-along Twirlywoos will be a firm favourite for all fans of the show! Performs best on smooth surfaces. Approx. size 23cm. Each sold separately.",
                    Image = "http://media.very.co.uk/i/very/73N4D_SQ1_0000000088_NO_COLOR_SLf?$266x354_standard$",
                    Price = 17.90m,
                    CategoryId = rnd.Next(1, category)
                },
                new Product()
                {
                    Name = "Fisher-Price Bright Beats Dance and Move BeatBo",
                    Description = "Activate BeatBo by pressing his tummy or any of the 3 buttons on his feet. With music, songs, phrases, lights and lots of bright colours, he'll stimulate your baby's senses and help to develop their gross and fine motor skills.",
                    Image = "http://media.very.co.uk/i/very/6H4YD_SQ1_0000000088_NO_COLOR_SLf1?$266x354_standard$&$roundel_very$&p1_img=lw-roundel1",
                    Price = 40.00m,
                    CategoryId = rnd.Next(1, category)
                },
                new Product()
                {
                    Name = "Teletubbies Pull & Play Giant Noo Noo",
                    Description = "Perfect for encouraging imaginative play and teaching them about cause and effect, it has a 6- piece shape sorter and 3D Teletubbies character jigsaw to encourage problem solving and coordination. ",
                    Image = "http://media.very.co.uk/i/very/73U96_SQ1_0000000088_NO_COLOR_SLf?$266x354_standard$&$roundel_very$&p1_img=lw-roundel1",
                    Price = 30.00m,
                    CategoryId = rnd.Next(1, category)
                },
                new Product()
                {
                    Name = "WinFun Talking Activity Book",
                    Description = "Together you can identify letters, numbers, the time and shapes as well as learning to recognise different objects and words. You can also play the quiz and take the memory test - this colourful toy is full of educational features to help develop key pre-school skills like reading, telling the time and hand-eye coordination.",
                    Image = "http://media.very.co.uk/i/very/27CBA_SQ1_0000000099_N-A_SLf1?$266x354_standard$",
                    Price = 10.99m,
                    CategoryId = rnd.Next(1, category)
                },
                new Product()
                {
                    Name = "Paw Patrol Paw Patroller",
                    Description = "Kids can drive their Paw Patrol vehicles in and out, with room for 3 inside – or 6 vehicles when open. Authentic Paw Patrol sound effects add to the excitement and there's also a real working lift to take the pup vehicles up to Ryder's Command Centre!",
                    Image = "http://media.very.co.uk/i/very/6K7D7_SQ1_0000000088_NO_COLOR_SLf1?$266x354_standard$",
                    Price = 79.99m,
                    CategoryId = rnd.Next(1, category)
                },
                new Product()
                {
                    Name = "In The Night Garden Large Talking Soft Toy - Upsy Daisy",
                    Description = "This large soft toy of Upsy Daisy - star of TV's In The Night garden - will keep your child company with a range of familiar phrases and sounds.",
                    Image = "http://media.very.co.uk/i/very/3KFHY_SQ1_0000000099_N-A_SLf1?$266x354_standard$",
                    Price = 11.50m,
                    CategoryId = rnd.Next(1, category)

                });
        }
    }
}
