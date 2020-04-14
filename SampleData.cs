using PainterWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainterWebApplication
{
    public static class SampleData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Cards.Any())
            {
                Card card1 = new Card() { SerialNumber = 123 };
                Card card2 = new Card() { SerialNumber = 123 };
                Card card3 = new Card() { SerialNumber = 123 };

                context.Cards.AddRange(card1, card2, card3);
            }

            context.SaveChanges();

            if (!context.Sets.Any())
            {
                context.Sets.AddRange(
                    new Set
                    {
                        Name = "Avatar",
                        ReleaseDate = 2018,
                    });
                context.SaveChanges();
            }
            
            context.Painters.Add(
                new Painter
                {
                    Name = "Luke",
                    Surname = "Penberton",
                    Cards = new List<Card>()
                    {
                        new Card {SerialNumber = 12314 }
                    }
                }); ;
                
            context.SaveChanges();
            
        }
    }
}
