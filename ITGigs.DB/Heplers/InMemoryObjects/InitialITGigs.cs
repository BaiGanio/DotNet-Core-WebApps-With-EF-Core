using ITGigs.ITGigService.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ITGigs.DB.Heplers.InMemoryObjects
{
    public static class InitialITGigs
    {
        public static void Seed(AppDbContext context)
        {
            if (context.ITGigs.Any()) return;
            foreach (var initialITGig in GetInitialITGigs())
            {
                context.ITGigs.Add(initialITGig);
            }
            context.SaveChanges();
        }

        private static List<ITGig> GetInitialITGigs()
        {
            return new List<ITGig>()
            {
                new ITGig(
                    "Get your dirty pants in the laundry - tutorials for begginers!",
                    "e42837c5-96f1-436d-9688-44f4ce1817d8",
                    "296ea834-9c20-4741-b4bd-310aa535bef8",
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQt8iNdkEEvPCrxDNlSoe1n75I2qagmp-v9AocaVT-5D74votbK-g",
                    250
                ),
                 new ITGig(
                    "Alchocol nirvana - how to get drunk with single shot - live demo! Master edition!",
                    "7979da9f-b30e-40fa-9e55-04b75c3cb893",
                    "d7289be4-836d-47fe-b0dd-d19d1aae9f77",
                    "http://cdn.ebaumsworld.com/mediaFiles/picture/2298480/83181906.jpg",
                    650
                )
            };
        }
    }
}
