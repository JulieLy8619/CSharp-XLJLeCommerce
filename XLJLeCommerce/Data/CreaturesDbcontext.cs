using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Models;

namespace XLJLeCommerce.Data
{
    public class CreaturesDbcontext: DbContext
    {
        public CreaturesDbcontext(DbContextOptions<CreaturesDbcontext> options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Unicorn",
                    Sku = "Unicorn1abc123",
                    Price = 20,
                    Description = "The Unicorn is like a horse but has a magical horn that makes it more and better than a standard horse.",
                    ImageURL = "~/Unicorn.png",
                    VIPItem = true
                },
                new Product
                {
                    ID = 2,
                    Name = "Dragon",
                    Sku = "Dragon1abc123",
                    Price = 25,
                    Description = "The Dragon is a powerful magical lizard. About 30 times the size of a normal lizard and has special powers like breaths fire.",
                    ImageURL = "~/Assets/Dragon2.png",
                    VIPItem = false
                },
                new Product
                {
                    ID = 3,
                    Name = "Fairy",
                    Sku = "Fairy1abc123",
                    Price = 30,
                    Description = "The Fairy is a tiny magical being. They are about the size of an adult hand, faster than light, and have special fairy dust.",
                    ImageURL = "~/Fairy2Cropped.jpg",
                    VIPItem = false
                },
                new Product
                {
                    ID = 4,
                    Name = "Griffin",
                    Sku = "Griffin1abc123",
                    Price = 20,
                    Description = "The Griffin is a powerful magical creature. They are about the size of a grown elephant and has 3 times the strength of a whales bite.",
                    ImageURL = "/Assets/Griffin.png",
                    VIPItem = false
                },
                new Product
                {
                    ID = 5,
                    Name = "Hydra",
                    Sku = "Hydra1abc123",
                    Price = 10,
                    Description = "The Hydra is a tiny but powerful animal, yet as gentle as a dmesticated puppy. They are about the size of two adult hands.",
                    ImageURL = "~/Hydra.png",
                    VIPItem = false
                },
                new Product
                {
                    ID = 6,
                    Name = "NawWhal",
                    Sku = "Narwhal1abc123",
                    Price = 50,
                    Description = "The Narwhal is a mystical sea creature who is related to the Unicorn family. They power comes from their horn like the Unicorn, however they are limited to only surviving in water. However, one of their magical powers is changing size to fit whatever water space size.",
                    ImageURL = "~/Narwhal.png",
                    VIPItem = false
                },
                new Product
                {
                    ID = 7,
                    Name = "Troll",
                    Sku = "Troll1abc123",
                    Price = 15,
                    Description = "The Troll is a misunderstood being. They often have a facade of ignorance, however they are genius, like Einstein IQ level",
                    ImageURL = "~/Troll.png",
                    VIPItem = false
                },
                new Product
                {
                    ID = 8,
                    Name = "Werewolf",
                    Sku = "Werewolf1abc123",
                    Price = 15,
                    Description = "The Werewolf is a decieving beast because they are human by day, and wolf by night. Becautious as it is unknown but they are the pranksters of the animal world.",
                    ImageURL = "~/WereWolf.png",
                    VIPItem = true
                },
                new Product
                {
                    ID = 9,
                    Name = "Minotaur",
                    Sku = "Minotaur1abc123",
                    Price = 20,
                    Description = "The Minotaur is a half human half horse. They are the size of a dwarfed giant with a slightly larger horse. Their powers include mind reading and surviving on nothing for a year. They live for several hundreds of years.",
                    ImageURL = "~/Minotaur.jpg",
                    VIPItem = false
                },
                new Product
                {
                    ID = 10,
                    Name = "Mermaid",
                    Sku = "Mermaid1abc123",
                    Price = 40,
                    Description = "The Mermaid is half human and half fish. Their magic comes from their scales, which allows them to, but not limited to, create an illusion for how others view them.",
                    ImageURL = "~/MermaidCropped.jpg",
                    VIPItem = true
                }
            );
        }


        public DbSet<Product>  Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}
