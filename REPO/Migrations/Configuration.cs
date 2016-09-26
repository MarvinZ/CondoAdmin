using POCO;

namespace REPO.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<REPO.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(REPO.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            //add condo
            context.Condos.AddOrUpdate(
           p => p.Id,
           new Condo { Id = 1, Name = "Vistas de Monserrat", CreateDatetime = DateTime.Now, CreatedBy = "Seed", Balance = 5000000},
                      new Condo { Id = 2, Name = "Other condo..", CreateDatetime = DateTime.Now, CreatedBy = "Seed", Balance = 250000000 }

          );

            //status
            context.Statuses.AddOrUpdate(
             p => p.Id,
             new Status { Id = 1, Name = "Al dia", CreateDatetime = DateTime.Now, CreatedBy = "Seed" },
             new Status { Id = 2, Name = "Moroso", CreateDatetime = DateTime.Now, CreatedBy = "Seed" }
           );

            //add members to condo
            var member1 = new Member
            {
                Id = 1,
                Name = "Casa 28b-2",
                CondoId = 1,
                Balance = -38000,
                CreateDatetime = DateTime.Now,
                CreatedBy = "Seed",
                StatusId = 2
            };
            var member2 = new Member
            {
                Id = 2,
                Name = "Casa 29b-1",
                CondoId = 1,
                Balance = -40000,
                CreateDatetime = DateTime.Now,
                CreatedBy = "Seed",
                StatusId = 2
            };
            var member3 = new Member
            {
                Id = 3,
                Name = "Casa 1A-1",
                CondoId = 1,
                Balance = 555,
                CreateDatetime = DateTime.Now,
                CreatedBy = "Seed",
                StatusId = 1
            };
            var member4 = new Member
            {
                Id = 4,
                Name = "Casa 1A-2",
                CondoId = 1,
                Balance = 0,
                CreateDatetime = DateTime.Now,
                CreatedBy = "Seed",
                StatusId = 1
            };
            context.Members.AddOrUpdate(
               p => p.Id, member1, member2, member3, member4
             );

            //create people
            var person1 = new Person
            {
                Id = 1,
                FirstName = "Marvin",
                LastName = "Zumbado",
                DateOfBirth = new DateTime(1982, 6, 9),
                CreateDatetime = DateTime.Now,
                CreatedBy = "Seed"
            };

            var person2 = new Person
            {
                Id = 2,
                FirstName = "Ximena",
                LastName = "Rojas",
                DateOfBirth = new DateTime(1981, 2, 8),
                CreateDatetime = DateTime.Now,
                CreatedBy = "Seed"
            };

            var person3 = new Person
            {
                Id = 3,
                FirstName = "La vecina",
                LastName = "Loca",
                DateOfBirth = new DateTime(1950, 12, 25),
                CreateDatetime = DateTime.Now,
                CreatedBy = "Seed"
            };

            context.People.AddOrUpdate(
        p => p.Id, person1, person2, person3);

            //add people to members
            var memberPerson1 = new MemberPerson
            {
                Id = 1,
                Member = member1,
                Person = person1,
                CreateDatetime = DateTime.Now,
                CreatedBy = "Seed"
            };

            var memberPerson2 = new MemberPerson
            {
                Id = 2,
                Member = member1,
                Person = person2,
                CreateDatetime = DateTime.Now,
                CreatedBy = "Seed"
            };

            var memberPerson3 = new MemberPerson
            {
                Id = 3,
                Member = member2,
                Person = person3,
                CreateDatetime = DateTime.Now,
                CreatedBy = "Seed"
            };

            context.MemberPersons.AddOrUpdate(p => p.Id, memberPerson1, memberPerson2, memberPerson3);


            //transactionTypes
            context.TransactionTypes.AddOrUpdate(
             p => p.Id,
             new TransactionType { Id = 1, Name = "Cobro", CreateDatetime = DateTime.Now, CreatedBy = "Seed" },
             new TransactionType { Id = 2, Name = "Pago", CreateDatetime = DateTime.Now, CreatedBy = "Seed" }
            );
            //Transactions
            context.Transactions.AddOrUpdate(
         p => p.Id,
         new Transaction { Id = 1, Amount = 28000, TransactionTypeId = 1, MemberId = 1, Description = "Cuota Enero", TransactionDateTime = DateTime.Now, CreateDatetime = DateTime.Now, CreatedBy = "Seed" },
         new Transaction { Id = 2, Amount = 28000, TransactionTypeId = 1, MemberId = 2, Description = "Cuota Enero", TransactionDateTime = DateTime.Now, CreateDatetime = DateTime.Now, CreatedBy = "Seed" }
         ,
         new Transaction { Id = 3, Amount = 10000, TransactionTypeId = 1, MemberId = 1, Description = "Agua Enero", TransactionDateTime = DateTime.Now, CreateDatetime = DateTime.Now, CreatedBy = "Seed" }
         ,
         new Transaction { Id = 4, Amount = 12000, TransactionTypeId = 1, MemberId = 2, Description = "Agua Enero", TransactionDateTime = DateTime.Now, CreateDatetime = DateTime.Now, CreatedBy = "Seed" }
        );
            context.Amenities.AddOrUpdate(
               p => p.Id, new Amenity()
               {
                   Id = 1,
                   Name = "Piscina",
                   CondoId = 1,
                   Description = "tiene agua mojada y fria"
               },
               new Amenity()
               {
                   Id = 2,
                   Name = "Rancho # 1",
                   CondoId = 1,
                   Description = "Para las carne asadas! mmmm"
               },
               new Amenity()
               {
                   Id = 3,
                   Name = "Sala de Cina",
                   CondoId = 1,
                   Description = "Para jugar play"
               }
             );

            context.AmenityReservationStatuses.AddOrUpdate(
                p => p.Id, new AmenityReservationStatus()
                {
                    Id = 1,
                    Name = "Active"
                },
                new AmenityReservationStatus()
                {
                    Id = 2,
                    Name = "In progress"
                },
                new AmenityReservationStatus()
                {
                    Id = 3,
                    Name = "Finalized"
                },
                new AmenityReservationStatus()
                {
                    Id = 6,
                    Name = "Cancelled"
                });

            context.AmenityReservations.AddOrUpdate(
                p => p.Id, new AmenityReservation()
                {
                    Id = 1,
                    AmenityId = 1,
                    MemberId = 1,
                    PersonId = 1,
                    AmenityReservationStatusId = 1,
                    StartTime = DateTime.Now,
                    EndDatetime = DateTime.UtcNow
                }, new AmenityReservation()
                {
                    Id = 2,
                    AmenityId = 1,
                    MemberId = 2,
                    PersonId = 3,
                    AmenityReservationStatusId = 1,
                    StartTime = DateTime.Now.AddDays(3),
                    EndDatetime = DateTime.UtcNow.AddDays(3)
                });


            /**********************************Condo Transactions********************************/
            //transactionTypes
            context.CondoTransactionTypes.AddOrUpdate(
             p => p.Id,
             new CondoTransactionType { Id = 1, Name = "Seguridad", CreateDatetime = DateTime.Now, CreatedBy = "Seed" },
             new CondoTransactionType { Id = 2, Name = "Administracion", CreateDatetime = DateTime.Now, CreatedBy = "Seed" }
            );

            context.CondoTransactions.AddOrUpdate(
p => p.Id,
new CondoTransaction { Id = 1, Amount = 1000000, CondoTransactionTypeId = 1, CondoId = 1, Description = "Seguridad Enero", TransactionDateTime = DateTime.Now, CreateDatetime = DateTime.Now, CreatedBy = "Seed" },
new CondoTransaction { Id = 2, Amount = 1000000, CondoTransactionTypeId = 1, CondoId = 1, Description = "Seguridad Febrero", TransactionDateTime = DateTime.Now, CreateDatetime = DateTime.Now, CreatedBy = "Seed" }
,
new CondoTransaction { Id = 3, Amount = 500000, CondoTransactionTypeId = 2, CondoId = 1, Description = "Administracion Enero", TransactionDateTime = DateTime.Now, CreateDatetime = DateTime.Now, CreatedBy = "Seed" }
,
new CondoTransaction { Id = 4, Amount = 500000, CondoTransactionTypeId = 2, CondoId = 1, Description = "Administracion Febrero", TransactionDateTime = DateTime.Now, CreateDatetime = DateTime.Now, CreatedBy = "Seed" }
);

        }
    }
}
