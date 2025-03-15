using ContactsMasterData.Domain;

namespace ContactsMasterData.IRepository
{
    public interface IContactRepository
    {
        public Task<Contact> Get(int id);

        public Task<List<Contact>> List();

        public Task<int> UpdateContact(Contact contact);

        public Task DeleteContact(Contact contact);

        public Task<int> CreateContact(Contact contact);
    }
}
