using IncidentReport.Interfaces;
using IncidentReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace IncidentReport.Controllers
{
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        [Route("api/contact/create")]
        public async Task<IActionResult> AddContact([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact is null");
            }

            try
            {
                await _contactRepository.AddContact(contact);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while adding the contact");
            }
        }

        [HttpGet]
        [Route("api/contact/get-all")]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                var contacts = await _contactRepository.GetContactsAsync();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while retrieving the contacts");
            }
        }

        [HttpDelete]
        [Route("api/contact/delete-{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                await _contactRepository.DeleteContact(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while deleting the contact");
            }
        }
    }
}
