using ContactAPI.DbContexts;
using ContactAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Services
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            contact.Id = Guid.NewGuid().ToString();


            //foreach (var address in contact.Addresses)
            //{
            //    address.Id = Guid.NewGuid().ToString();
            //}

            _context.Contacts.Add(contact);

        }

        public bool ContactExists(string contactId)
        {
            if (contactId == null)
            {
                throw new ArgumentNullException(nameof(contactId));
            }

            return _context.Contacts.Any(c => c.Id == contactId);
        }

        public void DeleteContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            _context.Contacts.Remove(contact);
        }

        public Contact GetContact(string contactId)
        {
            if (contactId == null)
            {
                throw new ArgumentNullException(nameof(contactId));
            }

            return _context.Contacts.FirstOrDefault(c => c.Id == contactId);
        }

        public IEnumerable<Contact> GetContacts(int? pageIndex, int? pageSize)
        {
            return _context.Contacts
                .OrderBy(s => s.Id)
                .Take(pageSize.GetValueOrDefault(100))
                .Skip(pageIndex.GetValueOrDefault(0) * pageSize.GetValueOrDefault(100))
                .ToList<Contact>();
        }

        public void UpdateContact(Contact contact)
        {
            // no code in this implementation
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
