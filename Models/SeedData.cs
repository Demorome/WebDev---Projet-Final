using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using INFO4042___Projet_Final.Data;
using System;
using System.Linq;

namespace INFO4042___Projet_Final.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new INFO4042___Projet_FinalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<INFO4042___Projet_FinalContext>>()))
            {
                // Demorome: Regarder s'il y a des catégories
                if (context.Category.Any())
                {
                    return;   // DB has been seeded
                }

                context.Category.AddRange(
                    new Category
                    {
                        Name = "Famille"
                    },
                    new Category
                    {
                        Name = "Ami"
                    },
                    new Category
                    {
                        Name = "Travail"
                    },
                    new Category
                    {
                        Name = "Autre"
                    }
                );

                // Demorome: Regarder s'il y a des contacts
                if (context.Contact.Any())
                {
                    return;   // DB has been seeded
                }
                context.Contact.AddRange(

                    new Contact
                    {
                        Name = "Demorome", // pour cet exemple, l'utilisateur se rajoute lui-même dans sa liste de contacts.
                        PhoneNumber = "777-777-7777",
                        UserName = "demorome",
                        CategoryId = 1,

                        Address = "11 Arroyo Lane",
                        City = null,
                        Email = null,
                        CreationDate = null,
                        Category = null
                    }     /* ,      
                    new Contact
                    {
                        Name = "Le frère de Demorome",
                        Address = "11 Arroyo Lane",
                        PhoneNumber = "777-888-8777",
                    },
                    new Contact
                    {
                        Name = "Bart Simpsons",
                        Address = "The Simpsons household",
                        PhoneNumber = "111-111-1111",
                    },
                    new Contact
                    {
                        Name = "Placeholder",
                        Address = null,
                        PhoneNumber = "121-124-5411",
                    },
                    new Contact
                    {
                        Name = "Placeholder #2",
                        Address = "",
                        PhoneNumber = "221-333-2345",
                    } */

                );
                
                context.SaveChanges();
            }
        }
    }

}
