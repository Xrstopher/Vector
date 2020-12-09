using Vector.Domain.Entities;
using Vector.Domain.ValueObjects;
using Vector.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Vector.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {

            if (!context.Students.Any())
            {
                context.Students.Add(new Student
                {
                    FirstName = "John",
                    MiddleName = "Edward",
                    LastName = "Smith",
                    Email = "jsmith@vector.com",
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            Title = "War of the Worlds",
                            Isbn = "978-0451530653",
                            PublicationDate = new System.DateTime(2007, 09, 07)
                        },
                        new Book()
                        {
                            Title = "Adventures in Programming",
                            Isbn = "978-0451545613",
                            PublicationDate = new System.DateTime(2020, 12, 09)
                        },
                        new Book()
                        {
                            Title = "The Greatest Story Ever Told",
                            Isbn = "978-0412330653",
                            PublicationDate = new System.DateTime(2020, 09, 24)
                        },

                    },

                });

                context.Students.Add(new Student
                {
                    FirstName = "Jenny",
                    MiddleName = null,
                    LastName = "Wheeler",
                    Email = "jwheeler@vector.com",
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            Title = "The Hobbit",
                            Isbn = "978-0453491653",
                            PublicationDate = new System.DateTime(2010, 04, 01)
                        },
                        new Book()
                        {
                            Title = "Top Gun",
                            Isbn = "978-0100545613",
                            PublicationDate = new System.DateTime(2018, 12, 25)
                        }

                    },

                });

                context.Students.Add(new Student
                {
                    FirstName = "John",
                    MiddleName = "A.",
                    LastName = "Oliver",
                    Email = "joliver@vector.com",
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            Title = "Pride and Prejudice",
                            Isbn = "978-0453498883",
                            PublicationDate = new System.DateTime(1999, 02, 01)
                        }

                    },

                });

                context.Students.Add(new Student
                {
                    FirstName = "Scott",
                    MiddleName = "John",
                    LastName = "Dansteve",
                    Email = "sdansteve@vector.com",
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            Title = "Something About Stamps",
                            Isbn = "978-045322283",
                            PublicationDate = new System.DateTime(1991, 05, 23)
                        }

                    },

                });


                await context.SaveChangesAsync();
            }

        }
    }
}
