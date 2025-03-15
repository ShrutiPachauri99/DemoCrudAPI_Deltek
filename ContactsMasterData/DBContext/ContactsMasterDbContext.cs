using ContactsMasterData.Domain;
using Microsoft.EntityFrameworkCore;

namespace ContactsMasterData.DBContext
{
    public class ContactsMasterDbContext : DbContext
    {
        public ContactsMasterDbContext(DbContextOptions<ContactsMasterDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime dateTimeNow = DateTime.UtcNow;

            modelBuilder.Entity<Contact>().HasData(
                new Contact { ContactId = 1, ContactName = "John Doe", ContactEmail = "john.doe@example.com", ContactPhone = 1234567890, ContactAddress = "123 Street, NY", ContactBirthDate = new DateTime(1990, 5, 10), CreatedDateTime = dateTimeNow, ModifiedDateTime = dateTimeNow },
                new Contact { ContactId = 2, ContactName = "Jane Smith", ContactEmail = "jane.smith@example.com", ContactPhone = 987654321, ContactAddress = "456 Avenue, LA", ContactBirthDate = new DateTime(1985, 8, 20), CreatedDateTime = dateTimeNow, ModifiedDateTime = dateTimeNow },
                new Contact { ContactId = 3, ContactName = "Alice Johnson", ContactEmail = "alice.johnson@example.com", ContactPhone = 555666777, ContactAddress = "789 Blvd, TX", ContactBirthDate = new DateTime(1992, 2, 15), CreatedDateTime = dateTimeNow, ModifiedDateTime = dateTimeNow },
                new Contact { ContactId = 4, ContactName = "Bob Williams", ContactEmail = "bob.williams@example.com", ContactPhone = 444555666, ContactAddress = "1011 Lane, FL", ContactBirthDate = new DateTime(1980, 11, 5), CreatedDateTime = dateTimeNow, ModifiedDateTime = dateTimeNow },
                new Contact { ContactId = 5, ContactName = "Charlie Brown", ContactEmail = "charlie.brown@example.com", ContactPhone = 333222111, ContactAddress = "1213 Road, WA", ContactBirthDate = new DateTime(1995, 9, 25), CreatedDateTime = dateTimeNow, ModifiedDateTime = dateTimeNow },
                new Contact { ContactId = 6, ContactName = "David Miller", ContactEmail = "david.miller@example.com", ContactPhone = 112233445, ContactAddress = "1415 Circle, IL", ContactBirthDate = new DateTime(1988, 7, 30), CreatedDateTime = dateTimeNow, ModifiedDateTime = dateTimeNow },
                new Contact { ContactId = 7, ContactName = "Emma Wilson", ContactEmail = "emma.wilson@example.com", ContactPhone = 998877665, ContactAddress = "1617 Park, GA", ContactBirthDate = new DateTime(1993, 4, 18), CreatedDateTime = dateTimeNow, ModifiedDateTime = dateTimeNow },
                new Contact { ContactId = 8, ContactName = "Frank Thomas", ContactEmail = "frank.thomas@example.com", ContactPhone = 776655443, ContactAddress = "1819 Drive, OH", ContactBirthDate = new DateTime(1975, 12, 10), CreatedDateTime = dateTimeNow, ModifiedDateTime = dateTimeNow },
                new Contact { ContactId = 9, ContactName = "Grace Lee", ContactEmail = "grace.lee@example.com", ContactPhone = 665544332, ContactAddress = "2021 Path, NV", ContactBirthDate = new DateTime(2000, 1, 22), CreatedDateTime = dateTimeNow, ModifiedDateTime = dateTimeNow },
                new Contact { ContactId = 10, ContactName = "Henry Scott", ContactEmail = "henry.scott@example.com", ContactPhone = 554433221, ContactAddress = "2223 Trail, OR", ContactBirthDate = new DateTime(1991, 6, 14), CreatedDateTime = dateTimeNow, ModifiedDateTime = dateTimeNow }
            );
        }
    }
}
