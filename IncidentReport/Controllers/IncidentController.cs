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

            try
            {
                // Check if the contact exists
                var contact = await _contactRepository.GetContactByAccountNameAsync(request.AccountName);

                if (contact != null)
                {
                    // Update contact details if necessary
                    contact.FirstName = request.ContactFirstName;
                    contact.LastName = request.ContactLastName;

                    // Link contact to account if not already linked
                    if (account.ContactId != contact.Id)
                    {
                        account.ContactId = contact.Id;
                    }
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

                    await _contactRepository.AddContact(contact);

                    // Link new contact to account
                    account.ContactId = contact.Id;
                }
                var incident = new Incident
                {
                    Description = request.IncidentDescription,
                    AccountId = account.Id
                };
                // Create new incident response
                var incidentRes = new IncidentResDto
                {
                    ContactEmail = request.ContactEmail,
                    IncidentDescription = request.IncidentDescription,
                    CreatedAt = DateTime.UtcNow
                };

                _incidentRepository.AddIncident(incident);
                await unitOfWork.SaveAsync();

                return Ok(incidentRes);
            }
            catch (DbUpdateException ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);

                return StatusCode(500, "An error occurred while saving the changes to the database. Please check the inner exception for details.");
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine(ex.Message);

                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }


        // Method to get all incidents
        [HttpGet]
        [Route("api/incident/get-all")]
        public async Task<IActionResult> GetAllIncidents()
        {
            try
            {
                var incidents = await _incidentRepository.GetIncidentsAsync();
                return Ok(incidents);
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while retrieving the incidents.");
            }
        }

    }
}

