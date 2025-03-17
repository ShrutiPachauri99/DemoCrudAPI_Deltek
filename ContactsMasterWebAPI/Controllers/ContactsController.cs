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
        public async Task<ActionResult<ContactViewModel>> Get(int contactId)
        {
            // Retrieve the contact from your business logic or repository
            var contact = await _contactLogic.Get(contactId);

            // Check if the contact exists
            if (contact == null)
            {
                // If not found, return a 404 Not Found response
                return NotFound($"Contact with ID {contactId} not found.");
            }

            // If found, return the contact data with a 200 OK response
            return Ok(contact);
        }


        [HttpGet("List")]
        public async Task<ActionResult<List<ContactViewModel>>> List()
        {
            // Retrieve the list of contacts from your business logic or repository
            var contacts = await _contactLogic.List();

            // Check if no contacts are found
            if (contacts == null || !contacts.Any())
            {
                // If no contacts are found, return a 404 Not Found response
                return NotFound("No contacts found.");
            }

            // If contacts are found, return the list with a 200 OK response
            return Ok(contacts);
        }



        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ContactViewModel contactViewModel)
        {
            if (contactViewModel == null)
            {
                return BadRequest("Invalid contact data.");
            }

            var contactId = await _contactLogic.Create(contactViewModel);

            if (contactId > 0)
            {
                return Ok(contactId); // Return the ID of the created contact
            }
            else
            {
                return StatusCode(500, "An error occurred while creating the contact.");
            }
        }

        [HttpPost("Update")]
        public async Task<ActionResult<int>> Update(ContactViewModel contactViewModel)
        {
            if (contactViewModel == null)
            {
                // If the request body is null, return a 400 Bad Request response
                return BadRequest("Invalid contact data.");
            }

            // Call the business logic to update the contact
            var updatedContactId = await _contactLogic.Update(contactViewModel);

            if (updatedContactId <= 0)
            {
                // If the update operation fails, return a 404 Not Found or 500 Internal Server Error
                return NotFound("Contact not found or could not be updated.");
            }

            // If successful, return the updated contact ID with a 200 OK response
            return Ok(updatedContactId);
        }


        [HttpDelete("Delete")]
        public async Task<ActionResult<ContactViewModel>> Delete(ContactViewModel contactViewModel)
        {
            if (contactViewModel == null || contactViewModel.ContactId <= 0)
            {
                // If the contact data is invalid or the ID is not provided, return a 400 Bad Request response
                return BadRequest("Invalid contact data.");
            }

            // Call the business logic to delete the contact
            var deletedContact = await _contactLogic.Delete(contactViewModel);

            if (deletedContact == null)
            {
                // If the contact was not found, return a 404 Not Found response
                return NotFound("Contact not found.");
            }

            // If successful, return the deleted contact with a 200 OK response
            return Ok(deletedContact);
        }

        #endregion
    }
}
