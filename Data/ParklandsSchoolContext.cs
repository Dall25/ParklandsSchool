using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Claims;

namespace Data
{
    public class ParklandsSchoolContext : DbContext
    {
        public ParklandsSchoolContext(DbContextOptions<ParklandsSchoolContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<UserClass> UserClass { get; set; }
        public DbSet<YearGroup> YearGroup { get; set; }
        public DbSet<UserType> UserType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.UserType)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.UserTypeId);

            modelBuilder.Entity<User>()
             .HasOne(a => a.YearGroup)
             .WithMany(a => a.Users)
             .HasForeignKey(a => a.YearGroupId);

            modelBuilder.Entity<UserType>()
               .HasKey(a => a.UserTypeId);

            modelBuilder.Entity<Class>()
                 .HasKey(us => new { us.ClassId, us.SchoolId });

            modelBuilder.Entity<UserClass>()
                .HasKey(us => new { us.UserId, us.ClassId, us.SchoolId });

            modelBuilder.Entity<UserClass>()
                .HasOne(a => a.User)
                .WithMany(a => a.UserClasses)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<UserClass>()
                .HasOne(a => a.Class)
                .WithMany(a => a.UserClasses)
                .HasForeignKey(a => new { a.ClassId, a.SchoolId });


            modelBuilder.Entity<YearGroup>()
            .HasKey(a => a.YearGroupId);


            SeedData(modelBuilder);


        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YearGroup>().HasData(
                new YearGroup { YearGroupId = 1, Name = "Year 1" },
                new YearGroup { YearGroupId = 2, Name = "Year 2" },
                new YearGroup { YearGroupId = 3, Name = "Year 3" },
                new YearGroup { YearGroupId = 4, Name = "Year 4" },
                new YearGroup { YearGroupId = 5, Name = "Year 5" },
                new YearGroup { YearGroupId = 6, Name = "Year 6" },
                new YearGroup { YearGroupId = 7, Name = "Year 7" },
                new YearGroup { YearGroupId = 8, Name = "Year 8" },
                new YearGroup { YearGroupId = 9, Name = "Year 9" },
                new YearGroup { YearGroupId = 10, Name = "Year 10" },
                new YearGroup { YearGroupId = 11, Name = "Year 11" },
                new YearGroup { YearGroupId = 12, Name = "Year 12" },
                new YearGroup { YearGroupId = 13, Name = "Year 13" }
                );

            modelBuilder.Entity<UserType>().HasData(
                new UserType { UserTypeId = 1, Name = "Teacher" },
                new UserType { UserTypeId = 2, Name = "Pupil" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = Guid.Parse("d818a056-1d33-4276-bc80-c8dcf128fe20"), UserTypeId = 1, YearGroupId = null, FirstName = "Ben", LastName = "Sztucki" },
                new User { UserId = Guid.Parse("630958ef-30c8-4c43-a822-f5b3b5192bd1"), UserTypeId = 2, YearGroupId = 1, FirstName = "Luke", LastName = "Dallimore" },
                new User { UserId = Guid.Parse("ff96657b-00c1-4c68-a6d6-4bd213777f53"), UserTypeId = 2, YearGroupId = 2, FirstName = "Mike", LastName = "Prosser" },
                new User { UserId = Guid.Parse("42481486-17f2-4cd3-bda2-04d3b46c8e0f"), UserTypeId = 2, YearGroupId = 3, FirstName = "Maddie", LastName = "Williams" },
                new User { UserId = Guid.Parse("ef258c81-b08e-4b73-9173-956db34a6e7b"), UserTypeId = 2, YearGroupId = 4, FirstName = "Sarah", LastName = "Williams" },
                new User { UserId = Guid.Parse("39b79056-d79a-4672-a068-104cc3d77116"), UserTypeId = 2, YearGroupId = 5, FirstName = "Jamie", LastName = "Buckley" }
                );


            modelBuilder.Entity<Class>().HasData(
           new Class { ClassId = "A1" },
           new Class { ClassId = "A2" },
           new Class { ClassId = "A3" },
           new Class { ClassId = "A4" },
           new Class { ClassId = "B1" },
           new Class { ClassId = "B2" },
           new Class { ClassId = "B3" },
           new Class { ClassId = "B4" },
           new Class { ClassId = "C1" },
           new Class { ClassId = "C2" },
           new Class { ClassId = "C3" },
           new Class { ClassId = "C4" }
           );


            modelBuilder.Entity<UserClass>().HasData(
                new UserClass { UserId = Guid.Parse("d818a056-1d33-4276-bc80-c8dcf128fe20"), ClassId = "A1" },
                new UserClass { UserId = Guid.Parse("d818a056-1d33-4276-bc80-c8dcf128fe20"), ClassId = "A2" },
                new UserClass { UserId = Guid.Parse("d818a056-1d33-4276-bc80-c8dcf128fe20"), ClassId = "A3" },
                new UserClass { UserId = Guid.Parse("630958ef-30c8-4c43-a822-f5b3b5192bd1"), ClassId = "A1" },
                new UserClass { UserId = Guid.Parse("630958ef-30c8-4c43-a822-f5b3b5192bd1"), ClassId = "A2" },
                new UserClass { UserId = Guid.Parse("ff96657b-00c1-4c68-a6d6-4bd213777f53"), ClassId = "B1" },
                new UserClass { UserId = Guid.Parse("ff96657b-00c1-4c68-a6d6-4bd213777f53"), ClassId = "B2" },
                new UserClass { UserId = Guid.Parse("42481486-17f2-4cd3-bda2-04d3b46c8e0f"), ClassId = "B1" },
                new UserClass { UserId = Guid.Parse("42481486-17f2-4cd3-bda2-04d3b46c8e0f"), ClassId = "B2" },
                new UserClass { UserId = Guid.Parse("ef258c81-b08e-4b73-9173-956db34a6e7b"), ClassId = "C1" },
                new UserClass { UserId = Guid.Parse("ef258c81-b08e-4b73-9173-956db34a6e7b"), ClassId = "C2" },
                new UserClass { UserId = Guid.Parse("39b79056-d79a-4672-a068-104cc3d77116"), ClassId = "C1" },
                new UserClass { UserId = Guid.Parse("39b79056-d79a-4672-a068-104cc3d77116"), ClassId = "C2" }
                );
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ParklandsSchoolContext>
    {
        public ParklandsSchoolContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../ParklandsSchool/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<ParklandsSchoolContext>();
            var connectionString = configuration.GetConnectionString("ParklandsSchoolContext");
            builder.UseSqlServer(connectionString);

            return new ParklandsSchoolContext(builder.Options);
        }
    }

}
