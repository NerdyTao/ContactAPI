using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactAPI.Models;
using ContactAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactAPI.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {

        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository ??
                throw new ArgumentNullException(nameof(contactRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }



        // GET: api/contacts
        [HttpGet()]
        public IEnumerable<ContactDto> GetContacts([FromQuery] int? pageIndex, [FromQuery] int? pageSize)
        {
            var contactsFromRepo = _contactRepository.GetContacts(pageIndex, pageSize);
            return _mapper.Map<IEnumerable<ContactDto>>(contactsFromRepo);
        }

        // GET api/contact/id
        [HttpGet("{id}")]
        public IActionResult GetContact([FromRoute]string id)
        {
            var contactFromRepo = _contactRepository.GetContact(id);

            if (contactFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ContactDto>(contactFromRepo));
        }


        // POST api/contacts
        [HttpPost]
        public IActionResult CreateContact(ContactDto contact)
        {
            var contactEntity = _mapper.Map<Entities.Contact>(contact);
            _contactRepository.AddContact(contactEntity);
            _contactRepository.Save();

            var contactToReturn = _mapper.Map<ContactDto>(contactEntity);
            return Ok(contactToReturn);

        }


        // PUT api/contacts/id
        [HttpPut("{id}")]
        public IActionResult UpdateContact([FromRoute]string id, [FromBody] ContactDto contact)
        {
            if (!_contactRepository.ContactExists(id))
            {
                return NotFound();
            }

            var contactFromRepo = _contactRepository.GetContact(id);
            _mapper.Map(contact, contactFromRepo);
            _contactRepository.UpdateContact(contactFromRepo);
            _contactRepository.Save();
            return NoContent();

        }

        //[HttpOptions]
        //public IActionResult GetContactsOptions() 
        //{
        //    Response.Headers.Add("Allow", "GET,OPTIONS,POST");
        //    return Ok();
        //}

        // DELETE api/contacts/id
        [HttpDelete("{id}")]
        public ActionResult DeleteContact([FromRoute] string id)
        {
            var contactFromRepo = _contactRepository.GetContact(id);

            if (contactFromRepo == null)
            {
                return NotFound();
            }

            _contactRepository.DeleteContact(contactFromRepo);
            _contactRepository.Save();

            return NoContent();
        }
    }
}
