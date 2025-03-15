using ContactsMasterInfra.ViewModel;

namespace ContactsMasterLogic.IBusinessLogic
{
    public interface IContactLogic
    {
        public Task<ContactViewModel> Get(int id);

        public Task<List<ContactViewModel>> List();

        public Task<int> Update(ContactViewModel contactViewModel);

        public Task<ContactViewModel> Delete(ContactViewModel contactViewModel);

        public Task<int> Create(ContactViewModel contactViewModel);
    }
}
