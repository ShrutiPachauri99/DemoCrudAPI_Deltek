using Asp.Versioning;
using ContactsMasterInfra.ViewModel;
using ContactsMasterLogic.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace ContactsMasterWebAPI.Controllers
{
    [ApiController]

    [ApiVersion("1.0")]
    [Route("api/v1/Contacts")]
    public class ContactsController : Controller
    {
        #region Variables
        private readonly IContactLogic _contactLogic;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="contactLogic"></param>
        public ContactsController(IContactLogic contactLogic)
        {
            _contactLogic = contactLogic;
        }
        #endregion

        #region Methods
        [HttpGet("Get")]
        public async Task<ContactViewModel> Get(int contactId)
        {
            return await _contactLogic.Get(contactId);
        }

        [HttpGet("List")]
        public async Task<List<ContactViewModel>> List()
        {
            return await _contactLogic.List();
        }

        [HttpPost("Create")]
        public async Task<int> Create(ContactViewModel contactViewModel)
        {
            return await _contactLogic.Create(contactViewModel);
        }

        [HttpPost("Update")]
        public async Task<int> Update(ContactViewModel contactViewModel)
        {
            return await _contactLogic.Update(contactViewModel);
        }

        [HttpDelete("Delete")]
        public async Task<ContactViewModel> Delete(ContactViewModel contactViewModel)
        {
            return await _contactLogic.Delete(contactViewModel);
        }
        #endregion
    }
}
