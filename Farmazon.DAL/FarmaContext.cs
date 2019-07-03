using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmazon.DAL
{
    public class FarmaContext : DbContext
    {
        public FarmaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> User { get; set; }
        public DbSet<Products> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(new Users
            {
                userId = 1,
                firstName = "Enes",
                lastName = "Ecer",
                userPassword = "pW1234!",
                dateOfBirth = new DateTime(1995,10,20),
                phoneNumber = "11223344556677",
                email = "email@mail.com"
            },new Users
            {
                userId = 2,
                firstName = "Oguzcan",
                lastName = "Arslan",
                userPassword = "Pass1234!",
                dateOfBirth = new DateTime(1996, 10, 20),
                phoneNumber = "",
                email = "email2@mail.com"
            },new Users
            {
                userId = 3,
                firstName = "Ali",
                lastName = "Cennet",
                userPassword = "parola789",
                dateOfBirth = new DateTime(1995, 10, 20),
                phoneNumber = "113344667799852",
                email = ""
            });


            modelBuilder.Entity<Products>().HasData(new Products
            {
                productId = 1,
                productName = "Monitor 27",
                productOwnerId = 1,
                productOwnerName = "Enes",
                productOwnerLastName = "Ecer",
            },new Products
            {
                productId = 2,
                productName = "Klavye",
                productOwnerId = default(long),
                productOwnerName = "",
                productOwnerLastName = "",
            },new Products
            {
                productId = 3,
                productName = "Mekanik Klavye",
                productOwnerId = 1,
                productOwnerName = "Enes",
                productOwnerLastName = "Ecer",
            },new Products
            {
                productId = 4,
                productName = "Monitor 23",
                productOwnerId = 2,
                productOwnerName = "Oguzcan",
                productOwnerLastName = "Arslan",
            });
        }
    }

}
