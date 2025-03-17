using ContactsMasterData.DBContext;
using ContactsMasterData.Domain;
using ContactsMasterData.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ContactsMasterData.Repository
{
    public class ContactRepository : Repository, IContactRepository
    {
        public ContactRepository(ContactsMasterDbContext contactsMasterDbContext) : base(contactsMasterDbContext)
        {
        }

        public async Task<int> CreateContact(Contact contact)
        {
            Context.Add(contact);
            await Context.SaveChangesAsync();
            return contact.ContactId;
        }

        public async Task DeleteContact(Contact contact)
        {
            Context.Remove(contact);
            await Context.SaveChangesAsync();
        }

        public async Task<Contact> Get(int id)
        {
            return await Context.Contacts.FirstOrDefaultAsync(x => x.ContactId == id) ?? new Contact();
        }

        public async Task<List<Contact>> List()
        {
            return await Context.Contacts.OrderByDescending(x=>x.ModifiedDateTime).ToListAsync();
        }

        public async Task<int> UpdateContact(Contact contact)
        {
            Context.Contacts.Update(contact);
            await Context.SaveChangesAsync();
            return contact.ContactId;
        }
    }
}
