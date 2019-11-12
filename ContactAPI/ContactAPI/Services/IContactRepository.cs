using ContactAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Services
{
    public interface IContactRepository
    {
       
        IEnumerable<Contact> GetContacts(int? pageIndex, int? pageSize);
        Contact GetContact(string contactId);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
        bool ContactExists(string contactId);

        bool Save();


    }
}
