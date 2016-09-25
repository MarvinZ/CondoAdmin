using POCO;

namespace REPO
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext
    {
        // Your context has been configured to use a 'Context' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'REPO.Context' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Context' 
        // connection string in the application configuration file.
        public Context()
            : base("DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Member> Members { get; set; }

        public virtual DbSet<MemberPerson> MemberPersons { get; set; }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }

        public virtual DbSet<Transaction> Transactions { get; set; }

        public virtual DbSet<Condo> Condos { get; set; }
        public virtual DbSet<Amenity> Amenities { get; set; }
        public virtual DbSet<AmenityReservation> AmenityReservations { get; set; }
        public virtual DbSet<AmenityReservationStatus> AmenityReservationStatuses { get; set; }

        //public virtual DbSet<Member> MyEntities { get; set; }

        //public virtual DbSet<Member> MyEntities { get; set; }

        //public virtual DbSet<Member> MyEntities { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}