using Microsoft.EntityFrameworkCore;
using secretsantaapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using secretsantaapp.Database;
using System.IO;

namespace secretsantaapp.Seeder
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<string> Salt = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Salt.Add(UsersService.GenerateSalt());
            }

            #region Dodavanje uloga
            modelBuilder.Entity<Roles>().HasData(
                new Roles()
                {
                    RolesId = 1,
                    RoleName = "Admin",
                    RoleDuty = "Upravljanje sistemom"
                },
                new Roles()
                {
                    RolesId = 2,
                    RoleName = "Uposlenik",
                    RoleDuty = "Rad na sistemu"
                });
            #endregion

            #region Dodavanje korisnika
            modelBuilder.Entity<Users>().HasData(
                new Users()
                {
                    UsersId = 1,
                    FirstName = "Belma",
                    LastName = "Nukic",
                    Email = "belma@example.com",
                    Phone = "062147147",
                    Username = "belma",
                    PaswordSalt = Salt[0],
                    PasswordHash = UsersService.GenerateHash(Salt[0], "belma"),
                    Address="Opine bb, Mostar"
                },
                new Users()
                {
                    UsersId = 2,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@gmail.com",
                    Phone = "063222111",
                    Username = "admin",
                    PaswordSalt = Salt[1],
                    PasswordHash = UsersService.GenerateHash(Salt[1], "admin"),
                    Address="Jukiceva 36, Sarajevo"
                },
                new Users()
                {
                    UsersId = 3,
                    FirstName = "Uposlenik",
                    LastName = "Uposlenik",
                    Email = "uposlenik@gmail.com",
                    Phone = "063132233",
                    Username = "uposlenik",
                    PaswordSalt = Salt[2],
                    PasswordHash = UsersService.GenerateHash(Salt[2], "uposlenik"),
                    Address="Sehovina bb, Mostar"
                },
                new Users()
                {
                    UsersId = 4,
                    FirstName = "Ema",
                    LastName = "Bojcic",
                    Email = "ema@gmail.com",
                    Phone = "0631231323",
                    Username = "ema",
                    PaswordSalt = Salt[3],
                    PasswordHash = UsersService.GenerateHash(Salt[2], "ema"), 
                    Address="Opine bb, Mostar"
                });
            #endregion

            #region Dodavanje korisnickih uloga korisnicima
            modelBuilder.Entity<UsersRoles>().HasData(
                new UsersRoles()
                {
                    UsersRolesId = 1,
                    RolesId = 1,
                    UsersId = 2,
                    PublishedDate = DateTime.Now
                },
               new UsersRoles()
               {
                   UsersRolesId = 2,
                   RolesId = 2,
                   UsersId = 1,
                   PublishedDate = DateTime.Now
               },
                new UsersRoles()
                {
                    UsersRolesId = 3,
                    RolesId = 2,
                    UsersId = 3,
                    PublishedDate = DateTime.Now
                },
                new UsersRoles()
                {
                    UsersRolesId = 4,
                    RolesId = 2,
                    UsersId = 4,
                    PublishedDate = DateTime.Now
                });
            #endregion
        }
    }
}