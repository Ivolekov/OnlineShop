namespace OnlineStorePlatform.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineStorePlatform.Data.OnlineStorePlatformContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OnlineStorePlatform.Data.OnlineStorePlatformContext context)
        {
           // if (!context.Roles.Any(role => role.Name == "customer"))
           // {
           //     var store = new RoleStore<IdentityRole>(context);
           //     var manager = new RoleManager<IdentityRole>(store);
           //     var role = new IdentityRole("customer");
           //     manager.Create(role);
           // }

           // if (!context.Roles.Any(role => role.Name == "admin"))
           // {
           //     var store = new RoleStore<IdentityRole>(context);
           //     var manager = new RoleManager<IdentityRole>(store);
           //     var role = new IdentityRole("admin");
           //     manager.Create(role);
           // }

           // if (!context.Roles.Any(role => role.Name == "manager"))
           // {
           //     var store = new RoleStore<IdentityRole>(context);
           //     var manager = new RoleManager<IdentityRole>(store);
           //     var role = new IdentityRole("manager");
           //     manager.Create(role);
           // }

           // context.Categories.AddOrUpdate(cat => cat.Name,
           //     new Category()
           //     {
           //         Name = "Toys"
           //     },
           //     new Category()
           //     {
           //         Name = "Baby Clothes"
           //     },
           //     new Category()
           //     {
           //         Name = "Kids Furniture Sets"
           //     },
           //     new Category()
           //     {
           //         Name = "Baby Accessories"
           //     },
           //      new Category()
           //      {
           //          Name = "Desks"
           //      });
           //// context.SaveChanges();

           // context.Products.AddOrUpdate(products => products.Name,
           //     new Product()
           //     {
           //         //toys
           //         Name = "Winfun Music Cube",
           //         Description = "Turn and Learn Cube. Features 4 animal buttons and lots of manipulative features including maraca slider, drum button and cymbal slider. Motion sensor triggers fun sounds, melodies and songs. Introduces shapes, animals and their sounds. Includes 10 melodies and 5 sing-along songs. Age from 6 -36 month.",
           //         Price = 29.99m,
           //         CategoryId = 1

           //     },
           //     new Product()
           //     {
           //         Name = "Eichhorn Wood Car",
           //         Description = "Wood Car is the much-loved TV series shown on CBeebies. This unique show is based on pure slapstick comedy with a focus on laugh-out-loud child centric humour to engage pre-schoolers, encouraging them to think for themselves, gain confidence in their own perceptions of the world and reinforce their understanding as they grow and develop. The adorable Run-along Fun Sounds Toodloo, Great BigHoo, Chickedy and Chick are sure to provide lots of fun and giggles as they run along, just like in the show! Press their hand and watch as they come to life. Don’t forget to listen out for their signature silly sounds as they move. Little ones will love interacting and playing with them over and over again! Made with beautiful soft-to-touch fabric, these cheeky run-along Twirlywoos will be a firm favourite for all fans of the show! Performs best on smooth surfaces. Approx. size 23cm. Each sold separately.",
           //         Price = 17.90m,
           //         CategoryId = 1
           //     },
           //     new Product()
           //     {
           //         Name = "Winfun Music Duck",
           //         Description = "Activate Music Duck by pressing his tummy or any of the 3 buttons on his feet. With music, songs, phrases, lights and lots of bright colours, he'll stimulate your baby's senses and help to develop their gross and fine motor skills.",
           //         Price = 40.00m,
           //         CategoryId = 1
           //     },
           //     new Product()
           //     {
           //         Name = "Fisher Price Elephand",
           //         Description = "Perfect for encouraging imaginative play and teaching them about cause and effect, it has a 6- piece shape sorter and 3D Teletubbies character jigsaw to encourage problem solving and coordination. ",
           //         Price = 30.00m,
           //         CategoryId = 1
           //     },
           //     //clothes
           // new Product()
           // {
           //     Name = "San Bebe",
           //     Description = "Together you can identify letters, numbers, the time and shapes as well as learning to recognise different objects and words. You can also play the quiz and take the memory test - this colourful toy is full of educational features to help develop key pre-school skills like reading, telling the time and hand-eye coordination.",
           //     Price = 10.99m,
           //     CategoryId = 2
           // },
           //     new Product()
           //     {
           //         Name = "Lego Tshirt",
           //         Description = "Kids can drive their Paw Patrol vehicles in and out, with room for 3 inside – or 6 vehicles when open. Authentic Paw Patrol sound effects add to the excitement and there's also a real working lift to take the pup vehicles up to Ryder's Command Centre!",
           //         Price = 79.99m,
           //         CategoryId = 2
           //     },
           //     new Product()
           //     {
           //         Name = "Nike",
           //         Description = "This large soft toy of Upsy Daisy - star of TV's In The Night garden - will keep your child company with a range of familiar phrases and sounds.",
           //         Price = 11.50m,
           //         CategoryId = 2

           //     },
           //     new Product()
           //     {
           //         Name = "Air Jordan",
           //         Description = "Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores.",
           //         Price = 20.50m,
           //         CategoryId = 2

           //     },
           //     //futniture sets
           //     new Product()
           //     {
           //         Name = "Nature",
           //         Description = "Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. Child company with a range of familiar phrases and sounds.",
           //         Price = 150.80m,
           //         CategoryId = 3

           //     },
           //     new Product()
           //     {
           //         Name = "Boy",
           //         Description = "Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. This large soft toy of Upsy Daisy - star of TV's In The Night garden - will keep your child company with a range of familiar phrases and sounds.",
           //         Price = 599.99m,
           //         CategoryId = 3

           //     },
           //     new Product()
           //     {
           //         Name = "Girl",
           //         Description = "Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. Will keep your child company with a range of familiar phrases and sounds.",
           //         Price = 200.00m,
           //         CategoryId = 3

           //     },
           //     new Product()
           //     {
           //         Name = "Sunshine",
           //         Description = "Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. This large soft toy of Upsy Daisy - star of TV's In The Night garden - will keep your child company with a range of familiar phrases and sounds.",
           //         Price = 2000m,
           //         CategoryId = 3

           //     },
           //     //baby accessories
           //     new Product()
           //     {
           //         Name = "Baby Girl",
           //         Description = "Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. This large soft toy of Upsy Daisy - star of TV's In The Night garden - will keep your child company with a range of familiar phrases and sounds.",
           //         Price = 5.5m,
           //         CategoryId = 4

           //     },
           //     new Product()
           //     {
           //         Name = "Baby Boy",
           //         Description = "Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. This large soft toy of Upsy Daisy - star of TV's In The Night garden - will keep your child company with a range of familiar phrases and sounds.  Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores.",
           //         Price = 10.7m,
           //         CategoryId = 4

           //     },
           //     //desks
           //     new Product()
           //     {
           //         Name = "Classic",
           //         Description = "Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. ",
           //         Price = 23.65m,
           //         CategoryId = 5

           //     },
           //     new Product()
           //     {
           //         Name = "Girl",
           //         Description = "Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores.",
           //         Price = 100.10m,
           //         CategoryId = 5

           //     },
           //     new Product()
           //     {
           //         Name = "Modern",
           //         Description = "Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores.Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores.",
           //         Price = 89.99m,
           //         CategoryId = 5

           //     },
           //     new Product()
           //     {
           //         Name = "Colorfull",
           //         Description = "Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores.Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores.Lorem ipsum dolor sit amet, id posse honestatis pri, pri id unum homero option. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores. Ut vel menandri persecuti temporibus, te rebum accommodare sea. Exerci oportere sed id, vim et modus latine, ne ipsum postea vim. Eum affert labores epicuri ad, sale option ex nec, invidunt verterem imperdiet ne ius. Mel at putant labores.",
           //         Price = 45.87m,
           //         CategoryId = 5
           //     });

           // context.Articles.AddOrUpdate(article => article.Title,
           //     new Article()
           //     {
           //         Title= "Praesent Quis Felis Non Diam Volutpat Sollicitudin.",
           //         Content = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\"(The Extremes of Good and Evil) by Cicero, written in 45 BC.This book is a treatise on the theory of ethics, very popular during the Renaissance.The first line of Lorem Ipsum,\"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H.Rackham.",
           //         PublishDate = DateTime.Now.ToString("dd-MM-yyyy")

           //     });
        }
    }
}
