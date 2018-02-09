using ITGigs.Common.Extensions;
using ITGigs.UserService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITGigs.DB.Heplers.InMemoryObjects
{
    public static class InitialUsers
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Users.Any()) return;
            foreach (var initialUser in GetInitialUsers())
            {
                context.Users.Add(initialUser);
            }
            context.SaveChanges();
        }

        private static List<User> GetInitialUsers()
        {
            return new List<User>()
            {
                new User("Fiki"),
                new User("Me40 nyx"),
                new User(
                    "Буги Барабата",
                    new CustomId(new Guid("7979da9f-b30e-40fa-9e55-04b75c3cb893")),
                    "http://hotnews.bg/uploads/news/2012_02/p1/00047919.jpg"
                ),
                new User(
                    "Пинко Розовата Пантера",
                    new CustomId(new Guid("e42837c5-96f1-436d-9688-44f4ce1817d8")),
                    "http://media.avtora.com/images/cut/660x495/articles/2014/04/41277.jpg"
                )
            };
        }
    }
}
