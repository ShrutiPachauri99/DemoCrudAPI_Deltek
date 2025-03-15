using AutoMapper;
using ContactsMasterData.Domain;
using ContactsMasterData.IRepository;
using ContactsMasterInfra.ViewModel;
using ContactsMasterLogic.IBusinessLogic;

namespace ContactsMasterLogic.BusinessLogic
{
    public class ContactLogic : IContactLogic
    {
        #region Variables
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ContactLogic(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<int> Create(ContactViewModel contactViewModel)
        {
            DateTime dateTimeNow = DateTime.Now;
            Contact newContact = _mapper.Map<Contact>(contactViewModel);
            newContact.CreatedDateTime = dateTimeNow;
            newContact.ModifiedDateTime = dateTimeNow;
            return await _contactRepository.CreateContact(newContact);
        }

        public async Task<ContactViewModel> Delete(ContactViewModel contactViewModel)
        {
            Contact contact = _mapper.Map<Contact>(contactViewModel);
            await _contactRepository.DeleteContact(contact);
            return contactViewModel;
        }

        public async Task<ContactViewModel> Get(int id)
        {
            ContactViewModel contactViewModel = _mapper.Map<ContactViewModel>(await _contactRepository.Get(id));
            return contactViewModel;
        }

        public async Task<List<ContactViewModel>> List()
        {
            List<ContactViewModel> contactViewModelList = _mapper.Map<List<ContactViewModel>>(await _contactRepository.List());
            return contactViewModelList;
        }

        public async Task<int> Update(ContactViewModel contactViewModel)
        {
            Contact newContact = _mapper.Map<Contact>(contactViewModel);
            newContact.ModifiedDateTime = DateTime.Now;
            return await _contactRepository.UpdateContact(newContact);
        }

        #endregion
    }
}
