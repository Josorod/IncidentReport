using IncidentReport.Data;
using IncidentReport.DTO;
using IncidentReport.Interfaces;
using IncidentReport.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace IncidentReport.Controllers
{

    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentRepository _incidentRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork unitOfWork;

        public IncidentController(
            IIncidentRepository incidentRepository,
            IAccountRepository accountRepository,
            IContactRepository contactRepository,
            IUnitOfWork unitOfWork)
        {
            _incidentRepository = incidentRepository;
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("api/incident/create")]
        public async Task<IActionResult> CreateIncident([FromBody] IncidentReqDto request)
        {
            // Validate input
            if (request == null)
            {
                return BadRequest("Request body is null");
            }

            if (string.IsNullOrEmpty(request.AccountName))
            {
                return BadRequest("AccountName is required");
            }

            if (string.IsNullOrEmpty(request.ContactEmail))
            {
                return BadRequest("ContactEmail is required");
            }

            // Check if the account exists
            var account = await _accountRepository.GetAccountByNameAsync(request.AccountName);
            if (account == null)
            {
                return NotFound("Account not found");
            }

            // Check if the contact exists
            var contact = await _contactRepository.GetContactByEmailAsync(request.ContactEmail);

            if (contact != null)
            {
                // Update contact details if necessary
                contact.FirstName = request.ContactFirstName;
                contact.LastName = request.ContactLastName;
                contact.Email = request.ContactEmail;
            }
            else
            {
                // Create new contact
                contact = new Contact
                {
                    FirstName = request.ContactFirstName,
                    LastName = request.ContactLastName,
                    Email = request.ContactEmail
                };

                _contactRepository.AddContact(contact);
                //await unitOfWork.SaveAsync();
            }

            // Link contact to account if not already linked
            if (account.ContactId != contact.Id)
            {
                account.ContactId = contact.Id;
               // await unitOfWork.SaveAsync();
            }

            // Create new incident
            var incident = new Incident
            {
                Description = request.IncidentDescription,
                AccountId = account.Id
            };

            _incidentRepository.AddIncident(incident);
            await unitOfWork.SaveAsync();

            return Ok(incident);
        }
    }
}

