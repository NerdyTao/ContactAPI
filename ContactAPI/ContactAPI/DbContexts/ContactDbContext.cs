using ContactAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.DbContexts
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Contact>().HasData(
                new Contact()
                {
                    Id = "d28888e9-2ba9-473a-a40f-e38cb54f9b35",
                    Name = "Berry",
                    LastName = "Griffin",
                    Avatar = "",
                    NickName = "BG",
                    Company = "247pro",
                    JobTitle = "SDE",
                    Email = "bg@247pro.com",
                    Phone = "1234567890",
                    Address = "533 Airport blvd, suite 505, burlingame, CA 94010 ",
                    Birthday = "05-05-1996",
                    Notes = "Ships"
                },
                new Contact()
                {
                    Id = "c31111f2-5cqa4-156g-g20e-h62ab54f9k91",
                    Name = "Ben",
                    LastName = "Mateo",
                    Avatar = "",
                    NickName = "Benteo",
                    Company = "modobay",
                    JobTitle = "SDE",
                    Email = "BM@modobay.com",
                    Phone = "9876543210",
                    Address = "1299 Bayshore hwy, rm 128, burlingame, CA 94010",
                    Birthday = "09-08-1995",
                    Notes = "Cars"
                },
                new Contact()
                {
                    Id = "a35555f2-5cqa4-156g-g20e-h62ab54f9k91",
                    Name = "Penelope",
                    LastName = "Julie",
                    Avatar = "",
                    NickName = "PJ",
                    Company = "modobay",
                    JobTitle = "Designer",
                    Email = "PJ@modobay.com",
                    Phone = "9876543210",
                    Address = "1299 Bayshore hwy, rm 128, burlingame, CA 94010",
                    Birthday = "10-28-1994",
                    Notes = "Singing"
                },
                new Contact()
                {
                    Id = "f75555a2-4dd2-132d-d20d-d61dc11a2f24",
                    Name = "Matthew",
                    LastName = "Jones",
                    Avatar = "",
                    NickName = "MJ",
                    Company = "247pro",
                    JobTitle = "SDE",
                    Email = "mj@247pro.com",
                    Phone = "1111111111",
                    Address = "533 Airport blvd, suite 505, burlingame, CA 94010 ",
                    Birthday = "01-08-1991",
                    Notes = "Bulls"
                }
                );

            base.OnModelCreating(modelBuilder);

        }
    }
}
